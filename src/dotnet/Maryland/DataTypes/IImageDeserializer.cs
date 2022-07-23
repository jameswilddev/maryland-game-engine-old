namespace Maryland.DataTypes
{
    /// <summary>
    /// Deserializes <see cref="Image"/>s from <see cref="byte"/> streams.
    /// </summary>
    public interface IImageDeserializer
    {
        /// <summary>
        /// Deserializes a <see cref="Image"/> from a given <see cref="byte"/> stream.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/> stream to deserialize.</param>
        /// <returns>The <see cref="Image"/> deserialized from the given <paramref name="bytes"/>.</returns>
        /// <exception cref="InvalidDataException">Thrown when the given <paramref name="bytes"/> do not represent a valid <see cref="Image"/>.</exception>
        ValueTask<Image> Deserialize(IAsyncEnumerable<byte> bytes);
    }
}
