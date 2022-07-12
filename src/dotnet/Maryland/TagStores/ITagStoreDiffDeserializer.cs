namespace Maryland.TagStores
{
    /// <summary>
    /// Deserializes <see cref="TagStoreDiff"/>s from <see cref="byte"/> sequences.
    /// </summary>
    public interface ITagStoreDiffDeserializer
    {
        /// <summary>
        /// Deserializes a <see cref="TagStoreDiff"/> from a <see cref="byte"/> sequence.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/>s to serialize from.  Enumeration will stop at the end of the data describing a <see cref="TagStoreDiff"/>.</param>
        /// <returns>The <see cref="TagStoreDiff"/> parsed from the given <paramref name="bytes"/>.</returns>
        /// <exception cref="InvalidDataException">Thrown when <paramref name="bytes"/> ends before a complete <see cref="TagStoreDiff"/> is deserialized.</exception>
        /// <exception cref="InvalidDataException">Thrown when <paramref name="bytes"/> includes empty or white space tags.</exception>
        /// <exception cref="InvalidDataException">Thrown when <paramref name="bytes"/> includes the same identifier multiple times.</exception>
        Task<TagStoreDiff> Deserialize(IAsyncEnumerator<byte> bytes);
    }
}
