using Maryland.Databases;
using Maryland.DataTypes;
using Maryland.PatchInstructions;
using Moq;

namespace Maryland.Unit.PatchInstructions
{
    [TestClass]
    public sealed class SetColorTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Color();

            var setColor = new SetColor(entity, attribute, value);

            Assert.AreEqual(entity, setColor.Entity);
            Assert.AreEqual(attribute, setColor.Attribute);
            Assert.AreEqual(value, setColor.Value);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Color();
            var setColor = new SetColor(entity, attribute, value);
            var database = new Mock<IDatabase>();

            setColor.ApplyTo(database.Object);

            database.Verify(d => d.SetColor(entity, attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = new Color(0x7e, 0x75, 0xb5);
            var setColor = new SetColor(entity, attribute, value);

            var bytes = setColor.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    6,
                    0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    0x7e, 0x75, 0xb5,
                },
                bytes.ToArray()
            );
        }

        [TestMethod]
        public void Equal()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Color();
            var a = new SetColor(entity, attribute, value);
            var b = new SetColor(entity, attribute, value);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalEntity()
        {
            var attribute = Guid.NewGuid();
            var value = Generate.Color();
            var a = new SetColor(Guid.NewGuid(), attribute, value);
            var b = new SetColor(Guid.NewGuid(), attribute, value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalAttribute()
        {
            var entity = Guid.NewGuid();
            var value = Generate.Color();
            var a = new SetColor(entity, Guid.NewGuid(), value);
            var b = new SetColor(entity, Guid.NewGuid(), value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalValue()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var a = new SetColor(entity, attribute, Generate.Color());
            var b = new SetColor(entity, attribute, Generate.Color());

            Assert.AreNotEqual(a, b);
        }
    }
}
