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

public partial class Student_SubmitManualScreening : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }

    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        int addResult = 0;
        string UserId=Session["username"].ToString();
        int ScrId = Convert.ToInt32(Request.QueryString["ScrId"]);
        //LIBScreening objLibScreeningCode = new LIBScreening();
        //DALScreening OBJDALScreeningCode = new DALScreening();
        //TransportationPacket tpCode = new TransportationPacket();
        //  objLibScreeningCode.ScrId = ScrId;
        //  tpCode.MessagePacket = (object)objLibScreeningCode;

        string text = UserId + "-" + ScrId;
        string uploadFolder = Request.PhysicalApplicationPath + "Student\\UploadScreeningExam\\";
        string path = "";
        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(uploadFolder + text + extension);
            path = uploadFolder + text + extension;
            lblMessage.Text = "";

        }
        else 
        {
            lblMessage.Text = "Please upload ";
            return;
        }
        LIBScreening objLibScreening = new LIBScreening();
        DALScreening OBJDALScreening = new DALScreening();
        TransportationPacket tp = new TransportationPacket();
        //objLibScreening.UserId = hdnUserId.Value;
        objLibScreening.UserId = UserId;
        objLibScreening.ScrId =ScrId; 
        objLibScreening.UploadAnsPath = path;
        tp.MessagePacket = (object)objLibScreening;
        addResult = OBJDALScreening.AddUpdateMaualScreeningAnswers(tp);
        if (addResult > 0)
        {
            try
            {
                 string strQExam;
                strQExam = "update studentActiveScreening set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where ScrId=" + ScrId + "and userid='" + UserId + "'";
                CLS_C.fnExecuteQuery(strQExam);
            }
            catch (Exception ex)
            {
            }
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");

            Response.Write("<script> self.close();</script>");        
           

        }
        
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Failed to save'); </script>");

        }
    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>self.close();</script>");
    }
}
