using Maryland.DataTypes;
using Maryland.PatchInstructions;
using System.Collections.Immutable;
using System.Numerics;

namespace Maryland.Unit.DataTypes
{
    [TestClass]
    public sealed class MeshTests
    {
        internal static readonly ImmutableArray<Vector3> FirstTransformPositions = ImmutableArray.Create
        (
            new Vector3(0.693f, 0.761f, 0.993f),
            new Vector3(0.586f, 0.918f, 0.189f),
            new Vector3(0.073f, 0.717f, 0.365f),
            new Vector3(0.103f, 0.430f, 0.755f),
            new Vector3(0.633f, 0.823f, 0.842f),
            new Vector3(0.751f, 0.386f, 0.759f),
            new Vector3(0.494f, 0.084f, 0.828f),
            new Vector3(0.770f, 0.914f, 0.364f),
            new Vector3(0.383f, 0.471f, 0.354f),
            new Vector3(0.566f, 0.969f, 0.882f)
        );

        internal static readonly ImmutableArray<Vector3> FirstTransformNormals = ImmutableArray.Create
        (
            new Vector3(0.241f, 0.896f, 0.192f),
            new Vector3(0.306f, 0.829f, 0.372f),
            new Vector3(0.836f, 0.735f, 0.467f),
            new Vector3(0.618f, 0.879f, 0.836f),
            new Vector3(0.404f, 0.676f, 0.606f),
            new Vector3(0.332f, 0.935f, 0.235f),
            new Vector3(0.236f, 0.664f, 0.335f),
            new Vector3(0.566f, 0.441f, 0.365f),
            new Vector3(0.384f, 0.682f, 0.044f),
            new Vector3(0.861f, 0.675f, 0.475f)
        );

        internal static readonly ImmutableArray<Vector3> FirstTransformTangents = ImmutableArray.Create
        (
            new Vector3(0.074f, 0.760f, 0.976f),
            new Vector3(0.336f, 0.582f, 0.998f),
            new Vector3(0.509f, 0.084f, 0.310f),
            new Vector3(0.676f, 0.305f, 0.795f),
            new Vector3(0.303f, 0.613f, 0.706f),
            new Vector3(0.039f, 0.442f, 0.748f),
            new Vector3(0.470f, 0.201f, 0.337f),
            new Vector3(0.658f, 0.281f, 0.458f),
            new Vector3(0.380f, 0.776f, 0.556f),
            new Vector3(0.754f, 0.009f, 0.722f)
        );

        internal static readonly ImmutableArray<Vector3> FirstTransformBitangents = ImmutableArray.Create
        (
            new Vector3(0.694f, 0.620f, 0.305f),
            new Vector3(0.432f, 0.317f, 0.725f),
            new Vector3(0.516f, 0.811f, 0.931f),
            new Vector3(0.115f, 0.707f, 0.898f),
            new Vector3(0.105f, 0.261f, 0.970f),
            new Vector3(0.336f, 0.439f, 0.038f),
            new Vector3(0.703f, 0.717f, 0.253f),
            new Vector3(0.213f, 0.357f, 0.151f),
            new Vector3(0.024f, 0.186f, 0.560f),
            new Vector3(0.077f, 0.687f, 0.564f)
        );

        internal static readonly ImmutableArray<Vector3> SecondTransformPositions = ImmutableArray.Create
        (
            new Vector3(0.799f, 0.067f, 0.479f),
            new Vector3(0.143f, 0.672f, 0.619f),
            new Vector3(0.456f, 0.619f, 0.165f),
            new Vector3(0.816f, 0.155f, 0.525f),
            new Vector3(0.415f, 0.136f, 0.582f),
            new Vector3(0.658f, 0.156f, 0.127f),
            new Vector3(0.930f, 0.903f, 0.307f),
            new Vector3(0.335f, 0.678f, 0.842f),
            new Vector3(0.527f, 0.145f, 0.654f),
            new Vector3(0.593f, 0.755f, 0.382f)
        );

        internal static readonly ImmutableArray<Vector3> SecondTransformNormals = ImmutableArray.Create
        (
            new Vector3(0.422f, 0.542f, 0.298f),
            new Vector3(0.527f, 0.850f, 0.365f),
            new Vector3(0.586f, 0.174f, 0.220f),
            new Vector3(0.748f, 0.060f, 0.915f),
            new Vector3(0.534f, 0.536f, 0.752f),
            new Vector3(0.290f, 0.209f, 0.573f),
            new Vector3(0.491f, 0.360f, 0.420f),
            new Vector3(0.318f, 0.832f, 0.664f),
            new Vector3(0.618f, 0.964f, 0.065f),
            new Vector3(0.182f, 0.149f, 0.163f)
        );

        internal static readonly ImmutableArray<Vector3> SecondTransformTangents = ImmutableArray.Create
        (
            new Vector3(0.030f, 0.701f, 0.086f),
            new Vector3(0.693f, 0.474f, 0.281f),
            new Vector3(0.253f, 0.841f, 0.106f),
            new Vector3(0.662f, 0.011f, 0.400f),
            new Vector3(0.542f, 0.276f, 0.472f),
            new Vector3(0.341f, 0.775f, 0.208f),
            new Vector3(0.813f, 0.391f, 0.519f),
            new Vector3(0.279f, 0.735f, 0.208f),
            new Vector3(0.840f, 0.166f, 0.828f),
            new Vector3(0.679f, 0.915f, 0.975f)
        );

        internal static readonly ImmutableArray<Vector3> SecondTransformBitangents = ImmutableArray.Create
        (
            new Vector3(0.132f, 0.704f, 0.945f),
            new Vector3(0.528f, 0.102f, 0.035f),
            new Vector3(0.588f, 0.631f, 0.388f),
            new Vector3(0.538f, 0.839f, 0.917f),
            new Vector3(0.366f, 0.137f, 0.964f),
            new Vector3(0.795f, 0.859f, 0.414f),
            new Vector3(0.135f, 0.305f, 0.947f),
            new Vector3(0.292f, 0.923f, 0.515f),
            new Vector3(0.446f, 0.911f, 0.705f),
            new Vector3(0.165f, 0.346f, 0.183f)
        );

        internal static readonly ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>> TextureCoordinates = ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>>
            .Empty
            .Add
            (
                new Guid("d612d2af-798a-4e66-8936-12fc61fca7e3"),
                ImmutableArray.Create
                (
                    new Vector2(0.367f, 0.039f),
                    new Vector2(0.703f, 0.864f),
                    new Vector2(0.596f, 0.640f),
                    new Vector2(0.850f, 0.296f),
                    new Vector2(0.463f, 0.357f),
                    new Vector2(0.708f, 0.813f),
                    new Vector2(0.615f, 0.860f),
                    new Vector2(0.541f, 0.815f),
                    new Vector2(0.075f, 0.326f),
                    new Vector2(0.771f, 0.646f)
                )
            )
            .Add
            (
                new Guid("7484e4fb-88fb-48ca-aa57-be16cb2adbf5"),
                ImmutableArray.Create
                (
                    new Vector2(0.332f, 0.009f),
                    new Vector2(0.926f, 0.773f),
                    new Vector2(0.770f, 0.172f),
                    new Vector2(0.394f, 0.817f),
                    new Vector2(0.118f, 0.765f),
                    new Vector2(0.137f, 0.774f),
                    new Vector2(0.439f, 0.251f),
                    new Vector2(0.560f, 0.207f),
                    new Vector2(0.100f, 0.538f),
                    new Vector2(0.774f, 0.398f)
                )
            )
            .Add
            (
                new Guid("7b8243f1-289c-4f29-85cd-f461ea3f7ac7"),
                ImmutableArray.Create
                (
                    new Vector2(0.216f, 0.420f),
                    new Vector2(0.896f, 0.760f),
                    new Vector2(0.528f, 0.009f),
                    new Vector2(0.590f, 0.698f),
                    new Vector2(0.497f, 0.826f),
                    new Vector2(0.739f, 0.253f),
                    new Vector2(0.939f, 0.911f),
                    new Vector2(0.442f, 0.380f),
                    new Vector2(0.338f, 0.725f),
                    new Vector2(0.454f, 0.621f)
                )
            );

        internal static readonly ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>> Colors = ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>>
            .Empty
            .Add
            (
                new Guid("4a17b386-9449-4c7b-8379-36f006fc79a7"),
                ImmutableArray.Create
                (
                    new ColorWithOpacity(0x21, 0x0f, 0xb3, 0x82),
                    new ColorWithOpacity(0x9f, 0x5f, 0x1e, 0xa1),
                    new ColorWithOpacity(0x93, 0x20, 0x56, 0xa6),
                    new ColorWithOpacity(0x55, 0xaf, 0x03, 0xef),
                    new ColorWithOpacity(0xc3, 0x54, 0x9a, 0xcf),
                    new ColorWithOpacity(0x38, 0x1e, 0xc9, 0x64),
                    new ColorWithOpacity(0x9f, 0x43, 0x9b, 0x58),
                    new ColorWithOpacity(0xa3, 0x6a, 0xa0, 0xb3),
                    new ColorWithOpacity(0x05, 0x7b, 0x65, 0xb0),
                    new ColorWithOpacity(0xf6, 0xd0, 0x6b, 0x07)
                )
            )
            .Add
            (
                new Guid("cff5a70f-f345-449a-b8e5-2fffc41013be"),
                ImmutableArray.Create
                (
                    new ColorWithOpacity(0x22, 0xb7, 0x09, 0x2d),
                    new ColorWithOpacity(0xe1, 0xf7, 0x61, 0xd7),
                    new ColorWithOpacity(0x13, 0xeb, 0x52, 0x24),
                    new ColorWithOpacity(0x6a, 0x92, 0x54, 0xf4),
                    new ColorWithOpacity(0x8a, 0x67, 0xba, 0xb5),
                    new ColorWithOpacity(0x65, 0x77, 0x96, 0x93),
                    new ColorWithOpacity(0xc6, 0xae, 0xcd, 0x65),
                    new ColorWithOpacity(0x76, 0xff, 0x88, 0xcc),
                    new ColorWithOpacity(0x70, 0xbd, 0x51, 0xb8),
                    new ColorWithOpacity(0x8a, 0xa0, 0xfd, 0xf5)
                )
            )
            .Add
            (
                new Guid("78a06162-12c3-49b6-a4d4-b2b2201e0fd4"),
                ImmutableArray.Create
                (
                    new ColorWithOpacity(0x48, 0x28, 0x6e, 0xd7),
                    new ColorWithOpacity(0x60, 0x22, 0x44, 0xa3),
                    new ColorWithOpacity(0xe6, 0xf7, 0x67, 0x15),
                    new ColorWithOpacity(0xc9, 0x90, 0xcf, 0xa1),
                    new ColorWithOpacity(0x1d, 0x65, 0x49, 0xda),
                    new ColorWithOpacity(0x5a, 0xa4, 0xb8, 0x95),
                    new ColorWithOpacity(0xe5, 0xad, 0x04, 0xc4),
                    new ColorWithOpacity(0x53, 0x7e, 0xbe, 0x69),
                    new ColorWithOpacity(0xba, 0xdb, 0x77, 0xd9),
                    new ColorWithOpacity(0x69, 0xd5, 0xd8, 0xaf)
                )
            )
            .Add
            (
                new Guid("1f4bcf41-d352-4f2a-95fd-6544d3f88149"),
                ImmutableArray.Create
                (
                    new ColorWithOpacity(0x19, 0x46, 0x43, 0xa9),
                    new ColorWithOpacity(0xd8, 0x8c, 0xa1, 0xfc),
                    new ColorWithOpacity(0x4b, 0x7b, 0xda, 0x9e),
                    new ColorWithOpacity(0x57, 0x36, 0x4a, 0xbd),
                    new ColorWithOpacity(0x7b, 0xc5, 0x3f, 0x9a),
                    new ColorWithOpacity(0x70, 0xbd, 0xaa, 0x61),
                    new ColorWithOpacity(0x5d, 0xa1, 0xaa, 0x4a),
                    new ColorWithOpacity(0x00, 0xc8, 0xff, 0x19),
                    new ColorWithOpacity(0xb8, 0xdb, 0x9c, 0x30),
                    new ColorWithOpacity(0x41, 0xbf, 0x77, 0xc6)
                )
            );

        internal static readonly ImmutableSortedSet<Guid> Transforms = ImmutableSortedSet.Create
        (
            new Guid("7f9fcb78-7a0f-4a1c-ab2e-c6e9cfd7e6dc"),
            new Guid("345bb841-ed88-4070-8b46-6f9d3821ae2d"),
            new Guid("4eec9562-858a-4c5f-b33b-eb2fdcb37b25"),
            new Guid("a13ee51b-17cb-470d-99f1-083d5fae5256"),
            new Guid("045eca75-c57b-45c9-bb4f-9b196a8ca142"),
            new Guid("c35a9015-9500-4331-b5bf-525160dfe918")
        );

        internal static readonly ImmutableArray<byte> FirstTransformIndices = ImmutableArray.Create<byte>(1, 0, 4, 2, 1, 5, 3, 0, 4, 2);
        internal static readonly ImmutableArray<byte> SecondTransformIndices = ImmutableArray.Create<byte>(2, 0, 1, 4, 5, 0, 0, 1, 3, 1);
        internal static readonly ImmutableArray<byte> TransformBlendFactors = ImmutableArray.Create<byte>(0x08, 0x1d, 0xe7, 0x6f, 0xe0, 0x4b, 0xab, 0xe6, 0xa4, 0xc2);
        internal static readonly ImmutableArray<ushort> Indices = ImmutableArray.Create<ushort>(3, 0, 6, 9, 5, 8);

        internal static readonly ImmutableArray<byte> SerializedTransforms = ImmutableArray.Create<byte>
        (
            // Quantity.
            6,

            // Identifiers.
            0x04, 0x5e, 0xca, 0x75, 0xc5, 0x7b, 0x45, 0xc9, 0xbb, 0x4f, 0x9b, 0x19, 0x6a, 0x8c, 0xa1, 0x42,
            0x34, 0x5b, 0xb8, 0x41, 0xed, 0x88, 0x40, 0x70, 0x8b, 0x46, 0x6f, 0x9d, 0x38, 0x21, 0xae, 0x2d,
            0x4e, 0xec, 0x95, 0x62, 0x85, 0x8a, 0x4c, 0x5f, 0xb3, 0x3b, 0xeb, 0x2f, 0xdc, 0xb3, 0x7b, 0x25,
            0x7f, 0x9f, 0xcb, 0x78, 0x7a, 0x0f, 0x4a, 0x1c, 0xab, 0x2e, 0xc6, 0xe9, 0xcf, 0xd7, 0xe6, 0xdc,
            0xa1, 0x3e, 0xe5, 0x1b, 0x17, 0xcb, 0x47, 0x0d, 0x99, 0xf1, 0x08, 0x3d, 0x5f, 0xae, 0x52, 0x56,
            0xc3, 0x5a, 0x90, 0x15, 0x95, 0x00, 0x43, 0x31, 0xb5, 0xbf, 0x52, 0x51, 0x60, 0xdf, 0xe9, 0x18
        );

        internal static readonly ImmutableArray<byte> SerializedFirstTransformPositions = ImmutableArray.Create<byte>
        (
            0x73, 0x68, 0x31, 0x3f, 0xe5, 0xd0, 0x42, 0x3f, 0x3f, 0x35, 0x7e, 0x3f,
            0x19, 0x04, 0x16, 0x3f, 0x0c, 0x02, 0x6b, 0x3f, 0x37, 0x89, 0x41, 0x3e,
            0x06, 0x81, 0x95, 0x3d, 0x50, 0x8d, 0x37, 0x3f, 0x48, 0xe1, 0xba, 0x3e,
            0xaa, 0xf1, 0xd2, 0x3d, 0xf6, 0x28, 0xdc, 0x3e, 0xae, 0x47, 0x41, 0x3f,
            0x4a, 0x0c, 0x22, 0x3f, 0x21, 0xb0, 0x52, 0x3f, 0x50, 0x8d, 0x57, 0x3f,
            0x89, 0x41, 0x40, 0x3f, 0xcb, 0xa1, 0xc5, 0x3e, 0xd3, 0x4d, 0x42, 0x3f,
            0x91, 0xed, 0xfc, 0x3e, 0x31, 0x08, 0xac, 0x3d, 0xcf, 0xf7, 0x53, 0x3f,
            0xb8, 0x1e, 0x45, 0x3f, 0xe7, 0xfb, 0x69, 0x3f, 0x35, 0x5e, 0xba, 0x3e,
            0x93, 0x18, 0xc4, 0x3e, 0xe9, 0x26, 0xf1, 0x3e, 0x7d, 0x3f, 0xb5, 0x3e,
            0x60, 0xe5, 0x10, 0x3f, 0x62, 0x10, 0x78, 0x3f, 0xc1, 0xca, 0x61, 0x3f
        );

        internal static readonly ImmutableArray<byte> SerializedFirstTransformNormals = ImmutableArray.Create<byte>
        (
            0xb4, 0xc8, 0x76, 0x3e, 0x42, 0x60, 0x65, 0x3f, 0xa6, 0x9b, 0x44, 0x3e,
            0x08, 0xac, 0x9c, 0x3e, 0x58, 0x39, 0x54, 0x3f, 0xc9, 0x76, 0xbe, 0x3e,
            0x19, 0x04, 0x56, 0x3f, 0xf6, 0x28, 0x3c, 0x3f, 0xa0, 0x1a, 0xef, 0x3e,
            0x3f, 0x35, 0x1e, 0x3f, 0x25, 0x06, 0x61, 0x3f, 0x19, 0x04, 0x56, 0x3f,
            0x17, 0xd9, 0xce, 0x3e, 0x56, 0x0e, 0x2d, 0x3f, 0xd1, 0x22, 0x1b, 0x3f,
            0xe7, 0xfb, 0xa9, 0x3e, 0x29, 0x5c, 0x6f, 0x3f, 0xd7, 0xa3, 0x70, 0x3e,
            0xfc, 0xa9, 0x71, 0x3e, 0xe7, 0xfb, 0x29, 0x3f, 0x1f, 0x85, 0xab, 0x3e,
            0x60, 0xe5, 0x10, 0x3f, 0xc1, 0xca, 0xe1, 0x3e, 0x48, 0xe1, 0xba, 0x3e,
            0xa6, 0x9b, 0xc4, 0x3e, 0x8d, 0x97, 0x2e, 0x3f, 0x58, 0x39, 0x34, 0x3d,
            0x7f, 0x6a, 0x5c, 0x3f, 0xcd, 0xcc, 0x2c, 0x3f, 0x33, 0x33, 0xf3, 0x3e
        );

        internal static readonly ImmutableArray<byte> SerializedFirstTransformTangents = ImmutableArray.Create<byte>
        (
            0x50, 0x8d, 0x97, 0x3d, 0x5c, 0x8f, 0x42, 0x3f, 0x23, 0xdb, 0x79, 0x3f,
            0x31, 0x08, 0xac, 0x3e, 0xf4, 0xfd, 0x14, 0x3f, 0xee, 0x7c, 0x7f, 0x3f,
            0xd3, 0x4d, 0x02, 0x3f, 0x31, 0x08, 0xac, 0x3d, 0x52, 0xb8, 0x9e, 0x3e,
            0x56, 0x0e, 0x2d, 0x3f, 0xf6, 0x28, 0x9c, 0x3e, 0x1f, 0x85, 0x4b, 0x3f,
            0xd1, 0x22, 0x9b, 0x3e, 0x91, 0xed, 0x1c, 0x3f, 0x6a, 0xbc, 0x34, 0x3f,
            0x77, 0xbe, 0x1f, 0x3d, 0xd3, 0x4d, 0xe2, 0x3e, 0xee, 0x7c, 0x3f, 0x3f,
            0xd7, 0xa3, 0xf0, 0x3e, 0xf2, 0xd2, 0x4d, 0x3e, 0x44, 0x8b, 0xac, 0x3e,
            0xb0, 0x72, 0x28, 0x3f, 0x3b, 0xdf, 0x8f, 0x3e, 0xfa, 0x7e, 0xea, 0x3e,
            0x5c, 0x8f, 0xc2, 0x3e, 0xf0, 0xa7, 0x46, 0x3f, 0x04, 0x56, 0x0e, 0x3f,
            0x25, 0x06, 0x41, 0x3f, 0xbc, 0x74, 0x13, 0x3c, 0xfe, 0xd4, 0x38, 0x3f
        );

        internal static readonly ImmutableArray<byte> SerializedFirstTransformBitangents = ImmutableArray.Create<byte>
        (
            0xfc, 0xa9, 0x31, 0x3f, 0x52, 0xb8, 0x1e, 0x3f, 0xf6, 0x28, 0x9c, 0x3e,
            0x1b, 0x2f, 0xdd, 0x3e, 0xd3, 0x4d, 0xa2, 0x3e, 0x9a, 0x99, 0x39, 0x3f,
            0x93, 0x18, 0x04, 0x3f, 0xb2, 0x9d, 0x4f, 0x3f, 0x04, 0x56, 0x6e, 0x3f,
            0x1f, 0x85, 0xeb, 0x3d, 0xf4, 0xfd, 0x34, 0x3f, 0x54, 0xe3, 0x65, 0x3f,
            0x3d, 0x0a, 0xd7, 0x3d, 0xcb, 0xa1, 0x85, 0x3e, 0xec, 0x51, 0x78, 0x3f,
            0x31, 0x08, 0xac, 0x3e, 0x9c, 0xc4, 0xe0, 0x3e, 0xe3, 0xa5, 0x1b, 0x3d,
            0xcf, 0xf7, 0x33, 0x3f, 0x50, 0x8d, 0x37, 0x3f, 0x37, 0x89, 0x81, 0x3e,
            0xac, 0x1c, 0x5a, 0x3e, 0xb4, 0xc8, 0xb6, 0x3e, 0xbe, 0x9f, 0x1a, 0x3e,
            0xa6, 0x9b, 0xc4, 0x3c, 0xc9, 0x76, 0x3e, 0x3e, 0x29, 0x5c, 0x0f, 0x3f,
            0x2d, 0xb2, 0x9d, 0x3d, 0x3b, 0xdf, 0x2f, 0x3f, 0x4e, 0x62, 0x10, 0x3f
        );

        internal static readonly ImmutableArray<byte> SerializedSecondTransformPositions = ImmutableArray.Create<byte>
        (
            0x44, 0x8b, 0x4c, 0x3f, 0x4c, 0x37, 0x89, 0x3d, 0x7d, 0x3f, 0xf5, 0x3e,
            0x98, 0x6e, 0x12, 0x3e, 0x31, 0x08, 0x2c, 0x3f, 0xc9, 0x76, 0x1e, 0x3f,
            0xd5, 0x78, 0xe9, 0x3e, 0xc9, 0x76, 0x1e, 0x3f, 0xc3, 0xf5, 0x28, 0x3e,
            0x60, 0xe5, 0x50, 0x3f, 0x52, 0xb8, 0x1e, 0x3e, 0x66, 0x66, 0x06, 0x3f,
            0xe1, 0x7a, 0xd4, 0x3e, 0x96, 0x43, 0x0b, 0x3e, 0xf4, 0xfd, 0x14, 0x3f,
            0xb0, 0x72, 0x28, 0x3f, 0x77, 0xbe, 0x1f, 0x3e, 0x4a, 0x0c, 0x02, 0x3e,
            0x7b, 0x14, 0x6e, 0x3f, 0x02, 0x2b, 0x67, 0x3f, 0x1b, 0x2f, 0x9d, 0x3e,
            0x1f, 0x85, 0xab, 0x3e, 0x68, 0x91, 0x2d, 0x3f, 0x50, 0x8d, 0x57, 0x3f,
            0x79, 0xe9, 0x06, 0x3f, 0xe1, 0x7a, 0x14, 0x3e, 0x8b, 0x6c, 0x27, 0x3f,
            0xd9, 0xce, 0x17, 0x3f, 0xae, 0x47, 0x41, 0x3f, 0x81, 0x95, 0xc3, 0x3e
        );

        internal static readonly ImmutableArray<byte> SerializedSecondTransformNormals = ImmutableArray.Create<byte>
        (
            0x62, 0x10, 0xd8, 0x3e, 0x83, 0xc0, 0x0a, 0x3f, 0x75, 0x93, 0x98, 0x3e,
            0x79, 0xe9, 0x06, 0x3f, 0x9a, 0x99, 0x59, 0x3f, 0x48, 0xe1, 0xba, 0x3e,
            0x19, 0x04, 0x16, 0x3f, 0x0e, 0x2d, 0x32, 0x3e, 0xae, 0x47, 0x61, 0x3e,
            0xee, 0x7c, 0x3f, 0x3f, 0x8f, 0xc2, 0x75, 0x3d, 0x71, 0x3d, 0x6a, 0x3f,
            0x39, 0xb4, 0x08, 0x3f, 0x4c, 0x37, 0x09, 0x3f, 0x12, 0x83, 0x40, 0x3f,
            0xe1, 0x7a, 0x94, 0x3e, 0x19, 0x04, 0x56, 0x3e, 0x21, 0xb0, 0x12, 0x3f,
            0x5a, 0x64, 0xfb, 0x3e, 0xec, 0x51, 0xb8, 0x3e, 0x3d, 0x0a, 0xd7, 0x3e,
            0xe5, 0xd0, 0xa2, 0x3e, 0xf4, 0xfd, 0x54, 0x3f, 0xe7, 0xfb, 0x29, 0x3f,
            0x3f, 0x35, 0x1e, 0x3f, 0xb4, 0xc8, 0x76, 0x3f, 0xb8, 0x1e, 0x85, 0x3d,
            0x35, 0x5e, 0x3a, 0x3e, 0x75, 0x93, 0x18, 0x3e, 0x79, 0xe9, 0x26, 0x3e
        );

        internal static readonly ImmutableArray<byte> SerializedSecondTransformTangents = ImmutableArray.Create<byte>
        (
            0x8f, 0xc2, 0xf5, 0x3c, 0xbc, 0x74, 0x33, 0x3f, 0xc5, 0x20, 0xb0, 0x3d,
            0x73, 0x68, 0x31, 0x3f, 0x21, 0xb0, 0xf2, 0x3e, 0x3b, 0xdf, 0x8f, 0x3e,
            0x37, 0x89, 0x81, 0x3e, 0xc7, 0x4b, 0x57, 0x3f, 0x87, 0x16, 0xd9, 0x3d,
            0xd5, 0x78, 0x29, 0x3f, 0x58, 0x39, 0x34, 0x3c, 0xcd, 0xcc, 0xcc, 0x3e,
            0x83, 0xc0, 0x0a, 0x3f, 0xdf, 0x4f, 0x8d, 0x3e, 0xfc, 0xa9, 0xf1, 0x3e,
            0x8d, 0x97, 0xae, 0x3e, 0x66, 0x66, 0x46, 0x3f, 0xf4, 0xfd, 0x54, 0x3e,
            0xc5, 0x20, 0x50, 0x3f, 0x27, 0x31, 0xc8, 0x3e, 0x2f, 0xdd, 0x04, 0x3f,
            0x17, 0xd9, 0x8e, 0x3e, 0xf6, 0x28, 0x3c, 0x3f, 0xf4, 0xfd, 0x54, 0x3e,
            0x3d, 0x0a, 0x57, 0x3f, 0xe7, 0xfb, 0x29, 0x3e, 0xcf, 0xf7, 0x53, 0x3f,
            0xf2, 0xd2, 0x2d, 0x3f, 0x71, 0x3d, 0x6a, 0x3f, 0x9a, 0x99, 0x79, 0x3f
        );

        internal static readonly ImmutableArray<byte> SerializedSecondTransformBitangents = ImmutableArray.Create<byte>
        (
            0x02, 0x2b, 0x07, 0x3e, 0x58, 0x39, 0x34, 0x3f, 0x85, 0xeb, 0x71, 0x3f,
            0x02, 0x2b, 0x07, 0x3f, 0x60, 0xe5, 0xd0, 0x3d, 0x29, 0x5c, 0x0f, 0x3d,
            0x2b, 0x87, 0x16, 0x3f, 0x37, 0x89, 0x21, 0x3f, 0xf0, 0xa7, 0xc6, 0x3e,
            0x5e, 0xba, 0x09, 0x3f, 0xb4, 0xc8, 0x56, 0x3f, 0x83, 0xc0, 0x6a, 0x3f,
            0x5a, 0x64, 0xbb, 0x3e, 0xba, 0x49, 0x0c, 0x3e, 0xb4, 0xc8, 0x76, 0x3f,
            0x1f, 0x85, 0x4b, 0x3f, 0x6d, 0xe7, 0x5b, 0x3f, 0xcf, 0xf7, 0xd3, 0x3e,
            0x71, 0x3d, 0x0a, 0x3e, 0xf6, 0x28, 0x9c, 0x3e, 0x98, 0x6e, 0x72, 0x3f,
            0x06, 0x81, 0x95, 0x3e, 0xba, 0x49, 0x6c, 0x3f, 0x0a, 0xd7, 0x03, 0x3f,
            0x1d, 0x5a, 0xe4, 0x3e, 0x4c, 0x37, 0x69, 0x3f, 0xe1, 0x7a, 0x34, 0x3f,
            0xc3, 0xf5, 0x28, 0x3e, 0xe9, 0x26, 0xb1, 0x3e, 0x5a, 0x64, 0x3b, 0x3e
        );

        internal static readonly ImmutableArray<byte> SerializedTextureMaps = ImmutableArray.Create<byte>
        (
            // Quantity.
            3,

            // Identifiers.
            0x74, 0x84, 0xe4, 0xfb, 0x88, 0xfb, 0x48, 0xca, 0xaa, 0x57, 0xbe, 0x16, 0xcb, 0x2a, 0xdb, 0xf5,
            0x7b, 0x82, 0x43, 0xf1, 0x28, 0x9c, 0x4f, 0x29, 0x85, 0xcd, 0xf4, 0x61, 0xea, 0x3f, 0x7a, 0xc7,
            0xd6, 0x12, 0xd2, 0xaf, 0x79, 0x8a, 0x4e, 0x66, 0x89, 0x36, 0x12, 0xfc, 0x61, 0xfc, 0xa7, 0xe3,

            // Coordinates.
            0xe7, 0xfb, 0xa9, 0x3e, 0xbc, 0x74, 0x13, 0x3c,
            0x56, 0x0e, 0x6d, 0x3f, 0x54, 0xe3, 0x45, 0x3f,
            0xb8, 0x1e, 0x45, 0x3f, 0xc5, 0x20, 0x30, 0x3e,
            0x5e, 0xba, 0xc9, 0x3e, 0xe9, 0x26, 0x51, 0x3f,
            0xfc, 0xa9, 0xf1, 0x3d, 0x0a, 0xd7, 0x43, 0x3f,
            0xba, 0x49, 0x0c, 0x3e, 0xdd, 0x24, 0x46, 0x3f,
            0x9c, 0xc4, 0xe0, 0x3e, 0x12, 0x83, 0x80, 0x3e,
            0x29, 0x5c, 0x0f, 0x3f, 0xcf, 0xf7, 0x53, 0x3e,
            0xcd, 0xcc, 0xcc, 0x3d, 0x5e, 0xba, 0x09, 0x3f,
            0xdd, 0x24, 0x46, 0x3f, 0xa8, 0xc6, 0xcb, 0x3e,
            
            0x1b, 0x2f, 0x5d, 0x3e, 0x3d, 0x0a, 0xd7, 0x3e,
            0x42, 0x60, 0x65, 0x3f, 0x5c, 0x8f, 0x42, 0x3f,
            0x02, 0x2b, 0x07, 0x3f, 0xbc, 0x74, 0x13, 0x3c,
            0x3d, 0x0a, 0x17, 0x3f, 0x21, 0xb0, 0x32, 0x3f,
            0xc9, 0x76, 0xfe, 0x3e, 0xbc, 0x74, 0x53, 0x3f,
            0x1b, 0x2f, 0x3d, 0x3f, 0x37, 0x89, 0x81, 0x3e,
            0x4e, 0x62, 0x70, 0x3f, 0x4c, 0x37, 0x69, 0x3f,
            0xd3, 0x4d, 0xe2, 0x3e, 0x5c, 0x8f, 0xc2, 0x3e,
            0x56, 0x0e, 0xad, 0x3e, 0x9a, 0x99, 0x39, 0x3f,
            0xb0, 0x72, 0xe8, 0x3e, 0xdb, 0xf9, 0x1e, 0x3f,

            0x6d, 0xe7, 0xbb, 0x3e, 0x77, 0xbe, 0x1f, 0x3d,
            0xcf, 0xf7, 0x33, 0x3f, 0x1b, 0x2f, 0x5d, 0x3f,
            0x75, 0x93, 0x18, 0x3f, 0x0a, 0xd7, 0x23, 0x3f,
            0x9a, 0x99, 0x59, 0x3f, 0x50, 0x8d, 0x97, 0x3e,
            0x56, 0x0e, 0xed, 0x3e, 0xb4, 0xc8, 0xb6, 0x3e,
            0x7d, 0x3f, 0x35, 0x3f, 0xc5, 0x20, 0x50, 0x3f,
            0xa4, 0x70, 0x1d, 0x3f, 0xf6, 0x28, 0x5c, 0x3f,
            0xfa, 0x7e, 0x0a, 0x3f, 0xd7, 0xa3, 0x50, 0x3f,
            0x9a, 0x99, 0x99, 0x3d, 0x79, 0xe9, 0xa6, 0x3e,
            0x42, 0x60, 0x45, 0x3f, 0x42, 0x60, 0x25, 0x3f
        );

        internal static readonly ImmutableArray<byte> SerializedColorLayers = ImmutableArray.Create<byte>
        (
            // Quantity.
            4,

            // Identifiers.
            0x1f, 0x4b, 0xcf, 0x41, 0xd3, 0x52, 0x4f, 0x2a, 0x95, 0xfd, 0x65, 0x44, 0xd3, 0xf8, 0x81, 0x49,
            0x4a, 0x17, 0xb3, 0x86, 0x94, 0x49, 0x4c, 0x7b, 0x83, 0x79, 0x36, 0xf0, 0x06, 0xfc, 0x79, 0xa7,
            0x78, 0xa0, 0x61, 0x62, 0x12, 0xc3, 0x49, 0xb6, 0xa4, 0xd4, 0xb2, 0xb2, 0x20, 0x1e, 0x0f, 0xd4,
            0xcf, 0xf5, 0xa7, 0x0f, 0xf3, 0x45, 0x44, 0x9a, 0xb8, 0xe5, 0x2f, 0xff, 0xc4, 0x10, 0x13, 0xbe,

            // Colors.
            0x19, 0x46, 0x43, 0xa9,
            0xd8, 0x8c, 0xa1, 0xfc,
            0x4b, 0x7b, 0xda, 0x9e,
            0x57, 0x36, 0x4a, 0xbd,
            0x7b, 0xc5, 0x3f, 0x9a,
            0x70, 0xbd, 0xaa, 0x61,
            0x5d, 0xa1, 0xaa, 0x4a,
            0x00, 0xc8, 0xff, 0x19,
            0xb8, 0xdb, 0x9c, 0x30,
            0x41, 0xbf, 0x77, 0xc6,
            
            0x21, 0x0f, 0xb3, 0x82,
            0x9f, 0x5f, 0x1e, 0xa1,
            0x93, 0x20, 0x56, 0xa6,
            0x55, 0xaf, 0x03, 0xef,
            0xc3, 0x54, 0x9a, 0xcf,
            0x38, 0x1e, 0xc9, 0x64,
            0x9f, 0x43, 0x9b, 0x58,
            0xa3, 0x6a, 0xa0, 0xb3,
            0x05, 0x7b, 0x65, 0xb0,
            0xf6, 0xd0, 0x6b, 0x07,
            
            0x48, 0x28, 0x6e, 0xd7,
            0x60, 0x22, 0x44, 0xa3,
            0xe6, 0xf7, 0x67, 0x15,
            0xc9, 0x90, 0xcf, 0xa1,
            0x1d, 0x65, 0x49, 0xda,
            0x5a, 0xa4, 0xb8, 0x95,
            0xe5, 0xad, 0x04, 0xc4,
            0x53, 0x7e, 0xbe, 0x69,
            0xba, 0xdb, 0x77, 0xd9,
            0x69, 0xd5, 0xd8, 0xaf,

            0x22, 0xb7, 0x09, 0x2d,
            0xe1, 0xf7, 0x61, 0xd7,
            0x13, 0xeb, 0x52, 0x24,
            0x6a, 0x92, 0x54, 0xf4,
            0x8a, 0x67, 0xba, 0xb5,
            0x65, 0x77, 0x96, 0x93,
            0xc6, 0xae, 0xcd, 0x65,
            0x76, 0xff, 0x88, 0xcc,
            0x70, 0xbd, 0x51, 0xb8,
            0x8a, 0xa0, 0xfd, 0xf5
        );

        internal static readonly ImmutableArray<byte> SerializedIndices = ImmutableArray.Create<byte>
        (
            // Number of indices.
            6, 0,

            // Indices.
            3, 0, 0, 0, 6, 0, 9, 0, 5, 0, 8, 0
        );

        internal static byte[] Concatenated(params IEnumerable<byte>[] arrays)
        {
            var output = new List<byte>();

            foreach (var array in arrays)
            {
                output.AddRange(array);
            }

            return output.ToArray();
        }

        [TestMethod]
        public void ExposesGivenDataWithAllOptionalElementsNull()
        {
            var mesh = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );

            Assert.AreEqual(Transforms, mesh.Transforms);
            Assert.AreEqual(FirstTransformIndices, mesh.FirstTransformIndices);
            Assert.AreEqual(FirstTransformPositions, mesh.FirstTransformPositions);
            Assert.IsNull(mesh.FirstTransformNormals);
            Assert.IsNull(mesh.FirstTransformTangents);
            Assert.IsNull(mesh.FirstTransformBitangents);
            Assert.AreEqual(SecondTransformIndices, mesh.SecondTransformIndices);
            Assert.AreEqual(SecondTransformPositions, mesh.SecondTransformPositions);
            Assert.IsNull(mesh.SecondTransformNormals);
            Assert.IsNull(mesh.SecondTransformTangents);
            Assert.IsNull(mesh.SecondTransformBitangents);
            Assert.AreEqual(TransformBlendFactors, mesh.TransformBlendFactors);
            Assert.AreEqual(TextureCoordinates, mesh.TextureCoordinates);
            Assert.AreEqual(Colors, mesh.Colors);
            Assert.AreEqual(Indices, mesh.Indices);
            CollectionAssert.AreEqual
            (
                Concatenated
                (
                    new byte[] { 0, 10, 0 },
                    SerializedTransforms,
                    FirstTransformIndices,
                    SerializedFirstTransformPositions,
                    SecondTransformIndices,
                    SerializedSecondTransformPositions,
                    TransformBlendFactors,
                    SerializedTextureMaps,
                    SerializedColorLayers,
                    SerializedIndices
                ),
                mesh.Serialized.ToArray()
            );
        }

        [TestMethod]
        public void ExposesGivenDataWithNormals()
        {
            var mesh = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                FirstTransformNormals,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                SecondTransformNormals,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );

            Assert.AreEqual(Transforms, mesh.Transforms);
            Assert.AreEqual(FirstTransformIndices, mesh.FirstTransformIndices);
            Assert.AreEqual(FirstTransformPositions, mesh.FirstTransformPositions);
            Assert.AreEqual(FirstTransformNormals, mesh.FirstTransformNormals);
            Assert.IsNull(mesh.FirstTransformTangents);
            Assert.IsNull(mesh.FirstTransformBitangents);
            Assert.AreEqual(SecondTransformIndices, mesh.SecondTransformIndices);
            Assert.AreEqual(SecondTransformPositions, mesh.SecondTransformPositions);
            Assert.AreEqual(SecondTransformNormals, mesh.SecondTransformNormals);
            Assert.IsNull(mesh.SecondTransformTangents);
            Assert.IsNull(mesh.SecondTransformBitangents);
            Assert.AreEqual(TransformBlendFactors, mesh.TransformBlendFactors);
            Assert.AreEqual(TextureCoordinates, mesh.TextureCoordinates);
            Assert.AreEqual(Colors, mesh.Colors);
            Assert.AreEqual(Indices, mesh.Indices);
            CollectionAssert.AreEqual
            (
                Concatenated
                (
                    new byte[] { 1, 10, 0 },
                    SerializedTransforms,
                    FirstTransformIndices,
                    SerializedFirstTransformPositions,
                    SerializedFirstTransformNormals,
                    SecondTransformIndices,
                    SerializedSecondTransformPositions,
                    SerializedSecondTransformNormals,
                    TransformBlendFactors,
                    SerializedTextureMaps,
                    SerializedColorLayers,
                    SerializedIndices
                ),
                mesh.Serialized.ToArray()
            );
        }

        [TestMethod]
        public void ExposesGivenDataWithTangents()
        {
            var mesh = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                FirstTransformTangents,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                SecondTransformTangents,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );

            Assert.AreEqual(Transforms, mesh.Transforms);
            Assert.AreEqual(FirstTransformIndices, mesh.FirstTransformIndices);
            Assert.AreEqual(FirstTransformPositions, mesh.FirstTransformPositions);
            Assert.IsNull(mesh.FirstTransformNormals);
            Assert.AreEqual(FirstTransformTangents, mesh.FirstTransformTangents);
            Assert.IsNull(mesh.FirstTransformBitangents);
            Assert.AreEqual(SecondTransformIndices, mesh.SecondTransformIndices);
            Assert.AreEqual(SecondTransformPositions, mesh.SecondTransformPositions);
            Assert.IsNull(mesh.SecondTransformNormals);
            Assert.AreEqual(SecondTransformTangents, mesh.SecondTransformTangents);
            Assert.IsNull(mesh.SecondTransformBitangents);
            Assert.AreEqual(TransformBlendFactors, mesh.TransformBlendFactors);
            Assert.AreEqual(TextureCoordinates, mesh.TextureCoordinates);
            Assert.AreEqual(Colors, mesh.Colors);
            Assert.AreEqual(Indices, mesh.Indices);
            CollectionAssert.AreEqual
            (
                Concatenated
                (
                    new byte[] { 2, 10, 0 },
                    SerializedTransforms,
                    FirstTransformIndices,
                    SerializedFirstTransformPositions,
                    SerializedFirstTransformTangents,
                    SecondTransformIndices,
                    SerializedSecondTransformPositions,
                    SerializedSecondTransformTangents,
                    TransformBlendFactors,
                    SerializedTextureMaps,
                    SerializedColorLayers,
                    SerializedIndices
                ),
                mesh.Serialized.ToArray()
            );
        }

        [TestMethod]
        public void ExposesGivenDataWithBitangents()
        {
            var mesh = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                FirstTransformBitangents,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                SecondTransformBitangents,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );

            Assert.AreEqual(Transforms, mesh.Transforms);
            Assert.AreEqual(FirstTransformIndices, mesh.FirstTransformIndices);
            Assert.AreEqual(FirstTransformPositions, mesh.FirstTransformPositions);
            Assert.IsNull(mesh.FirstTransformNormals);
            Assert.IsNull(mesh.FirstTransformTangents);
            Assert.AreEqual(FirstTransformBitangents, mesh.FirstTransformBitangents);
            Assert.AreEqual(SecondTransformIndices, mesh.SecondTransformIndices);
            Assert.AreEqual(SecondTransformPositions, mesh.SecondTransformPositions);
            Assert.IsNull(mesh.SecondTransformNormals);
            Assert.IsNull(mesh.SecondTransformTangents);
            Assert.AreEqual(SecondTransformBitangents, mesh.SecondTransformBitangents);
            Assert.AreEqual(TransformBlendFactors, mesh.TransformBlendFactors);
            Assert.AreEqual(TextureCoordinates, mesh.TextureCoordinates);
            Assert.AreEqual(Colors, mesh.Colors);
            Assert.AreEqual(Indices, mesh.Indices);
            CollectionAssert.AreEqual
            (
                Concatenated
                (
                    new byte[] { 4, 10, 0 },
                    SerializedTransforms,
                    FirstTransformIndices,
                    SerializedFirstTransformPositions,
                    SerializedFirstTransformBitangents,
                    SecondTransformIndices,
                    SerializedSecondTransformPositions,
                    SerializedSecondTransformBitangents,
                    TransformBlendFactors,
                    SerializedTextureMaps,
                    SerializedColorLayers,
                    SerializedIndices
                ),
                mesh.Serialized.ToArray()
            );
        }

        [TestMethod]
        public void ExposesGivenDataWithAllOptionalFields()
        {
            var mesh = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                FirstTransformNormals,
                FirstTransformTangents,
                FirstTransformBitangents,
                SecondTransformIndices,
                SecondTransformPositions,
                SecondTransformNormals,
                SecondTransformTangents,
                SecondTransformBitangents,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );

            Assert.AreEqual(Transforms, mesh.Transforms);
            Assert.AreEqual(FirstTransformIndices, mesh.FirstTransformIndices);
            Assert.AreEqual(FirstTransformPositions, mesh.FirstTransformPositions);
            Assert.AreEqual(FirstTransformNormals, mesh.FirstTransformNormals);
            Assert.AreEqual(FirstTransformTangents, mesh.FirstTransformTangents);
            Assert.AreEqual(FirstTransformBitangents, mesh.FirstTransformBitangents);
            Assert.AreEqual(SecondTransformIndices, mesh.SecondTransformIndices);
            Assert.AreEqual(SecondTransformPositions, mesh.SecondTransformPositions);
            Assert.AreEqual(SecondTransformNormals, mesh.SecondTransformNormals);
            Assert.AreEqual(SecondTransformTangents, mesh.SecondTransformTangents);
            Assert.AreEqual(SecondTransformBitangents, mesh.SecondTransformBitangents);
            Assert.AreEqual(TransformBlendFactors, mesh.TransformBlendFactors);
            Assert.AreEqual(TextureCoordinates, mesh.TextureCoordinates);
            Assert.AreEqual(Colors, mesh.Colors);
            Assert.AreEqual(Indices, mesh.Indices);
            CollectionAssert.AreEqual
            (
                Concatenated
                (
                    new byte[] { 7, 10, 0 },
                    SerializedTransforms,
                    FirstTransformIndices,
                    SerializedFirstTransformPositions,
                    SerializedFirstTransformNormals,
                    SerializedFirstTransformTangents,
                    SerializedFirstTransformBitangents,
                    SecondTransformIndices,
                    SerializedSecondTransformPositions,
                    SerializedSecondTransformNormals,
                    SerializedSecondTransformTangents,
                    SerializedSecondTransformBitangents,
                    TransformBlendFactors,
                    SerializedTextureMaps,
                    SerializedColorLayers,
                    SerializedIndices
                ),
                mesh.Serialized.ToArray()
            );
        }

        [TestMethod]
        public void AllowsLargeDatasets()
        {
            var transforms = Generate.Guids(255);
            var firstTransformIndices = Enumerable.Range(0, 65535).Select(x => (byte)(Generate.Byte() % 255)).ToImmutableArray();
            var firstTransformPositions = Generate.Vector3s(65535);
            var firstTransformNormals = Generate.Vector3s(65535);
            var firstTransformTangents = Generate.Vector3s(65535);
            var firstTransformBitangents = Generate.Vector3s(65535);
            var secondTransformIndices = Enumerable.Range(0, 65535).Select(x => (byte)(Generate.Byte() % 255)).ToImmutableArray();
            var secondTransformPositions = Generate.Vector3s(65535);
            var secondTransformNormals = Generate.Vector3s(65535);
            var secondTransformTangents = Generate.Vector3s(65535);
            var secondTransformBitangents = Generate.Vector3s(65535);
            var transformBlendFactors = Generate.Bytes(65535);
            var textureCoordinates = ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>>.Empty;
            while (textureCoordinates.Count < 255)
            {
                textureCoordinates = textureCoordinates.Add(Guid.NewGuid(), Generate.Vector2s(65535));
            }
            var colors = ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>>.Empty;
            while (colors.Count < 255)
            {
                colors = colors.Add(Guid.NewGuid(), Generate.ColorsWithOpacity(65535));
            }
            var indices = Enumerable.Range(0, 65535).Select(x => (ushort)(Generate.Ushort() % 65535)).ToImmutableArray();

            var mesh = new Mesh
            (
                transforms,
                firstTransformIndices,
                firstTransformPositions,
                firstTransformNormals,
                firstTransformTangents,
                firstTransformBitangents,
                secondTransformIndices,
                secondTransformPositions,
                secondTransformNormals,
                secondTransformTangents,
                secondTransformBitangents,
                transformBlendFactors,
                textureCoordinates,
                colors,
                indices
            );

            Assert.AreEqual(transforms, mesh.Transforms);
            Assert.AreEqual(firstTransformIndices, mesh.FirstTransformIndices);
            Assert.AreEqual(firstTransformPositions, mesh.FirstTransformPositions);
            Assert.AreEqual(firstTransformNormals, mesh.FirstTransformNormals);
            Assert.AreEqual(firstTransformTangents, mesh.FirstTransformTangents);
            Assert.AreEqual(firstTransformBitangents, mesh.FirstTransformBitangents);
            Assert.AreEqual(secondTransformIndices, mesh.SecondTransformIndices);
            Assert.AreEqual(secondTransformPositions, mesh.SecondTransformPositions);
            Assert.AreEqual(secondTransformNormals, mesh.SecondTransformNormals);
            Assert.AreEqual(secondTransformTangents, mesh.SecondTransformTangents);
            Assert.AreEqual(secondTransformBitangents, mesh.SecondTransformBitangents);
            Assert.AreEqual(transformBlendFactors, mesh.TransformBlendFactors);
            Assert.AreEqual(textureCoordinates, mesh.TextureCoordinates);
            Assert.AreEqual(colors, mesh.Colors);
            Assert.AreEqual(indices, mesh.Indices);
        }

        [TestMethod]
        public void AllowsSmallDatasets()
        {
                var transforms = Generate.Guids(1);
                var firstTransformIndices = ImmutableArray.Create<byte>(0);
                var firstTransformPositions = Generate.Vector3s(1);
                var firstTransformNormals = Generate.Vector3s(1);
                var firstTransformTangents = Generate.Vector3s(1);
                var firstTransformBitangents = Generate.Vector3s(1);
                var secondTransformIndices = ImmutableArray.Create<byte>(0);
                var secondTransformPositions = Generate.Vector3s(1);
                var secondTransformNormals = Generate.Vector3s(1);
                var secondTransformTangents = Generate.Vector3s(1);
                var secondTransformBitangents = Generate.Vector3s(1);
                var transformBlendFactors = Generate.Bytes(1);
                var textureCoordinates = ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>>.Empty;
                var colors = ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>>.Empty;
                var indices = ImmutableArray.Create<ushort>(0, 0, 0);

            var mesh = new Mesh
            (
                transforms,
                firstTransformIndices,
                firstTransformPositions,
                firstTransformNormals,
                firstTransformTangents,
                firstTransformBitangents,
                secondTransformIndices,
                secondTransformPositions,
                secondTransformNormals,
                secondTransformTangents,
                secondTransformBitangents,
                transformBlendFactors,
                textureCoordinates,
                colors,
                indices
            );

            Assert.AreEqual(transforms, mesh.Transforms);
            Assert.AreEqual(firstTransformIndices, mesh.FirstTransformIndices);
            Assert.AreEqual(firstTransformPositions, mesh.FirstTransformPositions);
            Assert.AreEqual(firstTransformNormals, mesh.FirstTransformNormals);
            Assert.AreEqual(firstTransformTangents, mesh.FirstTransformTangents);
            Assert.AreEqual(firstTransformBitangents, mesh.FirstTransformBitangents);
            Assert.AreEqual(secondTransformIndices, mesh.SecondTransformIndices);
            Assert.AreEqual(secondTransformPositions, mesh.SecondTransformPositions);
            Assert.AreEqual(secondTransformNormals, mesh.SecondTransformNormals);
            Assert.AreEqual(secondTransformTangents, mesh.SecondTransformTangents);
            Assert.AreEqual(secondTransformBitangents, mesh.SecondTransformBitangents);
            Assert.AreEqual(transformBlendFactors, mesh.TransformBlendFactors);
            Assert.AreEqual(textureCoordinates, mesh.TextureCoordinates);
            Assert.AreEqual(colors, mesh.Colors);
            Assert.AreEqual(indices, mesh.Indices);
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformPositionsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    default,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized. (Parameter 'firstTransformPositions')", exception.Message);
                Assert.AreEqual("firstTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformPositionsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    default,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized. (Parameter 'secondTransformPositions')", exception.Message);
                Assert.AreEqual("secondTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhen65536Vertices()
        {
            var firstTransformIndices = Enumerable.Repeat<byte>(0, 65536).ToImmutableArray();
            var firstTransformPositions = Generate.Vector3s(65536);
            var secondTransformIndices = Enumerable.Repeat<byte>(0, 65536).ToImmutableArray();
            var secondTransformPositions = Generate.Vector3s(65536);
            var transformBlendFactors = Generate.Bytes(65536);
            var textureCoordinates = ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>>.Empty;
            var colors = ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>>.Empty;

            try
            {
                _ = new Mesh
                (
                    Transforms,
                    firstTransformIndices,
                    firstTransformPositions,
                    null,
                    null,
                    null,
                    secondTransformIndices,
                    secondTransformPositions,
                    null,
                    null,
                    null,
                    transformBlendFactors,
                    textureCoordinates,
                    colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 65535 vertices. (Parameter 'firstTransformPositions')", exception.Message);
                Assert.AreEqual("firstTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhen65537Vertices()
        {
            var firstTransformIndices = Enumerable.Repeat<byte>(0, 65537).ToImmutableArray();
            var firstTransformPositions = Generate.Vector3s(65537);
            var secondTransformIndices = Enumerable.Repeat<byte>(0, 65537).ToImmutableArray();
            var secondTransformPositions = Generate.Vector3s(65537);
            var transformBlendFactors = Generate.Bytes(65537);
            var textureCoordinates = ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>>.Empty;
            var colors = ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>>.Empty;

            try
            {
                _ = new Mesh
                (
                    Transforms,
                    firstTransformIndices,
                    firstTransformPositions,
                    null,
                    null,
                    null,
                    secondTransformIndices,
                    secondTransformPositions,
                    null,
                    null,
                    null,
                    transformBlendFactors,
                    textureCoordinates,
                    colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 65535 vertices. (Parameter 'firstTransformPositions')", exception.Message);
                Assert.AreEqual("firstTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformPositionsHasFewerElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions.Take(9).ToImmutableArray(),
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformPositions')", exception.Message);
                Assert.AreEqual("firstTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformPositionsHasMoreElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions.Concat(new[] { Generate.Vector3() }).ToImmutableArray(),
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformPositions')", exception.Message);
                Assert.AreEqual("firstTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformPositionsHasFewerElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions.Take(9).ToImmutableArray(),
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformPositions')", exception.Message);
                Assert.AreEqual("secondTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformPositionsHasMoreElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions.Concat(new[] { Generate.Vector3() }).ToImmutableArray(),
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformPositions')", exception.Message);
                Assert.AreEqual("secondTransformPositions", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformNormalsWithoutSecondTransformNormals()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    FirstTransformNormals,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null when normals are given for the first transform. (Parameter 'secondTransformNormals')", exception.Message);
                Assert.AreEqual("secondTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformNormalsWithoutFirstTransformNormals()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    SecondTransformNormals,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null when normals are given for the second transform. (Parameter 'firstTransformNormals')", exception.Message);
                Assert.AreEqual("firstTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformNormalsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    default(ImmutableArray<Vector3>),
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    SecondTransformNormals,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized when non-null. (Parameter 'firstTransformNormals')", exception.Message);
                Assert.AreEqual("firstTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFewerFirstTransformNormalsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    FirstTransformNormals.Take(9).ToImmutableArray(),
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    SecondTransformNormals,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformNormals')", exception.Message);
                Assert.AreEqual("firstTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenMoreFirstTransformNormalsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    FirstTransformNormals.Concat(Generate.Vector3s(1)).ToImmutableArray(),
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    SecondTransformNormals,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformNormals')", exception.Message);
                Assert.AreEqual("firstTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformNormalsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    FirstTransformNormals,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    default(ImmutableArray<Vector3>),
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized when non-null. (Parameter 'secondTransformNormals')", exception.Message);
                Assert.AreEqual("secondTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFewerSecondTransformNormalsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    FirstTransformNormals,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    SecondTransformNormals.Take(9).ToImmutableArray(),
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformNormals')", exception.Message);
                Assert.AreEqual("secondTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenMoreSecondTransformNormalsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    FirstTransformNormals,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    SecondTransformNormals.Concat(Generate.Vector3s(1)).ToImmutableArray(),
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformNormals')", exception.Message);
                Assert.AreEqual("secondTransformNormals", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformTangentsWithoutSecondTransformTangents()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    FirstTransformTangents,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null when tangents are given for the first transform. (Parameter 'secondTransformTangents')", exception.Message);
                Assert.AreEqual("secondTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformTangentsWithoutFirstTransformTangents()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    SecondTransformTangents,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null when tangents are given for the second transform. (Parameter 'firstTransformTangents')", exception.Message);
                Assert.AreEqual("firstTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformTangentsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    default(ImmutableArray<Vector3>),
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    SecondTransformTangents,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized when non-null. (Parameter 'firstTransformTangents')", exception.Message);
                Assert.AreEqual("firstTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFewerFirstTransformTangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    FirstTransformTangents.Take(9).ToImmutableArray(),
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    SecondTransformTangents,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformTangents')", exception.Message);
                Assert.AreEqual("firstTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenMoreFirstTransformTangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    FirstTransformTangents.Concat(Generate.Vector3s(1)).ToImmutableArray(),
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    SecondTransformTangents,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformTangents')", exception.Message);
                Assert.AreEqual("firstTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformTangentsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    FirstTransformTangents,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    default(ImmutableArray<Vector3>),
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized when non-null. (Parameter 'secondTransformTangents')", exception.Message);
                Assert.AreEqual("secondTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFewerSecondTransformTangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    FirstTransformTangents,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    SecondTransformTangents.Take(9).ToImmutableArray(),
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformTangents')", exception.Message);
                Assert.AreEqual("secondTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenMoreSecondTransformTangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    FirstTransformTangents,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    SecondTransformTangents.Concat(Generate.Vector3s(1)).ToImmutableArray(),
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformTangents')", exception.Message);
                Assert.AreEqual("secondTransformTangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformBitangentsWithoutSecondTransformTangents()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    FirstTransformBitangents,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null when bitangents are given for the first transform. (Parameter 'secondTransformBitangents')", exception.Message);
                Assert.AreEqual("secondTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformBitangentsWithoutFirstTransformBitangents()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    SecondTransformBitangents,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null when bitangents are given for the second transform. (Parameter 'firstTransformBitangents')", exception.Message);
                Assert.AreEqual("firstTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformBitangentsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    default(ImmutableArray<Vector3>),
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    SecondTransformBitangents,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized when non-null. (Parameter 'firstTransformBitangents')", exception.Message);
                Assert.AreEqual("firstTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFewerFirstTransformBitangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    FirstTransformBitangents.Take(9).ToImmutableArray(),
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    SecondTransformBitangents,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformBitangents')", exception.Message);
                Assert.AreEqual("firstTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenMoreFirstTransformBitangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    FirstTransformBitangents.Concat(Generate.Vector3s(1)).ToImmutableArray(),
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    SecondTransformBitangents,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'firstTransformBitangents')", exception.Message);
                Assert.AreEqual("firstTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformBitangentsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    FirstTransformBitangents,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    default(ImmutableArray<Vector3>),
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized when non-null. (Parameter 'secondTransformBitangents')", exception.Message);
                Assert.AreEqual("secondTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFewerSecondTransformBitangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    FirstTransformBitangents,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    SecondTransformBitangents.Take(9).ToImmutableArray(),
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformBitangents')", exception.Message);
                Assert.AreEqual("secondTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenMoreSecondTransformBitangentsThanFirstTransformPositions()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    FirstTransformBitangents,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    SecondTransformBitangents.Concat(Generate.Vector3s(1)).ToImmutableArray(),
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformBitangents')", exception.Message);
                Assert.AreEqual("secondTransformBitangents", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTextureCoordinatesNull()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    null!,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null. (Parameter 'textureCoordinates')", exception.Message);
                Assert.AreEqual("textureCoordinates", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTextureCoordinatesValueUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates.Add(Guid.NewGuid(), default),
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain uninitialized values. (Parameter 'textureCoordinates')", exception.Message);
                Assert.AreEqual("textureCoordinates", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTextureCoordinatesValueHasFewerElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates.Add(Guid.NewGuid(), Generate.Vector2s(9)),
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Each value must contain an element for each vertex. (Parameter 'textureCoordinates')", exception.Message);
                Assert.AreEqual("textureCoordinates", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTextureCoordinatesValueHasMoreElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates.Add(Guid.NewGuid(), Generate.Vector2s(11)),
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Each value must contain an element for each vertex. (Parameter 'textureCoordinates')", exception.Message);
                Assert.AreEqual("textureCoordinates", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTextureCoordinatesContains256Maps()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    Generate.Guids(256).ToImmutableSortedDictionary(k => k, k => Generate.Vector2s(10)),
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 255 entries. (Parameter 'textureCoordinates')", exception.Message);
                Assert.AreEqual("textureCoordinates", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTextureCoordinatesContains257Maps()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    Generate.Guids(257).ToImmutableSortedDictionary(k => k, k => Generate.Vector2s(10)),
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 255 entries. (Parameter 'textureCoordinates')", exception.Message);
                Assert.AreEqual("textureCoordinates", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColorsNull()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    null!,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null. (Parameter 'colors')", exception.Message);
                Assert.AreEqual("colors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColorsValueUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors.Add(Guid.NewGuid(), default),
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain uninitialized values. (Parameter 'colors')", exception.Message);
                Assert.AreEqual("colors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColorsValueHasFewerElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors.Add(Guid.NewGuid(), Generate.ColorsWithOpacity(9)),
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Each value must contain an element for each vertex. (Parameter 'colors')", exception.Message);
                Assert.AreEqual("colors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColorsValueHasMoreElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors.Add(Guid.NewGuid(), Generate.ColorsWithOpacity(11)),
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Each value must contain an element for each vertex. (Parameter 'colors')", exception.Message);
                Assert.AreEqual("colors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColorsContains256Layers()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Generate.Guids(256).ToImmutableSortedDictionary(k => k, k => Generate.ColorsWithOpacity(10)),
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 255 entries. (Parameter 'colors')", exception.Message);
                Assert.AreEqual("colors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColorsContains257Layers()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Generate.Guids(257).ToImmutableSortedDictionary(k => k, k => Generate.ColorsWithOpacity(10)),
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 255 entries. (Parameter 'colors')", exception.Message);
                Assert.AreEqual("colors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    default
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesEmpty()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    ImmutableArray<ushort>.Empty
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("At least three indices must be specified. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesContainsOneIndex()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices.Take(1).ToImmutableArray()
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("At least three indices must be specified. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesContainsTwoIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices.Take(2).ToImmutableArray()
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("At least three indices must be specified. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesContainsIndexEqualToNumberOfVertices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices.Take(2).Concat(new ushort[] { 10 }).Concat(Indices.Skip(3)).ToImmutableArray()
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Indices cannot be greater than or equal to the number of vertices. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesContainsIndexGreaterThanNumberOfVertices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices.Take(2).Concat(new ushort[] { 11 }).Concat(Indices.Skip(3)).ToImmutableArray()
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Indices cannot be greater than or equal to the number of vertices. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesContains65536Indices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Enumerable.Repeat<ushort>(0, 65536).ToImmutableArray()
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 65535 indices. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenIndicesContains65537Indices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Enumerable.Repeat<ushort>(0, 65537).ToImmutableArray()
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 65535 indices. (Parameter 'indices')", exception.Message);
                Assert.AreEqual("indices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTransformsNull()
        {
            try
            {
                _ = new Mesh
                (
                    null!,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null or empty. (Parameter 'transforms')", exception.Message);
                Assert.AreEqual("transforms", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTransformsEmpty()
        {
            try
            {
                _ = new Mesh
                (
                    ImmutableSortedSet<Guid>.Empty,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value cannot be null or empty. (Parameter 'transforms')", exception.Message);
                Assert.AreEqual("transforms", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTransformsContains256Items()
        {
            try
            {
                _ = new Mesh
                (
                    Generate.Guids(256),
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 255 entries. (Parameter 'transforms')", exception.Message);
                Assert.AreEqual("transforms", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTransformsContains257Items()
        {
            try
            {
                _ = new Mesh
                (
                    Generate.Guids(257),
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Cannot contain more than 255 entries. (Parameter 'transforms')", exception.Message);
                Assert.AreEqual("transforms", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformIndicesUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    default,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized. (Parameter 'firstTransformIndices')", exception.Message);
                Assert.AreEqual("firstTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformIndicesContainsNumberOfTransforms()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices.Take(1).Concat(new byte[] { 6 }).Concat(FirstTransformIndices.Skip(2)).ToImmutableArray(),
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Transform indices cannot be greater than or equal to the number of transforms. (Parameter 'firstTransformIndices')", exception.Message);
                Assert.AreEqual("firstTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenFirstTransformIndicesContainsValuesGreaterThanNumberOfTransforms()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices.Take(1).Concat(new byte[] { 7 }).Concat(FirstTransformIndices.Skip(2)).ToImmutableArray(),
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Transform indices cannot be greater than or equal to the number of transforms. (Parameter 'firstTransformIndices')", exception.Message);
                Assert.AreEqual("firstTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformIndicesUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    default,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized. (Parameter 'secondTransformIndices')", exception.Message);
                Assert.AreEqual("secondTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformIndicesHasFewerElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices.Take(9).ToImmutableArray(),
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformIndices')", exception.Message);
                Assert.AreEqual("secondTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformIndicesHasMoreElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices.Concat(new byte[] { 1 }).ToImmutableArray(),
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'secondTransformIndices')", exception.Message);
                Assert.AreEqual("secondTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformIndicesContainsNumberOfTransforms()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices.Take(1).Concat(new byte[] { 6 }).Concat(SecondTransformIndices.Skip(2)).ToImmutableArray(),
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Transform indices cannot be greater than or equal to the number of transforms. (Parameter 'secondTransformIndices')", exception.Message);
                Assert.AreEqual("secondTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenSecondTransformIndicesContainsValuesGreaterThanNumberOfTransforms()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices.Take(1).Concat(new byte[] { 7 }).Concat(SecondTransformIndices.Skip(2)).ToImmutableArray(),
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Transform indices cannot be greater than or equal to the number of transforms. (Parameter 'secondTransformIndices')", exception.Message);
                Assert.AreEqual("secondTransformIndices", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTransformBlendFactorsUninitialized()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    default,
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized. (Parameter 'transformBlendFactors')", exception.Message);
                Assert.AreEqual("transformBlendFactors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTransformBlendFactorsHasFewerElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors.Take(9).ToImmutableArray(),
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'transformBlendFactors')", exception.Message);
                Assert.AreEqual("transformBlendFactors", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenTransformBlendFactorsHasMoreElementsThanFirstTransformIndices()
        {
            try
            {
                _ = new Mesh
                (
                    Transforms,
                    FirstTransformIndices,
                    FirstTransformPositions,
                    null,
                    null,
                    null,
                    SecondTransformIndices,
                    SecondTransformPositions,
                    null,
                    null,
                    null,
                    TransformBlendFactors.Concat(Generate.Bytes(1)).ToImmutableArray(),
                    TextureCoordinates,
                    Colors,
                    Indices
                );
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must contain exactly one value for each vertex. (Parameter 'transformBlendFactors')", exception.Message);
                Assert.AreEqual("transformBlendFactors", exception.ParamName);
            }
        }

        [TestMethod]
        public void EqualMinimal()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void EqualFull()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                FirstTransformNormals,
                FirstTransformTangents,
                FirstTransformBitangents,
                SecondTransformIndices,
                SecondTransformPositions,
                SecondTransformNormals,
                SecondTransformTangents,
                SecondTransformBitangents,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                FirstTransformNormals.Select(x => x).ToImmutableArray(),
                FirstTransformTangents.Select(x => x).ToImmutableArray(),
                FirstTransformBitangents.Select(x => x).ToImmutableArray(),
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                SecondTransformNormals.Select(x => x).ToImmutableArray(),
                SecondTransformTangents.Select(x => x).ToImmutableArray(),
                SecondTransformBitangents.Select(x => x).ToImmutableArray(),
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalNumberOfVertices()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                ImmutableArray.Create<ushort>(8, 3, 1, 0, 2, 5)
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Take(9).ToImmutableArray(),
                FirstTransformPositions.Take(9).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Take(9).ToImmutableArray(),
                SecondTransformPositions.Take(9).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Take(9).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Take(9).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Take(9).ToImmutableArray()),
                ImmutableArray.Create<ushort>(8, 3, 1, 0, 2, 5)
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalFirstTransformPositions()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(FirstTransformPositions.Skip(4)).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalSecondTransformPositions()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(SecondTransformPositions.Skip(4)).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalFirstTransformNormals()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                FirstTransformNormals,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                SecondTransformNormals,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                FirstTransformNormals.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(FirstTransformNormals.Skip(4)).ToImmutableArray(),
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                SecondTransformNormals.Select(x => x).ToImmutableArray(),
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalSecondTransformNormals()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                FirstTransformNormals,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                SecondTransformNormals,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                FirstTransformNormals.Select(x => x).ToImmutableArray(),
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                SecondTransformNormals.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(SecondTransformNormals.Skip(4)).ToImmutableArray(),
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransformNormalsFirstNull()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                FirstTransformNormals.Select(x => x).ToImmutableArray(),
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                SecondTransformNormals.Select(x => x).ToImmutableArray(),
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransformNormalsSecondNull()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                FirstTransformNormals,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                SecondTransformNormals,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalFirstTransformTangents()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                FirstTransformTangents,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                SecondTransformTangents,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                FirstTransformTangents.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(FirstTransformTangents.Skip(4)).ToImmutableArray(),
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                SecondTransformTangents.Select(x => x).ToImmutableArray(),
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalSecondTransformTangents()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                FirstTransformTangents,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                SecondTransformTangents,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                FirstTransformTangents.Select(x => x).ToImmutableArray(),
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                SecondTransformTangents.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(SecondTransformTangents.Skip(4)).ToImmutableArray(),
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransformTangentsFirstNull()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                FirstTransformTangents.Select(x => x).ToImmutableArray(),
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                SecondTransformTangents.Select(x => x).ToImmutableArray(),
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransformTangentsSecondNull()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                FirstTransformTangents,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                SecondTransformTangents,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalFirstTransformBitangents()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                FirstTransformBitangents,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                SecondTransformBitangents,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                FirstTransformBitangents.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(FirstTransformBitangents.Skip(4)).ToImmutableArray(),
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                SecondTransformBitangents,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransformBitangentsFirstNull()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                FirstTransformBitangents.Select(x => x).ToImmutableArray(),
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                SecondTransformBitangents.Select(x => x).ToImmutableArray(),
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransformBitangentsSecondNull()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                FirstTransformBitangents,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                SecondTransformBitangents,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalSecondTransformBitangents()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                FirstTransformBitangents,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                SecondTransformBitangents,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Select(x => x).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                FirstTransformBitangents.Select(x => x).ToImmutableArray(),
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                SecondTransformBitangents.Take(3).Concat(new[] { new Vector3(0.907f, 0.964f, 0.213f) }).Concat(SecondTransformBitangents.Skip(4)).ToImmutableArray(),
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalNumberOfTransforms()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Concat(new[] { Guid.NewGuid() }).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransforms()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms.Take(1).Concat(new[] { Guid.NewGuid() }).Concat(Transforms.Skip(2)).ToImmutableSortedSet(),
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalFirstTransformIndices()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms,
                FirstTransformIndices.Take(1).Concat(new byte[] { 1 }).Concat(FirstTransformIndices.Skip(2)).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Select(x => x).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalSecondTransformIndices()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms,
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices.Take(1).Concat(new byte[] { 1 }).Concat(SecondTransformIndices.Skip(2)).ToImmutableArray(),
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalTransformBlendFactors()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms,
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Take(1).Concat(new byte[] { 1 }).Concat(TransformBlendFactors.Skip(2)).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Select(x => x).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalNumberOfIndices()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms,
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Concat(new ushort[] { 1 }).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalIndices()
        {
            var a = new Mesh
            (
                Transforms,
                FirstTransformIndices,
                FirstTransformPositions,
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions,
                null,
                null,
                null,
                TransformBlendFactors,
                TextureCoordinates,
                Colors,
                Indices
            );
            var b = new Mesh
            (
                Transforms,
                FirstTransformIndices.Select(x => x).ToImmutableArray(),
                FirstTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                SecondTransformIndices,
                SecondTransformPositions.Select(x => x).ToImmutableArray(),
                null,
                null,
                null,
                TransformBlendFactors.Select(x => x).ToImmutableArray(),
                TextureCoordinates.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Colors.ToImmutableSortedDictionary(kv => kv.Key, kv => kv.Value.Select(x => x).ToImmutableArray()),
                Indices.Take(1).Concat(new ushort[] { 1 }).Concat(Indices.Skip(2)).ToImmutableArray()
            );

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalNull()
        {
            var a = Generate.Mesh();

            Assert.AreNotEqual(a, null);
        }

        [TestMethod]
        public void InequalType()
        {
            var a = Generate.Mesh();

            Assert.AreNotEqual(a, 1);
        }
    }
}
