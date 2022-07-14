using Maryland.Databases;
using Maryland.Patches.Instructions;
using Moq;

namespace Maryland.Unit.Patches.Instructions
{
    [TestClass]
    public sealed class SetGlobalReferenceTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var attribute = Guid.NewGuid();
            var value = Guid.NewGuid();

            var setGlobalReference = new SetGlobalReference(attribute, value);

            Assert.AreEqual(attribute, setGlobalReference.Attribute);
            Assert.AreEqual(value, setGlobalReference.Value);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var attribute = Guid.NewGuid();
            var value = Guid.NewGuid();
            var setGlobalReference = new SetGlobalReference(attribute, value);
            var database = new Mock<IDatabase>();

            setGlobalReference.ApplyTo(database.Object);

            database.Verify(d => d.SetGlobalReference(attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {

            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = new Guid("73415b37-fd9d-42da-92a6-2ab4027a0ae5");
            var setGlobalReference = new SetGlobalReference(attribute, value);

            var bytes = setGlobalReference.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    0,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    0x73, 0x41, 0x5b, 0x37, 0xfd, 0x9d, 0x42, 0xda, 0x92, 0xa6, 0x2a, 0xb4, 0x02, 0x7a, 0x0a, 0xe5,
                },
                bytes.ToArray()
            );
        }
    }
}
