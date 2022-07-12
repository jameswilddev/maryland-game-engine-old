using System.Collections;

namespace Maryland.TagStores
{
    /// <summary>
    /// Maps identifiers to string tags.
    /// </summary>
    public interface ITagStore
    {
        /// <summary>
        /// Gets or sets the tag of a specified identifier.
        /// </summary>
        /// <remarks>Implementations must be thread-safe; retrieved values may be stale, and writes may be silently discarded if two conflicting writes occur simultaneously.</remarks>
        /// <param name="identifier">The identifier of which to get or set a tag.</param>
        /// <returns>When a tag exists for the given <paramref name="identifier"/>, that tag, otherwise <see langword="null"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the given tag is empty or white space; note that <see langword="null"/> is acceptable to delete a mapping.</exception>
        string? this[Guid identifier] { get; set; }

        /// <summary>
        /// Retrieves the identifiers which have been mapped, and the tags they have been mapped to.
        /// </summary>
        /// <remarks>Implementations must be thread safe; no exceptions are to be thrown and the result is to be self-consistent if data is changed during iteration, and the result set may be stale before iteration completes.  <see cref="IEnumerator.Reset"/> is unlikely to be supported, and very unlikely to result in the exact same result set more than once.</remarks>
        IEnumerable<TagMapping> MappedIdentifiers { get; }
    }
}
