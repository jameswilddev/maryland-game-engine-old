using System.Numerics;
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

        internal static IEnumerable<byte> Guids(IEnumerable<Guid> values)
        {
            return values.SelectMany(Guid);
        }

        internal static IEnumerable<byte> Float(float value) => BitConverter.GetBytes(value);

        internal static IEnumerable<byte> Floats(IEnumerable<float> floats) => floats.SelectMany(Float);

        internal static IEnumerable<byte> Vector2(Vector2 vector2) => Floats(new[] { vector2.X, vector2.Y });

        internal static IEnumerable<byte> Vector2s(IEnumerable<Vector2> vector2s) => vector2s.SelectMany(Vector2);

        internal static IEnumerable<byte> Vector3(Vector3 vector3) => Floats(new[] { vector3.X, vector3.Y, vector3.Z });

        internal static IEnumerable<byte> Vector3s(IEnumerable<Vector3> vector3s) => vector3s.SelectMany(Vector3);

        internal static IEnumerable<byte> U16(ushort value) => BitConverter.GetBytes(value);

        internal static IEnumerable<byte> U16s(IEnumerable<ushort> values) => values.SelectMany(U16);

        internal static IEnumerable<byte> UTF8(string value) => Encoding.UTF8.GetBytes(value);

        internal static IEnumerable<byte> ShortString(string value) => Byte((byte)Encoding.UTF8.GetByteCount(value)).Concat(UTF8(value));

        internal static IEnumerable<byte> LongString(string value) => U16((ushort)Encoding.UTF8.GetByteCount(value)).Concat(UTF8(value));

        internal static IEnumerable<byte> Bits(params bool[] bits)
        {
            byte nextOutput = 0;

            for (var i = 0; i < bits.Length; i++)
            {
                nextOutput >>= 1;

                if (bits[i])
                {
                    nextOutput |= 128;
                }

                if (i % 8 == 7)
                {
                    yield return nextOutput;
                    nextOutput = 0;
                }
            }

            if (bits.Length % 8 != 0)
            {
                for (var i = 8; i > bits.Length % 8; i--)
                {
                    nextOutput >>= 1;
                }

                yield return nextOutput;
            }
        }
    }
}
