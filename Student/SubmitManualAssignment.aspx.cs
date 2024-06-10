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

public partial class Student_SubmitManualAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int addResult = 0;
        string UserId=Session["username"].ToString();
        int AsgnId = Convert.ToInt32(Request.QueryString["AsgnId"]);
        //LIBAssignment objLibAssignmentCode = new LIBAssignment();
        //DALAssignment OBJDALAssignmentCode = new DALAssignment();
        //TransportationPacket tpCode = new TransportationPacket();
        //  objLibAssignmentCode.AsgnId = AsgnId;
        //  tpCode.MessagePacket = (object)objLibAssignmentCode;

        string text = "Manual-"+UserId + "-" + AsgnId;
        string uploadFolder = Request.PhysicalApplicationPath + "Student\\UploadAssignment\\";
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
            lblMessage.Text = "Please upload Assignment";
            return;
        }
        LIBAssignment objLibAssignment = new LIBAssignment();
        DALAssignment OBJDALAssignment = new DALAssignment();
        TransportationPacket tp = new TransportationPacket();
        //objLibAssignment.UserId = hdnUserId.Value;
        objLibAssignment.UserId = UserId;
        objLibAssignment.AsgnId =AsgnId; 
        objLibAssignment.UploadAnsPath = path;
        tp.MessagePacket = (object)objLibAssignment;
        addResult = OBJDALAssignment.AddUpdateMaualAssignmentAnswers(tp);
        if (addResult > 0)
        {
            try
            {
                 string strQExam;
                strQExam = "update studentActiveAssignment set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where AsgnId=" + AsgnId + "and userid='" + UserId + "'";
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
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>self.close();</script>");
    }
}
