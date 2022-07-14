# [Maryland](../../readme.md) > [Documentation](../readme.md) > [File Formats](./readme.md) > Patch

A patch file is a byte stream listing instructions which edit a [database](../architecture/database.md), in execution order.

Each instruction starts with an opcode byte.  A critical error is to be raised when an unrecognized opcode is encountered.

## 0 - Set Global Reference

Immediately followed by:

- 16 bytes representing the identifier of the attribute.
- 16 bytes representing the identifier of the referenced entity.

## 1 - Set Global String

Immediately followed by:

- 16 bytes representing the identifier of the attribute.
- A little-endian unsigned 16-bit integer specifying the length of the string in UTF-8 encoded bytes.
- The bytes of the string, UTF-8 encoded.

## 2 - Set Global Float

Immediately followed by:

- 16 bytes representing the identifier of the attribute.
- 4 bytes representing the value, as a little-endian IEEE 32-bit float.

## 3 - Set Global Flag

Immediately followed by:

- 16 bytes representing the identifier of the attribute.

## 4 - Clear Global Flag

Immediately followed by:

- 16 bytes representing the identifier of the attribute.

## 5 - Set Entity Reference

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the reference.
- 16 bytes representing the identifier of the attribute.
- 16 bytes representing the identifier of the referenced entity.

## 6 - Set Entity String

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the string.
- 16 bytes representing the identifier of the attribute.
- A little-endian unsigned 16-bit integer specifying the length of the string in UTF-8 encoded bytes.
- The bytes of the string, UTF-8 encoded.

## 7 - Set Entity Float

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the float.
- 16 bytes representing the identifier of the attribute.
- 4 bytes representing the value, as a little-endian IEEE 32-bit float.

## 8 - Set Entity Flag

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the flag.
- 16 bytes representing the identifier of the attribute.

## 9 - Clear Entity Flag

Immediately followed by:

- 16 bytes representing the identifier of the entity holding the flag.
- 16 bytes representing the identifier of the attribute.

## 10 - Set Tag

Immediately followed by:

- 16 bytes representing the identifier of the tag.
- An unsigned byte specifying the length of the string in UTF-8 encoded bytes.
- The bytes of the string, UTF-8 encoded.
