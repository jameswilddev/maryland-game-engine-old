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
