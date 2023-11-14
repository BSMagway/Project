using ProjectCommon.Models.Material.Gravel;

namespace UnitTestProject.Gravel
{
    [TestClass]
    public class FlakyGrainsGravelTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0)]
        [DataRow(66.0, 54.0)]
        [DataRow(52.0, 44.0)]
        [DataRow(57.0, 49.0)]
        public void TestCalculateMethodEquals(double gravelMass, double gravelFlakyGrainsMass)
        {
            FlakyGrainsGravelTest flakyGrainsGravelTest = new FlakyGrainsGravelTest();
            flakyGrainsGravelTest.GravelMass.DimensionValue = gravelMass;
            flakyGrainsGravelTest.GravelFlakyGrainsMass.DimensionValue = gravelFlakyGrainsMass;

            flakyGrainsGravelTest.Calculate();

            var expectedResult = gravelFlakyGrainsMass / gravelMass * 100.0;

            Assert.AreEqual(expectedResult, flakyGrainsGravelTest.GravelFlakyGrains.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0)]
        [DataRow(10.0, 0.0)]
        [DataRow(-55.0, 7.0)]
        [DataRow(10.0, -64.0)]
        [DataRow(36.0, 47.0)]
        public void TestCalculateMethodException(double gravelMass, double gravelFlakyGrainsMass)
        {
            FlakyGrainsGravelTest flakyGrainsGravelTest = new FlakyGrainsGravelTest();
            flakyGrainsGravelTest.GravelMass.DimensionValue = gravelMass;
            flakyGrainsGravelTest.GravelFlakyGrainsMass.DimensionValue = gravelFlakyGrainsMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { flakyGrainsGravelTest.Calculate(); });
        }
    }
}
