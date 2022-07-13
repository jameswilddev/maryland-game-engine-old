using Maryland.Stores.TagStores;
using System.Collections.Immutable;

namespace Maryland.Unit.StoreTests.TagStoreTests
{
    [TestClass]
    public sealed class TagStoreDiffTests
    {
        [TestMethod]
        public void ExposesSet()
        {
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.").Add(Guid.NewGuid(), "Test Tag C");
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            var tagStoreDiff = new TagStoreDiff(set, deleted);

            Assert.AreEqual(set, tagStoreDiff.Set);
        }

        [TestMethod]
        public void ExposesDeleted()
        {
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.").Add(Guid.NewGuid(), "Test Tag C");
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            var tagStoreDiff = new TagStoreDiff(set, deleted);

            Assert.AreEqual(deleted, tagStoreDiff.Deleted);
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetNull()
        {
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new TagStoreDiff(null, deleted);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch(ArgumentNullException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenDeletedNull()
        {
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.").Add(Guid.NewGuid(), "Test Tag C");

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new TagStoreDiff(set, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("deleted", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'deleted')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetAndDeletedShareKeys()
        {
            var commonIdentifier = Guid.NewGuid();
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(commonIdentifier, "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.").Add(Guid.NewGuid(), "Test Tag C");
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), commonIdentifier, Guid.NewGuid());

            try
            {
                _ = new TagStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentException exception)
            {
                Assert.IsNull(exception.ParamName);
                Assert.AreEqual("Cannot set and delete a mapping from the same identifier in the same TagStoreDiff.", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetContainsNullTags()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), null).Add(Guid.NewGuid(), "Test Tag C");
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            try
            {
                _ = new TagStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Tag names cannot be null, empty or white space. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetContainsEmptyTags()
        {
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), "").Add(Guid.NewGuid(), "Test Tag C");
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            try
            {
                _ = new TagStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Tag names cannot be null, empty or white space. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetContainsWhiteSpaceTags()
        {
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), "   \n    \r     \t").Add(Guid.NewGuid(), "Test Tag C");
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            try
            {
                _ = new TagStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Tag names cannot be null, empty or white space. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetContainsTagsContaining256UTF8Bytes()
        {
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty six bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we find them.").Add(Guid.NewGuid(), "Test Tag C");
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            try
            {
                _ = new TagStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Tag names cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSetContainsTagsContaining257UTF8Bytes()
        {
            var set = ImmutableDictionary<Guid, string>.Empty.Add(Guid.NewGuid(), "Test Tag A").Add(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty seven bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  I have found all.").Add(Guid.NewGuid(), "Test Tag C");
            var deleted = ImmutableHashSet.Create(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            try
            {
                _ = new TagStoreDiff(set, deleted);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("set", exception.ParamName);
                Assert.AreEqual("Tag names cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'set')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }
    }
}
