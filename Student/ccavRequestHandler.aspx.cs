﻿﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;

public partial class Student_ccavRequestHandler : System.Web.UI.Page
{
    CCACrypto ccaCrypto = new CCACrypto();
    string workingKey = "236A94A1F0124CAD7E69BABC2D78EF05";//put in the 32bit alpha numeric key in the quotes provided here 	
    string ccaRequest = "";
    public string strMerchantId = "";
    public string strEncRequest = "";
    public string strAccessCode = "AVAS08IE91AW56SAWA";// put the access key in the quotes provided here.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (string name in Request.Form)
            {
                if (name != null)
                {
                    if (!name.StartsWith("_"))
                    {
                        ccaRequest = ccaRequest + name + "=" + HttpUtility.UrlEncode(Request.Form[name]) + "&";
                        /* Response.Write(name + "=" + Request.Form[name]);
                          Response.Write("</br>");*/
                    }
                }
            }
            strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
            strMerchantId = Request.Form["merchant_id"].ToString();
        }

    }
}