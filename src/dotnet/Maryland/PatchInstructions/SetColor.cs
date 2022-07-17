using Maryland.Databases;
using Maryland.DataTypes;

namespace Maryland.PatchInstructions
{
    /// <summary>
    /// An instruction to set a 24-bit red/green/blue color within a patch.
    /// </summary>
    public sealed class SetColor : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the color.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The color to set.
        /// </summary>
        public readonly Color Value;

        /// <summary>
        /// Creates an instruction to set a 24-bit red/green/blue color within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the float.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The color to set.</param>
        public SetColor(Guid entity, Guid attribute, Color value)
        {
            Entity = entity;
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetColor(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(6)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.Byte(Value.Red))
            .Concat(Serialize.Byte(Value.Green))
            .Concat(Serialize.Byte(Value.Blue));

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is SetColor setColor)
            {
                return setColor.Entity == Entity && setColor.Attribute == Attribute && ValueType.Equals(setColor.Value, Value);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(Entity, Attribute, Value);
        }
    }
}
