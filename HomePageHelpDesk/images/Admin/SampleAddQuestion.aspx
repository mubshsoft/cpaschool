<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="SampleAddQuestion.aspx.cs" Inherits="Admin_SampleAddQuestion" Title="Add Question" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Question</title>--%>
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
        .style15
        {
            color: #4b4b4b;
            width: 0;
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
    <h1 class="heading-color"><asp:Label ID="lblCaption" runat="server" Text="Add Question" /></h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <%--<li class="active">Instruction Summary</li>--%>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
    <section class="container main m-tb">
               
        
                                <div class="frame">
                                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate >
                                --%>
                                 <div class="user-info media box" style="background-color:#fff;">
                                 <div class="row">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                                 </div>
                                 <div class="row">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><h4><asp:Label ID="lblSection" runat="server" Text=""></asp:Label></h4></div>
                                 </div>
                                 <div class="row">
                                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                 <asp:DropDownList ID="ddlQuestionType" runat="server" AutoPostBack="true" CssClass="input-block-level" ToolTip="Question Type"
                                                                TabIndex="1" OnSelectedIndexChanged="ddlQuestionType_SelectedIndexChanged">
                                                               <asp:ListItem>-Select Type-</asp:ListItem>
                                                                <asp:ListItem Value="Objective">Objective Question</asp:ListItem>
                                                                <asp:ListItem Value="Subjective">Short Answer Questions</asp:ListItem>
                                                                <asp:ListItem Value="Descriptive2">Descriptive Questions</asp:ListItem>
                                                                <asp:ListItem Value="Descriptive">Descriptive Questions (Upload file option)</asp:ListItem>
                                                                <asp:ListItem Value="Image Question">Descriptive Questions (Table)</asp:ListItem>
                                                                <asp:ListItem Value="Case Study">Case Study</asp:ListItem>
                                                                <asp:ListItem Value="Fill Blank">Fill in the Blanks</asp:ListItem>
                                                            </asp:DropDownList>
                                                            </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtAnswer" runat="server" TabIndex="2" CssClass="input-block-level" ToolTip="Answer" placeholder="Answer"></asp:TextBox>
                                </div>
                                </div>
                                <div class="row">
                                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" TabIndex="3" Rows="4" CssClass="input-block-level" ToolTip="Question"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rqdSurveyQuestion" runat="server" ControlToValidate="txtQuestion" Display="Dynamic"
                                                                ErrorMessage="Enter  Question " ValidationGroup="1"></asp:RequiredFieldValidator>
                                                            <FCKeditorV2:FCKeditor ID="Editor1" runat="server" BasePath="~/fckeditor/" Height="200px"
                                                                Width="580px" Visible="false">
                                                            </FCKeditorV2:FCKeditor></div>
                                 <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks" runat="server" TabIndex="4" CssClass="input-block-level"></asp:TextBox>
                                                            <nobr> 
                                                            <asp:RegularExpressionValidator ID="regRefFee0" runat="server" Display="Dynamic"
                                                                ControlToValidate="txtMarks" ValidationGroup="1"
                                                                ErrorMessage="Invalid Marks" ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                                                                                                                             
                                                                </nobr></div>
                                </div>
                                <div class="row" id="trup1" runat="server" visible="false">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:FileUpload ID="FileUpload1" runat="server" /></div>
                                </div>                            
                                                    
                                                  
                                                            <%--<asp:Label ID="lblAns" runat="server" Text="Answer :"></asp:Label>--%>
                                                      
                                                            <%--<asp:Label ID="lblAns0" runat="server" Text="Marks :"></asp:Label>--%>
                                                        
                                                    <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
                                  <div class="row">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" OnClick="btnBack_Click" CausesValidation="false" />
                                                            <%-- <a href="javascript:history.go(-1)"><img src="../Images/back_button.jpg" border="0" ></a>--%>
                                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"  OnClick="btnSave_Click" ValidationGroup="1" />
                                                        </div></div>
                                                        </div>
                                                         <div class="user-info media box" style="background-color:#fff;">
                                    <div class="row">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                
                                                <asp:GridView ID="gvQuestionList" runat="server" AllowPaging="true" AutoGenerateColumns="false" CssClass="table"
                                                    DataKeyNames="QuestionId" OnPageIndexChanging="gvQuestionList_PageIndexChanging" OnRowCancelingEdit="gvQuestionList_RowCancelingEdit"
                                                    OnRowDataBound="gvQuestionList_RowDataBound" OnRowDeleting="gvQuestionList_RowDeleting"
                                                    OnRowEditing="gvQuestionList_RowEditing" OnRowUpdating="gvQuestionList_RowUpdating"
                                                    PagerSettings-FirstPageText="Fisrt" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast"
                                                    PagerStyle-HorizontalAlign="Center" PageSize="20">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Question No.">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="QuesNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Question">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QuestionText")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:HiddenField ID="hdnDeleteQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>' />
                                                                <asp:TextBox ID="txtQuestion" runat="server" MaxLength="300" CssClass="NormalText"
                                                                    Text='<%# Bind("QuestionText") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Answer">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAnswer" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Answer")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtAnswer" runat="server" MaxLength="300" CssClass="NormalText"
                                                                    Text='<%# Bind("Answer") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Marks">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMaxQueMarks" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MaxQueMarks")%>'></asp:Label>
                                                                &nbsp;
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtMaxQueMarks" runat="server" MaxLength="300" CssClass="NormalText"
                                                                    Text='<%# Bind("MaxQueMarks") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField CausesValidation="false" HeaderStyle-HorizontalAlign="Right" 
                                                            ShowEditButton="True" ShowHeader="True" />
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>' />
                                                                <asp:LinkButton ID="linkDeleteQuestion" runat="server" CausesValidation="false" CommandName="Delete"
                                                                    Font-Underline="false" CommandArgument='<%# Eval("QuestionId") %>'> 
                                                                Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="center" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnQuesIamgePath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "UploadQuestionImagePath")%>' />
                                                                <asp:HiddenField ID="hdnQUESTYPE" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QUESTYPE")%>' />
                                                                <asp:HiddenField ID="hdnAddQuestionId" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "QuestionId")%>' />
                                                                <asp:LinkButton ID="linkAddOption" runat="server" CausesValidation="false" Font-Underline="false">Add Options</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div></div>
                                   <div class="row">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">     
                                                <asp:HiddenField ID="hdnSamId" runat="server" />
                                                <asp:HiddenField ID="hdnSectionId" runat="server" />
                                   </div></div>
                                   <div class="row">
                                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">         
                                      <asp:HiddenField ID="hdneditorupdate" runat="server" Value="0" />
                                     <asp:HiddenField ID="hdnCaseStudyQuesId" runat="server"  />
                                     </div></div>
                                     </div>
                                    <%--   </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </div>
                            
        </section>
        </div>
    </form>
</asp:Content>
