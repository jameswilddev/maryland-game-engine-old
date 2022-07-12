using System.Collections.Concurrent;
using System.Text;

namespace Maryland.TagStores
{
    /// <summary>
    /// Maps identifiers to string tags.
    /// </summary>
    public sealed class TagStore : ITagStore
    {
        private readonly ConcurrentDictionary<Guid, string> Items = new();

        /// <inheritdoc />
        public string? this[Guid identifier]
        {
            get
            {
                Items.TryGetValue(identifier, out string? output);
                return output;
            }

            set
            {
                if (value == null)
                {
                    Items.Remove(identifier, out _);
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Tags cannot be empty or white space; use null to delete them.");
                }
                else if (Encoding.UTF8.GetByteCount(value) > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Tag names cannot exceed 255 bytes in length when encoded as UTF-8.");
                }
                else
                {
                    Items[identifier] = value;
                }
            }
        }

        /// <inheritdoc />
        public IEnumerable<TagMapping> MappedIdentifiers => Items.Select(item => new TagMapping(item.Key, item.Value));
    }
}
