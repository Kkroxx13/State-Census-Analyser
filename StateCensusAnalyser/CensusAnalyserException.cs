namespace StateCensusAnalyzer
{
    using System;

    public class ExceptionFileNotFound : Exception
    {
        public StateCensusException FileFoundException;

        
        public ExceptionFileNotFound(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.FileFoundException = exception;
        } 
    }

    public class ExceptionWrongFile : Exception
    {
        public StateCensusException WrongFileException;


        public ExceptionWrongFile(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.WrongFileException = exception;
        }
    }

    public class ExceptionWrongDelimeter : Exception
    {
        public StateCensusException WrongDelimeter;

        public ExceptionWrongDelimeter(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.WrongDelimeter = exception;
        }
    }

    public class ExceptionInvalidHeaders : Exception
    {
        public StateCensusException InvalidHeaders;
        
        public ExceptionInvalidHeaders(StateCensusException exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.InvalidHeaders = exception;
        }
    }
} 
