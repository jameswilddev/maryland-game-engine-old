﻿using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set an entity flag within a patch.
    /// </summary>
    public sealed class SetEntityFlag : IInstruction
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
        /// Creates an instruction to set an entity flag within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the flag.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        public SetEntityFlag(Guid entity, Guid attribute)
        {
            Entity = entity;
            Attribute = attribute;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetEntityFlag(Entity, Attribute);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(8)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute));
    }
}
