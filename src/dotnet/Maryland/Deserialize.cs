using Maryland.DataTypes;
using System.Collections.Immutable;
using System.Numerics;

namespace Maryland
{
    internal static class Deserialize
    {
        internal static async ValueTask<Guid> Guid(IAsyncEnumerator<byte> bytes, string onEof)
        {
            var a = await Byte(bytes, onEof);
            var b = await Byte(bytes, onEof);
            var c = await Byte(bytes, onEof);
            var d = await Byte(bytes, onEof);
            var e = await Byte(bytes, onEof);
            var f = await Byte(bytes, onEof);
            var g = await Byte(bytes, onEof);
            var h = await Byte(bytes, onEof);
            var i = await Byte(bytes, onEof);
            var j = await Byte(bytes, onEof);
            var k = await Byte(bytes, onEof);
            var l = await Byte(bytes, onEof);
            var m = await Byte(bytes, onEof);
            var n = await Byte(bytes, onEof);
            var o = await Byte(bytes, onEof);
            var p = await Byte(bytes, onEof);

            return new Guid(new byte[] { d, c, b, a, f, e, h, g, i, j, k, l, m, n, o, p });
        }

        internal static async ValueTask<byte[]> MutableBytes(IAsyncEnumerator<byte> bytes, int number, string onEof)
        {
            var output = new byte[number];

            for (var i = 0; i < number; i++)
            {
                output[i] = await Byte(bytes, onEof);
            }

            return output;
        }

        internal static async ValueTask<ImmutableArray<byte>> Bytes(IAsyncEnumerator<byte> bytes, int number, string onEof)
        {
            var output = new byte[number];

            for (var i = 0; i < number; i++)
            {
                output[i] = await Byte(bytes, onEof);
            }

            return output.ToImmutableArray();
        }

        internal static async ValueTask<ImmutableArray<Guid>> GuidSet(IAsyncEnumerator<byte> bytes, int number, string onEof, string onDuplicate)
        {
            var collected = new Guid[number];

            for (var i = 0; i < number; i++)
            {
                collected[i] = await Guid(bytes, onEof);
            }

            if (collected.Distinct().Count() != number)
            {
                throw new InvalidDataException(onDuplicate);
            }

            return collected.ToImmutableArray();
        }

        internal static async Task<byte> Byte(IAsyncEnumerator<byte> bytes, string onEof)
        {
            if (!await bytes.MoveNextAsync())
            {
                throw new InvalidDataException(onEof);
            }

            return bytes.Current;
        }

        internal static async ValueTask<ushort> U16(IAsyncEnumerator<byte> bytes, string onEof)
        {
            var output = new byte[2];

            for (var i = 0; i < 2; i++)
            {
                output[i] = await Byte(bytes, onEof);
            }

            return BitConverter.ToUInt16(output);
        }

        internal static async ValueTask<ImmutableArray<ushort>> U16s(IAsyncEnumerator<byte> bytes, int number, string onEof)
        {
            var output = new ushort[number];

            for (var i = 0; i < number; i++)
            {
                output[i] = await U16(bytes, onEof);
            }

            return output.ToImmutableArray();
        }

        internal static async ValueTask<Vector2> Vector2(IAsyncEnumerator<byte> bytes, string onEof)
        {
            return new Vector2
            (
                await F32(bytes, onEof),
                await F32(bytes, onEof)
            );
        }

        internal static async ValueTask<ImmutableArray<Vector2>> Vector2s(IAsyncEnumerator<byte> bytes, int number, string onEof)
        {
            var output = new Vector2[number];

            for (var i = 0; i < number; i++)
            {
                output[i] = await Vector2(bytes, onEof);
            }

            return output.ToImmutableArray();
        }

        internal static async ValueTask<Vector3> Vector3(IAsyncEnumerator<byte> bytes, string onEof)
        {
            return new Vector3
            (
                await F32(bytes, onEof),
                await F32(bytes, onEof),
                await F32(bytes, onEof)
            );
        }

        internal static async ValueTask<ImmutableArray<Vector3>> Vector3s(IAsyncEnumerator<byte> bytes, int number, string onEof)
        {
            var output = new Vector3[number];

            for (var i = 0; i < number; i++)
            {
                output[i] = await Vector3(bytes, onEof);
            }

            return output.ToImmutableArray();
        }

        internal static async ValueTask<float> F32(IAsyncEnumerator<byte> bytes, string onEof)
        {
            var output = new byte[4];

            for (var i = 0; i < 4; i++)
            {
                output[i] = await Byte(bytes, onEof);
            }

            return BitConverter.ToSingle(output);
        }

        internal static async ValueTask<ColorWithOpacity> ColorWithOpacity(IAsyncEnumerator<byte> bytes, string onEof)
        {
            return new ColorWithOpacity
            (
                await Byte(bytes, onEof),
                await Byte(bytes, onEof),
                await Byte(bytes, onEof),
                await Byte(bytes, onEof)
            );
        }

        internal static async ValueTask<ImmutableArray<ColorWithOpacity>> ColorsWithOpacity(IAsyncEnumerator<byte> bytes, int number, string onEof)
        {
            var output = new ColorWithOpacity[number];

            for (var i = 0; i < number; i++)
            {
                output[i] = await ColorWithOpacity(bytes, onEof);
            }

            return output.ToImmutableArray();
        }

        internal static async ValueTask<Color> Color(IAsyncEnumerator<byte> bytes, string onEof)
        {
            return new Color
            (
                await Byte(bytes, onEof),
                await Byte(bytes, onEof),
                await Byte(bytes, onEof)
            );
        }
    }
}
