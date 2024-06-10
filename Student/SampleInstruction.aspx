<%@ Page Language="C#" Title="Instruction" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master" CodeFile="SampleInstruction.aspx.cs" Inherits="SampleInstruction" %>


<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Instruction</title>
<script type="text/javascript" src="../stmenu.js"></script>--%>
   <%-- <script language="javascript" type="text/javascript">
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
    </script>--%>
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
   

    

     <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Exam Instruction
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Exam Instruction</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <div onkeypress="javascript:HideMessage()">                           
       <div class="box"<div class="box-body">
       <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
             <%  
            if (dsInstruction != null)
              {
                  if (dsInstruction.Tables != null)
                  {
                      if (dsInstruction.Tables[0].Rows != null)
                      {
                          if (dsInstruction.Tables[0].Rows.Count > 0)
                          {
                              secText=dsInstruction.Tables[0].Rows[0]["instructiontext"].ToString();
                          }
                      }
                  }
              }
             %>
             <%=secText %>
             </div></div>
             <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <asp:HiddenField ID="hdnSamId" runat="server" /></div></div>
            <div class="row">&nbsp;</div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                    <%--<asp:ImageButton ID="btnStartSample" runat="server" ImageUrl="~/Images/start_exam.jpg" onclick="btnStartSample_Click" />--%>
                    <asp:Button ID="btnStartSample" runat="server" 
                        CssClass="btn btn-success" onclick="btnStartSample_Click1" Text="Start Exam" />
                </div></div>
                <div class="row">&nbsp;</div>
                </div>
                </div>
                </div>
    </section>
    </div>
</asp:Content>

