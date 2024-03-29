﻿using Maryland.Databases;
using Maryland.DataTypes;
using Maryland.PatchInstructions;
using Moq;
using System.Collections.Immutable;

namespace Maryland.Unit.Databases
{
    [TestClass]
    public sealed class DatabaseTests
    {
        private static void AssertEmptyMesh(Mesh mesh)
        {
            CollectionAssert.AreEqual(new[] { Guid.Empty }, mesh.Transforms);
            Assert.AreEqual(1, mesh.FirstTransformPositions.Length);
            Assert.AreEqual(3, mesh.Indices.Length);
            Assert.IsNull(mesh.FirstTransformNormals);
            Assert.IsNull(mesh.FirstTransformTangents);
            Assert.IsNull(mesh.FirstTransformBitangents);
        }

        [TestMethod]
        public void AllowsRetrievalOfStoredInformation()
        {
            var setFlagEntity = Guid.NewGuid();
            var doubleSetFlagEntity = Guid.NewGuid();
            var clearFlagEntity = Guid.NewGuid();
            var doubleClearFlagEntity = Guid.NewGuid();
            var setThenClearFlagEntity = Guid.NewGuid();
            var clearThenSetFlagEntity = Guid.NewGuid();
            var sharedAttribute = Guid.NewGuid();
            var sharedEntity = Guid.NewGuid();
            var setFlagAttribute = Guid.NewGuid();
            var doubleSetFlagAttribute = Guid.NewGuid();
            var clearFlagAttribute = Guid.NewGuid();
            var doubleClearFlagAttribute = Guid.NewGuid();
            var setThenClearFlagAttribute = Guid.NewGuid();
            var clearThenSetFlagAttribute = Guid.NewGuid();
            var setFloatEntity = Guid.NewGuid();
            var setFloatEntityValue = Generate.Float();
            var doubleSetFloatEntity = Guid.NewGuid();
            var doubleSetFloatEntityValue = Generate.Float();
            var setFloatAttribute = Guid.NewGuid();
            var setFloatAttributeValue = Generate.Float();
            var doubleSetFloatAttribute = Guid.NewGuid();
            var doubleSetFloatAttributeValue = Generate.Float();
            var setStringEntity = Guid.NewGuid();
            var setStringEntityValue = Generate.String();
            var doubleSetStringEntity = Guid.NewGuid();
            var doubleSetStringEntityValue = Generate.String();
            var setStringAttribute = Guid.NewGuid();
            var setStringAttributeValue = Generate.String();
            var doubleSetStringAttribute = Guid.NewGuid();
            var doubleSetStringAttributeValue = Generate.String();
            var setTagIdentifier = new Guid("e7d67415-af6c-4c89-94b0-641a39d22d18");
            var setTagValue = Generate.String();
            var doubleSetTagIdentifier = new Guid("f696fa41-22cc-45ef-a9c0-db488c6fbbd4");
            var doubleSetTagValue = Generate.String();
            var setReferenceEntity = Guid.NewGuid();
            var setReferenceEntityValue = Guid.NewGuid();
            var doubleSetReferenceEntity = Guid.NewGuid();
            var doubleSetReferenceEntityValue = Guid.NewGuid();
            var setReferenceAttribute = Guid.NewGuid();
            var setReferenceAttributeValue = Guid.NewGuid();
            var doubleSetReferenceAttribute = Guid.NewGuid();
            var doubleSetReferenceAttributeValue = Guid.NewGuid();
            var duplicateSetReferenceAttribute = Guid.NewGuid();
            var duplicateSetReferenceValue = Guid.NewGuid();
            var setThreeReferrerA = Guid.NewGuid();
            var setThreeReferrerB = Guid.NewGuid();
            var setThreeReferrerC = Guid.NewGuid();
            var setThreeEntity = Guid.NewGuid();
            var setThreeChangeOneReferrerA = Guid.NewGuid();
            var setThreeChangeOneReferrerB = Guid.NewGuid();
            var setThreeChangeOneReferrerC = Guid.NewGuid();
            var setThreeChangeOneEntity = Guid.NewGuid();
            var setThreeChangeTwoReferrerA = Guid.NewGuid();
            var setThreeChangeTwoReferrerB = Guid.NewGuid();
            var setThreeChangeTwoReferrerC = Guid.NewGuid();
            var setThreeChangeTwoEntity = Guid.NewGuid();
            var setThreeChangeThreeReferrerA = Guid.NewGuid();
            var setThreeChangeThreeReferrerB = Guid.NewGuid();
            var setThreeChangeThreeReferrerC = Guid.NewGuid();
            var setThreeChangeThreeEntity = Guid.NewGuid();
            var setColorEntity = Guid.NewGuid();
            var setColorEntityValue = Generate.Color();
            var doubleSetColorEntity = Guid.NewGuid();
            var doubleSetColorEntityValue = Generate.Color();
            var setColorAttribute = Guid.NewGuid();
            var setColorAttributeValue = Generate.Color();
            var doubleSetColorAttribute = Guid.NewGuid();
            var doubleSetColorAttributeValue = Generate.Color();
            var setImageEntity = Guid.NewGuid();
            var setImageEntityValue = Generate.Image();
            var doubleSetImageEntity = Guid.NewGuid();
            var doubleSetImageEntityValue = Generate.Image();
            var setImageAttribute = Guid.NewGuid();
            var setImageAttributeValue = Generate.Image();
            var doubleSetImageAttribute = Guid.NewGuid();
            var doubleSetImageAttributeValue = Generate.Image();
            var setMeshEntity = Guid.NewGuid();
            var setMeshEntityValue = Generate.Mesh();
            var doubleSetMeshEntity = Guid.NewGuid();
            var doubleSetMeshEntityValue = Generate.Mesh();
            var setMeshAttribute = Guid.NewGuid();
            var setMeshAttributeValue = Generate.Mesh();
            var doubleSetMeshAttribute = Guid.NewGuid();
            var doubleSetMeshAttributeValue = Generate.Mesh();
            var database = new Database();

            database.SetFlag(setFlagEntity, sharedAttribute);
            database.SetFlag(doubleSetFlagEntity, sharedAttribute);
            database.SetFlag(doubleSetFlagEntity, sharedAttribute);
            database.ClearFlag(clearFlagEntity, sharedAttribute);
            database.ClearFlag(doubleClearFlagEntity, sharedAttribute);
            database.ClearFlag(doubleClearFlagEntity, sharedAttribute);
            database.SetFlag(setThenClearFlagEntity, sharedAttribute);
            database.ClearFlag(setThenClearFlagEntity, sharedAttribute);
            database.ClearFlag(clearThenSetFlagEntity, sharedAttribute);
            database.SetFlag(clearThenSetFlagEntity, sharedAttribute);
            database.SetFlag(sharedEntity, setFlagAttribute);
            database.SetFlag(sharedEntity, doubleSetFlagAttribute);
            database.SetFlag(sharedEntity, doubleSetFlagAttribute);
            database.ClearFlag(sharedEntity, clearFlagAttribute);
            database.ClearFlag(sharedEntity, doubleClearFlagAttribute);
            database.ClearFlag(sharedEntity, doubleClearFlagAttribute);
            database.SetFlag(sharedEntity, setThenClearFlagAttribute);
            database.ClearFlag(sharedEntity, setThenClearFlagAttribute);
            database.ClearFlag(sharedEntity, clearThenSetFlagAttribute);
            database.SetFlag(sharedEntity, clearThenSetFlagAttribute);
            database.SetFloat(setFloatEntity, sharedAttribute, setFloatEntityValue);
            database.SetFloat(doubleSetFloatEntity, sharedAttribute, Generate.Float());
            database.SetFloat(doubleSetFloatEntity, sharedAttribute, doubleSetFloatEntityValue);
            database.SetFloat(sharedEntity, setFloatAttribute, setFloatAttributeValue);
            database.SetFloat(sharedEntity, doubleSetFloatAttribute, doubleSetFloatAttributeValue);
            database.SetString(setStringEntity, sharedAttribute, setStringEntityValue);
            database.SetString(doubleSetStringEntity, sharedAttribute, Generate.String());
            database.SetString(doubleSetStringEntity, sharedAttribute, doubleSetStringEntityValue);
            database.SetString(sharedEntity, setStringAttribute, setStringAttributeValue);
            database.SetString(sharedEntity, doubleSetStringAttribute, Generate.String());
            database.SetString(sharedEntity, doubleSetStringAttribute, doubleSetStringAttributeValue);
            database.SetTag(setTagIdentifier, setTagValue);
            database.SetTag(doubleSetTagIdentifier, Generate.String());
            database.SetTag(doubleSetTagIdentifier, doubleSetTagValue);
            database.SetReference(setReferenceEntity, sharedAttribute, setReferenceEntityValue);
            database.SetReference(doubleSetReferenceEntity, sharedAttribute, Guid.NewGuid());
            database.SetReference(doubleSetReferenceEntity, sharedAttribute, doubleSetReferenceEntityValue);
            database.SetReference(sharedEntity, setReferenceAttribute, setReferenceAttributeValue);
            database.SetReference(sharedEntity, doubleSetReferenceAttribute, Guid.NewGuid());
            database.SetReference(sharedEntity, doubleSetReferenceAttribute, doubleSetReferenceAttributeValue);
            database.SetReference(sharedEntity, duplicateSetReferenceAttribute, duplicateSetReferenceValue);
            database.SetReference(sharedEntity, duplicateSetReferenceAttribute, duplicateSetReferenceValue);
            database.SetReference(setThreeReferrerA, sharedAttribute, setThreeEntity);
            database.SetReference(setThreeReferrerB, sharedAttribute, setThreeEntity);
            database.SetReference(setThreeReferrerC, sharedAttribute, setThreeEntity);
            database.SetReference(setThreeChangeOneReferrerA, sharedAttribute, setThreeChangeOneEntity);
            database.SetReference(setThreeChangeOneReferrerB, sharedAttribute, setThreeChangeOneEntity);
            database.SetReference(setThreeChangeOneReferrerC, sharedAttribute, setThreeChangeOneEntity);
            database.SetReference(setThreeChangeOneReferrerB, sharedAttribute, sharedEntity);
            database.SetReference(setThreeChangeTwoReferrerA, sharedAttribute, setThreeChangeTwoEntity);
            database.SetReference(setThreeChangeTwoReferrerB, sharedAttribute, setThreeChangeTwoEntity);
            database.SetReference(setThreeChangeTwoReferrerC, sharedAttribute, setThreeChangeTwoEntity);
            database.SetReference(setThreeChangeTwoReferrerB, sharedAttribute, sharedEntity);
            database.SetReference(setThreeChangeTwoReferrerA, sharedAttribute, sharedEntity);
            database.SetReference(setThreeChangeThreeReferrerA, sharedAttribute, setThreeChangeThreeEntity);
            database.SetReference(setThreeChangeThreeReferrerB, sharedAttribute, setThreeChangeThreeEntity);
            database.SetReference(setThreeChangeThreeReferrerC, sharedAttribute, setThreeChangeThreeEntity);
            database.SetReference(setThreeChangeThreeReferrerB, sharedAttribute, sharedEntity);
            database.SetReference(setThreeChangeThreeReferrerA, sharedAttribute, sharedEntity);
            database.SetReference(setThreeChangeThreeReferrerC, sharedAttribute, sharedEntity);
            database.SetColor(setColorEntity, sharedAttribute, setColorEntityValue);
            database.SetColor(doubleSetColorEntity, sharedAttribute, Generate.Color());
            database.SetColor(doubleSetColorEntity, sharedAttribute, doubleSetColorEntityValue);
            database.SetColor(sharedEntity, setColorAttribute, setColorAttributeValue);
            database.SetColor(sharedEntity, doubleSetColorAttribute, doubleSetColorAttributeValue);
            database.SetImage(setImageEntity, sharedAttribute, setImageEntityValue);
            database.SetImage(doubleSetImageEntity, sharedAttribute, Generate.Image());
            database.SetImage(doubleSetImageEntity, sharedAttribute, doubleSetImageEntityValue);
            database.SetImage(sharedEntity, setImageAttribute, setImageAttributeValue);
            database.SetImage(sharedEntity, doubleSetImageAttribute, doubleSetImageAttributeValue);
            database.SetMesh(setMeshEntity, sharedAttribute, setMeshEntityValue);
            database.SetMesh(doubleSetMeshEntity, sharedAttribute, Generate.Mesh());
            database.SetMesh(doubleSetMeshEntity, sharedAttribute, doubleSetMeshEntityValue);
            database.SetMesh(sharedEntity, setMeshAttribute, setMeshAttributeValue);
            database.SetMesh(sharedEntity, doubleSetMeshAttribute, doubleSetMeshAttributeValue);

            Assert.IsTrue(database.GetFlag(setFlagEntity, sharedAttribute));
            Assert.IsTrue(database.GetFlag(doubleSetFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(clearFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(doubleClearFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(setThenClearFlagEntity, sharedAttribute));
            Assert.IsTrue(database.GetFlag(clearThenSetFlagEntity, sharedAttribute));
            Assert.IsTrue(database.GetFlag(sharedEntity, setFlagAttribute));
            Assert.IsTrue(database.GetFlag(sharedEntity, doubleSetFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, clearFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, doubleClearFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, setThenClearFlagAttribute));
            Assert.IsTrue(database.GetFlag(sharedEntity, clearThenSetFlagAttribute));
            Assert.IsFalse(database.GetFlag(Guid.NewGuid(), Guid.NewGuid()));
            Assert.IsFalse(database.GetFlag(Guid.NewGuid(), sharedAttribute));
            Assert.IsFalse(database.GetFlag(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(setFloatEntityValue, database.GetFloat(setFloatEntity, sharedAttribute));
            Assert.AreEqual(doubleSetFloatEntityValue, database.GetFloat(doubleSetFloatEntity, sharedAttribute));
            Assert.AreEqual(setFloatAttributeValue, database.GetFloat(sharedEntity, setFloatAttribute));
            Assert.AreEqual(doubleSetFloatAttributeValue, database.GetFloat(sharedEntity, doubleSetFloatAttribute));
            Assert.AreEqual(0, database.GetFloat(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(0, database.GetFloat(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(0, database.GetFloat(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(setStringEntityValue, database.GetString(setStringEntity, sharedAttribute));
            Assert.AreEqual(doubleSetStringEntityValue, database.GetString(doubleSetStringEntity, sharedAttribute));
            Assert.AreEqual(setStringAttributeValue, database.GetString(sharedEntity, setStringAttribute));
            Assert.AreEqual(doubleSetStringAttributeValue, database.GetString(sharedEntity, doubleSetStringAttribute));
            Assert.AreEqual(string.Empty, database.GetString(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(string.Empty, database.GetString(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(string.Empty, database.GetString(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(setTagValue, database.GetTag(setTagIdentifier));
            Assert.AreEqual(doubleSetTagValue, database.GetTag(doubleSetTagIdentifier));
            Assert.AreEqual("cc273a1c3e154b44980244bad5cc5bdd", database.GetTag(new Guid("cc273a1c-3e15-4b44-9802-44bad5cc5bdd")));
            Assert.AreEqual(setReferenceEntityValue, database.GetReference(setReferenceEntity, sharedAttribute));
            Assert.AreEqual(doubleSetReferenceEntityValue, database.GetReference(doubleSetReferenceEntity, sharedAttribute));
            Assert.AreEqual(setReferenceAttributeValue, database.GetReference(sharedEntity, setReferenceAttribute));
            Assert.AreEqual(doubleSetReferenceAttributeValue, database.GetReference(sharedEntity, doubleSetReferenceAttribute));
            Assert.AreEqual(duplicateSetReferenceValue, database.GetReference(sharedEntity, duplicateSetReferenceAttribute));
            Assert.AreEqual(Guid.Empty, database.GetReference(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(Guid.Empty, database.GetReference(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(Guid.Empty, database.GetReference(sharedAttribute, Guid.NewGuid()));
            CollectionAssert.AreEquivalent(new[] { setReferenceEntity }, database.GetReferrers(sharedAttribute, setReferenceEntityValue).ToArray());
            CollectionAssert.AreEquivalent(new[] { doubleSetReferenceEntity }, database.GetReferrers(sharedAttribute, doubleSetReferenceEntityValue).ToArray());
            CollectionAssert.AreEquivalent(new[] { sharedEntity }, database.GetReferrers(setReferenceAttribute, setReferenceAttributeValue).ToArray());
            CollectionAssert.AreEquivalent(new[] { sharedEntity }, database.GetReferrers(doubleSetReferenceAttribute, doubleSetReferenceAttributeValue).ToArray());
            CollectionAssert.AreEquivalent(new[] { sharedEntity }, database.GetReferrers(duplicateSetReferenceAttribute, duplicateSetReferenceValue).ToArray());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, Guid.NewGuid()).Any());
            Assert.IsFalse(database.GetReferrers(Guid.NewGuid(), setReferenceEntityValue).Any());
            Assert.IsFalse(database.GetReferrers(Guid.NewGuid(), doubleSetReferenceEntityValue).Any());
            Assert.IsFalse(database.GetReferrers(setReferenceAttribute, sharedEntity).Any());
            Assert.IsFalse(database.GetReferrers(doubleSetReferenceAttribute, sharedEntity).Any());
            Assert.IsFalse(database.GetReferrers(setReferenceAttribute, Guid.NewGuid()).Any());
            Assert.IsFalse(database.GetReferrers(doubleSetReferenceAttribute, Guid.NewGuid()).Any());
            Assert.IsFalse(database.GetReferrers(Guid.NewGuid(), sharedEntity).Any());
            CollectionAssert.AreEquivalent(new[] { setThreeReferrerA, setThreeReferrerB, setThreeReferrerC }, database.GetReferrers(sharedAttribute, setThreeEntity).ToArray());
            CollectionAssert.AreEquivalent(new[] { setThreeChangeOneReferrerA, setThreeChangeOneReferrerC }, database.GetReferrers(sharedAttribute, setThreeChangeOneEntity).ToArray());
            CollectionAssert.AreEquivalent(new[] { setThreeChangeTwoReferrerC }, database.GetReferrers(sharedAttribute, setThreeChangeTwoEntity).ToArray());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, setThreeChangeThreeEntity).Any());
            Assert.AreEqual(setColorEntityValue, database.GetColor(setColorEntity, sharedAttribute));
            Assert.AreEqual(doubleSetColorEntityValue, database.GetColor(doubleSetColorEntity, sharedAttribute));
            Assert.AreEqual(setColorAttributeValue, database.GetColor(sharedEntity, setColorAttribute));
            Assert.AreEqual(doubleSetColorAttributeValue, database.GetColor(sharedEntity, doubleSetColorAttribute));
            Assert.AreEqual(default, database.GetColor(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(default, database.GetColor(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(default, database.GetColor(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(setImageEntityValue, database.GetImage(setImageEntity, sharedAttribute));
            Assert.AreEqual(doubleSetImageEntityValue, database.GetImage(doubleSetImageEntity, sharedAttribute));
            Assert.AreEqual(setImageAttributeValue, database.GetImage(sharedEntity, setImageAttribute));
            Assert.AreEqual(doubleSetImageAttributeValue, database.GetImage(sharedEntity, doubleSetImageAttribute));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(setMeshEntityValue, database.GetMesh(setMeshEntity, sharedAttribute));
            Assert.AreEqual(doubleSetMeshEntityValue, database.GetMesh(doubleSetMeshEntity, sharedAttribute));
            Assert.AreEqual(setMeshAttributeValue, database.GetMesh(sharedEntity, setMeshAttribute));
            Assert.AreEqual(doubleSetMeshAttributeValue, database.GetMesh(sharedEntity, doubleSetMeshAttribute));
            AssertEmptyMesh(database.GetMesh(Guid.NewGuid(), Guid.NewGuid()));
            AssertEmptyMesh(database.GetMesh(Guid.NewGuid(), sharedAttribute));
            AssertEmptyMesh(database.GetMesh(sharedAttribute, Guid.NewGuid()));
            CollectionAssert.AreEquivalent
            (
                new IInstruction[]
                {
                    new SetFlag(setFlagEntity, sharedAttribute),
                    new SetFlag(doubleSetFlagEntity, sharedAttribute),
                    new ClearFlag(clearFlagEntity, sharedAttribute),
                    new ClearFlag(doubleClearFlagEntity, sharedAttribute),
                    new ClearFlag(setThenClearFlagEntity, sharedAttribute),
                    new SetFlag(clearThenSetFlagEntity, sharedAttribute),
                    new SetFlag(sharedEntity, setFlagAttribute),
                    new SetFlag(sharedEntity, doubleSetFlagAttribute),
                    new ClearFlag(sharedEntity, clearFlagAttribute),
                    new ClearFlag(sharedEntity, doubleClearFlagAttribute),
                    new ClearFlag(sharedEntity, setThenClearFlagAttribute),
                    new SetFlag(sharedEntity, clearThenSetFlagAttribute),
                    new SetFloat(setFloatEntity, sharedAttribute, setFloatEntityValue),
                    new SetFloat(doubleSetFloatEntity, sharedAttribute, doubleSetFloatEntityValue),
                    new SetFloat(sharedEntity, setFloatAttribute, setFloatAttributeValue),
                    new SetFloat(sharedEntity, doubleSetFloatAttribute, doubleSetFloatAttributeValue),
                    new SetString(setStringEntity, sharedAttribute, setStringEntityValue),
                    new SetString(doubleSetStringEntity, sharedAttribute, doubleSetStringEntityValue),
                    new SetString(sharedEntity, setStringAttribute, setStringAttributeValue),
                    new SetString(sharedEntity, doubleSetStringAttribute, doubleSetStringAttributeValue),
                    new SetTag(setTagIdentifier, setTagValue),
                    new SetTag(doubleSetTagIdentifier, doubleSetTagValue),
                    new SetReference(setReferenceEntity, sharedAttribute, setReferenceEntityValue),
                    new SetReference(doubleSetReferenceEntity, sharedAttribute, doubleSetReferenceEntityValue),
                    new SetReference(sharedEntity, setReferenceAttribute, setReferenceAttributeValue),
                    new SetReference(sharedEntity, doubleSetReferenceAttribute, doubleSetReferenceAttributeValue),
                    new SetReference(sharedEntity, duplicateSetReferenceAttribute, duplicateSetReferenceValue),
                    new SetReference(setThreeReferrerA, sharedAttribute, setThreeEntity),
                    new SetReference(setThreeReferrerB, sharedAttribute, setThreeEntity),
                    new SetReference(setThreeReferrerC, sharedAttribute, setThreeEntity),
                    new SetReference(setThreeChangeOneReferrerA, sharedAttribute, setThreeChangeOneEntity),
                    new SetReference(setThreeChangeOneReferrerB, sharedAttribute, sharedEntity),
                    new SetReference(setThreeChangeOneReferrerC, sharedAttribute, setThreeChangeOneEntity),
                    new SetReference(setThreeChangeTwoReferrerA, sharedAttribute, sharedEntity),
                    new SetReference(setThreeChangeTwoReferrerB, sharedAttribute, sharedEntity),
                    new SetReference(setThreeChangeTwoReferrerC, sharedAttribute, setThreeChangeTwoEntity),
                    new SetReference(setThreeChangeThreeReferrerA, sharedAttribute, sharedEntity),
                    new SetReference(setThreeChangeThreeReferrerB, sharedAttribute, sharedEntity),
                    new SetReference(setThreeChangeThreeReferrerC, sharedAttribute, sharedEntity),
                    new SetColor(setColorEntity, sharedAttribute, setColorEntityValue),
                    new SetColor(doubleSetColorEntity, sharedAttribute, doubleSetColorEntityValue),
                    new SetColor(sharedEntity, setColorAttribute, setColorAttributeValue),
                    new SetColor(sharedEntity, doubleSetColorAttribute, doubleSetColorAttributeValue),
                    new SetImage(setImageEntity, sharedAttribute, setImageEntityValue),
                    new SetImage(doubleSetImageEntity, sharedAttribute, doubleSetImageEntityValue),
                    new SetImage(sharedEntity, setImageAttribute, setImageAttributeValue),
                    new SetImage(sharedEntity, doubleSetImageAttribute, doubleSetImageAttributeValue),
                    new SetMesh(setMeshEntity, sharedAttribute, setMeshEntityValue),
                    new SetMesh(doubleSetMeshEntity, sharedAttribute, doubleSetMeshEntityValue),
                    new SetMesh(sharedEntity, setMeshAttribute, setMeshAttributeValue),
                    new SetMesh(sharedEntity, doubleSetMeshAttribute, doubleSetMeshAttributeValue),
                },
                database.Patch.ToArray()
            );
            var to = new Mock<IDatabase>();
            database.Apply(to.Object);
            to.Verify(d => d.SetFlag(setFlagEntity, sharedAttribute), Times.Once());
            to.Verify(d => d.SetFlag(doubleSetFlagEntity, sharedAttribute), Times.Once());
            to.Verify(d => d.ClearFlag(clearFlagEntity, sharedAttribute), Times.Once());
            to.Verify(d => d.ClearFlag(doubleClearFlagEntity, sharedAttribute), Times.Once());
            to.Verify(d => d.ClearFlag(setThenClearFlagEntity, sharedAttribute), Times.Once());
            to.Verify(d => d.SetFlag(clearThenSetFlagEntity, sharedAttribute), Times.Once());
            to.Verify(d => d.SetFlag(sharedEntity, setFlagAttribute), Times.Once());
            to.Verify(d => d.SetFlag(sharedEntity, doubleSetFlagAttribute), Times.Once());
            to.Verify(d => d.ClearFlag(sharedEntity, clearFlagAttribute), Times.Once());
            to.Verify(d => d.ClearFlag(sharedEntity, doubleClearFlagAttribute), Times.Once());
            to.Verify(d => d.ClearFlag(sharedEntity, setThenClearFlagAttribute), Times.Once());
            to.Verify(d => d.SetFlag(sharedEntity, clearThenSetFlagAttribute), Times.Once());
            to.Verify(d => d.SetFloat(setFloatEntity, sharedAttribute, setFloatEntityValue), Times.Once());
            to.Verify(d => d.SetFloat(doubleSetFloatEntity, sharedAttribute, doubleSetFloatEntityValue), Times.Once());
            to.Verify(d => d.SetFloat(sharedEntity, setFloatAttribute, setFloatAttributeValue), Times.Once());
            to.Verify(d => d.SetFloat(sharedEntity, doubleSetFloatAttribute, doubleSetFloatAttributeValue), Times.Once());
            to.Verify(d => d.SetString(setStringEntity, sharedAttribute, setStringEntityValue), Times.Once());
            to.Verify(d => d.SetString(doubleSetStringEntity, sharedAttribute, doubleSetStringEntityValue), Times.Once());
            to.Verify(d => d.SetString(sharedEntity, setStringAttribute, setStringAttributeValue), Times.Once());
            to.Verify(d => d.SetString(sharedEntity, doubleSetStringAttribute, doubleSetStringAttributeValue), Times.Once());
            to.Verify(d => d.SetTag(setTagIdentifier, setTagValue), Times.Once());
            to.Verify(d => d.SetTag(doubleSetTagIdentifier, doubleSetTagValue), Times.Once());
            to.Verify(d => d.SetReference(setReferenceEntity, sharedAttribute, setReferenceEntityValue), Times.Once());
            to.Verify(d => d.SetReference(doubleSetReferenceEntity, sharedAttribute, doubleSetReferenceEntityValue), Times.Once());
            to.Verify(d => d.SetReference(sharedEntity, setReferenceAttribute, setReferenceAttributeValue), Times.Once());
            to.Verify(d => d.SetReference(sharedEntity, doubleSetReferenceAttribute, doubleSetReferenceAttributeValue), Times.Once());
            to.Verify(d => d.SetReference(sharedEntity, duplicateSetReferenceAttribute, duplicateSetReferenceValue), Times.Once());
            to.Verify(d => d.SetReference(setThreeReferrerA, sharedAttribute, setThreeEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeReferrerB, sharedAttribute, setThreeEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeReferrerC, sharedAttribute, setThreeEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeOneReferrerA, sharedAttribute, setThreeChangeOneEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeOneReferrerB, sharedAttribute, sharedEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeOneReferrerC, sharedAttribute, setThreeChangeOneEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeTwoReferrerA, sharedAttribute, sharedEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeTwoReferrerB, sharedAttribute, sharedEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeTwoReferrerC, sharedAttribute, setThreeChangeTwoEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeThreeReferrerA, sharedAttribute, sharedEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeThreeReferrerB, sharedAttribute, sharedEntity), Times.Once());
            to.Verify(d => d.SetReference(setThreeChangeThreeReferrerC, sharedAttribute, sharedEntity), Times.Once());
            to.Verify(d => d.SetColor(setColorEntity, sharedAttribute, setColorEntityValue), Times.Once());
            to.Verify(d => d.SetColor(doubleSetColorEntity, sharedAttribute, doubleSetColorEntityValue), Times.Once());
            to.Verify(d => d.SetColor(sharedEntity, setColorAttribute, setColorAttributeValue), Times.Once());
            to.Verify(d => d.SetColor(sharedEntity, doubleSetColorAttribute, doubleSetColorAttributeValue), Times.Once());
            to.Verify(d => d.SetImage(setImageEntity, sharedAttribute, setImageEntityValue), Times.Once());
            to.Verify(d => d.SetImage(doubleSetImageEntity, sharedAttribute, doubleSetImageEntityValue), Times.Once());
            to.Verify(d => d.SetImage(sharedEntity, setImageAttribute, setImageAttributeValue), Times.Once());
            to.Verify(d => d.SetImage(sharedEntity, doubleSetImageAttribute, doubleSetImageAttributeValue), Times.Once());
            to.Verify(d => d.SetMesh(setMeshEntity, sharedAttribute, setMeshEntityValue), Times.Once());
            to.Verify(d => d.SetMesh(doubleSetMeshEntity, sharedAttribute, doubleSetMeshEntityValue), Times.Once());
            to.Verify(d => d.SetMesh(sharedEntity, setMeshAttribute, setMeshAttributeValue), Times.Once());
            to.Verify(d => d.SetMesh(sharedEntity, doubleSetMeshAttribute, doubleSetMeshAttributeValue), Times.Once());
            to.VerifyNoOtherCalls();
            database.Clear();
            Assert.IsFalse(database.GetFlag(setFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(doubleSetFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(clearFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(doubleClearFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(setThenClearFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(clearThenSetFlagEntity, sharedAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, setFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, doubleSetFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, clearFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, doubleClearFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, setThenClearFlagAttribute));
            Assert.IsFalse(database.GetFlag(sharedEntity, clearThenSetFlagAttribute));
            Assert.IsFalse(database.GetFlag(Guid.NewGuid(), Guid.NewGuid()));
            Assert.IsFalse(database.GetFlag(Guid.NewGuid(), sharedAttribute));
            Assert.IsFalse(database.GetFlag(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(0, database.GetFloat(setFloatEntity, sharedAttribute));
            Assert.AreEqual(0, database.GetFloat(doubleSetFloatEntity, sharedAttribute));
            Assert.AreEqual(0, database.GetFloat(sharedEntity, setFloatAttribute));
            Assert.AreEqual(0, database.GetFloat(sharedEntity, doubleSetFloatAttribute));
            Assert.AreEqual(0, database.GetFloat(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(0, database.GetFloat(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(0, database.GetFloat(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(string.Empty, database.GetString(setStringEntity, sharedAttribute));
            Assert.AreEqual(string.Empty, database.GetString(doubleSetStringEntity, sharedAttribute));
            Assert.AreEqual(string.Empty, database.GetString(sharedEntity, setStringAttribute));
            Assert.AreEqual(string.Empty, database.GetString(sharedEntity, doubleSetStringAttribute));
            Assert.AreEqual(string.Empty, database.GetString(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(string.Empty, database.GetString(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(string.Empty, database.GetString(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual("e7d67415af6c4c8994b0641a39d22d18", database.GetTag(setTagIdentifier));
            Assert.AreEqual("f696fa4122cc45efa9c0db488c6fbbd4", database.GetTag(doubleSetTagIdentifier));
            Assert.AreEqual("cc273a1c3e154b44980244bad5cc5bdd", database.GetTag(new Guid("cc273a1c-3e15-4b44-9802-44bad5cc5bdd")));
            Assert.AreEqual(Guid.Empty, database.GetReference(setReferenceEntity, sharedAttribute));
            Assert.AreEqual(Guid.Empty, database.GetReference(doubleSetReferenceEntity, sharedAttribute));
            Assert.AreEqual(Guid.Empty, database.GetReference(sharedEntity, setReferenceAttribute));
            Assert.AreEqual(Guid.Empty, database.GetReference(sharedEntity, doubleSetReferenceAttribute));
            Assert.AreEqual(Guid.Empty, database.GetReference(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(Guid.Empty, database.GetReference(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(Guid.Empty, database.GetReference(sharedAttribute, Guid.NewGuid()));
            Assert.IsFalse(database.GetReferrers(sharedAttribute, setReferenceEntityValue).Any());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, doubleSetReferenceEntityValue).Any());
            Assert.IsFalse(database.GetReferrers(setReferenceAttribute, setReferenceAttributeValue).Any());
            Assert.IsFalse(database.GetReferrers(doubleSetReferenceAttribute, doubleSetReferenceAttributeValue).Any());
            Assert.IsFalse(database.GetReferrers(duplicateSetReferenceAttribute, duplicateSetReferenceValue).Any());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, Guid.NewGuid()).Any());
            Assert.IsFalse(database.GetReferrers(Guid.NewGuid(), setReferenceEntityValue).Any());
            Assert.IsFalse(database.GetReferrers(Guid.NewGuid(), doubleSetReferenceEntityValue).Any());
            Assert.IsFalse(database.GetReferrers(setReferenceAttribute, sharedEntity).Any());
            Assert.IsFalse(database.GetReferrers(doubleSetReferenceAttribute, sharedEntity).Any());
            Assert.IsFalse(database.GetReferrers(setReferenceAttribute, Guid.NewGuid()).Any());
            Assert.IsFalse(database.GetReferrers(doubleSetReferenceAttribute, Guid.NewGuid()).Any());
            Assert.IsFalse(database.GetReferrers(Guid.NewGuid(), sharedEntity).Any());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, setThreeEntity).Any());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, setThreeChangeOneEntity).Any());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, setThreeChangeTwoEntity).Any());
            Assert.IsFalse(database.GetReferrers(sharedAttribute, setThreeChangeThreeEntity).Any());
            Assert.AreEqual(default, database.GetColor(setColorEntity, sharedAttribute));
            Assert.AreEqual(default, database.GetColor(doubleSetColorEntity, sharedAttribute));
            Assert.AreEqual(default, database.GetColor(sharedEntity, setColorAttribute));
            Assert.AreEqual(default, database.GetColor(sharedEntity, doubleSetColorAttribute));
            Assert.AreEqual(default, database.GetColor(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(default, database.GetColor(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(default, database.GetColor(sharedAttribute, Guid.NewGuid()));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(setImageEntity, sharedAttribute));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(doubleSetImageEntity, sharedAttribute));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(sharedEntity, setImageAttribute));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(sharedEntity, doubleSetImageAttribute));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(Guid.NewGuid(), Guid.NewGuid()));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(Guid.NewGuid(), sharedAttribute));
            Assert.AreEqual(new Image(1, ImmutableArray.Create(default(ColorWithOpacity))), database.GetImage(sharedAttribute, Guid.NewGuid()));
            AssertEmptyMesh(database.GetMesh(setMeshEntity, sharedAttribute));
            AssertEmptyMesh(database.GetMesh(doubleSetMeshEntity, sharedAttribute));
            AssertEmptyMesh(database.GetMesh(sharedEntity, setMeshAttribute));
            AssertEmptyMesh(database.GetMesh(sharedEntity, doubleSetMeshAttribute));
            AssertEmptyMesh(database.GetMesh(Guid.NewGuid(), Guid.NewGuid()));
            AssertEmptyMesh(database.GetMesh(Guid.NewGuid(), sharedAttribute));
            AssertEmptyMesh(database.GetMesh(sharedAttribute, Guid.NewGuid()));
            Assert.IsFalse(database.Patch.Any());
            var to2 = new Mock<IDatabase>();
            database.Apply(to2.Object);
            to2.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void SetStringThrowsExceptionWhenValueNull()
        {
            var database = new Database();
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                database.SetString(entity, attribute, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void SetStringThrowsExceptionWhenLengthLimitExceededByOneByte()
        {
            var database = new Database();
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String65536BytesInUTF8();

            try
            {
                database.SetString(entity, attribute, value);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot exceed 65535 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void SetStringThrowsExceptionWhenLengthLimitExceededByTwoBytes()
        {
            var database = new Database();
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String65537BytesInUTF8();

            try
            {
                database.SetString(entity, attribute, value);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot exceed 65535 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void SetStringPermitsAtLengthLimit()
        {
            var database = new Database();
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();
            var value = Generate.String65535BytesInUTF8();

            database.SetString(entity, attribute, value);
        }

        [TestMethod]
        public void SetTagThrowsExceptionWhenValueNull()
        {
            var database = new Database();
            var identifier = Guid.NewGuid();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                database.SetTag(identifier, null);
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
        public void SetTagThrowsExceptionWhenValueEmpty()
        {
            var database = new Database();
            var identifier = Guid.NewGuid();

            try
            {
                database.SetTag(identifier, string.Empty);
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
        public void SetTagThrowsExceptionWhenLengthLimitExceededByOneByte()
        {
            var database = new Database();
            var identifier = Guid.NewGuid();
            var value = Generate.String256BytesInUTF8();

            try
            {
                database.SetTag(identifier, value);
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
        public void SetTagThrowsExceptionWhenLengthLimitExceededByTwoBytes()
        {
            var database = new Database();
            var identifier = Guid.NewGuid();
            var value = Generate.String257BytesInUTF8();

            try
            {
                database.SetTag(identifier, value);
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
        public void SetTagPermitsAtLengthLimit()
        {
            var database = new Database();
            var identity = Guid.NewGuid();
            var value = Generate.String255BytesInUTF8();

            database.SetTag(identity, value);
        }

        [TestMethod]
        public void SetImageThrowsExceptionWhenValueNull()
        {
            var database = new Database();
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            try
            {
                database.SetImage(entity, attribute, null!);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }

        [TestMethod]
        public void SetMeshThrowsExceptionWhenValueNull()
        {
            var database = new Database();
            var entity = Guid.NewGuid();
            var attribute = Guid.NewGuid();

            try
            {
                database.SetMesh(entity, attribute, null!);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null. (Parameter 'value')", exception.Message);
                Assert.AreEqual("value", exception.ParamName);
            }
        }
    }
}
