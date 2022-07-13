using Maryland.Stores;
using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;
using System.Collections.Immutable;

namespace Maryland.Unit.StoreTests
{
    [TestClass]
    public sealed class StoreDiffTests
    {
        [TestMethod]
        public void ExposesReferenceStore()
        {
            var referenceStoreDiff = new ReferenceStoreDiff(ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty, ImmutableHashSet<EntityAttributeIdentifierPair>.Empty);
            var tagStoreDiff = new TagStoreDiff(ImmutableDictionary<Guid, string>.Empty, ImmutableHashSet<Guid>.Empty);

            var storeDiff = new StoreDiff(referenceStoreDiff, tagStoreDiff);

            Assert.AreSame(referenceStoreDiff, storeDiff.ReferenceStoreDiff);
        }

        [TestMethod]
        public void ExposesTagStore()
        {
            var referenceStoreDiff = new ReferenceStoreDiff(ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty, ImmutableHashSet<EntityAttributeIdentifierPair>.Empty);
            var tagStoreDiff = new TagStoreDiff(ImmutableDictionary<Guid, string>.Empty, ImmutableHashSet<Guid>.Empty);

            var storeDiff = new StoreDiff(referenceStoreDiff, tagStoreDiff);

            Assert.AreSame(tagStoreDiff, storeDiff.TagStoreDiff);
        }

        [TestMethod]
        public void ThrowsExceptionWhenReferenceStoreNull()
        {
            var tagStoreDiff = new TagStoreDiff(ImmutableDictionary<Guid, string>.Empty, ImmutableHashSet<Guid>.Empty);

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreDiff(null, tagStoreDiff);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("referenceStoreDiff", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'referenceStoreDiff')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTagStoreNull()
        {
            var referenceStoreDiff = new ReferenceStoreDiff(ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty, ImmutableHashSet<EntityAttributeIdentifierPair>.Empty);

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new StoreDiff(referenceStoreDiff, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tagStoreDiff", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'tagStoreDiff')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }
    }
}
