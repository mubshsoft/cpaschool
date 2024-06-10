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

public partial class Student_ViewAssessmentsChapter : System.Web.UI.Page
{
    protected static int HitCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        GetSourceMaterial();
    }
    private void GetSourceMaterial()
    {

        int unitid = Convert.ToInt32(Request.QueryString["ID"].ToString());
        hdnUnitId.Value = unitid.ToString();
        StringBuilder sb = new StringBuilder();
        DataSet ds1 = new DataSet();
        ds1 = CLS_C.fnQuerySelectDs("select count(*) as rcount from ChapterView where unitid=" + unitid + " and userid='"+Session["username"]+"'");

        string hitcount = ds1.Tables[0].Rows[0]["rcount"].ToString();
        hdnHitCount.Value = hitcount;

        DataSet ds = new DataSet();
        Chapter objLIBExam = new Chapter();
        DALChapter objDalExam = new DALChapter();
        ChapterListing objLibExamListing = new ChapterListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBExam.UnitID = unitid;

        tp.MessagePacket = (object)objLIBExam;
        tp = objDalExam.GetChapterListbyUnit(tp);
        objLibExamListing = (ChapterListing)tp.MessageResultset;
        if (objLibExamListing.Count > 0)
        {
            int j = 0;
            int k = objLibExamListing.Count;// ds.Tables[0].Rows.Count;
            hdnTotalCount.Value = k.ToString();
            sb.Append("<div id='verticalTab'>");
            sb.Append("<ul class='resp-tabs-list' id='chapterlist' style='text-align:left'>");
            for (int i = 0; i < objLibExamListing.Count; i++)
            {
                //string id = ds.Tables[0].Rows[i]["ID"].ToString();
                string id = objLibExamListing[i].ChapterID;  //ds.Tables[0].Rows[i]["ChapterID"].ToString();
                string ChapterText = objLibExamListing[i].ChapterText;// ds.Tables[0].Rows[i]["ChapterText"].ToString();
                string Type = objLibExamListing[i].Type;

                sb.Append("<li id='" + id + "' name='"+ Type +"'>");
                sb.Append(ChapterText);
                sb.Append("</li>");

            }
            sb.Append("</ul>");
            for (int i1 = 0; i1 < objLibExamListing.Count; i1++)
            {
                j = i1 + 1;
                string id = Convert.ToString(objLibExamListing[i1].ID);//ds.Tables[0].Rows[i1]["ID"].ToString();
                string FileName = objLibExamListing[i1].FileName;// ds.Tables[0].Rows[i1]["FileName"].ToString();
                string Filepath = "../" + objLibExamListing[i1].FilePath;// ds.Tables[0].Rows[i1]["FilePath"].ToString();
                string URL = "../" + objLibExamListing[i1].AssessmentsURL;// ds.Tables[0].Rows[i1]["URL"].ToString();
                if (j == 1)
                {
                    sb.Append("<div class='resp-tabs-container' style='width:800px;min-height: 600px'>");
                }
                sb.Append("<div>");
                if (Filepath != null)
                {
                    if (Filepath.ToLower().EndsWith(".pdf"))
                    {
                        string strpath = Filepath + "#toolbar=0&navpanes=0&statusbar=0&view=Fit;readonly=true; disableprint=true";
                        sb.Append("<iframe id ='f" + id + "' src = '" + strpath + "' style = 'width:780px;min-height: 600px' ></iframe>");
                    }
                    else if (Filepath.ToLower().EndsWith(".html"))
                    {
                        sb.Append("<iframe id ='f" + id + "' src = '" + Filepath + "' style = 'width:780px;min-height: 600px' ></iframe>");
                    }
                    else if (Filepath.ToLower().EndsWith(".mp4"))
                    {
                        //sb.Append("<iframe id ='f" + id + "' src = '" + Filepath + "' style = 'width:780px;min-height: 600px' ></iframe>");
                        sb.Append("<video width='780' height='580' controls id='Video" + id + "'><source src='" + Filepath + "' id='vidSource" + id + "' type='video/mp4'></source></video>");
                    }
                    else
                    {
                        sb.Append("<iframe id ='fq" + id + "' src = '" + URL + "' style = 'width:780px;min-height: 600px' ></iframe>");
                        // sb.Append(URL);
                    }
                }
                else
                {
                    sb.Append(URL);
                }
                sb.Append("</div>");

                if (j == k)
                {
                    sb.Append("</div>");
                }
            }


            sb.Append("</div>");
        }

        PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });
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

                // HttpContext.Current.Session["rtVal"].ToString();
            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


        return rtVal.ToString();

    }
}