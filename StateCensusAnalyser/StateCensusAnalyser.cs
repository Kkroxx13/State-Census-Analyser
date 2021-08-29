using LumenWorks.Framework.IO.Csv;
using StateCensusAnalyzer;
using System;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {

        int numberOfRecords = 0;
        string filePath;
        char delimeter;
        string[] headers = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };

        public StateCensusAnalyser(string path = @"C:\Users\kkancha\source\repos\StateCensusAnalyser\StateCensusData.csv")
        {
            this.filePath = path;
        }

        static void Main(string[] args)
        {

        }
        public void ReadRecords(string[] inputHeaders = null, char inputDelimeter = ',')
        {
            try
            {
                if (inputHeaders is null)
                {
                    inputHeaders = headers;
                }
                // if the given file is not csv file rise exception
                if (!filePath.EndsWith(".csv"))
                {
                    throw new ExceptionWrongFile(StateCensusException.wrongFile, "file type is incorrect");
                }
                var records = new StreamReader(filePath);
                using (CsvReader csvRecords = new CsvReader(records))
                {

                    // count number of records
                    while (csvRecords.ReadNextRecord()) numberOfRecords++;
                    // get delimeter 
                    delimeter = csvRecords.Delimiter;
                    // get header details
                    string[] fileHeaders = csvRecords.GetFieldHeaders();
                    // if delimeter of file is different raise Exception
                    if (!inputDelimeter.Equals(delimeter))
                    {
                        throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, "File has Different Delimeter");
                    }
                    if (!IsHeaderSame(fileHeaders, inputHeaders))
                    {
                        throw new ExceptionInvalidHeaders(StateCensusException.invalidHeaders, "Headers of file are not valid");
                    }
                }
            }
            catch (ExceptionWrongFile)
            {
                throw new ExceptionWrongFile(StateCensusException.wrongFile, "file type is incorrect");
            }
            catch (ExceptionWrongDelimeter)
            {
                throw new ExceptionWrongDelimeter(StateCensusException.wrongDelimeter, "File has different delimeter than given");
            }
            catch (ExceptionInvalidHeaders)
            {
                throw new ExceptionInvalidHeaders(StateCensusException.invalidHeaders, "Headers of file are not valid");
            }

            catch (FileNotFoundException)
            {
                throw new ExceptionFileNotFound(StateCensusException.fileNotFound, "Wrong file path or file missing");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public int GetNumberOfRecords()
        {
            return numberOfRecords;
        }

        public dynamic Delimeter()
        {
            return delimeter;
        }
        public bool IsHeaderSame(string[] header1, string[] header2)
        {
            // if length os the strings different return false
            if (header1.Length != header2.Length) return false;
            // loop and check each and every value of 2 strings
            for (int i = 0; i < header1.Length; i++)
            {
                if (header1[i].ToLower().CompareTo(header2[i].ToLower()) != 0) return false;
            }
            return true;
        }


    }
}