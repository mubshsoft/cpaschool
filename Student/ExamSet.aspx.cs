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

public partial class ExamSet : System.Web.UI.Page
{
    int STID = 0;
    int BID = 0;
    string PaperID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //int STID=0;
        //int BID = 0;
        //string PaperID = "";
        STID= Convert.ToInt32(Request.QueryString["STId"]);
        BID = Convert.ToInt32(Request.QueryString["Bid"]);
        PaperID = Request.QueryString["pid"].ToString();
      
        if (PaperID == "")
        {
            PaperID = "0";
        }
else
        {
            PaperID = PaperID.Remove(PaperID.Length - 1);
        }
        if (Session["username"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("StudentPanel.aspx");

            }
            if (!Page.IsPostBack)
            {
                if (STID != 0 && BID != 0)
                {
                    //string strP
                    //CheckData(STID, BID);
                    BindExamSetList();
                    //BindExamSetList_Query();
                    grdExamSet.Visible = true;
                }
                //BindExamSetList();
            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
                        //string strq1 = "select SPM.ExamStatus from StudentPaperMarks SPM inner join student st on SPM.stid=st.stid inner join paper pa on SPM.paperId=pa.paperId inner join ActivateExam ae on SPM.bid=ae.bid where st.email='" + sessVal + "' and SPM.ExamStatus=0 and ae.ActivateDate<=GETDATE() and ae.DeactivateDate>=GETDATE() and ae.bid=" + BID + " and st.stid=" + StID;
                        //DataSet dsStid1 = new DataSet();
                        //dsStid1 = objDalExam.fnQrySlctDsGrv(strq1);
                        //if (dsStid1.Tables(0) != null)
                        //{
                            //if (dsStid1.Tables(0).Rows.Count > 0)
                            //{
                            //    string ExamStatusVal = "";
                            //    for (int k = 0; k <= dsStid1.Tables(0).Rows.Count - 1; k++)
                            //    {
                            //        ExamStatusVal = ExamStatusVal + "," + dsStid1.Tables(0).Rows(k)("ExamStatus").ToString();
                            //        //ExamStatusVal = (ExamStatusVal & Convert.ToString(",")) & dsStid1.Tables(0).Rows(i)("SPM.ExamStatus").ToStrong()
                            //        //ExamStatusVal = dsStid1.Tables(0).Rows(i)("SPM.ExamStatus").ToStrong()
                            //    }
                            //}
        
    }
    //protected void BindExamSetList_Query()
    //{
    //    try
    //    {
    //        SqlConnection conquery = new SqlConnection(ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ConnectionString);
    //        SqlCommand cmdquery = new SqlCommand("select distinct e.ExamId,e.ExamCode,c.CourseTitle, s.SemesterTitle, m.ModuleTitle, p.PaperTitle from ExamSet e join Course c on e.CourseId=c.CourseId join Semester s on e.SemId=s.SemId join Module m on e.ModuleId=m.ModuleId join Paper p on e.PaperId=p.PaperId join StudentActiveExam sa on e.examid=sa.examid join activateExam a on e.examid=a.examid where sa.userid='" + Session["username"].ToString() + "' and DATEDIFF(dd, 0, GETDATE()) between a.Activatedate and a.deactivatedate and sa.activate=0 and sa.Userid not in(select email from student s join studentsemester ss on s.stid=ss.stid where s.email='" + Session["username"].ToString() + "' and ss.feestatus=0 and currentstatus=2) and e.PaperId in (select distinct paperID from StudentPaperMarks where stid=" + STID + " and bid=" + BID + " and ExamStatus=0 and paperId in (" + PaperID + "))", conquery);
    //        SqlDataAdapter adaquery = new SqlDataAdapter(cmdquery);
    //        DataSet dsquery = new DataSet();
    //        adaquery.Fill(dsquery);
    //        if (dsquery.Tables[0] != null)
    //        {
    //            if (dsquery.Tables[0].Rows.Count > 0)
    //            {
    //                grdExamSet.DataSource = dsquery;
    //                grdExamSet.DataBind();
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);
    //        //HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //}
    protected void BindExamSetList()
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.UserId = Session["username"].ToString();
            objLIBExam.stid = STID;
            objLIBExam.bid = BID;
            objLIBExam.paperid = PaperID;
            tp.MessagePacket = (object)objLIBExam;

            //tp = objDalExam.GetStudentExamSetList(tp);
            tp = objDalExam.GetStudentExamSetList_1(tp);
            objLibExamListing = (LIBExamListing)tp.MessageResultset;
            grdExamSet.DataSource = objLibExamListing;
            grdExamSet.DataBind();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void CheckData(int qrystr, int bid)
    {
        try
        {
            LIBExam objLIBExam = new LIBExam();
            DALExam objDalExam = new DALExam();
            //LIBExamListing objLibExamListing = new LIBExamListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBExam.userid = qrystr;
            objLIBExam.Bid = bid;
            tp.MessagePacket = (object)objLIBExam;
            DataSet ds = new DataSet();
            ds = objDalExam.fnCheckDs(tp);
            //objLibExamListing = (LIBExamListing)tp.MessageResultset;
            //------------------------------------------Gridview Data Begin--------------------------------------------------
            //tp = objDalExam.GetStudentExamSetList(tp);
            //objLibExamListing = (LIBExamListing)tp.MessageResultset;
            //tp = null;
            //tp.MessagePacket = null;
            //objLIBExam.UserId = Session["username"].ToString();
            //tp.MessagePacket = (object)objLIBExam;
            //DataSet dsgrv = new DataSet();
            //dsgrv = objDalExam.fnGrvDs(tp);
            //dsgrv = objLibExamListing;
            //------------------------------------------Gridview Data End----------------------------------------------------
            if (ds.Tables[0] != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Correct=select * from ActivateExam where ExamId in (select distinct ExamId from ExamSet where PaperId in (select distinct paperId from StudentPaperMarks where stid=@UserId and ExamStatus=0)) and BID in (select bid from StudentPaperMarks where bid=@BID and ExamStatus=0) and DATEDIFF(dd, 0, GETDATE())  between Activatedate and deactivatedate 

                    //select * from paper where paperid in (select distinct paperid from ExamSet where courseid in (select ss.courseid from studentsemester ss inner join StudentPaperMarks spm on ss.stid=spm.stid where spm.stid=@UserId and spm.ExamStatus=0))   
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                        //if (dsgrv.Tables[0] != null)
                        //{
                        //    if (dsgrv.Tables[0].Rows.Count > 0)
                        //    {
                        //        for (int j = 0; j < dsgrv.Tables[0].Rows.Count; i++)
                        //        {
                        //            if (ds.Tables[0].Rows[i]["PaperTitle"].ToString() == dsgrv.Tables[0].Rows[j]["PaperTitle"].ToString())
                        //            {
                                        grdExamSet.Visible = true;
                                        BindExamSetList();
                        //            }
                        //        }
                        //    }
                        //}
                    //}
                }
            }
            //grdExamSet.Visible = true;
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
        
    //}

    protected void grdExamSet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsExam");
                HiddenField hdnExamID = (HiddenField)e.Row.FindControl("hdnExamID");
                HiddenField hdnPaper = (HiddenField)e.Row.FindControl("hdPaperTitle");
                valu.PostBackUrl = "~/Student/Instruction.aspx?ExamID=" + hdnExamID.Value + "&paper=" + hdnPaper.Value;



            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void grdExamSet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdExamSet.PageIndex = e.NewPageIndex;
        BindExamSetList();
    }
    //protected void BindExamSetList_1()
    //{
    //    try
    //    {
    //        LIBExam objLIBExam = new LIBExam();
    //        DALExam objDalExam = new DALExam();
    //        LIBExamListing objLibExamListing = new LIBExamListing();
    //        TransportationPacket tp = new TransportationPacket();
    //        ///objLIBExam.UserId = Session["username"].ToString();
    //        objLIBExam.stid = STID;
    //        objLIBExam.bid = BID;
    //        objLIBExam.paperid = PaperID;
    //        tp.MessagePacket = (object)objLIBExam;

    //        //tp = objDalExam.GetStudentExamSetList(tp);
    //        tp = objDalExam.GetStudentExamSetList_StdActive(tp);
    //        objLibExamListing = (LIBExamListing)tp.MessageResultset;
    //        grdExamSet.DataSource = objLibExamListing;
    //        grdExamSet.DataBind();

    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //}

    //protected void grdExamSet_1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdExamSet_1.PageIndex = e.NewPageIndex;
    //    BindExamSetList_1();
    //}
    //protected void grdExamSet_1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {

    //            LinkButton valu = (LinkButton)e.Row.FindControl("lnkDetailsExam");
    //            HiddenField hdnExamID = (HiddenField)e.Row.FindControl("hdnExamID");
    //            HiddenField hdnPaper = (HiddenField)e.Row.FindControl("hdPaperTitle");
    //            valu.PostBackUrl = "~/Student/Instruction.aspx?ExamID=" + hdnExamID.Value + "&paper=" + hdnPaper.Value;



    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
    //    }
    //}
}
