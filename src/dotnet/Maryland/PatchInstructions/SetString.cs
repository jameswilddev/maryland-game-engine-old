using Maryland.Databases;
using System.Text;

namespace Maryland.PatchInstructions
{
    /// <summary>
    /// An instruction to set a string within a patch.
    /// </summary>
    public sealed class SetString : IInstruction
    {
        /// <summary>
        /// The identifier of the entity which holds the string.
        /// </summary>
        public readonly Guid Entity;

        /// <summary>
        /// The identifier of the attribute to set.
        /// </summary>
        public readonly Guid Attribute;

        /// <summary>
        /// The content of the string to set.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Creates an instruction to set a string within a patch.
        /// </summary>
        /// <param name="entity">The identifier of the entity which holds the string.</param>
        /// <param name="attribute">The identifier of the attribute to set.</param>
        /// <param name="value">The content of the string to set.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> exceeds 65535 bytes in length when encoded as UTF-8.</exception>
        public SetString(Guid entity, Guid attribute, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (Encoding.UTF8.GetByteCount(value) > 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Cannot exceed 65535 bytes in length when encoded as UTF-8.");
            }
            else
            {
                Entity = entity;
                Attribute = attribute;
                Value = value;
            }
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetString(Entity, Attribute, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(1)
            .Concat(Serialize.Guid(Entity))
            .Concat(Serialize.Guid(Attribute))
            .Concat(Serialize.LongString(Value));

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is SetString setString)
            {
                return setString.Entity == Entity && setString.Attribute == Attribute && setString.Value == Value;
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
