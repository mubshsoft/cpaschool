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
using System.IO;

public partial class Faculty_AssignmentInstruction : System.Web.UI.Page
{
    int NOS = 0;
    string strHeading = "";
    int totalObjectiveMarks = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("../login.aspx");

            }
            if (!Page.IsPostBack)
            {
                hdnAsgnId.Value = Request.QueryString["Asgnid"].ToString();
                BindInstructionList();
                hdnuserid.Value = Request.QueryString["uid"].ToString();

                String strGrandQ;
                String strGrand = "";
                String strGrandTotal = "";
                strGrandQ = "select categoryname from Assignment_category where AsgnId=" + Request.QueryString["Asgnid"].ToString();
                DataSet dsGrand = new DataSet();
                dsGrand = CLS_C.fnQuerySelectDs(strGrandQ);
                int i;
                for (i = 0; i < dsGrand.Tables[0].Rows.Count; i++)
                {
                    strGrand = strGrand + dsGrand.Tables[0].Rows[i][0].ToString() + " + ";
                }
                strGrandTotal = strGrand.Remove(strGrand.Length - 2);
                strGrandTotal = strGrandTotal.Replace("Section", "");
                lblGrand.Text = "(" + "Section " + strGrandTotal + ")";
                GetUserList();
                bindsection();
                BindAssignmentDate();
                ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
                //lblDate.Text =Convert.ToString(Session["date"]);
                //export();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void BindInstructionList()
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value.ToString());
            objLIBAssignment.StudentEmail = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetAssignmentInstruction(tp);

            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                if (objLibAssignmentListing.Count > 0)
                {
                    lblCourseName.Text = objLibAssignmentListing[0].CourseTitle;
                    lblCourseCode.Text = objLibAssignmentListing[0].CourseCode;
                    lblAssignmentCode.Text = objLibAssignmentListing[0].Assignmentcode;
                    lblPaperName.Text = objLibAssignmentListing[0].PaperTitle;
                }
            }

            tp = objDalAssignment.GetStudenInfo(tp);

            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;

            if (objLibAssignmentListing != null)
            {
                try
                {
                    if (objLibAssignmentListing.Count > 0)
                    {
                        DataTable dtEx = new DataTable();
                        dtEx = objDalAssignment.getdata("select refrenceid from studentregcourse where stid=" + objLibAssignmentListing[0].Stid.ToString() + " and courseid in(select courseid from Assignmentset where AsgnId=" + Convert.ToInt32(hdnAsgnId.Value.ToString()) + ")");
                        lblStid.Text = dtEx.Rows[0]["refrenceid"].ToString();

                        //lblStid.Text = objLibAssignmentListing[0].Stid.ToString();
                        //lblStudentName.Text = objLibAssignmentListing[0].StudentName;

                    }
                }
                catch (Exception ex)
                { }
            }
            DataTable dt = new DataTable();
            dt = objDalAssignment.getdata("select TimeAllowted from AssignmentSet where AsgnId=" + Request.QueryString["Asgnid"].ToString());
            lblTimeAlloted.Text = (Convert.ToInt32(dt.Rows[0]["TimeAllowted"].ToString()) / 60).ToString() + " min";


            DataTable dt1 = new DataTable();
            dt1 = objDalAssignment.getdata("select firstname + ' ' + lastname as name from student where email='" + Request.QueryString["uid"].ToString() + "'");
            lblStudentName.Text = dt1.Rows[0]["name"].ToString();

            DataTable dt3 = new DataTable();
            dt3 = objDalAssignment.getdata("select ActivateDate,EndAssignmenttime from studentActiveAssignment where AsgnId=" + Request.QueryString["Asgnid"].ToString() + " and  UserId='" + Request.QueryString["uid"].ToString() + "'");
            DateTime date1;
            DateTime date2;
            date1 = Convert.ToDateTime(dt3.Rows[0]["ActivateDate"].ToString());
            string st = dt3.Rows[0]["EndAssignmenttime"].ToString();
            try
            {
                date2 = Convert.ToDateTime(dt3.Rows[0]["EndAssignmenttime"]);

            }
            catch (Exception ex)
            {
                date2 = Convert.ToDateTime(dt3.Rows[0]["ActivateDate"].ToString());
            }

            TimeSpan difference = date2.Subtract(date1);

            double totalSeconds = difference.Seconds;
            double totalMinuts = difference.Minutes;
            lblTimeTaken.Text = totalMinuts.ToString() + ":" + totalSeconds.ToString() + " min";



            //lblDate.Text = DateTime.Now.ToShortDateString();
            DataSet ds = new DataSet();
            ds = objDalAssignment.GetInstructionSummary(tp);

            //objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            dlstInstructionSummary.DataSource = ds;
            dlstInstructionSummary.DataBind();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void BindAssignmentDate()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.AsgnId = Convert.ToInt32(hdnAsgnId.Value.ToString());
            objLIBExam.UserId = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetAssignmentDate(tp);

            objLibExamListing = (LIBExamListing)tp.MessageResultset;

            if (objLibExamListing != null)
            {
                if (objLibExamListing.Count > 0)
                {

                    lblDate.Text = Convert.ToString(objLibExamListing[0].activateDate);

                }
            }


        }



        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }





    protected void btnStartAssignment_Click(object sender, ImageClickEventArgs e)
    {
        int intAsgnId;
        try
        {
            intAsgnId = Convert.ToInt32(hdnAsgnId.Value);
            string strQAssignment;
            strQAssignment = "update studentActiveAssignment set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where AsgnId=" + intAsgnId + "and userid='" + Session["username"] + "'";
            CLS_C.fnExecuteQuery(strQAssignment);
        }
        catch (Exception ex)
        {
        }

        Response.Redirect("SubmitAssignment.aspx?AsgnId=" + hdnAsgnId.Value + "&review=0");
    }
    protected void lnkbtnexport_Click(object sender, EventArgs e)
    {
        //Response.Clear();

        //Response.Buffer = true;

        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");

        //Response.Charset = "";
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.ms-word ";

        //StringWriter sw = new StringWriter();

        //HtmlTextWriter hw = new HtmlTextWriter(sw);


        ////dlstanswers.DataBind();

        //dlstanswers.RenderControl(hw);
        ////LstUserAssignmentinfo.RenderControl(hw) 
        //Response.Output.Write(sw.ToString());

        //Response.Flush();

        //Response.End(); 
    }

    protected void GetUserList()
    {

        try
        {
            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.UserId = (hdnuserid.Value.ToString());
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);

            tp.MessagePacket = (object)objLIBAssignment;

            ds = objDalAssignment.GetSubmiitedAssignmentByUserId(tp);

            dlstanswers.DataSource = ds;
            dlstanswers.DataBind();




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }



    protected void bindsection()
    {
        if (dlstanswers.Items.Count > 0)
        {
            for (int i = 0; i < dlstanswers.Items.Count; i++)
            {
                Label lblcatgname = (Label)dlstanswers.Items[i].FindControl("lblcategoryname");
                Label hdnCatgId = (Label)dlstanswers.Items[i].FindControl("hdnCatgId");
                Label lblcorectanswers = (Label)dlstanswers.Items[i].FindControl("lblcorectanswers");
                Label lblcorectanswerstext = (Label)dlstanswers.Items[i].FindControl("lblcorectanswerstext");
                Label hdnQUESTYPE = (Label)dlstanswers.Items[i].FindControl("hdnquestype");
                Label hdnQUESID = (Label)dlstanswers.Items[i].FindControl("hdnquesid");
                Label Label2 = (Label)dlstanswers.Items[i].FindControl("Label2");
                Label Label1 = (Label)dlstanswers.Items[i].FindControl("Label1");
                Label lblmaxmarks = (Label)dlstanswers.Items[i].FindControl("lblmaxmarks");

                HtmlTableRow tr1 = (HtmlTableRow)dlstanswers.Items[i].FindControl("trRow1");
                HtmlTableRow tr2 = (HtmlTableRow)dlstanswers.Items[i].FindControl("trRow2");
                HtmlTableRow tr3 = (HtmlTableRow)dlstanswers.Items[i].FindControl("trRow3");
                HtmlTableRow trLineMain = (HtmlTableRow)dlstanswers.Items[i].FindControl("trLineMain");
                HtmlTableRow trLineSub = (HtmlTableRow)dlstanswers.Items[i].FindControl("trLineSub");
                Image imgUpload = (Image)dlstanswers.Items[i].FindControl("imgUploadImage");
                HtmlTableRow trimage = (HtmlTableRow)dlstanswers.Items[i].FindControl("trImage");
                Label lblanstext = (Label)dlstanswers.Items[i].FindControl("lblanstext");
                Label lblMarkscored = (Label)dlstanswers.Items[i].FindControl("lblMarkscored");

                TextBox  txtMarkscored = (TextBox)dlstanswers.Items[i].FindControl("txtMarkscored");



                lblanstext.Text.Replace("<br>", "\r\n");
                DataList gv = new DataList();
                gv = (DataList)dlstanswers.Items[i].FindControl("dlstSubanswers");
                if (hdnQUESTYPE.Text == "Objective")
                {
                    if (lblanstext.Text.Replace("\t", "") == lblcorectanswerstext.Text)
                    {
                        totalObjectiveMarks = totalObjectiveMarks + Convert.ToInt32(lblmaxmarks.Text);
                        lblMarkscored.Text = lblmaxmarks.Text;
                    }
                    else
                    {
                        lblMarkscored.Text = "0";
                    }

                    lblcorectanswers.Visible = true;
                    //Label2.Visible = false;
                    tr1.Visible = false;
                    tr2.Visible = false;
                }
                else
                {
                    txtMarkscored.Visible = true;
                    if (String.IsNullOrEmpty(txtMarkscored.Text))
                    {
                        txtMarkscored.Text = "0";
                    }
                    totalObjectiveMarks = totalObjectiveMarks + Convert.ToInt32(txtMarkscored.Text);
                    lblcorectanswers.Visible = false;
                }
                if (strHeading != hdnCatgId.Text)
                {
                    strHeading = hdnCatgId.Text;
                    NOS = 1;
                }
                else
                {
                    NOS = 0;
                }

                if (strHeading != "")
                {
                    if (NOS == 1)
                    {
                        lblcatgname.Visible = true;

                    }
                    else
                    {
                        lblcatgname.Visible = false;
                    }
                }

                if (hdnQUESTYPE.Text == "Case Study" || hdnQUESTYPE.Text == "Fill Blank")
                {

                    try
                    {
                        DataSet ds = new DataSet();
                        LIBAssignment objLIBAssignment = new LIBAssignment();
                        DALAssignment objDalAssignment = new DALAssignment();
                        LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
                        TransportationPacket tp = new TransportationPacket();
                        objLIBAssignment.UserId = (hdnuserid.Value.ToString());
                        objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
                        objLIBAssignment.QuestionId = Convert.ToInt32(hdnQUESID.Text);
                        tp.MessagePacket = (object)objLIBAssignment;

                        ds = objDalAssignment.GetSubmiitedCaseStudyAssignmentByUserId(tp);

                        gv.DataSource = ds;
                        gv.DataBind();
                        lblcorectanswers.Visible = false;
                        tr1.Visible = false;
                        tr2.Visible = false;
                        tr3.Visible = false;
                        // Label1.Visible = false;
                        // int countPre = ds.Tables[0].Rows.Count - 1;
                        int countPre = ds.Tables[0].Rows.Count;
                        //if (ds.Tables[0].Rows.Count > 1)
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            trLineMain.Visible = true;
                            trLineSub.Visible = false;
                            //Label lblSubMarkscored = (Label)gv.Items[i].FindControl("lblSubMarkscored");
                            
                            //TextBox txtSubMarkscored = (TextBox)gv.Items[i].FindControl("txtSubMarkscored");

                        }
                        else
                        {
                            trLineMain.Visible = false;
                            trLineSub.Visible = true;
                        }


                    }
                    catch (Exception ex)
                    {
                        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                    }

                }
                else
                {
                    tr3.Visible = true;
                }

                //for image

                if (hdnQUESTYPE.Text == "Image Question")
                {

                    try
                    {
                        DALAssignment objDalAssignment = new DALAssignment();
                        trimage.Visible = true;
                        DataTable dtEx = new DataTable();
                        dtEx = objDalAssignment.getdata("select uploadquestionimagepath from Assignmentquestions where questionid=" + hdnQUESID.Text);
                        string ImgFilename = dtEx.Rows[0]["uploadquestionimagepath"].ToString();
                        string uploadFolder = "~/Admin/UploadQuestionImage/" + ImgFilename;
                        imgUpload.ImageUrl = uploadFolder;

                    }
                    catch (Exception ex)
                    {
                        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                    }

                }
                else
                {
                    trimage.Visible = false;
                }
            }

            Label lbltotalObjmarks = (Label)dlstInstructionSummary.Items[0].FindControl("lbltotalObjmarks");
            lbltotalObjmarks.Text = Convert.ToString(totalObjectiveMarks);
            hdnTotalMarks.Value = Convert.ToString(totalObjectiveMarks);
        }
    }
    protected void dlstanswers_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            // string anstext;
            DataListItem row = e.Item;
            if (e.Item.ItemType == ListItemType.Item)
            {


            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void dlstSubanswers_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            // string anstext;
            DataListItem row = e.Item;
            //if (e.Item.ItemType == ListItemType.Item)
            //{


            //}
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                
                string lblSubMarkscored = (e.Item.FindControl("lblSubMarkscored") as Label).Text;
                string txtSubMarkscored = (e.Item.FindControl("txtSubMarkscored") as TextBox).Text;
                
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void export()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=AnswerSheet_" + Request.QueryString["uid"] + ".doc");

        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-word ";

        StringWriter stringWriter = new StringWriter();

        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        this.RenderControl(htmlTextWriter);

        Response.Write(stringWriter.ToString());
        Response.End();
    }

    protected void ImgBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FacultyListAssignment.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //DataList gv = new DataList();
        //gv = (DataList)dlstanswers.Items[i].FindControl("dlstSubanswers");

        // for (int i = 0; i < gv.Table; i++)
        //{
        //    try
        //    {
        //        Label hdnsubansid = (Label)dlstSubanswers.Items[i].FindControl("hdnsubansid");
        //        Label hdnsubQuestionId = (Label)dlstSubanswers.Items[i].FindControl("hdnsubQuestionId");
        //        TextBox txtSubMarkscored = (TextBox)dlstSubanswers.Items[i].FindControl("txtSubMarkscored");
        //        TextBox txtfeedback = (TextBox)dlstSubanswers.Items[i].FindControl("txtfeedback");

        //        int qid= Convert.ToInt32(hdnsubQuestionId.Value);
        //        int ansid = Convert.ToInt32(hdnsubansid.Value);
        //        int marks = 0;

        //        marks = Convert.ToInt32(txtMarkscored.Text.Trim());

        //    }
        //    catch (Exception ex1)
        //    {

        //    }
        //  }

        for (int i = 0; i < dlstanswers.Items.Count; i++)
        {
            try
            {
                Label hdnquesid = (Label)dlstanswers.Items[i].FindControl("hdnquesid");
                Label hdnQUESTYPE = (Label)dlstanswers.Items[i].FindControl("hdnquestype");
                Label lblMarkscored = (Label)dlstanswers.Items[i].FindControl("lblMarkscored");
                TextBox txtMarkscored = (TextBox)dlstanswers.Items[i].FindControl("txtMarkscored");
                TextBox txtfeedback = (TextBox)dlstanswers.Items[i].FindControl("txtfeedback");
                HiddenField hdnAnsid = (HiddenField)dlstanswers.Items[i].FindControl("hdnAnsid");

                int ansid = Convert.ToInt32(hdnAnsid.Value);
                int marks = 0;

                if (hdnQUESTYPE.Text == "Objective")
                {
                    marks = Convert.ToInt32(lblMarkscored.Text);
                }
                else
                {
                    marks = Convert.ToInt32(txtMarkscored.Text.Trim());
                }



                string strfeedback = txtfeedback.Text;
                string strTool = txtfeedback.ToolTip;

                int intAsgnId;
                intAsgnId = Convert.ToInt32(hdnAsgnId.Value);
                try
                {
                   
                    string strQAssignment;
                    strQAssignment = "update AssignmentQUES_ANSWERS set feedback='" + strfeedback + "', MarkGivenByFaculty='" + marks + "' where AsgnId=" + intAsgnId + " and Ansid=" + ansid;
                    CLS_C.fnExecuteQuery(strQAssignment);
                }
                catch (Exception ex)
                {
                }

            }
            catch (Exception ex)
            {

            }
        }
        try
        {
           

            LIBAssignment objLibAssignment = new LIBAssignment();
            DALAssignment OBJDALAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();

            
            objLibAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
            objLibAssignment.UserId = hdnuserid.Value;
            objLibAssignment.TotalMarks = Convert.ToInt32(hdnTotalMarks.Value);// totalObjectiveMarks;
            objLibAssignment.FacultyId = Convert.ToInt32(Session["fid"]);

            tp.MessagePacket = (object)objLibAssignment;
            int addResult = OBJDALAssignment.AddUpdateAssignmentFinalMarks(tp);
            if (addResult == 1)
            {
                
                //lblMessage.Text = "Saved Successfully.";
                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Saved Successfully'); </script>");
                
            }
        }
        catch(Exception ex)
        {

        }
    }
}
