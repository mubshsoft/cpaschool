<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminListCaseStudySet.aspx.cs" Inherits="Admin_AdminListCaseStudySet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                  //open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                  window.open(strOpen, "Info", "status=1, width=1200, height=550, top=100, left=100");
                }
    </script>

    <script language="javascript" type="text/javascript">
        function openPopuppage(asgnid, uid , type)
        {
            window.open("CaseStudyFinalAnswerSheet.aspx?CSId=" + asgnid + "&uid=" + uid + "&CaseStudyType=" + type + "", "Info", "status=1, width=700, height=450, top=200, left=300");
            //alert(asgnid);
        }
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
        <div class="frame">
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
       </
       </div>
       </div>
      <div class="row-fluid">
     <div class="span12">                                                          <td width="250px" class="style5" align="right" style="padding-right:10px">
      <asp:DropDownList ID="ddlListExamSet" runat="server" AutoPostBack="true" ToolTip="Assignment Code" CssClass="input-block-level" OnSelectedIndexChanged="ddlListExamSet_SelectedIndexChanged1">
                                                                    </asp:DropDownList> 
                                                                    </div>
                                                                    </div>                                                            
     <div class="row-fluid">
     <div class="span12" align="center" >
     <asp:Button ID="btnAssign" runat="server" Text="Assign to Faculty" CssClass="btn btn-large btn-warning" onclick="lnkbtnSubmit_Click" />
         &nbsp;<asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-large btn-warning" PostBackUrl="~/Admin/AssignmentBatchList.aspx" />
     </div>
     </div>
        <div class="row-fluid">
            <div class="span12">&nbsp;</div>
        </div> 
     <div class="row-fluid">
     <div class="span12">
                                                        <asp:GridView ID="GrdUserList" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True" OnPageIndexChanging="GrdUserList_PageIndexChanging" PageSize="15"
                                                            OnRowDataBound="GrdUserList_RowDataBound1">
                                                            <HeaderStyle CssClass="form_head" />
                                                            <RowStyle CssClass="grid-row-Overtime" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                             <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# (GrdUserList.PageSize * GrdUserList.PageIndex) + Container.DisplayIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="User Name" ItemStyle-HorizontalAlign="Left" >
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UserId")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left"  HeaderText="Answer Sheet">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hdnAsgnID" Value='<%#DataBinder.Eval(Container.DataItem, "CSID")%>'
                                                                            runat="server" />
                                                                        <asp:HiddenField ID="hdnUserID" Value='<%#DataBinder.Eval(Container.DataItem, "Userid")%>'
                                                                            runat="server" />
                                                                               <asp:HiddenField ID="hdnAssignpath" Value='<%#DataBinder.Eval(Container.DataItem, "CaseStudyPath")%>'
                                                                            runat="server" />
                                                                              <asp:HiddenField ID="hdntype" Value='<%#DataBinder.Eval(Container.DataItem, "CaseStudyType")%>'
                                                                            runat="server" />
                                                                        <asp:LinkButton ID="lnkbtntype" runat="server">Answer Sheet </asp:LinkButton>
                                                                        <%--<asp:LinkButton ID="lnkbtndownload" runat="server" Visible="false">Answer Sheet 
                                                                        Manual </asp:LinkButton>--%>

                                                                        <asp:LinkButton ID="lnkbtndownload" runat="server" Visible="false" >Answer Sheet 
                                                                        Manual </asp:LinkButton>
                                                                      
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left"  HeaderText="Paper Checked">
                                                                    <ItemTemplate>
                                                                        
                                                                        <%--<a id="a1" href="javascript:openPopup('../Faculty/AssignmentInstruction.aspx?AsgnId=<%#Eval("AsgnID")%>&uid=<%#Eval("Userid")%>')">
                                                                            Fafaculty Feedback</a>--%>
                                                                        <asp:HiddenField ID="hdnstatus" Value='<%#DataBinder.Eval(Container.DataItem, "status")%>'
                                                                            runat="server" />
                                                                        <asp:HiddenField ID="hdnTotalMarks" Value='<%#DataBinder.Eval(Container.DataItem, "TotalMarks")%>'
                                                                            runat="server" />
                                                                        <asp:LinkButton ID="lnkbtnFacultyFeedback" OnClientClick=<%# "openPopuppage(" + Eval("CSID") + ",'" + Eval("Userid") + "','" + Eval("CaseStudyType") + "')" %> runat="server" ToolTip="Faculty has checked the paper."  >Answer Sheet (Faculty)
                                                                         </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField> 

                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left"  HeaderText="Attachment">
                                                                    <ItemTemplate>
                                                                        <%--<asp:HiddenField ID="hdnuploadanspath" runat="server" Value='<%#Eval("uploadanspath")%>' />--%>
                                                                        <asp:LinkButton ID="lnkbtnDesc" runat="server" Visible="false" OnCommand="lnkbtnDesc_Command"
                                                                            CommandName="descriptive" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UserId")%>'> 
                                                                        Descriptive Answer(Uploaded File)
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
     </div>
     </div>                                               
     <div class="row-fluid">
     <div class="span12">
                                                        <asp:GridView ID="GrdDescAns" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True"  PageSize="15" >
                                                            <HeaderStyle CssClass="grid-header-Overtime" />
                                                            <RowStyle CssClass="form_head" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ShowHeader="true">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <strong>Question No.&nbsp;<asp:Label ID="lblqueno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Queno")%>'></asp:Label>
                                                                            --</strong>&nbsp;&nbsp;<asp:Label ID="lblquetext" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px">
                                                                    <ItemTemplate>
                                                           <asp:LinkButton ID="lnkbtndownloadDesc" runat="server" CommandName="download" OnCommand="lnkbtndownloadDesc_Command"
                                                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UploadAnspath")%>'>Download </asp:LinkButton>
                                                                
                                                            
                                                           <%--  <a href='Handler.ashx?FILE=<%#DataBinder.Eval(Container.DataItem, "UploadAnspath")%>'>Download </a>--%>
                                                            
                                                             </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:HiddenField ID="hdnbatchid" runat="server" />
                                                        <asp:HiddenField ID="hdmasgnid" runat="server" />
                                                    
                                            </div>
                                            </div>
                                            </section>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            
    </form>

</asp:Content>


