using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;

namespace Maryland.Stores
{
    /// <summary>
    /// Serializes <see cref="StoreDiff"/>s to <see cref="byte"/> streams.
    /// </summary>
    public sealed class StoreDiffSerializer : IStoreDiffSerializer
    {
        /// <summary>
        /// The helper used to serialize <see cref="ReferenceStoreDiff"/>s of <see cref="StoreDiff"/>s to <see cref="byte"/> streams.
        /// </summary>
        public readonly IReferenceStoreDiffSerializer ReferenceStoreDiffSerializer;

        /// <summary>
        /// The helper used to serialize <see cref="TagStoreDiff"/>s of <see cref="StoreDiff"/>s to <see cref="byte"/> streams.
        /// </summary>
        public readonly ITagStoreDiffSerializer TagStoreDiffSerializer;

        /// <summary>
        /// Creates a new helper which serializes <see cref="StoreDiff"/>s to <see cref="byte"/> streams.
        /// </summary>
        /// <param name="referenceStoreDiffSerializer">The helper used to serialize <see cref="ReferenceStoreDiff"/>s of <see cref="StoreDiff"/>s to <see cref="byte"/> streams.</param>
        /// <param name="tagStoreDiffSerializer">The helper used to serialize <see cref="TagStoreDiff"/>s of <see cref="StoreDiff"/>s to <see cref="byte"/> streams.</param>
        public StoreDiffSerializer(IReferenceStoreDiffSerializer referenceStoreDiffSerializer, ITagStoreDiffSerializer tagStoreDiffSerializer)
        {
            if (referenceStoreDiffSerializer == null)
            {
                throw new ArgumentNullException(nameof(referenceStoreDiffSerializer));
            }
            else if (tagStoreDiffSerializer == null)
            {
                throw new ArgumentNullException(nameof(tagStoreDiffSerializer));
            }
            else
            {
                ReferenceStoreDiffSerializer = referenceStoreDiffSerializer;
                TagStoreDiffSerializer = tagStoreDiffSerializer;
            }
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialize(StoreDiff storeDiff)
        {
            return ReferenceStoreDiffSerializer
                .Serialize(storeDiff.ReferenceStoreDiff)
                .Concat(TagStoreDiffSerializer.Serialize(storeDiff.TagStoreDiff));
        }
    }
}
