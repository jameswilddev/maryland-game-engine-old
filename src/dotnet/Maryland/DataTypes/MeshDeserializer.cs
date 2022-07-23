using System.Collections.Immutable;
using System.Numerics;

namespace Maryland.DataTypes
{
    /// <summary>
    /// Deserializes <see cref="Mesh"/>es from <see cref="byte"/> streams.
    /// </summary>
    public sealed class MeshDeserializer : IMeshDeserializer
    {
        /// <inheritdoc />
        public async ValueTask<Mesh> Deserialize(IAsyncEnumerable<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            else
            {
                var enumerator = bytes.GetAsyncEnumerator();

                var mesh = await Deserialize(enumerator);

                if (await enumerator.MoveNextAsync())
                {
                    throw new InvalidDataException("Unexpected bytes following mesh.");
                }
                else
                {
                    return mesh;
                }
            }
        }

        internal static async ValueTask<Mesh> Deserialize(IAsyncEnumerator<byte> bytes)
        {
            var featureFlags = await Maryland.Deserialize.Byte(bytes, "Unexpected EOF during mesh feature flags.");

            if ((featureFlags & 248) != 0)
            {
                throw new InvalidDataException("Unexpected mesh feature flags.");
            }

            var hasNormals = (featureFlags & 1) == 1;
            var hasTangents = (featureFlags & 2) == 2;
            var hasBitangents = (featureFlags & 4) == 4;

            var numberOfVertices = await Maryland.Deserialize.U16(bytes, "Unexpected EOF during number of vertices in mesh.");

            if (numberOfVertices == 0)
            {
                throw new InvalidDataException("Mesh has no vertices.");
            }

            var numberOfTransforms = await Maryland.Deserialize.Byte(bytes, "Unexpected EOF during number of transforms in mesh.");

            if (numberOfTransforms == 0)
            {
                throw new InvalidDataException("Mesh has no transforms.");
            }

            var transformIdentifiers = await Maryland.Deserialize.GuidSet(bytes, numberOfTransforms, "Unexpected EOF during transform identifiers in mesh.", "Duplicate transform identifiers in mesh.");
            var firstTransformIndices = await Maryland.Deserialize.Bytes(bytes, numberOfVertices, "Unexpected EOF during first transform indices in mesh.");
            
            if (firstTransformIndices.Any(index => index >= numberOfTransforms))
            {
                throw new InvalidDataException("Mesh first transform index out of range.");
            }

            var firstTransformPositions = await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during first transform positions in mesh.");
            ImmutableArray<Vector3>? firstTransformNormals = hasNormals ? await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during first transform normals in mesh.") : null;
            ImmutableArray<Vector3>? firstTransformTangents = hasTangents ? await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during first transform tangents in mesh.") : null;
            ImmutableArray<Vector3>? firstTransformBitangents = hasBitangents ? await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during first transform bitangents in mesh.") : null;
            var secondTransformIndices = await Maryland.Deserialize.Bytes(bytes, numberOfVertices, "Unexpected EOF during second transform indices in mesh.");

            if (secondTransformIndices.Any(index => index >= numberOfTransforms))
            {
                throw new InvalidDataException("Mesh second transform index out of range.");
            }

            var secondTransformPositions = await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during second transform positions in mesh.");
            ImmutableArray<Vector3>? secondTransformNormals = hasNormals ? await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during second transform normals in mesh.") : null;
            ImmutableArray<Vector3>? secondTransformTangents = hasTangents ? await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during second transform tangents in mesh.") : null;
            ImmutableArray<Vector3>? secondTransformBitangents = hasBitangents ? await Maryland.Deserialize.Vector3s(bytes, numberOfVertices, "Unexpected EOF during second transform bitangents in mesh.") : null;

            var transformBlendFactors = await Maryland.Deserialize.Bytes(bytes, numberOfVertices, "Unexpected EOF during mesh transform blend factors.");

            var numberOfTextureMaps = await Maryland.Deserialize.Byte(bytes, "Unexpected EOF during number of texture maps in mesh.");
            var textureMapIdentifiers = await Maryland.Deserialize.GuidSet(bytes, numberOfTextureMaps, "Unexpected EOF during texture map identifiers in mesh.", "Duplicate texture map identifiers in mesh.");
            var textureMaps = ImmutableSortedDictionary<Guid, ImmutableArray<Vector2>>.Empty;

            foreach (var identifier in textureMapIdentifiers)
            {
                textureMaps = textureMaps.Add(identifier, await Maryland.Deserialize.Vector2s(bytes, numberOfVertices, "Unexpected EOF during texture map coordinates in mesh."));
            }

            var numberOfColorLayers = await Maryland.Deserialize.Byte(bytes, "Unexpected EOF during number of color layers in mesh.");
            var colorLayerIdentifiers = await Maryland.Deserialize.GuidSet(bytes, numberOfColorLayers, "Unexpected EOF during color layer identifiers in mesh.", "Duplicate color layer identifiers in mesh.");
            var colorLayers = ImmutableSortedDictionary<Guid, ImmutableArray<ColorWithOpacity>>.Empty;

            foreach (var identifier in colorLayerIdentifiers)
            {
                colorLayers = colorLayers.Add(identifier, await Maryland.Deserialize.ColorsWithOpacity(bytes, numberOfVertices, "Unexpected EOF during color layer content in mesh."));
            }

            var numberOfIndices = await Maryland.Deserialize.U16(bytes, "Unexpected EOF during number of indices in mesh.");

            if (numberOfIndices < 3)
            {
                throw new InvalidDataException("Mesh does not have at least three indices.");
            }

            var indices = await Maryland.Deserialize.U16s(bytes, numberOfIndices, "Unexpected EOF during indices in mesh.");

            if (indices.Any(index => index >= numberOfVertices))
            {
                throw new InvalidDataException("Mesh index out of range.");
            }

            var sortedTransforms = transformIdentifiers.ToImmutableSortedSet();

            return new Mesh
            (
                sortedTransforms,
                firstTransformIndices.Select(i => (byte)sortedTransforms.IndexOf(transformIdentifiers[i])).ToImmutableArray(),
                firstTransformPositions,
                firstTransformNormals,
                firstTransformTangents,
                firstTransformBitangents,
                secondTransformIndices.Select(i => (byte)sortedTransforms.IndexOf(transformIdentifiers[i])).ToImmutableArray(),
                secondTransformPositions,
                secondTransformNormals,
                secondTransformTangents,
                secondTransformBitangents,
                transformBlendFactors,
                textureMaps,
                colorLayers,
                indices
            );
        }
    }
}
