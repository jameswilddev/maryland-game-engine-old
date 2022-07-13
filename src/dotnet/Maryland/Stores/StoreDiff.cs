using Maryland.Stores.ReferenceStores;
using Maryland.Stores.TagStores;

namespace Maryland.Stores
{
    /// <summary>
    /// A description of the differences between two <see cref="Store"/>s.
    /// </summary>
    public sealed class StoreDiff
    {
        /// <summary>
        /// The differences between the <see cref="ReferenceStore"/>s within the <see cref="Store"/>s.
        /// </summary>
        public readonly ReferenceStoreDiff ReferenceStoreDiff;

        /// <summary>
        /// The differences between the <see cref="TagStore"/>s within the <see cref="Store"/>s.
        /// </summary>
        public readonly TagStoreDiff TagStoreDiff;

        /// <summary>
        /// Creates a new description of the differences between two <see cref="Store"/>s.
        /// </summary>
        /// <param name="referenceStoreDiff">The differences between the <see cref="ReferenceStore"/>s within the <see cref="Store"/>s.</param>
        /// <param name="tagStoreDiff">The differences between the <see cref="TagStore"/>s within the <see cref="Store"/>s.</param>
        public StoreDiff(ReferenceStoreDiff referenceStoreDiff, TagStoreDiff tagStoreDiff)
        {
            if (referenceStoreDiff == null)
            {
                throw new ArgumentNullException(nameof(referenceStoreDiff));
            }
            else if (tagStoreDiff == null)
            {
                throw new ArgumentNullException(nameof(tagStoreDiff));
            }
            else
            {
                ReferenceStoreDiff = referenceStoreDiff;
                TagStoreDiff = tagStoreDiff;
            }
        }
    }
}
