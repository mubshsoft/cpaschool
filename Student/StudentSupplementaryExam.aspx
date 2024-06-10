<%@ Page Language="VB" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="false" CodeFile="StudentSupplementaryExam.aspx.vb" Inherits="Student_StudentSupplementaryExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add ExamSet</title>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
<section class="content-header">
          <h1>
            Supplementary Exam
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Supplementary Exam</li>
          </ol>
        </section>
        <section class="content">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div onkeypress="javascript:HideMessage()">
        
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                           
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        
                                                                    <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Green"></asp:Label>
                                                               <div class="box box-primary">
                           
                                                                    <div class="box-body">
                                                                        <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Batch Code :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="ddlbatch" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList></div>
                                                                    </div>
                                                                <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Course Code :</div>
                              <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" CssClass="form-control"
                                                                                        />
                                                                                    <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                               </div>
                                                                               </div>
                                                                            <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Semester :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="ddlSem" AutoPostBack="true" runat="server" CssClass="form-control"
                                                                                      />
                                                                                    <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                </div>
                                                                                </div>
                                                                            <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Module :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="ddlModule" AutoPostBack="true" runat="server" CssClass="form-control"
                                                                                         />
                                                                                    <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                </div>
                                                                                </div>
                                                                            <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Paper :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="ddlPaper" runat="server" CssClass="form-control" />
                                                                                    <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                               </div>
                                                                               </div>
                                                                            <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdncoursecode" runat="server" />
                                                                                </div></div>
                                                                            <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                                                                    <asp:Button ID="imgSave" Text="Save" CssClass="btn btn-large btn-success" runat="server"  />
                                                                                    
                                                                                    <asp:Button ID="imgCancel" Text="Cancel" CssClass="btn btn-large btn-warning" runat="server" PostBackUrl="studentPanel.aspx" />
                                                                                </div></div>
                                                                        
                                                                   </div>
                                                                   </div>
                                                               
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                
                                           
    </div>
    </div>
    </div>
    </section>
    </div>
    </asp:content>

