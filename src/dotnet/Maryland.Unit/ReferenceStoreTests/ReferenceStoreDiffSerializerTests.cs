﻿using Maryland.ReferenceStores;
using System.Collections.Immutable;

namespace Maryland.Unit.ReferenceStoreTests
{
    [TestClass]
    public sealed class ReferenceStoreDiffSerializerTests
    {
        [TestMethod]
        public void SerializesToBytes()
        {
            var entityA = new Guid("291bcdb8-9199-49b2-8dff-b8584934121e");
            var entityB = new Guid("d2b6790d-9fa2-4595-8100-d44cee52c696");
            var entityC = new Guid("f6bd80cc-16e0-478e-a1b9-2ddc9c6c4c0f");
            var attributeA = new Guid("b51793db-115e-43f6-843c-a8abef20f76c");
            var attributeB = new Guid("094717c7-d5ac-4801-bc23-bb706539c7db");
            var attributeC = new Guid("a2b2b0fb-d50a-4eb0-bc63-8f481260e43c");
            var valueAA = new Guid("47e69a06-bd8e-4ba2-8358-aba5350fe7af");
            var valueAB = new Guid("00b0787f-174c-4a7a-b226-735a6ca8474c");
            var valueBA = new Guid("2726bd2e-3216-48b8-9a87-b4b5facf6371");
            var set = ImmutableDictionary<EntityAttributeIdentifierPair, Guid>
                .Empty
                .Add(new EntityAttributeIdentifierPair(entityA, attributeA), valueAA)
                .Add(new EntityAttributeIdentifierPair(entityA, attributeB), valueAB)
                .Add(new EntityAttributeIdentifierPair(entityB, attributeA), valueBA);
            var deleted = ImmutableHashSet.Create
            (
                new EntityAttributeIdentifierPair(entityA, attributeC),
                new EntityAttributeIdentifierPair(entityC, attributeA)
            );
            var referenceStoreDiff = new ReferenceStoreDiff(set, deleted);
            var referenceStoreDiffSerializer = new ReferenceStoreDiffSerializer();

            var actual = referenceStoreDiffSerializer.Serialize(referenceStoreDiff).ToArray();

            var expected = new byte[]
            {
                3, 0, 0, 0,
                0x29, 0x1b, 0xcd, 0xb8, 0x91, 0x99, 0x49, 0xb2, 0x8d, 0xff, 0xb8, 0x58, 0x49, 0x34, 0x12, 0x1e,
                0x09, 0x47, 0x17, 0xc7, 0xd5, 0xac, 0x48, 0x01, 0xbc, 0x23, 0xbb, 0x70, 0x65, 0x39, 0xc7, 0xdb,
                0x00, 0xb0, 0x78, 0x7f, 0x17, 0x4c, 0x4a, 0x7a, 0xb2, 0x26, 0x73, 0x5a, 0x6c, 0xa8, 0x47, 0x4c,
                0x29, 0x1b, 0xcd, 0xb8, 0x91, 0x99, 0x49, 0xb2, 0x8d, 0xff, 0xb8, 0x58, 0x49, 0x34, 0x12, 0x1e,
                0xb5, 0x17, 0x93, 0xdb, 0x11, 0x5e, 0x43, 0xf6, 0x84, 0x3c, 0xa8, 0xab, 0xef, 0x20, 0xf7, 0x6c,
                0x47, 0xe6, 0x9a, 0x06, 0xbd, 0x8e, 0x4b, 0xa2, 0x83, 0x58, 0xab, 0xa5, 0x35, 0x0f, 0xe7, 0xaf,
                0xd2, 0xb6, 0x79, 0x0d, 0x9f, 0xa2, 0x45, 0x95, 0x81, 0x00, 0xd4, 0x4c, 0xee, 0x52, 0xc6, 0x96,
                0xb5, 0x17, 0x93, 0xdb, 0x11, 0x5e, 0x43, 0xf6, 0x84, 0x3c, 0xa8, 0xab, 0xef, 0x20, 0xf7, 0x6c,
                0x27, 0x26, 0xbd, 0x2e, 0x32, 0x16, 0x48, 0xb8, 0x9a, 0x87, 0xb4, 0xb5, 0xfa, 0xcf, 0x63, 0x71,
                2, 0, 0, 0,
                0x29, 0x1b, 0xcd, 0xb8, 0x91, 0x99, 0x49, 0xb2, 0x8d, 0xff, 0xb8, 0x58, 0x49, 0x34, 0x12, 0x1e,
                0xa2, 0xb2, 0xb0, 0xfb, 0xd5, 0x0a, 0x4e, 0xb0, 0xbc, 0x63, 0x8f, 0x48, 0x12, 0x60, 0xe4, 0x3c,
                0xf6, 0xbd, 0x80, 0xcc, 0x16, 0xe0, 0x47, 0x8e, 0xa1, 0xb9, 0x2d, 0xdc, 0x9c, 0x6c, 0x4c, 0x0f,
                0xb5, 0x17, 0x93, 0xdb, 0x11, 0x5e, 0x43, 0xf6, 0x84, 0x3c, 0xa8, 0xab, 0xef, 0x20, 0xf7, 0x6c,
            };
            CollectionAssert.AreEqual(expected, actual, $"Expected: {Convert.ToHexString(expected)}, actual: {Convert.ToHexString(actual)}");
        }
    }
}
