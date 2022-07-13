using Maryland.Stores;
using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;
using Moq;
using System.Collections.Immutable;

namespace Maryland.Unit.StoreTests
{
    [TestClass]
    public sealed class StoreDiffSerializerTests
    {
        [TestMethod]
        public void ExposesReferenceStoreDiffSerializer()
        {
            var referenceStoreDiffSerializer = new Mock<IReferenceStoreDiffSerializer>();
            var tagStoreDiffSerializer = new Mock<ITagStoreDiffSerializer>();

            var store = new StoreDiffSerializer(referenceStoreDiffSerializer.Object, tagStoreDiffSerializer.Object);

            Assert.AreSame(referenceStoreDiffSerializer.Object, store.ReferenceStoreDiffSerializer);
            referenceStoreDiffSerializer.VerifyNoOtherCalls();
            tagStoreDiffSerializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ExposesTagStoreDiffSerializer()
        {
            var referenceStoreDiffSerializer = new Mock<IReferenceStoreDiffSerializer>();
            var tagStoreDiffSerializer = new Mock<ITagStoreDiffSerializer>();

            var store = new StoreDiffSerializer(referenceStoreDiffSerializer.Object, tagStoreDiffSerializer.Object);

            Assert.AreSame(tagStoreDiffSerializer.Object, store.TagStoreDiffSerializer);
            referenceStoreDiffSerializer.VerifyNoOtherCalls();
            tagStoreDiffSerializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenReferenceStoreDiffSerializerNull()
        {
            var tagStoreDiffSerializer = new Mock<ITagStoreDiffSerializer>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreDiffSerializer(null, tagStoreDiffSerializer.Object);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("referenceStoreDiffSerializer", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'referenceStoreDiffSerializer')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            tagStoreDiffSerializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenTagStoreDiffSerializerNull()
        {
            var referenceStoreDiffSerializer = new Mock<IReferenceStoreDiffSerializer>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreDiffSerializer(referenceStoreDiffSerializer.Object, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tagStoreDiffSerializer", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'tagStoreDiffSerializer')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            referenceStoreDiffSerializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void SerializesDiff()
        {
            var referenceStoreDiffSerializer = new Mock<IReferenceStoreDiffSerializer>();
            var referenceStoreDiff = new ReferenceStoreDiff(ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty, ImmutableHashSet<EntityAttributeIdentifierPair>.Empty);
            referenceStoreDiffSerializer.Setup(s => s.Serialize(It.IsAny<ReferenceStoreDiff>())).Returns(new byte[] { 0x6d, 0xe6, 0xca });
            var tagStoreDiffSerializer = new Mock<ITagStoreDiffSerializer>();
            var tagStoreDiff = new TagStoreDiff(ImmutableDictionary<Guid, string>.Empty, ImmutableHashSet<Guid>.Empty);
            tagStoreDiffSerializer.Setup(s => s.Serialize(It.IsAny<TagStoreDiff>())).Returns(new byte[] { 0x7a, 0x59, 0xa6, 0x78, 0xde, 0x9f, 0xa5 });
            var storeDiff = new StoreDiff(referenceStoreDiff, tagStoreDiff);
            var storeDiffSerializer = new StoreDiffSerializer(referenceStoreDiffSerializer.Object, tagStoreDiffSerializer.Object);

            var bytes = storeDiffSerializer.Serialize(storeDiff);

            CollectionAssert.AreEqual(new byte[] { 0x6d, 0xe6, 0xca, 0x7a, 0x59, 0xa6, 0x78, 0xde, 0x9f, 0xa5 }, bytes.ToArray());
            referenceStoreDiffSerializer.Verify(c => c.Serialize(referenceStoreDiff), Times.Once());
            referenceStoreDiffSerializer.VerifyNoOtherCalls();
            tagStoreDiffSerializer.Verify(c => c.Serialize(tagStoreDiff), Times.Once());
            tagStoreDiffSerializer.VerifyNoOtherCalls();
        }
    }
}
