<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="FacultyListExam.aspx.cs" Inherits="Faculty_FacultyListExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    
   <script language="javascript" type="text/javascript">
       function openPopuppage(asgnid, uid) {
           window.open("../Admin/AssignmentFinalAnswerSheet.aspx?AssignmentType=Manual" + "&AsgnId=" + asgnid + "&uid=" + uid + "", "Info", "status=1, width=700, height=450, top=200, left=300");
           
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
               function openPopup(id)
                     {
                    open("../Student/QueryDetails.aspx?lstquerydetails=" + id, "Info", "status=1, width=510, height=650, top=20, left=300");
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
    <h1 class="heading-color">List Of Exam</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">List Of Exam</li>
		</ul>
	</div>
    </section> 
    <form id="form1" runat="server">

    
  <section class="container main m-tb">


<div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row" align="center" > 
                 <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red" Visible="false" ></asp:Label>
                 </div>
                 <div class="well">
                     
                 <div class="row">
                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" align="right"><asp:DropDownList ID="ddlCourse" runat="server" Width="100%" CssClass="input-block-level"  AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    </div>
                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" align="left"><asp:DropDownList ID="ddlBatch" runat="server" ToolTip="Batch Code" Width="100%" CssClass="input-block-level" AutoPostBack="true" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">&nbsp;</div>
                                                                    </div>
                     <div class="row">
     <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">                                                        
      <asp:DropDownList ID="ddlListExamSet" runat="server" AutoPostBack="true" ToolTip="Exam Code" Width="100%" CssClass="input-block-level" >
                                                                    </asp:DropDownList> 
                                                                    </div>
                         <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">  
                                                                        <asp:LinkButton ID="btnView" Text="Click here to view assignment answer sheet of student" runat="server" OnClick="btnView_Click" ></asp:LinkButton>
                                                                    </div>
                                                                    </div>   
                 </div>
                                                                    

         <div class="row">
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                 Exam Assigned to <%=Session["username"].ToString() %>
                 </div>
         </div>
                  <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center" style="overflow:auto; height:600px">
                 
                 <asp:GridView ID="GrdExam" AutoGenerateColumns="false" runat="server" DataKeyNames="ExamId"
                                                    Width="100%" AllowPaging="True" PageSize="10" CssClass="table" OnRowDataBound="GrdExam_RowDataBound">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle  Font-Names="arial" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="form_head" />
                                                    <EmptyDataTemplate>
                                                      <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                      </EmptyDataTemplate>
                                                    <Columns>
                                                        
                                                    
                                                                    <%--<asp:TemplateField HeaderText="Assignment Type" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkAssignmentType" runat="server" Text='<%# Eval("AssignmentType") %>'></asp:LinkButton>
                                                                            
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                       <asp:TemplateField HeaderText="Exam Code" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%" >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblasgncode" Text='<%# Eval("examcode") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Batch Code" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%"  >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblBatchCode" Text='<%# Eval("batchcode") %>' runat="server" ></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                        <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PaperTitle" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaperTitle" Text='<%# Eval("PaperTitle") %>' runat="server" ></asp:Label>
                                                                <%--<asp:HiddenField ID="hdnAssignmentType" Value='<%# Eval("AssignmentType") %>' runat="server" ></asp:HiddenField>--%>
                                                                <asp:HiddenField ID="hdnAsgnid" runat="server" Value='<%#Eval("ExamId") %>' />
                                                                <asp:HiddenField ID="hdnfid" runat="server" Value='<%#Eval("FId") %>' />
                                                                <asp:HiddenField ID="hdnCourseId" runat="server" Value='<%#Eval("CourseId") %>' />
                                                                <asp:HiddenField ID="hdnbid" runat="server" Value='<%#Eval("bid") %>' />
                                                                <%--<asp:HiddenField ID="hdnmanualAssignAssignment" runat="server" Value='<%#Eval("manualAssignAssignment") %>' />
                                                                <asp:HiddenField ID="hdnsubmiitedAssignment" runat="server" Value='<%#Eval("submiitedAssignment") %>' />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                         
                                                    </Columns>
                                                </asp:GridView>
                 <br />
                   <div class="row">
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="left">
                <span style="font-weight:bold;font-size:12px;"> View answer sheet of Student</span>
              </div>
         </div>   
                     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
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
                                                                        <asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Userid")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left"  HeaderText="Answer Sheet">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hdnBatchid" Value='<%#DataBinder.Eval(Container.DataItem, "BatchID")%>'
                                                                            runat="server" />
                                                                        <asp:HiddenField ID="hdnExamId" Value='<%#DataBinder.Eval(Container.DataItem, "ExamID")%>'
                                                                            runat="server" />
                                                                        <asp:HiddenField ID="hdnUserID" Value='<%#DataBinder.Eval(Container.DataItem, "Userid")%>'
                                                                            runat="server" />

                                                                        <asp:LinkButton ID="lnkbtntype" runat="server">Answer Sheet </asp:LinkButton>
                                                                       
                                                                        <asp:LinkButton ID="lnkSubmitMarkformanual" OnClientClick=<%# "openPopuppage(" + Eval("ExamID") + ",'" + Eval("Userid") + "')" %> runat="server" Visible="false" >Submit Marks </asp:LinkButton>
                                                                      
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
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow:auto">
                                                        <asp:GridView ID="GrdDescAns" AutoGenerateColumns="False" Width="100%" runat="server" CssClass="table"
                                                            AllowPaging="True"  PageSize="15" >
                                                            <HeaderStyle CssClass="grid-header-Overtime" />
                                                            <RowStyle CssClass="form_head" />
                                                            <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ShowHeader="true">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
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
                                              
                 </div>
                                                </div>
                                                                    
        
       </div>
       </div>
       </div>             
                                
                
   </section>
    </form>

</asp:Content>
