using Maryland.Stores.ReferenceStores;

namespace Maryland.Unit.StoreTests.ReferenceStoreTests
{
    [TestClass]
    public sealed class ReferenceStoreTests
    {
        [TestMethod]
        public void AllowsRetrievalOfMappings()
        {
            var referenceStore = new ReferenceStore();
            var entityA = Guid.NewGuid();
            var entityB = Guid.NewGuid();
            var entityC = Guid.NewGuid();
            var entityD = Guid.NewGuid();
            var attributeA = Guid.NewGuid();
            var attributeB = Guid.NewGuid();
            var valueA = Guid.NewGuid();
            var valueB = Guid.NewGuid();
            var valueC = Guid.NewGuid();
            var valueD = Guid.NewGuid();
            var valueE = Guid.NewGuid();
            var valueF = Guid.NewGuid();
            var valueG = Guid.NewGuid();

            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeB)] = valueD;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeA)] = valueE;
            referenceStore[new EntityAttributeIdentifierPair(entityA, attributeA)] = valueA;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeA)] = valueB;
            referenceStore[new EntityAttributeIdentifierPair(entityA, attributeB)] = valueC;
            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeA)] = valueF;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeB)] = valueG;
            referenceStore[new EntityAttributeIdentifierPair(entityD, attributeA)] = Guid.Empty;

            Assert.AreEqual(valueA, referenceStore[new EntityAttributeIdentifierPair(entityA, attributeA)]);
            Assert.AreEqual(valueB, referenceStore[new EntityAttributeIdentifierPair(entityB, attributeA)]);
            Assert.AreEqual(valueC, referenceStore[new EntityAttributeIdentifierPair(entityA, attributeB)]);
            Assert.AreEqual(Guid.Empty, referenceStore[new EntityAttributeIdentifierPair(entityB, attributeB)]);
            Assert.AreEqual(valueF, referenceStore[new EntityAttributeIdentifierPair(entityC, attributeA)]);
            Assert.AreEqual(valueG, referenceStore[new EntityAttributeIdentifierPair(entityC, attributeB)]);
            Assert.AreEqual(Guid.Empty, referenceStore[new EntityAttributeIdentifierPair(entityD, attributeA)]);
            Assert.AreEqual(Guid.Empty, referenceStore[new EntityAttributeIdentifierPair(entityD, attributeB)]);
            Assert.AreEqual(Guid.Empty, referenceStore[new EntityAttributeIdentifierPair(Guid.NewGuid(), attributeA)]);
            Assert.AreEqual(Guid.Empty, referenceStore[new EntityAttributeIdentifierPair(entityA, Guid.NewGuid())]);
        }

        [TestMethod]
        public void AllowsIterationOfMappings()
        {
            var referenceStore = new ReferenceStore();
            var entityA = Guid.NewGuid();
            var entityB = Guid.NewGuid();
            var entityC = Guid.NewGuid();
            var entityD = Guid.NewGuid();
            var attributeA = Guid.NewGuid();
            var attributeB = Guid.NewGuid();
            var valueA = Guid.NewGuid();
            var valueB = Guid.NewGuid();
            var valueC = Guid.NewGuid();
            var valueD = Guid.NewGuid();
            var valueE = Guid.NewGuid();
            var valueF = Guid.NewGuid();
            var valueG = Guid.NewGuid();

            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeB)] = valueD;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeA)] = valueE;
            referenceStore[new EntityAttributeIdentifierPair(entityA, attributeA)] = valueA;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeA)] = valueB;
            referenceStore[new EntityAttributeIdentifierPair(entityA, attributeB)] = valueC;
            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeA)] = valueF;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeB)] = valueG;
            referenceStore[new EntityAttributeIdentifierPair(entityD, attributeA)] = Guid.Empty;

            CollectionAssert.AreEquivalent(new[]
            {
                new ReferenceMapping(entityA, attributeA, valueA),
                new ReferenceMapping(entityB, attributeA, valueB),
                new ReferenceMapping(entityA, attributeB, valueC),
                new ReferenceMapping(entityC, attributeA, valueF),
                new ReferenceMapping(entityC, attributeB, valueG),
            }, referenceStore.MappedReferences.ToArray());
        }

        [TestMethod]
        public void DoesNotThrowAnExceptionReturnTheSameMappingMultipleTimesOrReturnAnInvalidMappingWhenMappingsChangeDuringIteration()
        {
            var referenceStore = new ReferenceStore();
            var entityA = Guid.NewGuid();
            var entityB = Guid.NewGuid();
            var entityC = Guid.NewGuid();
            var entityD = Guid.NewGuid();
            var entityE = Guid.NewGuid();
            var entityF = Guid.NewGuid();
            var entityG = Guid.NewGuid();
            var entityH = Guid.NewGuid();
            var entityI = Guid.NewGuid();
            var entityJ = Guid.NewGuid();
            var entityK = Guid.NewGuid();
            var entityL = Guid.NewGuid();
            var entityM = Guid.NewGuid();
            var attributeA = Guid.NewGuid();
            var attributeB = Guid.NewGuid();
            var valueA = Guid.NewGuid();
            var valueB = Guid.NewGuid();
            var valueC = Guid.NewGuid();
            var valueD = Guid.NewGuid();
            var valueE = Guid.NewGuid();
            var valueF = Guid.NewGuid();
            var valueG = Guid.NewGuid();
            var valueH = Guid.NewGuid();
            var valueI = Guid.NewGuid();
            var valueJ = Guid.NewGuid();
            var valueK = Guid.NewGuid();
            var valueL = Guid.NewGuid();
            var valueM = Guid.NewGuid();
            var valueN = Guid.NewGuid();
            var valueO = Guid.NewGuid();
            var valueP = Guid.NewGuid();
            var valueQ = Guid.NewGuid();
            var valueR = Guid.NewGuid();
            var valueS = Guid.NewGuid();
            var valueT = Guid.NewGuid();
            var valueU = Guid.NewGuid();
            var valueV = Guid.NewGuid();
            var valueW = Guid.NewGuid();
            var valueX = Guid.NewGuid();
            var valueY = Guid.NewGuid();
            var valueZ = Guid.NewGuid();
            var valueAA = Guid.NewGuid();
            var valueAB = Guid.NewGuid();
            var valueAC = Guid.NewGuid();
            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeB)] = valueD;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeA)] = valueE;
            referenceStore[new EntityAttributeIdentifierPair(entityA, attributeA)] = valueA;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeA)] = valueB;
            referenceStore[new EntityAttributeIdentifierPair(entityA, attributeB)] = valueC;
            referenceStore[new EntityAttributeIdentifierPair(entityB, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeA)] = valueF;
            referenceStore[new EntityAttributeIdentifierPair(entityC, attributeB)] = valueG;
            referenceStore[new EntityAttributeIdentifierPair(entityD, attributeA)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityF, attributeB)] = valueK;
            referenceStore[new EntityAttributeIdentifierPair(entityG, attributeA)] = valueL;
            referenceStore[new EntityAttributeIdentifierPair(entityE, attributeA)] = valueH;
            referenceStore[new EntityAttributeIdentifierPair(entityG, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityF, attributeA)] = valueI;
            referenceStore[new EntityAttributeIdentifierPair(entityE, attributeB)] = valueJ;
            referenceStore[new EntityAttributeIdentifierPair(entityF, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityG, attributeA)] = valueM;
            referenceStore[new EntityAttributeIdentifierPair(entityG, attributeB)] = valueN;
            referenceStore[new EntityAttributeIdentifierPair(entityH, attributeA)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityJ, attributeB)] = valueR;
            referenceStore[new EntityAttributeIdentifierPair(entityK, attributeA)] = valueS;
            referenceStore[new EntityAttributeIdentifierPair(entityI, attributeA)] = valueO;
            referenceStore[new EntityAttributeIdentifierPair(entityK, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityJ, attributeA)] = valueP;
            referenceStore[new EntityAttributeIdentifierPair(entityI, attributeB)] = valueQ;
            referenceStore[new EntityAttributeIdentifierPair(entityJ, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityK, attributeA)] = valueT;
            referenceStore[new EntityAttributeIdentifierPair(entityK, attributeB)] = valueU;
            referenceStore[new EntityAttributeIdentifierPair(entityL, attributeA)] = Guid.Empty;
            var result = new List<ReferenceMapping>();

            var enumerator = referenceStore.MappedReferences.GetEnumerator();
            enumerator.MoveNext();
            result.Add(enumerator.Current);
            var hasMore = enumerator.MoveNext();
            referenceStore[new EntityAttributeIdentifierPair(entityE, attributeA)] = valueV;
            referenceStore[new EntityAttributeIdentifierPair(entityF, attributeA)] = valueW;
            referenceStore[new EntityAttributeIdentifierPair(entityE, attributeB)] = valueX;
            referenceStore[new EntityAttributeIdentifierPair(entityF, attributeB)] = valueY;
            referenceStore[new EntityAttributeIdentifierPair(entityG, attributeA)] = valueZ;
            referenceStore[new EntityAttributeIdentifierPair(entityG, attributeB)] = valueAA;
            referenceStore[new EntityAttributeIdentifierPair(entityH, attributeA)] = valueAB;
            referenceStore[new EntityAttributeIdentifierPair(entityJ, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityI, attributeA)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityJ, attributeA)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityI, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityK, attributeA)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityK, attributeB)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityL, attributeA)] = Guid.Empty;
            referenceStore[new EntityAttributeIdentifierPair(entityM, attributeA)] = valueAC;
            referenceStore[new EntityAttributeIdentifierPair(entityM, attributeB)] = Guid.Empty;
            while (hasMore)
            {
                result.Add(enumerator.Current);
                hasMore = enumerator.MoveNext();
            }

            CollectionAssert.AllItemsAreUnique(result.Select(item => new EntityAttributeIdentifierPair(item.Entity, item.Attribute)).ToArray());
            var resultMappings = result.ToDictionary(m => new EntityAttributeIdentifierPair(m.Entity, m.Attribute), m => m.Value);
            CollectionAssert.IsSubsetOf
            (
                resultMappings.Keys, 
                new[]
                {
                    new EntityAttributeIdentifierPair(entityB, attributeB),
                    new EntityAttributeIdentifierPair(entityC, attributeA),
                    new EntityAttributeIdentifierPair(entityA, attributeA),
                    new EntityAttributeIdentifierPair(entityC, attributeB),
                    new EntityAttributeIdentifierPair(entityB, attributeA),
                    new EntityAttributeIdentifierPair(entityA, attributeB),
                    new EntityAttributeIdentifierPair(entityD, attributeA),
                    new EntityAttributeIdentifierPair(entityF, attributeB),
                    new EntityAttributeIdentifierPair(entityG, attributeA),
                    new EntityAttributeIdentifierPair(entityE, attributeA),
                    new EntityAttributeIdentifierPair(entityG, attributeB),
                    new EntityAttributeIdentifierPair(entityF, attributeA),
                    new EntityAttributeIdentifierPair(entityE, attributeB),
                    new EntityAttributeIdentifierPair(entityH, attributeA),
                    new EntityAttributeIdentifierPair(entityK, attributeA),
                    new EntityAttributeIdentifierPair(entityI, attributeA),
                    new EntityAttributeIdentifierPair(entityK, attributeB),
                    new EntityAttributeIdentifierPair(entityJ, attributeA),
                    new EntityAttributeIdentifierPair(entityI, attributeB),
                    new EntityAttributeIdentifierPair(entityL, attributeA),
                    new EntityAttributeIdentifierPair(entityM, attributeA),
                }
            );
            CollectionAssert.IsSubsetOf
            (
                new[]
                {
                    new EntityAttributeIdentifierPair(entityC, attributeA),
                    new EntityAttributeIdentifierPair(entityA, attributeA),
                    new EntityAttributeIdentifierPair(entityC, attributeB),
                    new EntityAttributeIdentifierPair(entityB, attributeA),
                    new EntityAttributeIdentifierPair(entityA, attributeB),
                    new EntityAttributeIdentifierPair(entityG, attributeA),
                    new EntityAttributeIdentifierPair(entityE, attributeA),
                    new EntityAttributeIdentifierPair(entityF, attributeA),
                    new EntityAttributeIdentifierPair(entityE, attributeB),
                },
                resultMappings.Keys
            );
            Assert.AreEqual(valueF, resultMappings[new EntityAttributeIdentifierPair(entityC, attributeA)]);
            Assert.AreEqual(valueA, resultMappings[new EntityAttributeIdentifierPair(entityA, attributeA)]);
            Assert.AreEqual(valueG, resultMappings[new EntityAttributeIdentifierPair(entityC, attributeB)]);
            Assert.AreEqual(valueB, resultMappings[new EntityAttributeIdentifierPair(entityB, attributeA)]);
            Assert.AreEqual(valueC, resultMappings[new EntityAttributeIdentifierPair(entityA, attributeB)]);
            
            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityF, attributeB))) {
                Assert.AreEqual(valueY, resultMappings[new EntityAttributeIdentifierPair(entityF, attributeB)]);
            }
            
            CollectionAssert.Contains(new [] { valueM, valueZ }, resultMappings[new EntityAttributeIdentifierPair(entityG, attributeA)]);
            CollectionAssert.Contains(new [] { valueH, valueV }, resultMappings[new EntityAttributeIdentifierPair(entityE, attributeA)]);
            CollectionAssert.Contains(new [] { valueN, valueAA }, resultMappings[new EntityAttributeIdentifierPair(entityG, attributeB)]);
            CollectionAssert.Contains(new [] { valueI, valueW }, resultMappings[new EntityAttributeIdentifierPair(entityF, attributeA)]);
            CollectionAssert.Contains(new [] { valueJ, valueX }, resultMappings[new EntityAttributeIdentifierPair(entityE, attributeB)]);
            
            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityH, attributeA))) {
                Assert.AreEqual(valueAB, resultMappings[new EntityAttributeIdentifierPair(entityH, attributeA)]);
            }
            
            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityK, attributeA))) {
                Assert.AreEqual(valueT, resultMappings[new EntityAttributeIdentifierPair(entityK, attributeA)]);
            }
            
            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityI, attributeA))) {
                Assert.AreEqual(valueO, resultMappings[new EntityAttributeIdentifierPair(entityI, attributeA)]);
            }
            
            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityK, attributeB))) {
                Assert.AreEqual(valueU, resultMappings[new EntityAttributeIdentifierPair(entityK, attributeB)]);
            }
            
            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityJ, attributeA))) {
                Assert.AreEqual(valueP, resultMappings[new EntityAttributeIdentifierPair(entityJ, attributeA)]);
            }
            
            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityI, attributeB))) {
                Assert.AreEqual(valueQ, resultMappings[new EntityAttributeIdentifierPair(entityI, attributeB)]);
            }

            if (resultMappings.ContainsKey(new EntityAttributeIdentifierPair(entityM, attributeA)))
            {
                Assert.AreEqual(valueAC, resultMappings[new EntityAttributeIdentifierPair(entityM, attributeA)]);
            }
        }
    }
}