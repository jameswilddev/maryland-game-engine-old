namespace Maryland.DataTypes
{
    /// <summary>
    /// Deserializes <see cref="Mesh"/>es from <see cref="byte"/> streams.
    /// </summary>
    public interface IMeshDeserializer
    {
        /// <summary>
        /// Deserializes a <see cref="Mesh"/> from a given <see cref="byte"/> stream.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/> stream to deserialize.</param>
        /// <returns>The <see cref="Mesh"/> deserialized from the given <paramref name="bytes"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="bytes"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidDataException">Thrown when the given <paramref name="bytes"/> do not represent a valid <see cref="Mesh"/>.</exception>
        ValueTask<Mesh> Deserialize(IAsyncEnumerable<byte> bytes);
    }
}
