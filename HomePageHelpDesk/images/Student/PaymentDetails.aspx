<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile ="~/Student/StudentMaster.master" CodeFile="PaymentDetails.aspx.vb" Inherits="Student_PaymentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
<script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=500, height=330, top=20, left=300");
                }
    </script>

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
                     
                      function openPopup(id)
                     {
                    open("QueryDetails.aspx?fid=" + id, "Info", "status=1, width=510, height=650, top=20, left=300");
                      }
    </script>

<div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Payment
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Payment</li>
          </ol>
        </section>
 <section class="content" style="margin-top:20px">
     
   
    <div onkeypress="javascript:HideMessage()">
    <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                       </div></div>
                                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">    
                                                            <strong class="style9_sec"><asp:Label ID="lblMsgDetails" runat="server" Text=""></asp:Label></strong>
                                                        </div></div>
                                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                        <div class="box"><div class="box-body">
                                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="Label1" runat="server" ></asp:Label></div></div>
                                        <div class="row">&nbsp;</div>
                                        <div class="row">
                                        <div class="col-lg-3 col-md-4 col-sm-12 col-xs-12">D D Number :</div>
                                        <div class="col-lg-9 col-md-8 col-sm-12 col-xs-12"><asp:TextBox ID="txtDDNumber"  runat="server" CssClass="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="row">&nbsp;</div>
                                        <div class="row">
                                        <div class="col-lg-3 col-md-4 col-sm-12 col-xs-12">Amount (Rs.) :</div>
                                        <div class="col-lg-9 col-md-8 col-sm-12 col-xs-12"><asp:TextBox ID="txtAmt"  runat="server"  Enabled="false"  CssClass="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="row">&nbsp;</div>
                                        <div class="row">
                                        <div class="col-lg-3 col-md-4 col-sm-12 col-xs-12">Issue date (D D) :</div>
                                        <div class="col-lg-9 col-md-8 col-sm-12 col-xs-12"><asp:TextBox ID="txtDDDate"  runat="server" CssClass="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="row">&nbsp;</div>
                                        <div class="row">
                                        <div class="col-lg-3 col-md-4 col-sm-12 col-xs-12">Payment date :</div>
                                        <div class="col-lg-9 col-md-8 col-sm-12 col-xs-12"><asp:TextBox ID="txtPaymentDate" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="row">&nbsp;</div>
                                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                                         <asp:Button ID="btnSave" CssClass="btn btn-large btn-primary" Text="Save" runat="server"/>&nbsp;&nbsp;
                                                           <asp:Button ID="btnClose" CssClass="btn btn-large btn-warning" Text="Close" runat="server"/>
                                                           </div>
                                                           </div>
                                       </div>
                                       </div>
                                       </div>
                                       </div>     
                            
                            
     </div>   
</section>
</div>
</asp:Content>
