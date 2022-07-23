using Maryland.DataTypes;
using Moq;
using System.Collections.Immutable;
using System.Numerics;

namespace Maryland.Unit.DataTypes
{
    [TestClass]
    public sealed class ImageDeserializerTests
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private static async IAsyncEnumerable<byte> ByteSequence(params IEnumerable<byte>[] bytes)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            foreach (var set in bytes)
            {
                foreach (var b in set)
                {
                    yield return b;
                }
            }
        }

        private static async ValueTask Valid(Image image, params IEnumerable<byte>[] bytes)
        {
            var enumerable = new Mock<IAsyncEnumerable<byte>>();
            var enumerator = ByteSequence(bytes).GetAsyncEnumerator();
            enumerable.Setup(e => e.GetAsyncEnumerator(default)).Returns(enumerator);
            var imageDeserializer = new ImageDeserializer();

            var actual = await imageDeserializer.Deserialize(enumerable.Object);

            Assert.AreEqual(image, actual);
            enumerable.Verify(e => e.GetAsyncEnumerator(default), Times.Once);
            enumerable.VerifyNoOtherCalls();
        }

        private static async ValueTask Invalid(string message, params IEnumerable<byte>[] bytes)
        {
            var enumerable = new Mock<IAsyncEnumerable<byte>>();
            var enumerator = ByteSequence(bytes).GetAsyncEnumerator();
            enumerable.Setup(e => e.GetAsyncEnumerator(default)).Returns(enumerator);
            var imageDeserializer = new ImageDeserializer();

            try
            {
                _ = await imageDeserializer.Deserialize(enumerable.Object);
                Assert.Fail();
            }
            catch (InvalidDataException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual(message, exception.Message);
            }

            enumerable.Verify(e => e.GetAsyncEnumerator(default), Times.Once);
            enumerable.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenBytesNull()
        {
            var imageDeserializer = new ImageDeserializer();

            try
            {
                await imageDeserializer.Deserialize(null!);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null. (Parameter 'bytes')", exception.Message);
                Assert.AreEqual("bytes", exception.ParamName);
            }
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenBytesEmpty()
        {
            await Invalid("Unexpected EOF during number of columns in image.");
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenNoColumns()
        {
            await Invalid(
                "Image has no columns.",
                new byte[]
                {
                    0,
                    37,
                }
            );
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenNumberOfRowsInterrupted()
        {
            await Invalid(
                "Unexpected EOF during number of rows in image.",
                new byte[]
                {
                    37,
                }
            );
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenNoRows()
        {
            await Invalid(
                "Image has no rows.",
                new byte[]
                {
                    37,
                    0,
                }
            );
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenPixelsInterrupted()
        {
            await Invalid(
                "Unexpected EOF during pixels in image.",
                new byte[]
                {
                    37,
                    12,
                    0xc6, 0xc9, 0xf7, 0x27, 0x56, 0xa0, 0xdc, 0x70, 0xf5, 0x09, 0x13, 0xaf, 0x32, 0x1a, 0x7b,
                }
            );
        }

        [TestMethod]
        public async Task ValidMinimum()
        {
            await Valid(
                new Image(1, ImmutableArray.Create(new ColorWithOpacity(0xc6, 0xc9, 0xf7, 0x27))),
                new byte[]
                {
                    1,
                    1,
                    0xc6, 0xc9, 0xf7, 0x27,
                }
            );
        }

        [TestMethod]
        public async Task Valid()
        {
            await Valid(
                new Image
                (
                    3, 
                    ImmutableArray.Create
                    (
                        new ColorWithOpacity(0xc6, 0xc9, 0xf7, 0x27),
                        new ColorWithOpacity(0xd1, 0x33, 0x57, 0xf7),
                        new ColorWithOpacity(0x19, 0x94, 0x58, 0xc1),
                        new ColorWithOpacity(0x8d, 0xdb, 0x03, 0xa5),
                        new ColorWithOpacity(0xfd, 0x55, 0x94, 0x12),
                        new ColorWithOpacity(0xae, 0x25, 0x13, 0x10),
                        new ColorWithOpacity(0x6c, 0x8d, 0x5e, 0xdc),
                        new ColorWithOpacity(0x86, 0x60, 0x69, 0xd3),
                        new ColorWithOpacity(0x8e, 0x30, 0xf7, 0x12),
                        new ColorWithOpacity(0x13, 0x5e, 0x34, 0x05),
                        new ColorWithOpacity(0x27, 0xad, 0x65, 0x6e),
                        new ColorWithOpacity(0xd2, 0xfe, 0x2f, 0xa9)
                    )
                ),
                new byte[]
                {
                    3,
                    4,
                    0xc6, 0xc9, 0xf7, 0x27,
                    0xd1, 0x33, 0x57, 0xf7,
                    0x19, 0x94, 0x58, 0xc1,
                    0x8d, 0xdb, 0x03, 0xa5,
                    0xfd, 0x55, 0x94, 0x12,
                    0xae, 0x25, 0x13, 0x10,
                    0x6c, 0x8d, 0x5e, 0xdc,
                    0x86, 0x60, 0x69, 0xd3,
                    0x8e, 0x30, 0xf7, 0x12,
                    0x13, 0x5e, 0x34, 0x05,
                    0x27, 0xad, 0x65, 0x6e,
                    0xd2, 0xfe, 0x2f, 0xa9,
                }
            );
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenOneExcessByte()
        {
            await Invalid
            (
                "Unexpected bytes following image.",
                new byte[]
                {
                    1, 1,
                    0x63, 0xb7, 0x81, 0x5c,
                    37,
                }
            );
        }

        [TestMethod]
        public async Task ThrowsExceptionWhenTwoExcessBytes()
        {
            await Invalid
            (
                "Unexpected bytes following image.",
                new byte[]
                {
                    1, 1,
                    0x63, 0xb7, 0x81, 0x5c,
                    37, 150,
                }
            );
        }
    }
}
