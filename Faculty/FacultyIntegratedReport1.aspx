<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="FacultyIntegratedReport1.aspx.cs" Inherits="Faculty_FacultyIntegratedReport1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
   
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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px; }

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }
      
      
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
    <h1 class="heading-color">Faculty Integrated Report</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Faculty Integrated Report</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
  <section class="container main m-tb">
   <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 <strong><asp:Label ID="lblCaption" runat="server" /></strong>
                 </div>
                 </div>
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 
                                 <div id="print_grid" runat="server">
                                    
                                         <table width="100%">
                                         <tr><td>
                                         <table width="100%">
                                         <tr>
                                         <td align="left" style="padding-left:13px; font-family:Tahoma; font-size:11px"; 
                                                 >
                                             <table cellpadding="0" cellspacing="0" width="50%">
                                                 <tr>
                                                     <td width="35%" align="left">
                                                          &nbsp;</td>
                                                     <td width="10%" align="center">
                                                         &nbsp;</td>
                                                     <td width="55%" align="left">
                                             
                                                         &nbsp;</td>
                                                 </tr>
                                                 <tr>
                                                     <td width="35%" align="left">
                                                          <b>Course</b></td>
                                                     <td width="10%" align="center">
                                                         :</td>
                                                     <td width="55%" align="left">
                                             
                                                      <asp:Label ID="lblcourse" runat="server" Text="label"></asp:Label>
                                             
                                             
                                                                                        </td>
                                                 </tr>
                                                 <tr>
                                                     <td width="35%" align="left">
                                                          <b>Batch</b></td>
                                                     <td width="10%" align="center">
                                                         :</td>
                                                     <td width="55%" align="left">
                                             
                                                      <asp:Label ID="lblBatch" runat="server" Text="label"></asp:Label>
                                             
                                             
                                                                                        </td>
                                                 </tr>
                                                 <tr>
                                                     <td width="35%" align="left">
                                                        <b>Faculty Name</b></td>
                                                     <td width="10%" align="center">
                                                         :</td>
                                                     <td width="55%" align="left">
                                             
                                                        <asp:Label ID="lblStudentName" runat="server" Text="label"></asp:Label>
                                                     
                                                                                        </td>
                                                 </tr>
                                                 <tr>
                                                     <td width="35%" align="left">
                                                         &nbsp;</td>
                                                     <td width="10%" align="center">
                                                         &nbsp;</td>
                                                     <td width="55%" align="left">
                                             
                                                         &nbsp;</td>
                                                 </tr>
                                                 </table>
                                            </td>
                                         </tr>
                                         
                                         </table>
                                         </td></tr>
                                            <tr><td>
                                             <fieldset>
                                            <legend class="style9_sec"><b>Faculty Assigned
                                                Report</legend>
                                           <br />
                                                <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%"  AllowPaging="True" Font-Names="Verdana" Font-Size="10px" 
                                                    HeaderStyle-BackColor="#eeeeee" AlternatingRowStyle-BackColor="#eeeeee" 
                                                    RowStyle-BackColor="#ffffff" EnableModelValidation="True" PageSize="20" onpageindexchanging="grdReport_PageIndexChanging" 
                                                          >
                                                          <RowStyle BackColor="White"></RowStyle>
                                                  
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Paper Assigned"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Semester"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lblSemesterTitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                               <asp:TemplateField HeaderText="Module"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                               <asp:Label ID="lblModuleTitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Course Title"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                </fieldset>
                                             </td></tr>
                                          
                                             <tr>
                                             <td>
                                              <fieldset>
                                            <legend class="style9_sec"><b>Last Login 
                                                Report</b></legend>
                                           <br />
                                             <asp:GridView ID="GridLoginReport" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%"  AllowPaging="True" Font-Names="Verdana" Font-Size="10px" 
                                                    HeaderStyle-BackColor="#eeeeee" AlternatingRowStyle-BackColor="#eeeeee" 
                                                    RowStyle-BackColor="#ffffff"  PageSize="20" onpageindexchanging="GridLoginReport_PageIndexChanging" 
                                                          >
                                                          <RowStyle BackColor="White"></RowStyle>
                                                  
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Faculty Log ID"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourse" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "FacultyLogId")%>'></asp:Label>
                                                                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Faculty Name "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "FacultyName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                          <asp:TemplateField HeaderText="Login From "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblexamcode" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginFrom")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Login Date "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllogindate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Logout Date "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLogOutdate" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "LoginOut")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           
                                                        
                                                    
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                   </fieldset>
                                             
                                             
                                             </td>
                                             
                                             </tr>
                                             
                                            
                                             
                                             
                                             
                                             <tr>
                                             <td>
                                              <fieldset>
                                            <legend class="style9_sec"><b>Query
                                                Query
                                                Report</b></legend>
                                           <br />
                                             
                                             <asp:GridView ID="grdQueryDetails" runat="server" AutoGenerateColumns="False" 
                                                Width="100%"
                                                    AlternatingRowStyle-BackColor="#eeeeee" 
                                                    EnableModelValidation="True" Font-Names="Verdana" Font-Size="10px" 
                                                    HeaderStyle-BackColor="#eeeeee" RowStyle-BackColor="#ffffff" RowStyle-HorizontalAlign="Center">                       
                                                                   
                                                    
                                                    
                                                   
                                                    <%--<HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />--%>
                                                    <EmptyDataTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center" style="padding-right: 10px" width="100%">
                                                                    <font color="#4b4b4b"><strong>No records </strong></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Number of Queries Posted"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                   <asp:Label ID="lblNoQuery" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "NumberofQueriesPosted")%>'></asp:Label>
                                                              
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Number of UnReplied Queries "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuery" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "NumberofUnRepliedQueries")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Number of Replied Queries "><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuery" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "NumberofRepliedQueries")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                       
                                                    </Columns>
                                                    
                                                    <HeaderStyle BackColor="#EEEEEE" />
                                                           <AlternatingRowStyle BackColor="#EEEEEE" />
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                 </fieldset>
                                             
                                             </td>
                                             </tr>
                                         
                                             
                                                                                 
                                           
 
                                             
                                             
                                             
                                          </table> 
                                      
                                
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Back.png" 
                                                   PostBackUrl="~/Faculty/FacultyIntegratedReport.aspx"  />
                                                     
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png" tyle="text-align: left" ToolTip="Print" />
                                                  
                                                    
                                             
                                               
                                           
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </section>
    
                                                        
    </form>
    </asp:content>

