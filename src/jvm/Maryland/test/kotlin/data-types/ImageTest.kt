import com.google.common.collect.ImmutableList
import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.TestInstance
import org.junit.jupiter.api.assertThrows

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
class ImageTest {
    @Test
    fun `Exposes given data`() {
        val columns: UByte = 3u
        val pixels = Generate.colorsWithOpacity(6)

        val image = Image(columns, pixels)

        assertEquals(columns, image.columns)
        assertEquals(2u.toUByte(), image.rows)
        assertEquals(pixels, image.pixels)
    }

    @Test
    fun `Exposes given data with one row`() {
        val columns: UByte = 6u
        val pixels = Generate.colorsWithOpacity(6)

        val image = Image(columns, pixels)

        assertEquals(columns, image.columns)
        assertEquals(1u.toUByte(), image.rows)
        assertEquals(pixels, image.pixels)
    }

    @Test
    fun `Exposes given data with one column`() {
        val columns: UByte = 1u
        val pixels = Generate.colorsWithOpacity(6)

        val image = Image(columns, pixels)

        assertEquals(columns, image.columns)
        assertEquals(6u.toUByte(), image.rows)
        assertEquals(pixels, image.pixels)
    }

    @Test
    fun `Exposes given data with 255 rows`() {
        val columns: UByte = 3u
        val pixels = Generate.colorsWithOpacity(765)

        val image = Image(columns, pixels)

        assertEquals(columns, image.columns)
        assertEquals(255u.toUByte(), image.rows)
        assertEquals(pixels, image.pixels)
    }

    @Test
    fun `Throws an exception without columns`() {
        var exception = assertThrows<IllegalArgumentException> {
            Image(0u, Generate.colorsWithOpacity(6))
        }

        assertEquals("Number of columns must be a factor of the number of pixels", exception.message)
        assertNull(exception.cause)
    }

    @Test
    fun `Throws an exception with more columns than pixels`() {
        var exception = assertThrows<IllegalArgumentException> {
            Image(7u, Generate.colorsWithOpacity(6))
        }

        assertEquals("Number of columns must be a factor of the number of pixels", exception.message)
        assertNull(exception.cause)
    }

    @Test
    fun `Throws an exception when pixels not equally divisible into rows`() {
        var exception = assertThrows<IllegalArgumentException> {
            Image(4u, Generate.colorsWithOpacity(6))
        }

        assertEquals("Number of columns must be a factor of the number of pixels", exception.message)
        assertNull(exception.cause)
    }

    @Test
    fun `Throws an exception when pixels describe 256 rows`() {
        var exception = assertThrows<IllegalArgumentException> {
            Image(3u, Generate.colorsWithOpacity(768))
        }

        assertEquals("Contains more than 255 rows", exception.message)
        assertNull(exception.cause)
    }

    @Test
    fun `Throws an exception when pixels describe 257 rows`() {
        var exception = assertThrows<IllegalArgumentException> {
            Image(3u, Generate.colorsWithOpacity(771))
        }

        assertEquals("Contains more than 255 rows", exception.message)
        assertNull(exception.cause)
    }

    @Test
    fun `Equal`() {
        val columns: UByte = 3u;
        val pixels = Generate.colorsWithOpacity(6)

        val a = Image(columns, pixels)
        val b = Image(columns, ImmutableList.copyOf(pixels.map { it.copy() }))

        assertEquals(a, b)
    }

    @Test
    fun `Inequal number of columns`() {
        val pixels = Generate.colorsWithOpacity(6)

        val a = Image(3u, pixels)
        val b = Image(2u, pixels)

        assertNotEquals(a, b)
    }

    @Test
    fun `Inequal number of rows`() {
        val columns: UByte = 3u;
        val pixels = Generate.colorsWithOpacity(6)

        val a = Image(columns, pixels)
        val b = Image(columns, ImmutableList.copyOf(pixels + Generate.colorsWithOpacity(3)))

        assertNotEquals(a, b)
    }

    @Test
    fun `Inequal pixel data`() {
        val columns: UByte = 3u;
        val pixels = Generate.colorsWithOpacity(12)

        val a = Image(columns, pixels)
        val b = Image(columns, ImmutableList.copyOf(pixels.subList(0, 4) + Generate.colorsWithOpacity(1) + pixels.subList(5, 6)))

        assertNotEquals(a, b)
    }
}