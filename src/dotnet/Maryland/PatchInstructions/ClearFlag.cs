using Maryland.Databases;

namespace Maryland.PatchInstructions
{
    /// <summary>
    /// An instruction to clear a flag within a patch.
    /// </summary>
    public sealed class ClearFlag : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the flag.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to clear.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// Creates an instruction to clear a flag within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the flag.</param>
        /// <param name="attribute">The identifier of the attribute to clear.</param>
        public ClearFlag(Guid entity, Guid attribute)
        {
            Entity = entity;
            Attribute = attribute;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.ClearFlag(Entity, Attribute);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(4)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute));

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is ClearFlag clearFlag)
            {
                return clearFlag.Entity == Entity && clearFlag.Attribute == Attribute;
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
