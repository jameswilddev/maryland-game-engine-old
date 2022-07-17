using Maryland.DataTypes;
using System.Collections.Immutable;

namespace Maryland.Unit.DataTypes
{
    [TestClass]
    public sealed class ImageTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var columns = 3;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            var image = new Image(columns, pixels);

            Assert.AreEqual(columns, image.Columns);
            CollectionAssert.AreEqual(pixels, image.Pixels);
        }

        [TestMethod]
        public void ExposesGivenDataOneRow()
        {
            var columns = 6;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            var image = new Image(columns, pixels);

            Assert.AreEqual(columns, image.Columns);
            CollectionAssert.AreEqual(pixels, image.Pixels);
        }

        [TestMethod]
        public void ExposesGivenDataOneColumn()
        {
            var columns = 1;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            var image = new Image(columns, pixels);

            Assert.AreEqual(columns, image.Columns);
            CollectionAssert.AreEqual(pixels, image.Pixels);
        }

        [TestMethod]
        public void ThrowsExceptionWhenPixelsUninitialized()
        {
            var columns = 3;

            try
            {
                _ = new Image(columns, default(ImmutableArray<ColorWithOpacity>));
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
            var columns = 3;

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
                Assert.AreEqual("Must be factor of the number of pixels. (Parameter 'columns')", exception.Message);
                Assert.AreEqual("columns", exception.ParamName);
            }
        }

        [TestMethod]
        public void ThrowsExceptionWhenColumnsNegative()
        {
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());

            try
            {
                _ = new Image(-1, pixels);
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
                Assert.AreEqual("Must be factor of the number of pixels. (Parameter 'columns')", exception.Message);
                Assert.AreEqual("columns", exception.ParamName);
            }
        }

        [TestMethod]
        public void Equal()
        {
            var columns = 3;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var a = new Image(columns, pixels);
            var b = new Image(columns, pixels.ToImmutableArray());

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalColumns()
        {
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var a = new Image(3, pixels);
            var b = new Image(6, pixels.ToImmutableArray());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalPixelLength()
        {
            var columns = 3;
            var pixels = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var a = new Image(columns, pixels);
            var b = new Image(columns, pixels.Concat(new[] { Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity() }).ToImmutableArray());

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalPixelValue()
        {
            var columns = 3;
            var pixelsA = ImmutableArray.Create(Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity(), Generate.ColorWithOpacity());
            var pixelsB = pixelsA.Take(4).Concat(new[] { Generate.DifferentColorWithOpacity(pixelsA[4]) }).Concat(pixelsA.Skip(5)).ToImmutableArray();
            var a = new Image(columns, pixelsA);
            var b = new Image(columns, pixelsB);

            Assert.AreNotEqual(a, b);
        }
    }
}
