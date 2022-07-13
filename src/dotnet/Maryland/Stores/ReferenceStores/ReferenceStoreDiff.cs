using System.Collections.Immutable;

namespace Maryland.Stores.ReferenceStores
{
    /// <summary>
    /// A description of the differences between two <see cref="IReferenceStore"/>s.
    /// </summary>
    public sealed class ReferenceStoreDiff
    {
        /// <summary>
        /// The references which were set (either created or changed) between the two <see cref="IReferenceStore"/>s.
        /// </summary>
        public readonly ImmutableDictionary<EntityAttributeIdentifierPair, Guid> Set;

        /// <summary>
        /// The references which were deleted between the two <see cref="IReferenceStore"/>s.
        /// </summary>
        public readonly ImmutableHashSet<EntityAttributeIdentifierPair> Deleted;

        /// <summary>
        /// Creates a new description of differences between two <see cref="IReferenceStore"/>s.
        /// </summary>
        /// <param name="set">The references which were set (either created or changed) between the two <see cref="IReferenceStore"/>s.</param>
        /// <param name="deleted">The references which were deleted between the two <see cref="IReferenceStore"/>s.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="set"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="deleted"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="set"/> and <paramref name="deleted"/> include the same entity/attribute identifier pair.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="set"/> maps entity/attribute identifier pairs to <see cref="Guid.Empty"/>.</exception>
        public ReferenceStoreDiff(ImmutableDictionary<EntityAttributeIdentifierPair, Guid> set, ImmutableHashSet<EntityAttributeIdentifierPair> deleted)
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
                throw new ArgumentException("Cannot set and delete a mapping from the same entity/attribute identifier pair in the same ReferenceStoreDiff.");
            }
            else if (set.Values.Any(value => value == Guid.Empty))
            {
                throw new ArgumentNullException(nameof(set), "Value identifiers cannot be zero.");
            }
            else
            {
                Set = set;
                Deleted = deleted;
            }
        }
    }
}
