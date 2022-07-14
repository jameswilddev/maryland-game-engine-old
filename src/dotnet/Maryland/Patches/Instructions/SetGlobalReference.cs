using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set a global reference within a patch.
    /// </summary>
    public sealed class SetGlobalReference : IInstruction
    {
        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The identifier of the referenced entity.
        /// </summary>
        public readonly Guid Value;

        /// <summary>
        /// Creates an instruction to set a global reference within a patch.
        /// </summary>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The identifier of the referenced entity.</param>
        public SetGlobalReference(Guid attribute, Guid value)
        {
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetGlobalReference(Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(0)
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.Guid(Value));
    }
}
