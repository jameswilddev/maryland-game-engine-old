using System.Collections.Concurrent;
using System.Text;

namespace Maryland.ReferenceStores
{
    /// <summary>
    /// Maps entity/attribute identifier pairs to value identifiers (themselves references to entities).
    /// </summary>
    public sealed class ReferenceStore : IReferenceStore
    {
        private readonly ConcurrentDictionary<EntityAttributeIdentifierPair, Guid> Items = new();

        /// <inheritdoc />
        public Guid this[EntityAttributeIdentifierPair entityAttributeIdentifierPair]
        {
            get
            {
                Items.TryGetValue(entityAttributeIdentifierPair, out var output);
                return output;
            }

            set
            {
                if (value == Guid.Empty)
                {
                    Items.Remove(entityAttributeIdentifierPair, out _);
                }
                else
                {
                    Items[entityAttributeIdentifierPair] = value;
                }
            }
        }

        /// <inheritdoc />
        public IEnumerable<ReferenceMapping> MappedReferences => Items.Select(item => new ReferenceMapping(item.Key.Entity, item.Key.Attribute, item.Value));
    }
}
