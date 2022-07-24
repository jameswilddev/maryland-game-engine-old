using Maryland.Databases;
using Maryland.DataTypes;

namespace Maryland.PatchInstructions
{
    /// <summary>
    /// An instruction to set a 32-bit red/green/blue/opacity image within a patch.
    /// </summary>
    public sealed class SetImage : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the image.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The image to set.
        /// </summary>
        public readonly Image Value;

        /// <summary>
        /// Creates an instruction to set a 32-bit red/green/blue/opacity image within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the float.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The image to set.</param>
        public SetImage(Guid entity, Guid attribute, Image value)
        {
            Entity = entity;
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetImage(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(7)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Value.Serialized);

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is SetImage setImage)
            {
                return setImage.Entity == Entity && setImage.Attribute == Attribute && setImage.Value.Equals(Value);
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
