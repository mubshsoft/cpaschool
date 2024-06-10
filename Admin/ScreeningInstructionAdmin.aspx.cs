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

public partial class Admin_ScreeningInstructionAdmin : System.Web.UI.Page
{
    int NOS = 0;
    string strHeading = "";
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
                hdnScrId.Value = Request.QueryString["ScrId"].ToString();
                BindInstructionList();
                hdnuserid.Value = Request.QueryString["uid"].ToString();

                String strGrandQ;
                String strGrand = "";
                String strGrandTotal = "";
                strGrandQ = "select categoryname from Screening_category where Scrid=" + Request.QueryString["ScrId"].ToString();
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
              
                ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');");
                //lblDate.Text =Convert.ToString(Session["date"]);
                // export();
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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId= Convert.ToInt32(hdnScrId.Value.ToString());
            objLIBScreening.StudentEmail = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBScreening;

            tp = objDalScreening.GetScreeningInstruction(tp);

            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;

            if (objLibScreeningListing != null)
            {
                if (objLibScreeningListing.Count > 0)
                {
                    lblCourseName.Text = objLibScreeningListing[0].CourseTitle;
                    lblCourseCode.Text = objLibScreeningListing[0].CourseCode;
                    lblScreeningCode.Text = objLibScreeningListing[0].Screeningcode;
                    //lblPaperName.Text = objLibScreeningListing[0].PaperTitle;
                }
            }

            tp = objDalScreening.GetStudenInfo(tp);

            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;

            if (objLibScreeningListing != null)
            {
                try
                {
                    if (objLibScreeningListing.Count > 0)
                    {
                        //DataTable dtEx = new DataTable();
                        //dtEx = objDalScreening.getdata("select refrenceid from studentregcourse where stid=" + objLibScreeningListing[0].Stid.ToString() + " and courseid in(select courseid from Screeningset where Screeningid=" + hdnScreeningId.Value + ")");
                        //lblStid.Text = dtEx.Rows[0]["refrenceid"].ToString();

                        //lblStid.Text = objLibScreeningListing[0].Stid.ToString();
                        //lblStudentName.Text = objLibScreeningListing[0].StudentName;

                    }
                }
                catch (Exception ex)
                { }
            }
            DataTable dt = new DataTable();
            dt = objDalScreening.getdata("select TimeAllowted from ScreeningSet where ScrId=" + Request.QueryString["ScrId"].ToString());
            lblTimeAlloted.Text = (Convert.ToInt32(dt.Rows[0]["TimeAllowted"].ToString()) / 60).ToString() + " min";


            DataTable dt1 = new DataTable();
            dt1 = objDalScreening.getdata("select firstname + ' ' + lastname as name from application where email='" + Request.QueryString["uid"].ToString() + "'");
            lblStudentName.Text = dt1.Rows[0]["name"].ToString();

            DataTable dt3 = new DataTable();
            dt3 = objDalScreening.getdata("select ActivateDate,EndScreeningtime from studentActiveScreening where ScrId=" + Request.QueryString["ScrId"].ToString() + " and  UserId='" + Request.QueryString["uid"].ToString() + "'");
            DateTime date1;
            DateTime date2;
            date1 = Convert.ToDateTime(dt3.Rows[0]["ActivateDate"].ToString());
            
            string st = dt3.Rows[0]["EndScreeningtime"].ToString();
            try
            {
                date2 = Convert.ToDateTime(dt3.Rows[0]["EndScreeningtime"]);

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
            //Code by mala
            lblDate.Text = date1.Date.ToShortDateString();

            DataSet ds = new DataSet();
            ds = objDalScreening.GetInstructionSummary(tp);

            //objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            dlstInstructionSummary.DataSource = ds;
            dlstInstructionSummary.DataBind();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

      protected void btnStartScreening_Click(object sender, ImageClickEventArgs e)
    {
        int intScreeningiD;
        try
        {
            intScreeningiD = Convert.ToInt32(hdnScrId.Value);
            string strQScreening;
            strQScreening = "update studentActiveScreening set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where Screeningid=" + intScreeningiD + "and userid='" + Session["username"] + "'";
            CLS_C.fnExecuteQuery(strQScreening);
        }
        catch (Exception ex)
        {
        }

        Response.Redirect("SubmitScreening.aspx?ScreeningID=" + hdnScrId.Value + "&review=0");
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
        ////LstUserScreeninginfo.RenderControl(hw) 
        //Response.Output.Write(sw.ToString());

        //Response.Flush();

        //Response.End(); 
    }

    protected void GetUserList()
    {

        try
        {
            DataSet ds = new DataSet();
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.UserId = (hdnuserid.Value.ToString());
            objLIBScreening.ScrId= Convert.ToInt32(hdnScrId.Value);

            tp.MessagePacket = (object)objLIBScreening;

            ds = objDalScreening.GetSubmiitedScreeningByUserId(tp);

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
                Label hdnQUESTYPE = (Label)dlstanswers.Items[i].FindControl("hdnquestype");
                Label hdnQUESID = (Label)dlstanswers.Items[i].FindControl("hdnquesid");
                Label Label2 = (Label)dlstanswers.Items[i].FindControl("Label2");
                Label Label1 = (Label)dlstanswers.Items[i].FindControl("Label1");
                HtmlTableRow tr1 = (HtmlTableRow)dlstanswers.Items[i].FindControl("trRow1");
                HtmlTableRow tr2 = (HtmlTableRow)dlstanswers.Items[i].FindControl("trRow2");
                HtmlTableRow tr3 = (HtmlTableRow)dlstanswers.Items[i].FindControl("trRow3");
                HtmlTableRow trLineMain = (HtmlTableRow)dlstanswers.Items[i].FindControl("trLineMain");
                HtmlTableRow trLineSub = (HtmlTableRow)dlstanswers.Items[i].FindControl("trLineSub");
                Image imgUpload = (Image)dlstanswers.Items[i].FindControl("imgUploadImage");
                HtmlTableRow trimage = (HtmlTableRow)dlstanswers.Items[i].FindControl("trImage");
                Label lblanstext = (Label)dlstanswers.Items[i].FindControl("lblanstext");
                //wahid
                lblanstext.Text.Replace("<br>", "\r\n");
                DataList gv = new DataList();
                gv = (DataList)dlstanswers.Items[i].FindControl("dlstSubanswers");
                if (hdnQUESTYPE.Text == "Objective")
                {
                    lblcorectanswers.Visible = true;
                    //Label2.Visible = false;
                    tr1.Visible = false;
                    tr2.Visible = false;
                }
                else
                {
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
                        LIBScreening objLIBScreening = new LIBScreening();
                        DALScreening objDalScreening = new DALScreening();
                        LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
                        TransportationPacket tp = new TransportationPacket();
                        objLIBScreening.UserId = (hdnuserid.Value.ToString());
                        objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                        objLIBScreening.QuestionId = Convert.ToInt32(hdnQUESID.Text);
                        tp.MessagePacket = (object)objLIBScreening;

                        ds = objDalScreening.GetSubmiitedCaseStudyScreeningByUserId(tp);

                        gv.DataSource = ds;
                        gv.DataBind();
                        lblcorectanswers.Visible = false;
                        tr1.Visible = false;
                        tr2.Visible = false;
                        tr3.Visible = false;
                        Label1.Visible = false;
                        int countPre = ds.Tables[0].Rows.Count - 1;
                        if (ds.Tables[0].Rows.Count > 1)
                        {
                            trLineMain.Visible = true;
                            trLineSub.Visible = false;
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
                        DALScreening objDalScreening = new DALScreening();
                        trimage.Visible = true;
                        DataTable dtEx = new DataTable();
                        dtEx = objDalScreening.getdata("select uploadquestionimagepath from Screeningquestions where questionid=" + hdnQUESID.Text);
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
    //protected string ShowOrHideRow(string theText)
    //{
    //    if (string.IsNullOrEmpty(theText))
    //    {
    //        return ("style='display:none'");
    //    }
    //    else
    //    {
    //        return ("style='display:'");
    //    }
    //} 
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImgBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AdminListScreeningSet.aspx?ScrId=" + Request.QueryString["ScrId"] + "&cid=" + Request.QueryString["cid"]);
    }
}
