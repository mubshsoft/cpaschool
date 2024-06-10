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

public partial class SampleAddSectionQue : System.Web.UI.Page
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
                hdnSamId.Value = Request.QueryString["SamId"].ToString();

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
            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            LIBSampleListing objLibSampleListing = new LIBSampleListing();
            objLIBSample.SamId = Convert.ToInt32(hdnSamId.Value);
            objLIBSample.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            TransportationPacket tp = new TransportationPacket();

            tp.MessagePacket = (object)objLIBSample;
          tp = objDalSample.GetNoQuestionInSection(tp);
          objLibSampleListing = (LIBSampleListing)tp.MessageResultset;
          if (objLibSampleListing != null)
          {

              if (objLibSampleListing.Count > 0)
              {
                  txtmax_sec.Text = objLibSampleListing[0].MaxQueInSection.ToString();
                  txtmaxattempt.Text = objLibSampleListing[0].MaxAttemptQue.ToString();
                 // txtmaxmarks.Text = objLibSampleListing[0].MaxQueMarks.ToString();
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

                LIBSample objLIBSample = new LIBSample();
                DALSample objDalSample = new DALSample();
                TransportationPacket tp = new TransportationPacket();

                objLIBSample.SamId = Convert.ToInt32(hdnSamId.Value);
                objLIBSample.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                objLIBSample.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
                objLIBSample.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
                tp.MessagePacket = (object)objLIBSample;
                addResult = objDalSample.AddQueInSection(tp);

                if (addResult == 1 )
                {
                   lblMessage.Text = "Saved Successfully";
                   txtmaxattempt.Text = "";
                   txtmax_sec.Text = "";
                   Response.Redirect("SampleStudentInstructionSummary.aspx?SamId=" + Request.QueryString["SamId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString());
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
                    Response.Redirect("SampleSelectSection.aspx?SamId=" + hdnSamId.Value);

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
                    Response.Redirect("SampleAddSelectSection.aspx?SamId=" + Request.QueryString["SamId"].ToString(), false);

                }
                else
                {
                    Response.Redirect("SampleSelectSection.aspx?SamId=" + Request.QueryString["SamId"].ToString(), false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("SampleSelectSection.aspx?SamId=" + Request.QueryString["SamId"].ToString(), false);
            }
        }

    }
    protected void btnSaveContinue_Click(object sender, EventArgs e)
    {
        try
        {
            int addResult = 0;

            LIBSample objLIBSample = new LIBSample();
            DALSample objDalSample = new DALSample();
            TransportationPacket tp = new TransportationPacket();

            objLIBSample.SamId = Convert.ToInt32(hdnSamId.Value);
            objLIBSample.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
            objLIBSample.MaxQueInSection = Convert.ToInt32(txtmax_sec.Text);
            objLIBSample.MaxAttemptQue = Convert.ToInt32(txtmaxattempt.Text);
            tp.MessagePacket = (object)objLIBSample;
            addResult = objDalSample.AddQueInSection(tp);

            if (addResult == 1)
            {
                lblMessage.Text = "Saved Successfully";
                txtmaxattempt.Text = "";
                txtmax_sec.Text = "";
                //Response.Redirect("SelectSection.aspx?SamId=" + hdnSamId.Value);
                Response.Redirect("SampleStudentInstructionSummary.aspx?SamId=" + Request.QueryString["SamId"].ToString() + "&sectionId=" + Request.QueryString["sectionId"].ToString() + "&sectionName=" + Request.QueryString["sectionName"].ToString() + "&a=1");
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
                Response.Redirect("SampleSelectSection.aspx?SamId=" + hdnSamId.Value);

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
