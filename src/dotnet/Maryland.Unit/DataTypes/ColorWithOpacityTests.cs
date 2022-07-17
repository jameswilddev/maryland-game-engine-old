using Maryland.DataTypes;

namespace Maryland.Unit.DataTypes
{
    [TestClass]
    public sealed class ColorWithOpacityTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var red = Generate.Byte();
            var green = Generate.Byte();
            var blue = Generate.Byte();
            var opacity = Generate.Byte();

            var color = new ColorWithOpacity(red, green, blue, opacity);

            Assert.AreEqual(red, color.Red);
            Assert.AreEqual(green, color.Green);
            Assert.AreEqual(blue, color.Blue);
        }

        [TestMethod]
        public void Equal()
        {
            var red = Generate.Byte();
            var green = Generate.Byte();
            var blue = Generate.Byte();
            var opacity = Generate.Byte();
            var a = new ColorWithOpacity(red, green, blue, opacity);
            var b = new ColorWithOpacity(red, green, blue, opacity);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalRed()
        {
            var redA = Generate.Byte();
            var green = Generate.Byte();
            var blue = Generate.Byte();
            var opacity = Generate.Byte();
            var a = new ColorWithOpacity(redA, green, blue, opacity);
            var b = new ColorWithOpacity(Generate.DifferentByte(redA), green, blue, opacity);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalGreen()
        {
            var red = Generate.Byte();
            var greenA = Generate.Byte();
            var blue = Generate.Byte();
            var opacity = Generate.Byte();
            var a = new ColorWithOpacity(red, greenA, blue, opacity);
            var b = new ColorWithOpacity(red, Generate.DifferentByte(greenA), blue, opacity);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalBlue()
        {
            var red = Generate.Byte();
            var green = Generate.Byte();
            var blueA = Generate.Byte();
            var opacity = Generate.Byte();
            var a = new ColorWithOpacity(red, green, blueA, opacity);
            var b = new ColorWithOpacity(red, green, Generate.DifferentByte(blueA), opacity);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalOpacity()
        {
            var red = Generate.Byte();
            var green = Generate.Byte();
            var blue = Generate.Byte();
            var opacityA = Generate.Byte();
            var a = new ColorWithOpacity(red, green, blue, opacityA);
            var b = new ColorWithOpacity(red, green, blue, Generate.DifferentByte(opacityA));

            Assert.AreNotEqual(a, b);
        }
    }
}
