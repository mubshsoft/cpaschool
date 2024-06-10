<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="PerformanceSheet.aspx.vb" Inherits="Admin_PerformanceSheet" Title="Performance Sheet" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Performance Sheet</title>--%>
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
    <script type="text/javascript">
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
    .td-head {font-size: 15px; padding: 0 10px;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Performance Sheet</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Performance Sheet</li>
		</ul>
	</div>
    </section>
<div onload="updateMarks()">
    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">


    <section class="container main m-tb">
    <div class="user-info media box" style="background-color:#fff;">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary"  /></span></div>
    </div>

    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
    </div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <div id="print_grid">
        <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>STUDENT PERFORMANCE SHEET</h4></div></div>
        <div class="row" >
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Course Name :</div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
       
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Batch :</div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblBatchCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
        </div> 
        <div class="row" >
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Name of the Student : </div>    
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"><asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label> </div>                                             
        
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Student Reference ID : </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12"> <asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label></div>
         </div>                                                       
         
                                                              <%--  <tr>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        Years :
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        <asp:Label ID="lblYears" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>--%>
                                                                <div class="row">&nbsp;</div>
        <div class="row" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                                     
                                                                <table width="100%" class="form_head" id="tblhd" runat="server">
                                                                        <tr>
                                                                            <td width="10%" align="left" class="td-head" >
                                                                                Papers
                                                                            </td>
                                                                            <td width="20%" align="left" class="td-head" >
                                                                                Name of the papers
                                                                            </td>
                                                                            <td width="20%" align="left" id="tdhdngasgnmarks" runat="server" class="td-head">
                                                                                Assignment
                                                                            </td>
                                                                            <td  width="15%" align="left"   id="tdhdngexammarks" runat="server" class="td-head">
                                                                                Online Exam
                                                                            </td>
                                                                            <td width="15%" align="left"  id="tdhdngdiscussforum" runat="server" class="td-head">
                                                                                Participation in Discussion Forum
                                                                            </td>
                                                                            <td width="10%" align="left"  id="tdhdngcasestudy" runat="server" class="td-head">
                                                                                Case Study
                                                                            </td>
                                                                            <td width="10%" align="left" class="td-head">
                                                                                Total
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    </div>
                                                                    </div>
        <div class="row" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                                            <asp:DataList ID="dlstPerformanceSheet" runat="server" Width="100%" RepeatColumns="1" CssClass="table">
                                                        <%--        <HeaderTemplate>
                                                                
                                                                </HeaderTemplate>--%>
                                                                <ItemTemplate>
                                                                    <table width="100%" align="center" style="border-color: #cccccc; border-style: solid;
                                                                        border-width: thin">
                                                                        <tr>
                                                                            <td width="10%" align="left" >
                                                                                <asp:Label ID="lblrowid" runat="server" Text=' <%#Eval("ROWID") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="20%" align="left" >
                                                                                <asp:Label ID="lblPapertitle" runat="server" Text=' <%#Eval("Papertitle") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="20%" align="center"  id="tdasgnmarks" runat="server">
                                                                                <asp:Label ID="lblAssignmentMarks" runat="server" Text=' <%#Eval("AssignmentMarks") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="15%" align="center" id="tdexammarks" runat="server">
                                                                                <asp:Label ID="lblExamMarks" runat="server" Text=' <%#Eval("ExamMarks") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="15%" align="center" id="tddiscussforum" runat="server">
                                                                                <asp:Label ID="lblforum" runat="server" Text=' <%#Eval("forum") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="10%" align="center" id="tdcasestudy" runat="server">
                                                                                <asp:Label ID="lblcasestudy" runat="server" Text=' <%#Eval("CaseStudyMarks") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="10%" align="center" >
                                                                                <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                  
                                                            </asp:DataList>
                                                            </div></div>
        <div class="row" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                                             <table width="100%" align="center" style="border-color: #cccccc; border-style: solid;">
                                                               <tr id="trproject" runat="server" visible="false">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                       <asp:Label ID="lblprojectmarkshd" runat="server" Text="" Font-Bold="true" Visible="false">Project Marks (out of 40):</asp:Label>
                                                                        <asp:Label ID="lblProject" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                    <td id="trgrndtotal" runat="server" visible="false" width="300" align="right" style="font-family:Tahoma; font-size:11px; ">
                                                                        Grand Total :
                                                                        <asp:Label ID="lblGrandTotal" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trcolumn1" runat="server" visible="false" style="display:none">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                      <asp:Label ID="lblColName1" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                        <asp:Label ID="lblmarks1" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trcolumn2" runat="server" visible="false" style="display:none">
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
                                                                         <asp:Label ID="lblColName2" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td width="300" align="left" style="font-family:Tahoma; font-size:11px; ">
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
                                                            </div></div>
        <div class="row" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> <asp:Label ID="lblGrand" runat="server" /></div></div>
        <div class="row" >
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:button ID="btnback" Text="Back" CssClass="btn btn-large btn-warning" runat="server"/></div>
        </div>
    </div>
    </div>
    </div>
    </div>
    </section>
    </div>
    </form>
</div>

</asp:Content>