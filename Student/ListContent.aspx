<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="ListContent.aspx.vb" Inherits="Student_ListContent" Title="List Content" %>
<%--
<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List Content</title>
<script type="text/javascript" src="../stmenu.js"></script>
--%>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style>
       
     /*.modal-dialog {
  margin-top: 0;
  margin-bottom: 0;
  height: 100vh;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.modal.fade .modal-dialog {
  transform: translate(0, -100%);
}

.modal.in .modal-dialog {
  transform: translate(0, 0);
}*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        var statusmsg = ""
        function hidestatus() {
            window.status = statusmsg
            return true
        }

    </script>
    <script>
        function ViewResourceFile(fn, paperid, unitid) {
            var url = "../ViewDetail.aspx?fnm=" + fn + "&paperid=" + paperid + "&unitid=" + unitid;

            $('#ifrm').attr('src', url)


            $("#ModalPopupDivPlayVideo").css("width", "1000px");
            $('#ModalPopupDivPlayVideo').modal('show');

            //$('.modal-dialog').draggable();


            // window.open("../ViewDetail.aspx?fnm=" + fn + "&paperid=" + paperid + "&unitid=" + unitid, '_blank', 'toolbar=0, location=0, menubar=0');
        }
        

    </script>
   <script language="javascript" type="text/javascript">
       function openmodalPopUp(popupId) {

           $('#' + popupId).modal('show');

       }
    </script>
     <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            Course Material
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Course Material</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">     

    <div style="margin-top:20px;">
    <div class="row">
        
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" ><asp:DropDownList ID="dllSem" runat="server" AutoPostBack="true" CssClass="form-control" >
                                            </asp:DropDownList></div></div>
      <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                       
                                                <%
                                                    If dsmodule IsNot Nothing Then
                                                        If dsmodule.Tables IsNot Nothing Then
                                                            If dsmodule.Tables(0).Rows IsNot Nothing Then
                                                                If dsmodule.Tables(0).Rows.Count > 0 Then
                                                %>
                                                <div style="padding-left:15px; height:20px; width:100% ">
                                                     <b> 
                                                      <%if semcount >1 then %>
                                                     <%=strsem %>
                                                     <%End If %>
                                                     </b>
                                                 </div>
                                                   
                                                 <table class="table" cellpadding="0" cellspacing="0">
                                                    <%Dim i As Integer%>
                                                    <%i = 0%>
                                                    <% While i < dsmodule.Tables(0).Rows.Count%>
                                                    <tr>
                                                        <td width="100%" align="left" style="height:20px" bgcolor="#ebebeb">
                                                      
                                                          <div  style="padding:5px 0; width:100%">
                                                                <% strmoduleTitle = dsmodule.Tables(0).Rows(i)("ModuleTitle").ToString%>
                                                                <% moduleId=  dsmodule.Tables(0).Rows(i)("ModuleID").ToString%>
                                                                <b><%=strmoduleTitle%></b>
                                                            </div>
                                                                
                                                              <%
                                                                  Dim strPaper As String = "select * from paper where moduleid=" & CInt(dsmodule.Tables(0).Rows(i)("ModuleId").ToString) & " order by paperid"
                                                                dspaper = CLS.fnQuerySelectDs(strPaper)
                                                                Dim iPaper As Integer
                                                                iPaper = 0
                                                                If dspaper IsNot Nothing Then
                                                                    If dspaper.Tables IsNot Nothing Then
                                                                        If dspaper.Tables(0).Rows IsNot Nothing Then
                                                                            If dspaper.Tables(0).Rows.Count > 0 Then
                                                            %>
                                                            
                                                              <table style="width:100%; padding-top:5px" class="table" cellpadding="0" cellspacing="0">
                                                                <% While iPaper < dspaper.Tables(0).Rows.Count%>
                                                                                                                               
                                                                <tr>
                                                                    <td width="100%" align="left" style="height:20px;">
                                                                     <div style="width:100%;padding:5px 0;">
                                                                        <%strpaperTitle = dspaper.Tables(0).Rows(iPaper)("PaperTitle").ToString%>
                                                                        <%paperid = dspaper.Tables(0).Rows(iPaper)("PaperID").ToString%>
                                                                      <b>  <%=strpaperTitle%></b>
                                                                        </div>
                                                                        <%
                                                                           ' Session("strdownloadPath") = Server.MapPath("..") & "\upload\" & strCourse & "\" & strsem & "\" & strmoduleTitle & "\" & strpaperTitle
                                                                            'Dim strUnit As String = "select * from unit where paperid=" & CInt(dspaper.Tables(0).Rows(i)("paperId").ToString)
                                                                            'dsunit = CLS.fnQuerySelectDs(strUnit)
                                                                            'Dim iUnit As Integer
                                                                            'iPaper = 0
                                                                            'If dsunit IsNot Nothing Then
                                                                            '    If dsunit.Tables IsNot Nothing Then
                                                                            '        If dsunit.Tables(0).Rows IsNot Nothing Then
                                                                            '            If dsunit.Tables(0).Rows.Count > 0 Then
                                                                          %>
                                                                           <div>
                                                                                  <table class="table" style="width:100%" cellpadding="0" cellspacing="0">
                                                                <%try %>
                                                                 <%
                                                                Dim strUnitQ As String
                                                                Dim dsUnit As New DataSet
                                                                Dim iUnit As Integer=0
                                                                     Dim strUnitTitle As String
                                                                     Dim strMode as String
                                                                     Dim unitid As Integer
                                                                     strUnitQ = "select unitid,uploadfilepath,unitTitle,Mode from unit where paperid=" & paperid
                                                                dsUnit=CLS.fnQuerySelectDs(strUnitQ)
                                                                   
                                                                      If dsUnit IsNot Nothing Then
                                                                        If dsUnit.Tables IsNot Nothing Then
                                                                            If dsUnit.Tables(0).Rows IsNot Nothing Then
                                                                                 If dsUnit.Tables(0).Rows.Count > 0 Then%>
                                                                                     <tr>
                                                                                      <td colspan="2" width="80%" align="left" style="padding-left:65px;height:20px; padding-top:5px; padding-bottom:5px">
                                                                                    
                                                                                     <strong>Units</strong>
                                                                                     
                                                                                     </td>
                                                                                     
                                                                                     </tr>
                                                                                     
                                                                                 <% For iUnit = 0 To dsUnit.Tables(0).Rows.Count - 1%>
                                                                                           <tr>
                                                                                           <td width="500px" align="left" style="padding-left:65px;height:20px; padding-top:5px; padding-bottom:5px">
                                                                                          <%  Dim full As String = dsUnit.Tables(0).Rows(iUnit)("uploadfilepath").ToString
                                                                                              unitid = dsUnit.Tables(0).Rows(iUnit)("unitid").ToString
                                                                                              strMode = dsUnit.Tables(0).Rows(iUnit)("Mode").ToString
                                                                                          Dim filename as String = System.IO.Path.GetFileName(full)
                                                                                          Dim strext As String
                                                                                          strext=MyCLS.fnGetExtension(filename)
                                                                                          Dim strFileName As String
                                                                                          %>
                                                                                          
                                                                                            <%strFileName = filename%>
                                                                                                                                                          
                                                                                            <%strUnitTitle = dsunit.Tables(0).Rows(iunit)("unittitle").ToString%>
                                                                                            <%=strunittitle %>

                                                                                            </td>
                                                                                                    
                                                                                                <td width="20%" align="left" style=" padding-left:5px">
                                                                                                    <%if strMode = "View" Then %>
                                                                                                   <a href="#" onclick="ViewResourceFile('<%=filename %>',<%=paperid %>,<%=unitid %>)" >
                                                                                                     <asp:HiddenField ID="hdnFname" runat="server" Value='<%=filename %>' />
                                                                                                       View </a>
                                                                                                     <%else %>
                                                                                                      <a href="../DownloadDetail.aspx?fnm=<%=FileName %>&dt=lc&paperid=<%=paperid %>&unitid=<%=unitid %>" onMouseover="return hidestatus()" onclick="return hidestatus()">
                                                                                                       Download </a>
                                                                                                     <%End If %>

                                                                                                  <%--<a href="../DownloadDetail.aspx?fnm=<%=FileName %>&dt=lc&paperid=<%=paperid %>&unitid=<%=unitid %>" onMouseover="return hidestatus()" onclick="return hidestatus()">
                                                                                                       Download </a>--%>
                                                                                               </td>
                                                                                               <td width="20%" align="left" style=" padding-left:5px">
                                                                                                   <%--<a href="#" onclick="ViewResourceFile('<%=filename %>','wahidbgp@gmail.com')" >
                                                                                                       View </a>--%> 

                                                                                                  
                                                                                               </td>
                                                                                           </tr>
                                                                                           <tr style="height:1px"></tr>
                                                                                       <%next%>
                                                                                       <% end if %>
                                                                                     <% end if %>
                                                                                  <% end if %>
                                                                             <% end if %>
                                                                                       
                                                                   
                                                                   
                                                                   
                                                                   <%catch ex as exception %>
                                                                   <%end try %>
                                                                </table>
                                                                            </div>
                                                                        <% 'End If%>
                                                                        <% 'End If%>
                                                                        <% 'End If%>
                                                                        <% 'End If%>
                                                                    </td>
                                                                </tr>
                                                                <%iPaper = iPaper + 1%>
                                                                <%End While%>
                                                            </table>
                                                            <%
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                                            %>
                                                        </td>
                                                    </tr>
                                                    <%i = i + 1%>
                                                    <%End While%>
                                                </table>
                                                <%     
                                                End If
                                            End If
                                        End If
                                    End If
                                                %>

                                                </div>
                                                </div>
                                
    </div>
    </div>
    </div>
     
    </section>

        <div class="modal fade in" id="ModalPopupDivPlayVideo" aria-hidden="false" style="align-content:flex-start">
    <div class="modal-dialog" >
    <div class="modal-content">
    <div class="modal-header">
        <i class="icon-remove" data-dismiss="modal" aria-hidden="true"></i>
        <h4>View</h4>
    </div>
    <!--Modal Body-->
    <div class="modal-body" style="height:auto">
        <%--<div class="scroller" data-height="900px">--%>
         <iframe id="ifrm" style="width:1000px;height:900px;" ></iframe>
            
        <%--</div> --%>
    </div>
        <div class="modal-footer" style="text-align:center" >
        
        
    </div>
        </div>
    </div>
    <!--/Modal Body-->
</div>
</div>

<script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>