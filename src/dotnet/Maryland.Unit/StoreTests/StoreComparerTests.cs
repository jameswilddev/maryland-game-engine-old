using Maryland.Stores;
using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;
using Moq;
using System.Collections.Immutable;

namespace Maryland.Unit.StoreTests
{
    [TestClass]
    public sealed class StoreComparerTests
    {
        [TestMethod]
        public void ExposesReferenceStoreComparer()
        {
            var referenceStoreComparer = new Mock<IReferenceStoreComparer>();
            var tagStoreComparer = new Mock<ITagStoreComparer>();

            var store = new StoreComparer(referenceStoreComparer.Object, tagStoreComparer.Object);

            Assert.AreSame(referenceStoreComparer.Object, store.ReferenceStoreComparer);
            referenceStoreComparer.VerifyNoOtherCalls();
            tagStoreComparer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ExposesTagStoreComparer()
        {
            var referenceStoreComparer = new Mock<IReferenceStoreComparer>();
            var tagStoreComparer = new Mock<ITagStoreComparer>();

            var store = new StoreComparer(referenceStoreComparer.Object, tagStoreComparer.Object);

            Assert.AreSame(tagStoreComparer.Object, store.TagStoreComparer);
            referenceStoreComparer.VerifyNoOtherCalls();
            tagStoreComparer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenReferenceStoreComparerNull()
        {
            var tagStoreComparer = new Mock<ITagStoreComparer>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreComparer(null, tagStoreComparer.Object);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("referenceStoreComparer", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'referenceStoreComparer')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            tagStoreComparer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenTagStoreComparerNull()
        {
            var referenceStoreComparer = new Mock<IReferenceStoreComparer>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreComparer(referenceStoreComparer.Object, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tagStoreComparer", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'tagStoreComparer')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            referenceStoreComparer.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void GeneratesDiffByComparingStores()
        {
            var referenceStoreComparer = new Mock<IReferenceStoreComparer>();
            var referenceStoreDiff = new ReferenceStoreDiff(ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty, ImmutableHashSet<EntityAttributeIdentifierPair>.Empty);
            referenceStoreComparer.Setup(c => c.Compare(It.IsAny<IReferenceStore>(), It.IsAny<IReferenceStore>())).Returns(referenceStoreDiff);
            var tagStoreComparer = new Mock<ITagStoreComparer>();
            var tagStoreDiff = new TagStoreDiff(ImmutableDictionary<Guid, string>.Empty, ImmutableHashSet<Guid>.Empty);
            tagStoreComparer.Setup(c => c.Compare(It.IsAny<ITagStore>(), It.IsAny<ITagStore>())).Returns(tagStoreDiff);
            var referenceStoreA = new Mock<IReferenceStore>();
            var tagStoreA = new Mock<ITagStore>();
            var storeA = new Store(referenceStoreA.Object, tagStoreA.Object);
            var referenceStoreB = new Mock<IReferenceStore>();
            var tagStoreB = new Mock<ITagStore>();
            var storeB = new Store(referenceStoreB.Object, tagStoreB.Object);
            var storeComparer = new StoreComparer(referenceStoreComparer.Object, tagStoreComparer.Object);

            var storeDiff = storeComparer.Compare(storeA, storeB);

            referenceStoreComparer.Verify(c => c.Compare(referenceStoreA.Object, referenceStoreB.Object), Times.Once());
            referenceStoreComparer.VerifyNoOtherCalls();
            tagStoreComparer.Verify(c => c.Compare(tagStoreA.Object, tagStoreB.Object), Times.Once());
            tagStoreComparer.VerifyNoOtherCalls();
            referenceStoreA.VerifyNoOtherCalls();
            tagStoreA.VerifyNoOtherCalls();
            referenceStoreB.VerifyNoOtherCalls();
            tagStoreB.VerifyNoOtherCalls();
        }
    }
}
