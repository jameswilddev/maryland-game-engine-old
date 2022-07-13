using Maryland.Stores.ReferenceStores;

namespace Maryland.Unit.StoreTests.ReferenceStoreTests
{
    [TestClass]
    public sealed class ReferenceMappingTests
    {
        [TestMethod]
        public void ExposesEntity()
        {
            var entity = Guid.NewGuid();

            var referenceMapping = new ReferenceMapping(entity, Guid.NewGuid(), Guid.NewGuid());

            Assert.AreEqual(entity, referenceMapping.Entity);
        }

        [TestMethod]
        public void ExposesAttribute()
        {
            var attribute = Guid.NewGuid();

            var referenceMapping = new ReferenceMapping(Guid.NewGuid(), attribute, Guid.NewGuid());

            Assert.AreEqual(attribute, referenceMapping.Attribute);
        }

        [TestMethod]
        public void ExposesValue()
        {
            var value = Guid.NewGuid();

            var referenceMapping = new ReferenceMapping(Guid.NewGuid(), Guid.NewGuid(), value);

            Assert.AreEqual(value, referenceMapping.Value);
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenValueIsZero()
        {
            try
            {
                _ = new ReferenceMapping(Guid.NewGuid(), Guid.NewGuid(), Guid.Empty);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'value')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void Equal()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Guid.NewGuid();

            var a = new ReferenceMapping(entity, attribute, value);
            var b = new ReferenceMapping(entity, attribute, value);

            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void EntityNotEqual()
        {
            var attribute = Guid.NewGuid();
            var value = Guid.NewGuid();

            var a = new ReferenceMapping(Guid.NewGuid(), attribute, value);
            var b = new ReferenceMapping(Guid.NewGuid(), attribute, value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void AttributeNotEqual()
        {
            var entity = Guid.NewGuid();
            var value = Guid.NewGuid();

            var a = new ReferenceMapping(entity, Guid.NewGuid(), value);
            var b = new ReferenceMapping(entity, Guid.NewGuid(), value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void ValueNotEqual()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            var a = new ReferenceMapping(entity, attribute, Guid.NewGuid());
            var b = new ReferenceMapping(entity, attribute, Guid.NewGuid());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void GetHashCodeReturnsSameValueForSameIdentifierAndTag()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Guid.NewGuid();

            var a = new ReferenceMapping(entity, attribute, value);
            var b = new ReferenceMapping(entity, attribute, value);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void ThrowIfUninitializedThrowsWhenUninitialized()
        {
            try
            {
                default(ReferenceMapping).ThrowIfUninitialized();
                Assert.Fail();
            }
            catch (InvalidOperationException exception)
            {
                Assert.AreEqual("ReferenceMapping uninitialized.", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowIfUninitializedDoesNothingWhenInitialized()
        {
            var referenceMapping = new ReferenceMapping(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            referenceMapping.ThrowIfUninitialized();
        }
    }
}
