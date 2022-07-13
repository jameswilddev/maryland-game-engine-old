using System.Collections.Immutable;

namespace Maryland.Stores.ReferenceStores
{
    /// <summary>
    /// Generates <see cref="ReferenceStoreDiff"/>s from pairs of <see cref="IReferenceStore"/>s.
    /// </summary>
    public sealed class ReferenceStoreComparer : IReferenceStoreComparer
    {
        /// <inheritdoc />
        public ReferenceStoreDiff Compare(IReferenceStore a, IReferenceStore b)
        {
            ArgumentNullException.ThrowIfNull(a, nameof(a));
            ArgumentNullException.ThrowIfNull(b, nameof(b));

            var rawFromA = a.MappedReferences.ToArray();
            
            foreach (var item in rawFromA)
            {
                item.ThrowIfUninitialized();
            }

            var fromA = rawFromA.ToDictionary(m => new EntityAttributeIdentifierPair(m.Entity, m.Attribute), m => m.Value);

            var rawFromB = b.MappedReferences.ToArray();

            foreach (var item in rawFromB)
            {
                item.ThrowIfUninitialized();
            }

            var fromB = rawFromB.ToDictionary(m => new EntityAttributeIdentifierPair(m.Entity, m.Attribute), m => m.Value);

            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty;

            foreach (var identifierTag in fromB)
            {
                if (!fromA.TryGetValue(identifierTag.Key, out var otherTag) || identifierTag.Value != otherTag)
                {
                    set = set.Add(identifierTag.Key, identifierTag.Value);
                }
            }

            var deleted = ImmutableHashSet<EntityAttributeIdentifierPair>.Empty;

            foreach (var identifier in fromA.Keys)
            {
                if (!fromB.ContainsKey(identifier))
                {
                    deleted = deleted.Add(identifier);
                }
            }

            return new ReferenceStoreDiff(set, deleted);
        }
    }
}
