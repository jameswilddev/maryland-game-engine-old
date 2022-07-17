using Maryland.Databases;
using Maryland.DataTypes;
using Maryland.PatchInstructions;
using Moq;
using System.Collections.Immutable;

namespace Maryland.Unit.PatchInstructions
{
    [TestClass]
    public sealed class SetImageTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Image();

            var setImage = new SetImage(entity, attribute, value);

            Assert.AreEqual(entity, setImage.Entity);
            Assert.AreEqual(attribute, setImage.Attribute);
            Assert.AreEqual(value, setImage.Value);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Image();
            var setImage = new SetImage(entity, attribute, value);
            var database = new Mock<IDatabase>();

            setImage.ApplyTo(database.Object);

            database.Verify(d => d.SetImage(entity, attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = new Image
            (
                3, 
                ImmutableArray.Create
                (
                    new ColorWithOpacity(0xf8, 0xd5, 0x5f, 0x80),
                    new ColorWithOpacity(0x67, 0xe4, 0x6d, 0xcf),
                    new ColorWithOpacity(0x3f, 0xa0, 0x85, 0x9c),
                    new ColorWithOpacity(0x56, 0xe5, 0x5a, 0x79),
                    new ColorWithOpacity(0xf0, 0x51, 0x4d, 0x0d),
                    new ColorWithOpacity(0x60, 0x0a, 0x51, 0xa1)
                )
            );
            var setImage = new SetImage(entity, attribute, value);

            var bytes = setImage.Serialized;

            CollectionAssert.AreEqual
            (
                new byte[]
                {
                    7,
                    0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    3, 2,
                    0xf8, 0xd5, 0x5f, 0x80,
                    0x67, 0xe4, 0x6d, 0xcf,
                    0x3f, 0xa0, 0x85, 0x9c,
                    0x56, 0xe5, 0x5a, 0x79,
                    0xf0, 0x51, 0x4d, 0x0d,
                    0x60, 0x0a, 0x51, 0xa1,
                },
                bytes.ToArray()
            );
        }

        [TestMethod]
        public void Equal()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Image();
            var a = new SetImage(entity, attribute, value);
            var b = new SetImage(entity, attribute, value);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalEntity()
        {
            var attribute = Guid.NewGuid();
            var value = Generate.Image();
            var a = new SetImage(Guid.NewGuid(), attribute, value);
            var b = new SetImage(Guid.NewGuid(), attribute, value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalAttribute()
        {
            var entity = Guid.NewGuid();
            var value = Generate.Image();
            var a = new SetImage(entity, Guid.NewGuid(), value);
            var b = new SetImage(entity, Guid.NewGuid(), value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalValue()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var valueA = Generate.Image();
            var a = new SetImage(entity, attribute, valueA);
            var b = new SetImage(entity, attribute, Generate.DifferentImage(valueA));

            Assert.AreNotEqual(a, b);
        }
    }
}
