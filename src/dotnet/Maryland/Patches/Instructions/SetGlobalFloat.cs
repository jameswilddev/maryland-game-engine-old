using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set a global float within a patch.
    /// </summary>
    public sealed class SetGlobalFloat : IInstruction
    {
        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The content of the float to set.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Creates an instruction to set a global floatwithin a patch.
        /// </summary>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The content of the float to set.</param>
        public SetGlobalFloat(Guid attribute, float value)
        {
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetGlobalFloat(Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(2)
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.Float(Value));
    }
}
