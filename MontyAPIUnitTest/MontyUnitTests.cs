using MontyHallService.Domain;

namespace MontyAPIUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimulateMontyHallWithChange()
        {
            var result = MontyHallSimulation.MontySimulationCall(10000, true);
            Console.WriteLine(result);
            Assert.Pass();
        }
        [Test]
        public void SimulateMontyHallWithNoChange()
        {
            var result = MontyHallSimulation.MontySimulationCall(10000, false);
            Console.WriteLine(result);
            Assert.Pass();
        }
    }
}