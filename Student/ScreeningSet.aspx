<%@ Page Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="ScreeningSet.aspx.cs" Inherits="ScreeningSet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    
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


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; height:15px;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; height:15px; }
    </style>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
          <h1>
            Screening Set
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Screening Set</li>
          </ol>
        </section>
        <section class="content">

     <div onkeypress="javascript:HideMessage()">
  <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                       </div>
                                                       </div>
<div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:GridView ID="grdScreeningSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="ScrID" onrowdatabound="grdScreeningSet_RowDataBound" >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                        <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                           <asp:TemplateField HeaderText="Paper No."  Visible="false">
                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      <asp:HiddenField ID="hdPaperTitle" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>' />
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Name">
                                                        <ItemStyle HorizontalAlign="center" Width="250px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblScreeningcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ScreeningCode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:TemplateField HeaderText="Course" Visible="false">
                                                        <ItemStyle HorizontalAlign="center" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Semester"  Visible="false">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module"  Visible="false">
                                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                    
                                                         <asp:TemplateField>
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnScreeningID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ScrId")%>' />
                           <asp:HiddenField ID="hdnScreeningtype" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Screeningtype")%>' />
                            <%--<asp:HiddenField ID="hdnScreeningPath" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ScreeningPath")%>' />--%>
                          <asp:LinkButton ID="lnkDetailsScreening" runat="server" Font-Underline="false"  Font-Bold="true"
                                Text="Start"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                       
   </div>
   </div>
    </div>
    </section>
    </div>
    </asp:content>
    
  

