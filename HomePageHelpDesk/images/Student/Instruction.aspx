<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master" CodeFile="Instruction.aspx.cs" Inherits="Instruction" Title="Instruction" %>

<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="../stmenu.js"></script>
    
     <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
           Exam Instruction
          </h1>
          <ol class="breadcrumb">
            <li><a href="javascript:history.back();"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Exam Instruction</li>
          </ol>
        </section>
    

    
    <section class="content">
    <div onkeypress="javascript:HideMessage()">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">


    
    <div class="box"><div class="box-body">               
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
                                            </div></div>

<div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                  <asp:Button ID="btn_StartExam" runat="server" CssClass="btn btn-large btn-primary" Text="Start Exam" OnClick="btn_StartExam_Click" />
                  </div>
                  </div>
                                       
  <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">                                      
                                        <asp:ImageButton ID="btnStartExam" runat="server" Visible="false" ImageUrl="~/Images/start_exam.jpg" onclick="btnStartExam_Click" />
                                        </div></
                                        <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                               <asp:HiddenField ID="hdnExamId" runat="server" />
                                               </div>
                                               </div>
                            
    </div>
        </div>
        
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>