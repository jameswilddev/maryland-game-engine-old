namespace Maryland.Stores
{
    /// <summary>
    /// Deserializes <see cref="StoreDiff"/>s from <see cref="byte"/> streams.
    /// </summary>
    public interface IStoreDiffDeserializer
    {
        /// <summary>
        /// Deserializes a <see cref="StoreDiff"/> from a <see cref="byte"/> stream.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/> stream to deserialize to a <see cref="StoreDiff"/>.</param>
        /// <returns>The <see cref="StoreDiff"/> to deserialized from the given <paramref name="bytes"/>.</returns>
        Task<StoreDiff> Deserialize(IAsyncEnumerator<byte> bytes);
    }
}
