using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyzer
{
    public class CensusAnalyserException : Exception
    {
        public enum CensusExceptionType
        {
            fileNotFound, incorrectType, incorrectDelimeter
        }
        CensusExceptionType exceptionType;
        public CensusAnalyserException(CensusExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            this.exceptionType = exceptionType;
        }
    }
}
