using ProjectCommon.Models.Material.Gravel;

namespace UnitTestProject.Gravel
{
    [TestClass]
    public class CrushabilityGravelTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0)]
        [DataRow(66.0, 54.0)]
        [DataRow(52.0, 44.0)]
        [DataRow(57.0, 49.0)]
        public void TestCalculateMethodEquals(double gravelMass, double gravelCrushabilityMass)
        {
            CrushabilityGravelTest crushabilityGravelTest = new CrushabilityGravelTest();
            crushabilityGravelTest.GravelMass.DimensionValue = gravelMass;
            crushabilityGravelTest.GravelCrushabilityMass.DimensionValue = gravelCrushabilityMass;

            crushabilityGravelTest.Calculate();

            var expectedResult = (gravelMass - gravelCrushabilityMass) / gravelMass * 100.0;

            Assert.AreEqual(expectedResult, crushabilityGravelTest.GravelCrushability.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0)]
        [DataRow(10.0, 0.0)]
        [DataRow(-55.0, 7.0)]
        [DataRow(10.0, -64.0)]
        [DataRow(36.0, 47.0)]
        public void TestCalculateMethodException(double gravelMass, double gravelCrushabilityMass)
        {
            CrushabilityGravelTest crushabilityGravelTest = new CrushabilityGravelTest();
            crushabilityGravelTest.GravelMass.DimensionValue = gravelMass;
            crushabilityGravelTest.GravelCrushabilityMass.DimensionValue = gravelCrushabilityMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { crushabilityGravelTest.Calculate(); });
        }
    }
}
