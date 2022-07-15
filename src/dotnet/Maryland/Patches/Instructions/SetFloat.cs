using Maryland.Databases;
using System.Text;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set a float within a patch.
    /// </summary>
    public sealed class SetFloat : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the float.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The content of the float to set.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Creates an instruction to set a float within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the float.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The content of the float to set.</param>
        public SetFloat(Guid entity, Guid attribute, float value)
        {
            Entity = entity;
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetFloat(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(2)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.Float(Value));

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is SetFloat setFloat)
            {
                return setFloat.Entity == Entity && setFloat.Attribute == Attribute && setFloat.Value == Value;
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
