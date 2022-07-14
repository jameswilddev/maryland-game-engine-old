using Maryland.Databases;
using Maryland.Patches.Instructions;
using Moq;

namespace Maryland.Unit.Patches.Instructions
{
    [TestClass]
    public sealed class SetGlobalFlagTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var attribute = Guid.NewGuid();

            var setGlobalFlag = new SetGlobalFlag(attribute);

            Assert.AreEqual(attribute, setGlobalFlag.Attribute);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var attribute = Guid.NewGuid();
            var setEntityReference = new SetGlobalFlag(attribute);
            var database = new Mock<IDatabase>();

            setEntityReference.ApplyTo(database.Object);

            database.Verify(d => d.SetGlobalFlag(attribute), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var setGlobalFlag = new SetGlobalFlag(attribute);

            var bytes = setGlobalFlag.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    3,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                },
                bytes.ToArray()
            );
        }
    }
}
