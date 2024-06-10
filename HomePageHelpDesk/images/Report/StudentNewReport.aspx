<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="StudentNewReport.aspx.cs" Inherits="Admin_StudentNewReport" Title="Student New Report" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Student New Report</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

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
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .style14
        {
            width: 18%;
        }
    </style>

    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>

         <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff"><asp:Label ID="lblCaption" runat="server" /></h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="../Admin/Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">/</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="container main">
    <div class="row-fluid" >
    <div class="span6">
<asp:DropDownList ID="ddlCourse" runat="server" CssClass="input-block-level" ToolTip="Course Title" placeholder="Course Title" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="span6">
    <asp:DropDownList ID="ddlApplicationStatus" runat="server" CssClass="input-block-level" ToolTip="Application Status" placeholder="Application Status" AutoPostBack="True">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Approved</asp:ListItem>
                                                                        <asp:ListItem Value="0">UnApproved</asp:ListItem>
                                                                        <asp:ListItem Value="All">ALL</asp:ListItem>
                                                                    </asp:DropDownList>
    </div>
    </div>
    <div class="row-fluid" >
    <div class="sapn12 center" >
    <asp:Button ID="ImageButton4" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton3" runat="server" Text="Generate Report" CssClass="btn btn-large btn-success" OnClick="ImageButton3_Click"  />
    </div></div>
          <div id="print_grid">
           <fieldset>
           <legend>Student Report</legend>
            <div class="row-fluid" style="border-bottom:soldid 1px #ccc">
            <div class="span3"><asp:Label ID="lblcourse1" runat="server" align="right" Text="Course Title :" Font-Bold Font-Names="Tahoma" Font-Size="11px" Visible="false"></asp:Label></div>
            <div class="span3"><asp:Label ID="lblCourseTitle" runat="server" align="left" Font-Names="Tahoma" Font-Size="11px" Visible="false"></asp:Label></div>
            <div class="span3"><asp:Label ID="lbldate" runat="server" align="Right" Text="Date :" Font-Names="Tahoma" Font-Bold Font-Size="11px" Visible="false"></asp:Label></div>
            <div class="span3"><asp:Label ID="lblshowdate" runat="server" align="left" Text="" Font-Names="Tahoma" Font-Size="11px" Visible="false"></asp:Label></div>
            </div>
            <div class="row-fluid" style="border-bottom:solid 1px #ccc">
            <div class="span3"><asp:Label ID="lblAppStatus" runat="server" align="right" Text="Application Status :" Font-Bold Font-Names="Tahoma" Font-Size="11px" Visible="false"></asp:Label></div>
            <div class="span3"><asp:Label ID="lblAppStatus1" runat="server" align="left" Font-Names="Tahoma" Font-Size="11px" Visible="false"></asp:Label></div>
            <div class="span6">&nbsp;</div>
            
            </div>  
            <div class="row-fluid" style="overflow:auto; height:400px">
            <div class="span12">
            <asp:GridView ID="grdStudentDetails" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                                                OnRowDataBound="grdStudentDetails_DataBound" AllowPaging="false" Font-Names="Verdana"
                                                                                Font-Size="10px" HeaderStyle-CssClass="form_head" AlternatingRowStyle-BackColor="#eeeeee"
                                                                                RowStyle-BackColor="#ffffff" EnableModelValidation="True" PageSize="20" OnPageIndexChanging="grdStudentDetails_PageIndexChanging">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                        <ItemTemplate>
                                                                                            <%# (grdStudentDetails.PageSize * grdStudentDetails.PageIndex) + Container.DisplayIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Student Name"  >
                                                                                     <ItemStyle HorizontalAlign="left"  />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblStudentId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Address" >
                                                                                       <ItemStyle HorizontalAlign="left"  />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblAddress" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "address1")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Gender" >
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGender" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Gender")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Status" >
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCurProfession" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CurProfession")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Email ID" >
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEmailId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
                                                                                            <asp:HiddenField ID="hdnAppId" Value='<%#DataBinder.Eval(Container.DataItem, "aid")%>'
                                                                                                runat="server" />
                                                                                           </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField  Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkdetails" runat="server" Text="View Details"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                            </div>
                                                                            </div>
                                                                        
                                                            </fieldset>
                                                        </div>
          <div class="row-fluid">
                                                        <div class="span12 center">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png" tyle="text-align: left" ToolTip="Print" Visible="false" />
                                                        </div></div>
          </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                               
    </div>
    </form>
</asp:Content>