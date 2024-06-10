<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="ListCourseForfee.aspx.vb" Inherits="Student_ListCourseForfee" Title="List Content"%>
<%--
<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List Content</title>
<script type="text/javascript" src="../stmenu.js"></script>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #0e245d;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
            var statusmsg=""
                function hidestatus()
                    {
                        window.status=statusmsg
                        return true
                     }

    </script>
    
   
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Pay your Fees
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Pay your Fees</li>
          </ol>
        </section>
    <section class="content">
    
            

    
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div onkeypress="javascript:HideMessage()">
        
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                   <ContentTemplate>
                                     <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </div></div>
                                        <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:GridView ID="GrdCourse" AutoGenerateColumns="False" DataKeyNames="courseID" Width="100%"
                                                    runat="server" AllowPaging="True" PageSize="10" CssClass="table form_body" >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <Columns>
                                                      
                                                         <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="center">
                                                            <ItemTemplate>
                                                          
                                                            
                                                                   <%#Eval("CourseTitle")%>
                                                              
                                                                <%--<asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" CssClass="left_padding"></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Course Id" ItemStyle-HorizontalAlign="center" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseId" Text='<%# Eval("courseID") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="CourseCode" ItemStyle-HorizontalAlign="center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("CourseCode") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      
                                                        <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="center">
                                                            <ItemTemplate>
                                                            
                                                       <a href=' <%# If(Eval("feestatus") = 1, "#", "FeePayment.aspx?courseIDFEE="+Eval("courseID").ToString())%>'>
                                                        <asp:Label ID="Label1" Text='<%# If(Eval("feestatus").ToString() = "1", "Paid", "Pay") %>' runat="server" />
                                                       </a>
                                                         
                                                             
                                                       
                                                                <%--<asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" CssClass="left_padding"></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                        </div></div>    
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                    
                
    
        
        </div>
       
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>