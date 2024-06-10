<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="AddExamDate.aspx.cs" Inherits="Admin_AddExamDate" Title="Add ExamSet" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add ExamSet</title>--%>

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
                    <h2 style="color:#fff">Add Answer Sheet Date</h2>
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
           <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
           <fieldset><legend>Add Date</legend>
            <div class="row-fluid" >
            <div class="span6">
            <asp:TextBox ID="txtSentDate" runat="server" CssClass="input-block-level" ToolTip="Date Sent" placeholder="Date Sent"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="(mm/dd/yy)" ></asp:Label>
            <asp:Label ID="lblSentDateReq" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>
            <div class="span6">
            <asp:TextBox ID="txtReceivedDate" runat="server" CssClass="input-block-level" ToolTip="Date Received" placeholder="Date Received"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="(mm/dd/yy)" ></asp:Label>
            <asp:Label ID="lblReceivedDateReq" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>
            </div>                                                            
            <div class="row-fluid" >
            <div class="span12 center">
<asp:Button ID="ImgbtnBack" Text="Back" CssClass="btn btn-large btn-warning" runat="server" onclick="ImgbtnBack_Click" />
<asp:ImageButton ID="Imagebutton1" Text="Save" CssClass="btn btn-large btn-success" runat="server" OnClick="btnSave_Click" />
<asp:ImageButton ID="Imagebutton2" Text="Cancel" CssClass="btn btn-large btn-primary" runat="server" PostBackUrl="~/Admin/Adminlogin.aspx" />
</div></div>
         
                                                                    </fieldset>
                                                               
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
 <div class="row-fluid" >
            <div class="span12">
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnExamId" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnBatchId" runat="server" Visible="false" />
                                          </div></div>
      
    </div>
    </div>
    </div>
    </form>


</asp:Content>
