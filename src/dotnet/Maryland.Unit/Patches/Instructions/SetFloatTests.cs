using Maryland.Databases;
using Maryland.Patches.Instructions;
using Moq;

namespace Maryland.Unit.Patches.Instructions
{
    [TestClass]
    public sealed class SetFloatTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var bytes = new byte[4];
            Random.Shared.NextBytes(bytes);
            var value = BitConverter.ToSingle(bytes);

            var setFloat = new SetFloat(entity, attribute, value);

            Assert.AreEqual(entity, setFloat.Entity);
            Assert.AreEqual(attribute, setFloat.Attribute);
            Assert.AreEqual(value, setFloat.Value);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var bytes = new byte[4];
            Random.Shared.NextBytes(bytes);
            var value = BitConverter.ToSingle(bytes);
            var setFloat = new SetFloat(entity, attribute, value);
            var database = new Mock<IDatabase>();

            setFloat.ApplyTo(database.Object);

            database.Verify(d => d.SetFloat(entity, attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = 3.14159265359f;
            var setFloat = new SetFloat(entity, attribute, value);

            var bytes = setFloat.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    2,
                    0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    0xdb, 0x0f, 0x49, 0x40,
                },
                bytes.ToArray()
            );
        }
    }
}
