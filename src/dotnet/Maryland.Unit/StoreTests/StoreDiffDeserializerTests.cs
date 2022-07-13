using Maryland.Stores;
using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;
using Moq;
using System.Collections.Immutable;

namespace Maryland.Unit.StoreTests
{
    [TestClass]
    public sealed class StoreDiffDeserializerTests
    {
        [TestMethod]
        public void ExposesReferenceStoreDiffDeserializer()
        {
            var referenceStoreDiffDeserializer = new Mock<IReferenceStoreDiffDeserializer>();
            var tagStoreDiffDeserializer = new Mock<ITagStoreDiffDeserializer>();

            var store = new StoreDiffDeserializer(referenceStoreDiffDeserializer.Object, tagStoreDiffDeserializer.Object);

            Assert.AreSame(referenceStoreDiffDeserializer.Object, store.ReferenceStoreDiffDeserializer);
            referenceStoreDiffDeserializer.VerifyNoOtherCalls();
            tagStoreDiffDeserializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ExposesTagStoreDiffDeserializer()
        {
            var referenceStoreDiffDeserializer = new Mock<IReferenceStoreDiffDeserializer>();
            var tagStoreDiffDeserializer = new Mock<ITagStoreDiffDeserializer>();

            var store = new StoreDiffDeserializer(referenceStoreDiffDeserializer.Object, tagStoreDiffDeserializer.Object);

            Assert.AreSame(tagStoreDiffDeserializer.Object, store.TagStoreDiffDeserializer);
            referenceStoreDiffDeserializer.VerifyNoOtherCalls();
            tagStoreDiffDeserializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenReferenceStoreDiffDeserializerNull()
        {
            var tagStoreDiffDeserializer = new Mock<ITagStoreDiffDeserializer>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreDiffDeserializer(null, tagStoreDiffDeserializer.Object);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("referenceStoreDiffDeserializer", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'referenceStoreDiffDeserializer')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            tagStoreDiffDeserializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenTagStoreDiffDeserializerNull()
        {
            var referenceStoreDiffDeserializer = new Mock<IReferenceStoreDiffDeserializer>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreDiffDeserializer(referenceStoreDiffDeserializer.Object, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tagStoreDiffDeserializer", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'tagStoreDiffDeserializer')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            referenceStoreDiffDeserializer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task DeserializesDiff()
        {
            var callOrder = new List<string>();
            var referenceStoreDiffDeserializer = new Mock<IReferenceStoreDiffDeserializer>();
            var referenceStoreDiff = new ReferenceStoreDiff(ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty, ImmutableHashSet<EntityAttributeIdentifierPair>.Empty);
            referenceStoreDiffDeserializer
                .Setup(d => d.Deserialize(It.IsAny<IAsyncEnumerator<byte>>()))
                .Callback(() =>
                {
                    callOrder.Add("reference");
                })
                .Returns(Task.FromResult(referenceStoreDiff));
            var tagStoreDiffDeserializer = new Mock<ITagStoreDiffDeserializer>();
            var tagStoreDiff = new TagStoreDiff(ImmutableDictionary<Guid, string>.Empty, ImmutableHashSet<Guid>.Empty);
            tagStoreDiffDeserializer
                .Setup(d => d.Deserialize(It.IsAny<IAsyncEnumerator<byte>>()))
                .Callback(() =>
                {
                    callOrder.Add("tag");
                })
                .Returns(Task.FromResult(tagStoreDiff));
            var storeDiff = new StoreDiff(referenceStoreDiff, tagStoreDiff);
            var storeDiffDeserializer = new StoreDiffDeserializer(referenceStoreDiffDeserializer.Object, tagStoreDiffDeserializer.Object);
            var bytes = new Mock<IAsyncEnumerator<byte>>();

            var result = await storeDiffDeserializer.Deserialize(bytes.Object);

            Assert.AreSame(referenceStoreDiff, result.ReferenceStoreDiff);
            Assert.AreSame(tagStoreDiff, result.TagStoreDiff);
            referenceStoreDiffDeserializer.Verify(c => c.Deserialize(bytes.Object), Times.Once());
            referenceStoreDiffDeserializer.VerifyNoOtherCalls();
            tagStoreDiffDeserializer.Verify(c => c.Deserialize(bytes.Object), Times.Once());
            tagStoreDiffDeserializer.VerifyNoOtherCalls();
            bytes.VerifyNoOtherCalls();
            CollectionAssert.AreEqual(new[] { "reference", "tag" }, callOrder);
        }
    }
}
