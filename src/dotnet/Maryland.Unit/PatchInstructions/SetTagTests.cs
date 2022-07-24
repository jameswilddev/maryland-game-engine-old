using Maryland.Databases;
using Maryland.PatchInstructions;
using Moq;

namespace Maryland.Unit.PatchInstructions
{
    [TestClass]
    public sealed class SetTagTests
    {
        [TestMethod]
        public void ExposesGivenOneCharacter()
        {
            var identifier = Guid.NewGuid();
            var value = "a";

            var setTag = new SetTag(identifier, value);

            Assert.AreEqual(identifier, setTag.Identifier);
            Assert.AreEqual(value, setTag.Value);
        }

        [TestMethod]
        public void ExposesGivenDataUnderLengthLimit()
        {
            var identifier = Guid.NewGuid();
            var value = Generate.String254BytesInUTF8();

            var setTag = new SetTag(identifier, value);

            Assert.AreEqual(identifier, setTag.Identifier);
            Assert.AreEqual(value, setTag.Value);
        }

        [TestMethod]
        public void ExposesGivenDataAtLengthLimit()
        {
            var identifier = Guid.NewGuid();
            var value = Generate.String255BytesInUTF8();

            var setTag = new SetTag(identifier, value);

            Assert.AreEqual(identifier, setTag.Identifier);
            Assert.AreEqual(value, setTag.Value);
        }

        [TestMethod]
        public void ThrowsExceptionWhenLengthLimitExceededByOneByte()
        {
            var identifier = Guid.NewGuid();
            var value = Generate.String256BytesInUTF8();

            try
            {
                _ = new SetTag(identifier, value);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenLengthLimitExceededByTwoBytes()
        {
            var identifier = Guid.NewGuid();
            var value = Generate.String257BytesInUTF8();

            try
            {
                _ = new SetTag(identifier, value);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenValueNull()
        {
            var identifier = Guid.NewGuid();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new SetTag(identifier, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null or empty. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenValueEmpty()
        {
            var identifier = Guid.NewGuid();

            try
            {
                _ = new SetTag(identifier, string.Empty);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null or empty. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var identifier = Guid.NewGuid();
            var value = "Test Value";
            var setEntityReference = new SetTag(identifier, value);
            var database = new Mock<IDatabase>();

            setEntityReference.ApplyTo(database.Object);

            database.Verify(d => d.SetTag(identifier, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var identifier = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = "Test §あ𩸽 Value";
            var setTag = new SetTag(identifier, value);

            var bytes = setTag.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    5,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    20,
                    0x54, 0x65, 0x73, 0x74, 0x20, 0xc2, 0xa7, 0xe3, 0x81, 0x82, 0xf0, 0xa9, 0xb8, 0xbd, 0x20, 0x56, 0x61, 0x6c, 0x75, 0x65,
                },
                bytes.ToArray()
            );
        }

        [TestMethod]
        public void Equal()
        {
            var identifier = Guid.NewGuid();
            var value = Generate.String();
            var a = new SetTag(identifier, value);
            var b = new SetTag(identifier, value);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalIdentifier()
        {
            var value = Generate.String();
            var a = new SetTag(Guid.NewGuid(), value);
            var b = new SetTag(Guid.NewGuid(), value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalValue()
        {
            var identifier = Guid.NewGuid();
            var a = new SetTag(identifier, Generate.String());
            var b = new SetTag(identifier, Generate.String());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalNull()
        {
            var a = new SetTag(Guid.NewGuid(), Generate.String());

            Assert.AreNotEqual(a, null);
        }

        [TestMethod]
        public void InequalType()
        {
            var a = new SetTag(Guid.NewGuid(), Generate.String());

            Assert.AreNotEqual(a, 1);
        }
    }
}
