﻿using Maryland.Databases;
using Maryland.Patches.Instructions;
using Moq;

namespace Maryland.Unit.Patches.Instructions
{
    [TestClass]
    public sealed class SetEntityReferenceTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Guid.NewGuid();

            var setEntityReference = new SetEntityReference(entity, attribute, value);

            Assert.AreEqual(entity, setEntityReference.Entity);
            Assert.AreEqual(attribute, setEntityReference.Attribute);
            Assert.AreEqual(value, setEntityReference.Value);
        }

        [TestMethod]
        public void AppliesToDatabases()
        {
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Guid.NewGuid();
            var setEntityReference = new SetEntityReference(entity, attribute, value);
            var database = new Mock<IDatabase>();

            setEntityReference.ApplyTo(database.Object);

            database.Verify(d => d.SetEntityReference(entity, attribute, value), Times.Once);
            database.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void Serializes()
        {
            var entity = new Guid("eb28a90f-86c4-4f56-b8f9-135156e9d8f9");
            var attribute = new Guid("9ca7bb9e-506b-4cfe-bb0b-0e8fbb8a2da6");
            var value = new Guid("73415b37-fd9d-42da-92a6-2ab4027a0ae5");
            var setEntityReference = new SetEntityReference(entity, attribute, value);

            var bytes = setEntityReference.Serialized;

            CollectionAssert.AreEqual(
                new byte[]
                {
                    5,
                    0xeb, 0x28, 0xa9, 0x0f, 0x86, 0xc4, 0x4f, 0x56, 0xb8, 0xf9, 0x13, 0x51, 0x56, 0xe9, 0xd8, 0xf9,
                    0x9c, 0xa7, 0xbb, 0x9e, 0x50, 0x6b, 0x4c, 0xfe, 0xbb, 0x0b, 0x0e, 0x8f, 0xbb, 0x8a, 0x2d, 0xa6,
                    0x73, 0x41, 0x5b, 0x37, 0xfd, 0x9d, 0x42, 0xda, 0x92, 0xa6, 0x2a, 0xb4, 0x02, 0x7a, 0x0a, 0xe5,
                },
                bytes.ToArray()
            );
        }
    }
}
