<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="ActiveExamReport.aspx.cs" Inherits="ActiveExamReport" Title="Active Exam Report" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Assign Exam Report</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>
      <script language="javascript" type="text/javascript" src="../datetimepicker.js">
    </script>
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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Active Exam</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
       <li><a href="ReportList.aspx">Report Panel</a></li>
      <li class="active">Active Exam Report</li>
		</ul>
	</div>
    </section>
 <div id='popCal' style='POSITION:absolute;visibility:hidden;border:2px ridge;width:10'>
<iframe name="popFrame" src="../UNTITLED.htm" frameborder="0" scrolling="no" width="152" height="147"></iframe>
</div>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
       

    <section class="container main m-tb">
     <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlCourse" AutoPostBack="true"  runat="server" ToolTip="Course"  CssClass="form-control" onselectedindexchanged="ddlCourse_SelectedIndexChanged" /><asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:DropDownList ID="ddlbatch" AutoPostBack="true"  runat="server" ToolTip="Batch"  CssClass="form-control" />
    </div>
    </div>
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:TextBox ID="txtfrmdt" runat="server" CssClass="form-control" ToolTip="From Activate Date" placeholder="From Activate Date"></asp:TextBox>
    <a href="javascript:NewCal('<%= txtfrmdt.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
    <asp:TextBox ID="txttodt" runat="server" CssClass="form-control" ToolTip="To actvate Date" placeholder="To actvate Date"></asp:TextBox><%--<input id="Image1" runat="server" onclick="popFrame.fPopCalendar(txttodt,txttodt,popCal);return false" type="image"  src="~/Images/calender.png" style="vertical-align: bottom; width: 22px; height: 22px" />--%>
    <a href="javascript:NewCal('<%= txttodt.ClientID %>','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" class="icon-position"></a>
    </div>
    </div>
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
                                            <legend>Assign exam list</legend>
                                          <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>Course :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblcourse" runat="server" ></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>Batch :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblbatch" runat="server" ></asp:Label></div>
                                        </div>
                                        <div class="row" >
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>Activate From&nbsp; Date :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblactivatedt" runat="server" ></asp:Label></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><b>Activate To Date :</b></div>
                                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lbltoactivatedt" runat="server" ></asp:Label></div>
                                        </div>
                                        <div class="row" >
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                            <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" CssClass="table" 
                                                    Width="100%"  AllowPaging="false"   
                                                     HeaderStyle-CssClass="form_head" AlternatingRowStyle-BackColor="#eeeeee" 
                                                    RowStyle-BackColor="#ffffff" EnableModelValidation="True" PageSize="20" onpageindexchanging="grdReport_PageIndexChanging" 
                                                          >
                                                          <RowStyle BackColor="White"></RowStyle>
                                                  
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course" ItemStyle-CssClass="left_padding1"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "coursetitle")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Batch" ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "batchcode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="ExamCode" ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "examcode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Semester" ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsem" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "semestertitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Paper"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpaper" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "papertitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Activate Date" ><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactvate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "activatedate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Deactivate Date"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldeactivate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "deactivatedate")%>'></asp:Label>
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
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" Visible="false" />
     
           </div>
           </div>
           </div>
           </section>
    </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    
                                                        
    </form>
</asp:Content>
