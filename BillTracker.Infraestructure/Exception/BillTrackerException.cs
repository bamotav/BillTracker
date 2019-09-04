using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BillTracker.Infraestructure
{
    class BillTrackerException : Exception
    {
        /// <summary>
        /// Additional information about the exception.
        /// </summary>
        public string Details { get; private set; }


        public int HttpCode { get; set; } = 500;

        /// <summary>
        /// An arbitrary error code.
        /// </summary>
        public ErrorCode Code { get; set; }

        /// <summary>
        /// Severity of the exception.
        /// Default: Warn.
        /// </summary>
        public LogSeverity Severity { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BillTrackerException()
        {
            Severity = LogSeverity.Warn;
        }

        /// <summary>
        /// Constructor for serializing.
        /// </summary>
        public BillTrackerException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public BillTrackerException(string message)
            : base(message)
        {
            Severity = LogSeverity.Warn;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="severity">Exception severity</param>
        public BillTrackerException(string message, LogSeverity severity)
            : base(message)
        {
            Severity = severity;
        }

        public BillTrackerException(ErrorCode code, string message, LogSeverity severity)
           : base(message)
        {
            Code = code;
            Severity = severity;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Exception message</param>
        public BillTrackerException(ErrorCode code, string message)
            : this(message)
        {
            Code = code;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        public BillTrackerException(string message, string details)
            : this(message)
        {
            Details = details;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        public BillTrackerException(ErrorCode code, string message, string details)
            : this(message, details)
        {
            Code = code;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public BillTrackerException(string message, Exception innerException)
            : base(message, innerException)
        {
            Severity = LogSeverity.Warn;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        /// <param name="innerException">Inner exception</param>
        public BillTrackerException(string message, string details, Exception innerException)
            : this(message, innerException)
        {
            Details = details;
        }
    }
}
