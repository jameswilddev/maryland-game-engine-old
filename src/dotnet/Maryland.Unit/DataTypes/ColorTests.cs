using Maryland.DataTypes;

namespace Maryland.Unit.DataTypes
{
    [TestClass]
    public sealed class ColorTests
    {
        [TestMethod]
        public void ExposesGivenData()
        {
            var red = Generate.Byte();
            var green = Generate.Byte();
            var blue = Generate.Byte();

            var color = new Color(red, green, blue);

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
            var a = new Color(red, green, blue);
            var b = new Color(red, green, blue);

            Assert.AreEqual(a, b);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void InequalRed()
        {
            var redA = Generate.Byte();
            var green = Generate.Byte();
            var blue = Generate.Byte();
            var a = new Color(redA, green, blue);
            var b = new Color(Generate.DifferentByte(redA), green, blue);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalGreen()
        {
            var red = Generate.Byte();
            var greenA = Generate.Byte();
            var blue = Generate.Byte();
            var a = new Color(red, greenA, blue);
            var b = new Color(red, Generate.DifferentByte(greenA), blue);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalBlue()
        {
            var red = Generate.Byte();
            var green = Generate.Byte();
            var blueA = Generate.Byte();
            var a = new Color(red, green, blueA);
            var b = new Color(red, green, Generate.DifferentByte(blueA));

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalNull()
        {
            var a = new Color(Generate.Byte(), Generate.Byte(), Generate.Byte());

            Assert.AreNotEqual(a, null);
        }

        [TestMethod]
        public void InequalType()
        {
            var a = new Color(Generate.Byte(), Generate.Byte(), Generate.Byte());

            Assert.AreNotEqual(a, 1);
        }
    }
}
