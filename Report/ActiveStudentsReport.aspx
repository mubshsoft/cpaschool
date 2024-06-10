<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="ActiveStudentsReport.aspx.cs" Inherits="Report_ActiveStudentsReport" Title="Active Students Report" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Active Students Report</title>--%>

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
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 15px;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 15px;
            
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
    <h1 class="heading-color">Active Students Report</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
<li><a href="ReportList.aspx">Report Panel</a></li>
        <li class="active">Active Students Report</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

            

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlCourse" runat="server" ToolTip="Course"  CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                                                </asp:DropDownList>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<asp:DropDownList ID="ddlbatch" runat="server" ToolTip="Batch"  CssClass="form-control" AutoPostBack="True" meta:resourcekey="ddlbatchResource1" onselectedindexchanged="ddlbatch_SelectedIndexChanged">
                                                                </asp:DropDownList>
    </div>
    </div>

     <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton5" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton3" runat="server" Text="Generate Report" CssClass="btn btn-large btn-success" onclick="ImageButton3_Click" />
    </div>
    </div>
    </div>
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >                                                  
      <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Search Through" ToolTip="Search Through"></asp:TextBox></div>                                                 
      <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"><asp:Button ID="ImageButton4" runat="server" Text="Search" CssClass="btn btn-large btn-success" onclick="ImageButton4_Click" /></div>                                                                                                                           
      <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"><asp:RadioButton ID="RadioButton1" runat="server" Checked="True" Text="Student Name" GroupName="A" /></div>
      <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"><asp:RadioButton ID="RadioButton2" runat="server" Text="Email ID" GroupName="A" /></div>
      </div>
      </div>
      <div class="user-info media box" style="background-color:#fff;">
      <div id="print_grid">
       <fieldset>
        <legend>Active Students Report</legend>
        <div class="row" >                                                  
      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:GridView ID="grdStudentDetails" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                      HeaderStyle-CssClass="form_head" AlternatingRowStyle-BackColor="#eeeeee"
                                                    RowStyle-BackColor="#ffffff" EnableModelValidation="True" OnRowDataBound="grdStudentDetails_DataBound">
                                                                                 
                                                                       
                                                    <%--<HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />--%>
                                                    <RowStyle BackColor="White"></RowStyle>
                                                    <EmptyDataTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="100%" align="center" style="padding-right: 10px">
                                                                    <font color="red"  ><strong>!!!No Records 
                                                                    Found!!!</strong>
                                                                    </font>
                                                                </td>
                                                                
                                                                                                                          </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                      <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                    <%# (grdStudentDetails.PageSize * grdStudentDetails.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                                   </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Student ID" >
                                                            <%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "refid")%>'></asp:Label>
                                                                <asp:HiddenField ID="hdnStudentId" Value='<%#DataBinder.Eval(Container.DataItem, "StudentID")%>' runat="server" />
                                                                <asp:HiddenField ID="hdnBatchId" Value='<%#DataBinder.Eval(Container.DataItem, "bid")%>' runat="server" />
                                                                <asp:HiddenField ID="hdnBatch" Value='<%#DataBinder.Eval(Container.DataItem, "Batch")%>' runat="server" />
                                                                <asp:HiddenField ID="hdnCourseTitle" Value='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="left_padding1" />
                                                        </asp:TemplateField>
                                                    
                                                    
                                                    
                                                        <asp:TemplateField HeaderText="Student Name" >
                                                            <%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStudentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                                 <asp:HiddenField ID="hdnStudentName" Value='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="left_padding1" />
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Course" >
                                                            <%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                           </ItemTemplate>
                                                             <ItemStyle CssClass="left_padding1" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email ID" >
                                                            <%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmailId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
                                                                 <asp:HiddenField ID="hdnEmail" Value='<%#DataBinder.Eval(Container.DataItem, "email")%>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="left_padding1" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Personal Details" >
                                                            <%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                              <asp:LinkButton ID="lnkPdetails" runat="server" Text="Personal Details" ></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="left_padding1" />
                                                        </asp:TemplateField>
                                                        
                                                        
                                                           <asp:TemplateField HeaderText="Academic Details" ><%--<ItemStyle Width="110px" />--%>
                                                         <ItemTemplate>
                                                       <asp:LinkButton ID="lnkdetails" runat="server" Text="View Details" ></asp:LinkButton>
                                                       </ItemTemplate>
                                                               <ItemStyle CssClass="left_padding1" />
                                                       </asp:TemplateField>
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                              <AlternatingRowStyle BackColor="#EEEEEE" />
                                                </asp:GridView>
      </div>
      </div>
                                                            
                                                           </fieldset> 
       </div>
       <div class="row" > &nbsp;</div>
       <div class="row" >
       <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
       <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" Visible="false" />
                                      </div>
                                      </div>
                                      </div>
                                      </section>                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
              
 
    </form>

</asp:Content>
