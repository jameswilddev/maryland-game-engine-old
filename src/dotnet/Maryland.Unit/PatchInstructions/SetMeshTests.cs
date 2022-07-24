using Maryland.Databases;
using Maryland.DataTypes;
using Maryland.PatchInstructions;
using Maryland.Unit.DataTypes;
using Moq;

namespace Maryland.Unit.PatchInstructions
{
    [TestClass]
    public sealed class SetMeshTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Mesh();

            var setMesh = new SetMesh(entity, attribute, value);

            Assert.AreEqual(entity, setMesh.Entity);
            Assert.AreEqual(attribute, setMesh.Attribute);
            Assert.AreEqual(value, setMesh.Value);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Mesh();
            var setMesh = new SetMesh(entity, attribute, value);
            var database = new Mock<IDatabase>();

            setMesh.ApplyTo(database.Object);

            database.Verify(d => d.SetMesh(entity, attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = new Mesh
            (
                MeshTests.Transforms,
                MeshTests.FirstTransformIndices,
                MeshTests.FirstTransformPositions,
                null,
                null,
                null,
                MeshTests.SecondTransformIndices,
                MeshTests.SecondTransformPositions,
                null,
                null,
                null,
                MeshTests.TransformBlendFactors,
                MeshTests.TextureCoordinates,
                MeshTests.Colors,
                MeshTests.Indices
            );
            var setMesh = new SetMesh(entity, attribute, value);

            var bytes = setMesh.Serialized;

            CollectionAssert.AreEqual
            (
                MeshTests.Concatenated
                (
                    new byte[]
                    {
                        8,
                        0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                        0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                        0, 10, 0,
                    },
                    MeshTests.SerializedTransforms,
                    MeshTests.FirstTransformIndices,
                    MeshTests.SerializedFirstTransformPositions,
                    MeshTests.SecondTransformIndices,
                    MeshTests.SerializedSecondTransformPositions,
                    MeshTests.TransformBlendFactors,
                    MeshTests.SerializedTextureMaps,
                    MeshTests.SerializedColorLayers,
                    MeshTests.SerializedIndices
                ),
                bytes.ToArray()
            );
        }

        [TestMethod]
        public void Equal()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.Mesh();
            var a = new SetMesh(entity, attribute, value);
            var b = new SetMesh(entity, attribute, value);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalEntity()
        {
            var attribute = Guid.NewGuid();
            var value = Generate.Mesh();
            var a = new SetMesh(Guid.NewGuid(), attribute, value);
            var b = new SetMesh(Guid.NewGuid(), attribute, value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalAttribute()
        {
            var entity = Guid.NewGuid();
            var value = Generate.Mesh();
            var a = new SetMesh(entity, Guid.NewGuid(), value);
            var b = new SetMesh(entity, Guid.NewGuid(), value);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalValue()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var valueA = Generate.Mesh();
            var a = new SetMesh(entity, attribute, valueA);
            var b = new SetMesh(entity, attribute, Generate.Mesh());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalNull()
        {
            var a = new SetMesh(Guid.NewGuid(), Guid.NewGuid(), Generate.Mesh());

            Assert.AreNotEqual(a, null);
        }

        [TestMethod]
        public void InequalType()
        {
            var a = new SetMesh(Guid.NewGuid(), Guid.NewGuid(), Generate.Mesh());

            Assert.AreNotEqual(a, 1);
        }
    }
}
