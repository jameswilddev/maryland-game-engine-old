using Maryland.Stores.TagStores;

namespace Maryland.Unit.StoreTests.TagStoreTests
{
    [TestClass]
    public sealed class EntityAttributeIdentifierPairTests
    {
        [TestMethod]
        public void ExposesIdentifier()
        {
            var identifier = Guid.NewGuid();

            var tagMapping = new TagMapping(identifier, "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");

            Assert.AreEqual(identifier, tagMapping.Identifier);
        }

        [TestMethod]
        public void ExposesTag()
        {
            var tagMapping = new TagMapping(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");

            Assert.AreEqual("This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.", tagMapping.Tag);
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagIsNull()
        {
            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = new TagMapping(Guid.NewGuid(), null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tag", exception.ParamName);
                Assert.AreEqual("Value cannot be null, empty or white space. (Parameter 'tag')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagIsEmpty()
        {
            try
            {
                _ = new TagMapping(Guid.NewGuid(), "");
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tag", exception.ParamName);
                Assert.AreEqual("Value cannot be null, empty or white space. (Parameter 'tag')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagIsWhiteSpace()
        {
            try
            {
                _ = new TagMapping(Guid.NewGuid(), "           \n      \r          \t               ");
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("tag", exception.ParamName);
                Assert.AreEqual("Value cannot be null, empty or white space. (Parameter 'tag')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagIs256UTF8Bytes()
        {
            try
            {
                _ = new TagMapping(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty six bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we find them.");
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("tag", exception.ParamName);
                Assert.AreEqual("Tag names cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'tag')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowsAnExceptionWhenTagIs257UTF8Bytes()
        {
            try
            {
                _ = new TagMapping(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty seven bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  I have found all.");
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.AreEqual("tag", exception.ParamName);
                Assert.AreEqual("Tag names cannot exceed 255 bytes in length when encoded as UTF-8. (Parameter 'tag')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void Equal()
        {
            var identifier = Guid.NewGuid();

            var a = new TagMapping(identifier, "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");
            var b = new TagMapping(identifier, "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");

            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void IdentifierNotEqual()
        {
            var a = new TagMapping(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");
            var b = new TagMapping(Guid.NewGuid(), "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void TagNotEqual()
        {
            var identifier = Guid.NewGuid();

            var a = new TagMapping(identifier, "Test Tag A");
            var b = new TagMapping(identifier, "Test Tag B");

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void GetHashCodeReturnsSameValueForSameIdentifierAndTag()
        {
            var identifier = Guid.NewGuid();

            var a = new TagMapping(identifier, "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");
            var b = new TagMapping(identifier, "This is a string, which, encoded as UTF-8, is exactly two hundred and fifty five bytes in length for the purposes of testing length limits.  Some multi-byte characters include あ, 𩸽 and §.  Still more characters to go.  Nearly done.  Here we are now.");

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void ThrowIfUninitializedThrowsWhenUninitialized()
        {
            try
            {
                default(TagMapping).ThrowIfUninitialized();
                Assert.Fail();
            }
            catch (InvalidOperationException exception)
            {
                Assert.AreEqual("TagMapping uninitialized.", exception.Message);
                Assert.IsNull(exception.InnerException);
            }
        }

        [TestMethod]
        public void ThrowIfUninitializedDoesNothingWhenInitialized()
        {
            var tagMapping = new TagMapping(Guid.NewGuid(), "Test Tag");

            tagMapping.ThrowIfUninitialized();
        }
    }
}
