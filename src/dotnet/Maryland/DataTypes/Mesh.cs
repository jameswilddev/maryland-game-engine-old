using System.Collections.Immutable;
using System.Numerics;

namespace Maryland.DataTypes
{
    /// <summary>
    /// A polygonal mesh.
    /// </summary>
    public sealed class Mesh
    {
        /// <summary>
        /// The identifiers of the transforms applied to the vertices.
        /// </summary>
        public readonly ImmutableSortedSet<Guid> Transforms;

        /// <summary>
        /// The index into <see cref="Transforms"/> of the first transform which applies to each vertex.
        /// </summary>
        public readonly ImmutableArray<byte> FirstTransformIndices;

        /// <summary>
        /// The positions of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms.
        /// </summary>
        public readonly ImmutableArray<Vector3> FirstTransformPositions;

        /// <summary>
        /// The normals of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.
        /// </summary>
        public readonly ImmutableArray<Vector3>? FirstTransformNormals;

        /// <summary>
        /// The tangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.
        /// </summary>
        public readonly ImmutableArray<Vector3>? FirstTransformTangents;

        /// <summary>
        /// The bitangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.
        /// </summary>
        public readonly ImmutableArray<Vector3>? FirstTransformBitangents;

        /// <summary>
        /// The index into <see cref="Transforms"/> of the second transform which applies to each vertex.
        /// </summary>
        public readonly ImmutableArray<byte> SecondTransformIndices;

        /// <summary>
        /// The positions of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their second transforms.
        /// </summary>
        public readonly ImmutableArray<Vector3> SecondTransformPositions;

        /// <summary>
        /// The normals of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their second transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.
        /// </summary>
        public readonly ImmutableArray<Vector3>? SecondTransformNormals;

        /// <summary>
        /// The tangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their second transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.
        /// </summary>
        public readonly ImmutableArray<Vector3>? SecondTransformTangents;

        /// <summary>
        /// The bitangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their second transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.
        /// </summary>
        public readonly ImmutableArray<Vector3>? SecondTransformBitangents;

        /// <summary>
        /// The blend factor between the the first and second transforms which apply to each vertex, where 0 is the first transform and 255 is the second transform.
        /// </summary>
        public readonly ImmutableArray<byte> TransformBlendFactors;

        /// <summary>
        /// The indices into <see cref="FirstTransformPositions"/>, <see cref="TextureCoordinates"/>.*, etc.  These are rendered as a triangle strip.
        /// </summary>
        public readonly ImmutableArray<ushort> Indices;

        /// <summary>
        /// The texture coordinates of the vertices within <see langword="this"/> <see cref="Mesh"/>, by the <see cref="Guid"/>s of the maps.
        /// </summary>
        public readonly ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>> TextureCoordinates;

        /// <summary>
        /// The colors of the vertices within <see langword="this"/> <see cref="Mesh"/>, by the <see cref="Guid"/>s of the layers.
        /// </summary>
        public readonly ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>> Colors;

        /// <summary>
        /// Creates a new polygonal mesh.
        /// </summary>
        /// <param name="transforms">The identifiers of the transforms applied to the vertices.</param>
        /// <param name="firstTransformIndices">The index into <see cref="Transforms"/> of the first transform which applies to each vertex.</param>
        /// <param name="firstTransformPositions">The positions of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms.</param>
        /// <param name="firstTransformNormals">The normals of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.</param>
        /// <param name="firstTransformTangents">The tangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.</param>
        /// <param name="firstTransformBitangents">The bitangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their first transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.</param>
        /// <param name="secondTransformIndices">The index into <see cref="Transforms"/> of the second transform which applies to each vertex.</param>
        /// <param name="secondTransformPositions">The positions of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their second transforms.</param>
        /// <param name="secondTransformNormals">The normals of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their second transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.</param>
        /// <param name="secondTransformTangents">The tangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their second transforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.</param>
        /// <param name="secondTransformBitangents">The bitangents of the vertices within <see langword="this"/> <see cref="Mesh"/>, relative to their secondtransforms, or <see langword="null"/> should <see langword="this"/> <see cref="Mesh"/> lack them.</param>
        /// <param name="transformBlendFactors">The blend factor between the the first and second transforms which apply to each vertex, where 0 is the first transform and 1 is the second transform.</param>
        /// <param name="textureCoordinates">The texture coordinates of the vertices within <see langword="this"/> <see cref="Mesh"/>, by the <see cref="Guid"/>s of the maps.</param>
        /// <param name="colors">The colors of the vertices within <see langword="this"/> <see cref="Mesh"/>, by the <see cref="Guid"/>s of the layers.</param>
        /// <param name="indices">The indices into <see cref="FirstTransformPositions"/>, <see cref="TextureCoordinates"/>.*, etc.  These are rendered as a triangle strip.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="transforms"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="transforms"/> is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="transforms"/> contains more than 255 entries.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformIndices"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="firstTransformIndices"/> contains more than 255 entries.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="firstTransformIndices"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="firstTransformIndices"/> contains indices greater than or equal to <paramref name="transforms"/>.<see cref="ImmutableArray{T}.Length"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformPositions"/> is uninitialized.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformPositions"/> contains more than 65535 entries.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformNormals"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="firstTransformNormals"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformTangents"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="firstTransformTangents"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformBitangents"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="firstTransformBitangents"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformIndices"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="secondTransformIndices"/> contains more than 255 entries.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="secondTransformIndices"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="secondTransformIndices"/> contains indices greater than or equal to <paramref name="transforms"/>.<see cref="ImmutableArray{T}.Length"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformPositions"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="secondTransformPositions"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformNormals"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="secondTransformNormals"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformNormals"/> is <see langword="null"/> but <paramref name="secondTransformNormals" /> is non-<see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformNormals"/> is <see langword="null"/> but <paramref name="firstTransformNormals" /> is non-<see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformTangents"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="secondTransformTangents"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformTangents"/> is <see langword="null"/> but <paramref name="secondTransformTangents" /> is non-<see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformTangents"/> is <see langword="null"/> but <paramref name="firstTransformTangents" /> is non-<see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformBitangents"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="secondTransformBitangents"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="firstTransformBitangents"/> is <see langword="null"/> but <paramref name="secondTransformBitangents" /> is non-<see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="secondTransformBitangents"/> is <see langword="null"/> but <paramref name="firstTransformBitangents" /> is non-<see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="transformBlendFactors"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="transformBlendFactors"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="textureCoordinates"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="textureCoordinates"/> contains a <see langword="null"/> value.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="textureCoordinates"/> contains an uninitialized value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="textureCoordinates"/> contains more than 255 entries.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value of <paramref name="textureCoordinates"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="colors"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="colors"/> contains a <see langword="null"/> value.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="colors"/> contains an uninitialized value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="colors"/> contains more than 255 entries.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when a value of <paramref name="colors"/> contains a different number of elements to <paramref name="firstTransformIndices"/>.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indices"/> is uninitialized.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="indices"/> contains fewer than 3 items.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="indices"/> contains more than 65535 items.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="indices"/> contains indices greater than or equal to <paramref name="firstTransformPositions"/>.<see cref="ImmutableArray{T}.Length"/>.</exception>
        public Mesh
        (
            ImmutableSortedSet<Guid> transforms,
            ImmutableArray<byte> firstTransformIndices,
            ImmutableArray<Vector3> firstTransformPositions,
            ImmutableArray<Vector3>? firstTransformNormals,
            ImmutableArray<Vector3>? firstTransformTangents,
            ImmutableArray<Vector3>? firstTransformBitangents,
            ImmutableArray<byte> secondTransformIndices,
            ImmutableArray<Vector3> secondTransformPositions,
            ImmutableArray<Vector3>? secondTransformNormals,
            ImmutableArray<Vector3>? secondTransformTangents,
            ImmutableArray<Vector3>? secondTransformBitangents,
            ImmutableArray<byte> transformBlendFactors,
            ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>> textureCoordinates,
            ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>> colors,
            ImmutableArray<ushort> indices
        )
        {
            if (firstTransformIndices.IsDefault)
            {
                throw new ArgumentNullException(nameof(firstTransformIndices), "Value must be initialized.");
            }
            else if (secondTransformIndices.IsDefault)
            {
                throw new ArgumentNullException(nameof(secondTransformIndices), "Value must be initialized.");
            }
            else if (firstTransformPositions.IsDefault)
            {
                throw new ArgumentNullException(nameof(firstTransformPositions), "Value must be initialized.");
            }
            else if (firstTransformPositions.Length > 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(firstTransformPositions), "Cannot contain more than 65535 vertices.");
            }
            else if (firstTransformNormals.HasValue && firstTransformNormals.Value.IsDefault)
            {
                throw new ArgumentNullException(nameof(firstTransformNormals), "Value must be initialized when non-null.");
            }
            else if (firstTransformNormals.HasValue && firstTransformNormals.Value.Length != firstTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(firstTransformNormals), "Must contain exactly one value for each vertex.");
            }
            else if (firstTransformTangents.HasValue && firstTransformTangents.Value.IsDefault)
            {
                throw new ArgumentNullException(nameof(firstTransformTangents), "Value must be initialized when non-null.");
            }
            else if (firstTransformTangents.HasValue && firstTransformTangents.Value.Length != firstTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(firstTransformTangents), "Must contain exactly one value for each vertex.");
            }
            else if (firstTransformBitangents.HasValue && firstTransformBitangents.Value.IsDefault)
            {
                throw new ArgumentNullException(nameof(firstTransformBitangents), "Value must be initialized when non-null.");
            }
            else if (firstTransformBitangents.HasValue && firstTransformBitangents.Value.Length != firstTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(firstTransformBitangents), "Must contain exactly one value for each vertex.");
            }
            else if (secondTransformNormals.HasValue && secondTransformNormals.Value.IsDefault)
            {
                throw new ArgumentNullException(nameof(secondTransformNormals), "Value must be initialized when non-null.");
            }
            else if (secondTransformNormals.HasValue && secondTransformNormals.Value.Length != secondTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(secondTransformNormals), "Must contain exactly one value for each vertex.");
            }
            else if (secondTransformTangents.HasValue && secondTransformTangents.Value.IsDefault)
            {
                throw new ArgumentNullException(nameof(secondTransformTangents), "Value must be initialized when non-null.");
            }
            else if (secondTransformTangents.HasValue && secondTransformTangents.Value.Length != secondTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(secondTransformTangents), "Must contain exactly one value for each vertex.");
            }
            else if (secondTransformBitangents.HasValue && secondTransformBitangents.Value.IsDefault)
            {
                throw new ArgumentNullException(nameof(secondTransformBitangents), "Value must be initialized when non-null.");
            }
            else if (secondTransformBitangents.HasValue && secondTransformBitangents.Value.Length != secondTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(secondTransformBitangents), "Must contain exactly one value for each vertex.");
            }
            else if (secondTransformNormals.HasValue && !firstTransformNormals.HasValue)
            {
                throw new ArgumentNullException(nameof(firstTransformNormals), "Value cannot be null when normals are given for the second transform.");
            }
            else if (firstTransformNormals.HasValue && !secondTransformNormals.HasValue)
            {
                throw new ArgumentNullException(nameof(secondTransformNormals), "Value cannot be null when normals are given for the first transform.");
            }
            else if (secondTransformTangents.HasValue && !firstTransformTangents.HasValue)
            {
                throw new ArgumentNullException(nameof(firstTransformTangents), "Value cannot be null when tangents are given for the second transform.");
            }
            else if (firstTransformTangents.HasValue && !secondTransformTangents.HasValue)
            {
                throw new ArgumentNullException(nameof(secondTransformTangents), "Value cannot be null when tangents are given for the first transform.");
            }
            else if (secondTransformBitangents.HasValue && !firstTransformBitangents.HasValue)
            {
                throw new ArgumentNullException(nameof(firstTransformBitangents), "Value cannot be null when bitangents are given for the second transform.");
            }
            else if (firstTransformBitangents.HasValue && !secondTransformBitangents.HasValue)
            {
                throw new ArgumentNullException(nameof(secondTransformBitangents), "Value cannot be null when bitangents are given for the first transform.");
            }
            else if (textureCoordinates == null)
            {
                throw new ArgumentNullException(nameof(textureCoordinates));
            }
            else if (textureCoordinates.Values.Any(value => value.IsDefault))
            {
                throw new ArgumentNullException(nameof(textureCoordinates), "Cannot contain uninitialized values.");
            }
            else if (textureCoordinates.Values.Any(value => value.Length != firstTransformIndices.Length))
            {
                throw new ArgumentNullException(nameof(textureCoordinates), "Each value must contain an element for each vertex.");
            }
            else if (colors == null)
            {
                throw new ArgumentNullException(nameof(colors));
            }
            else if (colors.Values.Any(value => value.IsDefault))
            {
                throw new ArgumentNullException(nameof(colors), "Cannot contain uninitialized values.");
            }
            else if (colors.Values.Any(value => value.Length != firstTransformIndices.Length))
            {
                throw new ArgumentNullException(nameof(colors), "Each value must contain an element for each vertex.");
            }
            else if (indices.IsDefault)
            {
                throw new ArgumentNullException(nameof(indices), "Value must be initialized.");
            }
            else if (indices.Length < 3)
            {
                throw new ArgumentOutOfRangeException(nameof(indices), "At least three indices must be specified.");
            }
            else if (indices.Length > 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(indices), "Cannot contain more than 65535 indices.");
            }
            else if (indices.Any(index => index >= firstTransformIndices.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(indices), "Indices cannot be greater than or equal to the number of vertices.");
            }
            else if (transforms == null || transforms.IsEmpty)
            {
                throw new ArgumentNullException(nameof(transforms), "Value cannot be null or empty.");
            }
            else if (transforms.Count > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(transforms), "Cannot contain more than 255 entries.");
            }
            else if (firstTransformPositions.Length != firstTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(firstTransformPositions), "Must contain exactly one value for each vertex.");
            }
            else if (secondTransformPositions.IsDefault)
            {
                throw new ArgumentNullException(nameof(secondTransformPositions), "Value must be initialized.");
            }
            else if (secondTransformPositions.Length != firstTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(secondTransformPositions), "Must contain exactly one value for each vertex.");
            }
            else if (firstTransformIndices.Any(index => index >= transforms.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(firstTransformIndices), "Transform indices cannot be greater than or equal to the number of transforms.");
            }
            else if (secondTransformIndices.Length != firstTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(secondTransformIndices), "Must contain exactly one value for each vertex.");
            }
            else if (secondTransformIndices.Any(index => index >= transforms.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(secondTransformIndices), "Transform indices cannot be greater than or equal to the number of transforms.");
            }
            else if (transformBlendFactors.IsDefault)
            {
                throw new ArgumentNullException(nameof(transformBlendFactors), "Value must be initialized.");
            }
            else if (transformBlendFactors.Length != firstTransformIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(transformBlendFactors), "Must contain exactly one value for each vertex.");
            }
            else if (colors.Count > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(colors), "Cannot contain more than 255 entries.");
            }
            else if (textureCoordinates.Count > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(textureCoordinates), "Cannot contain more than 255 entries.");
            }
            else
            {
                FirstTransformPositions = firstTransformPositions;
                SecondTransformPositions = secondTransformPositions;
                FirstTransformNormals = firstTransformNormals;
                SecondTransformNormals = secondTransformNormals;
                FirstTransformTangents = firstTransformTangents;
                SecondTransformTangents = secondTransformTangents;
                FirstTransformBitangents = firstTransformBitangents;
                SecondTransformBitangents = secondTransformBitangents;
                TextureCoordinates = textureCoordinates;
                Colors = colors;
                Transforms = transforms;
                FirstTransformIndices = firstTransformIndices;
                SecondTransformIndices = secondTransformIndices;
                TransformBlendFactors = transformBlendFactors;
                Indices = indices;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is Mesh mesh)
            {
                return mesh.Transforms.SequenceEqual(Transforms)
                    && mesh.FirstTransformIndices.SequenceEqual(FirstTransformIndices)
                    && mesh.FirstTransformPositions.SequenceEqual(FirstTransformPositions)
                    && mesh.FirstTransformNormals.HasValue == FirstTransformNormals.HasValue
                    && (!mesh.FirstTransformNormals.HasValue || mesh.FirstTransformNormals.Value.SequenceEqual(FirstTransformNormals!.Value))
                    && mesh.FirstTransformTangents.HasValue == FirstTransformTangents.HasValue
                    && (!mesh.FirstTransformTangents.HasValue || mesh.FirstTransformTangents.Value.SequenceEqual(FirstTransformTangents!.Value))
                    && mesh.FirstTransformBitangents.HasValue == FirstTransformBitangents.HasValue
                    && (!mesh.FirstTransformBitangents.HasValue || mesh.FirstTransformBitangents.Value.SequenceEqual(FirstTransformBitangents!.Value))
                    && mesh.SecondTransformIndices.SequenceEqual(SecondTransformIndices)
                    && mesh.SecondTransformPositions.SequenceEqual(SecondTransformPositions)
                    && (!mesh.SecondTransformNormals.HasValue || mesh.SecondTransformNormals.Value.SequenceEqual(SecondTransformNormals!.Value))
                    && (!mesh.SecondTransformTangents.HasValue || mesh.SecondTransformTangents.Value.SequenceEqual(SecondTransformTangents!.Value))
                    && (!mesh.SecondTransformBitangents.HasValue || mesh.SecondTransformBitangents.Value.SequenceEqual(SecondTransformBitangents!.Value))
                    && mesh.TransformBlendFactors.SequenceEqual(TransformBlendFactors)
                    && mesh.TextureCoordinates.Count == TextureCoordinates.Count
                    && mesh.TextureCoordinates.Keys.All(TextureCoordinates.ContainsKey)
                    && mesh.TextureCoordinates.All(kv => TextureCoordinates[kv.Key].SequenceEqual(kv.Value))
                    && mesh.Colors.Count == Colors.Count
                    && mesh.Colors.Keys.All(Colors.ContainsKey)
                    && mesh.Colors.All(kv => Colors[kv.Key].SequenceEqual(kv.Value))
                    && mesh.Indices.SequenceEqual(Indices);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return FirstTransformPositions.Length;
        }

        /// <summary>
        /// A sequence of <see cref="byte"/>s which describe <see langword="this"/> <see cref="Mesh"/>.
        /// </summary>
        public IEnumerable<byte> Serialized => Serialize
            .Bits(FirstTransformNormals.HasValue, FirstTransformTangents.HasValue, FirstTransformBitangents.HasValue)
            .Concat(Serialize.U16((ushort)FirstTransformPositions.Length))
            .Concat(Serialize.Byte((byte)Transforms.Count))
            .Concat(Serialize.Guids(Transforms))
            .Concat(FirstTransformIndices)
            .Concat(Serialize.Vector3s(FirstTransformPositions))
            .Concat(FirstTransformNormals.HasValue ? Serialize.Vector3s(FirstTransformNormals.Value) : Enumerable.Empty<byte>())
            .Concat(FirstTransformTangents.HasValue ? Serialize.Vector3s(FirstTransformTangents.Value) : Enumerable.Empty<byte>())
            .Concat(FirstTransformBitangents.HasValue ? Serialize.Vector3s(FirstTransformBitangents.Value) : Enumerable.Empty<byte>())
            .Concat(SecondTransformIndices)
            .Concat(Serialize.Vector3s(SecondTransformPositions))
            .Concat(SecondTransformNormals.HasValue ? Serialize.Vector3s(SecondTransformNormals.Value) : Enumerable.Empty<byte>())
            .Concat(SecondTransformTangents.HasValue ? Serialize.Vector3s(SecondTransformTangents.Value) : Enumerable.Empty<byte>())
            .Concat(SecondTransformBitangents.HasValue ? Serialize.Vector3s(SecondTransformBitangents.Value) : Enumerable.Empty<byte>())
            .Concat(TransformBlendFactors)
            .Concat(Serialize.Byte((byte)TextureCoordinates.Count))
            .Concat(TextureCoordinates.Keys.SelectMany(Serialize.Guid))
            .Concat(TextureCoordinates.Values.SelectMany(x => Serialize.Vector2s(x)))
            .Concat(Serialize.Byte((byte)Colors.Count))
            .Concat(Colors.Keys.SelectMany(Serialize.Guid))
            .Concat(Colors.Values.SelectMany(x => x).SelectMany(x => x.Serialized))
            .Concat(Serialize.U16((ushort)Indices.Length))
            .Concat(Serialize.U16s(Indices));
    }
}
