# [Maryland](../../readme.md) > [Documentation](../readme.md) > [Architecture](./readme.md) > Database

## Identifiers

An identifier is a 128-bit value which identifies an entity or attribute, randomly generated on the creation of new entities and attributes.  Identifiers are analogous to UUIDs or GUIDs.

## References

A reference includes:

- The identifier of the entity holding the reference.
- The identifier of the attribute.
- The identifier of the referenced entity (the value).

All references' values default to an all-zero identifier.

## Strings

A string includes:

- The identifier of the entity holding the string.
- The identifier of the attribute.
- Up to 65535 bytes of UTF-8 encoded text (the value).

All strings' values default to empty strings.

## Floats

A float includes:

- The identifier of the entity holding the float.
- The identifier of the attribute.
- A 32-bit IEEE float (the value, including support for NaN and positive/negative infinity).

All floats' values default to 0 when not set.

## Flags

- The identifier of the entity holding the flag.
- The identifier of the attribute.

All flags default to unset.

## Tags

Tags are used to give human-readable names to entity and attribute identifiers.  Each includes:

- The identifier of the tag.
- Up to 255 bytes of UTF-8 encoded text (the value; cannot be empty).

All tags' values default to the hexadecimal representation of the identifier they represent.

## Colors

A color is 24-bit and includes:

- The identifier of the entity holding the color.
- The identifier of the attribute.
- A red channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
- A green channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
- A blue channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.

All colors' values default to 0, 0, 0 (black) when not set.

## Images

An image is an uncompressed 32-bit 2D bitmap graphic.  It is intended for small sprites and textures.  Images include:

- A width in columns, between 1 and 255 (inclusive).
- A height in columns, between 1 and 255 (inclusive).
- 4 * width * height bytes specifying the colors of the pixels within the image.  This is a repeating pattern of the following, row-major, starting in the top left corner:
  - A red channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
  - A green channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
  - A blue channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
  - An opacity, where 0 is fully transparent and 255 is fully opaque.

All images default to a 1x1 image, where the lone pixel is 0, 0, 0, 0 (fully transparent).

## Meshes

A mesh is a polygonal model and includes:

- Between 1 and 255 transform identifiers (inclusive).
- Between 0 and 255 texture map identifiers (inclusive).
- Between 0 and 255 color layer identifiers (inclusive).
- A flag indicating whether the mesh includes normals.
- A flag indicating whether the mesh includes tangents.
- A flag indicating whether the mesh includes bitangents.
- 1-65535 vertices, each of which includes:
  - Two indices into the list of transform identifiers.
  - An unsigned byte representing the blend factor between the two specified transforms, where 0 is the first and 255 is the second.
  - 3x 32-bit IEEE floats representing position relative to the first transform (including support for NaN and positive/negative infinity).
  - 3x 32-bit IEEE floats representing position relative to the second transform (including support for NaN and positive/negative infinity).
  - When enabled, 3x 32-bit IEEE floats representing the normal relative to the first transform (including support for NaN and positive/negative infinity).
  - When enabled, 3x 32-bit IEEE floats representing the normal relative to the second transform (including support for NaN and positive/negative infinity).
  - When enabled, 3x 32-bit IEEE floats representing the tangent relative to the first transform (including support for NaN and positive/negative infinity).
  - When enabled, 3x 32-bit IEEE floats representing the tangent relative to the second transform (including support for NaN and positive/negative infinity).
  - When enabled, 3x 32-bit IEEE floats representing the bitangent relative to the first transform (including support for NaN and positive/negative infinity).
  - When enabled, 3x 32-bit IEEE floats representing the bitangent relative to the second transform (including support for NaN and positive/negative infinity).
  - For each vertex for each texture map:
    - 2x 32-bit IEEE floats representing texture coordinates (including support for NaN and positive/negative infinity).
  - For each vertex for each color layer:
    - A red channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
    - A green channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
    - A blue channel intensity, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
    - An opacity, where 0 is fully transparent and 255 is fully opaque.

All meshes default to having no normals, tangents, bitangents, texture maps or color layers, a single transform with an all-zero identifier and a single degenerate triangle.
