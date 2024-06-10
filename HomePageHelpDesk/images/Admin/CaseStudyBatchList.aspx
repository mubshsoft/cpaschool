<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CaseStudyBatchList.aspx.cs" Inherits="Admin_CaseStudyBatchList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>

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
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
        <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">Case Study : List of Batch</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">|</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="container main">
    <div class="row-fluid">
     <div class="span12">
      <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
      </div>
      </div>
     <div class="row-fluid">
     <div class="span12"> 
     <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" ToolTip="Course" CssClass="input-block-level" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                                                    </asp:DropDownList>
     </div>
      </div> 
      <div class="row-fluid">
     <div class="span12" id="trbatch" runat="server"> 
     <asp:DropDownList ID="ddlbatch" runat="server" AutoPostBack="true" ToolTip="Batch" CssClass="input-block-level" onselectedindexchanged="ddlbatch_SelectedIndexChanged">
                                                            </asp:DropDownList>
     </div>
      </div>                                                     
       <div class="row-fluid">
     <div class="span12 center">
     <asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server" onclick="btnback_Click" />
     </div>
     </div>
     <hr />
    <div class="row-fluid">
     <div class="span12">
     <asp:GridView ID="GrdBatch" AutoGenerateColumns="False" DataKeyNames="BatchId" Width="100%" CssClass="table"
                                                            runat="server" AllowPaging="True" OnPageIndexChanging="GrdBatch_PageIndexChanging"
                                                            OnSelectedIndexChanged="GrdBatch_SelectedIndexChanged">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                             <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                         <%# (GrdBatch.PageSize * GrdBatch.PageIndex) + Container.DisplayIndex + 1%>
                                                                        </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left" >
                                                                     <ItemTemplate>
                                                                        <a id="a1" href="AdminListCaseStudySet.aspx?batchid=<%#Eval("BatchId")%>">
                                                                            <%# Eval("BatchTitle") %>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Course Id" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCourseId" Text='<%# Eval("courseID") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    
                                            </div>
                                            </div>
                                            </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                               
    </div>
    </form>

</asp:Content>


