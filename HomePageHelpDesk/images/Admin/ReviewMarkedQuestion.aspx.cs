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
public partial class SubmitExam : System.Web.UI.Page
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

            //if (!Page.IsPostBack)
            //{
            //    if (Request.QueryString.Count > 0)
            //    {

                    hdnExamId.Value = Request.QueryString["ExamID"].ToString();

                    BindQuestionList();
            


            //    }


            //}
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
    }

    protected DataSet BindQuestionOptionList(int QuestionId)
    {
        DataSet dss = new DataSet();
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.QuestionId = QuestionId;
            tp.MessagePacket = (object)objLIBExam;

            dss = objDalExam.GetQuestionOptionList2(tp);
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

    protected void BindQuestionList()
    {
        try
        {
            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value);
            objLIBExam.UserId = Session["username"].ToString();

            tp.MessagePacket = (object)objLIBExam;
            ds = objDalExam.GetMarkedQuestionList(tp);
            //objLibExamListing = (LIBExamListing)tp.MessageResultset;
            gvQuestionList.DataSource = ds;
            gvQuestionList.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
   
    protected void gvQuestionList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            string anstext;
            GridViewRow row = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                HiddenField hdnQuestionId = (HiddenField)e.Row.FindControl("hdnQuestionId");
                HiddenField hdnQUESTYPE = (HiddenField)e.Row.FindControl("hdnQUESTYPE");
                Panel panel = (Panel)e.Row.FindControl("panel");
                Panel panel1 = (Panel)e.Row.FindControl("panel1");
                LIBExam objLIBExam = new LIBExam();
                DALExam objDalExam = new DALExam();
                LIBExamListing objLibExamListing = new LIBExamListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                tp.MessagePacket = (object)objLIBExam;

                tp = objDalExam.GetQuestionOptionListByOptionType(tp);
                objLibExamListing = (LIBExamListing)tp.MessageResultset;
                string strOptType = objLibExamListing[0].OPTIONTYPE;

                // bind value in sub grid for case study

                if (hdnQUESTYPE.Value == "Case Study")
                {
                    GridView gv = new GridView();
                    gv = (GridView)row.FindControl("gvSubQuestionList");
                    try
                    {
                        LIBExam objLIBExam2 = new LIBExam();
                        DALExam objDalExam2 = new DALExam();
                        LIBExamListing objLibExamListing2 = new LIBExamListing();
                        TransportationPacket tp2 = new TransportationPacket();
                        objLIBExam2.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionId.Value));
                        tp2.MessagePacket = (object)objLIBExam;
                        tp = objDalExam2.GetSubQuestionList(tp2);
                        objLibExamListing2 = (LIBExamListing)tp.MessageResultset;
                        gv.DataSource = objLibExamListing2;
                        gv.DataBind();

                    }
                    catch (Exception ex)
                    {
                        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                    }

                }

                else if (hdnQUESTYPE.Value == "Descriptive")
                {

                    FileUpload fileup = new FileUpload();
                    Label lblHeading = new Label();
                    lblHeading.Text = "Upload File";
                    
                    fileup.ID = ("flu" + Convert.ToInt32(hdnQuestionId.Value));
                    fileup.Width = 200;
                    fileup.Height = 20;
                    TextBox txtb = new TextBox();
                    txtb.ID = ("txt" + Convert.ToInt32(hdnQuestionId.Value));
                    txtb.Width = 200;
                    txtb.Height = 20;
                    panel.Controls.Add(txtb);
                   
                    panel1.Controls.Add(lblHeading);
                    panel1.Controls.Add(fileup);
                    anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                    txtb.Text = anstext;
                  
                    //panel.Controls.Add(lbl);
                    //panel.Controls.Add(btnupload);

                }
               

              


                else
                {
                    //create dynamic control in grid view
                    if (strOptType == "Radio Button")
                    {

                        try
                        {
                            LIBExam objLIBExam1 = new LIBExam();
                            DALExam objDalExam1 = new DALExam();
                            LIBExamListing objLibExamListing1 = new LIBExamListing();
                            TransportationPacket tp1 = new TransportationPacket();
                            objLIBExam1.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                            tp1.MessagePacket = (object)objLIBExam1;

                            tp1 = objDalExam1.GetQuestionOptionListByOptionTypeAll(tp);
                            objLibExamListing1 = (LIBExamListing)tp.MessageResultset;
                            RadioButtonList rd = new RadioButtonList();
                            rd.ID = ("opt" + Convert.ToInt32(hdnQuestionId.Value));
                            rd.Width = 200;
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
                            DALExam objDalExam1 = new DALExam();
                            LIBExamListing objLibExamListing1 = new LIBExamListing();
                            TransportationPacket tp1 = new TransportationPacket();
                            objLIBExam1.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                            tp1.MessagePacket = (object)objLIBExam1;

                            tp1 = objDalExam1.GetQuestionOptionListByOptionTypeAll(tp);
                            objLibExamListing1 = (LIBExamListing)tp.MessageResultset;
                            CheckBoxList chk = new CheckBoxList();
                            chk.ID = ("chk" + Convert.ToInt32(hdnQuestionId.Value));
                            chk.Width = 200;
                            chk.RepeatDirection = RepeatDirection.Vertical;
                            chk.RepeatLayout = RepeatLayout.Flow;
                            chk.DataSource = objLibExamListing1;
                            chk.DataTextField = objLIBExam1.OPTIONSDisplayText;
                            chk.DataValueField = objLIBExam1.OPTIONSValueField;
                            chk.DataBind();

                            panel.Controls.Add(chk);
                            anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                            chk.Items.FindByText(anstext).Selected = true;

                        }
                        catch (Exception ex)
                        {
                            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                        }
                    }

                    else //if (strOptType == "TextBox")
                    {
                        TextBox txtb = new TextBox();
                        txtb.ID = ("txt" + Convert.ToInt32(hdnQuestionId.Value));
                        txtb.Width = 200;
                        txtb.Height = 20;
                        panel.Controls.Add(txtb);

                        anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                        txtb.Text = anstext;

                    }
                }
                  
                }
          
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void gvSubQuestionList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string anstext;
            GridViewRow row = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnQuestionId = (HiddenField)e.Row.FindControl("hdnSubQuestionId");
               
                Panel panel = (Panel)e.Row.FindControl("panel");

                LIBExam objLIBExam = new LIBExam();
                DALExam objDalExam = new DALExam();
                LIBExamListing objLibExamListing = new LIBExamListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBExam.SubQuestionId = Convert.ToInt32(hdnQuestionId.Value);
                tp.MessagePacket = (object)objLIBExam;

                tp = objDalExam.GetSubQuestionOptionListByOptionType(tp);
                objLibExamListing = (LIBExamListing)tp.MessageResultset;
                string strOptType = objLibExamListing[0].OPTIONTYPE;

              
                   // create dynamic control in grid view
                    if (strOptType == "Radio Button")
                    {

                        try
                        {
                            LIBExam objLIBExam1 = new LIBExam();
                            DALExam objDalExam1 = new DALExam();
                            LIBExamListing objLibExamListing1 = new LIBExamListing();
                            TransportationPacket tp1 = new TransportationPacket();
                            objLIBExam1.SubQuestionId = Convert.ToInt32(hdnQuestionId.Value);
                            tp1.MessagePacket = (object)objLIBExam1;

                            tp1 = objDalExam1.GetSubQuestionOptionListByOptionTypeAll(tp);
                            objLibExamListing1 = (LIBExamListing)tp.MessageResultset;
                            RadioButtonList rd = new RadioButtonList();
                            rd.ID = ("opt" +"_"+ Convert.ToInt32(hdnQuestionId.Value));
                            rd.Width = 200;
                            rd.RepeatDirection = RepeatDirection.Vertical;
                            rd.RepeatLayout = RepeatLayout.Flow;
                            rd.DataSource = objLibExamListing1;
                            rd.DataTextField = objLIBExam1.OPTIONSDisplayText;
                            rd.DataValueField = objLIBExam1.OPTIONSValueField;
                            rd.DataBind();
                            panel.Controls.Add(rd);
                            anstext = BindsubAnsText(Convert.ToInt32(hdnQuestionId.Value));
                            rd.Items.FindByText(anstext).Selected = true;
                        }
                        catch (Exception ex)
                        {
                            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                        }
                    }
                    else //if (strOptType == "TextBox")
                    {
                        TextBox txtb = new TextBox();
                        txtb.ID = ("txt" +"_" +Convert.ToInt32(hdnQuestionId.Value));
                        txtb.Width = 200;
                        txtb.Height = 20;
                        panel.Controls.Add(txtb);
                        anstext = BindsubAnsText(Convert.ToInt32(hdnQuestionId.Value));
                        txtb.Text = anstext;
                    }
               

            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void gvDisplayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            // submit answer in data base of question
            int addResult = 0;



            int QuesId = 0;

            GridView gvRef = (GridView)sender;


            // fatch value frim inner grid view
            //GridView opt2 = (GridView)gvRef.Rows[0].FindControl("gvSubQuestionList");

            //HiddenField hdnSubQuestionId = (HiddenField)opt2.Rows[0].FindControl("hdnSubQuestionId");
            HiddenField hdnQUESTYPE = (HiddenField)gvRef.Rows[0].FindControl("hdnQUESTYPE");
            HiddenField hdnQuestionId = (HiddenField)gvRef.Rows[0].FindControl("hdnQuestionId");
            HiddenField hdnOptionType = (HiddenField)gvRef.Rows[0].FindControl("hdnOPTIONTYPE");
            if (hdnQUESTYPE.Value == "Case Study") // code for case study data submit
            {



                DALExam objDalExam = new DALExam();
                DataSet ds = new DataSet();

                ds = objDalExam.GetSubQuestionListByExamId((Convert.ToInt16(hdnQuestionId.Value)));

                if (ds != null)
                {
                    if (ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows != null)
                        {
                            int NOS = 0;
                            //int QuesId = 0;

                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {

                                if (QuesId != Convert.ToInt16(ds.Tables[0].Rows[j]["SubQuestionId"]))
                                {
                                    QuesId = Convert.ToInt16(ds.Tables[0].Rows[j]["SubQuestionId"]);
                                    NOS = 1;
                                }
                                else
                                {
                                    NOS = 0;
                                }
                                if (NOS == 1)
                                {
                                    QuesId = Convert.ToInt16(ds.Tables[0].Rows[j]["SubQuestionId"]);


                                    string strOptType = ds.Tables[0].Rows[j]["OptionType"].ToString();
                                    string strVal = "";
                                    string CtrlId = "";
                                    if (strOptType == "")
                                    {
                                        CtrlId = "txt" + "_" + QuesId;

                                    }
                                    else
                                    {
                                        CtrlId = ds.Tables[0].Rows[j]["CtrlId"].ToString();

                                    }
                                    strVal = fngetValueofCtrl2(CtrlId, strOptType);

                                    if (strVal != "")
                                    {
                                        LIBExam objLibExam = new LIBExam();
                                        DALExam OBJDALExam = new DALExam();
                                        TransportationPacket tp = new TransportationPacket();
                                        objLibExam.UserId = Session["username"].ToString();
                                        objLibExam.AnsText = strVal;

                                        objLibExam.SubQuestionId = QuesId;

                                        objLibExam.ExamId = Convert.ToInt32(hdnExamId.Value);
                                        tp.MessagePacket = (object)objLibExam;

                                        addResult = OBJDALExam.SubmitSubExamAns(tp);
                                    }

                                }
                            }
                        }

                    }

                }



            }
            //else if (hdnQUESTYPE.Value == "Descriptive")
            //{
            //    string fileup = "flu" + Convert.ToInt32(hdnQuestionId.Value);
            //    if (fileup.PostedFile != null)
            //    {
            //        try
            //        {





            //            hdnRealImagUrl.Value = sCopyRealPath + RealFile;




            //        }
            //        catch (Exception ex)
            //        {
            //        }
            //    }





            //}

            else  //  code for normal question
            {


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

                }
                strVal = fngetValueofCtrl(CtrlId, strOptType);

                if (strVal != "")
                {
                    LIBExam objLibExam = new LIBExam();
                    DALExam OBJDALExam = new DALExam();
                    TransportationPacket tp = new TransportationPacket();
                    objLibExam.UserId = Session["username"].ToString();
                    objLibExam.AnsText = strVal;
                    
                        objLibExam.Review = true;
                   
                        
                    
                    objLibExam.QuestionId = QuesId;

                    objLibExam.ExamId = Convert.ToInt32(hdnExamId.Value);
                    tp.MessagePacket = (object)objLibExam;

                    addResult = OBJDALExam.SubmitExamAns(tp);
                }




            }




            gvQuestionList.PageIndex = e.NewPageIndex;
            BindQuestionList();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        int addResult = 0;
       
        try
        {
            DALExam objDalExam = new DALExam();
            DataSet ds = new DataSet();

            ds = objDalExam.GetQuestionListByExamId(Request.QueryString["ExamID"].ToString());

            if (ds != null)
            {
                if (ds.Tables != null)
                {
                    if (ds.Tables[0].Rows != null)
                    {
                        int NOS = 0;
                        int QuesId = 0;

                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {

                            if (QuesId != Convert.ToInt16(ds.Tables[0].Rows[j]["QuestionId"]))
                            {
                                QuesId = Convert.ToInt16(ds.Tables[0].Rows[j]["QuestionId"]);
                                NOS = 1;
                            }
                            else
                            {
                                NOS = 0;
                            }
                            if (NOS == 1)
                            {
                                QuesId = Convert.ToInt16(ds.Tables[0].Rows[j]["QuestionId"]);


                                string strOptType = ds.Tables[0].Rows[j]["OptionType"].ToString();
                                string strVal = "";
                                string CtrlId = "";
                                if (strOptType == "")
                                {
                                    CtrlId = "txt" + QuesId;

                                }
                                else
                                {
                                    CtrlId = ds.Tables[0].Rows[j]["CtrlId"].ToString();

                                }
                                strVal = fngetValueofCtrl(CtrlId, strOptType);

                                try
                                {
                                    LIBExam objLibExam = new LIBExam();
                                    DALExam OBJDALExam = new DALExam();
                                    TransportationPacket tp = new TransportationPacket();
                                    objLibExam.UserId = Session["username"].ToString();
                                    objLibExam.AnsText = strVal;

                                    objLibExam.QuestionId = QuesId;

                                    objLibExam.ExamId = Convert.ToInt32(hdnExamId.Value);
                                    tp.MessagePacket = (object)objLibExam;

                                    addResult = OBJDALExam.SubmitExamAns(tp);
                                }
                                catch (Exception ex)
                                {
                                    HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                                }
                                //Response.Write("ID : " + CtrlId + " , Value : " + strVal + "<BR>");
                            }
                        }
                    }
                    
                }
            }
            if (addResult > 0)
            {
                Uri ur = Request.Url;
                string AbsoluteURL = ur.AbsoluteUri.Replace("SubmitExam.aspx", "SelectExam.aspx");

                ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert(' Exam Submitted Successfully'); location.href='" + AbsoluteURL + "';</script>");



            }


            else
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Failed to save Exam'); </script>");

            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected string fngetValueofCtrl(string strId, string strOptType)
    {
        string strValue = "";
        try
        {
            foreach (GridViewRow gv in gvQuestionList.Rows)
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
                                strValue = chk.Items[i].Text;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    TextBox txt = (TextBox)gv.FindControl(strId);

                    if (txt != null)
                    {
                        strValue = txt.Text;
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
            foreach (GridViewRow gv in gvQuestionList.Rows)
            {
                // fatch value frim inner grid view
                GridView opt2 = (GridView)gv.FindControl("gvSubQuestionList");

                if (strOptType == "Radio Button")
                {
                    foreach (GridViewRow gv2 in opt2.Rows)
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
                    foreach (GridViewRow gv3 in opt2.Rows)
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

    protected string BindAnsText( int questionid)
    {
        string addResult = "";
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value);
            objLIBExam.UserId = Session["username"].ToString();
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
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value);
            objLIBExam.UserId = Session["username"].ToString();
            objLIBExam.SubQuestionId = Subquestionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetSubQuestionAnsText(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            if (objLibExamListing != null)
            {

                if (objLibExamListing.Count > 0)
                {


                    addResult = objLibExamListing[0].AnsText;
                }
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return addResult;

    }
}
