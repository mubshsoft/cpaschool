<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="StudentPerformaneCourse.aspx.vb" Inherits="Student_StudentPerformaneCourse" Title="List of course" %>

 
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
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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

<div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            List of Course
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">List of Course</li>
          </ol>
        </section>
    <section class="content">
            
    

    
     <div style="overflow:auto">
                                                          <asp:GridView ID="GrdCourseApply" AutoGenerateColumns="false" runat="server" DataKeyNames="stid"
                                                    Width="97%" AllowPaging="true" PageSize="5" CssClass="table form_body">
                                                    <HeaderStyle CssClass="form_head" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course Title" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate >
                                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("CourseTitle") %>' runat="server"  ></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate >
                                                               
                                                                    <%# Eval("CourseCode") %> 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <a id="a1" href="PerformanceSheet.aspx?cid=<%#Container.DataItem("courseID")%>&stid=<%#Container.DataItem("stid")%>&bt=<%#Container.DataItem("bid")%>">
                                                                    View </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                         
                                                    </Columns>
                                                </asp:GridView>
                                                        </div>
                                                        
    
    
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js" ></script>
    
    </asp:Content>