<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="PaymentMode.aspx.cs" Inherits="Student_PaymentMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
       
    .RadioButtonWidth label {  margin-left:20px;vertical-align:top; }  
    .style1
    {
        width: 15%;
    }
    .style2
    {
        width: 40%;
    }
    .style3
    {
        width: 45%;
    }
    </style>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
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
    <script type="text/javascript">

        function ValidateDDSubmit() 
        
                {

                    
                    if (document.getElementById("<%=txtDD.ClientID%>").value == "") {
                        alert("Enter DD Number !");
                        document.getElementById("<%=txtDD.ClientID%>").focus();
                        return false;
                    }

                    if (document.getElementById("<%=txtddBank.ClientID%>").value == "") {
                        alert("Enter Bank Name !");
                        document.getElementById("<%=txtddBank.ClientID%>").focus();
                        return false;
                    }
                    if (document.getElementById("<%=txtddBranch.ClientID%>").value == "") {
                        alert("Enter Branch !");
                        document.getElementById("<%=txtddBranch.ClientID%>").focus();
                        return false;
                    }

                    if (document.getElementById("<%=txtddDate.ClientID%>").value == "") {
                        alert("Enter Date !");
                        document.getElementById("<%=txtddDate.ClientID%>").focus();
                        return false;
                    }
                }

                function ValidateChequeSubmit() {

                   
                    if (document.getElementById("<%=txtChequeNo.ClientID%>").value == "") {
                        alert("Enter Cheque Number !");
                        document.getElementById("<%=txtChequeNo.ClientID%>").focus();
                        return false;
                    }

                    if (document.getElementById("<%=txtchqBank.ClientID%>").value == "") {
                        alert("Enter Bank Name !");
                        document.getElementById("<%=txtchqBank.ClientID%>").focus();
                        return false;
                    }
                    if (document.getElementById("<%=txtchqBranch.ClientID%>").value == "") {
                        alert("Enter Branch !");
                        document.getElementById("<%=txtchqBranch.ClientID%>").focus();
                        return false;
                    }

                    if (document.getElementById("<%=txtchqDate.ClientID%>").value == "") {
                        alert("Enter Date !");
                        document.getElementById("<%=txtchqDate.ClientID%>").focus();
                        return false;
                    }
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
                                        <div class="box"><div class="box-body">
                                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">Payments can be through the following modes, please click on the preferred 
                                                        mode to proceed with payment:</td>
                                         </div>
                                         </div>
                                        <div class="row"><div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                       Payment Modes:</div>
                                                       <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                                                        <<asp:RadioButton ID="rdoOnline" runat="server" Text="Internet Banking / Debit Card / Credit Card" GroupName="p" 
                                                                CssClass="RadioButtonWidth" AutoPostBack="True" 
                                                                oncheckedchanged="rdoOnline_CheckedChanged" />
                                                       
                                                            
                                                       </div>
                                                       </div>
                                          <div class="row"><div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">&nbsp;</div>             
                                           <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:RadioButton ID="rdoDD" runat="server" Text="Demand Draft" GroupName="p" 
                                                                CssClass="RadioButtonWidth" AutoPostBack="True" 
                                                                oncheckedchanged="rdoDD_CheckedChanged" /></div>
                                                                </div>
                                                                </div>
                                                                </div>
                                                                </div>
                                                                </div>
              <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                        <div class="box"><div class="box-body">
                                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                       <asp:Panel  ID="pnlDD" runat="server" Visible="false"></div></div>
                                            <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                       <asp:Label ID="txtddPayable" runat="server" Text="DD should be made in favour of <b>' FMSF Learning Systems.'</b> Payable at New Delhi"></asp:Label></div></div>
                                                       <div class="row">&nbsp;</div>
                                                 <div class="row"><div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                        Enter DD No:</div>
                                                    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                                                        <asp:TextBox ID="txtDD" runat="server" Width="250px"></asp:TextBox>
                                                   </div>
                                                   <div class="row">&nbsp;</div>
                                                   </div>
                                                <div class="row"><div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Bank Name:</div>
                                                    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtddBank" runat="server" Width="250px"></asp:TextBox></div>
                                                    </div>
                                                    <div class="row">&nbsp;</div>
                                                <div class="row"><div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Branch :</div>
                                                    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtddBranch" runat="server" Width="250px"></asp:TextBox></div>
                                                    </div>
                                                    <div class="row">&nbsp;</div>
                                                <div class="row"><div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Date:</div>
                                                <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtddDate" runat="server" Width="250px"></asp:TextBox>&nbsp;<span style="font:small;">(mm/dd/yyyy)</span></div>
                                                </div>
                                                <div class="row">&nbsp;</div>
                                                <%--<tr>
                                                    <td style="width: 30%; padding-left:5px" align="left">
                                                        Amount:</td>
                                                    <td align="left">
                                                             <asp:Label ID="lblddAmount" runat="server" ></asp:Label></td>
                                                </tr>--%>
                                            <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                                <asp:Button ID="btnSubmitDD" CssClass="btn btn-large btn-primary" runat="server" onclick="btnSubmitDD_Click"  OnClientClick="javascript:return ValidateDDSubmit();"
                                                            Text="Submit" />
                                                    </div>
                                                    </div>
                                            </asp:Panel>
                                            </div>
                                            </div>
                                            </div>
                                            </div>           
              <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                        <div class="box"><div class="box-body">
                                        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <asp:RadioButton ID="rdoCheque" runat="server" Text="Cheque" GroupName="p" 
                                                                CssClass="RadioButtonWidth" AutoPostBack="True" 
                                                                oncheckedchanged="rdoCheque_CheckedChanged" />
                                                       </div>
                                                       </div>
                                                       <asp:Panel  ID="pnlCheque" runat="server" Visible="false">
                                            <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="txtchqPayable" runat="server" Text="Cheque should be made in favour of <b>'FMSF Learning Systems.'</b> Payable at New Delhi"></asp:Label></div></div>
                                            <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Enter Cheque No:</div>
                                            <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtChequeNo" runat="server" Width="250px"></asp:TextBox></div>
                                            </div>
                                             <div class="row">&nbsp;</div>       
                                              <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Bank Name:</div>
                                            <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtchqBank" runat="server" Width="250px"></asp:TextBox></div>
                                            </div>
                                              <div class="row">&nbsp;</div>       
                                              <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Branch :</div>
                                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtchqBranch" runat="server" Width="250px"></asp:TextBox></div>
                                             </div>
                                             <div class="row">&nbsp;</div>       
                                              <div class="row">
                                               <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Date:</div>
                                               <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtchqDate" runat="server" Width="250px"></asp:TextBox> &nbsp;<span style="font:small;">(mm/dd/yyyy)</span></div>
                                               </div>
                                                
                                                <%--<tr>
                                                    <td style="width: 30%; padding-left:5px" align="left">
                                                        Amount:</td>
                                                    <td align="left">
                                                             <asp:Label ID="lblchqAmount" runat="server" ></asp:Label></td>
                                                </tr>--%>
                                              <div class="row">&nbsp;</div>       
                                              <div class="row">
                                               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                            <asp:Button ID="btnSubmitCheque" runat="server" CssClass="brn btn-large btn-primary" Text="Submit" onclick="btnSubmitCheque_Click" OnClientClick="javascript:return ValidateChequeSubmit();" /></div>
                                            </div>
                                            </asp:Panel>
                                                       
                                             </div>
                                             </div>
                                             </div>
                                             </div>
              <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                        <div class="box"><div class="box-body">
                                        <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Fee Type :</div>
                                         <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblFeeType" runat="server"></asp:Label></div>
                                         </div>
                                         <div class="row">&nbsp;</div>
                                         <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Course Fee:</div>
                                         <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblPrice" runat="server"></asp:Label> &nbsp;<asp:Label ID="lblCurrencyType" runat="server"></asp:Label></div>
                                         </div>
                                         </div>
                                         </div>          
                                         </div>
                                         </div>
                  
                  </div>
        
</section>
</div>
</asp:Content>

