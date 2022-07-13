using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;

namespace Maryland.Stores
{
    /// <summary>
    /// A collection of stores describing a running application.
    /// </summary>
    public sealed class Store
    {
        /// <summary>
        /// The references within the store.
        /// </summary>
        public readonly IReferenceStore ReferenceStore;

        /// <summary>
        /// The tags within the store.
        /// </summary>
        public readonly ITagStore TagStore;

        /// <summary>
        /// Creates a new collection of stores describing a running application.
        /// </summary>
        /// <param name="referenceStore">The references within the store.</param>
        /// <param name="tagStore">The tags within the store.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="referenceStore"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="tagStore"/> is <see langword="null"/>.</exception>
        public Store(IReferenceStore referenceStore, ITagStore tagStore)        {
            if (referenceStore == null)
            {
                throw new ArgumentNullException(nameof(referenceStore));
            }
            else if (tagStore == null)
            {
                throw new ArgumentNullException(nameof(tagStore));
            }
            else
            {
                ReferenceStore = referenceStore;
                TagStore = tagStore;
            }
        }
    }
}
