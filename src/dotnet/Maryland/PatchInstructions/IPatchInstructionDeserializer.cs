namespace Maryland.PatchInstructions
{
    /// <summary>
    /// Deserializes <see cref="IInstruction"/>s from <see cref="byte"/> streams.
    /// </summary>
    public interface IPatchInstructionDeserializer
    {
        /// <summary>
        /// Deserializes <see cref="IInstruction"/>s from a given <see cref="byte"/> stream.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/> stream to deserialize.</param>
        /// <returns>The <see cref="IInstruction"/>s deserialized from the given <paramref name="bytes"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="bytes"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidDataException">Thrown when the given <paramref name="bytes"/> do not represent valid <see cref="IInstruction"/>s.</exception>
        IAsyncEnumerable<IInstruction> Deserialize(IAsyncEnumerable<byte> bytes);
    }
}
