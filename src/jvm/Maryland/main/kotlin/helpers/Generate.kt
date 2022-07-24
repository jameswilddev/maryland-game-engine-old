import com.google.common.collect.ImmutableList
import kotlin.random.Random
import kotlin.random.nextUBytes

internal object Generate {
    fun byte(): UByte {
        return Random.nextUBytes(1)[0]
    }

    fun colorWithOpacity(): ColorWithOpacity {
        val bytes = Random.nextUBytes(4)
        return ColorWithOpacity(bytes[0], bytes[1], bytes[2], bytes[3])
    }

    fun colorsWithOpacity(length: Int): ImmutableList<ColorWithOpacity>
    {
        var output = ImmutableList.builder<ColorWithOpacity>()

        for (i in 0 until length) {
            output.add(colorWithOpacity())
        }

        return output.build()
    }
}