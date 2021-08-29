using NUnit.Framework;
using CensusAnalyser;
using System;

namespace CensusAnalyserTest
{
    public class Tests
    {
        const string filePath = @"C:\Users\kkancha\source\repos\StateCensusAnalyser\StateCensusData.csv";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MatchNumberOfRecords()
        {
            int expected = 29;
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(filePath);
            stateCensusAnalyser.ReadRecords();
            int actual = stateCensusAnalyser.GetNoOfRecords();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenCsvFilePAth_WhenImproper_ShouldThrowException()
        {
            string expected = "Wrong file path or file missing";
            try
            {
                StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\kkancha\source\repos\StateCensusAnalyser\StateData.csv");
                stateCensusAnalyser.ReadRecords();
            }
            catch(Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        [Test]
        public void GivenCsvFilePath_WhenTypeImproper_ShouldThrowException()
        {
            string expected = "file type is incorrect";
            try
            {
                StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser(@"C:\Users\kkancha\source\repos\StateCensusAnalyser\StateData.txt");
                stateCensusAnalyser.ReadRecords();
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}