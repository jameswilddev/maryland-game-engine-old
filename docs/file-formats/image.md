# [Maryland](../../readme.md) > [Documentation](../readme.md) > [File Formats](./readme.md) > Image

An image file describes an image as would be held in a [database](../architecture/database.md), and includes:

- An unsigned byte specifying the width of the image in columns.
- An unsigned byte specifying the height of the image in rows.
- 4 * width * height unsigned bytes specifying the colors of the pixels within the image.  This is a repeating pattern of the following, row-major, starting in the top left corner:
  - An unsigned byte specifying the intensity of red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
  - An unsigned byte specifying the intensity of green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
  - An unsigned byte specifying the intensity of blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity.
  - An unsigned byte specifying the opacity, where 0 is fully transparent and 255 is fully opaque.
