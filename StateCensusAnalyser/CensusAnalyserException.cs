using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyzer
{
    public class CensusAnalyserException : Exception
    {
        public enum CensusExceptionType
        {
            file_not_found,incorrectType
        }
        CensusExceptionType exceptionType;
        public CensusAnalyserException(CensusExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            this.exceptionType = exceptionType;
        }
    }
}
