<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="AddCourseEmailContent.aspx.cs" Inherits="AddCourseEmailContent" Title="Add Course Email Content" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Course Email Content</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="../stmenu.js"></script>

    
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
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <asp:Label ID="lblCaption" Visible="false" runat="server" />
    <h1 class="heading-color">Add Course Details</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Add Course Details</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        
                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>


  

    <section class="container main m-tb">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtcourseemailid"  ToolTip="Course EMail-Id" PlaceHolder="Course EMail-Id" CssClass="input-block-level" runat="server"  /></div></div>

                                   
                                                            
                                                             
                                                                           <%--<asp:Label ID="lblcourseemailid" runat="server" Text="Course eMail-id"></asp:Label></td>--%>
     <div class="user-info media box" style="background-color:#fff;">                                                          
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Content:</h4></div>
    </div>
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                       <FCKeditorV2:FCKeditor ID="Editor1" runat="server" BasePath="~/fckeditor/" ></FCKeditorV2:FCKeditor>
    </div>
    </div>   
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
                                                    <div class="row">&nbsp;</div>
                                                                                                                        
 <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-warning btn-large" CausesValidation="false" onclick="btnBack_Click" />
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-large"  OnClick="btnSave_Click"/>
                                                                </div></div>
                                                                <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:HiddenField ID="hdncourseId" runat="server" />
                                                        <asp:HiddenField ID="hdnemailtype" runat="server" />
                                                    </div></</div>
                                                    </div>
                                                    <div class="row">&nbsp;</div>
                                       <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </section>

                                </div>
    </form>

</asp:Content>