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
public partial class AssignmentAnswerSheet : System.Web.UI.Page
{
    int NOS = 0;
    string strHeading = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("../Default-new.aspx");
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

                hdnuserid.Value = Request.QueryString["uid"].ToString();
                hdnasnid.Value = Request.QueryString["asgnid"].ToString();


                GetUserList();
                bindsection();
              


            }
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
       
    }





   

    protected void GetUserList()
    {
       
        try
        {
            DataSet ds = new DataSet();
            LIBAssignment objLIBAssignment = new LIBAssignment();
            DALAssignment objDalAssignment = new DALAssignment();
            LIBAssignmentListing objLibAssignmentListing = new LIBAssignmentListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBAssignment.UserId = (hdnuserid.Value.ToString());
            objLIBAssignment.AsgnId = Convert.ToInt32(hdnasnid.Value);
          
            tp.MessagePacket = (object)objLIBAssignment;

            ds = objDalAssignment.GetSubmiitedAssignmentByUserId(tp);
          
            dlstanswers.DataSource = ds;
            dlstanswers.DataBind();
           



        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


    }


    protected void dlstanswers_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void bindsection()
    {
        if (dlstanswers.Items.Count > 0)
        {
            for (int i = 0; i< dlstanswers.Items.Count; i++ )
            {
                Label lblcatgname = (Label)dlstanswers.Items[i].FindControl("lblcategoryname");
                HiddenField hdnCatgId = (HiddenField)dlstanswers.Items[i].FindControl("hdnCatgId");
                if (strHeading != hdnCatgId.Value)
                {
                    strHeading = hdnCatgId.Value;
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
    protected void dlstanswers_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
           // string anstext;
            DataListItem row = e.Item;
            if (e.Item.ItemType == ListItemType.Item)
            {
               
                Label lblcorectanswers = (Label)e.Item.FindControl("lblcorectanswers");
                Label lblcatgname = (Label)e.Item.FindControl("lblcategoryname");
                HiddenField hdnCatgId = (HiddenField)e.Item.FindControl("hdnCatgId");
                HiddenField hdnQUESTYPE = (HiddenField)e.Item.FindControl("hdnquestype");
                if (hdnQUESTYPE.Value == "Objective")
                {
                    lblcorectanswers.Visible = true;
                }
                else
                {
                    lblcorectanswers.Visible = false;
                }

               
            }
        }
        catch (Exception ex)
        {
        }
    }
    
    protected void lnkbtnexport_Click(object sender, EventArgs e)
    {
        Response.Clear();

        Response.Buffer = true;

        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");

        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-word ";

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);


        //dlstanswers.DataBind();

        dlstanswers.RenderControl(hw);
        //LstUserExaminfo.RenderControl(hw) 
        Response.Output.Write(sw.ToString());

        Response.Flush();

        Response.End(); 
    }
}
