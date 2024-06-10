using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class RegisXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string strFilename =txtUsername.Text.Trim() +".xml";

        string strPath = Server.MapPath("~/XmlFiles/" + strFilename);
        //string uploadFolder = Request.PhysicalApplicationPath + "XmlFiles\\";
        //string filename = uploadFolder + strFilename;
        System.IO.FileInfo file = new System.IO.FileInfo(strPath);
        if (!file.Exists)
        {

            XmlTextWriter writer = new XmlTextWriter(Server.MapPath("~/XmlFiles/" + strFilename), System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");

            writer.WriteStartElement("User");
            writer.WriteStartElement("FirstName");
            writer.WriteString(txtFname.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("FirstName");
            writer.WriteString(txtLname.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("UserName");
            writer.WriteString(txtUsername.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("Password");
            writer.WriteString(txtPassword.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("Address");
            writer.WriteString(txtAddress.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("Mobile");
            writer.WriteString(txtMob.Text);
            writer.WriteEndElement();
            writer.WriteEndElement();
            //createNode("1", "Product 1", "1000", writer);
            //createNode("2", "Product 2", "2000", writer);
            //createNode("3", "Product 3", "3000", writer);
            //createNode("4", "Product 4", "4000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        else
        {
            Response.Write("username is already exists");
        }
    }
}