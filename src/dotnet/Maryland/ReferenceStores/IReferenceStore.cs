using System.Collections;

namespace Maryland.ReferenceStores
{
    /// <summary>
    /// Maps entity/attribute identifier pairs to value identifiers (themselves references to entities).
    /// </summary>
    public interface IReferenceStore
    {
        /// <summary>
        /// Gets or sets the value identifier of a specified entity/attribute identifier pair.
        /// </summary>
        /// <remarks>Implementations must be thread-safe; retrieved values may be stale, and writes may be silently discarded if two conflicting writes occur simultaneously.</remarks>
        /// <param name="entityAttributeIdentifierPair">The entity/attribute identifier pair of which to get or set a value identifier.</param>
        /// <returns>When a value identifier exists for the given <paramref name="entityAttributeIdentifierPair"/>, that value identifier, otherwise <see cref="Guid.Empty"/>.</returns>
        Guid this[EntityAttributeIdentifierPair entityAttributeIdentifierPair] { get; set; }

        /// <summary>
        /// Retrieves the entity/attribute identifier pairs which have been mapped, and the value identifiers they have been mapped to.
        /// </summary>
        /// <remarks>Implementations must be thread safe; no exceptions are to be thrown and the result is to be self-consistent if data is changed during iteration, and the result set may be stale before iteration completes.  <see cref="IEnumerator.Reset"/> is unlikely to be supported, and very unlikely to result in the exact same result set more than once.</remarks>
        IEnumerable<ReferenceMapping> MappedReferences { get; }
    }
}
