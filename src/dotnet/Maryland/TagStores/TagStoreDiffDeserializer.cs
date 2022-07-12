using System.Collections.Immutable;
using System.Text;

namespace Maryland.TagStores
{
    /// <summary>
    /// Deserializes <see cref="TagStoreDiff"/>s from <see cref="byte"/> sequences.
    /// </summary>
    public sealed class TagStoreDiffDeserializer : ITagStoreDiffDeserializer
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

        private static async Task<string> DeserializeString(IAsyncEnumerator<byte> bytes, string description)
        {
            var length = await DeserializeU8(bytes, $"the length of a {description}");

            if (length == 0)
            {
                throw new InvalidDataException($"A {description} is empty.");
            } else
            {
                return Encoding.UTF8.GetString(await DeserializeU8Array(bytes, length, $"the content of a {description}"));
            }
        }

        /// <inheritdoc />
        public async Task<TagStoreDiff> Deserialize(IAsyncEnumerator<byte> bytes)
        {
            var numberSet = await DeserializeU32(bytes, "the number of tags set");

            var set = ImmutableDictionary<Guid, string>.Empty;

            while (numberSet > 0)
            {
                var identifier = await DeserializeGuid(bytes, "the identifier of a set tag");

                if (set.ContainsKey(identifier))
                {
                    throw new InvalidDataException("Multiple tags are specified for the same identifier.");
                }

                var tag = await DeserializeString(bytes, "set tag");

                set = set.Add(identifier, tag);

                numberSet--;
            }

            var numberDeleted = await DeserializeU32(bytes, "the number of deleted tags");

            var deleted = ImmutableHashSet<Guid>.Empty;

            while (numberDeleted > 0)
            {
                var identifier = await DeserializeGuid(bytes, "the identifier of a deleted tag");

                if (set.ContainsKey(identifier))
                {
                    throw new InvalidDataException("A tag is set, then deleted again.");
                }
                else if (deleted.Contains(identifier))
                {
                    throw new InvalidDataException("The same tag is deleted multiple times.");
                }
                else
                {
                    deleted = deleted.Add(identifier);
                }

                numberDeleted--;
            }

            return new TagStoreDiff(set, deleted);
        }
    }
}
