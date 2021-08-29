﻿using LumenWorks.Framework.IO.Csv;
using System;
using System.IO;
using System.Text;


namespace StateCensusAnalyser
{
    class StateCensusAnalyser
    {
        int numberOfRecords = default;
        string file;
        public StateCensusAnalyser(string file)
        {
            this.file = file;
        }

        public void ReadRecords()
        {
            try
            {
                using CsvReader records = new CsvReader(new StreamReader(this.file));
                while (records.ReadNextRecord())
                {
                    this.numberOfRecords++;
                }
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.file_not_found, "Wrong file path or file missing");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to State Census Analyser!!!");
        }
    }
}