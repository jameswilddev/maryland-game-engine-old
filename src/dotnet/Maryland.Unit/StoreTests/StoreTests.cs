using Maryland.Stores;
using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;
using Moq;

namespace Maryland.Unit.StoreTests
{
    [TestClass]
    public sealed class StoreTests
    {
        [TestMethod]
        public void ExposesReferenceStore()
        {
            var referenceStore = new Mock<IReferenceStore>();
            var tagStore = new Mock<ITagStore>();

            var store = new Store(referenceStore.Object, tagStore.Object);

            Assert.AreSame(referenceStore.Object, store.ReferenceStore);
            referenceStore.VerifyNoOtherCalls();
            tagStore.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ExposesTagStore()
        {
            var referenceStore = new Mock<IReferenceStore>();
            var tagStore = new Mock<ITagStore>();

            var store = new Store(referenceStore.Object, tagStore.Object);

            Assert.AreSame(tagStore.Object, store.TagStore);
            referenceStore.VerifyNoOtherCalls();
            tagStore.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenReferenceStoreNull()
        {
            var tagStore = new Mock<ITagStore>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new Store(null, tagStore.Object);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("referenceStore", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'referenceStore')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            tagStore.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsExceptionWhenTagStoreNull()
        {
            var referenceStore = new Mock<IReferenceStore>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new Store(referenceStore.Object, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tagStore", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'tagStore')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
            referenceStore.VerifyNoOtherCalls();
        }
    }
}
