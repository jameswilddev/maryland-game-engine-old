using System.Collections.Immutable;
using System.Text;

namespace Maryland.Stores.TagStores
{
    /// <summary>
    /// A description of the differences between two <see cref="ITagStore"/>s.
    /// </summary>
    public sealed class TagStoreDiff
    {
        /// <summary>
        /// The tags which were set (either created or changed) between the two <see cref="ITagStore"/>s.
        /// </summary>
        public readonly ImmutableDictionary<Guid, string> Set;

        /// <summary>
        /// The tags which were deleted between the two <see cref="ITagStore"/>s.
        /// </summary>
        public readonly ImmutableHashSet<Guid> Deleted;

        /// <summary>
        /// Creates a new description of differences between two <see cref="ITagStore"/>s.
        /// </summary>
        /// <param name="set">The tags which were set (either created or changed) between the two <see cref="ITagStore"/>s.</param>
        /// <param name="deleted">The tags which were deleted between the two <see cref="ITagStore"/>s.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="set"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="deleted"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="set"/> and <paramref name="deleted"/> include the same identifier.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="set"/> maps identifiers to <see langword="null"/>, <see cref="string.Empty"/> or white space.</exception>
        public TagStoreDiff(ImmutableDictionary<Guid, string> set, ImmutableHashSet<Guid> deleted)
        {
            if (set == null)
            {
                throw new ArgumentNullException(nameof(set));
            }
            else if (deleted == null)
            {
                throw new ArgumentNullException(nameof(deleted));
            }
            else if (set.Keys.Any(key => deleted.Contains(key)))
            {
                throw new ArgumentException("Cannot set and delete a mapping from the same identifier in the same TagStoreDiff.");
            }
            else if (set.Values.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentNullException(nameof(set), "Tag names cannot be null, empty or white space.");
            }
            else if (set.Values.Any(tag => Encoding.UTF8.GetByteCount(tag) > 255))
            {
                throw new ArgumentOutOfRangeException(nameof(set), "Tag names cannot exceed 255 bytes in length when encoded as UTF-8.");
            }
            else
            {
                Set = set;
                Deleted = deleted;
            }
        }
    }
}
