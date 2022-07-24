import com.google.common.collect.ImmutableList
import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.TestInstance
import org.junit.jupiter.api.assertThrows

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
class ColorWithOpacityTest {
    @Test
    fun `Exposes given data`() {
        val red = Generate.byte()
        var green = Generate.byte()
        var blue = Generate.byte()
        var opacity = Generate.byte()

        val image = ColorWithOpacity(red, green, blue, opacity)

        assertEquals(red, image.red)
        assertEquals(green, image.green)
        assertEquals(blue, image.blue)
        assertEquals(opacity, image.opacity)
    }

    @Test
    fun `Equal`() {
        val red = Generate.byte()
        var green = Generate.byte()
        var blue = Generate.byte()
        var opacity = Generate.byte()

        val a = ColorWithOpacity(red, green, blue, opacity)
        val b = ColorWithOpacity(red, green, blue, opacity)

        assertEquals(a, b)
    }

    @Test
    fun `Inequal red`() {
        var green = Generate.byte()
        var blue = Generate.byte()
        var opacity = Generate.byte()

        val a = ColorWithOpacity(Generate.byte(), green, blue, opacity)
        val b = ColorWithOpacity(Generate.byte(), green, blue, opacity)

        assertNotEquals(a, b)
    }

    @Test
    fun `Inequal green`() {
        var red = Generate.byte()
        var blue = Generate.byte()
        var opacity = Generate.byte()

        val a = ColorWithOpacity(red, Generate.byte(), blue, opacity)
        val b = ColorWithOpacity(red, Generate.byte(), blue, opacity)

        assertNotEquals(a, b)
    }

    @Test
    fun `Inequal blue`() {
        var red = Generate.byte()
        var green = Generate.byte()
        var opacity = Generate.byte()

        val a = ColorWithOpacity(red, green, Generate.byte(), opacity)
        val b = ColorWithOpacity(red, green, Generate.byte(), opacity)

        assertNotEquals(a, b)
    }

    @Test
    fun `Inequal opacity`() {
        var red = Generate.byte()
        var green = Generate.byte()
        var blue = Generate.byte()

        val a = ColorWithOpacity(red, green, blue, Generate.byte())
        val b = ColorWithOpacity(red, green, blue, Generate.byte())

        assertNotEquals(a, b)
    }
}