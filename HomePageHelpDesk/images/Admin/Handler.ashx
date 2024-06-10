<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using fmsf.lib;
using fmsf.DAL;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string filename =context.Request.QueryString["FILE"].ToString();
        System.IO.FileInfo file = new System.IO.FileInfo(filename);
        if (file.Exists)
        {
            context.Response.Clear();
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            context.Response.AddHeader("Content-Length", file.Length.ToString());
            context.Response.ContentType = "application/octet-stream";
            context.Response.WriteFile(file.FullName);
            context.Response.End();
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}