using Maryland.Databases;
using System.Text;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set an entity float within a patch.
    /// </summary>
    public sealed class SetEntityFloat : IInstruction
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
        /// Creates an instruction to set an entity float within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the float.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The content of the float to set.</param>
        public SetEntityFloat(Guid entity, Guid attribute, float value)
        {
            Entity = entity;
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetEntityFloat(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(7)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.Float(Value));
    }
}
