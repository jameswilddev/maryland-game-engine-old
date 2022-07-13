using Maryland.Stores.ReferenceStores;

namespace Maryland.Unit.StoreTests.ReferenceStoreTests
{
    [TestClass]
    public sealed class EntityAttributeIdentifierPairTests
    {
        [TestMethod]
        public void ExposesEntity()
        {
            var entity = Guid.NewGuid();

            var entityAttributeIdentifierPair = new EntityAttributeIdentifierPair(entity, Guid.NewGuid());

            Assert.AreEqual(entity, entityAttributeIdentifierPair.Entity);
        }

        [TestMethod]
        public void ExposesAttribute()
        {
            var attribute = Guid.NewGuid();

            var entityAttributeIdentifierPair = new EntityAttributeIdentifierPair(Guid.NewGuid(), attribute);

            Assert.AreEqual(attribute, entityAttributeIdentifierPair.Attribute);
        }

        [TestMethod]
        public void Equal()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            var a = new EntityAttributeIdentifierPair(entity, attribute);
            var b = new EntityAttributeIdentifierPair(entity, attribute);

            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void EntityNotEqual()
        {
            var attribute = Guid.NewGuid();

            var a = new EntityAttributeIdentifierPair(Guid.NewGuid(), attribute);
            var b = new EntityAttributeIdentifierPair(Guid.NewGuid(), attribute);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void AttributeNotEqual()
        {
            var entity = Guid.NewGuid();

            var a = new EntityAttributeIdentifierPair(entity, Guid.NewGuid());
            var b = new EntityAttributeIdentifierPair(entity, Guid.NewGuid());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void GetHashCodeReturnsSameValueForSameIdentifierAndTag()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            var a = new EntityAttributeIdentifierPair(entity, attribute);
            var b = new EntityAttributeIdentifierPair(entity, attribute);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
    }
}
