﻿using LumenWorks.Framework.IO.Csv;
using System;
using System.IO;
using System.Text;
using StateCensusAnalyzer;


namespace CensusAnalyser

{
    public class StateCensusAnalyser
    {
        int numberOfRecords = default;
       readonly string file;
        public StateCensusAnalyser(string file)
        {
            try
            {
                if (file[file.Length - 4] != '.')
                    throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.incorrectDelimeter, "delimter is wrong for file type in path");

                if (!file.EndsWith(".csv"))
                    throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.incorrectType, "file type is incorrect");
                this.file = file;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public int GetNoOfRecords()
        {
            return numberOfRecords;
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
            catch (IOException)
            {
                throw new CensusAnalyserException(CensusAnalyserException.CensusExceptionType.fileNotFound, "Wrong file path or file missing");
            }

        }   
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to State Census Analyser!!!");
        }
    }
}
