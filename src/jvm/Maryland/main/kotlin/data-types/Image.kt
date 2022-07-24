import com.google.common.collect.ImmutableList

/**
 * A 32-bits-per-pixel [Image].
 * @param columns The number of columns within the [Image].
 * @param pixels The row-major pixels within the [Image], starting in the top left corner.
 * @constructor Creates a new 32-bits-per-pixel [Image].
 * @throws IllegalArgumentException Thrown when [columns] is not a factor of the number of [pixels].
 * @throws IllegalArgumentException Thrown when [pixels] contains more than 255 rows.
 */
data class Image(val columns: UByte, val pixels: ImmutableList<ColorWithOpacity>) {
    init {
        val columnsInt = columns.toInt()
        val numberOfPixels = pixels.count()

        if (columnsInt < 1 || columnsInt > numberOfPixels || numberOfPixels % columnsInt != 0) {
            throw IllegalArgumentException("Number of columns must be a factor of the number of pixels")
        }

        else if (numberOfPixels / columnsInt > 255)
        {
            throw IllegalArgumentException("Contains more than 255 rows");
        }
    }

    /**
     * The number of rows within the [Image].
     */
    val rows: UByte get() = (pixels.count() / columns.toInt()).toUByte()

    /**
     * A sequence of [UByte]s which describe this [Image].
     */
    val serialized: Sequence<UByte>
        get() = sequence {
            yield(columns)
            yield(rows)
            yieldAll(pixels.flatMap { it.serialized })
        }
}
