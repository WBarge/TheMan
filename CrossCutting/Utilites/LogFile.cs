using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Utilites
{
    /// <summary>
    /// Used to control timestamps in the log
    /// </summary>
    public enum LogTiming
    {
        /// <summary>
        /// No Timing takes place.
        /// </summary>
        None,
        /// <summary>
        /// Records the start time.
        /// </summary>
        Start,
        /// <summary>
        /// Records the end time and stamps the duration.
        /// </summary>
        End
    }

    /// <summary>
    /// class for a logging file
    /// </summary>
    public class LogFile
    {
        #region Local Vars
        private StreamWriter _sw = null;
        protected int Indent = -1;
        protected Stack<DateTime> StartTimes = null;
        protected const string IndentString = "    ";
        #endregion

        #region Properties
        /// <summary>
        /// Gets the writer.
        /// </summary>
        /// <value>
        /// The writer.
        /// </value>
        public StreamWriter Writer
        {
            get { return (_sw); }
        }//end of property
        public string FileName { get; internal set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Create the file
        /// it assumes the path does not have the file name in it
        /// the name of the file will be the date and time of creation plus a guid
        /// </summary>
        /// <param name="path">the path to the location of the log file</param>
        public LogFile(string path = "") : this(path, false) { }

        /// <summary>
        /// Create the file
        /// when the pathIncludesFileName is false the name of the file will be the date and time of creation plus a guid
        /// </summary>
        /// <param name="path">the path to the location of the log file</param>
        /// <param name="pathIncludesFileName">
        ///     true - if the path includes the name of the log file at the end of it
        ///     false - if the path does not include the name of the log file at the end of it
        /// </param>
        public LogFile(string path, bool pathIncludesFileName)
        {
            FileStream f = null;
            string logFileName = string.Empty;
            string tempFileName = "Log_" + DateTime.Now.ToString("MM_dd_yyyy____HH_mm_ss_mm") + "_" + Guid.NewGuid().ToString() + ".txt";
            int numTries = 10;
            try
            {
                if (pathIncludesFileName)
                {
                    logFileName = path;
                }
                else
                {
                    if (path == null || path == string.Empty)
                    {
                        logFileName = string.Format("{0}", tempFileName);
                    }
                    else
                    {
                        logFileName = string.Format("{0}\\{1}", path, tempFileName);
                    }//end of if-else
                }//end of if-else
                while (true)
                {
                    try
                    {
                        f = File.Create(logFileName);
                        _sw = new StreamWriter(f);
                        break;
                    }
                    catch
                    {
                        numTries--;
                        if (numTries <= 0)
                        {
                            Debug.WriteLine("Could not open log file for writing.");
                            return;
                        }
                        Thread.Sleep(100); // Wait 100 mili-seconds
                    }
                }//end of while
                StartTimes = new Stack<DateTime>();
                FileName = logFileName;
            }
            catch (System.Exception ex) { ErrorMessage.WriteToDebugWindow(ex.Message); }
        }//end of constructor
        #endregion

        #region Public Methods

        /// <summary>
        /// Closes the log file
        /// </summary>
        public void Close()
        {
            try
            {
                if (_sw != null)
                {
                    _sw.Flush();
                    _sw.Close();
                    _sw = null;
                }
            }
            catch (System.Exception ex) { ErrorMessage.WriteToDebugWindow(ex.Message); }
        }//end of Close

        /// <summary>
        /// Writes the message to the log file
        /// </summary>
        /// <param name="msg">the error message to write to the file</param>
        public void Log(ErrorMessage msg)
        {
            try
            {
                Log(msg.Message);
            }
            catch (Exception x) { ErrorMessage.WriteToDebugWindow(x.Message); }
        }

        /// <summary>
        /// Writes a string to the log file.
        /// </summary>
        /// <param name="msg">The string to write.</param>
        public void Log(string msg)
        {
            try
            {
                Log(msg, LogTiming.None, null);
            }
            catch (System.Exception ex) { ErrorMessage.WriteToDebugWindow(ex.Message); }
        }//end of Log

        /// <summary>
        /// Writes a string to the log file.
        /// </summary>
        /// <param name="msg">The string to write.</param>
        /// <param name="logType">The log type.</param>
        public void Log(string msg, LogTiming logType)
        {
            try
            {
                Log(msg, logType, null);
            }
            catch (System.Exception ex) { ErrorMessage.WriteToDebugWindow(ex.Message); }
        }//end of Log

        /// <summary>
        /// Writes a formatted string to the log file.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="values">The values to insert into the format string.</param>
        public void Log(string formatString, params object[] values)
        {
            try
            {
                Log(formatString, LogTiming.None, values);
            }
            catch (System.Exception ex) { ErrorMessage.WriteToDebugWindow(ex.Message); }
        }//end of Log

        /// <summary>
        /// Writes a formatted string to the log file.
        /// </summary>
        /// <param name="formatString">The format string.</param>
        /// <param name="logType">The log type.</param>
        /// <param name="values">The values to insert into the format string.</param>
        public void Log(string formatString, LogTiming logType, params object[] values)
        {
            string msg = string.Empty;
            DateTime start = DateTime.MinValue;
            TimeSpan span = TimeSpan.MinValue;
            try
            {
                if (values != null)
                {
                    msg = string.Format(formatString, values);
                }
                else
                {
                    msg = formatString;
                }//end of if-else

                switch (logType)
                {
                    case LogTiming.Start:
                        Indent++;
                        StartTimes.Push(DateTime.Now);
                        break;

                    case LogTiming.None:
                        Indent++;
                        break;

                    case LogTiming.End:
                        start = StartTimes.Pop();
                        span = DateTime.Now - start;
                        break;
                }//end of switch

                for (int i = 0; i < Indent; i++)
                {
                    msg = IndentString + msg;
                }//end of for

                _sw.WriteLine("{0} {1}{2}", DateTime.Now.ToString(), msg, (span > TimeSpan.MinValue ? " (duration: " + span.ToString() + ")" : ""));

                switch (logType)
                {
                    case LogTiming.None:
                    case LogTiming.End:
                        Indent--;
                        break;
                }//end of switch
            }
            catch (System.Exception ex) { ErrorMessage.WriteToDebugWindow(ex.Message); }
        }//end of Log

        #endregion
    }
}