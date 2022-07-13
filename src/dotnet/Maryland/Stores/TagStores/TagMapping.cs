using System.Text;

namespace Maryland.Stores.TagStores
{
    /// <summary>
    /// Describes a mapping from an identifier to a tag.
    /// </summary>
    public struct TagMapping
    {
        /// <summary>
        /// The identifier mapped from.
        /// </summary>
        public readonly Guid Identifier;

        /// <summary>
        /// The tag mapped to.
        /// </summary>
        public readonly string Tag;

        /// <summary>
        /// Creates a new mapping from an identifier to a tag.
        /// </summary>
        /// <param name="identifier">The identifier to map from.</param>
        /// <param name="tag">The tag to map to.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="tag"/> is <see langword="null"/>, <see cref="string.Empty"/> or white space.</exception>
        public TagMapping(Guid identifier, string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag), "Value cannot be null, empty or white space.");
            }
            else if (Encoding.UTF8.GetByteCount(tag) > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(tag), "Tag names cannot exceed 255 bytes in length when encoded as UTF-8.");
            }
            else
            {
                Identifier = identifier;
                Tag = tag;
            }
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> should <see langword="this"/> <see cref="TagMapping"/> be uninitialized.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when <see langword="this"/> <see cref="TagMapping"/> is uninitialized.</exception>
        public void ThrowIfUninitialized()
        {
            if (Tag == null)
            {
                throw new InvalidOperationException("TagMapping uninitialized.");
            }
        }
    }
}
