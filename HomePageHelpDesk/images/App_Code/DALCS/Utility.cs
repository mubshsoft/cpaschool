using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.Odbc;
using System.IO;

namespace fmsf.lib
{
    public class Utility
    {
        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        public static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        //public static void GetrSitemap()
        //{
        //    XmlDocument myxmlDoc = new XmlDocument();
        //    myxmlDoc.Load(Server.MapPath("web.sitemap"));

        //    XmlNode myNode = myxmlDoc.SelectSingleNode("/siteMap/siteMapNode/siteMapNode[attribute::title='Titles']");

        //    //Remove Child Nodes
        //    myNode.innerText = "";

        //    //Var for holding new nodes
        //    XmlElement elem = default(XmlElement);

        //    //Connect to database
        //    string adoCmdStr = "select title,title_id from titles;";

        //    string adoConnStr = ConfigurationSettings.AppSettings("--Insert Connection String--");
        //    OdbcConnection adoConn = new OdbcConnection(AdoConnStr);
        //    OdbcDataAdapter adoDApt = new OdbcDataAdapter(adoCmdStr, adoConn);
        //    OdbcCommand adoCmd = new OdbcCommand(adoCmdStr, adoConn);

        //    OdbcDataReader adoRdr = default(OdbcDataReader);

        //    adoConn.Open();

        //    adoRdr = adoCmd.ExecuteReader(CommandBehavior.CloseConnection);

        //    //data reader reads all rows
        //    while (adoRdr.Read())
        //    {

        //        elem = myxmlDoc.CreateElement("siteMapNode");
        //        elem.SetAttribute("title", adoRdr.GetValue(adoRdr.GetOrdinal("Title")).toString);
        //        elem.SetAttribute("url", "/anime/" + adoRdr.GetValue(adoRdr.GetOrdinal("Title_ID")).toString + ".info");

        //        //appends new node
        //        myNode.AppendChild(elem);
        //    }

        //    //Saves XML
        //    myxmlDoc.Save(Server.MapPath("web.sitemap"));



        //    //s a lot easier than expected.
        //    It();
        //}

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns>Unicode Byte Array converted by String pXmlString</returns>
        public static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
        public static string CheckNullString(string strText)
        {
            if (string.IsNullOrEmpty(strText))
            {
                strText = "";
            }

            return strText;
        }

        public static string CheckNullIntDecimal(string strText)
        {
            if (string.IsNullOrEmpty(strText))
            {
                strText = "0";
            }

            return strText;
        }

      
    }
}
