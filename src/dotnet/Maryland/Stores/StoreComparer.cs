using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;

namespace Maryland.Stores
{
    /// <summary>
    /// Generates <see cref="StoreDiff"/>s from pairs of <see cref="Store"/>s.
    /// </summary>
    public sealed class StoreComparer : IStoreComparer
    {
        /// <summary>
        /// The helper used to compare the <see cref="IReferenceStore"/>s of the pair of <see cref="Store"/>s.
        /// </summary>
        public readonly IReferenceStoreComparer ReferenceStoreComparer;

        /// <summary>
        /// The helper used to compare the <see cref="ITagStore"/>s of the pair of <see cref="Store"/>s.
        /// </summary>
        public readonly ITagStoreComparer TagStoreComparer;

        /// <summary>
        /// Creates a new helper which generates <see cref="StoreDiff"/>s from pairs of <see cref="Store"/>s.
        /// </summary>
        /// <param name="referenceStoreComparer">The helper used to compare the <see cref="IReferenceStore"/>s of the pair of <see cref="Store"/>s.</param>
        /// <param name="tagStoreComparer">The helper used to compare the <see cref="ITagStore"/>s of the pair of <see cref="Store"/>s.</param>
        public StoreComparer(IReferenceStoreComparer referenceStoreComparer, ITagStoreComparer tagStoreComparer)
        {
            if (referenceStoreComparer == null)
            {
                throw new ArgumentNullException(nameof(referenceStoreComparer));
            }
            else if (tagStoreComparer == null)
            {
                throw new ArgumentNullException(nameof(tagStoreComparer));
            }
            else
            {
                ReferenceStoreComparer = referenceStoreComparer;
                TagStoreComparer = tagStoreComparer;
            }
        }

        /// <inheritdoc />
        public StoreDiff Compare(Store a, Store b) => new StoreDiff(ReferenceStoreComparer.Compare(a.ReferenceStore, b.ReferenceStore), TagStoreComparer.Compare(a.TagStore, b.TagStore));
    }
}
