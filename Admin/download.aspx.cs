using System;
using System.IO;
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

public partial class Admin_download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string PgType = Request.QueryString["PgType"].ToString();
        //int quesid =Convert.ToInt32(Request.QueryString["Questionid"].ToString());
        //int examid = Convert.ToInt32(Request.QueryString["examid"].ToString());
        //string filename = "";
        //if (PgType == "asgn")
        //{
        //    filename=GetAsgnFileName(quesid, examid);
        //}
        //if (PgType == "exam")
        //{
        //    filename = GetExamFileName(quesid, examid);
        //}
        //if (PgType == "scr")
        //{
        //    filename = GetscrFileName(quesid, examid);
        //}
        string filename = Session["file"].ToString();
        System.IO.FileInfo file = new System.IO.FileInfo(filename);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            Response.Write("<script language='javascript' type='text/javascript'>alert('file does not exist'); history.go(-1)</script>");
        }
        
    }
    //protected string  GetExamFileName(int questionid,int examid)
    //{
    //    string file = "";
    //    try
    //    {
    //        LIBExam objLIBExam = new LIBExam();
    //        DALExam objDalExam = new DALExam();
    //        LIBExamListing objLibExamListing = new LIBExamListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBExam.QuestionId = questionid;
    //        objLIBExam.ExamId = examid;
    //        tp.MessagePacket = (object)objLIBExam;

    //        file = objDalExam.GetUploadAnsPath(tp);
           


    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //    return file;

    //}
    //protected string GetExamFileName(int questionid, int examid)
    //{
    //    string file = "";
    //    try
    //    {
    //        LIBExam objLIBExam = new LIBExam();
    //        DALExam objDalExam = new DALExam();
    //        LIBExamListing objLibExamListing = new LIBExamListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBExam.QuestionId = questionid;
    //        objLIBExam.ExamId = examid;
    //        tp.MessagePacket = (object)objLIBExam;

    //        file = objDalExam.GetUploadAnsPath(tp);



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //    return file;

    //}
    //protected string GetAsgnFileName(int questionid, int examid)
    //{
    //    string file = "";
    //    try
    //    {
    //        LIBExam objLIBAssignment = new LIBAssignment();
    //        DALAssignment objDalAssignment = new DALAssignment();
    //        LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBAssignment.QuestionId = questionid;
    //        objLIBAssignment.AsgnId = examid;
    //        tp.MessagePacket = (object)objLIBAssignment;

    //        file = objDalAssignment.GetUploadAnsPath(tp);



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //    return file;

    //}
    //protected string GetScrFileName(int questionid, int examid)
    //{
    //    string file = "";
    //    try
    //    {
    //        LIBScreening objLIBScreening = new LIBScreening();
    //        DALScreening objDalScreening = new DALScreening();
    //        LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        objLIBScreening.QuestionId = questionid;
    //        objLIBScreening.ScrId = examid;
    //        tp.MessagePacket = (object)objLIBScreening;

    //        file = objDalScreening.GetUploadAnsPath(tp);



    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //    return file;

    //}
}
