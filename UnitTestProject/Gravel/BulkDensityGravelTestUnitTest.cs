using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Sand;

namespace UnitTestProject.Gravel
{
    [TestClass]
    public class BulkDensityGravelTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0, 10)]
        [DataRow(66.0, 54.0, 10)]
        [DataRow(52.0, 44.0, 10)]
        [DataRow(57.0, 49.0, 10)]
        public void TestCalculateMethodEquals(double bulkDensityCylinderWithGravelMass, double bulkDensityCylinderMass, double cylinderVolume)
        {
            BulkDensityGravelTest bulkDensityGravelTest = new BulkDensityGravelTest();
            bulkDensityGravelTest.BulkDensityCylinderMass.DimensionValue = bulkDensityCylinderMass;
            bulkDensityGravelTest.BulkDensityCylinderWithGravelMass.DimensionValue = bulkDensityCylinderWithGravelMass;
            bulkDensityGravelTest.CylinderVolume.DimensionValue = cylinderVolume;

            bulkDensityGravelTest.Calculate();

            var expectedResult = (bulkDensityCylinderWithGravelMass - bulkDensityCylinderMass) / cylinderVolume;

            Assert.AreEqual(expectedResult, bulkDensityGravelTest.GravelBulkDensity.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0, 10)]
        [DataRow(10.0, 0.0, 10)]
        [DataRow(-55.0, 7.0, 0)]
        [DataRow(10.0, -64.0, 10)]
        [DataRow(10.0, 64.0, -10)]
        [DataRow(41.0, 47.0, 10)]
        public void TestCalculateMethodException(double bulkDensityCylinderWithGravelMass, double bulkDensityCylinderMass, double cylinderVolume)
        {
            BulkDensityGravelTest bulkDensityGravelTest = new BulkDensityGravelTest();
            bulkDensityGravelTest.BulkDensityCylinderMass.DimensionValue = bulkDensityCylinderMass;
            bulkDensityGravelTest.BulkDensityCylinderWithGravelMass.DimensionValue = bulkDensityCylinderWithGravelMass;
            bulkDensityGravelTest.CylinderVolume.DimensionValue = cylinderVolume;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { bulkDensityGravelTest.Calculate(); });
        }
    }
}
