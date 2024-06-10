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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;
using System.Xml;
public partial class SubmitOnlineScreening : System.Web.UI.Page
{
    protected string secname = null;
    HiddenField hdnCategoryIdQuesnew;
    protected string secText = null;
    protected DataSet dsInstruction;
   protected void Page_Load(object sender, EventArgs e)
     {
        //ClientScript.RegisterStartupScript(typeof(Page), "timer_script", "<script>countdown_clock();</script>");

        


        try
        {
           if (!Page.IsPostBack)
            {
                if (Session["Screeningusername"] == null)
                {
                    Response.Redirect("../Screeninglogin.aspx");
                }  
                //    if (Request.QueryString.Count > 0)
                //    {
                GetBid();
                hdnUserId.Value = Session["Screeningusername"].ToString();
                Response.Cookies["Count"].Expires = DateTime.Now.AddDays(-1);

                hdnScrId.Value = Request.QueryString["ScrId"].ToString();
                try
                {
                    Session["ScrId"] = Convert.ToInt32(hdnScrId.Value);
                }
                catch (Exception ex)
                {
                }
               string backtoreview = Request.QueryString["review"].ToString();
                //timeAllocated.Value = "20";

                string strTimeAllocated;
                DataSet dsTimer =new DataSet();
                dsTimer = CLS_C.fnQuerySelectDs("select (timeallowted/(60*60)) as Hours, ((timeallowted%(60*60))/60) as Minutes,((timeallowted%(60*60))%60)as Seconds from Screeningset where ScrId=" + Convert.ToInt32(hdnScrId.Value));
                if (dsTimer != null)
               {
                   if (dsTimer.Tables != null)
                   {
                       if (dsTimer.Tables[0].Rows != null)
                       {
                           if (dsTimer.Tables[0].Rows.Count > 0)
                           {
                               try
                               {
                                   if (string.IsNullOrEmpty(ViewState["CountTime"].ToString()))
                                   {
                                       ViewState["CountTime"] = "TRUE";
                                       timerDisplaySpan.Text = (Convert.ToInt32(dsTimer.Tables[0].Rows[0]["Hours"].ToString())).ToString("#00") + ":" + (Convert.ToInt32(dsTimer.Tables[0].Rows[0]["Minutes"].ToString())).ToString("#00") + ":" + (Convert.ToInt32(dsTimer.Tables[0].Rows[0]["Seconds"].ToString())).ToString("#00");
                                   }
                               }
                               catch (Exception ex)
                               {
                                   ViewState["CountTime"] = "TRUE";

                                   timerDisplaySpan.Text = (Convert.ToInt32(dsTimer.Tables[0].Rows[0]["Hours"].ToString())).ToString("#00") + ":" + (Convert.ToInt32(dsTimer.Tables[0].Rows[0]["Minutes"].ToString())).ToString("#00") + ":" + (Convert.ToInt32(dsTimer.Tables[0].Rows[0]["Seconds"].ToString())).ToString("#00");

                               }
                              //strTimeAllocated=dsTimer.Tables[0].Rows[0]["timeallowted"].ToString();
                               
                               //timeAllocated.Value = Convert.ToInt32(strTimeAllocated).ToString();
                           }
                       }
                   }
               }


                hdnFileName.Value = "ExamFile/" + Guid.NewGuid().ToString().GetHashCode().ToString("x") + ".xml";
                if (backtoreview == "0")
                {
                    BindQuestionList();
                }
                else if (backtoreview == "1")
                {
                    BindQuestionListwithsession();
                }


            }
            else
            {
                timeAllocated.Value = timeAllocated.Value;
                int q = 0;
                q = Convert.ToInt32(lblQues.Text);
                //if (q == 16)
                //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 2');</script>");
                //else if (q == 22)
                //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 3');</script>");

                //if (hdnNxtPrv.Value == "N")
                //{
                //    q++;
                //}
                //else if (hdnNxtPrv.Value == "P")
                //{
                //    q--;
                //}
                //if (q == 16 && hdnChk.Value == "0")
                //{
                //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 2');</script>");
                //    hdnChk.Value = "1";
                //}
                //else if (q == 22 && hdnChk.Value == "0")
                //{
                //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 3');</script>");
                //    hdnChk.Value = "1";
                //}
                //else
                //    hdnChk.Value = "0";

            }
            BindQuestionListwithsession();

            //bindsection();
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
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.QuestionId = QuestionId;
            tp.MessagePacket = (object)objLIBScreening;

            dss = objDalScreening.GetQuestionOptionList2(tp);
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
            DataSet ds2 = new DataSet();
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            TransportationPacket tp = new TransportationPacket();
            objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
            objLIBScreening.UserId = hdnUserId.Value.ToString();
            tp.MessagePacket = (object)objLIBScreening;

            ds2 = objDalScreening.GetBalQuestionList(tp);

           

            //DLSTSECTION.DataSource = ds2;
            //DLSTSECTION.DataBind();
            //objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            //  ViewState["ds"] = ds2;
            //DataSet ds = (DataSet)  ViewState["ds"];
            this.XMLSerializeMyBasicCObject(Server.MapPath(hdnFileName.Value), ds2);
            dlsquestion.DataSource = ds2;
            dlsquestion.DataBind();

            bindquesbysection(ds2);
            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = ds2.Tables[0].DefaultView;
            objPds.AllowPaging = true;
            objPds.PageSize = 1;

            objPds.CurrentPageIndex = CurrentPage;
            Session["backsearchpage"] = CurrentPage;

            btnprev.Visible = !objPds.IsFirstPage;
            btnnext.Visible = !objPds.IsLastPage;
            

            dlsquestion.DataSource = objPds;
            dlsquestion.DataBind();

            lblqueno.Text = " " + CurrentPage+1 + " of " + ds2.Tables[0].Rows.Count;

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
    public void WriteBinary(string FileName, DataSet ds)
    {
        ds.RemotingFormat = SerializationFormat.Binary;
        IFormatter myFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        using (Stream myStream = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite))
        {
            myFormatter.Serialize(myStream, ds);
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
    public DataSet ReadBinary(string FileName)
    {
        DataSet ds = new DataSet();
        ds.RemotingFormat = SerializationFormat.Binary;
        IFormatter myFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        using (Stream myStream = new FileStream(FileName, FileMode.Open))
        {
            ds = (DataSet)myFormatter.Deserialize(myStream);
        }
        return ds;
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
    protected void BindQuestionListwithsession()
    {
        try
        {
            //if (Session["ReviewPageNo"]!=null)
            //{
            //    CurrentPage =Convert.ToInt32(Session["ReviewPageNo"].ToString());
            //}
            //DataSet ds = (DataSet)  ViewState["ds"];

            //DLSTSECTION.DataSource = ds;
            //DLSTSECTION.DataBind();


            //dlsquestion.DataSource = ds;
            //dlsquestion.DataBind();
            if (Session.Count > 0)
            {

            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('System idle for more than 30 min.Please contact Programme Coordinator to reset the exam ');</script>");
                //return;
            }
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
            btnEndScreening.Visible = objPds.IsLastPage;

            dlsquestion.DataSource = objPds;
            dlsquestion.DataBind();
            bindquesbysection(ds);
            int pgno = Convert.ToInt32(CurrentPage)+1;
            lblqueno.Text = " " + pgno + " of " + ds.Tables[0].Rows.Count;

            if (dlsquestion.Items.Count == 0)
            {
                tbl.Visible = false;
            }
            if (dlsquestion.Items.Count == 0)
            {
                tbl.Visible = true;
            }
            bindsection();
            VisiblityPrevious();
        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }


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
                Panel panel = (Panel)e.Item.FindControl("panel");
                Panel panel1 = (Panel)e.Item.FindControl("panel1");

                // added by chhaya for image questions
                HiddenField hdnImagepath = (HiddenField)e.Item.FindControl("hdnImagepath");
                Image imgQue = (Image)e.Item.FindControl("imgQue");
                if (hdnImagepath.Value != "")
                {
                    imgQue.ImageUrl = "~/Admin/UploadQuestionImage/" + hdnImagepath.Value;
                    imgQue.Visible = true;
                }
                else
                {
                    imgQue.Visible = false;
                }

                LIBScreening objLIBScreening = new LIBScreening();
                DALScreening objDalScreening = new DALScreening();
                LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBScreening.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                tp.MessagePacket = (object)objLIBScreening;

                tp = objDalScreening.GetQuestionOptionListByOptionType(tp);
                objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
                string strOptType = objLibScreeningListing[0].OPTIONTYPE;

                  DataSet dsSection= new DataSet();
                          int toSection=0;
                          dsSection = CLS_C.fnQuerySelectDs("select c.categoryname as category from Screeningquestions q inner join Screening_category c on c.categoryid=q.categoryid where questionid=" + Convert.ToInt32(hdnQuestionId.Value));
                          string SectionText = " ";
                          if (dsSection != null)
                          {
                              if (dsSection.Tables != null)
                              {
                                  if (dsSection.Tables[0].Rows != null)
                                  {
                                      if (dsSection.Tables[0].Rows.Count > 0)
                                     {
                                         SectionText = dsSection.Tables[0].Rows[0]["category"].ToString();
                                      }
                                  }
                              }
                          }



                          Label lblSectionInformation = (Label)e.Item.FindControl("lblSectionInfo");
                          //if (SectionText == "Section1")

                          if (hdnQUESTYPE.Value == "Subjective")
                          {
                              lblSectionInformation.Text = "(Short Answer Questions)";
                          }
                          else if (hdnQUESTYPE.Value == "Descriptive2")
                          {
                              lblSectionInformation.Text = "(Descriptive Questions)";
                          }
                          else if (hdnQUESTYPE.Value == "Descriptive")
                          {
                              lblSectionInformation.Text = "(Descriptive Questions (Upload file option))";
                          }
                          else if (hdnQUESTYPE.Value == "Image Question")
                          {
                              lblSectionInformation.Text = "(Descriptive Questions (Table))";
                          }
                          else if (hdnQUESTYPE.Value == "Fill Blank")
                          {
                              lblSectionInformation.Text = "(Fill in the Blanks)";
                          }
                          else if (hdnQUESTYPE.Value == "Objective")
                          {
                              lblSectionInformation.Text = "(Objective Question)";
                          }
                          else
                          {
                              lblSectionInformation.Text = "(" + hdnQUESTYPE.Value + ")";
                          }

                         Label labelRowID = (Label)e.Item.FindControl("lblRowID");
                          //int Quesnum = Convert.ToInt32();
                          lblQues.Text = labelRowID.Text;

                        //ImageButton imgNButton = (ImageButton)e.Item.FindControl("btnnext");

                        //if (Quesnum == 16)
                        //    imgNButton.ImageUrl = "images/Review_mark.png";
                        //else if (Quesnum == 7)
                        //    imgNButton.ImageUrl = "images/Review_mark.png";


                  


                
                // bind value in sub grid for case study

               if (hdnQUESTYPE.Value == "Case Study" || hdnQUESTYPE.Value == "Fill Blank")
                {
                    DataList gv = new DataList();
                    gv = (DataList)e.Item.FindControl("dlSubsquestion");
                    try
                    {
                        LIBScreening objLIBScreening2 = new LIBScreening();
                        DALScreening objDalScreening2 = new DALScreening();
                        LIBScreeningListing objLibScreeningListing2 = new LIBScreeningListing();
                        TransportationPacket tp2 = new TransportationPacket();
                        objLIBScreening2.QuestionId = Convert.ToInt32(Utility.CheckNullString(hdnQuestionId.Value));
                        tp2.MessagePacket = (object)objLIBScreening;
                        tp = objDalScreening2.GetSubQuestionList(tp2);
                        objLibScreeningListing2 = (LIBScreeningListing)tp.MessageResultset;
                        gv.DataSource = objLibScreeningListing2;
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
                    lblHeading.CssClass = "style5";

                    fileup.ID = ("flu" + Convert.ToInt32(hdnQuestionId.Value));
                    fileup.Width = 200;
                    fileup.Height = 20;
                    fileup.CssClass = "style5";
                    TextBox txtb = new TextBox();

                    txtb.ID = ("txt" + Convert.ToInt32(hdnQuestionId.Value));
                    //txtb.Width = 200;
                    //txtb.Height = 20;
                    //txtb.CssClass = "styletxt";
                    txtb.TextMode = TextBoxMode.MultiLine;
                    //txtb.MaxLength = 7900;
                    txtb.CssClass = "styletxt";
                    txtb.Width = 490;
                    txtb.Height = 180;
                    txtb.Attributes.Add("onKeyDown", "return textboxMultilineMaxNumberDes(this,event);");
                    panel.Controls.Add(txtb);

                    panel1.Controls.Add(lblHeading);
                    panel1.Controls.Add(fileup);
                    anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                    //txtb.Text = anstext;

                    //wahid
                    txtb.Text = anstext.Replace("<br>", "\r\n"); 


                    //panel.Controls.Add(lbl);
                    //panel.Controls.Add(btnupload);

                }

               else if (hdnQUESTYPE.Value == "Descriptive2")
               {

                   FileUpload fileup = new FileUpload();
                   Label lblHeading = new Label();
                   lblHeading.Text = "Upload File";
                   lblHeading.CssClass = "style5";

                   fileup.ID = ("flu" + Convert.ToInt32(hdnQuestionId.Value));
                   fileup.Width = 200;
                   fileup.Height = 20;
                   fileup.CssClass = "style5_2";
                   TextBox txtb = new TextBox();

                   txtb.ID = ("txt" + Convert.ToInt32(hdnQuestionId.Value));
                   //txtb.Width = 200;
                   //txtb.Height = 20;
                   //txtb.CssClass = "styletxt";
                   txtb.TextMode = TextBoxMode.MultiLine;
                   //comment by mala on 1 DEc2012
                   //txtb.MaxLength = 15000;
                   txtb.CssClass = "styletxt";
                   txtb.Width = 490;
                   txtb.Height = 180;

                   panel.Controls.Add(txtb);
                   txtb.Attributes.Add("onKeyDown", "return textboxMultilineMaxNumberDes(this,event);");

                   panel1.Controls.Add(lblHeading);
                   panel1.Controls.Add(fileup);
                   anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                   //txtb.Text = anstext;

                   //wahid
                   txtb.Text = anstext.Replace("<br>", "\r\n");
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
                            LIBScreening objLIBScreening1 = new LIBScreening();
                            DALScreening objDalScreening1 = new DALScreening();
                            LIBScreeningListing objLibScreeningListing1 = new LIBScreeningListing();
                            TransportationPacket tp1 = new TransportationPacket();
                            objLIBScreening1.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                            tp1.MessagePacket = (object)objLIBScreening1;

                            tp1 = objDalScreening1.GetQuestionOptionListByOptionTypeAll(tp);
                            objLibScreeningListing1 = (LIBScreeningListing)tp.MessageResultset;
                            RadioButtonList rd = new RadioButtonList();
                            rd.ID = ("opt" + Convert.ToInt32(hdnQuestionId.Value));
                            rd.Width = 490;
                            rd.CssClass = "style5";
                            rd.RepeatDirection = RepeatDirection.Vertical;
                            rd.RepeatLayout = RepeatLayout.Flow;
                            rd.DataSource = objLibScreeningListing1;
                            rd.DataTextField = objLIBScreening1.OPTIONSDisplayText;
                            rd.DataValueField = objLIBScreening1.OPTIONSValueField;
                            rd.DataBind();

                            panel.Controls.Add(rd);
                            anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                            rd.Items.FindByText(anstext).Selected = true;
                            //bool rewiew = BindReview(Convert.ToInt32(hdnQuestionId.Value));
                            //if (rewiew == true)
                            //{
                            //    ChkReview.Checked = true;
                            //}
                            //else
                            //{
                            //    ChkReview.Checked = false;
                            //}


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
                            LIBScreening objLIBScreening1 = new LIBScreening();
                            DALScreening objDalScreening1 = new DALScreening();
                            LIBScreeningListing objLibScreeningListing1 = new LIBScreeningListing();
                            TransportationPacket tp1 = new TransportationPacket();
                            objLIBScreening1.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                            tp1.MessagePacket = (object)objLIBScreening1;

                            tp1 = objDalScreening1.GetQuestionOptionListByOptionTypeAll(tp);
                            objLibScreeningListing1 = (LIBScreeningListing)tp.MessageResultset;
                            CheckBoxList chk = new CheckBoxList();
                            chk.ID = ("chk" + Convert.ToInt32(hdnQuestionId.Value));
                            chk.Width = 490;
                            chk.CssClass = "style5";
                            chk.RepeatDirection = RepeatDirection.Vertical;
                            chk.RepeatLayout = RepeatLayout.Flow;
                            chk.DataSource = objLibScreeningListing1;
                            chk.DataTextField = objLIBScreening1.OPTIONSDisplayText;
                            chk.DataValueField = objLIBScreening1.OPTIONSValueField;
                            chk.DataBind();

                            panel.Controls.Add(chk);
                            try
                            {
                                LIBScreening objLIBScreening2 = new LIBScreening();
                                DALScreening objDalScreening2 = new DALScreening();
                                LIBScreeningListing objLibScreeningListing2 = new LIBScreeningListing();
                                objLIBScreening2.ScrId = Convert.ToInt32(hdnScrId.Value);
                                objLIBScreening2.UserId = hdnUserId.Value;
                                objLIBScreening2.QuestionId = Convert.ToInt16(hdnQuestionId.Value);

                                TransportationPacket tp2 = new TransportationPacket();
                                tp2.MessagePacket = (object)objLIBScreening2;
                                tp2 = objDalScreening2.GetAnsText(tp2);
                                objLibScreeningListing2 = (LIBScreeningListing)tp2.MessageResultset;
                                for (int i = 0; i < objLibScreeningListing2.Count; i++)
                                {

                                    chk.Items.FindByText(objLibScreeningListing2[i].AnsText).Selected = true;

                                }


                            }
                            catch (Exception ex)
                            {
                                HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                            }

                            //chk.Items.FindByText(anstext).Selected = true;
                            //bool rewiew = BindReview(Convert.ToInt32(hdnQuestionId.Value));
                            //if (rewiew == true)
                            //{
                            //    ChkReview.Checked = true;
                            //}
                            //else
                            //{
                            //    ChkReview.Checked = false;
                            //}


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
                        //txtb.Width = 200;
                        //txtb.Height = 20;
                        
                        panel.Controls.Add(txtb);

                        anstext = BindAnsText(Convert.ToInt32(hdnQuestionId.Value));
                        //wahid
                        txtb.Text = anstext.Replace("<br>", "\r\n"); 

                        //txtb.Text = anstext;
                        txtb.TextMode =TextBoxMode.MultiLine;
                        txtb.CssClass = "styletxt";
                       // txtb.MaxLength = 7900;
                        txtb.Width = 490;
                        txtb.Height = 180;
                        txtb.Attributes.Add("onKeyDown", "return textboxMultilineMaxNumber(this,event);");
                        //bool rewiew = BindReview(Convert.ToInt32(hdnQuestionId.Value));
                        //if (rewiew == true)
                        //{
                        //    ChkReview.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkReview.Checked = false;
                        //}

                    }
                }

               


                
            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
    protected void dlSubsquestion_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            string anstext;

            DataListItem rowF = e.Item;
            if (rowF.ItemType != null)
            {
                HiddenField hdnQuestionId = (HiddenField)e.Item.FindControl("hdnSubQuestionId");

                Panel panel = (Panel)e.Item.FindControl("panel");

                LIBScreening objLIBScreening = new LIBScreening();
                DALScreening objDalScreening = new DALScreening();
                LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
                TransportationPacket tp = new TransportationPacket();
                objLIBScreening.SubQuestionId = Convert.ToInt32(hdnQuestionId.Value);
                tp.MessagePacket = (object)objLIBScreening;

                tp = objDalScreening.GetSubQuestionOptionListByOptionType(tp);
                objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
                string strOptType = objLibScreeningListing[0].OPTIONTYPE;


                // create dynamic control in grid view
                if (strOptType == "Radio Button")
                {

                    try
                    {
                        LIBScreening objLIBScreening1 = new LIBScreening();
                        DALScreening objDalScreening1 = new DALScreening();
                        LIBScreeningListing objLibScreeningListing1 = new LIBScreeningListing();
                        TransportationPacket tp1 = new TransportationPacket();
                        objLIBScreening1.SubQuestionId = Convert.ToInt32(hdnQuestionId.Value);
                        tp1.MessagePacket = (object)objLIBScreening1;

                        tp1 = objDalScreening1.GetSubQuestionOptionListByOptionTypeAll(tp);
                        objLibScreeningListing1 = (LIBScreeningListing)tp.MessageResultset;
                        RadioButtonList rd = new RadioButtonList();
                        rd.ID = ("opt" + "_" + Convert.ToInt32(hdnQuestionId.Value));
                        rd.Width = 490;
                        rd.CssClass = "style5";
                        rd.RepeatDirection = RepeatDirection.Vertical;
                        rd.RepeatLayout = RepeatLayout.Flow;
                        rd.DataSource = objLibScreeningListing1;
                        rd.DataTextField = objLIBScreening1.OPTIONSDisplayText;
                        rd.DataValueField = objLIBScreening1.OPTIONSValueField;
                        rd.DataBind();

                        panel.Controls.Add(rd);
                        anstext = BindsubAnsText(Convert.ToInt32(hdnQuestionId.Value));
                        if (anstext == "")
                        {
                        }
                        else
                        {
                            rd.Items.FindByText(anstext).Selected = true;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        HandleException.ExceptionLogging(ex.Source, ex.Message, true);
                    }
                }
                else //if (strOptType == "TextBox")
                {
                    TextBox txtb = new TextBox();
                    txtb.ID = ("txt" + "_" + Convert.ToInt32(hdnQuestionId.Value));
                    //txtb.Width = 200;
                    //txtb.Height = 20;
                    txtb.TextMode = TextBoxMode.MultiLine;
                    txtb.CssClass = "styletxt";
                    txtb.MaxLength = 7900;
                    txtb.Width = 490;
                    txtb.Height = 180;
                    panel.Controls.Add(txtb);
                    anstext = BindsubAnsText(Convert.ToInt32(hdnQuestionId.Value));
                    if (anstext=="")
                    {
                    }
                    else
                    {  //wahid
                        txtb.Text = anstext.Replace("<br>", "\r\n"); 

                        //txtb.Text = anstext;
                    }
                    
                }
               


            }

        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
    }
  
    protected void btnnext_Click(object sender, ImageClickEventArgs e)
    {
        btnprev.Visible = true;
        
        HiddenField hdnCategoryIdQuesold = (HiddenField)dlsquestion.Items[0].FindControl("hdnCategoryId");

        getans();


        CurrentPage += 1;
        ChkReview.Checked = false;
        BindQuestionListwithsession();

         hdnCategoryIdQuesnew = (HiddenField)dlsquestion.Items[0].FindControl("hdnCategoryId");
         Label lblSectionInformation = (Label)dlsquestion.Items[0].FindControl("lblSection");
         string sectionName = lblSectionInformation.Text;
         if (hdnCategoryIdQuesold.Value != hdnCategoryIdQuesnew.Value)
         {
           //  lblSection.Text = sectionName;
             ClientScript.RegisterStartupScript(this.GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>confirmmsg();</script>");
             //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>confirm('You are now proceeding to " + sectionName + "');</script>");
            
             pnlqueslist.Visible = false;
             pnlinstruction.Visible = true;
             
             BindInstructiondata(hdnCategoryIdQuesnew.Value);

         }
        else
        {

            pnlqueslist.Visible = true;
            pnlinstruction.Visible = false;
        }


        
       


        HiddenField hdnQuestionId = (HiddenField)dlsquestion.Items[0].FindControl("hdnQuestionId");
        bool rewiew = BindReview(Convert.ToInt32(hdnQuestionId.Value));
        if (rewiew == true)
        {
            ChkReview.Checked = true;
        }
        else
        {
            ChkReview.Checked = false;
       }

       
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

               // GridView gvRef = (GridView)sender;


                // fatch value frim inner grid view
                //GridView opt2 = (GridView)gvRef.Rows[0].FindControl("gvSubQuestionList");

                //HiddenField hdnSubQuestionId = (HiddenField)opt2.Rows[0].FindControl("hdnSubQuestionId");
                HiddenField hdnQUESTYPE = (HiddenField)dlsquestion.Items[0].FindControl("hdnQUESTYPE");
                HiddenField hdnQuestionId = (HiddenField)dlsquestion.Items[0].FindControl("hdnQuestionId");
                HiddenField hdnOptionType = (HiddenField)dlsquestion.Items[0].FindControl("hdnOPTIONTYPE");
                HiddenField hdnCategoryId = (HiddenField)dlsquestion.Items[0].FindControl("hdnCategoryId");
                string checkmaxlimit = "0";
                if (hdnQUESTYPE.Value == "Case Study" || hdnQUESTYPE.Value == "Fill Blank") // code for case study data submit
                   {
                    int quesid1=Convert.ToInt32(hdnQuestionId.Value);
                    int ScrId=Convert.ToInt32(hdnScrId.Value);
                     int categoryid=Convert.ToInt32(hdnCategoryId.Value);
                    int maxattempque = getmaxattempque(ScrId,categoryid);
                     int maxlimitque = getmaxLimitque(ScrId,categoryid,quesid1);
                     if (maxattempque <= maxlimitque)
                     {
                         if (maxattempque == maxlimitque)
                         {

                            // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + maxlimitque + " in this section');</script>");
                                 return;
                         }
                         
                         DALScreening objDalScreening = new DALScreening();
                         DataSet ds = new DataSet();

                         ds = objDalScreening.GetSubQuestionListByScrId((Convert.ToInt16(hdnQuestionId.Value)));

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
                                                 LIBScreening objLibScreening = new LIBScreening();
                                                 DALScreening OBJDALScreening = new DALScreening();
                                                 TransportationPacket tp = new TransportationPacket();
                                                 objLibScreening.UserId = hdnUserId.Value;
                                                 objLibScreening.AnsText = strVal;
                                                 objLibScreening.BatchId = Convert.ToInt16(hdnBid.Value);
                                                 objLibScreening.SubQuestionId = QuesId;
                                                 objLibScreening.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                                                 objLibScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                                                 objLibScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                                                 tp.MessagePacket = (object)objLibScreening;

                                                 checkmaxlimit = OBJDALScreening.CheckMaxLimit(tp);
                                                 //if (checkmaxlimit == "0")
                                                 //{
                                                 addResult = OBJDALScreening.SubmitSubScreeningAns(tp);
                                                 // addResult = OBJDALScreening.SubmitScreeningAns(tp);
                                           if (addResult == -11)
                                                
                                                 {
                                                     //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit  + " in this section');</script>");
                                                     ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section.If you have answered more than " + checkmaxlimit + " questions, then the last question attempted by you will be considered invalid.Click on OK to proceed');</script>");
                                                 }
                                                 //else
                                                 //{
                                                 //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt only " + checkmaxlimit + " question'); </script>");
                                                 //}



                                             }

                                         }
                                     }
                                 }

                             }

                         }


                     }
                }


                else if (hdnQUESTYPE.Value == "Descriptive")
                {
                    string option = "";
                    string fileup = "flu" + Convert.ToInt32(hdnQuestionId.Value);

                    string text = Convert.ToInt32(hdnQuestionId.Value) + "-" + hdnScrId.Value + "-" + hdnUserId.Value +DateTime.Now.ToString("HHmm");

                    string uploadFolder = Request.PhysicalApplicationPath + "Student\\UploadScreeningExam\\";
                    foreach (DataListItem gv in dlsquestion.Items)
                    {
                        FileUpload FileUpload1 = (FileUpload)gv.FindControl(fileup);
                        string CtrlId = "txt" + Convert.ToInt32(hdnQuestionId.Value);
                        string strOptType = "";
                        string strVal = fngetValueofCtrl(CtrlId, strOptType);
                        string path = "";
                        if (FileUpload1.HasFile || strVal != "")
                        {

                            if (FileUpload1.HasFile)
                            {

                                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                        FileUpload1.SaveAs(uploadFolder + text + extension);
                                path = uploadFolder + text + extension;
                                //}
                            }




                            

                            //if (strVal != "" || FileUpload1.HasFile)
                            //{
                            LIBScreening objLibScreening = new LIBScreening();
                            DALScreening OBJDALScreening = new DALScreening();
                            TransportationPacket tp = new TransportationPacket();
                            objLibScreening.UserId = hdnUserId.Value; 
                            objLibScreening.AnsText = strVal;
                            if (ChkReview.Checked == true)
                            {
                                objLibScreening.Review = true;
                            }
                            else
                            {
                                objLibScreening.Review = false;
                            }
                            objLibScreening.UploadAnsPath = path;
                            objLibScreening.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
                            objLibScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                            objLibScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                            objLibScreening.BatchId = Convert.ToInt16(hdnBid.Value);
                            objLibScreening.Option = option;
                            tp.MessagePacket = (object)objLibScreening;
                            checkmaxlimit = OBJDALScreening.CheckMaxLimit(tp);
                            
                            ////if (checkmaxlimit == "0")
                            ////{
                                //addResult = OBJDALScreening.SubmitScreeningAns(tp);
                                addResult = OBJDALScreening.SubmitScreeningAns(tp);
                              if (addResult == -11)
                               
                                {
                                    ////ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Maximum Question limit is exceed');</script>");
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section.If you have answered more than " + checkmaxlimit + " questions, then the last question attempted by you will be considered invalid.Click on OK to proceed');</script>");
                                  // ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section');</script>");
                                }
                            //else
                            //{
                            //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt only " + checkmaxlimit + " question'); </script>");
                            //}

                        }
                    }

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
                        LIBScreening objLibScreening = new LIBScreening();
                        DALScreening OBJDALScreening = new DALScreening();
                        TransportationPacket tp = new TransportationPacket();
                        //objLibScreening.UserId = hdnUserId.Value;
                        objLibScreening.AnsText = strVal;
                        objLibScreening.Option = option;
                        if (ChkReview.Checked == true)
                        {
                            objLibScreening.Review = true;
                        }
                        else
                        {
                            objLibScreening.Review = false;
                        }
                        objLibScreening.QuestionId = QuesId;
                        objLibScreening.UploadAnsPath = "";
                        objLibScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                        objLibScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                        objLibScreening.UserId = hdnUserId.Value;
                        objLibScreening.BatchId = Convert.ToInt16(hdnBid.Value);
                        tp.MessagePacket = (object)objLibScreening;
                        // check max limit

                        checkmaxlimit = OBJDALScreening.CheckMaxLimit(tp);

                        addResult = OBJDALScreening.SubmitScreeningAns(tp);
                    if (addResult == -11)

                        {
                            ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section.If you have answered more than " + checkmaxlimit + " questions, then the last question attempted by you will be considered invalid.Click on OK to proceed');</script>");
                          //  ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You can attempt maximum " + checkmaxlimit + " in this section');</script>");
                        }



                    }
                    else if (strVal != "")
                    {
                        LIBScreening objLibScreening = new LIBScreening();
                        DALScreening OBJDALScreening = new DALScreening();
                        TransportationPacket tp = new TransportationPacket();
                        objLibScreening.QuestionId = QuesId;
                        objLibScreening.UploadAnsPath = "";
                        objLibScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                        objLibScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                        objLibScreening.UserId = hdnUserId.Value;
                        objLibScreening.BatchId = Convert.ToInt16(hdnBid.Value);
                        objLibScreening.Option = option;
                        tp.MessagePacket = (object)objLibScreening;
                        OBJDALScreening.DeleteCheckboxScreeningAns(tp);


                        String[] strValu = strVal.Split(',');


                        for (int i = 0; i < (strValu.Length - 1); i++)
                        {



                            objLibScreening.AnsText = strValu[i].ToString();
                            objLibScreening.Option = option;
                            if (ChkReview.Checked == true)
                            {
                                objLibScreening.Review = true;
                            }
                            else
                            {
                                objLibScreening.Review = false;
                            }
                            objLibScreening.QuestionId = QuesId;
                            objLibScreening.UploadAnsPath = "";
                            objLibScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                            objLibScreening.CategoryID = Convert.ToInt32(hdnCategoryId.Value);
                            objLibScreening.UserId = hdnUserId.Value;
                            objLibScreening.BatchId = Convert.ToInt16(hdnBid.Value);
                            objLibScreening.Option = option;
                            tp.MessagePacket = (object)objLibScreening;
                            // check max limit

                            checkmaxlimit = OBJDALScreening.CheckMaxLimit(tp);

                            addResult = OBJDALScreening.SubmitScreeningAns(tp);
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

    protected void btnprev_Click1(object sender, ImageClickEventArgs e)
    {
        HiddenField hdnCategoryIdQuesold = (HiddenField)dlsquestion.Items[0].FindControl("hdnCategoryId");
        Label lblSectionInformation = (Label)dlsquestion.Items[0].FindControl("lblSection");
        getans();
        CurrentPage -= 1;
      
        BindQuestionListwithsession();
        hdnCategoryIdQuesnew = (HiddenField)dlsquestion.Items[0].FindControl("hdnCategoryId");
       
        string sectionName = lblSectionInformation.Text;
        if (hdnCategoryIdQuesold.Value != hdnCategoryIdQuesnew.Value)
        {
            //lblSection.Text = sectionName;
            pnlqueslist.Visible = false;
            pnlinstruction.Visible = true;
            BindInstructiondata(hdnCategoryIdQuesold.Value);
            CurrentPage += 1;

            BindQuestionListwithsession();

        }
        else
        {

            pnlqueslist.Visible = true;
            pnlinstruction.Visible = false;
        }

        HiddenField hdnQuestionId = (HiddenField)dlsquestion.Items[0].FindControl("hdnQuestionId");
        bool rewiew = BindReview(Convert.ToInt32(hdnQuestionId.Value));
        if (rewiew == true)
        {
            ChkReview.Checked = true;
        }
        else
        {
            ChkReview.Checked = false;
        }
        //hdnNxtPrv.Value = "P";
        int q = 0;
        q = Convert.ToInt32(lblQues.Text);
        //q--;

        //if (q == 16 && hdnChk.Value == "0")
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 2');</script>");
        //    hdnChk.Value = "1";
        //}
        //else if (q == 22 && hdnChk.Value == "0")
        //{
        //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 3');</script>");
        //    hdnChk.Value = "1";
        //}
        //else
        //    hdnChk.Value = "0";
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
                else
                {
                    TextBox txt = (TextBox)gv.FindControl(strId);

                    if (txt != null)
                    {
                        strValue = txt.Text.Replace("\r\n", "<br>");
                        //strValue = txt.Text;
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
                            strValue = txt.Text.Replace("\r\n", "<br>");
                            //strValue = txt.Text;
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

    protected string BindAnsText(int questionid)
    {
        string addResult = "";
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
            objLIBScreening.UserId = hdnUserId.Value;
            objLIBScreening.QuestionId = questionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBScreening;
            tp = objDalScreening.GetAnsText(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            if (objLibScreeningListing != null)
            {

                if (objLibScreeningListing.Count > 0)
                {

                    addResult = objLibScreeningListing[0].AnsText;
                    //bool chk = objLibScreeningListing[0].Review;
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

    protected bool BindReview(int questionid)
    {
        bool review = false;
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
            objLIBScreening.UserId = hdnUserId.Value;
            objLIBScreening.QuestionId = questionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBScreening;
            review = objDalScreening.GetReviewMark(tp);
            


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return review;

    }
    protected string BindsubAnsText(int Subquestionid)
    {
        string addResult = "";
        try
        {
            LIBScreening objLIBScreening = new LIBScreening();
            DALScreening objDalScreening = new DALScreening();
            LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
            objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
            objLIBScreening.UserId = hdnUserId.Value;
            objLIBScreening.SubQuestionId = Subquestionid;

            TransportationPacket tp = new TransportationPacket();
            tp.MessagePacket = (object)objLIBScreening;
            tp = objDalScreening.GetSubQuestionAnsText(tp);
            objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
            if (objLibScreeningListing != null)
            {

                if (objLibScreeningListing.Count > 0)
                {
                    addResult = objLibScreeningListing[0].AnsText;
                }
            }


        }
        catch (Exception ex)
        {
            HandleException.ExceptionLogging(ex.Source, ex.Message, true);
        }
        return addResult;

    }
   
    protected void btnReview_Click(object sender, ImageClickEventArgs e)
    {
        //string currentpageReview = CurrentPage.ToString();
        //Session["ReviewPageNo"] = currentpageReview;
           
      //  Response.Redirect("ReviewMarkedQuestion.aspx?ScrId=" + hdnScrId.Value + " &Userid=" + "1");
        
    }
    protected void bindsection()
    {
        if (DLSTSECTION.Items.Count > 0)
        {
            for (int i = 0; i < DLSTSECTION.Items.Count; i++)
            {
                try
                {

                    LinkButton lnkbtncatgno = (LinkButton)DLSTSECTION.Items[i].FindControl("lnkbtncatgno");
                    HiddenField hdnQuestionId = (HiddenField)DLSTSECTION.Items[i].FindControl("hdnQuestionId");
                    HiddenField lblhead = (HiddenField)DLSTSECTION.Items[i].FindControl("hdnhead");
                    //Label lblsecName = (Label)DLSTSECTION.Items[i].FindControl("lblsecName");
                    secname = lblhead.Value;
                    LIBScreening objLIBScreening = new LIBScreening();
                    DALScreening objDalScreening = new DALScreening();
                    LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
                    LIBScreeningListing objLibScreeningListingSub = new LIBScreeningListing();
                    objLIBScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
                    objLIBScreening.UserId = hdnUserId.Value;
                    objLIBScreening.QuestionId = Convert.ToInt32(hdnQuestionId.Value);

                    TransportationPacket tp = new TransportationPacket();
                    TransportationPacket tpSub = new TransportationPacket();
                    tp.MessagePacket = (object)objLIBScreening;
                    tpSub.MessagePacket = (object)objLIBScreening;
                    tp = objDalScreening.GetAnsText(tp);                    
                    tpSub = objDalScreening.GetSubAnsText(tpSub);

                    objLibScreeningListing = (LIBScreeningListing)tp.MessageResultset;
                    objLibScreeningListingSub = (LIBScreeningListing)tpSub.MessageResultset;
                    if (objLibScreeningListing != null)
                    {

                        if (objLibScreeningListing.Count > 0)
                        {
                            lnkbtncatgno.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    if (objLibScreeningListingSub != null)
                    {

                        if (objLibScreeningListingSub.Count > 0)
                        {
                            lnkbtncatgno.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                }

                catch (Exception ex)
                {
                }
            }
        }
      
    }
    protected void VisiblityPrevious()
    {
        Label lblqueNo = (Label)dlsquestion.Items[0].FindControl("lblRowID");
        if (DLSTSECTION.Items.Count > 0)
        {
            for (int i = 0; i < DLSTSECTION.Items.Count; i++)
            {
                try
                {

                    LinkButton lnkbtncatgno = (LinkButton)DLSTSECTION.Items[i].FindControl("lnkbtncatgno");
                   
                    HiddenField hdnSecQueno = (HiddenField)DLSTSECTION.Items[i].FindControl("hdnSecQueno");
                    if (lblqueNo.Text == lnkbtncatgno.Text && hdnSecQueno.Value == "1")
                    {
                        btnprev.Visible = false;
                        break;

                    }
                   

                }

                catch (Exception ex)
                {
                }
            }
        }

    }
  
    protected void lnkbtncatgno_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName.Equals("pageno"))
        {
            hdnNxtPrv.Value = "";
            getans();
            Label lblquesNo = (Label)dlsquestion.Items[0].FindControl("lblRowID");
            int str = Convert.ToInt32(e.CommandArgument);

            int q = 0;
            q = Convert.ToInt32(str);
            //if (q == 16 && hdnChk.Value == "0")
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 2');</script>");
            //    hdnChk.Value = "1";
            //}
            //else if (q == 22 && hdnChk.Value == "0")
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('You are now proceeding to Section 3');</script>");
            //    hdnChk.Value = "1";
            //}
            //else
            //    hdnChk.Value = "0";

            //lblQues.Text = "0";
            CurrentPage = str - 1;

            BindQuestionListwithsession();

        }
    }

    protected void DLSTSECTION_ItemDataBound(object sender, DataListItemEventArgs e)
    {
       
               
    }
    protected void DLSTSECTION_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected int getmaxattempque(int ScrId,int categoryid)
    {
        int maxattempque = 0;
        LIBScreening objLibScreening = new LIBScreening();
        DALScreening OBJDALScreening = new DALScreening();
        TransportationPacket tp = new TransportationPacket();
        objLibScreening.UserId = hdnUserId.Value;
        objLibScreening.CategoryID = categoryid;
        objLibScreening.ScrId = ScrId;
        tp.MessagePacket = (object)objLibScreening;
        maxattempque = OBJDALScreening.GetMaxAttemptQue(tp);
        return maxattempque;
    }
    protected int getmaxLimitque(int ScrId, int categoryid,int quesid)
    {
        int maxattempque = 0;
        LIBScreening objLibScreening = new LIBScreening();
        DALScreening OBJDALScreening = new DALScreening();
        TransportationPacket tp = new TransportationPacket();
        objLibScreening.UserId = hdnUserId.Value;
        objLibScreening.CategoryID = categoryid;
        objLibScreening.ScrId = ScrId;
        objLibScreening.QuestionId = quesid;
        tp.MessagePacket = (object)objLibScreening;
        string max= OBJDALScreening.CheckMaxLimit(tp);
        maxattempque = Convert.ToInt32(max);
        return maxattempque;
    }
    protected void btnEndScreening_Click(object sender, ImageClickEventArgs e)
    {

        getans();

   



       string nextpage = "EndScreening.aspx?ScrId=" + hdnScrId.Value + "&username=" + hdnUserId.Value;


        Response.Write("<SCRIPT LANGUAGE=javascript>");
        Response.Write("{");

        //Response.Write(" var Backlen=history.length;") ;
        Response.Write(" history.go(1);");

        Response.Write(" window.location.href='" + nextpage + "'; ");
        Response.Write("}");

        Response.Write("</SCRIPT>");
    }

    protected void bindquesbysection(DataSet ds)
    {
        HiddenField hdnCategoryIdQues = (HiddenField)dlsquestion.Items[0].FindControl("hdnCategoryId");
        DataTable dt = new DataTable();
        dt = CreateDataTable();
        if (ds != null)
        {
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows != null)
                {
                    //int j = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int quesno = Convert.ToInt32(ds.Tables[0].Rows[i]["ROWID"].ToString());
                        int questionid = Convert.ToInt32(ds.Tables[0].Rows[i]["QuestionId"].ToString());
                        int CategoryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"].ToString());
                        string CategoryName = (ds.Tables[0].Rows[i]["CategoryName"].ToString());
                        if (Convert.ToInt32(hdnCategoryIdQues.Value) == CategoryId)
                        {
                            //int rowid = j + 1;
                            AddDataToTable(questionid, CategoryId, CategoryName, quesno, dt);
                        }



                    }

                }
            }
        }
        DLSTSECTION.DataSource = dt.DefaultView;
        DLSTSECTION.DataBind();

    }
    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();

        DataColumn myDataColumn;

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.Int32");
        myDataColumn.ColumnName = "QuestionId";

        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.Int32");
        myDataColumn.ColumnName = "CategoryId";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CategoryName";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.Int32");
        myDataColumn.ColumnName = "QuesNo";

        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.Int32");
        myDataColumn.ColumnName = "ROWID";
        myDataColumn.AutoIncrement = true;
        myDataColumn.AutoIncrementSeed = 1;
        myDataTable.Columns.Add(myDataColumn);

        return myDataTable;
    }
    private void AddDataToTable(int queid, int categoryid, string categoryname, int quesno, DataTable myTable)
    {
        DataRow row;

        row = myTable.NewRow();

        row["QuestionId"] = queid;
        row["CategoryId"] = categoryid;
        row["CategoryName"] = categoryname;
        row["QuesNo"] = quesno;
        //row["ROWID"] = rowid;

        myTable.Rows.Add(row);
    }
   
    protected void GetBid()
    {
        LIBScreening objLIBScreening = new LIBScreening();
        DALScreening objDalScreening = new DALScreening();
        LIBScreeningListing objLibScreeningListing = new LIBScreeningListing();
        TransportationPacket tp = new TransportationPacket();
        objLIBScreening.Stid = Convert.ToInt32(Session["stid"]);

        tp.MessagePacket = (object)objLIBScreening;

        hdnBid.Value = Convert.ToString(objDalScreening.GetBid(tp));

    }
    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        btnprev.Visible = false;
        pnlqueslist.Visible = true;
        pnlinstruction.Visible = false;
    }
    protected void BindInstructiondata(string catgid)
    {
        string strQ;

        strQ = "select instructionText from ScreeningStudentInstruction where Scrid=" + hdnScrId.Value + " and categoryid=" + catgid;

        dsInstruction = CLS_C.fnQuerySelectDs(strQ);


    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        HiddenField hdnQUESTYPE = (HiddenField)dlsquestion.Items[0].FindControl("hdnQUESTYPE");
        HiddenField hdnQuestionId = (HiddenField)dlsquestion.Items[0].FindControl("hdnQuestionId");
        HiddenField hdnOptionType = (HiddenField)dlsquestion.Items[0].FindControl("hdnOPTIONTYPE");


        int maxattempque = 0;
        LIBScreening objLibScreening = new LIBScreening();
        DALScreening OBJDALScreening = new DALScreening();
        TransportationPacket tp = new TransportationPacket();
        objLibScreening.UserId = Convert.ToString(hdnUserId.Value);
        objLibScreening.ScrId = Convert.ToInt32(hdnScrId.Value);
        objLibScreening.QuestionId = Convert.ToInt32(hdnQuestionId.Value);
        tp.MessagePacket = (object)objLibScreening;
        maxattempque = OBJDALScreening.DeleteScreeningQuestionanswer(tp);
        BindQuestionListwithsession();

    }
 
}

