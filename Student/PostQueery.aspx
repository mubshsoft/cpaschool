<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="PostQueery.aspx.vb" Inherits="Student_PostQueery" Title="Post Query" %>

<%--
<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Post Query</title>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}

</style>
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


<!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper">
<!-- Content Header (Page header) -->
        <section class="content-header">
        <h1>Post Query</h1>
         <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Post Query</li>
          </ol>
        </section>
           
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 
                                 
    <%--<div onkeypress="javascript:HideMessage()"></div>--%>
     <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <div>
                                   
    <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red" CssClass="arial"></asp:Label></div>
     </div> 
     </div>
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     <div class="box box-primary">
     <div class="box-body"> 
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate >                                       
    <div class="row">
    <div class="col-lg-2 col-md-3 col-sm-12 col-xs-12 form_text field-label margin-tb">Query For :</div>
    <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="dllList" runat="server" CssClass="form-control" AutoPostBack="true" >
                                                                      <asp:ListItem>SELECT</asp:ListItem>
                                                                     
                                                                    <asp:ListItem Value="Admin"></asp:ListItem>
                                                                    <asp:ListItem Value="Faculty"></asp:ListItem>
                                                                    <asp:ListItem Value="Course Coordinator"></asp:ListItem>
                                                                  </asp:DropDownList></div>
    <div class="col-lg-2 col-md-3 col-sm-12 col-xs-12 form_text field-label margin-tb">Faculty :</div>
    <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="dllFaculty" runat="server" CssClass="form-control" AutoPostBack="true" ></asp:DropDownList></div>
    </div>  
    <div class="row">
    <div class="col-lg-2 col-md-3 col-sm-12 col-xs-12 form_text field-label margin-tb">Subject :</div>
    <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" Title="Subject" ToolTip="Subject"></asp:TextBox></div>
    <div class="col-lg-2 col-md-3 col-sm-12 col-xs-12 form_text field-label margin-tb">Your Query :</div>
    <div class="col-lg-4 col-md-3 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtQuery" runat="server"  TextMode="MultiLine" CssClass="form-control" Title="Your Query" ToolTip="Your Query"></asp:TextBox></div>
    </div>  
    
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-large arial"  />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-large arial"  /></div>
    </div>                  

                                                        
                                                           
                                                           </ContentTemplate>
    </asp:UpdatePanel>
     </div>
     </div>
     </div>
     </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="box box-primary">
            <div class="box-header">
              <h3 class="box-title">Post Query Status</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <table class="table table-striped">
                <tbody>

              
                                            
                                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                          <ContentTemplate >
                                                <asp:GridView ID="GrdQuery" AutoGenerateColumns="false" runat="server" DataKeyNames="QueryId"
                                                    Width="97%" AllowPaging="True" PageSize="10">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle  />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFacID" Text='<%# Eval("fId") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="QueryId" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQueryId" Text='<%# Eval("QueryId") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Query For" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFid" Text='<%# Eval("firstName") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" Text='<%# Eval("email") %>' runat="server" ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Subject" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server"
                                                                   ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Query" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQuery" Text='<%# Eval("Query") %>' runat="server"
                                                                    ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                              <%--<font color="red"> <%#ReplaceStatus(Eval("Status"))%> </font>--%>
                                                               <asp:LinkButton  ID="lblStatus" Text='<%#ReplaceStatus(Eval("Status"))%>' runat="server" CssClass="gridlink"></asp:LinkButton>
                                                             </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <%--<asp:TemplateField  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                              <asp:LinkButton  ID="lnk" Text='<%#Eval("QueryId")%>' runat="server" ></asp:LinkButton>
                                                             </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                                </ContentTemplate>
    </asp:UpdatePanel>
                                              </tbody></table>
            </div>
            <!-- /.box-body -->
          </div>
                                                </div>
                                            </div>
                                               
                                    
                                
    

  
  </section>
  </div>

    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>
