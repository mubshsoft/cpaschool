<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="StudentInMutipleCourseReport.aspx.cs" Inherits="Admin_StudentInMutipleCourseReport" Title="Student In Multiple Course Report" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Student In Multiple Course Report</title>--%>

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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000;   font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828;   height:15px;  }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828;   height:15px;  }
      .style14
      {
          color: #000000;
          font-size: 11px;
          font-family: tahoma;
          width: 698px;
      }
      .style15
      {
          width: 698px;
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
       <%-- <li class="active">Instruction Summary</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
     

    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
  
            
                              <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           
                                                        <ContentTemplate>--%>
    <div id="print_grid">
    <fieldset>
     <legend>Student In Multiple Course Report</legend>
     <div class="row" >
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lbldate" runat="server" align="Right" Text="Date :" Font-Names="Tahoma" Font-Size="11px" Font-Bold ></asp:Label>
                                             <asp:Label ID="lblshowdate" runat="server" align="left" Text="" Font-Names="Tahoma" Font-Size="11px"></asp:Label>
                                              </div>
      </div>  
      <div class="row" >
                                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                          
                                                 <asp:GridView ID="grdStudentReport" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table"
                                                   AllowPaging="false"   HeaderStyle-CssClass="form_head"
                                                   AlternatingRowStyle-BackColor="#eeeeee" RowStyle-BackColor="#ffffff" EnableModelValidation="True" PageSize="10" 
                                                     onpageindexchanging="grdStudentReport_PageIndexChanging" >
                                                       
                                                      <RowStyle BackColor="White"></RowStyle>
                                                    
                                                      <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="red"   ><strong>  !!!No Records 
                                                            Found!!!</strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                                                            
                                                 
                                                
                                                    <%--<HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />--%>
                                                    <Columns>
                                                       <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                                    <ItemTemplate>
                                                                                                                    <%# (grdStudentReport.PageSize * grdStudentReport.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                                   </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Student Name" >
                                                       <%-- <ItemStyle  Width="50px" />--%>
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblStudentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StudentName")%>'></asp:Label>
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       
                                                       
                                                       <asp:TemplateField HeaderText="Email ID" >
                                                       <%-- <ItemStyle  Width="50px" />--%>
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StudentEmail")%>'></asp:Label>
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       
                                                         <asp:TemplateField HeaderText="Course" >
                                                       <%-- <ItemStyle  Width="50px" />--%>
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblCourseTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                            
                                                          
                                                            
                                                             
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                </div>
       </div>
                                                </fieldset></div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <asp:Button ID="ImageButton2" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Report/ReportList.aspx" />
    <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" />
    </div>
    </div>
                                   <%--   </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                </div>
                            </div>
                            </div>
                            </section>
        
 </ContentTemplate>
      </asp:UpdatePanel>
    
                                                        
    </form>
</asp:Content>
