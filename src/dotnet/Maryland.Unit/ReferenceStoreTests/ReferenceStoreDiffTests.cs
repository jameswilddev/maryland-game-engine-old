using Maryland.ReferenceStores;
using System.Collections.Immutable;

namespace Maryland.Unit.ReferenceStoreTests
{
    [TestClass]
    public sealed class ReferenceStoreDiffTests
    {
        [TestMethod]
        public void ExposesSet()
        {
            var entityAIdentifier = Guid.NewGuid();
            var entityBIdentifier = Guid.NewGuid();
            var entityCIdentifier = Guid.NewGuid();
            var attributeAIdentifier = Guid.NewGuid();
            var attributeBIdentifier = Guid.NewGuid();
            var attributeCIdentifier = Guid.NewGuid();
            var valueAIdentifier = Guid.NewGuid();
            var valueBIdentifier = Guid.NewGuid();
            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeAIdentifier), valueAIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityBIdentifier, attributeAIdentifier), valueBIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeBIdentifier), valueAIdentifier);
            var deleted = ImmutableHashSet< EntityAttributeIdentifierPair>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeCIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeAIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeCIdentifier));

            var tagStoreDiff = new ReferenceStoreDiff(set, deleted);

            Assert.AreEqual(set, tagStoreDiff.Set);
        }

        [TestMethod]
        public void ExposesDeleted()
        {
            var entityAIdentifier = Guid.NewGuid();
            var entityBIdentifier = Guid.NewGuid();
            var entityCIdentifier = Guid.NewGuid();
            var attributeAIdentifier = Guid.NewGuid();
            var attributeBIdentifier = Guid.NewGuid();
            var attributeCIdentifier = Guid.NewGuid();
            var valueAIdentifier = Guid.NewGuid();
            var valueBIdentifier = Guid.NewGuid();
            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeAIdentifier), valueAIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityBIdentifier, attributeAIdentifier), valueBIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeBIdentifier), valueAIdentifier);
            var deleted = ImmutableHashSet<EntityAttributeIdentifierPair>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeCIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeAIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeCIdentifier));

            var tagStoreDiff = new ReferenceStoreDiff(set, deleted);

            Assert.AreEqual(deleted, tagStoreDiff.Deleted);
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetNull()
        {
            var entityAIdentifier = Guid.NewGuid();
            var entityCIdentifier = Guid.NewGuid();
            var attributeAIdentifier = Guid.NewGuid();
            var attributeCIdentifier = Guid.NewGuid();
            var deleted = ImmutableHashSet<EntityAttributeIdentifierPair>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeCIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeAIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeCIdentifier));

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new ReferenceStoreDiff(null, deleted);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenDeletedNull()
        {
            var entityAIdentifier = Guid.NewGuid();
            var entityBIdentifier = Guid.NewGuid();
            var attributeAIdentifier = Guid.NewGuid();
            var attributeBIdentifier = Guid.NewGuid();
            var valueAIdentifier = Guid.NewGuid();
            var valueBIdentifier = Guid.NewGuid();
            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeAIdentifier), valueAIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityBIdentifier, attributeAIdentifier), valueBIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeBIdentifier), valueAIdentifier);

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new ReferenceStoreDiff(set, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("deleted", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'deleted')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetAndDeletedShareKeys()
        {
            var entityAIdentifier = Guid.NewGuid();
            var entityBIdentifier = Guid.NewGuid();
            var entityCIdentifier = Guid.NewGuid();
            var attributeAIdentifier = Guid.NewGuid();
            var attributeBIdentifier = Guid.NewGuid();
            var attributeCIdentifier = Guid.NewGuid();
            var valueAIdentifier = Guid.NewGuid();
            var valueBIdentifier = Guid.NewGuid();
            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeAIdentifier), valueAIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityBIdentifier, attributeAIdentifier), valueBIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeBIdentifier), valueAIdentifier);
            var deleted = ImmutableHashSet<EntityAttributeIdentifierPair>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeCIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeAIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeAIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeCIdentifier));

            try
            {
                _ = new ReferenceStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentException exception)
            {
                Assert.IsNull(exception.ParamName);
                Assert.AreEqual("Cannot set and delete a mapping from the same entity/attribute identifier pair in the same ReferenceStoreDiff.", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetContainsNullTags()
        {
            var entityAIdentifier = Guid.NewGuid();
            var entityBIdentifier = Guid.NewGuid();
            var entityCIdentifier = Guid.NewGuid();
            var attributeAIdentifier = Guid.NewGuid();
            var attributeBIdentifier = Guid.NewGuid();
            var attributeCIdentifier = Guid.NewGuid();
            var valueAIdentifier = Guid.NewGuid();
            var valueBIdentifier = Guid.NewGuid();
            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeAIdentifier), valueAIdentifier)
                .Add(new EntityAttributeIdentifierPair(entityBIdentifier, attributeAIdentifier), Guid.Empty)
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeBIdentifier), valueBIdentifier);
            var deleted = ImmutableHashSet<EntityAttributeIdentifierPair>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityAIdentifier, attributeCIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeAIdentifier))
                .Add(new EntityAttributeIdentifierPair(entityCIdentifier, attributeCIdentifier));

            try
            {
                _ = new ReferenceStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Value identifiers cannot be zero. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }
    }
}
