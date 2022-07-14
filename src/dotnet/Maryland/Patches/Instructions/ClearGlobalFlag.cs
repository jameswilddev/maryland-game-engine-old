using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to clear a global flag within a patch.
    /// </summary>
    public sealed class ClearGlobalFlag : IInstruction
    {
        /// <summary>
        /// The identifier of the attribute to clear.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// Creates an instruction to clear a global flag within a patch.
        /// </summary>
        /// <param name="attribute">The identifier of the attribute to clear.</param>
        public ClearGlobalFlag(Guid attribute)
        {
            Attribute = attribute;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.ClearGlobalFlag(Attribute);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(4)
            .Concat(Serialize.Guid(Attribute));
    }
}