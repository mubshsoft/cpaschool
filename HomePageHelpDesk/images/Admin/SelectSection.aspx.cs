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
using System.Data.SqlClient;


public partial class Admin_SelectSection : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {

                    hdnExamId.Value = Request.QueryString["ExamID"].ToString();

                    BindCategoryList();


                }


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }


    protected void BindCategoryList()
    {
        try
        {
            LIBCategory objLIBCategory = new LIBCategory();
            DALCategory objDalCategory = new DALCategory();
            LIBCategoryListing objLibCategoryListing = new LIBCategoryListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBCategory.ExamId = Convert.ToInt32(hdnExamId.Value);

            tp.MessagePacket = (object)objLIBCategory;

            tp = objDalCategory.GetCategoryByExamId(tp);
            objLibCategoryListing = (LIBCategoryListing)tp.MessageResultset;
            gvCategoryList.DataSource = objLibCategoryListing;

            gvCategoryList.DataBind();





        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }
    protected void gvCategoryList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                HiddenField hdnCustId = (HiddenField)e.Row.FindControl("hdnDeleteCategoryID");
                Label lblCatName = (Label)e.Row.FindControl("lblCategoryName");
                //Add delete confirmation message for Customer
                LinkButton l = (LinkButton)e.Row.FindControl("linkDeleteCategory");
             
                //l.PostBackUrl = "~/Admin/AddSectionQue.aspx?ExamID=" + hdnExamId.Value + "&sectionId=" + hdnCustId.Value;
                l.PostBackUrl = "~/Admin/AddQuestion.aspx?ExamID=" + hdnExamId.Value + "&sectionId=" + hdnCustId.Value + "&sectionName=" + lblCatName.Text;

                LinkButton l2 = (LinkButton)e.Row.FindControl("linkaddcategoryquestion");
                l2.PostBackUrl = "~/Admin/AddSectionQue.aspx?ExamID=" + hdnExamId.Value + "&sectionId=" + hdnCustId.Value + "&sectionName=" + lblCatName.Text;

                LinkButton lnkInstructionSummary = (LinkButton)e.Row.FindControl("lnkaddInstruction");
                lnkInstructionSummary.PostBackUrl = "~/Admin/StudentInstructionSummary.aspx?ExamID=" + hdnExamId.Value + "&sectionId=" + hdnCustId.Value + "&sectionName=" + lblCatName.Text;
            }


        }
        catch (Exception ex)
        { }



    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //checking validation

        try
        {
            if (txtNoofSection.Text.Length == 0)
            {
                Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Section value cannot be left blank.'); </script>");
                return;
            }
        }
        catch (System.FormatException ex)
        {
            
        }

        try
        {
            int i = System.Convert.ToInt32(txtNoofSection.Text);
          
        }
        catch (System.FormatException ex)
        {
            Response.Write("<SCRIPT LANGUAGE='javascript'>alert('Section value should be numeric.'); </script>");
            return;
        }


        try
        {
            int addResult = 0;

            LIBExam objLibExam = new LIBExam();
            DALExam OBJDALExam = new DALExam();
            TransportationPacket tp = new TransportationPacket();

            //objLibExam.ExamId = Convert.ToInt32(hdnExamId.Value);
            //tp.MessagePacket = (object)objLibExam;
            //addResult = OBJDALExam.DeleteExamCategory(tp);

            //if (addResult >= 0)
            //{

            DataSet dsSection= new DataSet();
            int toSection=0;
            dsSection = CLS_C.fnQuerySelectDs("select categoryID from exam_category where ExamId=" + Convert.ToInt32(hdnExamId.Value));
               int Trows=0;
                if (dsSection != null) 
                { 
                    if (dsSection.Tables != null) 
                        { 
                           if (dsSection.Tables[0].Rows != null) 
                                { 
                            if (dsSection.Tables[0].Rows.Count > 0) 
                                    { 
                                     Trows=dsSection.Tables[0].Rows.Count;
                                     Trows = Trows + 1;
                                     toSection = Trows     + Convert.ToInt16(txtNoofSection.Text);

                                             for (Trows = Trows; Trows < toSection; Trows++)
                                             {


                                                 objLibExam.CategoryName = "Section" + Trows;


                                                 objLibExam.ExamId = Convert.ToInt32(hdnExamId.Value);
                                                 tp.MessagePacket = (object)objLibExam;
                                                 addResult = OBJDALExam.AddExamCategory(tp);
                                             }
                                    }
                                   else
                                    {
                                     Trows=1;
                                    toSection=Convert.ToInt16(txtNoofSection.Text);

                                        for (Trows = Trows; Trows <= toSection; Trows++)
                                        {


                                            objLibExam.CategoryName = "Section" + Trows;


                                            objLibExam.ExamId = Convert.ToInt32(hdnExamId.Value);
                                            tp.MessagePacket = (object)objLibExam;
                                            addResult = OBJDALExam.AddExamCategory(tp);
                                        }
                                    } 
                                }    
                        }    
                }





         
                txtNoofSection.Text = "";
            BindCategoryList();

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddExamSet.aspx");
    }
    protected void gvCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id;
        if (e.CommandName == "Delete")
        {
            id = Convert.ToInt32(e.CommandArgument);
            string strChk = "select cate.CategoryID from EXAM_CATEGORY cate INNER JOIN QUESTIONS ques on cate.CategoryID=ques.CategoryID where cate.CategoryID=" + id;
            DALExam objDalExam = new DALExam();
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = objDalExam.getdata(strChk);
            if (dtt.Rows.Count > 0)
            {
                lblMessage.Text = "Section has some question - can't be deleted";
            }
            else
            {
                string str = "delete from EXAM_CATEGORY where CategoryID=" + id;
                //ExeNQcomsp(str);
                objDalExam.ExeNQcomsp(str);
                lblMessage.Text = "Record deleted successfully";
                lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
            }
            BindCategoryList();
        }
    }
    protected void gvCategoryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //public static void ExeNQcomsp(string strQ)
    //{
    //    String strSQLConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["fmsfConnectionString2"].ConnectionString;

    //    SqlConnection con = new SqlConnection(strSQLConnectionString);

    //    SqlCommand ObjSqlCommand = null;
    //    int intReturnValue = 0;
    //    try
    //    {
    //        con.Open();
    //        ObjSqlCommand = new SqlCommand(strQ, con);
    //        intReturnValue = ObjSqlCommand.ExecuteNonQuery();
    //        ObjSqlCommand.Connection.Close();


    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }
    //} 
}
