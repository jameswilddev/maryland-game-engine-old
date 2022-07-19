using Maryland.DataTypes;
using System.Collections.Immutable;
using System.Numerics;

namespace Maryland.Unit
{
    internal static class Generate
    {
        internal static float Float()
        {
            var bytes = new byte[4];

            while (true)
            {
            Random.Shared.NextBytes(bytes);

                var output = BitConverter.ToSingle(bytes);

                if (!float.IsNaN(output))
                {
                    return output;
                }
            }
        }

        internal static float DifferentFloat(float to)
        {
            float output;

            do
            {
                output = Float();
            }
            while (output == to);

            return output;
        }

        internal static byte Byte()
        {
            var bytes = new byte[1];
            Random.Shared.NextBytes(bytes);
            return bytes[0];
        }

        internal static byte DifferentByte(byte to)
        {
            byte output;

            do
            {
                output = Byte();
            }
            while (output == to);

            return output;
        }

        internal static string String()
        {
            return $"Test {Guid.NewGuid()} String";
        }

        internal static string String254BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 62; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§a";
        }

        internal static string String255BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 62; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§aa";
        }

        internal static string String256BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 62; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§aaa";
        }

        internal static string String257BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 62; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§aaaa";
        }

        internal static string String65534BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§a";
        }

        internal static string String65535BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§aa";
        }

        internal static string String65536BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§aaa";
        }

        internal static string String65537BytesInUTF8()
        {
            var value = string.Empty;

            for (var i = 0; i < 16382; i++)
            {
                value += "𩸽";
            }

            return $"{value}あ§aaaa";
        }

        internal static Color Color() => new(Byte(), Byte(), Byte());

        internal static Color DifferentColor(Color to)
        {
            Color output;

            do
            {
                output = Color();
            }
            while (Equals(to, output));

            return output;
        }

        internal static ImmutableArray<byte> Bytes(int length)
        {
            var output = new byte[length];
            Random.Shared.NextBytes(output);
            return ImmutableArray.Create(output);
        }

        internal static ColorWithOpacity ColorWithOpacity() => new(Byte(), Byte(), Byte(), Byte());

        internal static ColorWithOpacity DifferentColorWithOpacity(ColorWithOpacity to)
        {
            ColorWithOpacity output;

            do
            {
                output = ColorWithOpacity();
            }
            while (Equals(to, output));

            return output;
        }

        internal static ImmutableArray<ColorWithOpacity> ColorsWithOpacity(int length)
        {
            return Enumerable.Range(0, length).Select((x) => ColorWithOpacity()).ToImmutableArray();
        }

        internal static Image Image()
        {
            byte columns;

            do
            {
                columns = Byte();
            }
            while (columns < 1);

            byte rows;

            do
            {
                rows = Byte();
            }
            while (rows < 1);

            return new Image(columns, ColorsWithOpacity(columns * rows));
        }

        internal static Image DifferentImage(Image to)
        {
            Image output;

            do
            {
                output = Image();
            }
            while (output.Equals(to));

            return output;
        }

        internal static Vector2 Vector2()
        {
            return new Vector2(Float(), Float());
        }

        internal static ImmutableArray<Vector2> Vector2s(int length)
        {
            return Enumerable.Range(0, length).Select(x => Vector2()).ToImmutableArray();
        }

        internal static Vector3 Vector3()
        {
            return new Vector3(Float(), Float(), Float());
        }

        internal static ImmutableArray<Vector3> Vector3s(int length)
        {
            return Enumerable.Range(0, length).Select(x => Vector3()).ToImmutableArray();
        }

        internal static float UnitInterval()
        {
            return (float)Random.Shared.NextDouble();
        }

        internal static ImmutableArray<float> UnitIntervals(int length)
        {
            return Enumerable.Range(0, length).Select(x => UnitInterval()).ToImmutableArray();
        }

        internal static ImmutableSortedSet<Guid> Guids(int length)
        {
            return Enumerable.Range(0, length).Select(x => Guid.NewGuid()).ToImmutableSortedSet();
        }
    }
}
