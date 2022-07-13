namespace Maryland.Stores.TagStores
{
    /// <summary>
    /// Serializes <see cref="TagStoreDiff"/>s to <see cref="byte"/> sequences.
    /// </summary>
    public interface ITagStoreDiffSerializer
    {
        /// <summary>
        /// Serializes a <see cref="TagStoreDiff"/> to a <see cref="byte"/> sequence.
        /// </summary>
        /// <param name="tagStoreDiff">The <see cref="TagStoreDiff"/> to serialize.</param>
        /// <returns>A sequence of <see cref="byte"/>s describing the given <paramref name="tagStoreDiff"/>.</returns>
        IEnumerable<byte> Serialize(TagStoreDiff tagStoreDiff);
    }
}
