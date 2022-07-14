using Maryland.Databases;
using System.Text;

namespace Maryland.Patches.Instructions
{
    /// <summary>
    /// An instruction to set a tag within a patch.
    /// </summary>
    public sealed class SetTag : IInstruction
    {
        /// <summary>
        /// The identifier of the tag to set.
        /// </summary>
        public readonly Guid Identifier;

        /// <summary>
        /// The content of the tag to set.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Creates an instruction to set a tag within a patch.
        /// </summary>
        /// <param name="identifier">The identifier of the tag to set.</param>
        /// <param name="value">The content of the tag to set.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> exceeds 255 bytes in length when encoded as UTF-8.</exception>
        public SetTag(Guid identifier, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (Encoding.UTF8.GetByteCount(value) > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Cannot exceed 255 bytes in length when encoded as UTF-8.");
            }
            else
            {
                Identifier = identifier;
                Value = value;
            }
        }

        /// <inheritdoc />
        public void ApplyTo(IDatabase database)
        {
            database.SetTag(Identifier, Value);
        }

        /// <inheritdoc />
        public IEnumerable<byte> Serialized => Serialize
            .Byte(5)
            .Concat(Serialize.Guid(Identifier))
            .Concat(Serialize.ShortString(Value));
    }
}
