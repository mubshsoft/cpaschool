<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="StudentLoginReport.aspx.cs" Inherits="Report_StudentLoginReport" Title="Student Login Report" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Student Login Report</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" src="../stmenu.js"></script>
  <script language="javascript" type="text/javascript">


  function closepopup()
{    
    window.close();
}
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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000;   font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828;   height:15px;  }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828;   height:15px;  }
.icon-position
        {
        position: absolute;
        right: 20px;
        top: 10px;
        }
    </style>
     <script language="javascript" type="text/javascript" src="../datetimepicker.js">
    </script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Student Login Report</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
       <li><a href="ReportList.aspx">Report Panel</a></li>
      <li class="active">Student Login Report</li>
		</ul>
	</div>
    </section>
 <div id='popCal' style='POSITION:absolute;visibility:hidden;border:2px ridge;width:10'>
<iframe name="popFrame" src="../UNTITLED.htm" frameborder="0" scrolling="no" width="152" height="147"></iframe>
</div>
    <form id="form1" runat="server">
  
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
  
      
    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" ToolTip="Course" AutoPostBack="True" onselectedindexchanged="ddlcourse_SelectedIndexChanged">
                                                                     </asp:DropDownList>
    </div> 
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlbatch" runat="server" CssClass="form-control" ToolTip="Batch" AutoPostBack="True">
                                                                     </asp:DropDownList>
    </div>
    </div>  
     <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:TextBox ID="txtfrmdt" runat="server" CssClass="form-control" ToolTip="From Activate Date" placeholder="From Activate Date"></asp:TextBox>
    <a href="javascript:NewCal('<%= txtfrmdt.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:TextBox ID="txttodt" runat="server" CssClass="form-control" ToolTip="To Activate Date" placeholder="To Activate Date"></asp:TextBox>
    <a href="javascript:NewCal('<%= txttodt.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
    </div>
    </div>     
                                                                                                      
                                                   <%--<asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="11px" Text="Course :"></asp:Label>
                                                   <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="11px" Text="Batch :"></asp:Label>--%>
                                                                        
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <hr />
    <asp:Button ID="ImageButton4" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton3" runat="server" Text="Generate report" CssClass="btn btn-large btn-success" onclick="ImageButton3_Click" />
    </div>
    </div>
    </div>
    <div class="user-info media box" style="background-color:#fff;">
     <div id="print_grid" runat="server" visible="false">
                                     <fieldset>
                                            <legend>Student Login Report</legend>
                                           <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>To Date :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lbltoactivatedt" runat="server" ></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>Course Code :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblCourseCode" runat="server" ></asp:Label></div>
                                            </div>
                                            <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>From&nbsp; Date :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblactivatedt" runat="server" ></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>Batch Code :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblBatchCode" runat="server" ></asp:Label></div>
                                            </div>
                                            <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>Date :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblShowDate" runat="server" ></asp:Label></div>
                                             <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
                                            </div>
                                         <div class="row" >
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" CssClass="table" 
                                                    Width="100%"  AllowPaging="false"   
                                                     HeaderStyle-CssClass="form_head" AlternatingRowStyle-BackColor="#eeeeee" 
                                                    RowStyle-BackColor="#ffffff"  PageSize="25" onpageindexchanging="grdReport_PageIndexChanging" 
                                                          >
                                                          <RowStyle BackColor="White"></RowStyle>
                                                  
                                                    <Columns>
                                                     <%--   <asp:TemplateField HeaderText="Sr.No." >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "StudentLogId")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                         <asp:TemplateField HeaderText="Sr.No." ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (grdReport.PageSize * grdReport.PageIndex) + Container.DisplayIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Student Name " ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblname" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          
                                                                                                                   
                                                          <asp:TemplateField HeaderText="Login From " ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginFrom")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Login Date " ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllogindate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginDate1")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Login Time " ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblloginTime" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginTime1")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <%--  <asp:TemplateField HeaderText="Logout Date " Visible="false" ItemStyle-CssClass="left_padding1">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLogOutdate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginOut")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                           <asp:TemplateField HeaderText="Logout Time " ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLogOutTime" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginOutTime1")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                             </div>
                                             </div>
                                       </fieldset>
                                   </div>
     <div class="row" >&nbsp;</div>
     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton1" runat="server"  Visible="false" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" />
             </div>
             </div>
             </div>
             </section>
         
   </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    
                                                        
    </form>

</asp:Content>