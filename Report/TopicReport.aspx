<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="TopicReport.aspx.cs" Inherits="Admin_TopicReport" Title="Topic Report" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Topic Report</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
    
  <script language="javascript" type="text/javascript">
  function myprint()
{   
    window.print();
}

  function closepopup()
{    
    window.close();
}
//function CallPrint(strid)

//{


//var prtContent = document.getElementById(strid);


//var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=1000,status=0');

////WinPrint.document.write("<STYLE><!-- body{width:100%;margin:0;float:none;color: #000000;font-size: 11px;font-family: tahoma;word-spacing:0.5mm;} --></STYLE>");

//WinPrint.document.write(prtContent.innerHTML );

//WinPrint.document.close();

//WinPrint.focus(); 


//WinPrint.print();


////WinPrint.print();

//WinPrint.close();

// prtContent.innerHTML=strOldOne;

function CallPrint(strid)
  {
   var prtContent = document.getElementById(strid);
   var strOldOne=prtContent.innerHTML;
   var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
   WinPrint.document.write(prtContent.innerHTML);
   WinPrint.document.close();
   WinPrint.focus();
   WinPrint.print();
   WinPrint.close();
   prtContent.innerHTML=strOldOne;
  }


//}


    </script>
  
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }
      #form1
      {
          text-align: left;
      }
    </style>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Discussion Topic</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
       <li><a href="ReportList.aspx">Report Panel</a></li>
      <li class="active">Discussion Topic Reports</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div>
                              
                             <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           
                                                        <ContentTemplate>--%>

     

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course Title"  CssClass="form-control" AutoPostBack="True" onselectedindexchanged="ddlCourse_SelectedIndexChanged">
                                                            </asp:DropDownList>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlbatch" runat="server" ToolTip="Batch Code" CssClass="form-control" AutoPostBack="True" onselectedindexchanged="ddlbatch_SelectedIndexChanged" meta:resourcekey="ddlbatchResource1">
                                                              </asp:DropDownList>
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlSemester" runat="server" ToolTip="Semester" CssClass="form-control" AutoPostBack="True" onselectedindexchanged="ddlSemester_SelectedIndexChanged">
                                                           </asp:DropDownList>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlTopic1" runat="server" ToolTip="Topic" CssClass="form-control" AutoPostBack="True" onselectedindexchanged="ddlTopic1_SelectedIndexChanged1">
                                                           </asp:DropDownList>
    </div>
    </div>                             
                                                   
                                                     
  <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton3" runat="server" Text="Back" CssClass="btn btn-large btn-warning"  PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton4" runat="server" Text="Generate Report" CssClass="btn btn-large btn-success" onclick="ImageButton3_Click" />
    </div>
    </div>                                        
   </div>
   <div class="user-info media box" style="background-color:#fff;">
    <div id="print_grid">
                                            <fieldset>
                                            <legend>Topic Report</legend>          
                                             <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblCourse" runat="server" Font-Bold=""   Text="Course Title :"></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblCourseTitle" runat="server" align="left"  ></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lbldate" runat="server" align="Right" Font-Bold=""    Text="Date :"></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblshowdate" runat="server" align="left"   Text=""></asp:Label></div>
                                             </div>
                                             <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblBatch" runat="server" Font-Bold=""   Text="Batch Title :"></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblbatchTitle" runat="server" align="left"  ></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblSemester" runat="server" align="Right" Font-Bold=""   Text="Semester :"></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblSemesterTitle" runat="server" align="left"  ></asp:Label></div>
                                             </div>
                                             <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblTopic" runat="server" Font-Bold=""   Text="Topic :"></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblTopicTitle" runat="server" align="left"  ></asp:Label></div>
                                             <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
                                             </div>
                                             <div class="row" >
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <asp:GridView ID="grdStudentDetails" runat="server" AllowPaging="false" CssClass="table"
                                                                    AlternatingRowStyle-BackColor="#eeeeee" AutoGenerateColumns="False" 
                                                                    EnableModelValidation="True"  HeaderStyle-CssClass="form_head"
                                                                    onpageindexchanging="grdStudentDetails_PageIndexChanging" PageSize="20" 
                                                                    RowStyle-BackColor="#ffffff" Width="100%" 
                                                                    RowStyle-HorizontalAlign="Center" 
                                                                    onrowdatabound="grdStudentDetails_RowDataBound">
                                                                    <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                    <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="red"   ><strong>  !!!No Records Found!!!</strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                                    
                                                                    
                                                                    
                                                                    
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText=""><%-- <ItemStyle  Width="50px" />--%>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStudentName" runat="server" 
                                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Post Reply" ><%--<ItemStyle Width="110px" />--%>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPostReply" runat="server" 
                                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "PostReply")%>'></asp:Label>
                                                                                    
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date OF Posting"><%--<ItemStyle Width="110px" />--%>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDateOfPosting" runat="server" 
                                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "DateOfPosting")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <AlternatingRowStyle BackColor="#EEEEEE" />
                                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                </asp:GridView>
                                                            </div>
                                                            </div>
                                                </fieldset>
                                        </div>
                                     
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" Visible="false" /></div>
    </div>
    </div>
                                                  
    
                                    </section>
                                  <%--    </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                               
                          
       </div>                                                 
    </form>
</asp:Content>
