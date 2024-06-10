<%@ Page Title="" Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="AddCaseStudyEvaluation.aspx.vb" Inherits="Admin_AddCaseStudyEvaluation" %>


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


 
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
    <div onkeypress="HideMessage()">

    <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff"><asp:Label ID="lblHeading" runat="server" ></asp:Label></h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">/</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="container main">
    <div class="row-fluid" >
    <div class="span12">
        
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
                                                               
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
      <div class="row-fluid" >
    <div class="span12"><asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Red" Text=""></asp:Label></div>
    </div>
    <div class="row-fluid" >
    <div class="span12" style="overflow:scroll;">
                        <asp:GridView ID="GrdStudent" AutoGenerateColumns="False" DataKeyNames="stid" Width="100%" CssClass="table"
                                                    runat="server" AllowPaging="True" PageSize="10"  >
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
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
                                                     
                                                         <asp:TemplateField HeaderText="Case Study" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCaseStudyMarks" Text='<%# Eval("CaseStudyMarks") %>' runat="server" ></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Case Study(Fail Status)" ItemStyle-HorizontalAlign="Left">
                                                            
                                                            <ItemTemplate>
                                                             <asp:Label ID="lblCaseStudyStatus" runat ="server" Text='<%# Eval("CaseStudyStatus") %>' Visible="false"></asp:Label>
                                                               
                                                                <asp:CheckBox ID="chkCaseStudy"  runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                                  </div>
                                                  </div>
    <div class="row-fluid" >&nbsp;</div>
    <div class="row-fluid" >
    <div class="span12">
                     <asp:button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"/>&nbsp;&nbsp;&nbsp;
                     <asp:button ID="btnClose" Text="Close" CssClass="btn btn-large btn-warning" runat="server"/>&nbsp;&nbsp;&nbsp;
                     <asp:button ID="Imagebutton1" Text="Save & Continue" CssClass="btn btn-large btn-success" runat="server" Visible="false" />
                     </div>
                     </div>
                                                  </ContentTemplate>
                                            </asp:UpdatePanel>
                                            
                    </div>
                
        </div>
        
        </section>
    </div>
    </form>
</asp:Content>