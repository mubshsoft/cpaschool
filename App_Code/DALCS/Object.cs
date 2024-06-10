using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;


namespace fmsf.lib
{
   
    #region XML Related
    public class SerializeXML
    {
        public object ConvertXML(string FilePath, EXMLContextTypes XMLContext, bool Encrypted, string EncryptedString)
        {
            object objSerialClassObject = null;
            XmlSerializer objXMLSerializer = null;
            FileStream objStream = null;
            XmlReader objXMLReader = null;
            try
            {
                switch (XMLContext)
                {
                    case EXMLContextTypes.ClientDBConnection:
                        {
                            objXMLSerializer = new XmlSerializer(typeof(ConnectionInfo));
                            break;
                        }

                    //case EXMLContextTypes.SearchInfo:
                    //    {
                    //        objXMLSerializer = new XmlSerializer(typeof(SearchInfo));
                    //        break;
                    //    }
                    default:
                        break;
                }

                if (objXMLSerializer == null)
                {
                    return objSerialClassObject;
                }

                objStream = new FileStream(FilePath, FileMode.Open);
                objXMLReader = new XmlTextReader(objStream);

                objSerialClassObject = objXMLSerializer.Deserialize(objXMLReader);
            }
            catch (Exception exObj)
            {
                //BugsHandler.BugLogging(exObj.StackTrace, exObj.Message, true);
            }
            finally
            {
                if (objStream != null)
                {
                    objStream.Close();
                }
                objStream = null;
                if (objXMLReader != null)
                {
                    objXMLReader.Close();
                }
                objXMLReader = null;
            }
            return objSerialClassObject;
        }
    }
    #endregion

    #region ConnectionInfo
    public class ConnectionInfo
    {
        string m_strServerName;
        string m_strPassword;
        string m_strDatabase;
        string m_strUserID;

        public string ServerName
        {
            get
            {
                return m_strServerName;
            }
            set
            {
                m_strServerName = value;
            }

        }

        public string Password
        {
            get
            {
                return m_strPassword;
            }
            set
            {
                m_strPassword = value;
            }
        }

        public string Database
        {
            get
            {
                return m_strDatabase;
            }
            set
            {
                m_strDatabase = value;
            }
        }

        public string UserID
        {
            get
            {
                return m_strUserID;
            }
            set
            {
                m_strUserID = value;
            }
        }
    }
    #endregion


  }