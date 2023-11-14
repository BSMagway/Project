using ProjectCommon.Models.Material.Gravel;

namespace UnitTestProject.Gravel
{
    [TestClass]
    public class WeakGrainsGravelTestUnitTest
    {
        [TestMethod]
        [DataRow(10.0, 7.0)]
        [DataRow(66.0, 54.0)]
        [DataRow(52.0, 44.0)]
        [DataRow(57.0, 49.0)]
        public void TestCalculateMethodEquals(double gravelMass, double gravelWeakGrainsMass)
        {
            WeakGrainsGravelTest weakGrainsGravelTest = new WeakGrainsGravelTest();
            weakGrainsGravelTest.GravelMass.DimensionValue = gravelMass;
            weakGrainsGravelTest.GravelWeakGrainsMass.DimensionValue = gravelWeakGrainsMass;

            weakGrainsGravelTest.Calculate();

            var expectedResult = gravelWeakGrainsMass / gravelMass * 100.0;

            Assert.AreEqual(expectedResult, weakGrainsGravelTest.GravelWeakGrains.DimensionValue);
        }

        [TestMethod]
        [DataRow(0.0, 7.0)]
        [DataRow(10.0, 0.0)]
        [DataRow(-55.0, 7.0)]
        [DataRow(10.0, -64.0)]
        [DataRow(36.0, 47.0)]
        public void TestCalculateMethodException(double gravelMass, double gravelWeakGrainsMass)
        {
            ProjectCommon.Models.Material.Gravel.WeakGrainsGravelTest weakGrainsGravelTest = new ProjectCommon.Models.Material.Gravel.WeakGrainsGravelTest();
            weakGrainsGravelTest.GravelMass.DimensionValue = gravelMass;
            weakGrainsGravelTest.GravelWeakGrainsMass.DimensionValue = gravelWeakGrainsMass;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { weakGrainsGravelTest.Calculate(); });
        }
    }
}
