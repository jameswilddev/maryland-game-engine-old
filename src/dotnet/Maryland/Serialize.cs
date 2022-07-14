using System.Text;

namespace Maryland
{
    internal static class Serialize
    {
        internal static IEnumerable<byte> Byte(byte value)
        {
            yield return value;
        }

        internal static IEnumerable<byte> Guid(Guid value)
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

        internal static IEnumerable<byte> Float(float value) => BitConverter.GetBytes(value);

        internal static IEnumerable<byte> U16(ushort value) => BitConverter.GetBytes(value);

        internal static IEnumerable<byte> UTF8(string value) => Encoding.UTF8.GetBytes(value);

        internal static IEnumerable<byte> ShortString(string value) => Byte((byte)Encoding.UTF8.GetByteCount(value)).Concat(UTF8(value));

        internal static IEnumerable<byte> LongString(string value) => U16((ushort)Encoding.UTF8.GetByteCount(value)).Concat(UTF8(value));
    }
}
