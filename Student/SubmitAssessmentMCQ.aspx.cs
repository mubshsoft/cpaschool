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
using System.IO;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;
using System.Xml;
using fmsf.lib;
using fmsf.DAL;

public partial class Student_SubmitAssessmentMCQ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            hdnUserId.Value = Session["username"].ToString();
            hdnFileName.Value = "ExamFile/" + Guid.NewGuid().ToString().GetHashCode().ToString("x") + ".xml";
            GetBid();
            BindQuestionList();
        }

        BindQuestionListwithsession();
    }

    protected void BindQuestionList()
    {
        try
        {
            int uid = Convert.ToInt32(Request.QueryString["unitid"].ToString());
            int ChapterId = Convert.ToInt32(Request.QueryString["ChapterId"].ToString());
            hdnUnitid.Value = uid.ToString();
            hdnChapter.Value = ChapterId.ToString();
            DataSet ds2 = new DataSet();
            Chapter objLIBExam = new Chapter();
            DALChapter objDalExam = new DALChapter();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.UnitID = Convert.ToInt32(uid);
            objLIBExam.ChapterID = ChapterId.ToString();
            tp.MessagePacket = (object)objLIBExam;

            ds2 = objDalExam.GetRandomlyAssessmentsQuestionList(tp);
            this.XMLSerializeMyBasicCObject(Server.MapPath(hdnFileName.Value), ds2);


            dlsquestion.DataSource = ds2;
            dlsquestion.DataBind();

            //bindquesbysection(ds2);
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = ds2.Tables[0].DefaultView;
            objPds.AllowPaging = true;
            objPds.PageSize = 1;

            objPds.CurrentPageIndex = CurrentPage;

            btnprev.Visible = !objPds.IsFirstPage;
            btnnext.Visible = !objPds.IsLastPage;


            dlsquestion.DataSource = objPds;
            dlsquestion.DataBind();

            //lblqueno.Text = " " + CurrentPage + 1 + " of " + ds2.Tables[0].Rows.Count;

            if (dlsquestion.Items.Count == 0)
            {
                tbl.Visible = false;
            }
            if (dlsquestion.Items.Count == 0)
            {
                tbl.Visible = true;
            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void GetBid()
    {
        LIBExam objLIBExam = new LIBExam();
        DALExam objDalExam = new DALExam();
        LIBExamListing objLibExamListing = new LIBExamListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.Stid = Convert.ToInt32(Session["stid"]);

        tp.MessagePacket = (object)objLIBExam;

        hdnBid.Value = Convert.ToString(objDalExam.GetBid(tp));

    }
    protected void dlsquestion_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            string anstext;
            DataListItem row = e.Item;
            if (e.Item.ItemType == ListItemType.Item)
            {

                HiddenField hdnQuestionId = (HiddenField)e.Item.FindControl("hdnQuestionId");
                HiddenField hdnQUESTYPE = (HiddenField)e.Item.FindControl("hdnQUESTYPE");
                Panel panel = (Panel)e.Item.FindControl("panel4");
                Panel panel1 = (Panel)e.Item.FindControl("panel5");
                

                LIBExam objLIBExam = new LIBExam();
                DALChapter objDalExam = new DALChapter();
                LIBExamListing objLibExamListing = new LIBExamListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                tp.MessagePacket = (object)objLIBExam;

                tp = objDalExam.GetAssesmentsQuestionOptionListByOptionType(tp);
                objLibExamListing = (LIBExamListing)tp.MessageResultset;
                string strOptType = objLibExamListing[0].OPTIONTYPE;



                //create dynamic control in grid view
                if (strOptType == "Radio Button")
                {

                    try
                    {
                        LIBExam objLIBExam1 = new LIBExam();
                        DALChapter objDalExam1 = new DALChapter();
                        LIBExamListing objLibExamListing1 = new LIBExamListing();
                        TransportationPacket tp1 = new TransportationPacket();
                        objLIBExam1.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                        tp1.MessagePacket = (object)objLIBExam1;

                        tp1 = objDalExam1.GetAssesmentsQuestionOptionListByOptionTypeAll(tp);
                        objLibExamListing1 = (LIBExamListing)tp.MessageResultset;
                        RadioButtonList rd = new RadioButtonList();
                        //rd.ID = ("opt" + Convert.ToInt32(hdnQuestionId.Value));

                        rd.ID = ("opt" + Convert.ToInt32(hdnQuestionId.Value));
                        //rd.Width = 490;
                        rd.CssClass = "style5";
                        rd.RepeatDirection = RepeatDirection.Vertical;
                        rd.RepeatLayout = RepeatLayout.Flow;
                        rd.DataSource = objLibExamListing1;
                        rd.DataTextField = objLIBExam1.OPTIONSDisplayText;
                        rd.DataValueField = objLIBExam1.OPTIONSValueField;
                        rd.DataBind();

                        panel.Controls.Add(rd);
                        anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
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
                        LIBExam objLIBExam1 = new LIBExam();
                        DALChapter objDalExam1 = new DALChapter();
                        LIBExamListing objLibExamListing1 = new LIBExamListing();
                        TransportationPacket tp1 = new TransportationPacket();
                        objLIBExam1.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                        tp1.MessagePacket = (object)objLIBExam1;

                        tp1 = objDalExam1.GetAssesmentsQuestionOptionListByOptionTypeAll(tp);
                        objLibExamListing1 = (LIBExamListing)tp.MessageResultset;
                        CheckBoxList chk = new CheckBoxList();
                        chk.ID = ("chk" + Convert.ToInt32(hdnQuestionId.Value));
                        chk.Width = 490;
                        chk.CssClass = "style5";
                        chk.RepeatDirection = RepeatDirection.Vertical;
                        chk.RepeatLayout = RepeatLayout.Flow;
                        chk.DataSource = objLibExamListing1;
                        chk.DataTextField = objLIBExam1.OPTIONSDisplayText;
                        chk.DataValueField = objLIBExam1.OPTIONSValueField;
                        chk.DataBind();

                        panel.Controls.Add(chk);
                        try
                        {
                            LIBExam objLIBExam2 = new LIBExam();
                            DALChapter objDalExam2 = new DALChapter();
                            LIBExamListing objLibExamListing2 = new LIBExamListing();
                            //objLIBExam2.ExamId = Convert.ToInt32(hdnExamId.Value);
                            //objLIBExam2.UserId = hdnUserId.Value;
                            objLIBExam2.QuestionId = Convert.ToInt16(hdnQuestionId.Value);

                            TransportationPacket tp2 = new TransportationPacket();
                            tp2.MessagePacket = (object)objLIBExam2;
                            tp2 = objDalExam2.GetAnsText(tp2);
                            objLibExamListing2 = (LIBExamListing)tp2.MessageResultset;
                            for (int i = 0; i < objLibExamListing2.Count; i++)
                            {
                                chk.Items.FindByText(objLibExamListing2[i].AnsText).Selected = true;

                            }


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
            LIBExam objLIBExam = new LIBExam();
            DALChapter objDalExam = new DALChapter();
            LIBExamListing objLibExamListing = new LIBExamListing();
           
            objLIBExam.QuestionId = questionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetAnsText(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            if (objLibExamListing != null)
            {

                if (objLibExamListing.Count > 0)
                {


                    addResult = objLibExamListing[0].AnsText;
                    //bool chk = objLibExamListing[0].Review;
                    //ChkReview.Checked = chk;
                }
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return addResult;

    }

    protected string CheckCorrectAnsText(int questionid)
    {
        string addResult = "";
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALChapter objDalExam = new DALChapter();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.UnitID =Convert.ToInt32(hdnUnitid.Value);
            objLIBExam.ChapterID = Convert.ToInt32(hdnChapter.Value);
            objLIBExam.QuestionId = questionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.CheckAssessmentsQuestionAnswer(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            if (objLibExamListing != null)
            {

                if (objLibExamListing.Count > 0)
                {
                    addResult = objLibExamListing[0].Answer;
                }
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return addResult;

    }
    public void getans()
    {
        //foreach (DataListItem row in dlsquestion.Items)
        //for(int)
        //{
        try
        {

            // submit answer in data base of question
            int addResult = 0;



            int QuesId = 0;
            
            HiddenField hdnQUESTYPE = (HiddenField)dlsquestion.Items[0].FindControl("hdnQUESTYPE");
            HiddenField hdnQuestionId = (HiddenField)dlsquestion.Items[0].FindControl("hdnQuestionId");
            HiddenField hdnOptionType = (HiddenField)dlsquestion.Items[0].FindControl("hdnOPTIONTYPE");
           // HiddenField hdnCategoryId = (HiddenField)dlsquestion.Items[0].FindControl("hdnCategoryId");

            string checkmaxlimit = "0";

            if (hdnQUESTYPE.Value == "Descriptive" || hdnQUESTYPE.Value == "Image Question")
            {

            }

            else  //  code for normal question
            {

                string option = "";
                QuesId = Convert.ToInt16(hdnQuestionId.Value);
                string strOptType = hdnOptionType.Value;


                string strVal = "";
                string CtrlId = "";
                if (strOptType == "")
                {
                    CtrlId = "txt" + QuesId;
                }
                else if (strOptType == "Radio Button")
                {
                    CtrlId = "opt" + QuesId;
                }
                else if (strOptType == "Check Box List")
                {
                    CtrlId = "chk" + QuesId;
                    option = "chk";
                }

                strVal = fngetValueofCtrl(CtrlId, strOptType);

                if (strVal != "" && option == "")
                {

                    LIBExam objLibExam = new LIBExam();
                    DALChapter OBJDALExam = new DALChapter();
                    TransportationPacket tp = new TransportationPacket();

                    objLibExam.AnsText = strVal;
                    objLibExam.Option = option;
                    if (ChkReview.Checked == true)
                    {
                        objLibExam.Review = true;
                    }
                    else
                    {
                        objLibExam.Review = false;
                    }
                    objLibExam.QuestionId = QuesId;

                    objLibExam.UnitID = Convert.ToInt32(hdnUnitid.Value);
                    objLibExam.ChapterID = Convert.ToInt32(hdnChapter.Value);
                    objLibExam.UserId = hdnUserId.Value;
                    objLibExam.BatchId = Convert.ToInt16(hdnBid.Value);
                    tp.MessagePacket = (object)objLibExam;
                    // check max limit

                    //checkmaxlimit = OBJDALExam.CheckMaxLimit(tp);

                    addResult = OBJDALExam.SubmitAssessmentsAns(tp);
                    if (addResult == -11)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section.If you have answered more than " + checkmaxlimit + " questions, then the last question attempted by you will be considered invalid.Click on OK to proceed');</script>");
                        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section');</script>");
                    }

                }
                else if (strVal != "")
                {
                    LIBExam objLibExam = new LIBExam();
                    DALChapter OBJDALExam = new DALChapter();
                    TransportationPacket tp = new TransportationPacket();
                    objLibExam.QuestionId = QuesId;

                    objLibExam.UnitID = Convert.ToInt32(hdnUnitid.Value);
                    objLibExam.ChapterID = Convert.ToInt32(hdnChapter.Value);
                    objLibExam.UserId = hdnUserId.Value;
                    objLibExam.BatchId = Convert.ToInt16(hdnBid.Value);
                    tp.MessagePacket = (object)objLibExam;
                    OBJDALExam.DeleteAssessmentsCheckboxExamAns(tp);


                    String[] strValu = strVal.Split(',');


                    for (int i = 0; i < (strValu.Length - 1); i++)
                    {



                        objLibExam.AnsText = strValu[i].ToString();
                        objLibExam.Option = option;
                        if (ChkReview.Checked == true)
                        {
                            objLibExam.Review = true;
                        }
                        else
                        {
                            objLibExam.Review = false;
                        }
                        objLibExam.QuestionId = QuesId;

                        objLibExam.UnitID = Convert.ToInt32(hdnUnitid.Value);
                        objLibExam.ChapterID = Convert.ToInt32(hdnChapter.Value);
                        objLibExam.UserId = hdnUserId.Value;
                        objLibExam.BatchId = Convert.ToInt16(hdnBid.Value);
                        tp.MessagePacket = (object)objLibExam;
                        // check max limit

                        //checkmaxlimit = OBJDALExam.CheckMaxLimit(tp);

                        addResult = OBJDALExam.SubmitAssessmentsAns(tp);
                        if (addResult == -11)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section.If you have answered more than " + checkmaxlimit + " questions, then the last question attempted by you will be considered invalid.Click on OK to proceed');</script>");
                            // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section');</script>");
                        }

                    }
                }
            }

            //  gvQuestionList.PageIndex = e.NewPageIndex;
            BindQuestionListwithsession();
            //ChkReview.Checked = false;
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        //}
    }
    protected string fngetValueofCtrl(string strId, string strOptType)
    {
        string strValue = "";
        try
        {
            foreach (DataListItem gv in dlsquestion.Items)
            {

                if (strOptType == "Radio Button")
                {
                   
                    RadioButtonList opt = (RadioButtonList)gv.FindControl(strId);
                    
                    if (opt != null)
                    {
                        strValue = opt.SelectedItem.Text;
                        break;
                    }
                }
                else if (strOptType == "Check Box List")
                {
                    CheckBoxList chk = (CheckBoxList)gv.FindControl(strId);

                    if (chk != null)
                    {
                        for (int i = 0; i < chk.Items.Count; i++)
                        {
                            if (chk.Items[i].Selected)
                            {
                                strValue = strValue + chk.Items[i].Text + ",";

                            }
                        }

                        break;
                    }
                }
                else if (strOptType == "FilePath")
                {
                    Label txt = (Label)gv.FindControl(strId);

                    if (txt != null)
                    {
                        //strValue = txt.Text;
                        //wahid
                        strValue = txt.Text;
                        break;
                    }
                }
                else
                {
                    TextBox txt = (TextBox)gv.FindControl(strId);

                    if (txt != null)
                    {
                        //strValue = txt.Text;
                        //wahid
                        strValue = txt.Text.Replace("\r\n", "<br>");
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        return strValue;
    }
    protected string fngetValueofCtrl2(string strId, string strOptType)
    {
        string strValue = "";
        try
        {
            foreach (DataListItem gv in dlsquestion.Items)
            {
                // fatch value frim inner grid view
                DataList opt2 = (DataList)gv.FindControl("dlSubsquestion");

                if (strOptType == "Radio Button")
                {
                    foreach (DataListItem gv2 in opt2.Items)
                    {
                        RadioButtonList opt = (RadioButtonList)gv2.FindControl(strId);

                        if (opt != null)
                        {
                            strValue = opt.SelectedItem.Text;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (DataListItem gv3 in opt2.Items)
                    {
                        TextBox txt = (TextBox)gv3.FindControl(strId);

                        if (txt != null)
                        {
                            strValue = txt.Text;
                            break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        return strValue;
    }
    protected void btnprev_Click1(object sender, EventArgs e)
    {
        btnnext.Visible = true;
        getans();
        CurrentPage -= 1;
        BindQuestionListwithsession();
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        btnprev.Visible = true;
        getans();
        CurrentPage += 1;
        BindQuestionListwithsession();
    }

    protected void btnchkAnswer_Click(object sender, EventArgs e)
    {

        int addResult = 0;

        int QuesId = 0;

        HiddenField hdnQUESTYPE = (HiddenField)dlsquestion.Items[0].FindControl("hdnQUESTYPE");
        HiddenField hdnQuestionId = (HiddenField)dlsquestion.Items[0].FindControl("hdnQuestionId");
        HiddenField hdnOptionType = (HiddenField)dlsquestion.Items[0].FindControl("hdnOPTIONTYPE");

        if (hdnQUESTYPE.Value == "Descriptive" || hdnQUESTYPE.Value == "Image Question")
        {

        }
        else  //  code for normal question
        {

            string option = "";
            QuesId = Convert.ToInt16(hdnQuestionId.Value);
            string strOptType = hdnOptionType.Value;

            string strVal = "";
            string CtrlId = "";
            if (strOptType == "")
            {
                CtrlId = "txt" + QuesId;

            }
            else if (strOptType == "Radio Button")
            {
                CtrlId = "opt" + QuesId;

            }
            else if (strOptType == "Check Box List")
            {
                CtrlId = "chk" + QuesId;
                option = "chk";
            }
            strVal = fngetValueofCtrl(CtrlId, strOptType);

            if (strVal != "" && option == "")
            {
                string correctans = CheckCorrectAnsText(QuesId);
                if (strVal == correctans)
                {
                    lblAnsMsg.Text = "<b>Thank You, This is Correct Answer</b>";
                }
                else
                {
                    lblAnsMsg.Text = "<b>Wrong Answer -</b> Correct Answer is "+correctans ;
                }
            }
            else if (strVal != "")
            {


            }
        }

        BindQuestionListwithsession();
    }


    protected void btnEndExam_Click(object sender, EventArgs e)
    {
        try
        {
            getans();
            //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>ReadingChapter('"+ hdnUnitid.Value + "','"+ hdnChapter.Value + "'); </script>");
            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>window.parent.ReadingChapter('" + hdnChapter.Value + "'); </script>");
        }
        catch (Exception exx)
        {
        }
        finally
        {
            try
            {
                if (File.Exists(Server.MapPath(hdnFileName.Value)))
                {
                    File.Delete(Server.MapPath(hdnFileName.Value));

                }
            }
            catch (Exception ex)
            {

            }
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
    }
    protected void BindQuestionListwithsession()
    {
        try
        {

            DataSet ds = this.XMLDeSerializeMyBasicCObject(Server.MapPath(hdnFileName.Value));

            
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = ds.Tables[0].DefaultView;
            objPds.AllowPaging = true;
            objPds.PageSize = 1;

            objPds.CurrentPageIndex = CurrentPage;
            //Session["backsearchpage"] = CurrentPage;
            btnprev.Visible = !objPds.IsFirstPage;
            btnnext.Visible = !objPds.IsLastPage;
            // 10 nov 2009 EndExam button visible on last page
            btnEndExam.Visible = objPds.IsLastPage;

            dlsquestion.DataSource = objPds;
            dlsquestion.DataBind();

            

            int pgno = Convert.ToInt32(CurrentPage) + 1;
           // lblqueno.Text = " " + pgno + " of " + ds.Tables[0].Rows.Count;

            if (dlsquestion.Items.Count == 0)
            {
                tbl.Visible = false;
            }
            if (dlsquestion.Items.Count == 0)
            {
                tbl.Visible = true;
            }
           
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    private DataSet XMLDeSerializeMyBasicCObject(string FileName)
    {
        DataSet ds = new DataSet();
        try
        {
            // Read the file back into a stream
            using (Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                // Now create a binary formatter
                XmlSerializer xmlserializer = new XmlSerializer(typeof(DataSet));

                // Deserialize the object and use it
                ds = (DataSet)xmlserializer.Deserialize(stream);
                // Cleanup
                stream.Close();
            }
        }
        catch (Exception ex)
        {
        }

        return ds;

    }
    public int CurrentPage
    {
        get
        {
            object o = this.ViewState["_CurrentPage"];
            //object o = page;
            if (o == null)
                return 0;	// default to showing the first page
            else
                return (int)o;
        }
        set
        {
            this.ViewState["_CurrentPage"] = value;
        }

    }

    private void XMLSerializeMyBasicCObject(string FileName, DataSet ds)
    {
        try
        {
            // Initialize a storage medium to hold the serialized object
            using (Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(DataSet));
                xmlserializer.Serialize(stream, ds);
                stream.Close();
            }
        }
        catch (Exception ex)
        {
        }
    }

    [WebMethod]
    public static string CallReadingChapter(string UnitId, string ChapterID)
    {


        int rtVal = 0;
        try
        {
            int addResult = 0;
            Chapter objLibExam = new Chapter();
            DALChapter OBJDALExam = new DALChapter();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.UnitID = Convert.ToInt32(UnitId);
            objLibExam.ChapterID = ChapterID;
            objLibExam.UserId = HttpContext.Current.Session["username"].ToString();

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddUpdateChapterReading(tp);

            if (addResult > 0)
            {
                rtVal = addResult;
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return rtVal.ToString();

    }
}