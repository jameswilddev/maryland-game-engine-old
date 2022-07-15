using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set a reference within a patch.
    /// </summary>
    public sealed class SetReference : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the reference.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The identifier of the referenced entity.
        /// </summary>
        public readonly Guid Value;

        /// <summary>
        /// Creates an instruction to set a reference within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the reference.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The identifier of the referenced entity.</param>
        public SetReference(Guid entity, Guid attribute, Guid value)
        {
            Entity = entity;
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetReference(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(0)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.Guid(Value));

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is SetReference setReference)
            {
                return setReference.Entity == Entity && setReference.Attribute == Attribute && setReference.Value == Value;
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
