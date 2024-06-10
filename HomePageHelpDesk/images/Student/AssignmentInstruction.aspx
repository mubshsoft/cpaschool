<%@ Page Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="AssignmentInstruction.aspx.cs" Inherits="AssignmentInstruction" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>

.form_head {background: #3c8dbc;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
        }
    </script>

    <script language="javascript" type="text/javascript">
        <%--function HideMessage() {

            if (document.all) {
                document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
            }
            else {
                document.getElementById('<%=lblMessage.ClientID%>').textContent = '';
            }
        }--%>
    </script>
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
          <h1>
            Assignment Instruction
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Assignment Instruction</li>
          </ol>
        </section>
        <section class="content">
        <div onkeypress="javascript:HideMessage()">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        
                                                   <%  
                                                       try
                                                       {
                                                           if (dsInstruction != null)
                                                           {
                                                               if (dsInstruction.Tables != null)
                                                               {
                                                                   if (dsInstruction.Tables[0].Rows != null)
                                                                   {
                                                                       if (dsInstruction.Tables[0].Rows.Count > 0)
                                                                       {
                                                                           secText = dsInstruction.Tables[0].Rows[0]["instructiontext"].ToString();
                                                                       }
                                                                   }
                                                               }
                                                           }
                                                       }
                                                       catch (Exception ex) { }                                                    
                                                     %>
                                                     <%=secText %>
                                            </div>
                                            </div>

                                                        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  <asp:HiddenField ID="hdnAsgnId" runat="server" /></div>
        </div>
                                                            
                                                  <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">          <asp:Button ID="btnStartAssignment" runat="server" 
                                                   Text="Start Assignment" CssClass="btn btn-primary" onclick="btnStartAssignment_Click" />
                                                    </div>
                                                    </div>
                                                          
</div>
</section>
</div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>
