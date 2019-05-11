using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UniRx.Diagnostics
{
    public struct LogEntry
    {
        // requires
        public string LoggerName { get;  set; }
        public LogType LogType { get;  set; }
        public string Message { get;  set; }
        public DateTime Timestamp { get;  set; }

        // options

        /// <summary>[Optional]</summary>
        public UnityEngine.Object Context { get;  set; }
        /// <summary>[Optional]</summary>
        public Exception Exception { get;  set; }
        /// <summary>[Optional]</summary>
        public string StackTrace { get;  set; }
        /// <summary>[Optional]</summary>
        public object State { get;  set; }

        public LogEntry(string loggerName, LogType logType, DateTime timestamp, string message, UnityEngine.Object context = null, Exception exception = null, string stackTrace = null, object state = null)
            : this()
        {
            this.LoggerName = loggerName;
            this.LogType = logType;
            this.Timestamp = timestamp;
            this.Message = message;
            this.Context = context;
            this.Exception = exception;
            this.StackTrace = stackTrace;
            this.State = state;
        }

        public override string ToString()
        {
            var plusEx = (Exception != null) ? (Environment.NewLine + Exception.ToString()) : "";
            return "[" + Timestamp.ToString() + "]"
                + "[" + LoggerName + "]"
                + "[" + LogType.ToString() + "]"
                + Message
                + plusEx;
        }
    }
}
