using ProjectCommon.Models.Material.Gravel;
using ProjectCommon.Models.Material.Sand;

namespace UnitTestProject.Sand
{
    [TestClass]
    public class BulkDensitySandTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0, 10)]
        [DataRow(66.0, 54.0, 10)]
        [DataRow(52.0, 44.0, 10)]
        [DataRow(57.0, 49.0, 10)]
        public void TestCalculateMethodEquals(double bulkDensityCylinderWithSandMass, double bulkDensityCylinderMass, double cylinderVolume)
        {
            BulkDensitySandTest bulkDensitySandTest = new BulkDensitySandTest();
            bulkDensitySandTest.BulkDensityCylinderMass.DimensionValue = bulkDensityCylinderMass;
            bulkDensitySandTest.BulkDensityCylinderWithSandMass.DimensionValue = bulkDensityCylinderWithSandMass;
            bulkDensitySandTest.CylinderVolume.DimensionValue = cylinderVolume;

            bulkDensitySandTest.Calculate();

            var expectedResult = (bulkDensityCylinderWithSandMass - bulkDensityCylinderMass) / cylinderVolume;

            Assert.AreEqual(expectedResult, bulkDensitySandTest.SandBulkDensity.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0, 10)]
        [DataRow(10.0, 0.0, 10)]
        [DataRow(-55.0, 7.0, 0)]
        [DataRow(10.0, -64.0, 10)]
        [DataRow(10.0, 64.0, -10)]
        [DataRow(41.0, 47.0, 10)]
        public void TestCalculateMethodException(double bulkDensityCylinderWithSandMass, double bulkDensityCylinderMass, double cylinderVolume)
        {
            BulkDensitySandTest bulkDensitySandTest = new BulkDensitySandTest();
            bulkDensitySandTest.BulkDensityCylinderMass.DimensionValue = bulkDensityCylinderMass;
            bulkDensitySandTest.BulkDensityCylinderWithSandMass.DimensionValue = bulkDensityCylinderWithSandMass;
            bulkDensitySandTest.CylinderVolume.DimensionValue = cylinderVolume;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { bulkDensitySandTest.Calculate(); });
        }
    }
}
