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

public partial class ScreeningAddSectionQue : System.Web.UI.Page
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
                hdnScrId.Value = Request.QueryString["ScrId"].ToString();

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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
            objLIBScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBScreening;
          tp = objDalScreening.GetNoQuestionInSection(tp);
          objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
          if (objLibScreeningListing != null)
          {

              if (objLibScreeningListing.Count > 0)
              {
                  txtmax_sec.Text = objLibScreeningListing[0].MaxQueInSection.ToString();
                  txtmaxattempt.Text = objLibScreeningListing[0].MaxAttemptQue.ToString();
                 // txtmaxmarks.Text = objLibScreeningListing[0].MaxQueMarks.ToString();
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

                LIBScreening objLIBScreening = new LIBScreening();
                DALScreening objDalScreening = new DALScreening();
                TransportationPacket tp = new TransportationPacket();

                objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                objLIBScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                objLIBScreening.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
                objLIBScreening.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
                tp.MessagePacket = (object)objLIBScreening;
                addResult = objDalScreening.AddQueInSection(tp);

                if (addResult == 1 )
                {
                   lblMessage.Text = "Saved Successfully";
                   txtmaxattempt.Text = "";
                   txtmax_sec.Text = "";
                   Response.Redirect("ScreeningStudentInstructionSummary.aspx?ScrId=" + Request.QueryString["ScrId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString());
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
                    Response.Redirect("ScreeningSelectSection.aspx?ScrId=" + hdnScrId.Value);

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
                    Response.Redirect("ScreeningAddSelectSection.aspx?ScrId=" + Request.QueryString["ScrId"].ToString(), false);

                }
                else
                {
                    Response.Redirect("ScreeningSelectSection.aspx?ScrId=" + Request.QueryString["ScrId"].ToString(), false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("ScreeningSelectSection.aspx?ScrId=" + Request.QueryString["ScrId"].ToString(), false);
            }
        }

    }
    protected void btnSaveContinue_Click(object sender, EventArgs e)
    {
        try
        {
            int addResult = 0;

            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();

            objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
            objLIBScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            objLIBScreening.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
            objLIBScreening.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
            tp.MessagePacket = (object)objLIBScreening;
            addResult = objDalScreening.AddQueInSection(tp);

            if (addResult == 1)
            {
                lblMessage.Text = "Saved Successfully";
                txtmaxattempt.Text = "";
                txtmax_sec.Text = "";
                //Response.Redirect("SelectSection.aspx?ScrId=" + hdnScrId.Value);
                Response.Redirect("ScreeningStudentInstructionSummary.aspx?ScrId=" + Request.QueryString["ScrId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
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
                Response.Redirect("ScreeningSelectSection.aspx?ScrId=" + hdnScrId.Value);

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
