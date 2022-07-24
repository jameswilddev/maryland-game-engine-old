import java.util.*

internal object Serialize {
    fun uuid(uuid: UUID): Sequence<UByte> {
        return sequence {
            yield (((uuid.mostSignificantBits shr 56) and 255).toUByte())
            yield (((uuid.mostSignificantBits shr 48) and 255).toUByte())
            yield (((uuid.mostSignificantBits shr 40) and 255).toUByte())
            yield (((uuid.mostSignificantBits shr 32) and 255).toUByte())
            yield (((uuid.mostSignificantBits shr 24) and 255).toUByte())
            yield (((uuid.mostSignificantBits shr 16) and 255).toUByte())
            yield (((uuid.mostSignificantBits shr 8) and 255).toUByte())
            yield ((uuid.mostSignificantBits and 255).toUByte())
            yield (((uuid.leastSignificantBits shr 56) and 255).toUByte())
            yield (((uuid.leastSignificantBits shr 48) and 255).toUByte())
            yield (((uuid.leastSignificantBits shr 40) and 255).toUByte())
            yield (((uuid.leastSignificantBits shr 32) and 255).toUByte())
            yield (((uuid.leastSignificantBits shr 24) and 255).toUByte())
            yield (((uuid.leastSignificantBits shr 16) and 255).toUByte())
            yield (((uuid.leastSignificantBits shr 8) and 255).toUByte())
            yield ((uuid.leastSignificantBits and 255).toUByte())
        }
    }
}