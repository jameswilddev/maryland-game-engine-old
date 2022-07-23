using System.Collections.Immutable;
using System.Numerics;

namespace Maryland.DataTypes
{
    /// <summary>
    /// Deserializes <see cref="Image"/>es from <see cref="byte"/> streams.
    /// </summary>
    public sealed class ImageDeserializer : IImageDeserializer
    {
        /// <inheritdoc />
        public async ValueTask<Image> Deserialize(IAsyncEnumerable<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            else
            {
                var enumerator = bytes.GetAsyncEnumerator();

                var image = await Deserialize(enumerator);

                if (await enumerator.MoveNextAsync())
                {
                    throw new InvalidDataException("Unexpected bytes following image.");
                }
                else
                {
                    return image;
                }
            }
        }

        internal static async ValueTask<Image> Deserialize(IAsyncEnumerator<byte> bytes)
        {
            var numberOfColumns = await Maryland.Deserialize.Byte(bytes, "Unexpected EOF during number of columns in image.");

            if (numberOfColumns == 0)
            {
                throw new InvalidDataException("Image has no columns.");
            }

            var numberOfRows = await Maryland.Deserialize.Byte(bytes, "Unexpected EOF during number of rows in image.");

            if (numberOfRows == 0)
            {
                throw new InvalidDataException("Image has no rows.");
            }

            var pixels = await Maryland.Deserialize.ColorsWithOpacity(bytes, numberOfColumns * numberOfRows, "Unexpected EOF during pixels in image.");

            return new Image(numberOfColumns, pixels);
        }
    }
}
