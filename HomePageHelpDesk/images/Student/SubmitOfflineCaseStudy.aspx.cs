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

public partial class Student_SubmitOfflineCaseStudy : System.Web.UI.Page
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
        string UserId = Session["username"].ToString();
        int CSID = Convert.ToInt32(Request.QueryString["CSID"]);
        //LIBAssignment objLibAssignmentCode = new LIBAssignment();
        //DALAssignment OBJDALAssignmentCode = new DALAssignment();
        //TransportationPacket tpCode = new TransportationPacket();
        //  objLibAssignmentCode.AsgnId = AsgnId;
        //  tpCode.MessagePacket = (object)objLibAssignmentCode;

        string text = "Offline-" + UserId + "-" + CSID;
        string uploadFolder = Request.PhysicalApplicationPath + "Student\\UploadCaseStudy\\";
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
            lblMessage.Text = "Please upload Case Study";
            return;
        }
        LIBCaseStudy objLibAssignment = new LIBCaseStudy();
        DALCaseStudy OBJDALAssignment = new DALCaseStudy();
        TransportationPacket tp = new TransportationPacket();
       
        objLibAssignment.UserId = UserId;
        objLibAssignment.CSId = CSID;
        objLibAssignment.UploadAnsPath = path;
        tp.MessagePacket = (object)objLibAssignment;
        addResult = OBJDALAssignment.AddUpdateOfflineCaseStudyAnswers(tp);
        if (addResult > 0)
        {
            try
            {
                string strQExam;
                strQExam = "update StudentActiveCaseStudy set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where CSId=" + CSID + "and userid='" + UserId + "'";
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
