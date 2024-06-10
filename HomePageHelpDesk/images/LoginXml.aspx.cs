using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Data;

public partial class LoginXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strFilename = txtUsername.Text.Trim() + ".xml";
        string strPath = Server.MapPath("~/XmlFiles/" + strFilename);
        System.IO.FileInfo file = new System.IO.FileInfo(strPath);
        if (file.Exists)
        {
            XmlReader xmlFile;
            xmlFile = XmlReader.Create(strPath, new XmlReaderSettings());
            DataSet ds = new DataSet();
            //DataView dv;
            ds.ReadXml(xmlFile);

            string username = ds.Tables[0].Rows[0]["UserName"].ToString();
            string password = ds.Tables[0].Rows[0]["password"].ToString();
            if (username == txtUsername.Text.Trim() && password == txtPassword.Text.Trim())
            {
                Response.Write("Success");
            }
            else
            {
                Response.Write("Invalid");
            }
            
        }
        else
        {
            Response.Write("Username or Password not matched");
        }
    }
}