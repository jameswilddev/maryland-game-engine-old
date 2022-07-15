using Maryland.Databases;
using Maryland.PatchInstructions;
using Moq;

namespace Maryland.Unit.PatchInstructions
{
    [TestClass]
    public sealed class SetStringTests
    {
        [TestMethod]
        public void ExposesGivenEmpty()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            var setString = new SetString(entity, attribute, string.Empty);

            Assert.AreEqual(entity, setString.Entity);
            Assert.AreEqual(attribute, setString.Attribute);
            Assert.AreEqual(string.Empty, setString.Value);
        }

        [TestMethod]
        public void ExposesGivenDataUnderLengthLimit()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String65534BytesInUTF8();

            var setString = new SetString(entity, attribute, value);

            Assert.AreEqual(entity, setString.Entity);
            Assert.AreEqual(attribute, setString.Attribute);
            Assert.AreEqual(value, setString.Value);
        }

        [TestMethod]
        public void ExposesGivenDataAtLengthLimit()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String65535BytesInUTF8();

            var setString = new SetString(entity, attribute, value);

            Assert.AreEqual(entity, setString.Entity);
            Assert.AreEqual(attribute, setString.Attribute);
            Assert.AreEqual(value, setString.Value);
        }

        [TestMethod]
        public void ThrowsExceptionWhenLengthLimitExceededByOneByte()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String65536BytesInUTF8();

            try
            {
                _ = new SetString(entity, attribute, value);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot exceed 65535 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenLengthLimitExceededByTwoBytes()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String65537BytesInUTF8();

            try
            {
                _ = new SetString(entity, attribute, value);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot exceed 65535 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenValueNull()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new SetString(entity, attribute, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = "Test Value";
            var setEntityReference = new SetString(entity, attribute, value);
            var database = new Mock<IDatabase>();

            setEntityReference.ApplyTo(database.Object);

            database.Verify(d => d.SetString(entity, attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = "Test §あ𩸽 Value";
            var setString = new SetString(entity, attribute, value);

            var bytes = setString.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    1,
                    0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    20, 0,
                    0x54, 0x65, 0x73, 0x74, 0x20, 0xc2, 0xa7, 0xe3, 0x81, 0x82, 0xf0, 0xa9, 0xb8, 0xbd, 0x20, 0x56, 0x61, 0x6c, 0x75, 0x65,
                },
                bytes.ToArray()
            );
        }

        [TestMethod]
        public void Equal()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String();
            var a = new SetString(entity, attribute, value);
            var b = new SetString(entity, attribute, value);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalEntity()
        {
            var attribute = Guid.NewGuid();
            var value = Generate.String();
            var a = new SetString(Guid.NewGuid(), attribute, value);
            var b = new SetString(Guid.NewGuid(), attribute, value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalAttribute()
        {
            var entity = Guid.NewGuid();
            var value = Generate.String();
            var a = new SetString(entity, Guid.NewGuid(), value);
            var b = new SetString(entity, Guid.NewGuid(), value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalValue()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var a = new SetString(entity, attribute, Generate.String());
            var b = new SetString(entity, attribute, Generate.String());

            Assert.AreNotEqual(a, b);
        }
    }
}
