using System;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for CLS_C
/// </summary>
namespace fmsf.lib
{
    public class CLS_C
    {
        static OleDbConnection MyCon;
        static string strGlobalerrorinfo;
        static OleDbCommand mycmd;
        public CLS_C()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void ConOpen()
        {
            try
            {
                strGlobalerrorinfo = "";
                //Dim Strconn As String = ConfigurationSettings.AppSettings("strconn1") 
                string Strconn;
                Strconn = ConfigurationManager.ConnectionStrings["fmsfConnectionString"].ToString();
                MyCon = new OleDbConnection(Strconn);
                if (MyCon.State == ConnectionState.Closed)
                {
                    MyCon.Open();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void ConClose()
        {
            try
            {
                //Dim strconn As String = ConfigurationSettings.AppSettings("strconn1") & path & ConfigurationSettings.AppSettings("strconn3") 
                if (MyCon.State == ConnectionState.Open)
                {
                    MyCon.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static long fnExecuteQuery(string UpdateQ)
        {
            ConOpen();
            long functionReturnValue = 0;
            try
            {
                strGlobalerrorinfo = "";
                mycmd = new OleDbCommand(UpdateQ, MyCon);
                functionReturnValue = mycmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MyCon.Close();
            }
            return functionReturnValue;
        }
        public static DataSet fnQuerySelectDs(string SelectQ)
        {
            ConOpen();
            DataSet ds = new DataSet();
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = SelectQ;
                //sqlCommand.CommandType = CommandType.StoredProcedure; 
                cmd.Connection = MyCon;
                //sqlCommand.Parameters.Add(new SqlParameter("@VENDNMBR", SqlDbType.Int)).Value = VendorId; 
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                ConClose();
            }
            return ds;
        }
        public static string fnReplaceSpCH1(string str)
        {
            try
            {
                str = str.Replace("\"", "dq$");
                str = str.Replace(",", "com$");
                str = str.Replace("'", "q$");
                str = str.Replace("&", "amp$");

            }
            catch (Exception ex)
            {
            }
            return str;
        }

        public static string fnGetDataFromSpCH1(string str)
        {
            try
            {
                str = str.Replace("dq$", "\"");
                str = str.Replace("com$", ",");
                str = str.Replace("q$", "'");
                str = str.Replace("amp$", "&");

            }
            catch (Exception ex)
            {
            }
            return str;
        }




    }

}