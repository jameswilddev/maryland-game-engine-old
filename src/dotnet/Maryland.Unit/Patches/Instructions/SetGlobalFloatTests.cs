using Maryland.Databases;
using Maryland.Patches.Instructions;
using Moq;

namespace Maryland.Unit.Patches.Instructions
{
    [TestClass]
    public sealed class SetGlobalFloatTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var attribute = Guid.NewGuid();
            var bytes = new byte[4];
            Random.Shared.NextBytes(bytes);
            var value = BitConverter.ToSingle(bytes);

            var setGlobalFloat = new SetGlobalFloat(attribute, value);

            Assert.AreEqual(attribute, setGlobalFloat.Attribute);
            Assert.AreEqual(value, setGlobalFloat.Value);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var attribute = Guid.NewGuid();
            var bytes = new byte[4];
            Random.Shared.NextBytes(bytes);
            var value = BitConverter.ToSingle(bytes);
            var setEntityFloat = new SetGlobalFloat(attribute, value);
            var database = new Mock<IDatabase>();

            setEntityFloat.ApplyTo(database.Object);

            database.Verify(d => d.SetGlobalFloat(attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = 3.14159265359f;
            var setGlobalFloat = new SetGlobalFloat(attribute, value);

            var bytes = setGlobalFloat.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    2,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    0xdb, 0x0f, 0x49, 0x40,
                },
                bytes.ToArray()
            );
        }
    }
}
