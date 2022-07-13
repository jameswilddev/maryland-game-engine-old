using Maryland.Stores.TagStores;

namespace Maryland.Unit.StoreTests.TagStoreTests
{
    [TestClass]
    public sealed class TagStoreTests
    {
        [TestMethod]
        public void AllowsRetrievalOfMappings()
        {
            var tagStore = new TagStore();
            var identifierA = Guid.NewGuid();
            var identifierB = Guid.NewGuid();
            var identifierC = Guid.NewGuid();
            var identifierD = Guid.NewGuid();

            tagStore[identifierB] = "Test Tag B";
            tagStore[identifierA] = "Test Tag A";
            tagStore[identifierC] = "Test Tag D";
            tagStore[identifierB] = "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.";
            tagStore[identifierC] = null;
            tagStore[identifierC] = "Test Tag E";
            tagStore[identifierD] = null;

            Assert.AreEqual("Test Tag A", tagStore[identifierA]);
            Assert.AreEqual("This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.", tagStore[identifierB]);
            Assert.AreEqual("Test Tag E", tagStore[identifierC]);
            Assert.IsNull(tagStore[identifierD]);
            Assert.IsNull(tagStore[Guid.NewGuid()]);
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagNameEmpty()
        {
            var tagStore = new TagStore();

            try
            {
                tagStore[Guid.NewGuid()] = "";
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
                Assert.AreEqual("Tags cannot be empty or white space; use null to delete them. (Parameter 'value')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagNameWhiteSpace()
        {
            var tagStore = new TagStore();

            try
            {
                tagStore[Guid.NewGuid()] = "    \n    \t     \r     ";
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
                Assert.AreEqual("Tags cannot be empty or white space; use null to delete them. (Parameter 'value')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagName256UTF8Bytes()
        {
            var tagStore = new TagStore();

            try
            {
                tagStore[Guid.NewGuid()] = "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty six bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we find them.";
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
                Assert.AreEqual("Tag names cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagName257UTF8Bytes()
        {
            var tagStore = new TagStore();

            try
            {
                tagStore[Guid.NewGuid()] = "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty seven bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  I have found all.";
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
                Assert.AreEqual("Tag names cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'value')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void AllowsIterationOfMappings()
        {
            var tagStore = new TagStore();
            var identifierA = Guid.NewGuid();
            var identifierB = Guid.NewGuid();
            var identifierC = Guid.NewGuid();
            var identifierD = Guid.NewGuid();

            tagStore[identifierB] = "Test Tag B";
            tagStore[identifierA] = "Test Tag A";
            tagStore[identifierC] = "Test Tag D";
            tagStore[identifierB] = "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.";
            tagStore[identifierC] = null;
            tagStore[identifierC] = "Test Tag E";
            tagStore[identifierD] = null;

            CollectionAssert.AreEquivalent(new[]
            {
                new TagMapping(identifierA, "Test Tag A"),
                new TagMapping(identifierB, "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now."),
                new TagMapping(identifierC, "Test Tag E"),
            }, tagStore.MappedIdentifiers.ToArray());
        }

        [TestMethod]
        public void DoesNotThrowAnExceptionReturnTheSameMappingMultipleTimesOrReturnAnInvalidMappingWhenMappingsChangeDuringIteration()
        {
            var tagStore = new TagStore();
            var identifierA = Guid.NewGuid();
            var identifierB = Guid.NewGuid();
            var identifierC = Guid.NewGuid();
            var identifierD = Guid.NewGuid();
            var identifierE = Guid.NewGuid();
            var identifierF = Guid.NewGuid();
            var identifierG = Guid.NewGuid();
            var identifierH = Guid.NewGuid();
            var identifierI = Guid.NewGuid();
            var identifierJ = Guid.NewGuid();
            var identifierK = Guid.NewGuid();
            tagStore[identifierB] = "Test Tag B";
            tagStore[identifierA] = "Test Tag A";
            tagStore[identifierC] = "Test Tag D";
            tagStore[identifierB] = "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.";
            tagStore[identifierC] = null;
            tagStore[identifierC] = "Test Tag E";
            tagStore[identifierD] = null;
            tagStore[identifierF] = "Test Tag G";
            tagStore[identifierE] = "Test Tag F";
            tagStore[identifierG] = "Test Tag I";
            tagStore[identifierF] = "Test Tag H";
            tagStore[identifierG] = null;
            tagStore[identifierG] = "Test Tag J";
            tagStore[identifierK] = "Test Tag Q";

            var result = new List<TagMapping>();

            var enumerator = tagStore.MappedIdentifiers.GetEnumerator();
            enumerator.MoveNext();
            result.Add(enumerator.Current);
            var hasMore = enumerator.MoveNext();
            tagStore[identifierA] = null;
            tagStore[identifierB] = null;
            tagStore[identifierC] = null;
            tagStore[identifierE] = "Test Tag K";
            tagStore[identifierF] = "Test Tag L";
            tagStore[identifierG] = "Test Tag M";
            tagStore[identifierH] = "Test Tag N";
            tagStore[identifierI] = "Test Tag O";
            tagStore[identifierJ] = "Test Tag P";
            while (hasMore)
            {
                result.Add(enumerator.Current);
                hasMore = enumerator.MoveNext();
            }

            CollectionAssert.AllItemsAreUnique(result.Select(item => item.Identifier).ToArray());
            var resultMappings = result.ToDictionary(kv => kv.Identifier, kv => kv.Tag);
            CollectionAssert.IsSubsetOf(resultMappings.Keys, new[] { identifierA, identifierB, identifierC, identifierE, identifierF, identifierG, identifierH, identifierI, identifierJ, identifierK });
            CollectionAssert.IsSubsetOf(new[] { identifierE, identifierF, identifierG, identifierK }, resultMappings.Keys);
            if (resultMappings.ContainsKey(identifierA))
            {
                Assert.AreEqual("Test Tag A", resultMappings[identifierA]);
            }
            if (resultMappings.ContainsKey(identifierB))
            {
                Assert.AreEqual("This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.", resultMappings[identifierB]);
            }
            if (resultMappings.ContainsKey(identifierC))
            {
                Assert.AreEqual("Test Tag E", resultMappings[identifierC]);
            }
            if (resultMappings.ContainsKey(identifierE))
            {
                CollectionAssert.Contains(new[] { "Test Tag F", "Test Tag K" }, resultMappings[identifierE], resultMappings[identifierE]);
            }
            if (resultMappings.ContainsKey(identifierF))
            {
                CollectionAssert.Contains(new[] { "Test Tag H", "Test Tag L" }, resultMappings[identifierF], resultMappings[identifierF]);
            }
            if (resultMappings.ContainsKey(identifierG))
            {
                CollectionAssert.Contains(new[] { "Test Tag J", "Test Tag M" }, resultMappings[identifierG], resultMappings[identifierG]);
            }
            if (resultMappings.ContainsKey(identifierH))
            {
                Assert.AreEqual("Test Tag N", resultMappings[identifierH]);
            }
            if (resultMappings.ContainsKey(identifierI))
            {
                Assert.AreEqual("Test Tag O", resultMappings[identifierI]);
            }
            if (resultMappings.ContainsKey(identifierJ))
            {
                Assert.AreEqual("Test Tag P", resultMappings[identifierJ]);
            }
            Assert.AreEqual("Test Tag Q", resultMappings[identifierK]);
        }
    }
}