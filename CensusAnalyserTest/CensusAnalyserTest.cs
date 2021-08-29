using NUnit.Framework;
using CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MatchNumberOfRecords()
        {
            int expected = 29;
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\kkancha\source\repos\StateCensusAnalyser\StateCensusData.csv");
            int actual = stateCensusAnalyser.ReadRecords();
            Assert.AreEqual(expected, actual);
            
            
        }
    }
}