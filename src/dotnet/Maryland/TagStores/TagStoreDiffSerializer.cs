using System.Text;

namespace Maryland.TagStores
{
    /// <summary>
    /// Serializes <see cref="TagStoreDiff"/>s to <see cref="byte"/> sequences.
    /// </summary>
    public sealed class TagStoreDiffSerializer : ITagStoreDiffSerializer
    {
        private static IEnumerable<byte> SerializeU8(byte value)
        {
            yield return value;
        }

        private static IEnumerable<byte> SerializeU32(uint value) => BitConverter.GetBytes(value);

        private IEnumerable<byte> SerializeGuid(Guid value)
        {
            var output = value.ToByteArray();

            yield return output[3];
            yield return output[2];
            yield return output[1];
            yield return output[0];
            yield return output[5];
            yield return output[4];
            yield return output[7];
            yield return output[6];
            yield return output[8];
            yield return output[9];
            yield return output[10];
            yield return output[11];
            yield return output[12];
            yield return output[13];
            yield return output[14];
            yield return output[15];
        }

        private static IEnumerable<byte> SerializeString(string value) => SerializeU8((byte)Encoding.UTF8.GetByteCount(value)).Concat(Encoding.UTF8.GetBytes(value));
       
        private IEnumerable<byte> SerializeMapping(KeyValuePair<Guid, string> mapping) => SerializeGuid(mapping.Key).Concat(SerializeString(mapping.Value));

        /// <inheritdoc />
        public IEnumerable<byte> Serialize(TagStoreDiff tagStoreDiff)
        {
            return SerializeU32((uint)tagStoreDiff.Set.Count)
                .Concat(tagStoreDiff.Set.OrderBy(kv => kv.Key).SelectMany(SerializeMapping))
                .Concat(SerializeU32((uint)tagStoreDiff.Deleted.Count))
                .Concat(tagStoreDiff.Deleted.OrderBy(k => k).SelectMany(SerializeGuid));
        }
    }
}
