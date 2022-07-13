namespace Maryland.Stores.ReferenceStores
{
    /// <summary>
    /// Deserializes <see cref="ReferenceStoreDiff"/>s from <see cref="byte"/> sequences.
    /// </summary>
    public interface IReferenceStoreDiffDeserializer
    {
        /// <summary>
        /// Deserializes a <see cref="ReferenceStoreDiff"/> from a <see cref="byte"/> sequence.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/>s to serialize from.  Enumeration will stop at the end of the data describing a <see cref="ReferenceStoreDiff"/>.</param>
        /// <returns>The <see cref="ReferenceStoreDiff"/> parsed from the given <paramref name="bytes"/>.</returns>
        /// <exception cref="InvalidDataException">Thrown when <paramref name="bytes"/> ends before a complete <see cref="ReferenceStoreDiff"/> is deserialized.</exception>
        /// <exception cref="InvalidDataException">Thrown when <paramref name="bytes"/> includes the same entity/attribute identifier pair multiple times.</exception>
        Task<ReferenceStoreDiff> Deserialize(IAsyncEnumerator<byte> bytes);
    }
}
