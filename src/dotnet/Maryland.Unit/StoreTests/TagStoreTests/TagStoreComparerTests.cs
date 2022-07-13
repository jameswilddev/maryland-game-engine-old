using Maryland.Stores.TagStores;
using Moq;

namespace Maryland.Unit.StoreTests.TagStoreTests
{
    [TestClass]
    public sealed class TagStoreComparerTests
    {
        [TestMethod]
        public void ThrowsWhenANull()
        {
            var tagStoreComparer = new TagStoreComparer();
            var b = new Mock<ITagStore>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = tagStoreComparer.Compare(null, b.Object);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("a", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'a')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }

            b.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsWhenBNull()
        {
            var tagStoreComparer = new TagStoreComparer();
            var a = new Mock<ITagStore>();

            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _ = tagStoreComparer.Compare(a.Object, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("b", exception.ParamName);
                Assert.AreEqual("Value cannot be null. (Parameter 'b')", exception.Message);
                Assert.IsNull(exception.InnerException);
            }

            a.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsWhenAContainsUninitialized()
        {
            var unchangedIdentifier = Guid.NewGuid();
            var changedIdentifier = Guid.NewGuid();
            var addedIdentifier = Guid.NewGuid();
            var removedIdentifier = Guid.NewGuid();
            var tagStoreComparer = new TagStoreComparer();
            var a = new Mock<ITagStore>();
            var aEnumerable = new Mock<IEnumerable<TagMapping>>();
            var aEnumerator = new Mock<IEnumerator<TagMapping>>();
            a.SetupGet(store => store.MappedIdentifiers).Returns(aEnumerable.Object);
            aEnumerable.Setup(enumerable => enumerable.GetEnumerator()).Returns(aEnumerator.Object);
            aEnumerator.SetupGet(enumerator => enumerator.Current).Throws(new AssertFailedException("aEnumerator.Current accessed before calling aEnumerator.MoveNext."));
            aEnumerator.Setup(enumerator => enumerator.Dispose()).Throws(new AssertFailedException("aEnumerator.Dispose called before end of collection."));
            aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
            {
                aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(unchangedIdentifier, "Test Unchanged Tag"));
                aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                {
                    aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(default(TagMapping));
                    aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                    {
                        aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(removedIdentifier, "Test Removed Tag"));
                        aEnumerator
                            .Setup(enumerator => enumerator.MoveNext())
                            .Callback(() =>
                            {
                                aEnumerator.Setup(enumerator => enumerator.Dispose()).Callback(() => { });
                            })
                            .Returns(false);
                    })
                    .Returns(true);
                }).Returns(true);
            }).Returns(true);
            var b = new Mock<ITagStore>();
            var bEnumerable = new Mock<IEnumerable<TagMapping>>();
            var bEnumerator = new Mock<IEnumerator<TagMapping>>();
            b.SetupGet(store => store.MappedIdentifiers).Returns(bEnumerable.Object);
            bEnumerable.Setup(enumerable => enumerable.GetEnumerator()).Returns(bEnumerator.Object);
            bEnumerator.SetupGet(enumerator => enumerator.Current).Throws(new AssertFailedException("bEnumerator.Current accessed before calling bEnumerator.MoveNext."));
            bEnumerator.Setup(enumerator => enumerator.Dispose()).Throws(new AssertFailedException("bEnumerator.Dispose called before end of collection."));
            bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
            {
                bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(addedIdentifier, "Test Added Tag"));
                bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                {
                    bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(unchangedIdentifier, "Test Unchanged Tag"));
                    bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                    {
                        bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(changedIdentifier, "Test Changed Tag B"));
                        bEnumerator
                            .Setup(enumerator => enumerator.MoveNext())
                            .Callback(() =>
                            {
                                bEnumerator.Setup(enumerator => enumerator.Dispose()).Callback(() => { });
                            })
                            .Returns(false);
                    })
                    .Returns(true);
                }).Returns(true);
            }).Returns(true);

            try
            {
                _ = tagStoreComparer.Compare(a.Object, b.Object);
                Assert.Fail();
            }
            catch (InvalidOperationException exception)
            {
                Assert.AreEqual("TagMapping uninitialized.", exception.Message);
                Assert.IsNull(exception.InnerException);
            }

            a.VerifyGet(store => store.MappedIdentifiers, Times.AtMostOnce);
            aEnumerable.Verify(enumerable => enumerable.GetEnumerator(), Times.AtMostOnce);
            aEnumerator.Verify(enumerable => enumerable.MoveNext(), Times.AtMost(4));
            aEnumerator.VerifyGet(enumerable => enumerable.Current, Times.AtMost(3));
            if (aEnumerable.Invocations.Any())
            {
                aEnumerator.Verify(enumerable => enumerable.Dispose(), Times.Once);
            }
            b.VerifyGet(store => store.MappedIdentifiers, Times.AtMostOnce);
            bEnumerable.Verify(enumerable => enumerable.GetEnumerator(), Times.AtMostOnce);
            bEnumerator.Verify(enumerable => enumerable.MoveNext(), Times.AtMost(4));
            bEnumerator.VerifyGet(enumerable => enumerable.Current, Times.AtMost(3));
            if (bEnumerable.Invocations.Any())
            {
                bEnumerator.Verify(enumerable => enumerable.Dispose(), Times.Once);
            }
            a.VerifyNoOtherCalls();
            aEnumerable.VerifyNoOtherCalls();
            aEnumerator.VerifyNoOtherCalls();
            b.VerifyNoOtherCalls();
            bEnumerable.VerifyNoOtherCalls();
            bEnumerator.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ThrowsWhenBContainsUninitialized()
        {
            var unchangedIdentifier = Guid.NewGuid();
            var changedIdentifier = Guid.NewGuid();
            var addedIdentifier = Guid.NewGuid();
            var removedIdentifier = Guid.NewGuid();
            var tagStoreComparer = new TagStoreComparer();
            var a = new Mock<ITagStore>();
            var aEnumerable = new Mock<IEnumerable<TagMapping>>();
            var aEnumerator = new Mock<IEnumerator<TagMapping>>();
            a.SetupGet(store => store.MappedIdentifiers).Returns(aEnumerable.Object);
            aEnumerable.Setup(enumerable => enumerable.GetEnumerator()).Returns(aEnumerator.Object);
            aEnumerator.SetupGet(enumerator => enumerator.Current).Throws(new AssertFailedException("aEnumerator.Current accessed before calling aEnumerator.MoveNext."));
            aEnumerator.Setup(enumerator => enumerator.Dispose()).Throws(new AssertFailedException("aEnumerator.Dispose called before end of collection."));
            aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
            {
                aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(unchangedIdentifier, "Test Unchanged Tag"));
                aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                {
                    aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(changedIdentifier, "Test Changed Tag A"));
                    aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                    {
                        aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(removedIdentifier, "Test Removed Tag"));
                        aEnumerator
                            .Setup(enumerator => enumerator.MoveNext())
                            .Callback(() =>
                            {
                                aEnumerator.Setup(enumerator => enumerator.Dispose()).Callback(() => { });
                            })
                            .Returns(false);
                    })
                    .Returns(true);
                }).Returns(true);
            }).Returns(true);
            var b = new Mock<ITagStore>();
            var bEnumerable = new Mock<IEnumerable<TagMapping>>();
            var bEnumerator = new Mock<IEnumerator<TagMapping>>();
            b.SetupGet(store => store.MappedIdentifiers).Returns(bEnumerable.Object);
            bEnumerable.Setup(enumerable => enumerable.GetEnumerator()).Returns(bEnumerator.Object);
            bEnumerator.SetupGet(enumerator => enumerator.Current).Throws(new AssertFailedException("bEnumerator.Current accessed before calling bEnumerator.MoveNext."));
            bEnumerator.Setup(enumerator => enumerator.Dispose()).Throws(new AssertFailedException("bEnumerator.Dispose called before end of collection."));
            bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
            {
                bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(addedIdentifier, "Test Added Tag"));
                bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                {
                    bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(default(TagMapping));
                    bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                    {
                        bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(changedIdentifier, "Test Changed Tag B"));
                        bEnumerator
                            .Setup(enumerator => enumerator.MoveNext())
                            .Callback(() =>
                            {
                                bEnumerator.Setup(enumerator => enumerator.Dispose()).Callback(() => { });
                            })
                            .Returns(false);
                    })
                    .Returns(true);
                }).Returns(true);
            }).Returns(true);

            try
            {
                _ = tagStoreComparer.Compare(a.Object, b.Object);
                Assert.Fail();
            }
            catch (InvalidOperationException exception)
            {
                Assert.AreEqual("TagMapping uninitialized.", exception.Message);
                Assert.IsNull(exception.InnerException);
            }

            a.VerifyGet(store => store.MappedIdentifiers, Times.AtMostOnce);
            aEnumerable.Verify(enumerable => enumerable.GetEnumerator(), Times.AtMostOnce);
            aEnumerator.Verify(enumerable => enumerable.MoveNext(), Times.AtMost(4));
            aEnumerator.VerifyGet(enumerable => enumerable.Current, Times.AtMost(3));
            if (aEnumerable.Invocations.Any())
            {
                aEnumerator.Verify(enumerable => enumerable.Dispose(), Times.Once);
            }
            b.VerifyGet(store => store.MappedIdentifiers, Times.AtMostOnce);
            bEnumerable.Verify(enumerable => enumerable.GetEnumerator(), Times.AtMostOnce);
            bEnumerator.Verify(enumerable => enumerable.MoveNext(), Times.AtMost(4));
            bEnumerator.VerifyGet(enumerable => enumerable.Current, Times.AtMost(3));
            if (bEnumerable.Invocations.Any())
            {
                bEnumerator.Verify(enumerable => enumerable.Dispose(), Times.Once);
            }
            a.VerifyNoOtherCalls();
            aEnumerable.VerifyNoOtherCalls();
            aEnumerator.VerifyNoOtherCalls();
            b.VerifyNoOtherCalls();
            bEnumerable.VerifyNoOtherCalls();
            bEnumerator.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void GeneratesDiff()
        {
            var unchangedIdentifier = Guid.NewGuid();
            var changedIdentifier = Guid.NewGuid();
            var addedIdentifier = Guid.NewGuid();
            var removedIdentifier = Guid.NewGuid();
            var tagStoreComparer = new TagStoreComparer();
            var a = new Mock<ITagStore>();
            var aEnumerable = new Mock<IEnumerable<TagMapping>>();
            var aEnumerator = new Mock<IEnumerator<TagMapping>>();
            a.SetupGet(store => store.MappedIdentifiers).Returns(aEnumerable.Object);
            aEnumerable.Setup(enumerable => enumerable.GetEnumerator()).Returns(aEnumerator.Object);
            aEnumerator.SetupGet(enumerator => enumerator.Current).Throws(new AssertFailedException("aEnumerator.Current accessed before calling aEnumerator.MoveNext."));
            aEnumerator.Setup(enumerator => enumerator.Dispose()).Throws(new AssertFailedException("aEnumerator.Dispose called before end of collection."));
            aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
            {
                aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(unchangedIdentifier, "Test Unchanged Tag"));
                aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                {
                    aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(changedIdentifier, "Test Changed Tag A"));
                    aEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                    {
                        aEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(removedIdentifier, "Test Removed Tag"));
                        aEnumerator
                            .Setup(enumerator => enumerator.MoveNext())
                            .Callback(() =>
                            {
                                aEnumerator.Setup(enumerator => enumerator.Dispose()).Callback(() => { });
                            })
                            .Returns(false);
                    })
                    .Returns(true);
                }).Returns(true);
            }).Returns(true);
            var b = new Mock<ITagStore>();
            var bEnumerable = new Mock<IEnumerable<TagMapping>>();
            var bEnumerator = new Mock<IEnumerator<TagMapping>>();
            b.SetupGet(store => store.MappedIdentifiers).Returns(bEnumerable.Object);
            bEnumerable.Setup(enumerable => enumerable.GetEnumerator()).Returns(bEnumerator.Object);
            bEnumerator.SetupGet(enumerator => enumerator.Current).Throws(new AssertFailedException("bEnumerator.Current accessed before calling bEnumerator.MoveNext."));
            bEnumerator.Setup(enumerator => enumerator.Dispose()).Throws(new AssertFailedException("bEnumerator.Dispose called before end of collection."));
            bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
            {
                bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(addedIdentifier, "Test Added Tag"));
                bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                {
                    bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(unchangedIdentifier, "Test Unchanged Tag"));
                    bEnumerator.Setup(enumerator => enumerator.MoveNext()).Callback(() =>
                    {
                        bEnumerator.SetupGet(enumerator => enumerator.Current).Returns(new TagMapping(changedIdentifier, "Test Changed Tag B"));
                        bEnumerator
                            .Setup(enumerator => enumerator.MoveNext())
                            .Callback(() =>
                            {
                                bEnumerator.Setup(enumerator => enumerator.Dispose()).Callback(() => { });
                            })
                            .Returns(false);
                    })
                    .Returns(true);
                }).Returns(true);
            }).Returns(true);

            var diff = tagStoreComparer.Compare(a.Object, b.Object);

            CollectionAssert.AreEquivalent
            (
                new[] 
                {
                    new KeyValuePair<Guid, string>(addedIdentifier, "Test Added Tag"),
                    new KeyValuePair<Guid, string>(changedIdentifier, "Test Changed Tag B"),
                }, 
                diff.Set,
                string.Join(", ", diff.Set.Select(item => $"{item.Key}: {item.Value}"))
            );
            CollectionAssert.AreEquivalent(new[] { removedIdentifier }, diff.Deleted);
            a.VerifyGet(store => store.MappedIdentifiers, Times.Once);
            aEnumerable.Verify(enumerable => enumerable.GetEnumerator(), Times.Once);
            aEnumerator.Verify(enumerable => enumerable.MoveNext(), Times.Exactly(4));
            aEnumerator.VerifyGet(enumerable => enumerable.Current, Times.Exactly(3));
            aEnumerator.Verify(enumerable => enumerable.Dispose(), Times.Once);
            b.VerifyGet(store => store.MappedIdentifiers, Times.Once);
            bEnumerable.Verify(enumerable => enumerable.GetEnumerator(), Times.Once);
            bEnumerator.Verify(enumerable => enumerable.MoveNext(), Times.Exactly(4));
            bEnumerator.VerifyGet(enumerable => enumerable.Current, Times.Exactly(3));
            bEnumerator.Verify(enumerable => enumerable.Dispose(), Times.Once);
            a.VerifyNoOtherCalls();
            aEnumerable.VerifyNoOtherCalls();
            aEnumerator.VerifyNoOtherCalls();
            b.VerifyNoOtherCalls();
            bEnumerable.VerifyNoOtherCalls();
            bEnumerator.VerifyNoOtherCalls();
        }
    }
}
