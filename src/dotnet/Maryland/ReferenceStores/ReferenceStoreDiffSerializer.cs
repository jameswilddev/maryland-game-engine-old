namespace Maryland.ReferenceStores
{
    /// <summary>
    /// Serializes <see cref="ReferenceStoreDiff"/>s to <see cref="byte"/> sequences.
    /// </summary>
    public sealed class ReferenceStoreDiffSerializer : IReferenceStoreDiffSerializer
    {
        private static IEnumerable<byte> SerializeU32(uint value) => BitConverter.GetBytes(value);

        private IEnumerable<byte> SerializeGuid(Guid value)
        {
            var output = value.ToByteArray();

            yield return output[3];
            yield return output[2];
            yield return output[1];
            yield return output[0];
            yield return output[5];
            yield return output[4];
            yield return output[7];
            yield return output[6];
            yield return output[8];
            yield return output[9];
            yield return output[10];
            yield return output[11];
            yield return output[12];
            yield return output[13];
            yield return output[14];
            yield return output[15];
        }

        private IEnumerable<byte> SerializeEntityAttributeIdentifierPair(EntityAttributeIdentifierPair entityAttributeIdentifierPair)
        {
            return SerializeGuid(entityAttributeIdentifierPair.Entity).Concat(SerializeGuid(entityAttributeIdentifierPair.Attribute));
        }

        private IEnumerable<byte> SerializeMapping(KeyValuePair<EntityAttributeIdentifierPair, Guid> mapping) => SerializeEntityAttributeIdentifierPair(mapping.Key).Concat(SerializeGuid(mapping.Value));

        /// <inheritdoc />
        public IEnumerable<byte> Serialize(ReferenceStoreDiff referenceStoreDiff)
        {
            return SerializeU32((uint)referenceStoreDiff.Set.Count)
                .Concat(referenceStoreDiff.Set.OrderBy(m => m.Key.Entity).ThenBy(m => m.Key.Attribute).SelectMany(SerializeMapping))
                .Concat(SerializeU32((uint)referenceStoreDiff.Deleted.Count))
                .Concat(referenceStoreDiff.Deleted.OrderBy(m => m.Entity).ThenBy(m => m.Attribute).SelectMany(SerializeEntityAttributeIdentifierPair));
        }
    }
}
