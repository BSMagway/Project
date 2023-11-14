using ProjectCommon.Models.Material.Gravel;

namespace UnitTestProject.Gravel
{
    [TestClass]
    public class DustGravelTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0)]
        [DataRow(66.0, 54.0)]
        [DataRow(52.0, 44.0)]
        [DataRow(57.0, 49.0)]
        public void TestCalculateMethodEquals(double gravelMass, double gravelWithoutDustMass)
        {
            DustGravelTest dustGravelTest = new DustGravelTest();
            dustGravelTest.GravelMass.DimensionValue = gravelMass;
            dustGravelTest.GravelWithoutDustMass.DimensionValue = gravelWithoutDustMass;

            dustGravelTest.Calculate();

            var expectedResult = (gravelMass - gravelWithoutDustMass) / gravelMass * 100.0;

            Assert.AreEqual(expectedResult, dustGravelTest.GravelDust.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0)]
        [DataRow(10.0, 0.0)]
        [DataRow(-55.0, 7.0)]
        [DataRow(10.0, -64.0)]
        [DataRow(36.0, 47.0)]
        public void TestCalculateMethodException(double gravelMass, double gravelWithoutDustMass)
        {
            DustGravelTest dustGravelTest = new DustGravelTest();
            dustGravelTest.GravelMass.DimensionValue = gravelMass;
            dustGravelTest.GravelWithoutDustMass.DimensionValue = gravelWithoutDustMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { dustGravelTest.Calculate(); });
        }
    }
}
