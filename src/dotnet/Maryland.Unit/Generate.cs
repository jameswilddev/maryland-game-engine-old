using Maryland.DataTypes;

namespace Maryland.Unit
{
    internal static class Generate
    {
        internal static float Float()
        {
            var bytes = new byte[4];
            Random.Shared.NextBytes(bytes);
            return BitConverter.ToSingle(bytes);
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
            while (ValueType.Equals(to, output));

            return output;
        }
    }
}
