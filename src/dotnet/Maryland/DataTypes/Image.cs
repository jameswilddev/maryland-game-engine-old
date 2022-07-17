using Maryland.PatchInstructions;
using System.Collections.Immutable;

namespace Maryland.DataTypes
{
    /// <summary>
    /// A 32-bits-per-pixel image.
    /// </summary>
    public sealed class Image
    {
        /// <summary>
        /// The number of columns within the image.
        /// </summary>
        public byte Columns;

        /// <summary>
        /// The row-major pixels within the image, starting in the top left corner.
        /// </summary>
        public readonly ImmutableArray<ColorWithOpacity> Pixels;

        /// <summary>
        /// The number of rows within the image.
        /// </summary>
        public byte Rows => (byte)(Pixels.Length / Columns);

        /// <summary>
        /// Creates a new 32-bits-per-pixel image.
        /// </summary>
        /// <param name="columns">The number of columns within the image.</param>
        /// <param name="pixels">The column-order pixels within the image, starting in the top left corner.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="columns"/> is not a factor of <paramref name="pixels"/>.<see cref="ImmutableArray{ColorWithOpacity}.Length"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="pixels"/> is uninitialized or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pixels"/> contains more than 255 rows.</exception>
        public Image(byte columns, ImmutableArray<ColorWithOpacity> pixels)
        {
            if (pixels.IsDefaultOrEmpty)
            {
                throw new ArgumentNullException(nameof(pixels), "Value must be initialized and non-empty.");
            }
            else if (columns < 1 || columns > pixels.Length || pixels.Length % columns != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columns), "Must be a factor of the number of pixels.");
            }
            else if (pixels.Length / columns > byte.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(pixels), "Contains more than 255 rows.");
            }
            else
            {
                Columns = columns;
                Pixels = pixels;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is Image image)
            {
                return image.Columns == Columns && image.Pixels.SequenceEqual(Pixels);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var output = Columns.GetHashCode();

            foreach (var pixel in Pixels)
            {
                output = HashCode.Combine(output, pixel);
            }

            return output;
        }
    }
}
