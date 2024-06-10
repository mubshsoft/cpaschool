using System;
using System.IO;
using System.Threading;

namespace fmsf.lib
{
    public class HandleException
    {
        static StreamWriter objBugStream;
        static bool m_blnBugsHandling = true;
        static string m_strPath = "";
        static bool m_blnCreateNew = false;
        static HandleException m_objExceptionHandler;

        private HandleException()
        {
        }

        public static HandleException Instance()
        {
            if (m_objExceptionHandler == null)
            {
                m_objExceptionHandler = new HandleException();
            }
            return m_objExceptionHandler;
        }


        /// <summary>
        /// Property to enable or disable the monitoring of the bugs in a physical file
        /// </summary>
        public static bool MonitorBugs
        {
            set
            {
                m_blnBugsHandling = value;
            }
        }

        /// <summary>
        /// File path specify the path where the file has to be stored
        /// </summary>
        /// <param name="strPath">Path of the file where the bugs shall be stored.</param>
        public static string FilePath
        {
            set
            {
                m_strPath = value;
            }
            get
            {
                return m_strPath;
            }
        }

        /// <summary>
        /// Method to Log the Bug into the file.
        /// This shall take care whether the log has to be maintained or not.
        /// </summary>
        /// <param name="SourceofBug">Source of Bug</param>
        /// <param name="DescriptionofBug">Description of the Bug</param>
        public static void ExceptionLogging(string Source, string Description)
        {
            try
            {
                OpenStream();
                WriteToFile(Source, Description);
            }
            catch (Exception exBugsHandling)
            {
                //throw exBugsHandling;
            }

        }

        /// <summary>
        /// Private function which shall open up the Stream for writing the details to the text file.
        /// </summary>
        private static void OpenStream()
        {
            if (m_blnBugsHandling)
            {
                if (objBugStream == null)
                {
                    if (m_strPath.Trim().Length > 0)
                    {
                        if (m_blnCreateNew)
                        {
                            File.Delete(m_strPath);
                        }
                        objBugStream = new StreamWriter(m_strPath, true, System.Text.Encoding.Unicode);
                    }
                }
            }
        }

        /// <summary>
        /// Overloaded function which shall be used for logging the Exceptions
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Description"></param>
        /// <param name="ForcefulLogging"></param>
        public static void ExceptionLogging(string Source, string Description, bool ForcefulLogging)
        {
            try
            {
                OpenStream();
                WriteToFile(Source, Description);
                if (ForcefulLogging)
                {
                    throw new Exception("Message : " + Description + " Stack Trace : " + Source);
                }
            }
            catch (Exception exBugsHandling)
            {
                //throw exBugsHandling;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Description"></param>
        public static void ExceptionLogging(string Description)
        {
            try
            {
                OpenStream();
                WriteToFile(null, Description);
            }
            catch (Exception exBugsHandling)
            {
                WriteToFile(exBugsHandling.StackTrace, exBugsHandling.Message);
                //throw exBugsHandling;
            }
        }

        /// <summary>
        /// This shall be privately function which shall be used by the functions.
        /// </summary>
        /// <param name="SourceofBug"></param>
        /// <param name="DescriptionofBug"></param>
        private static void WriteToFile(string SourceofBug, string DescriptionofBug)
        {
            if (objBugStream == null)
            {
                OpenStream();
            }

            if (m_blnBugsHandling)
            {
                Monitor.Enter(objBugStream);
                try
                {
                    string strReportedOn = "Reported on " + System.DateTime.Now.ToString();
                    objBugStream.WriteLine();
                    objBugStream.WriteLine("*********");
                    objBugStream.WriteLine(strReportedOn);
                    string strHash = "";
                    strHash = strHash.PadLeft(strReportedOn.Length, char.Parse("-"));
                    objBugStream.WriteLine(strHash);
                    if (SourceofBug != null)
                    {
                        objBugStream.WriteLine("Source: " + SourceofBug);
                    }
                    objBugStream.WriteLine("Description: " + DescriptionofBug);
                    objBugStream.WriteLine("*The End*");
                    objBugStream.Flush();
                }
                catch
                {
                }
                finally
                {
                    Monitor.Exit(objBugStream);
                }
                if (objBugStream != null)
                {
                    objBugStream.Close();
                    objBugStream = null;
                }
            }

        }

        /// <summary>
        /// This method shall close the BugsHandler.
        /// </summary>
        public static void CloseExceptionHandler()
        {
            //objBugStream.Close();
            objBugStream = null;
        }
    }
}
