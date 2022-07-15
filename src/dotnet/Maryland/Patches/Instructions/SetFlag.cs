using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set a flag within a patch.
    /// </summary>
    public sealed class SetFlag : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the flag.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// Creates an instruction to set a flag within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the flag.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        public SetFlag(Guid entity, Guid attribute)
        {
            Entity = entity;
            Attribute = attribute;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetFlag(Entity, Attribute);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(3)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute));

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is SetFlag setFlag)
            {
                return setFlag.Entity == Entity && setFlag.Attribute == Attribute;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(Entity, Attribute);
        }
    }
}
