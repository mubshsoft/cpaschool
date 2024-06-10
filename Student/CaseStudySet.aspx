<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true"
    CodeFile="CaseStudySet.aspx.cs" Inherits="Student_CaseStudySet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <script language="javascript" type="text/javascript">
        function HideMessage() {

            if (document.all) {
                document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
            }
            else {
                document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
            }
        }
    </script>
    <style>
td, th {
    padding: 5px;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Case Study Set
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Case Study Set</li>
          </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    
   
     <div style="margin-top:20px;">
    <div class="row">
        
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
  
        
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            
                                                       </div>
                                                       </div>
                                                       <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="box">
                <div class="box-body">
              <table class="table table-striped">
                <tbody>
                
                                                <asp:GridView ID="grdAssignmentSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="CSID" AllowPaging="true" PageSize="10" 
                                                                onrowdatabound="grdAssignmentSet_RowDataBound" 
                                                                onpageindexchanging="grdAssignmentSet_PageIndexChanging" >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                        <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                           <asp:TemplateField HeaderText="Paper No." >
                                                        <ItemStyle HorizontalAlign="center" Width="200px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      <asp:HiddenField ID="hdPaperTitle" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>' />
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Name">
                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblAssignmentcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CSCode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:TemplateField HeaderText="Course" Visible="false">
                                                        <ItemStyle HorizontalAlign="center" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Semester">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module">
                                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                    
                                                         <asp:TemplateField>
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnAssignmentID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CSId")%>' />
                           <asp:HiddenField ID="hdnAssignmenttype" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CaseStudytype")%>' />
                            <%--<asp:HiddenField ID="hdnAssignmentPath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "AssignmentPath")%>' />--%>
                          <asp:LinkButton ID="lnkDetailsAssignment" runat="server" Font-Underline="false"  Font-Bold="true"
                                Text="Start"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                </tbody>
                                                </table>
                                                </div>
                                                </div>
                                                       
   
    </div>
    
    </div>
    </div>
    </div>
    </div>
    </section>
        <script src="../Calendar/jquery-1.10.2.min.js"></script>
</asp:Content>
