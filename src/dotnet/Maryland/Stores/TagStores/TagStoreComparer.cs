using System.Collections.Immutable;

namespace Maryland.Stores.TagStores
{
    /// <summary>
    /// Generates <see cref="TagStoreDiff"/>s from pairs of <see cref="ITagStore"/>s.
    /// </summary>
    public sealed class TagStoreComparer : ITagStoreComparer
    {
        /// <inheritdoc />
        public TagStoreDiff Compare(ITagStore a, ITagStore b)
        {
            ArgumentNullException.ThrowIfNull(a, nameof(a));
            ArgumentNullException.ThrowIfNull(b, nameof(b));

            var rawFromA = a.MappedIdentifiers.ToArray();
            
            foreach (var item in rawFromA)
            {
                item.ThrowIfUninitialized();
            }

            var fromA = rawFromA.ToDictionary(kv => kv.Identifier, kv => kv.Tag);

            var rawFromB = b.MappedIdentifiers.ToArray();

            foreach (var item in rawFromB)
            {
                item.ThrowIfUninitialized();
            }

            var fromB = rawFromB.ToDictionary(kv => kv.Identifier, kv => kv.Tag);

            var set = ImmutableDictionary<Guid, string>.Empty;

            foreach (var identifierTag in fromB)
            {
                if (!fromA.TryGetValue(identifierTag.Key, out var otherTag) || identifierTag.Value != otherTag)
                {
                    set = set.Add(identifierTag.Key, identifierTag.Value);
                }
            }

            var deleted = ImmutableHashSet<Guid>.Empty;

            foreach (var identifier in fromA.Keys)
            {
                if (!fromB.ContainsKey(identifier))
                {
                    deleted = deleted.Add(identifier);
                }
            }

            return new TagStoreDiff(set, deleted);
        }
    }
}
