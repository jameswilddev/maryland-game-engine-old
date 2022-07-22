using Maryland.Databases;
using Maryland.DataTypes;

namespace Maryland.PatchInstructions
{
    /// <summary>
    /// An instruction to set a polygonal <see cref="Mesh"/> within a patch.
    /// </summary>
    public sealed class SetMesh : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the mesh.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The <see cref="Mesh"/> to set.
        /// </summary>
        public readonly Mesh Value;

        /// <summary>
        /// Creates an instruction to set a polygonal <see cref="Mesh"/> within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the float.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The <see cref="Mesh"/> to set.</param>
        public SetMesh(Guid entity, Guid attribute, Mesh value)
        {
            Entity = entity;
            Attribute = attribute;
            Value = value;
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetMesh(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(8)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Value.Serialized);

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is SetMesh setMesh)
            {
                return setMesh.Entity == Entity && setMesh.Attribute == Attribute && setMesh.Value.Equals(Value);
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
