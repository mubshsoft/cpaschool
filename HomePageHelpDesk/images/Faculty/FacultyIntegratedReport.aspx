<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="FacultyIntegratedReport.aspx.cs" Inherits="Faculty_FacultyIntegratedReport" Title="Faculty Report" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
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
    <h1 class="heading-color">List Query</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">List Query</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
  <section class="container main m-tb">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff; padding-top:20px">
     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"> 
      <asp:DropDownList ID="ddlCourse" runat="server" CssClass="input-block-level" AutoPostBack="True"  Width="100%" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                </div>      
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"> 
     <asp:DropDownList ID="ddlbatch" runat="server" CssClass="input-block-level" AutoPostBack="True" Width="100%" meta:resourcekey="ddlbatchResource1">
                                                                </asp:DropDownList>
                                                                </div>
                                                                </div>
    <div class="row" >
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
                                                                <asp:Button ID="ImageButton4" runat="server" Text="Generate Report" CssClass="btn btn-success btn-large" onclick="ImageButton4_Click" />
                                                                </div>
                                                                </div>
                                                               
                                                               
<div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><span class="pull-right"><asp:Label ID="Label1" runat="server" CssClass="arial" Text="Search Through :"></asp:Label></span></div>
     <div class="span2 left"><asp:TextBox ID="TextBox1" runat="server" CssClass="input-block-level" ></asp:TextBox></div>
     <div class="span4 left"><asp:Button ID="ImageButton3" runat="server" onclick="ImageButton3_Click" Text="Search" CssClass="btn btn-warning btn-small" /></div>
</div>
<div class="row">
<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><span class="pull-right"><asp:RadioButton ID="RadioButton1" CssClass="input-medium arial" runat="server" Checked="True" GroupName="A"></asp:radiobutton> <span style="font-family: arial;">Faculty Name</span></span></div>
 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:RadioButton ID="RadioButton2" CssClass="input-medium arial" runat="server" GroupName="A" ></asp:radiobutton> <span style="font-family: arial;">Email ID</span></div>
 </div>
                                                                
                         </div>        
                             <div class="user-info media box" style="background-color:#fff; padding-top:20px">                                   
                                                               
                                               
                                                    <div id="print_grid" style="overflow:auto; height:600px">
                                                        <fieldset >
                                                            <div class="form_head">Faculty Report</div>
                                                            
                                                                          <asp:GridView ID="grdStudentDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                                     HeaderStyle-BackColor="#eeeeee" AlternatingRowStyle-BackColor="#eeeeee" CssClass="table"
                                                    RowStyle-BackColor="#ffffff" EnableModelValidation="True" OnRowDataBound="grdStudentDetails_DataBound" >
                                                    <%--<HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />--%>
                                                    <RowStyle BackColor="White"></RowStyle>
                                                    <EmptyDataTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="100%" align="center" style="padding-right: 10px">
                                                                    <font color="red" font-names="Verdana" font-size="10px"><strong>!!!No Records 
                                                                    Found!!!</strong>
                                                                    </font>
                                                                </td>
                                                                
                                                                                                                          </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                      <asp:TemplateField HeaderText="Faculty ID">
                                                            <%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFacultyid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FacultyID")%>'></asp:Label>
                                                                <asp:HiddenField ID="hdnFacultyid" Value='<%#DataBinder.Eval(Container.DataItem, "FacultyID")%>' runat="server" />
                                                                <asp:HiddenField ID="hdnCourseId" Value='<%#DataBinder.Eval(Container.DataItem, "courseid")%>' runat="server" />
                                                                <asp:HiddenField ID="hdnBatchId" Value='<%#DataBinder.Eval(Container.DataItem, "bid")%>' runat="server" />
                                                                <asp:HiddenField ID="HiddenBatch" Value='<%#DataBinder.Eval(Container.DataItem, "batch")%>' runat="server" />
                                                                <asp:HiddenField ID="hdnCourseTitle" Value='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    
                                                    
                                                    
                                                        <asp:TemplateField HeaderText="Faculty Name">
                                                            <%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFacultyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FacultyName")%>'></asp:Label>
                                                                 <asp:HiddenField ID="hdnFacultyName" Value='<%#DataBinder.Eval(Container.DataItem, "FacultyName")%>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                   
                                                        <asp:TemplateField HeaderText="Email ID">
                                                            <%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmailId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "email")%>'></asp:Label>
                                                                 <asp:HiddenField ID="hdnEmail" Value='<%#DataBinder.Eval(Container.DataItem, "email")%>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Batch">
                                                            <%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbatch" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Batch")%>'></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Personal Details">
                                                            <%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                              <asp:LinkButton ID="lnkPdetails" runat="server" Text="Personal Details" ></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                           <asp:TemplateField HeaderText="Other Details"><%--<ItemStyle Width="110px" />--%>
                                                         <ItemTemplate>
                                                       <asp:LinkButton ID="lnkdetails" runat="server" Text="View Details" ></asp:LinkButton>
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                        
                                                        
                                                    </Columns>
                                                   
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                                          
                                                           </fieldset> 
                                                           </div>
                                                       <div class="row">&nbsp;</div>     
                                                <div class="row">
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
                                                <asp:Button ID="ImageButton2" runat="server" PostBackUrl="~/Report/ReportList.aspx" Text="Close" CssClass="btn btn-warning btn-large" Visible="False" onclick="ImageButton2_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-primary btn-large" ToolTip="Print" Visible="false" />
                                            </div>
                                            </div>
                                        
                                       </div>
                                       </div>
                                       </div>                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                               
               </section>             
    </form>
</asp:Content>

