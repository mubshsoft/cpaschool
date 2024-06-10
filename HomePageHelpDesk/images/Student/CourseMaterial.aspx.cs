using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Text;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using fmsf.lib;
using fmsf.DAL;

public partial class Student_CourseMaterial : System.Web.UI.Page
{
    int cid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            cid = Convert.ToInt32(Request.QueryString["id"].ToString());

            try
            {
                if (!Page.IsPostBack)
                {
                    BindSemesterDropDown(cid);
                    GetSourceMaterial(0);

                }
            }
            catch (Exception ex)
            {
                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
            }
        }

    }

    protected void BindSemesterDropDown(int CourseId)
    {
        try
        {


            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();

            objLIBExam.CourseId = CourseId;
            objLIBExam.stid = Convert.ToInt32(Session["stid"].ToString());

            tp.MessagePacket = (object)objLIBExam;
            tp = objDalExam.GetSemesterofStudent(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            dllSem.DataSource = objLibExamListing;
            dllSem.DataTextField = objLIBExam.SemesterDispalyText;
            dllSem.DataValueField = objLIBExam.SemesterValueField;
            dllSem.DataBind();
            dllSem.Items.Insert(0, "-Select Semester-");

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }

    private void GetSourceMaterial(int SemesterId)
    {
        DataSet ds = new DataSet();

        LIBStudent objLIBExam = new LIBStudent();
        DalAddStudent_CS objDalExam = new DalAddStudent_CS();
        LIBStudentListing objLibExamListing = new LIBStudentListing();
        TransportationPacket tp = new TransportationPacket();

        objLIBExam.Courseid = cid;
        objLIBExam.stid = Convert.ToInt32(Session["stid"].ToString()); ;
        objLIBExam.SemesterId = SemesterId;
        tp.MessagePacket = (object)objLIBExam;

        ds = objDalExam.GetSourceMaterialVideoList(tp);
        ArrayList arr = new ArrayList();
        StringBuilder sb = new StringBuilder();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {


                int id = Convert.ToInt32(ds.Tables[0].Rows[i]["row_num"].ToString());
                int topid = Convert.ToInt32(ds.Tables[0].Rows[0]["row_num"].ToString());

                string strLnk = ds.Tables[0].Rows[i]["row_num"].ToString();
                string strq = ds.Tables[0].Rows[i]["Title"].ToString();
                string strFilepath = ds.Tables[0].Rows[i]["UploadFilePath"].ToString();
                string moduleid = ds.Tables[0].Rows[i]["moduleid"].ToString();
                string heading = ds.Tables[0].Rows[i]["ModuleTitle"].ToString();
                string paperid = ds.Tables[0].Rows[i]["PaperId"].ToString();
                string PaperTitle = ds.Tables[0].Rows[i]["PaperTitle"].ToString();
                string unitid = ds.Tables[0].Rows[i]["unitid"].ToString();
                string unittitle = ds.Tables[0].Rows[i]["unittitle"].ToString();
                string Assessments = ds.Tables[0].Rows[i]["Assessments"].ToString();

                string courseid = Request.QueryString["id"].ToString();



                sb.Append("<div class='card'>");
                if (!arr.Contains(heading))
                {
                    //sb.Append("<h4 class='mb-0' style='padding-left:10px;background-color:#3598db;color:white;'>");
                    //sb.Append(heading.ToString());
                    //sb.Append("</h4>");
                    sb.Append("<div class='card-header' id='" + id + "'>");
                    sb.Append("<h2 class='mb-0' style='padding-left:10px;color:white;'>");
                    sb.Append("<button type = 'button' class='btn btn-primary' style='width: 100%;text-align: left;' data-toggle='collapse' data-target='#collapse" + id + "'>" + heading + "</a>");
                    sb.Append("</h2>");
                    sb.Append("</div>");
                    arr.Add(heading);
                }

                string collapseid = "";
               if (id== topid)
                {
                    collapseid = "in";
                }
               
                sb.Append("<div id='collapse" + id + "' class='collapse "+ collapseid + "' aria-labelledby='" + id + "' data-parent='#accordionExample'>");
                sb.Append("<div class='card-body' style='background: #fff;padding: 10px;border-radius: 5px;'>");
                //sb.Append("<p>" + paperid + "</p>");
                sb.Append("<h4 style='font-weight:bold; border-bottom:solid 1px #e4e4e4;padding-bottom: 5px;'>" + PaperTitle + "</h4>");
                sb.Append("<h5>Units</h5>");
                string strq1 = "select *, Assessments=(select top 1 'Assessments' from chapter where UnitID=unit.UnitID ) from unit where paperid=" + paperid + " order by unitid";
                var ds1 = new DataSet();
                ds1 = CLS.fnQuerySelectDs(strq1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        string uid = ds1.Tables[0].Rows[j]["Unitid"].ToString();
                        string unit = ds1.Tables[0].Rows[j]["UnitTitle"].ToString();
                        string UploadFilePath = ds1.Tables[0].Rows[j]["UploadFilePath"].ToString();
                        string Mode = ds1.Tables[0].Rows[j]["mode"].ToString();
                        string Assess = ds1.Tables[0].Rows[j]["Assessments"].ToString();
                        if (Mode == "View")
                        {
                            sb.Append("<div class='row'>");
                            sb.Append("<div class='col-lg-4 col-md-4 col-sm-4 col-xs-4' style='padding-left:30px;padding-bottom: 10px'>" + unit + "</div>");
                            sb.Append("<div class='col-lg-8 col-md-8 col-sm-8 col-xs-8'>");
                            if (UploadFilePath.ToLower().EndsWith(".mp4") || UploadFilePath.ToLower().EndsWith(".mp3"))
                            {
                                string AddNote = "1";
                                sb.Append("<a href = '#' id='" + id + "' onclick ='javascript:ViewResourceFile(" + courseid + "," + paperid + "," + uid + "," + AddNote + ")' title='Play Video & Add Note' ><i class='fa fa-youtube-play'></i> Play Video & Add Note</a>");
                                sb.Append(" | <a href = '#' id='" + id + "' onclick ='javascript:ViewNote(" + courseid + "," + uid + ")' title='View Note'> <i class='fa fa-book'></i></a>");
                            }
                            else
                            {
                                string AddNote = "2";
                                //sb.Append("<a href = '#' id='" + id + "' onclick ='javascript:ViewResourceFile(" + courseid + "," + paperid + "," + unitid + "," + AddNote + ")' >View File - " + unittitle + "</a>");
                                if (Assess == "Assessments")
                                {
                                    sb.Append("<a href = '#' id='" + id + "' onclick ='javascript:ViewResourceFile(" + courseid + "," + paperid + "," + uid + "," + AddNote + ")' title='View Unit' ><i class='fa fa-eye'></i> Unit</a>");
                                    //sb.Append(" | <a href = 'ViewAssessmentsChapter.aspx?ID=" + uid + "' id='" + id + "' title='View Assessments Chapter' > <i class='fa fa-eye'></i> Assessments Chapter</a>");
                                    sb.Append(" | <a href = '#' id='" + id + "' onclick ='javascript:ViewAssessmentSchapter(" + uid + ")' title='View Assessments Chapter''> <i class='fa fa-eye'></i> Assessments Chapter</a></a>");
                                }
                                else
                                {
                                    sb.Append("<a href = '#' id='" + id + "' onclick ='javascript:ViewResourceFile(" + courseid + "," + paperid + "," + uid + "," + AddNote + ")' title='View Unit' ><i class='fa fa-eye'></i> Unit</a>");
                                }

                            }
                            //sb.Append("<a href = '#' id='" + id + "' onclick ='javascript:ViewNote(" + courseid + "," + unitid + ")' > View Note</a>");
                            sb.Append("</div>");
                            sb.Append("</div>");
                        }
                        else
                        {
                            sb.Append("<div class='row'>");
                            sb.Append("<div class='col-lg-4 col-md-4 col-sm-4 col-xs-4' style='padding-left:30px;padding-bottom: 10px'>" + unit + "</div>");
                            sb.Append("<div class='col-lg-8 col-md-8 col-sm-8 col-xs-8'>");

                            if (Assess == "Assessments")
                            {
                                sb.Append("<a href = '../DownloadDetail.aspx?dt=lc&paperid=" + paperid + "&unitid=" + uid + "' id='" + id + "' ><i class='fa fa-download'></i> Download</a>");
                                //sb.Append(" | <a href = 'ViewAssessmentsChapter.aspx?ID=" + uid + "' id='" + id + "' title='View Assessments Chapter' > <i class='fa fa-eye'></i> Assessments Chapter</a>");
                                sb.Append(" | <a href = '#' id='" + id + "' onclick ='javascript:ViewAssessmentSchapter(" + uid + ")' title='View Assessments Chapter''> <i class='fa fa-eye'></i> Assessments Chapter</a></a>");
                            }
                            else
                            {
                                sb.Append("<a href = '../DownloadDetail.aspx?dt=lc&paperid=" + paperid + "&unitid=" + uid + "' id='" + id + "' ><i class='fa fa-download'></i> Download</a>");
                            }
                            
                            sb.Append("</div>");
                            sb.Append("</div>");

                        }
                        //sb.Append("<div>" + unit + "</div>");
                        //sb.Append("<div>" + UploadFilePath + "</div>");
                        //sb.Append("<div>" + Mode + "</div>");
                    }
                }

                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

            }

            PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });
            //lblMessage.Visible = false;
        }
        else
        {
            // lblMessage.Visible = true;
            //lblMessage.Text = "No record found !.";
            return;
        }
    }

    protected void dllSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dllSem.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, "alert('Select Semester !');", true);
            return;

        }
        else
        {
            int semid = Convert.ToInt32(dllSem.SelectedValue);
            GetSourceMaterial(semid);
        }
    }

    [WebMethod]
    public static string AddNote(string Courseid, string UnitId, string Note)
    {


        int rtVal = 0;
        try
        {
            int addResult = 0;
            LIBStudent objLibExam = new LIBStudent();
            DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
            TransportationPacket tp = new TransportationPacket();

            objLibExam.stid = Convert.ToInt32(HttpContext.Current.Session["stid"].ToString());
            objLibExam.Courseid = Convert.ToInt32(Courseid);
            objLibExam.UnitId = Convert.ToInt32(UnitId);
            objLibExam.Note = Utility.CheckNullString(Note);

            tp.MessagePacket = (object)objLibExam;
            addResult = OBJDALExam.AddNote(tp);

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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetStudentNotes(string Courseid, string UnitId)
    {
        DataSet ds = new DataSet();

        LIBStudent objLibExam = new LIBStudent();
        DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
        TransportationPacket tp = new TransportationPacket();

        objLibExam.stid = Convert.ToInt32(HttpContext.Current.Session["stid"].ToString());
        objLibExam.Courseid = Convert.ToInt32(Courseid);
        objLibExam.UnitId = Convert.ToInt32(UnitId);

        tp.MessagePacket = (object)objLibExam;
        List<LIBStudent> ls = OBJDALExam.GetNoteList(tp);
        var json = new
        {
            rows = ls

        };

        // Return JSON data
        JavaScriptSerializer js = new JavaScriptSerializer();
        string retJSON = js.Serialize(json);
        return retJSON;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetVideoPath(string PaperId, string UnitId)
    {
        DataSet ds = new DataSet();

        LIBStudent objLibExam = new LIBStudent();
        DalAddStudent_CS OBJDALExam = new DalAddStudent_CS();
        TransportationPacket tp = new TransportationPacket();

        objLibExam.PaperId = Convert.ToInt32(PaperId);
        objLibExam.UnitId = Convert.ToInt32(UnitId);

        tp.MessagePacket = (object)objLibExam;
        List<LIBStudent> ls = OBJDALExam.GetVideoPathList(tp);
        var json = new
        {
            rows = ls

        };

        // Return JSON data
        JavaScriptSerializer js = new JavaScriptSerializer();
        string retJSON = js.Serialize(json);
        return retJSON;

    }
}