using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction within a patch.
    /// </summary>
    public interface IInstruction
    {
        /// <summary>
        /// Applies the change described by <see langword="this"/> <see cref="IInstruction"/> to a given <see cref="IDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="IDatabase"/> to apply <see langword="this"/> <see cref="IInstruction"/> to.</param>
        void ApplyTo(IDatabase database);

        /// <summary>
        /// A sequence of <see cref="byte"/>s which describe <see langword="this"/> <see cref="IInstruction"/>.
        /// </summary>
        IEnumerable<byte> Serialized { get; }
    }
}
