using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set a global flag within a patch.
    /// </summary>
    public sealed class SetGlobalFlag : IInstruction
    {
        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// Creates an instruction to set a global flag within a patch.
        /// </summary>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        public SetGlobalFlag(Guid attribute)
        {
            Attribute = attribute;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetGlobalFlag(Attribute);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(3)
            .Concat(Serialize.Guid(Attribute));
    }
}
