using System;
using System.Collections.Generic;
using System.Text;

namespace BillTracker.Infraestructure
{
    /// <summary>
    /// Indicates severity for log.
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// Debug.
        /// </summary>
        Debug,

        /// <summary>
        /// Info.
        /// </summary>
        Info,

        /// <summary>
        /// Warn.
        /// </summary>
        Warn,

        /// <summary>
        /// Error.
        /// </summary>
        Error,

        /// <summary>
        /// Fatal.
        /// </summary>
        Fatal
    }


    public enum ErrorCode
    {
        ArgumentNull = 01,
        ErrorNotHandler = 999,
        CanNotRefreshToken = 02,
        TokenWasExpired = 03,
        InvalidUserPassword = 04,
        IntegrationException = 05
    }
}
