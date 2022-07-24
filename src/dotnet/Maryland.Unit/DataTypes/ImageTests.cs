using Maryland.DataTypes;
using System.Collections.Immutable;
using System.Linq;

namespace Maryland.Unit.DataTypes
{
    [TestClass]
    public sealed class ImageTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            byte columns = 3;
            var pixels = ImmutableArray.Create
            (
                new ColorWithOpacity(0xf0, 0xa6, 0x10, 0xae),
                new ColorWithOpacity(0x0b, 0x70, 0xd9, 0x08),
                new ColorWithOpacity(0x72, 0xe3, 0x78, 0xed),
                new ColorWithOpacity(0x47, 0xea, 0x60, 0x55), 
                new ColorWithOpacity(0x0e, 0x65, 0xde, 0x6a),
                new ColorWithOpacity(0xe9, 0xe9, 0x6c, 0x0d)
            );

            var image = new Image(columns, pixels);

            Assert.AreEqual(columns, image.Columns);
            Assert.AreEqual(2, image.Rows);
            CollectionAssert.AreEqual(pixels, image.Pixels);
            CollectionAssert.AreEqual
            (
                new byte[] 
                { 
                    columns, 
                    2, 
                    0xf0, 0xa6, 0x10, 0xae, 0x0b, 0x70, 0xd9, 0x08, 0x72, 0xe3, 0x78, 0xed,
                    0x47, 0xea, 0x60, 0x55, 0x0e, 0x65, 0xde, 0x6a, 0xe9, 0xe9, 0x6c, 0x0d
                },
                image.Serialized.ToArray()
            );
        }

        [TestMethod]
        public void ExposesGivenDataOneRow()
        {
            byte columns = 6;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            var image = new Image(columns, pixels);

            Assert.AreEqual(columns, image.Columns);
            Assert.AreEqual(1, image.Rows);
            CollectionAssert.AreEqual(pixels, image.Pixels);
        }

        [TestMethod]
        public void ExposesGivenDataOneColumn()
        {
            byte columns = 1;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            var image = new Image(columns, pixels);

            Assert.AreEqual(columns, image.Columns);
            Assert.AreEqual(6, image.Rows);
            CollectionAssert.AreEqual(pixels, image.Pixels);
        }

        [TestMethod]
        public void ExposesGivenData255Rows()
        {
            byte columns = 3;
            var pixels = Enumerable.Range(0, 765).Select((x) => Generate.ColorWithOpacity()).ToImmutableArray();

            var image = new Image(columns, pixels);

            Assert.AreEqual(columns, image.Columns);
            Assert.AreEqual(255, image.Rows);
            CollectionAssert.AreEqual(pixels, image.Pixels);
        }

        [TestMethod]
        public void ThrowsExceptionWhenPixelsUninitialized()
        {
            byte columns = 3;

            try
            {
                _ = new Image(columns, default);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized and non-empty. (Parameter 'pixels')", exception.Message);
                Assert.AreEqual("pixels", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenPixelsEmpty()
        {
            byte columns = 3;

            try
            {
                _ = new Image(columns, ImmutableArray<ColorWithOpacity>.Empty);
                Assert.Fail();
            }
            catch (ArgumentNullException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Value must be initialized and non-empty. (Parameter 'pixels')", exception.Message);
                Assert.AreEqual("pixels", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColumnsZero()
        {
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            try
            {
                _ = new Image(0, pixels);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must be a factor of the number of pixels. (Parameter 'columns')", exception.Message);
                Assert.AreEqual("columns", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenMoreColumnsThanPixels()
        {
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            try
            {
                _ = new Image(7, pixels);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must be a factor of the number of pixels. (Parameter 'columns')", exception.Message);
                Assert.AreEqual("columns", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColumnsNonFactorOfNumberOfPixels()
        {
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            try
            {
                _ = new Image(4, pixels);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Must be a factor of the number of pixels. (Parameter 'columns')", exception.Message);
                Assert.AreEqual("columns", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenPixelsDescribes256Rows()
        {
            byte columns = 3;
            var pixels = Enumerable.Range(0, 768).Select((x) => Generate.ColorWithOpacity()).ToImmutableArray();

            try
            {
                _ = new Image(columns, pixels);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Contains more than 255 rows. (Parameter 'pixels')", exception.Message);
                Assert.AreEqual("pixels", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenPixelsDescribes257Rows()
        {
            byte columns = 3;
            var pixels = Enumerable.Range(0, 771).Select((x) => Generate.ColorWithOpacity()).ToImmutableArray();

            try
            {
                _ = new Image(columns, pixels);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual("Contains more than 255 rows. (Parameter 'pixels')", exception.Message);
                Assert.AreEqual("pixels", exception.ParamName);
            }
        }

        [TestMethod]
        public void Equal()
        {
            byte columns = 3;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var a = new Image(columns, pixels);
            var b = new Image(columns, pixels.Select(x => x).ToImmutableArray());

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalColumns()
        {
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var a = new Image(3, pixels);
            var b = new Image(6, pixels.Select(x => x).ToImmutableArray());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalPixelLength()
        {
            byte columns = 3;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var a = new Image(columns, pixels);
            var b = new Image(columns, pixels.Concat(new[] { Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity() }).ToImmutableArray());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalPixelValue()
        {
            byte columns = 3;
            var pixelsA = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var pixelsB = pixelsA.Take(4).Concat(new[] { Generate.DifferentColorWithOpacity(pixelsA[4]) }).Concat(pixelsA.Skip(5)).ToImmutableArray();
            var a = new Image(columns, pixelsA);
            var b = new Image(columns, pixelsB);

            Assert.AreNotEqual(a, b);
        }
    }
}
