using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;

namespace Maryland.Stores
{
    /// <summary>
    /// Deserializes <see cref="StoreDiff"/>s fromsee cref="byte"/> streams.
    /// </summary>
    public sealed class StoreDiffDeserializer : IStoreDiffDeserializer
    {
        /// <summary>
        /// The helper used to deserialize <see cref="ReferenceStoreDiff"/>s of <see cref="StoreDiff"/>s from <see cref="byte"/> streams.
        /// </summary>
        public readonly IReferenceStoreDiffDeserializer ReferenceStoreDiffDeserializer;

        /// <summary>
        /// The helper used to deserialize <see cref="TagStoreDiff"/>s of <see cref="StoreDiff"/>s from <see cref="byte"/> streams.
        /// </summary>
        public readonly ITagStoreDiffDeserializer TagStoreDiffDeserializer;

        /// <summary>
        /// Creates a new helper which deserializes <see cref="StoreDiff"/>s from <see cref="byte"/> streams.
        /// </summary>
        /// <param name="referenceStoreDiffDeserializer">The helper used to serialize <see cref="ReferenceStoreDiff"/>s of <see cref="StoreDiff"/>s to <see cref="byte"/> streams.</param>
        /// <param name="tagStoreDiffDeserializer">The helper used to deserialize <see cref="TagStoreDiff"/>s of <see cref="StoreDiff"/>s from <see cref="byte"/> streams.</param>
        public StoreDiffDeserializer(IReferenceStoreDiffDeserializer referenceStoreDiffDeserializer, ITagStoreDiffDeserializer tagStoreDiffDeserializer)
        {
            if (referenceStoreDiffDeserializer == null)
            {
                throw new ArgumentNullException(nameof(referenceStoreDiffDeserializer));
            }
            else if (tagStoreDiffDeserializer == null)
            {
                throw new ArgumentNullException(nameof(tagStoreDiffDeserializer));
            }
            else
            {
                ReferenceStoreDiffDeserializer = referenceStoreDiffDeserializer;
                TagStoreDiffDeserializer = tagStoreDiffDeserializer;
            }
        }

        /// <inheritdoc />
        public async Task<StoreDiff> Deserialize(IAsyncEnumerator<byte> bytes)
        {
            var referenceStoreDiff = await ReferenceStoreDiffDeserializer.Deserialize(bytes);
            var tagStoreDiff = await TagStoreDiffDeserializer.Deserialize(bytes);

            return new StoreDiff(referenceStoreDiff, tagStoreDiff);
        }
    }
}
