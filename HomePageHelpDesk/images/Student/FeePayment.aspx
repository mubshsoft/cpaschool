<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="FeePayment.aspx.vb" Inherits="Student_FeePayment" Title="Fee Payment" %>

<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Fee Payment</title>
<script type="text/javascript" src="../stmenu.js"></script>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #3c8dbc;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        function openPopup1(id)
                     {
                    open("PaymentDetails.aspx", "Info", "status=1, width=510, height=650, top=20, left=300");
                      }
                      function openPopup(id)
                     {
                    open("PaymentDetails.aspx?pid=" + id, "Info", "status=1, width=510, height=650, top=20, left=300");
                      }
    </script>

 <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Fee for Course
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Fee for Course</li>
          </ol>
        </section>
    <section class="content">
 
    <div onkeypress="javascript:HideMessage()">
     
         <div class="box box-primary"><div class="box-body">
         <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">   
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </div>
         </div>
         <div class="row">&nbsp;</div>
         <div class="row">
        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">Fee of course/semester :</div>
        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"><asp:TextBox ID="lblFee"  runat="server" CssClass="form-control" Enabled="false" MaxLength="48" ReadOnly="True"></asp:TextBox> <asp:Label ID="lblfeecurrency" runat="server" Text="Label"></asp:Label></div> 
        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">Pay fee :</div>
        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4"><asp:TextBox ID="txtPay"  runat="server" CssClass="form-control" Enabled="true" MaxLength="48" ></asp:TextBox></div>
        </div>   
        <div class="row">&nbsp;</div>                                                     
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center"><asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-large arial"/> 
        <asp:Button ID="btnPay" runat="server"  Text="Pay Now" CssClass="btn btn-success btn-large arial"/></div></div>
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><i>Note: Inclusion of service Tax at 12.36%</i></div></div>
                                                          
         </div></div>                                              
        
    </div>                  
    
        
</section>
</div>
<script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>