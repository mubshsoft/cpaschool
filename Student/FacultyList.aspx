<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master" CodeFile="FacultyList.aspx.cs" Inherits="FacultyList" Title="Faculty List" %>
<%--
<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title></title>

    <script type="text/javascript" src="../stmenu.js"></script>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #0e245d;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript">
    function openPopup(strOpen)
    {
        //alert(strOpen);
       open(strOpen, "FacultyDetails", "status=1, width=800, height=500, top=00, left=200");
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
    </script>

    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
    </style>

<div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            List of Faculty
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">List ofFaculty</li>
          </ol>
        </section>
    <section class="content">
            
    

    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
    <%--<div onkeypress="javascript:HideMessage()"></div>--%>
        <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            </div></div>
                                                            <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb">
      <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" />
     </div>
     </div>                                                       
     
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb">
                    <asp:DropDownList ID="ddlPaper" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPaper_SelectedIndexChanged"/>
                </div>         
     </div>
     <div class="row">&nbsp;</div> 
     <div style="overflow:auto">
                                                            <asp:GridView ID="grdFacultySet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                 AllowPaging="true" PageSize="10" CssClass="table form_body" OnPageIndexChanging="grdFacultySet_PageIndexChanging" style="background:#fff;">
                                                                <HeaderStyle CssClass="form_head"  />
                                                                <RowStyle  />
                                                                <AlternatingRowStyle />
                                                                <HeaderStyle />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Faculty Name">
                                                                        <ItemStyle HorizontalAlign="left"   />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:openPopup('FacultyDetails.aspx?facultyid=<%#Eval("fid")%>&PaperTitle=<%#Eval("PaperTitle")%>')">
                                                                                <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>' Width="100%"></asp:Label></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Paper No.">
                                                                        <ItemStyle HorizontalAlign="left"   />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Semester" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle HorizontalAlign="center"  />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemStyle HorizontalAlign="center"  />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                            </asp:GridView>
                                                        </div>
                                                        
    
    
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
    </asp:Content>