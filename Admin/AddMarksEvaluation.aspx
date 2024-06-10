<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="AddMarksEvaluation.aspx.vb" Inherits="Admin_AddMarksEvaluation" Title="Add Marks" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Add Marks</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
    
      <script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage.ClientID%>').textContent ='';
                        }
                     }
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
    <h1 class="heading-color"><asp:Label ID="lblHeading" runat="server" ></asp:Label></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
       
		</ul>
	</div>
    </section>
 
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
    <div onkeypress="HideMessage()">

   
    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
       <div class="user-info media box" style="background-color:#fff;">                                                        
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
      <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Red" Text=""></asp:Label></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                        <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="stid" Width="100%" CssClass="table" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" PagerStyle-HorizontalAlign="Center"
                                                    runat="server" AllowPaging="True" PageSize="10"  >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
<PagerSettings LastPageText="Last" Mode="NumericFirstLast" />
                                                    <PagerStyle HorizontalAlign="Center" /><PagerStyle CssClass="pagination-ys" />
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
                                                     <asp:TemplateField HeaderText="Student Id" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstid" Text='<%# Eval("stid") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="bid" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblbid" Text='<%# Eval("bid") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfullname" Text='<%# Eval("fullname") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Exam Marks" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtExamMarks" Text='<%# Eval("ExamMarks") %>' runat="server" ></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Assignment Marks" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtAssignMarks" Text='<%# Eval("AssignmentMarks") %>' runat="server" ></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Forum Marks" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtForumMarks" Text='<%# Eval("Forum") %>' runat="server" ></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Exam(Fail Status)" ItemStyle-HorizontalAlign="Left">
                                                            
                                                            <ItemTemplate>
                                                            <asp:Label ID="lblexamstaus" runat ="server" Text='<%# Eval("ExamStatus") %>' Visible="false"></asp:Label>
                                                               <%-- <asp:CheckBox ID="chkFail" Checked='<%# Eval("ExamStatus") %>' runat="server" />--%>
                                                                <asp:CheckBox ID="chkFail"  runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Assignment(Fail Status)" ItemStyle-HorizontalAlign="Left">
                                                            
                                                            <ItemTemplate>
                                                             <asp:Label ID="lblAssignStatus" runat ="server" Text='<%# Eval("AssignStatus") %>' Visible="false"></asp:Label>
                                                               <%-- <asp:CheckBox ID="chkAssignment" Checked='<%# Eval("AssignStatus") %>' runat="server" />--%>
                                                                <asp:CheckBox ID="chkAssignment"  runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                     
                                                    </Columns>
                                                </asp:GridView>
                                                  </div>
                                                  </div>
    <div class="row" >&nbsp;</div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                     <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>&nbsp;&nbsp;&nbsp;
                     <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server"/>&nbsp;&nbsp;&nbsp;
                     <asp:button ID="Imagebutton1" Text="Save & Continue" CssClass="btn btn-large btn-success" runat="server" Visible="false" />
                     </div>
                     </div>
                                                  </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </div>
                                            
                    </div>
                
        </div>
        
        </section>
    </div>
    </form>
</asp:Content>