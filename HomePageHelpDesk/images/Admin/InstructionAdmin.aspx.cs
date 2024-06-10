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

public partial class InstructionAdmin : System.Web.UI.Page
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
                hdnExamId.Value = Request.QueryString["exid"].ToString();
               
                hdnuserid.Value  = Request.QueryString["uid"].ToString();
                BindInstructionList();
                String strGrandQ;
                String strGrand="";
                 String strGrandTotal="";
                strGrandQ = "select categoryname from exam_category where examid=" + Request.QueryString["exid"].ToString();
                DataSet dsGrand= new DataSet() ;
                dsGrand=CLS_C.fnQuerySelectDs(strGrandQ);
                int i;
                for (i = 0; i < dsGrand.Tables[0].Rows.Count;i++ )
                {
                    strGrand = strGrand + dsGrand.Tables[0].Rows[i][0].ToString() + " + ";
                }
                strGrandTotal=strGrand.Remove(strGrand.Length-2);
                strGrandTotal = strGrandTotal.Replace("Section", "");
                lblGrand.Text = "(" + "Section " + strGrandTotal + ")";
                GetUserList();
                bindsection();
                BindExamDate();
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
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value.ToString());
            objLIBExam.StudentEmail = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetExamInstruction(tp);

            objLibExamListing = (LIBExamListing)tp.MessageResultset;

            if (objLibExamListing != null)
            {
                if (objLibExamListing.Count > 0)
                {
                    lblCourseName.Text = objLibExamListing[0].CourseTitle;
                    lblCourseCode.Text = objLibExamListing[0].CourseCode;
                    lblExamCode.Text = objLibExamListing[0].examcode;
                    lblPaperName.Text = objLibExamListing[0].PaperTitle;
                }
            }

            tp = objDalExam.GetStudenInfo(tp);

            objLibExamListing = (LIBExamListing)tp.MessageResultset;

            if (objLibExamListing != null)
            {
                try
                {
                    if (objLibExamListing.Count > 0)
                    {
                        DataTable dtEx = new DataTable();
                        dtEx = objDalExam.getdata("select refrenceid from studentregcourse where stid=" + objLibExamListing[0].Stid.ToString() + " and courseid in(select courseid from examset where examid=" + hdnExamId.Value + ")");
                        lblStid.Text = dtEx.Rows[0]["refrenceid"].ToString();

                        //lblStid.Text = objLibExamListing[0].Stid.ToString();
                        //lblStudentName.Text = objLibExamListing[0].StudentName;

                    }
                }
                catch (Exception ex)
                { }
            }
            DataTable dt = new DataTable();
            dt = objDalExam.getdata("select TimeAllowted from ExamSet where ExamId=" + Request.QueryString["exid"].ToString());
            lblTimeAlloted.Text = (Convert.ToInt32(dt.Rows[0]["TimeAllowted"].ToString()) / 60).ToString() + " min";


            DataTable dt1 = new DataTable();
            dt1 = objDalExam.getdata("select firstname + ' ' + lastname as name from student where email='" + Request.QueryString["uid"].ToString() + "'");
            lblStudentName.Text = dt1.Rows[0]["name"].ToString();

            DataTable dt3 = new DataTable();
            dt3 = objDalExam.getdata("select ActivateDate,EndExamtime from studentActiveExam where ExamId=" + Request.QueryString["exid"].ToString() + " and  UserId='" + Request.QueryString["uid"].ToString() + "'");
            DateTime date1;
            DateTime date2;
            date1 = Convert.ToDateTime(dt3.Rows[0]["ActivateDate"].ToString());
            string st = dt3.Rows[0]["EndExamtime"].ToString();
            try
            {
                date2 = Convert.ToDateTime(dt3.Rows[0]["EndExamtime"]);
                
            }
            catch(Exception ex)
            {
                date2 = Convert.ToDateTime(dt3.Rows[0]["ActivateDate"].ToString());
            }

            TimeSpan difference = date2.Subtract(date1);

            double totalSeconds = difference.Seconds;
            double totalMinuts = difference.Minutes;
            lblTimeTaken.Text = totalMinuts.ToString() + ":" + totalSeconds.ToString() + " min";



            //lblDate.Text = DateTime.Now.ToShortDateString();
            DataSet ds = new DataSet();
            ds = objDalExam.GetInstructionSummary(tp);

            //objLibExamListing = (LIBExamListing)tp.MessageResultset;
            dlstInstructionSummary.DataSource = ds;
            dlstInstructionSummary.DataBind();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    protected void BindExamDate()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value.ToString());
            objLIBExam.UserId = (Request.QueryString["uid"].ToString());
            tp.MessagePacket = (object)objLIBExam;

            tp = objDalExam.GetExamDate(tp);

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

    


   
    protected void btnStartExam_Click(object sender, ImageClickEventArgs e)
    {
        int intExamiD;
        try
        {
            intExamiD = Convert.ToInt32(hdnExamId.Value);
            string strQExam;
            strQExam = "update studentActiveExam set Activate=1,ActivateDate='" + DateTime.Now.Date.ToString() + "' where examid=" + intExamiD + "and userid='" + Session["username"] + "'";
            CLS_C.fnExecuteQuery(strQExam);
        }
        catch (Exception ex)
        {
        }

        Response.Redirect("SubmitExam.aspx?ExamID=" + hdnExamId.Value + "&review=0");
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
        ////LstUserExaminfo.RenderControl(hw) 
        //Response.Output.Write(sw.ToString());

        //Response.Flush();

        //Response.End(); 
    }
    
    protected void GetUserList()
    {

        try
        {
            DataSet ds = new DataSet();
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.UserId = (hdnuserid.Value.ToString());
            objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value );

            tp.MessagePacket = (object)objLIBExam;

            ds = objDalExam.GetSubmiitedExamByUserId(tp);

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
              
                //wahid
                lblanstext.Text.Replace("<br>", "\r\n");
               

                DataList gv = new DataList();
                gv = (DataList)dlstanswers.Items[i].FindControl("dlstSubanswers");
                if (hdnQUESTYPE.Text == "Objective")
                {
                    if ( lblanstext.Text.Replace("\t", "") == lblcorectanswerstext.Text)
                    {
                        totalObjectiveMarks = totalObjectiveMarks + Convert.ToInt32(lblmaxmarks.Text);
                        lblMarkscored.Text = lblmaxmarks.Text;
                    }
                    else
                    {
                        lblMarkscored.Text = "0";
                    }

                    //totalObjectiveMarks
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
                        LIBExam objLIBExam = new LIBExam();
                        DALExam objDalExam = new DALExam();
                        LIBExamListing objLibExamListing = new LIBExamListing();
                        TransportationPacket tp = new TransportationPacket();
                        objLIBExam.UserId = (hdnuserid.Value.ToString());
                        objLIBExam.ExamId = Convert.ToInt32(hdnExamId.Value);
                        objLIBExam.QuestionId = Convert.ToInt32(hdnQUESID.Text);
                        tp.MessagePacket = (object)objLIBExam;

                        ds = objDalExam.GetSubmiitedCaseStudyExamByUserId(tp);

                        gv.DataSource = ds;
                        gv.DataBind();
                        lblcorectanswers.Visible = false;
                        tr1.Visible = false;
                        tr2.Visible = false;
                        tr3.Visible = false;
                        Label1.Visible = false;
                        int countPre = ds.Tables[0].Rows.Count-1;
                        if(ds.Tables[0].Rows.Count > 1)
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
                        DALExam objDalExam = new DALExam();
                        trimage.Visible = true;
                        DataTable dtEx = new DataTable();
                        dtEx = objDalExam.getdata("select uploadquestionimagepath from questions where questionid=" + hdnQUESID.Text);
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
            Label lbltotalObjmarks = (Label) dlstInstructionSummary.Items[0].FindControl("lbltotalObjmarks");
            lbltotalObjmarks.Text = Convert.ToString(totalObjectiveMarks);
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


    protected void dlstInstructionSummary_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            // string anstext;
            DataListItem row = e.Item;
            //if (e.Item.ItemType == ListItemType.Item)
            //{
                //Label lblSummaryCategoryName = (Label)e.Item.FindControl("lblSummaryCategoryName");
                //Label lbltotalObjmarks = (Label)e.Item.FindControl("lbltotalObjmarks");
                //lbltotalObjmarks.Text = Convert.ToString(totalObjectiveMarks);
            //}
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
    protected void ImageButton1_Click(object sender, EventArgs e)
    {

    }
    protected void ImgBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminListExamSets.aspx?batchid=" + Request.QueryString["Batchid"] + "&exid=" + Request.QueryString["exid"]); 
    }
    //added by chhaya 3 march 2015
    protected void imgFileOpenLink(object sender, EventArgs e)
    {
        try
        {
            LinkButton objLinkBtn = (LinkButton)sender;


            bool forceDownload = true;
            string path = (objLinkBtn.CommandArgument.ToString());
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);

            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                type = GetMimeType(ext);
            }
            if (forceDownload)
            {
                Response.AppendHeader("content-disposition",
                    "attachment; filename=" + name);
            }
            if (type != "")
            {
                Response.ContentType = type;
                Response.WriteFile(path);
                Response.End();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    public static string GetMimeType(string extension)
    {
        if (extension == null)
            throw new ArgumentNullException("extension");

        if (extension.StartsWith("."))
            extension = extension.Substring(1);


        switch (extension.ToLower())
        {
            #region Big freaking list of mime types
            case "323": return "text/h323";
            case "3g2": return "video/3gpp2";
            case "3gp": return "video/3gpp";
            case "3gp2": return "video/3gpp2";
            case "3gpp": return "video/3gpp";
            case "7z": return "application/x-7z-compressed";
            case "aa": return "audio/audible";
            case "aac": return "audio/aac";
            case "aaf": return "application/octet-stream";
            case "aax": return "audio/vnd.audible.aax";
            case "ac3": return "audio/ac3";
            case "aca": return "application/octet-stream";
            case "accda": return "application/msaccess.addin";
            case "accdb": return "application/msaccess";
            case "accdc": return "application/msaccess.cab";
            case "accde": return "application/msaccess";
            case "accdr": return "application/msaccess.runtime";
            case "accdt": return "application/msaccess";
            case "accdw": return "application/msaccess.webapplication";
            case "accft": return "application/msaccess.ftemplate";
            case "acx": return "application/internet-property-stream";
            case "addin": return "text/xml";
            case "ade": return "application/msaccess";
            case "adobebridge": return "application/x-bridge-url";
            case "adp": return "application/msaccess";
            case "adt": return "audio/vnd.dlna.adts";
            case "adts": return "audio/aac";
            case "afm": return "application/octet-stream";
            case "ai": return "application/postscript";
            case "aif": return "audio/x-aiff";
            case "aifc": return "audio/aiff";
            case "aiff": return "audio/aiff";
            case "air": return "application/vnd.adobe.air-application-installer-package+zip";
            case "amc": return "application/x-mpeg";
            case "application": return "application/x-ms-application";
            case "art": return "image/x-jg";
            case "asa": return "application/xml";
            case "asax": return "application/xml";
            case "ascx": return "application/xml";
            case "asd": return "application/octet-stream";
            case "asf": return "video/x-ms-asf";
            case "ashx": return "application/xml";
            case "asi": return "application/octet-stream";
            case "asm": return "text/plain";
            case "asmx": return "application/xml";
            case "aspx": return "application/xml";
            case "asr": return "video/x-ms-asf";
            case "asx": return "video/x-ms-asf";
            case "atom": return "application/atom+xml";
            case "au": return "audio/basic";
            case "avi": return "video/x-msvideo";
            case "axs": return "application/olescript";
            case "bas": return "text/plain";
            case "bcpio": return "application/x-bcpio";
            case "bin": return "application/octet-stream";
            case "bmp": return "image/bmp";
            case "c": return "text/plain";
            case "cab": return "application/octet-stream";
            case "caf": return "audio/x-caf";
            case "calx": return "application/vnd.ms-office.calx";
            case "cat": return "application/vnd.ms-pki.seccat";
            case "cc": return "text/plain";
            case "cd": return "text/plain";
            case "cdda": return "audio/aiff";
            case "cdf": return "application/x-cdf";
            case "cer": return "application/x-x509-ca-cert";
            case "chm": return "application/octet-stream";
            case "class": return "application/x-java-applet";
            case "clp": return "application/x-msclip";
            case "cmx": return "image/x-cmx";
            case "cnf": return "text/plain";
            case "cod": return "image/cis-cod";
            case "config": return "application/xml";
            case "contact": return "text/x-ms-contact";
            case "coverage": return "application/xml";
            case "cpio": return "application/x-cpio";
            case "cpp": return "text/plain";
            case "crd": return "application/x-mscardfile";
            case "crl": return "application/pkix-crl";
            case "crt": return "application/x-x509-ca-cert";
            case "cs": return "text/plain";
            case "csdproj": return "text/plain";
            case "csh": return "application/x-csh";
            case "csproj": return "text/plain";
            case "css": return "text/css";
            case "csv": return "text/csv";
            case "cur": return "application/octet-stream";
            case "cxx": return "text/plain";
            case "dat": return "application/octet-stream";
            case "datasource": return "application/xml";
            case "dbproj": return "text/plain";
            case "dcr": return "application/x-director";
            case "def": return "text/plain";
            case "deploy": return "application/octet-stream";
            case "der": return "application/x-x509-ca-cert";
            case "dgml": return "application/xml";
            case "dib": return "image/bmp";
            case "dif": return "video/x-dv";
            case "dir": return "application/x-director";
            case "disco": return "text/xml";
            case "dll": return "application/x-msdownload";
            case "dll.config": return "text/xml";
            case "dlm": return "text/dlm";
            case "doc": return "application/msword";
            case "docm": return "application/vnd.ms-word.document.macroenabled.12";
            case "docx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            case "dot": return "application/msword";
            case "dotm": return "application/vnd.ms-word.template.macroenabled.12";
            case "dotx": return "application/vnd.openxmlformats-officedocument.wordprocessingml.template";
            case "dsp": return "application/octet-stream";
            case "dsw": return "text/plain";
            case "dtd": return "text/xml";
            case "dtsconfig": return "text/xml";
            case "dv": return "video/x-dv";
            case "dvi": return "application/x-dvi";
            case "dwf": return "drawing/x-dwf";
            case "dwp": return "application/octet-stream";
            case "dxr": return "application/x-director";
            case "eml": return "message/rfc822";
            case "emz": return "application/octet-stream";
            case "eot": return "application/octet-stream";
            case "eps": return "application/postscript";
            case "etl": return "application/etl";
            case "etx": return "text/x-setext";
            case "evy": return "application/envoy";
            case "exe": return "application/octet-stream";
            case "exe.config": return "text/xml";
            case "fdf": return "application/vnd.fdf";
            case "fif": return "application/fractals";
            case "filters": return "application/xml";
            case "fla": return "application/octet-stream";
            case "flr": return "x-world/x-vrml";
            case "flv": return "video/x-flv";
            case "fsscript": return "application/fsharp-script";
            case "fsx": return "application/fsharp-script";
            case "generictest": return "application/xml";
            case "gif": return "image/gif";
            case "group": return "text/x-ms-group";
            case "gsm": return "audio/x-gsm";
            case "gtar": return "application/x-gtar";
            case "gz": return "application/x-gzip";
            case "h": return "text/plain";
            case "hdf": return "application/x-hdf";
            case "hdml": return "text/x-hdml";
            case "hhc": return "application/x-oleobject";
            case "hhk": return "application/octet-stream";
            case "hhp": return "application/octet-stream";
            case "hlp": return "application/winhlp";
            case "hpp": return "text/plain";
            case "hqx": return "application/mac-binhex40";
            case "hta": return "application/hta";
            case "htc": return "text/x-component";
            case "htm": return "text/html";
            case "html": return "text/html";
            case "htt": return "text/webviewhtml";
            case "hxa": return "application/xml";
            case "hxc": return "application/xml";
            case "hxd": return "application/octet-stream";
            case "hxe": return "application/xml";
            case "hxf": return "application/xml";
            case "hxh": return "application/octet-stream";
            case "hxi": return "application/octet-stream";
            case "hxk": return "application/xml";
            case "hxq": return "application/octet-stream";
            case "hxr": return "application/octet-stream";
            case "hxs": return "application/octet-stream";
            case "hxt": return "text/html";
            case "hxv": return "application/xml";
            case "hxw": return "application/octet-stream";
            case "hxx": return "text/plain";
            case "i": return "text/plain";
            case "ico": return "image/x-icon";
            case "ics": return "application/octet-stream";
            case "idl": return "text/plain";
            case "ief": return "image/ief";
            case "iii": return "application/x-iphone";
            case "inc": return "text/plain";
            case "inf": return "application/octet-stream";
            case "inl": return "text/plain";
            case "ins": return "application/x-internet-signup";
            case "ipa": return "application/x-itunes-ipa";
            case "ipg": return "application/x-itunes-ipg";
            case "ipproj": return "text/plain";
            case "ipsw": return "application/x-itunes-ipsw";
            case "iqy": return "text/x-ms-iqy";
            case "isp": return "application/x-internet-signup";
            case "ite": return "application/x-itunes-ite";
            case "itlp": return "application/x-itunes-itlp";
            case "itms": return "application/x-itunes-itms";
            case "itpc": return "application/x-itunes-itpc";
            case "ivf": return "video/x-ivf";
            case "jar": return "application/java-archive";
            case "java": return "application/octet-stream";
            case "jck": return "application/liquidmotion";
            case "jcz": return "application/liquidmotion";
            case "jfif": return "image/pjpeg";
            case "jnlp": return "application/x-java-jnlp-file";
            case "jpb": return "application/octet-stream";
            case "jpe": return "image/jpeg";
            case "jpeg": return "image/jpeg";
            case "jpg": return "image/jpeg";
            case "js": return "application/x-javascript";
            case "jsx": return "text/jscript";
            case "jsxbin": return "text/plain";
            case "latex": return "application/x-latex";
            case "library-ms": return "application/windows-library+xml";
            case "lit": return "application/x-ms-reader";
            case "loadtest": return "application/xml";
            case "lpk": return "application/octet-stream";
            case "lsf": return "video/x-la-asf";
            case "lst": return "text/plain";
            case "lsx": return "video/x-la-asf";
            case "lzh": return "application/octet-stream";
            case "m13": return "application/x-msmediaview";
            case "m14": return "application/x-msmediaview";
            case "m1v": return "video/mpeg";
            case "m2t": return "video/vnd.dlna.mpeg-tts";
            case "m2ts": return "video/vnd.dlna.mpeg-tts";
            case "m2v": return "video/mpeg";
            case "m3u": return "audio/x-mpegurl";
            case "m3u8": return "audio/x-mpegurl";
            case "m4a": return "audio/m4a";
            case "m4b": return "audio/m4b";
            case "m4p": return "audio/m4p";
            case "m4r": return "audio/x-m4r";
            case "m4v": return "video/x-m4v";
            case "mac": return "image/x-macpaint";
            case "mak": return "text/plain";
            case "man": return "application/x-troff-man";
            case "manifest": return "application/x-ms-manifest";
            case "map": return "text/plain";
            case "master": return "application/xml";
            case "mda": return "application/msaccess";
            case "mdb": return "application/x-msaccess";
            case "mde": return "application/msaccess";
            case "mdp": return "application/octet-stream";
            case "me": return "application/x-troff-me";
            case "mfp": return "application/x-shockwave-flash";
            case "mht": return "message/rfc822";
            case "mhtml": return "message/rfc822";
            case "mid": return "audio/mid";
            case "midi": return "audio/mid";
            case "mix": return "application/octet-stream";
            case "mk": return "text/plain";
            case "mmf": return "application/x-smaf";
            case "mno": return "text/xml";
            case "mny": return "application/x-msmoney";
            case "mod": return "video/mpeg";
            case "mov": return "video/quicktime";
            case "movie": return "video/x-sgi-movie";
            case "mp2": return "video/mpeg";
            case "mp2v": return "video/mpeg";
            case "mp3": return "audio/mpeg";
            case "mp4": return "video/mp4";
            case "mp4v": return "video/mp4";
            case "mpa": return "video/mpeg";
            case "mpe": return "video/mpeg";
            case "mpeg": return "video/mpeg";
            case "mpf": return "application/vnd.ms-mediapackage";
            case "mpg": return "video/mpeg";
            case "mpp": return "application/vnd.ms-project";
            case "mpv2": return "video/mpeg";
            case "mqv": return "video/quicktime";
            case "ms": return "application/x-troff-ms";
            case "msi": return "application/octet-stream";
            case "mso": return "application/octet-stream";
            case "mts": return "video/vnd.dlna.mpeg-tts";
            case "mtx": return "application/xml";
            case "mvb": return "application/x-msmediaview";
            case "mvc": return "application/x-miva-compiled";
            case "mxp": return "application/x-mmxp";
            case "nc": return "application/x-netcdf";
            case "nsc": return "video/x-ms-asf";
            case "nws": return "message/rfc822";
            case "ocx": return "application/octet-stream";
            case "oda": return "application/oda";
            case "odc": return "text/x-ms-odc";
            case "odh": return "text/plain";
            case "odl": return "text/plain";
            case "odp": return "application/vnd.oasis.opendocument.presentation";
            case "ods": return "application/oleobject";
            case "odt": return "application/vnd.oasis.opendocument.text";
            case "one": return "application/onenote";
            case "onea": return "application/onenote";
            case "onepkg": return "application/onenote";
            case "onetmp": return "application/onenote";
            case "onetoc": return "application/onenote";
            case "onetoc2": return "application/onenote";
            case "orderedtest": return "application/xml";
            case "osdx": return "application/opensearchdescription+xml";
            case "p10": return "application/pkcs10";
            case "p12": return "application/x-pkcs12";
            case "p7b": return "application/x-pkcs7-certificates";
            case "p7c": return "application/pkcs7-mime";
            case "p7m": return "application/pkcs7-mime";
            case "p7r": return "application/x-pkcs7-certreqresp";
            case "p7s": return "application/pkcs7-signature";
            case "pbm": return "image/x-portable-bitmap";
            case "pcast": return "application/x-podcast";
            case "pct": return "image/pict";
            case "pcx": return "application/octet-stream";
            case "pcz": return "application/octet-stream";
            case "pdf": return "application/pdf";
            case "pfb": return "application/octet-stream";
            case "pfm": return "application/octet-stream";
            case "pfx": return "application/x-pkcs12";
            case "pgm": return "image/x-portable-graymap";
            case "pic": return "image/pict";
            case "pict": return "image/pict";
            case "pkgdef": return "text/plain";
            case "pkgundef": return "text/plain";
            case "pko": return "application/vnd.ms-pki.pko";
            case "pls": return "audio/scpls";
            case "pma": return "application/x-perfmon";
            case "pmc": return "application/x-perfmon";
            case "pml": return "application/x-perfmon";
            case "pmr": return "application/x-perfmon";
            case "pmw": return "application/x-perfmon";
            case "png": return "image/png";
            case "pnm": return "image/x-portable-anymap";
            case "pnt": return "image/x-macpaint";
            case "pntg": return "image/x-macpaint";
            case "pnz": return "image/png";
            case "pot": return "application/vnd.ms-powerpoint";
            case "potm": return "application/vnd.ms-powerpoint.template.macroenabled.12";
            case "potx": return "application/vnd.openxmlformats-officedocument.presentationml.template";
            case "ppa": return "application/vnd.ms-powerpoint";
            case "ppam": return "application/vnd.ms-powerpoint.addin.macroenabled.12";
            case "ppm": return "image/x-portable-pixmap";
            case "pps": return "application/vnd.ms-powerpoint";
            case "ppsm": return "application/vnd.ms-powerpoint.slideshow.macroenabled.12";
            case "ppsx": return "application/vnd.openxmlformats-officedocument.presentationml.slideshow";
            case "ppt": return "application/vnd.ms-powerpoint";
            case "pptm": return "application/vnd.ms-powerpoint.presentation.macroenabled.12";
            case "pptx": return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
            case "prf": return "application/pics-rules";
            case "prm": return "application/octet-stream";
            case "prx": return "application/octet-stream";
            case "ps": return "application/postscript";
            case "psc1": return "application/powershell";
            case "psd": return "application/octet-stream";
            case "psess": return "application/xml";
            case "psm": return "application/octet-stream";
            case "psp": return "application/octet-stream";
            case "pub": return "application/x-mspublisher";
            case "pwz": return "application/vnd.ms-powerpoint";
            case "qht": return "text/x-html-insertion";
            case "qhtm": return "text/x-html-insertion";
            case "qt": return "video/quicktime";
            case "qti": return "image/x-quicktime";
            case "qtif": return "image/x-quicktime";
            case "qtl": return "application/x-quicktimeplayer";
            case "qxd": return "application/octet-stream";
            case "ra": return "audio/x-pn-realaudio";
            case "ram": return "audio/x-pn-realaudio";
            case "rar": return "application/octet-stream";
            case "ras": return "image/x-cmu-raster";
            case "rat": return "application/rat-file";
            case "rc": return "text/plain";
            case "rc2": return "text/plain";
            case "rct": return "text/plain";
            case "rdlc": return "application/xml";
            case "resx": return "application/xml";
            case "rf": return "image/vnd.rn-realflash";
            case "rgb": return "image/x-rgb";
            case "rgs": return "text/plain";
            case "rm": return "application/vnd.rn-realmedia";
            case "rmi": return "audio/mid";
            case "rmp": return "application/vnd.rn-rn_music_package";
            case "roff": return "application/x-troff";
            case "rpm": return "audio/x-pn-realaudio-plugin";
            case "rqy": return "text/x-ms-rqy";
            case "rtf": return "application/rtf";
            case "rtx": return "text/richtext";
            case "ruleset": return "application/xml";
            case "s": return "text/plain";
            case "safariextz": return "application/x-safari-safariextz";
            case "scd": return "application/x-msschedule";
            case "sct": return "text/scriptlet";
            case "sd2": return "audio/x-sd2";
            case "sdp": return "application/sdp";
            case "sea": return "application/octet-stream";
            case "searchconnector-ms": return "application/windows-search-connector+xml";
            case "setpay": return "application/set-payment-initiation";
            case "setreg": return "application/set-registration-initiation";
            case "settings": return "application/xml";
            case "sgimb": return "application/x-sgimb";
            case "sgml": return "text/sgml";
            case "sh": return "application/x-sh";
            case "shar": return "application/x-shar";
            case "shtml": return "text/html";
            case "sit": return "application/x-stuffit";
            case "sitemap": return "application/xml";
            case "skin": return "application/xml";
            case "sldm": return "application/vnd.ms-powerpoint.slide.macroenabled.12";
            case "sldx": return "application/vnd.openxmlformats-officedocument.presentationml.slide";
            case "slk": return "application/vnd.ms-excel";
            case "sln": return "text/plain";
            case "slupkg-ms": return "application/x-ms-license";
            case "smd": return "audio/x-smd";
            case "smi": return "application/octet-stream";
            case "smx": return "audio/x-smd";
            case "smz": return "audio/x-smd";
            case "snd": return "audio/basic";
            case "snippet": return "application/xml";
            case "snp": return "application/octet-stream";
            case "sol": return "text/plain";
            case "sor": return "text/plain";
            case "spc": return "application/x-pkcs7-certificates";
            case "spl": return "application/futuresplash";
            case "src": return "application/x-wais-source";
            case "srf": return "text/plain";
            case "ssisdeploymentmanifest": return "text/xml";
            case "ssm": return "application/streamingmedia";
            case "sst": return "application/vnd.ms-pki.certstore";
            case "stl": return "application/vnd.ms-pki.stl";
            case "sv4cpio": return "application/x-sv4cpio";
            case "sv4crc": return "application/x-sv4crc";
            case "svc": return "application/xml";
            case "swf": return "application/x-shockwave-flash";
            case "t": return "application/x-troff";
            case "tar": return "application/x-tar";
            case "tcl": return "application/x-tcl";
            case "testrunconfig": return "application/xml";
            case "testsettings": return "application/xml";
            case "tex": return "application/x-tex";
            case "texi": return "application/x-texinfo";
            case "texinfo": return "application/x-texinfo";
            case "tgz": return "application/x-compressed";
            case "thmx": return "application/vnd.ms-officetheme";
            case "thn": return "application/octet-stream";
            case "tif": return "image/tiff";
            case "tiff": return "image/tiff";
            case "tlh": return "text/plain";
            case "tli": return "text/plain";
            case "toc": return "application/octet-stream";
            case "tr": return "application/x-troff";
            case "trm": return "application/x-msterminal";
            case "trx": return "application/xml";
            case "ts": return "video/vnd.dlna.mpeg-tts";
            case "tsv": return "text/tab-separated-values";
            case "ttf": return "application/octet-stream";
            case "tts": return "video/vnd.dlna.mpeg-tts";
            case "txt": return "text/plain";
            case "u32": return "application/octet-stream";
            case "uls": return "text/iuls";
            case "user": return "text/plain";
            case "ustar": return "application/x-ustar";
            case "vb": return "text/plain";
            case "vbdproj": return "text/plain";
            case "vbk": return "video/mpeg";
            case "vbproj": return "text/plain";
            case "vbs": return "text/vbscript";
            case "vcf": return "text/x-vcard";
            case "vcproj": return "application/xml";
            case "vcs": return "text/plain";
            case "vcxproj": return "application/xml";
            case "vddproj": return "text/plain";
            case "vdp": return "text/plain";
            case "vdproj": return "text/plain";
            case "vdx": return "application/vnd.ms-visio.viewer";
            case "vml": return "text/xml";
            case "vscontent": return "application/xml";
            case "vsct": return "text/xml";
            case "vsd": return "application/vnd.visio";
            case "vsi": return "application/ms-vsi";
            case "vsix": return "application/vsix";
            case "vsixlangpack": return "text/xml";
            case "vsixmanifest": return "text/xml";
            case "vsmdi": return "application/xml";
            case "vspscc": return "text/plain";
            case "vss": return "application/vnd.visio";
            case "vsscc": return "text/plain";
            case "vssettings": return "text/xml";
            case "vssscc": return "text/plain";
            case "vst": return "application/vnd.visio";
            case "vstemplate": return "text/xml";
            case "vsto": return "application/x-ms-vsto";
            case "vsw": return "application/vnd.visio";
            case "vsx": return "application/vnd.visio";
            case "vtx": return "application/vnd.visio";
            case "wav": return "audio/wav";
            case "wave": return "audio/wav";
            case "wax": return "audio/x-ms-wax";
            case "wbk": return "application/msword";
            case "wbmp": return "image/vnd.wap.wbmp";
            case "wcm": return "application/vnd.ms-works";
            case "wdb": return "application/vnd.ms-works";
            case "wdp": return "image/vnd.ms-photo";
            case "webarchive": return "application/x-safari-webarchive";
            case "webtest": return "application/xml";
            case "wiq": return "application/xml";
            case "wiz": return "application/msword";
            case "wks": return "application/vnd.ms-works";
            case "wlmp": return "application/wlmoviemaker";
            case "wlpginstall": return "application/x-wlpg-detect";
            case "wlpginstall3": return "application/x-wlpg3-detect";
            case "wm": return "video/x-ms-wm";
            case "wma": return "audio/x-ms-wma";
            case "wmd": return "application/x-ms-wmd";
            case "wmf": return "application/x-msmetafile";
            case "wml": return "text/vnd.wap.wml";
            case "wmlc": return "application/vnd.wap.wmlc";
            case "wmls": return "text/vnd.wap.wmlscript";
            case "wmlsc": return "application/vnd.wap.wmlscriptc";
            case "wmp": return "video/x-ms-wmp";
            case "wmv": return "video/x-ms-wmv";
            case "wmx": return "video/x-ms-wmx";
            case "wmz": return "application/x-ms-wmz";
            case "wpl": return "application/vnd.ms-wpl";
            case "wps": return "application/vnd.ms-works";
            case "wri": return "application/x-mswrite";
            case "wrl": return "x-world/x-vrml";
            case "wrz": return "x-world/x-vrml";
            case "wsc": return "text/scriptlet";
            case "wsdl": return "text/xml";
            case "wvx": return "video/x-ms-wvx";
            case "x": return "application/directx";
            case "xaf": return "x-world/x-vrml";
            case "xaml": return "application/xaml+xml";
            case "xap": return "application/x-silverlight-app";
            case "xbap": return "application/x-ms-xbap";
            case "xbm": return "image/x-xbitmap";
            case "xdr": return "text/plain";
            case "xht": return "application/xhtml+xml";
            case "xhtml": return "application/xhtml+xml";
            case "xla": return "application/vnd.ms-excel";
            case "xlam": return "application/vnd.ms-excel.addin.macroenabled.12";
            case "xlc": return "application/vnd.ms-excel";
            case "xld": return "application/vnd.ms-excel";
            case "xlk": return "application/vnd.ms-excel";
            case "xll": return "application/vnd.ms-excel";
            case "xlm": return "application/vnd.ms-excel";
            case "xls": return "application/vnd.ms-excel";
            case "xlsb": return "application/vnd.ms-excel.sheet.binary.macroenabled.12";
            case "xlsm": return "application/vnd.ms-excel.sheet.macroenabled.12";
            case "xlsx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            case "xlt": return "application/vnd.ms-excel";
            case "xltm": return "application/vnd.ms-excel.template.macroenabled.12";
            case "xltx": return "application/vnd.openxmlformats-officedocument.spreadsheetml.template";
            case "xlw": return "application/vnd.ms-excel";
            case "xml": return "text/xml";
            case "xmta": return "application/xml";
            case "xof": return "x-world/x-vrml";
            case "xoml": return "text/plain";
            case "xpm": return "image/x-xpixmap";
            case "xps": return "application/vnd.ms-xpsdocument";
            case "xrm-ms": return "text/xml";
            case "xsc": return "application/xml";
            case "xsd": return "text/xml";
            case "xsf": return "text/xml";
            case "xsl": return "text/xml";
            case "xslt": return "text/xml";
            case "xsn": return "application/octet-stream";
            case "xss": return "application/xml";
            case "xtp": return "application/octet-stream";
            case "xwd": return "image/x-xwindowdump";
            case "z": return "application/x-compress";
            case "zip": return "application/x-zip-compressed";
            #endregion
            default: return "application/octet-stream";
        }
    }
        
}
