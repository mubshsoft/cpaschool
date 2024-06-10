using System;
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
using fmsf.DAL;
using fmsf.lib;

public partial class AssignmentAddSectionQue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            if (Session["role"].ToString() == "Admin")
            { }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }


        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            if (!Page.IsPostBack)
            {
                hdnCategoryId.Value = Request.QueryString["sectionId"].ToString();
                hdnAsgnId.Value = Request.QueryString["AsgnId"].ToString();

                if (Request.QueryString.Count > 0)
                {
                    try
                    {
                        if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                        {
                            btnSave.Visible = false;
                            btnSaveContinue.Visible = true;
                        }
                        else
                        {
                            btnSave.Visible = true;
                            btnSaveContinue.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        btnSave.Visible = true;
                        btnSaveContinue.Visible = false;
                    }
                }


                BindSectionList();


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
   

    protected void BindSectionList()
    {
        
        
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
            objLIBAssignment.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBAssignment;
          tp = objDalAssignment.GetNoQuestionInSection(tp);
          objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
          if (objLibAssignmentListing != null)
          {

              if (objLibAssignmentListing.Count > 0)
              {
                  txtmax_sec.Text = objLibAssignmentListing[0].MaxQueInSection.ToString();
                  txtmaxattempt.Text = objLibAssignmentListing[0].MaxAttemptQue.ToString();
                 // txtmaxmarks.Text = objLibAssignmentListing[0].MaxQueMarks.ToString();
                  //btnSave.Visible = false;
              }
          }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
       
            try
            {
                int addResult = 0;

                LIBAssignment objLIBAssignment = new LIBAssignment();
                DALAssignment objDalAssignment = new DALAssignment();
                TransportationPacket tp = new TransportationPacket();

                objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
                objLIBAssignment.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                objLIBAssignment.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
                objLIBAssignment.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
                tp.MessagePacket = (object)objLIBAssignment;
                addResult = objDalAssignment.AddQueInSection(tp);

                if (addResult == 1 )
                {
                   lblMessage.Text = "Saved Successfully";
                   txtmaxattempt.Text = "";
                   txtmax_sec.Text = "";
                   Response.Redirect("AssignmentStudentInstructionSummary.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString());
                }
                //else if (addResult == -11)
                //{

                //    lblMessage.Text = "Duplicate Section Option";

                //}
                else if (addResult == 2)
                {

                    lblMessage.Text = "Updated Successfully";
                    txtmaxattempt.Text = "";
                    txtmax_sec.Text = "";
                    Response.Redirect("AssignmentSelectSection.aspx?AsgnId=" + hdnAsgnId.Value);

                }
                else
                {

                    lblMessage.Text = "Failed to Save Section Option";

                }
            }
            catch (Exception ex)
            {
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }


       

        

    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            try
            {
                if (Convert.ToInt32(Request.QueryString["a"].ToString()) == 1)
                {
                    Response.Redirect("AssignmentAddSelectSection.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString(), false);

                }
                else
                {
                    Response.Redirect("AssignmentSelectSection.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString(), false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("AssignmentSelectSection.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString(), false);
            }
        }

    }
    protected void btnSaveContinue_Click(object sender, EventArgs e)
    {
        try
        {
            int addResult = 0;

            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();

            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
            objLIBAssignment.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            objLIBAssignment.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
            objLIBAssignment.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
            tp.MessagePacket = (object)objLIBAssignment;
            addResult = objDalAssignment.AddQueInSection(tp);

            if (addResult == 1)
            {
                lblMessage.Text = "Saved Successfully";
                txtmaxattempt.Text = "";
                txtmax_sec.Text = "";
                //Response.Redirect("SelectSection.aspx?AsgnId=" + hdnAsgnId.Value);
                Response.Redirect("AssignmentStudentInstructionSummary.aspx?AsgnId=" + Request.QueryString["AsgnId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
            }
            //else if (addResult == -11)
            //{

            //    lblMessage.Text = "Duplicate Section Option";

            //}
            else if (addResult == 2)
            {

                lblMessage.Text = "Updated Successfully";
                txtmaxattempt.Text = "";
                txtmax_sec.Text = "";
                Response.Redirect("AssignmentSelectSection.aspx?AsgnId=" + hdnAsgnId.Value);

            }
            else
            {

                lblMessage.Text = "Failed to Save Section Option";

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
}
