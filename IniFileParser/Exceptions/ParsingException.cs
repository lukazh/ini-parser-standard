using System;

namespace IniFileParser.Exceptions
{
    /// <summary>
    /// Represents an error occurred while parsing data 
    /// </summary>
    public class ParsingException : Exception
    {
        public int LineNumber { get; }
        public string LineValue { get; }

        public ParsingException(string msg)
            : this(msg, 0, string.Empty, null)
        { }

        public ParsingException(string msg, Exception innerException)
            : this(msg, 0, string.Empty, innerException)
        { }

        public ParsingException(string msg, int lineNumber, string lineValue)
            : this(msg, lineNumber, lineValue, null)
        { }

        public ParsingException(string msg, int lineNumber, string lineValue, Exception innerException)
            : base(
                string.Format(
                    "{0} while parsing line number {1} with value \'{2}\'",
                    msg, lineNumber, lineValue),
                innerException)
        {
            LineNumber = lineNumber;
            LineValue = lineValue;
        }
    }
}
