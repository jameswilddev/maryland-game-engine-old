using Maryland.Databases;
using Maryland.PatchInstructions;
using Moq;
using System.Collections.Immutable;

namespace Maryland.Unit.PatchInstructions
{
    [TestClass]
    public sealed class ClearFlagTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            var clearFlag = new ClearFlag(entity, attribute);

            Assert.AreEqual(entity, clearFlag.Entity);
            Assert.AreEqual(attribute, clearFlag.Attribute);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var clearFlag = new ClearFlag(entity, attribute);
            var database = new Mock<IDatabase>();

            clearFlag.ApplyTo(database.Object);

            database.Verify(d => d.ClearFlag(entity, attribute), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var clearFlag = new ClearFlag(entity, attribute);

            var bytes = clearFlag.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    4,
                    0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                },
                bytes.ToArray()
            );
        }

        [TestMethod]
        public void Equal()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var a = new ClearFlag(entity, attribute);
            var b = new ClearFlag(entity, attribute);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalEntity()
        {
            var attribute = Guid.NewGuid();
            var a = new ClearFlag(Guid.NewGuid(), attribute);
            var b = new ClearFlag(Guid.NewGuid(), attribute);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalAttribute()
        {
            var entity = Guid.NewGuid();
            var a = new ClearFlag(entity, Guid.NewGuid());
            var b = new ClearFlag(entity, Guid.NewGuid());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalNull()
        {
            var a = new ClearFlag(Guid.NewGuid(), Guid.NewGuid());

            Assert.AreNotEqual(a, null);
        }

        [TestMethod]
        public void InequalType()
        {
            var a = new ClearFlag(Guid.NewGuid(), Guid.NewGuid());

            Assert.AreNotEqual(a, 1);
        }
    }
}
