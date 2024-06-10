<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCaseStudySet.aspx.cs" Inherits="Admin_AddCaseStudySet" %>

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

    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
    </style>

    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">Case Study Set</h2>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
    <div class="row-fluid" >
    <div class="span12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row-fluid" >
    <div class="span12">
    <fieldset>
    <legend>Add New Case Study</legend>
     
    <div class="row-fluid" >
    <div class="span6">
    <asp:TextBox ID="txtcasestudycode" ToolTip="Case Study Code" PlaceHolder="Case Study Code" runat="server" CssClass="input-block-level"></asp:TextBox>
    <asp:Label ID="lblreqcasestudycode" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="span6">
    <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" ToolTip="Course Code" CssClass="input-block-level" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
    <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
    <div class="row-fluid" >
    <div class="span6">
    <asp:DropDownList ID="ddlSem" AutoPostBack="true" ToolTip="Semester" PlaceHolder="Semester" runat="server" CssClass="input-block-level" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" />
    <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div class="span6">
    <asp:DropDownList ID="ddlModule" AutoPostBack="true" runat="server" ToolTip="Module" PlaceHolder="Module" CssClass="input-block-level" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" />
    <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
    <div class="row-fluid" >
    <div class="span6">
    <asp:DropDownList ID="ddlPaper" runat="server" ToolTip="Paper" PlaceHolder="Paper" CssClass="input-block-level"  />
    <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label>                                                                       
    </div>
    <div class="span6">                                                                        
     <asp:DropDownList ID="ddlCasestudyType" runat="server" ToolTip="Assignment Type" CssClass="input-block-level" AutoPostBack="True" OnSelectedIndexChanged="ddlAssignmentType_SelectedIndexChanged">
                                                                                        <asp:ListItem>Online</asp:ListItem>
                                                                                        <asp:ListItem>Offline</asp:ListItem>
                                                                                       
                                                                                    </asp:DropDownList>  
     </div>
    </div> 
    <div class="row-fluid" >
    <div class="span6" id="tronline" runat="server">                                                                    
     <asp:TextBox ID="txtTimeAllowted" runat="server" ToolTip="Time Alloted" PlaceHolder="Time Alloted" CssClass="input-block-level"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="(In Minutes)" ></asp:Label>
                                                                                    <br />
    <asp:Label ID="lblTimeReq" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTimeAllowted" Display="Dynamic" ErrorMessage="<br>Please enter numeric values" ValidationExpression="(^[0-9]*\d*\d{1}?\d*)$"></asp:RegularExpressionValidator>
</div>
    <div class="span6" id="trmanual" runat="server" visible="false">Upload Assignment
<asp:FileUpload ID="FileUpload1" runat="server" Font-Names="Tahoma" Font-Size="11px" />
<asp:Label ID="lblfileupload" runat="server" Text="" ForeColor="Red"></asp:Label>
</div>
</div>
     <div class="row-fluid" >
    <div class="span12"> 
    <asp:HiddenField ID="hdncoursecode" runat="server" />
    </div>
    </div>                                                                      
     <div class="row-fluid" >
    <div class="span12 center">
    <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server" PostBackUrl="#" OnClick="btnSave_Click" />&nbsp;
    <asp:Button ID="btnClose" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" OnClick="btnClose_Click" />
    </div>
    </div>                                                                       
    <div class="row-fluid" >
    <div class="span12"> 
     <asp:CheckBox ID="chkuseAssignment" runat="server" Text="Use Existing Assignment" Visible="false" AutoPostBack="True" OnCheckedChanged="chkuseAssignment_CheckedChanged" CssClass="Style5" />
</div>
</div>
  
                                                                    </fieldset>
    </div>
    </div>
    <div class="row-fluid" >
    <div class="span12"> 
   <fieldset>
    <legend><strong class="style9_sec">View existing case study</strong></legend>
    <div class="row-fluid" >
    <div class="span6">
 <asp:DropDownList ID="ddlcoursefillter" runat="server" AutoPostBack="True" ToolTip="Course" PlaceHolder="Course" CssClass="input-block-level" OnSelectedIndexChanged="ddlcoursefillter_SelectedIndexChanged"> </asp:DropDownList>
    </div>
    <div class="span6">
    <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" ToolTip="Year" CssClass="input-block-level" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" >
                                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                                    <asp:ListItem>2008</asp:ListItem>
                                                                                                    <asp:ListItem>2009</asp:ListItem>
                                                                                                    <asp:ListItem>2010</asp:ListItem>
                                                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                                                </asp:DropDownList>
    </div>
    </div>
   
    <div class="row-fluid" >
    <div class="span12">
    <asp:GridView ID="grdCaseStudySet" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="CSID" OnRowDataBound="grdCaseStudySet_RowDataBound" OnRowEditing="grdCaseStudySet_RowEditing" CssClass="table"
                                                                                        OnRowUpdating="grdCaseStudySet_RowUpdating" OnRowCancelingEdit="grdCaseStudySet_RowCancelingEdit"
                                                                                        OnRowCommand="grdCaseStudySet_RowCommand" OnRowDeleting="grdCaseStudySet_RowDeleting">
                                                                                        <HeaderStyle CssClass="form_head" />
                                                                                        <RowStyle CssClass="grid-row-Overtime" />
                                                                                        <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                                                       <Columns>
                                                                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                                                                <ItemTemplate>
                                                                                                    <%# (grdCaseStudySet.PageSize * grdCaseStudySet.PageIndex) + Container.DisplayIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Assignment Code">
                                                                                                <ItemStyle Width="50px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkbtnCSCode" runat="server" Text='<%#Eval("CSCode")%>'
                                                                                                        CommandArgument='<%#Eval("CaseStudyPath")%>' CommandName="manual"></asp:LinkButton>
                                                                                                    <asp:Label ID="lblCScodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CSCode")%>'
                                                                                                        Visible="false"></asp:Label>
                                                                                                    <%-- <a id="a1" href="ShowAssignment.aspx?asgnid=<%#Eval ("AsgnId")%>">
                                                                  <%#Eval("AssignmentCode")%>
                                                                </a>
                                                      --%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Type">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lbltype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CaseStudyType")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Course">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Semester">
                                                                                                <ItemStyle Width="65px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Module">
                                                                                                <ItemStyle Width="55px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Paper">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Time Alloted">
                                                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTimeAllowted" runat="server" CssClass="left_padding" Text='<%#DataBinder.Eval(Container.DataItem, "TimeAllowted")%>'></asp:Label>
                                                                                                    &nbsp;
                                                                                                </ItemTemplate>
                                                                                                <EditItemTemplate>
                                                                                                    <asp:TextBox ID="txtTimeAllowted" runat="server" MaxLength="300" CssClass="NormalText"
                                                                                                        Text='<%# Bind("TimeAllowted") %>'></asp:TextBox>
                                                                                                </EditItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Date of creation">
                                                                                                <ItemStyle Width="110px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblcreatedate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CreateDate")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="75px"
                                                                                                ShowEditButton="True" ShowHeader="True" />
                                                                                            <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:HiddenField ID="hdnAsgnId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CSId")%>' />
                                                                                                    <asp:HiddenField ID="hdnAssignmentType" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "CaseStudyType")%>' />
                                                                                                    <asp:LinkButton ID="lnkDetailsAssignment" runat="server" Font-Underline="false" Text="Add Case Study"
                                                                                                        CausesValidation="false"></asp:LinkButton>
                                                                                                    <asp:LinkButton ID="lnkCopyAssignment" runat="server" Font-Underline="false" Text="Copy Questions"
                                                                                                        Visible="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                          <%--  <asp:TemplateField>
                                                                                                <ItemStyle Width="100px" />
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkEditDetailsAssignment" runat="server" Font-Underline="false"
                                                                                                        Text="Edit Assignment Details" CausesValidation="false"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>--%>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="lnkDeleteAssignmentSet" runat="server" CommandName="Delete" CommandArgument='<%# Eval("CSId") %>'>
                                                                     Delete</asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                                                    </asp:GridView>
                                                                                    </div>
                                                                                    </div>
     </fieldset>
     </div>
     </div>            
     </ContentTemplate>
     </asp:UpdatePanel>
                                            
                                </div>
                            
        </div>
        
        </section></div>
    
    </form>
</asp:Content>


