using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Threading;
using fmsf.lib;

using System.Configuration;


namespace fmsf.DAL
{
    public class DbConnection
    {
        SqlConnection m_sqlConnection;

        #region Open Database
        /// <summary>
        /// This is the Internal Function to be invoked from the DBConnection
        /// The purpose of the function 'OpenDatabase' is to open the XML File and have all the values in the class
        /// object through Serialization. This is static function of the class and can be invoked without any instance.
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenDatabase()
        {
            string strConnectionString = "";
            ConnectionInfo objConnectionConfig = new ConnectionInfo();
            SqlConnection objConnection = null;
            SerializeXML objXml = null;
            try
            {
                
                //string strXMLFilePath = "";
                //strXMLFilePath = AppDomain.CurrentDomain.BaseDirectory + "startup.xml";
                //strXMLFilePath = AppDomain.CurrentDomain.RelativeSearchPath +"\\"+ "Startup.xml";
                //objXml = new SerializeXML();
                //objConnectionConfig = (ConnectionInfo)objXml.ConvertXML(strXMLFilePath, EXMLContextTypes.ClientDBConnection, false, null);

                strConnectionString = ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ToString();
                //strConnectionString = "server=" + objConnectionConfig.ServerName + ";database=" + objConnectionConfig.Database + ";uid=" + objConnectionConfig.UserID + ";pwd=" + objConnectionConfig.Password + ";";
               
                if (strConnectionString != string.Empty)
                {
                    objConnection = new SqlConnection(strConnectionString);
                    objConnection.Open();
                }
            }
            catch (SqlException exSQL)
            {
                HandleException.ExceptionLogging(exSQL.Source, exSQL.Message, true);
                //BugsHandler.BugLogging("Exception Thrown while Opening Connection: " + WebDBErrorTypes.ConnectionError.ToString(), exSQL.Message, true);
            }
            catch (Exception ex)
            {
                //BugsHandler.BugLogging(ex.StackTrace, ex.Message, true);

                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
            finally
            {
                m_sqlConnection = objConnection;
            }

            return objConnection;
        }
        #endregion

        #region Close Database
        /// <summary>
        /// This is the Internal Function to be invoked from the DBConnection
        /// The purpose of the function 'CloseDatabase' is to close the existing open connection of the Database. 
        /// It shall automatically check the State of the SQL Connection used and will act accordingly.
        /// This shall return  true / false based on the success of the completion of the tasks.
        /// </summary>
        /// <returns></returns>
        public bool CloseDatabase()
        {
            bool blnReturnValue = true;
            try
            {
                if (m_sqlConnection != null)
                {
                    if (m_sqlConnection.State != System.Data.ConnectionState.Closed)
                    {
                        m_sqlConnection.Close();
                        m_sqlConnection.Dispose();
                        m_sqlConnection = null;
                    }
                }
            }
            catch (Exception exObj)
            {
                blnReturnValue = false;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
                throw;
            }
            finally
            {

            }
            return blnReturnValue;
        }
        #endregion

        #region Execute Stored Procedures

        #region ExecuteNonQuery
        /// <summary>
        /// This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteNonQuery
        /// This shall reduce lot of Development time in invoking the database properties.
        /// Input Parameters: String SPName -> Name of the Stored Procedures
        /// ParameterList -> List of Type SQLParameter
        /// The function is responsible for database connectivity and shall open and close the connection on it's own.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        public int ExecuteSPNonQuery(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                m_intReturnValue = -1;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return m_intReturnValue;
        }
        #endregion

        #region ExecuteNonQuery OutPut
        /// <summary>
        /// This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteNonQuery
        /// This shall reduce lot of Development time in invoking the database properties.
        /// Input Parameters: String SPName -> Name of the Stored Procedures
        /// ParameterList -> List of Type SQLParameter
        /// The function is responsible for database connectivity and shall open and close the connection on it's own.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        public string[] ExecuteSPNonQueryOutPut(string SPName, List<SqlParameter> ParameterList, List<SqlParameter> OutParameterList)
        {
            int m_intReturnValue = 0;
            string[] OutParameterArray = new string[OutParameterList.Count];
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }

                    for (int intLoop = 0; intLoop < OutParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(OutParameterList[intLoop]);
                        OutParameterList[intLoop].Direction = ParameterDirection.Output;
                    }

                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();


                    CloseDatabase();
                    for (int intLoop = 0; intLoop < OutParameterList.Count; intLoop++)
                    {
                        OutParameterArray[intLoop] = m_cmdStoredProcedure.Parameters[OutParameterList[intLoop].ParameterName].Value.ToString();
                          
                    }

                }
            }
            catch (Exception exObj)
            {
                m_intReturnValue = -1;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return OutParameterArray;
        }

        public int ExecuteSPNonQueryReturnValue(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            int intReturnValues = 0;
          
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    SqlParameter objReturnParameter=new SqlParameter("RETURNVALUE",SqlDbType.Int);
                    objReturnParameter.Direction=ParameterDirection.ReturnValue;

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter);
                  

                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    intReturnValues = Convert.ToInt32(m_cmdStoredProcedure.Parameters["RETURNVALUE"].Value);

                   CloseDatabase();

                  


                }
            }
            catch (Exception exObj)
            {
                intReturnValues = -1;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return intReturnValues + m_intReturnValue;
        }

        public int ExecuteNonQueryReturnValueWithoutAdd(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            int intReturnValues = 0;

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    SqlParameter objReturnParameter = new SqlParameter("RETURNVALUE", SqlDbType.Int);
                    objReturnParameter.Direction = ParameterDirection.ReturnValue;

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter);


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    intReturnValues = Convert.ToInt32(m_cmdStoredProcedure.Parameters["RETURNVALUE"].Value);

                    CloseDatabase();




                }
            }
            catch (Exception exObj)
            {
                intReturnValues = -1;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return intReturnValues ;
        }


        public decimal ExecuteNonQueryDecimal(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            decimal intReturnValues = 0;

            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    SqlParameter objReturnParameter = new SqlParameter("RETURNVALUE", SqlDbType.Decimal);
                    objReturnParameter.Direction = ParameterDirection.ReturnValue;

                    m_cmdStoredProcedure.Parameters.Add(objReturnParameter);


                    m_intReturnValue = m_cmdStoredProcedure.ExecuteNonQuery();
                    intReturnValues = Convert.ToDecimal(m_cmdStoredProcedure.Parameters["RETURNVALUE"].Value);

                    CloseDatabase();




                }
            }
            catch (Exception exObj)
            {
                intReturnValues = -1;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return intReturnValues;
        }
        #endregion
        #region ExecuteSPDataSet
        /// <summary>
        /// This function shall Execute the Stored Procedure on the Database, this is a replica of using DOTNET ExecuteReader 
        /// or the method of filling up the DataSet.
        /// This shall reduce lot of Development time in invoking the database properties.
        /// Input Parameters: String SPName -> Name of the Stored Procedures
        /// ParameterList -> List of Type SQLParameter
        /// The function is responsible for database connectivity and shall open and close the connection on it's own.
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="ParameterList"></param>
        /// <returns></returns>
        public DataSet ExecuteSPDataSet(string SPName, List<SqlParameter> ParameterList)
        {
            DataSet m_dsReturnValue = new DataSet();
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }


                    SqlDataAdapter daAdapater = new SqlDataAdapter(m_cmdStoredProcedure);
                    daAdapater.Fill(m_dsReturnValue);
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                m_dsReturnValue = null;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return m_dsReturnValue;
        }


        #endregion


        public int ExecuteSPScalar(string SPName, List<SqlParameter> ParameterList)
        {
            int m_intReturnValue = 0;
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    m_intReturnValue = Convert.ToInt32(m_cmdStoredProcedure.ExecuteScalar());
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                m_intReturnValue = -1;
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return m_intReturnValue;
        }
      
        #endregion

        public string ExecuteSPScalarString(string SPName, List<SqlParameter> ParameterList)
        {
            string m_intReturnValue = "";
            try
            {
                SqlCommand m_cmdStoredProcedure = new SqlCommand();
                m_cmdStoredProcedure.CommandText = SPName;
                m_cmdStoredProcedure.CommandType = CommandType.StoredProcedure;
                if (m_sqlConnection == null)
                {
                    m_sqlConnection = OpenDatabase();
                }
                if (m_sqlConnection != null)
                {
                    m_cmdStoredProcedure.Connection = m_sqlConnection;
                    for (int intLoop = 0; intLoop < ParameterList.Count; intLoop++)
                    {
                        m_cmdStoredProcedure.Parameters.Add(ParameterList[intLoop]);
                    }
                    m_intReturnValue = Convert.ToString(m_cmdStoredProcedure.ExecuteScalar());
                    CloseDatabase();
                }
            }
            catch (Exception exObj)
            {
                m_intReturnValue = "-1";
                HandleException.ExceptionLogging(exObj.Source, exObj.Message, true);
            }
            return m_intReturnValue;
        }

    }


}
