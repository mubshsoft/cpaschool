<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="PerformanceSheet.aspx.vb" Inherits="Student_PerformanceSheet" Title="Performance Sheet" %>
<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title></title>

    <script type="text/javascript" src="../stmenu.js"></script>

--%>    
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
                     function CallPrint(strid)
  {
   var prtContent = document.getElementById(strid);
   var strOldOne=prtContent.innerHTML;
   var WinPrint = window.open('','','left=0,top=0,width=700,height=500,toolbar=0,scrollbars=0,status=0');
   WinPrint.document.write(prtContent.innerHTML);
   WinPrint.document.close();
   WinPrint.focus();
   WinPrint.print();
   WinPrint.close();
   prtContent.innerHTML=strOldOne;
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
.pb {padding:1em 0;}
    </style>

   

    <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
          STUDENT PERFORMANCE SHEET
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
              <li><a href="../Student/StudentPerformaneCourse.aspx"> List of Course</a></li>
            <li class="active">STUDENT PERFORMANCE SHEET</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

    <%--<div onkeypress="HideMessage()"></div>--%>
        
                 <span class="pull-right"><asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-primary btn-large arial" /></span>
                 </div></div>
<div class="row">&nbsp;</div>
              <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
                        <div id="print_grid" class="table">
                                           
                            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                     
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </div></div>
<div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

<div class="box" style="height:400px">
<div class="box-body">
 <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">&nbsp;</div>
</div>
<div class="row pb">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">Course Name :</div>
		<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
</div>
<div class="row pb">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">Batch :</div>
		<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:Label ID="lblBatchCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
</div>
 <div class="row pb">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">Name of the Student :</div>
		<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
</div>
<div class="row pb">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">Student Reference ID :</div>
		<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label></div>
</div>
                                                                   
</div>
</div>
</div>

                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
<div class="box" style="height:400px">
<div class="box-header"><h4>Progess Report</h4></div>
<div class="box-body"><iframe id="frmprogress"  runat="server" style="height:400px; width: 100%; border: 0"></iframe></div>
</div>
                                                                            </div>
                                                                            
</div></div>
                                                                <table width="100%" align="center" class="form_head" style="border:none" id="tblhd" runat="server">
                                                                        <tr>
                                                                            <td width="10%" align="left" >
                                                                                Papers
                                                                            </td>
                                                                            <td width="30%" align="left" >
                                                                                Name of the papers
                                                                            </td>
                                                                            <td width="15%" align="center" id="tdhdngasgnmarks" runat="server">
                                                                                Assignment
                                                                            </td>
                                                                            <td width="15%" align="center" id="tdhdngexammarks" runat="server">
                                                                                Online Exam
                                                                            </td>
                                                                            <td width="20%" align="center" id="tdhdngdiscussforum" runat="server">
                                                                                Participation in Discussion Forum
                                                                            </td>
                                                                            <td width="10%" align="center" >
                                                                                Total
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                            <asp:DataList ID="dlstPerformanceSheet" runat="server" Width="100%" RepeatColumns="1">
                                                        <%--        <HeaderTemplate>
                                                                
                                                                </HeaderTemplate>--%>
                                                                <ItemTemplate>
                                                                    <table width="100%" align="center" style="background-color:#fff; border:0">
                                                                        <tr>
                                                                            <td width="10%" align="left" >
                                                                                <asp:Label ID="lblrowid" runat="server" Text=' <%#Eval("ROWID") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="30%" align="left" >
                                                                                <asp:Label ID="lblPapertitle" runat="server" Text=' <%#Eval("Papertitle") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="15%" align="center" id="tdasgnmarks" runat="server" >
                                                                                <asp:Label ID="lblAssignmentMarks" runat="server" Text=' <%#Eval("AssignmentMarks") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="15%" align="center" id="tdexammarks" runat="server" >
                                                                                <asp:Label ID="lblExamMarks" runat="server" Text=' <%#Eval("ExamMarks") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="20%" align="center" id="tddiscussforum" runat="server" >
                                                                                <asp:Label ID="lblforum" runat="server" Text=' <%#Eval("forum") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="10%" align="center" >
                                                                                <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                  
                                                            </asp:DataList>
                                                             <%--<table width="600" border="1" align="center" style="border-color: #cccccc; background-color:#808000 border-style: solid;">
                                                               <tr id="trproject" runat="server" visible="false">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                       <asp:Label ID="lblprojectmarkshd" runat="server" Text="" Font-Bold="true" Visible="false">Project 
                                                                        Marks :</asp:Label>
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        <asp:Label ID="lblProject" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trcolumn1" runat="server" visible="false">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                      <asp:Label ID="lblColName1" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        <asp:Label ID="lblmarks1" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trcolumn2" runat="server" visible="false">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                         <asp:Label ID="lblColName2" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        <asp:Label ID="lblmarks2" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                           
                                                                <tr id="trgrndtotal" runat="server" visible="false">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        Grand Total :
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        <asp:Label ID="lblGrandTotal" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>--%>

                                                            <table width="100%" border="1" align="center" style="background-color:#fff; border:0">
                                                               <tr id="trproject" runat="server" visible="false">
                                                                    <td width="85%" align="left" >
                                                                       <asp:Label ID="lblprojectmarkshd" runat="server" Text="" Font-Bold="true" Visible="false">Project Marks (out of 40):</asp:Label>
                                                                        <asp:Label ID="lblProject" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                    <td id="trgrndtotal" runat="server" visible="false" width="15%" align="right" >
                                                                        Grand Total :
                                                                        <asp:Label ID="lblGrandTotal" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trcolumn1" runat="server" visible="false" style="display:none">
                                                                    <td width="85%" align="left">
                                                                      <asp:Label ID="lblColName1" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td width="15%" align="left" >
                                                                        <asp:Label ID="lblmarks1" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trcolumn2" runat="server" visible="false" style="display:none">
                                                                    <td width="85%" align="left" >
                                                                         <asp:Label ID="lblColName2" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td width="15%" align="left" >
                                                                        <asp:Label ID="lblmarks2" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                           
                                                                <%--<tr id="trgrndtotal" runat="server" visible="false">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                       
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        
                                                                    </td>
                                                                </tr>--%>
                                                            </table>

                                                        
                                           </div> 
                                           </div></div>
               <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:Label ID="lblGrand" runat="server" />
                                                    </div></div>
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                
                                                <asp:button ID="btnback"  runat="server" Text="Back" CssClass="btn btn-warning btn-large arial" />
                                             </div></div>
                                            
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                            
    
    </section>
    </div>
<script type="text/javascript">
    updateMarks();
    function updateMarks() {
        setTimeout("updateProjectMarks()", 500);
    }
    function updateProjectMarks() {
        if (document.getElementById("lblProject").innerHTML == "0" && document.getElementById("lblCourseName").innerHTML == "NPO Governance Program") {
            document.getElementById("lblProject").innerHTML = "Not Applicable";
        }
        else {
            document.getElementById("lblGrandTotal").innerHTML = eval(document.getElementById("lblGrandTotal").innerHTML) - eval(document.getElementById("lblProject").innerHTML);
        }
    }

</script>

<script src="../Calendar/jquery-1.10.2.min.js" ></script>


</asp:Content>
