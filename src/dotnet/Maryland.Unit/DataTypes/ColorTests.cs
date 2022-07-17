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
            var green = Generate.Byte();
            var blue = Generate.Byte();
            var a = new Color(Generate.Byte(), green, blue);
            var b = new Color(Generate.Byte(), green, blue);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalGreen()
        {
            var red = Generate.Byte();
            var blue = Generate.Byte();
            var a = new Color(red, Generate.Byte(), blue);
            var b = new Color(red, Generate.Byte(), blue);

            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void InequalBlue()
        {
            var red = Generate.Byte();
            var green = Generate.Byte();
            var a = new Color(red, green, Generate.Byte());
            var b = new Color(red, green, Generate.Byte());

            Assert.AreNotEqual(a, b);
        }
    }
}
