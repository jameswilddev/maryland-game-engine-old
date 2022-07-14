using Maryland.Databases;
using Maryland.Patches.Instructions;
using Moq;

namespace Maryland.Unit.Patches.Instructions
{
    [TestClass]
    public sealed class SetEntityStringTests
    {
        [TestMethod]
        public void ExposesGivenEmpty()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            var setEntityString = new SetEntityString(entity, attribute, string.Empty);

            Assert.AreEqual(entity, setEntityString.Entity);
            Assert.AreEqual(attribute, setEntityString.Attribute);
            Assert.AreEqual(string.Empty, setEntityString.Value);
        }

        [TestMethod]
        public void ExposesGivenDataUnderLengthLimit()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = string.Empty;
            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }
            value += "あ§a";

            var setEntityString = new SetEntityString(entity, attribute, value);

            Assert.AreEqual(entity, setEntityString.Entity);
            Assert.AreEqual(attribute, setEntityString.Attribute);
            Assert.AreEqual(value, setEntityString.Value);
        }

        [TestMethod]
        public void ExposesGivenDataAtLengthLimit()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = string.Empty;
            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }
            value += "あ§aa";

            var setEntityString = new SetEntityString(entity, attribute, value);

            Assert.AreEqual(entity, setEntityString.Entity);
            Assert.AreEqual(attribute, setEntityString.Attribute);
            Assert.AreEqual(value, setEntityString.Value);
        }

        [TestMethod]
        public void ThrowsExceptionWhenLengthLimitExceededByOneBytes()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = string.Empty;
            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }
            value += "あ§aaa";

            try
            {
                _ = new SetEntityString(entity, attribute, value);
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
            var value = string.Empty;
            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }
            value += "あ§aaaa";

            try
            {
                _ = new SetEntityString(entity, attribute, value);
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
                _ = new SetEntityString(entity, attribute, null);
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
            var setEntityReference = new SetEntityString(entity, attribute, value);
            var database = new Mock<IDatabase>();

            setEntityReference.ApplyTo(database.Object);

            database.Verify(d => d.SetEntityString(entity, attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = "Test §あ𩸽 Value";
            var setEntityString = new SetEntityString(entity, attribute, value);

            var bytes = setEntityString.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    6,
                    0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    20, 0,
                    0x54, 0x65, 0x73, 0x74, 0x20, 0xc2, 0xa7, 0xe3, 0x81, 0x82, 0xf0, 0xa9, 0xb8, 0xbd, 0x20, 0x56, 0x61, 0x6c, 0x75, 0x65,
                },
                bytes.ToArray()
            );
        }
    }
}
