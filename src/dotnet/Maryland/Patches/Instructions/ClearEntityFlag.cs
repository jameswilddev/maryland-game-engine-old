using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to clear an entity flag within a patch.
    /// </summary>
    public sealed class ClearEntityFlag : IInstruction
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
        /// Creates an instruction to clear an entity flag within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the flag.</param>
        /// <param name="attribute">The identifier of the attribute to clear.</param>
        public ClearEntityFlag(Guid entity, Guid attribute)
        {
            Entity = entity;
            Attribute = attribute;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.ClearEntityFlag(Entity, Attribute);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(9)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute));
    }
}
