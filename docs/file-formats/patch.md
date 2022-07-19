# [Maryland](../../readme.md) > [Documentation](../readme.md) > [File Formats](./readme.md) > Patch

A patch file is a byte stream listing instructions which edit a [database](../architecture/database.md), in execution order.

Each instruction starts with an opcode byte.  A critical error is to be raised when an unrecognized opcode is encountered.

## 0 - Set Reference

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the reference.
- 16 bytes representing the identifier of the attribute.
- 16 bytes representing the identifier of the referenced entity.

## 1 - Set String

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the string.
- 16 bytes representing the identifier of the attribute.
- A little-endian unsigned 16-bit integer specifying the length of the string in UTF-8 encoded bytes.
- The bytes of the string, UTF-8 encoded.

## 2 - Set Float

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the float.
- 16 bytes representing the identifier of the attribute.
- 4 bytes representing the value, as a little-endian IEEE 32-bit float.

## 3 - Set Flag

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the flag.
- 16 bytes representing the identifier of the attribute.

## 4 - Clear Flag

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the flag.
- 16 bytes representing the identifier of the attribute.

## 5 - Set Tag

Immediately followed by:

- 16 bytes representing the identifier of the tag.
- An unsigned byte specifying the length of the string in UTF-8 encoded bytes (at least 1).
- The bytes of the string, UTF-8 encoded.

## 6 - Set Color

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the color.
- 16 bytes representing the identifier of the attribute.
- An unsigned byte specifying the intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
- An unsigned byte specifying the intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
- An unsigned byte specifying the intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.

## 7 - Set Image

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the image.
- 16 bytes representing the identifier of the attribute.
- An [image](./image.md).
