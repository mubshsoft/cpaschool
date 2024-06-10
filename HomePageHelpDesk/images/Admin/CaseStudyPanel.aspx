<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CaseStudyPanel.aspx.cs" Inherits="Admin_CaseStudyPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
     <script type="text/javascript" src="../stmenu.js"></script>

    <form id="form1" runat="server">

     <section class="title">
        <div class="container">
        <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">Case Study Panel</h2>
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

    <div class="container item-container">
                <div class="row-fluid" style="padding: 30px 0 30px 0;">
                <div class="span4 center"><a href="CaseStudyActivate.aspx">Assign Case Study</a></div>
                <div class="span4 center"><a href="ReActivateCaseStudy.aspx">Re-Activate Case Study</a></div>
                <div class="span4 center"><a href="CaseStudyBatchList.aspx">Case Study Batch List</a></div>
    </div>
    </div>
    </div>
    </div>
    </section>


    
    </form>

</asp:Content>


