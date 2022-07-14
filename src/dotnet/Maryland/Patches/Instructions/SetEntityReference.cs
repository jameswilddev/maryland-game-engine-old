﻿using Maryland.Databases;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set an entity reference within a patch.
    /// </summary>
    public sealed class SetEntityReference : IInstruction
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
        /// Creates an instruction to set an entity reference within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the reference.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The identifier of the referenced entity.</param>
        public SetEntityReference(Guid entity, Guid attribute, Guid value)
        {
            Entity = entity;
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetEntityReference(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(5)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.Guid(Value));
    }
}
