using System.Collections.Immutable;

namespace Maryland.Stores.ReferenceStores
{
    /// <summary>
    /// Deserializes <see cref="ReferenceStoreDiff"/>s from <see cref="byte"/> sequences.
    /// </summary>
    public sealed class ReferenceStoreDiffDeserializer : IReferenceStoreDiffDeserializer
    {
        private static async ValueTask<byte> DeserializeU8(IAsyncEnumerator<byte> bytes, string description)
        {
            if (await bytes.MoveNextAsync())
            {
                return bytes.Current;
            }
            else
            {
                throw new InvalidDataException($"Unexpected end of file during {description}.");
            }
        }

        private static async Task<byte[]> DeserializeU8Array(IAsyncEnumerator<byte> bytes, int length, string description)
        {
            var packed = new byte[length];

            for (var index = 0; index < length; index++)
            {
                packed[index] = await DeserializeU8(bytes, description);
            }

            return packed;
        }

        private static async ValueTask<uint> DeserializeU32(IAsyncEnumerator<byte> bytes, string description)
        {
            return BitConverter.ToUInt32(await DeserializeU8Array(bytes, 4, description));
        }

        private static async ValueTask<Guid> DeserializeGuid(IAsyncEnumerator<byte> bytes, string description)
        {
            var a = await DeserializeU8(bytes, description);
            var b = await DeserializeU8(bytes, description);
            var c = await DeserializeU8(bytes, description);
            var d = await DeserializeU8(bytes, description);
            var e = await DeserializeU8(bytes, description);
            var f = await DeserializeU8(bytes, description);
            var g = await DeserializeU8(bytes, description);
            var h = await DeserializeU8(bytes, description);
            var i = await DeserializeU8(bytes, description);
            var j = await DeserializeU8(bytes, description);
            var k = await DeserializeU8(bytes, description);
            var l = await DeserializeU8(bytes, description);
            var m = await DeserializeU8(bytes, description);
            var n = await DeserializeU8(bytes, description);
            var o = await DeserializeU8(bytes, description);
            var p = await DeserializeU8(bytes, description);

            return new Guid(new byte[] { d, c, b, a, f, e, h, g, i, j, k, l, m, n, o, p });
        }

        /// <inheritdoc />
        public async Task<ReferenceStoreDiff> Deserialize(IAsyncEnumerator<byte> bytes)
        {
            var numberSet = await DeserializeU32(bytes, "the number of references set");

            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>.Empty;

            while (numberSet > 0)
            {
                var entity = await DeserializeGuid(bytes, "the entity identifier of a set reference");
                var attribute = await DeserializeGuid(bytes, "the attribute identifier of a set reference");

                var entityAttributeIdentifierPair = new EntityAttributeIdentifierPair(entity, attribute);

                if (set.ContainsKey(entityAttributeIdentifierPair))
                {
                    throw new InvalidDataException("Multiple tags are specified for the same identifier.");
                }

                var value = await DeserializeGuid(bytes, "the value identifier of a set reference");

                set = set.Add(entityAttributeIdentifierPair, value);

                numberSet--;
            }

            var numberDeleted = await DeserializeU32(bytes, "the number of deleted references");

            var deleted = ImmutableHashSet<EntityAttributeIdentifierPair>.Empty;

            while (numberDeleted > 0)
            {
                var entity = await DeserializeGuid(bytes, "the entity identifier of a deleted reference");
                var attribute = await DeserializeGuid(bytes, "the attribute identifier of a deleted reference");

                var entityAttributeIdentifierPair = new EntityAttributeIdentifierPair(entity, attribute);

                if (set.ContainsKey(entityAttributeIdentifierPair))
                {
                    throw new InvalidDataException("A reference is set, then deleted again.");
                }
                else if (deleted.Contains(entityAttributeIdentifierPair))
                {
                    throw new InvalidDataException("The same reference is deleted multiple times.");
                }
                else
                {
                    deleted = deleted.Add(entityAttributeIdentifierPair);
                }

                numberDeleted--;
            }

            return new ReferenceStoreDiff(set, deleted);
        }
    }
}
