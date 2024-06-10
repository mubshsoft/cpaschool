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
using fmsf.lib;
using fmsf.DAL;
using System.IO;

public partial class Admin_ShowAssignment : System.Web.UI.Page
{
    protected string secname = null;
    protected string secText = null;
    protected DataSet dsInstruction;
    int NOS = 0;
    string strHeading = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        if (!Page.IsPostBack)
        {
            BindInstructionList();
            BindQuestionList(Convert.ToInt32(Request.QueryString["asgnid"]));
            bindsection();
           // export();
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
        }

    }
    protected DataSet BindQuestionOptionList(int QuestionId)
    {
        DataSet dss = new DataSet();
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.QuestionId = QuestionId;
            tp.MessagePacket = (object)objLIBAssignment;

            dss = objDalAssignment.GetQuestionOptionList2(tp);
            if (dss != null)
                if (dss != null)
                {
                    if (dss.Tables != null)
                    {
                        if (dss.Tables[0].Rows != null)
                        {


                        }
                    }
                }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return dss;

    }
    protected void BindInstructionList()
    {
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = Convert.ToInt32(Request.QueryString["asgnid"]);
            //objLIBAssignment.StudentEmail = (Request.QueryString["uid"].ToString());
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




        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void bindsection()
    {
        if (dlsquestion.Items.Count > 0)
        {
            for (int i = 0; i < dlsquestion.Items.Count; i++)
            {
                Label lblcatgname = (Label)dlsquestion.Items[i].FindControl("lblSection");
                Label hdnCatgId = (Label)dlsquestion.Items[i].FindControl("hdnCategoryId");
               
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
            }
        }
    }
    private void export()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=QuestionPaper_"+Request.QueryString["AsgnId"]+".doc");

        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-word ";
       // string str = " <style type='text/css'> .text1  { font-family: Verdana, Arial, Helvetica, sans-serif;   font-size: 12px;   font-style: normal;   font-weight: normal;  }  </style>";
        StringWriter stringWriter = new StringWriter();

        HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        this.RenderControl(htmlTextWriter);
        //stringWriter.WriteLine(str);
        Response.Write(stringWriter.ToString());
        Response.End();
    }
    protected void BindQuestionList(int asgnid)
    {
        try
        {
            DataSet ds2 = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.AsgnId = asgnid;
            tp.MessagePacket = (object)objLIBAssignment;
            ds2 = objDalAssignment.GetQuestionList_(tp);

            dlsquestion.DataSource = ds2;
            dlsquestion.DataBind();



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }

    protected void dlsquestion_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            string anstext = "";
            //DataListItem row = e.Item;
            //if (e.Item.ItemType == ListItemType.Item)
            //{

            Label hdnQuestionId = (Label)e.Item.FindControl("hdnQuestionId");
            Label hdnQUESTYPE = (Label)e.Item.FindControl("hdnQUESTYPE");
            Label hdnAnswer = (Label)e.Item.FindControl("hdnAnswer");
            Panel panel = (Panel)e.Item.FindControl("panel");
            Panel panel1 = (Panel)e.Item.FindControl("panel1");
            Image imgUpload = (Image)e.Item.FindControl("imgUploadImage");
            HtmlTableRow trimage = (HtmlTableRow)e.Item.FindControl("trImage");
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.QuestionId = Convert.ToInt32(hdnQuestionId.Text);
            tp.MessagePacket = (object)objLIBAssignment;

            tp = objDalAssignment.GetQuestionOptionListByOptionType(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            string strOptType = objLibAssignmentListing[0].OPTIONTYPE;




            if (hdnQUESTYPE.Text == "Image Question")
            {
                LIBExam objLIBExam = new LIBExam();
                DALExam objDalExam = new DALExam();
                LIBExamListing objLibExamListing = new LIBExamListing();

                try
                {
                    trimage.Visible = true;
                    DataTable dtEx = new DataTable();
                    dtEx = objDalExam.getdata("select uploadquestionimagepath from Assignmentquestions where questionid=" + hdnQuestionId.Text);
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


            if (hdnQUESTYPE.Text == "Case Study" || hdnQUESTYPE.Text == "Fill Blank")
            {
                DataList gv = new DataList();
                gv = (DataList)e.Item.FindControl("dlSubsquestion");
                try
                {
                    LIBAssignment objLIBAssignment2 = new LIBAssignment();
                    DALAssignment objDalAssignment2 = new DALAssignment();
                    LIBAssignmentListing objLibAssignmentListing2 = new LIBAssignmentListing();
                    TransportationPacket tp2 = new TransportationPacket();
                    objLIBAssignment2.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionId.Text));
                    tp2.MessagePacket = (object)objLIBAssignment;
                    tp = objDalAssignment2.GetSubQuestionList(tp2);
                    objLibAssignmentListing2 = (LIBAssignmentListing)tp.MessageResultset;
                    gv.DataSource = objLibAssignmentListing2;
                    gv.DataBind();

                }
                catch (Exception ex)
                {
                    HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                }

            }

            else if (hdnQUESTYPE.Text == "Descriptive")
            {

                //FileUpload fileup = new FileUpload();
                //Label lblHeading = new Label();
                //lblHeading.Text = "Upload File";
                //lblHeading.CssClass = "style5";

                //fileup.ID = ("flu" + Convert.ToInt32(hdnQuestionId.Text));
                //fileup.Width = 200;
                //fileup.Height = 20;
                //fileup.CssClass = "style5_2";
                //TextBox txtb = new TextBox();

                //txtb.ID = ("txt" + Convert.ToInt32(hdnQuestionId.Text));
                ////txtb.Width = 200;
                ////txtb.Height = 20;
                ////txtb.CssClass = "styletxt";
                //txtb.TextMode = TextBoxMode.MultiLine;
                //txtb.MaxLength = 7900;
                //txtb.CssClass = "styletxt";
                //txtb.Width = 490;
                //txtb.Height = 180;

                //panel.Controls.Add(txtb);

                //panel1.Controls.Add(lblHeading);
                //panel1.Controls.Add(fileup);
                ////anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                ////txtb.Text = anstext;

                ////panel.Controls.Add(lbl);
                ////panel.Controls.Add(btnupload);

            }





            else
            {
                //create dynamic control in grid view
                if (strOptType == "Radio Button")
                {

                    try
                    {
                        LIBAssignment objLIBAssignment1 = new LIBAssignment();
                        DALAssignment objDalAssignment1 = new DALAssignment();
                        LIBAssignmentListing objLibAssignmentListing1 = new LIBAssignmentListing();
                        TransportationPacket tp1 = new TransportationPacket();
                        objLIBAssignment1.QuestionId = Convert.ToInt32(hdnQuestionId.Text);
                        tp1.MessagePacket = (object)objLIBAssignment1;

                        tp1 = objDalAssignment1.GetQuestionOptionListByOptionTypeAll(tp);
                        objLibAssignmentListing1 = (LIBAssignmentListing)tp.MessageResultset;
                        RadioButtonList rd = new RadioButtonList();
                        rd.ID = ("opt" + Convert.ToInt32(hdnQuestionId.Text));
                        //rd.Width = 490;
                        //rd.CssClass = "style5_2";
                        rd.RepeatDirection = RepeatDirection.Vertical;
                        rd.RepeatLayout = RepeatLayout.Flow;
                        rd.DataSource = objLibAssignmentListing1;
                        rd.DataTextField = objLIBAssignment1.OPTIONSDisplayText;
                        rd.DataValueField = objLIBAssignment1.OPTIONSValueField;
                        rd.DataBind();

                        panel.Controls.Add(rd);
                        anstext = (hdnAnswer.Text);
                        rd.Items.FindByText(anstext).Selected = true;



                    }
                    catch (Exception ex)
                    {
                        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                    }
                }
                // for checkboxlist question

                else if (strOptType == "Check Box List")
                {
                    try
                    {
                        LIBAssignment objLIBAssignment1 = new LIBAssignment();
                        DALAssignment objDalAssignment1 = new DALAssignment();
                        LIBAssignmentListing objLibAssignmentListing1 = new LIBAssignmentListing();
                        TransportationPacket tp1 = new TransportationPacket();
                        objLIBAssignment1.QuestionId = Convert.ToInt32(hdnQuestionId.Text);
                        tp1.MessagePacket = (object)objLIBAssignment1;

                        tp1 = objDalAssignment1.GetQuestionOptionListByOptionTypeAll(tp);
                        objLibAssignmentListing1 = (LIBAssignmentListing)tp.MessageResultset;
                        CheckBoxList chk = new CheckBoxList();
                        chk.ID = ("chk" + Convert.ToInt32(hdnQuestionId.Text));
                        chk.Width = 490;
                        chk.CssClass = "style5_2";
                        chk.RepeatDirection = RepeatDirection.Vertical;
                        chk.RepeatLayout = RepeatLayout.Flow;
                        chk.DataSource = objLibAssignmentListing1;
                        chk.DataTextField = objLIBAssignment1.OPTIONSDisplayText;
                        chk.DataValueField = objLIBAssignment1.OPTIONSValueField;
                        chk.DataBind();

                        panel.Controls.Add(chk);
                        try
                        {
                            //LIBAssignment objLIBAssignment2 = new LIBAssignment();
                            //DALAssignment objDalAssignment2 = new DALAssignment();
                            //LIBAssignmentListing objLibAssignmentListing2 = new LIBAssignmentListing();
                            //objLIBAssignment2.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
                            //objLIBAssignment2.UserId = hdnUserId.Value;
                            //objLIBAssignment2.QuestionId =Convert.ToInt16( hdnQuestionId.Value);

                            //TransportationPacket tp2 = new TransportationPacket();
                            //tp2.MessagePacket = (object)objLIBAssignment2;
                            //tp2 = objDalAssignment2.GetAnsText(tp2);
                            //objLibAssignmentListing2 = (LIBAssignmentListing)tp2.MessageResultset;
                            //for (int i = 0; i < objLibAssignmentListing2.Count; i++)
                            //{

                            //        chk.Items.FindByText(objLibAssignmentListing2[i].AnsText).Selected = true;

                            //}


                        }
                        catch (Exception ex)
                        {
                            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                        }




                    }
                    catch (Exception ex)
                    {
                        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                    }
                }

                else //if (strOptType == "TextBox")
                {
                    //TextBox txtb = new TextBox();
                    //txtb.ID = ("txt" + Convert.ToInt32(hdnQuestionId.Text));

                    //panel.Controls.Add(txtb);

                    ////anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));

                    ////txtb.Text = anstext;
                    //txtb.TextMode = TextBoxMode.MultiLine;
                    //txtb.CssClass = "styletxt";
                    //txtb.MaxLength = 7900;
                    //txtb.Width = 490;
                    //txtb.Height = 180;

                }
            }





            //}

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void dlSubsquestion_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            string anstext = "";

            DataListItem rowF = e.Item;
            if (rowF.ItemType != null)
            {
                Label hdnQuestionId = (Label)e.Item.FindControl("hdnSubQuestionId");
                Label hdnType = (Label)e.Item.FindControl("hdnType");
                Label hdnSubAnswer = (Label)e.Item.FindControl("hdnSubAnswer");

                string value = hdnType.Text;
                Panel panel = (Panel)e.Item.FindControl("panel");

                LIBAssignment objLIBAssignment = new LIBAssignment();
                DALAssignment objDalAssignment = new DALAssignment();
                LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBAssignment.SubQuestionId = Convert.ToInt32(hdnQuestionId.Text);
                tp.MessagePacket = (object)objLIBAssignment;

                tp = objDalAssignment.GetSubQuestionOptionListByOptionType(tp);
                objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
                string strOptType = "";
                strOptType = objLibAssignmentListing[0].OPTIONTYPE;


                // create dynamic control in grid view
                if (strOptType == "Radio Button")
                {

                    try
                    {
                        LIBAssignment objLIBAssignment1 = new LIBAssignment();
                        DALAssignment objDalAssignment1 = new DALAssignment();
                        LIBAssignmentListing objLibAssignmentListing1 = new LIBAssignmentListing();
                        TransportationPacket tp1 = new TransportationPacket();
                        objLIBAssignment1.SubQuestionId = Convert.ToInt32(hdnQuestionId.Text);
                        tp1.MessagePacket = (object)objLIBAssignment1;

                        tp1 = objDalAssignment1.GetSubQuestionOptionListByOptionTypeAll(tp);
                        objLibAssignmentListing1 = (LIBAssignmentListing)tp.MessageResultset;
                        RadioButtonList rd = new RadioButtonList();
                        rd.ID = ("opt" + "_" + Convert.ToInt32(hdnQuestionId.Text));
                        rd.Width = 490;
                        rd.CssClass = "style5_2";
                        rd.RepeatDirection = RepeatDirection.Vertical;
                        rd.RepeatLayout = RepeatLayout.Flow;
                        rd.DataSource = objLibAssignmentListing1;
                        rd.DataTextField = objLIBAssignment1.OPTIONSDisplayText;
                        rd.DataValueField = objLIBAssignment1.OPTIONSValueField;
                        rd.DataBind();

                        panel.Controls.Add(rd);
                        anstext = (hdnSubAnswer.Text);
                        rd.Items.FindByText(anstext).Selected = true;

                    }
                    catch (Exception ex)
                    {
                        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                    }
                }


                else if (hdnType.Text == "Fill Blank" && strOptType == "Text Box")
                {
                    //TextBox txtb = new TextBox();
                    //txtb.ID = ("txt" + "_" + Convert.ToInt32(hdnQuestionId.Text));
                    ////txtb.Width = 200;
                    ////txtb.Height = 20;

                    //txtb.CssClass = "styletxt";
                    //txtb.MaxLength = 7900;
                    //txtb.Width = 200;
                    //txtb.Height = 20;
                    //panel.Controls.Add(txtb);
                    //anstext = BindsubAnsText(Convert.ToInt32(hdnQuestionId.Value));
                    //if (anstext == "")
                    //{
                    //}
                    //else
                    //{
                    //    txtb.Text = anstext;
                    //}
                }
                else if (hdnType.Text == "Case Study" && strOptType == "Text Box")
                {
                    //TextBox txtb = new TextBox();
                    //txtb.ID = ("txt" + "_" + Convert.ToInt32(hdnQuestionId.Text));
                    ////txtb.Width = 200;
                    ////txtb.Height = 20;
                    //txtb.TextMode = TextBoxMode.MultiLine;
                    //txtb.CssClass = "styletxt";
                    //txtb.MaxLength = 7900;
                    //txtb.Width = 490;
                    //txtb.Height = 180;
                    //panel.Controls.Add(txtb);
                    //anstext = BindsubAnsText(Convert.ToInt32(hdnQuestionId.Value));
                    //if (anstext=="")
                    //{
                    //}
                    //else
                    //{
                    //    txtb.Text = anstext;
                    //}

                }



            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected string BindAnsText(int questionid)
    {
        string addResult = "";
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
            objLIBAssignment.UserId = hdnUserId.Value;
            objLIBAssignment.QuestionId = questionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetAnsText(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            if (objLibAssignmentListing != null)
            {

                if (objLibAssignmentListing.Count > 0)
                {


                    addResult = objLibAssignmentListing[0].AnsText;

                }
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return addResult;

    }

    protected string BindsubAnsText(int Subquestionid)
    {
        string addResult = "";
        try
        {
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnAsgnId.Value);
            objLIBAssignment.UserId = hdnUserId.Value;
            objLIBAssignment.SubQuestionId = Subquestionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBAssignment;
            tp = objDalAssignment.GetSubQuestionAnsText(tp);
            objLibAssignmentListing = (LIBAssignmentListing)tp.MessageResultset;
            if (objLibAssignmentListing != null)
            {

                if (objLibAssignmentListing.Count > 0)
                {


                    addResult = objLibAssignmentListing[0].AnsText;
                }
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return addResult;

    }
    protected void ImgBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAssignmentSet.aspx");
    }
}
