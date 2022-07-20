# [Maryland](../../readme.md) > [Documentation](../readme.md) > [File Formats](./readme.md) > Mesh

An mesh file describes a mesh as would be held in a [database](../architecture/database.md), and includes:

- An unsigned byte specifying which optional features are enabled, where:
  - When the least significant bit is set, normals are enabled.
  - When the second-least significant bit is set, tangents are enabled.
  - When the third-least significant bit is set, bitangents are enabled.
  - Any other bit set is an error.
- A little-endian unsigned 16-bit integer specifying the number of vertices.  Must be greater than 0.
- An unsigned byte specifying the number of transforms.
- 16 bytes for each transform specifying their identifiers (no duplicates are permitted).
- An unsigned byte for each vertex, specifying a first transform index.  Must be less than the number of transforms.
- For each vertex:
  - 4 bytes representing the position on the X axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the position on the Y axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the position on the Z axis relative to the first transform, as a little-endian IEEE 32-bit float.
- When normals are enabled, for each vertex:
  - 4 bytes representing the normal on the X axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the normal on the Y axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the normal on the Z axis relative to the first transform, as a little-endian IEEE 32-bit float.
- When tangents are enabled, for each vertex:
  - 4 bytes representing the tangent on the X axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the tangent on the Y axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the tangent on the Z axis relative to the first transform, as a little-endian IEEE 32-bit float.
- When bitangents are enabled, for each vertex:
  - 4 bytes representing the bitangent on the X axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the bitangent on the Y axis relative to the first transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the bitangent on the Z axis relative to the first transform, as a little-endian IEEE 32-bit float.
- An unsigned byte for each vertex, specifying a second transform index.  Must be less than the number of transforms.
- For each vertex:
  - 4 bytes representing the position on the X axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the position on the Y axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the position on the Z axis relative to the second transform, as a little-endian IEEE 32-bit float.
- When normals are enabled, for each vertex:
  - 4 bytes representing the normal on the X axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the normal on the Y axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the normal on the Z axis relative to the second transform, as a little-endian IEEE 32-bit float.
- When tangents are enabled, for each vertex:
  - 4 bytes representing the tangent on the X axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the tangent on the Y axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the tangent on the Z axis relative to the second transform, as a little-endian IEEE 32-bit float.
- When bitangents are enabled, for each vertex:
  - 4 bytes representing the bitangent on the X axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the bitangent on the Y axis relative to the second transform, as a little-endian IEEE 32-bit float.
  - 4 bytes representing the bitangent on the Z axis relative to the second transform, as a little-endian IEEE 32-bit float.
- An unsigned byte for each vertex, specifying the blend between the first and second transforms, where 0 is the first transform, and 255 is the second transform.
- An unsigned byte specifying the number of texture maps.
- For each texture map:
  - 16 bytes specifying its identifier (no two texture maps may have the same identifier in the same mesh).
  - For each vertex:
    - 4 bytes representing the texture coordinate on the X axis, as a little-endian IEEE 32-bit float.
    - 4 bytes representing the texture coordinate on the Y axis, as a little-endian IEEE 32-bit float.
- For each color layer:
  - 16 bytes specifying its identifier (no two color layers may have the same identifier in the same mesh).
  - For each vertex:
    - An unsigned byte specifying the intensity of red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
    - An unsigned byte specifying the intensity of green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
    - An unsigned byte specifying the intensity of blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
    - An unsigned byte specifying the opacity, where 0 is fully transparent and 255 is fully opaque.
- A little-endian unsigned 16-bit integer specifying the number of indices.  Must be greater than 2.
- An unsigned 16-bit integer for each index.  Must be less than the number of vertices.