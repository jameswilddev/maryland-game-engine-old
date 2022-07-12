namespace Maryland.ReferenceStores
{
    /// <summary>
    /// Serializes <see cref="RefrrenceStoreDiff"/>s to <see cref="byte"/> sequences.
    /// </summary>
    public interface IReferenceStoreDiffSerializer
    {
        /// <summary>
        /// Serializes a <see cref="ReferenceStoreDiff"/> to a <see cref="byte"/> sequence.
        /// </summary>
        /// <param name="referenceStoreDiff">The <see cref="ReferenceStoreDiff"/> to serialize.</param>
        /// <returns>A sequence of <see cref="byte"/>s describing the given <paramref name="referenceStoreDiff"/>.</returns>
        IEnumerable<byte> Serialize(ReferenceStoreDiff referenceStoreDiff);
    }
}
