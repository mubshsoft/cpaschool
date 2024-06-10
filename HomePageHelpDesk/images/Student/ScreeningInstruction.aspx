<%@ Page Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="ScreeningInstruction.aspx.cs" Inherits="ScreeningInstruction" %>


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
    

    

    <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Screening Instruction
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Dashboard</a></li>
            <li class="active">Screening Instruction</li>
          </ol>
        </section>
    <section class="content">
     <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    
     <div onkeypress="javascript:HideMessage()">
  
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                       
                        <tr>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px" >
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 10px; padding-bottom: 20px;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                      
                                                  <tr><td><table width="100%">
                                                              <tr>
                                            <td align="left">
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
                                            </td>
                                        </tr>
                                                            <tr><td><asp:HiddenField ID="hdnScrId" runat="server" /></td></tr>
                                                            <tr><td align="center" valign="middle" class="style5"><b></b></td></tr>
                                                            <tr><td align="center" valign="middle" class="style5"><asp:ImageButton ID="btnStartScreening" runat="server" 
                                                    ImageUrl="~/Images/start_Screening.png" onclick="btnStartScreening_Click" /></td></tr>
                                                           </table>
                                                        </td></tr>
                                                </table>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
   
    </div>
    
   
    
    </div>
    </div>
   
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
 <script language="javascript" type="text/javascript">

     $(document).ready(function () {
        // alert('hi');
     });
     </script>
    </asp:Content>
                            

