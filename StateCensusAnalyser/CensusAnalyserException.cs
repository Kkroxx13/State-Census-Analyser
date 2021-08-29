using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyser
{
    class CensusAnalyserException : Exception
    {
        public enum CensusExceptionType
        {
            file_not_found
        }
        CensusExceptionType exceptionType;
        public CensusAnalyserException(CensusExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            this.exceptionType = exceptionType;
        }
    }
}
