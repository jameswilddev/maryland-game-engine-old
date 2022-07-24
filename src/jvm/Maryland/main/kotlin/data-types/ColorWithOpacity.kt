/**
 * A 32-bit red/green/blue/opacity color.
 * @param red The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity (premultiplied by the [ColorWithOpacity.opacity]).
 * @param green The intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity (premultiplied by the [ColorWithOpacity.opacity]).
 * @param blue The intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity (premultiplied by the [ColorWithOpacity.opacity]).
 * @param opacity The opacity of the color, where 0 is fully transparent and 255 is fully opaque.
 * @constructor Creates a new 32-bit red/green/blue/opacity color.
 */
data class ColorWithOpacity(val red: UByte, val green: UByte, val blue: UByte, val opacity: UByte) {
    /**
     * A sequence of [UByte]s which describe this color.
     */
    val serialized: Sequence<UByte>
        get() = sequence {
            yield(red)
            yield(green)
            yield(blue)
            yield(opacity)
        }
}
