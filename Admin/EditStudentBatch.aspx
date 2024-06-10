<%@ Page Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="EditStudentBatch.aspx.vb" Inherits="Admin_EditStudentBatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
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
                     
                     
             function SelectAllCheckboxes(spanChk)
                 {

                    var oItem = spanChk.children;
                    var theBox= (spanChk.type=="checkbox") ? 
                    spanChk : spanChk.children.item[0];
                    xState=theBox.checked;
                    elm=theBox.form.elements;

                        for(i=0;i<elm.length;i++)
                            if(elm[i].type=="checkbox" && 
                                elm[i].id!=theBox.id)
                                {
                                  //elm[i].click();
                                   if(elm[i].checked!=xState)
                                    elm[i].click();
                                   //elm[i].checked=xState;
                                 }
                                 
                    }

    </script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">List of batch</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">List of batch</li>
		</ul>
	</div>
    </section>
    

    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
       
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate >

             

    <section class="container main m-tb">
    <div class="row">&nbsp;</div>
    <div class="user-info media box" style="background-color:#fff;"> 
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                </div>
                
                <div class="row">
                 <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Course Name : </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                <asp:Label ID="lblCourse" runat="server" ></asp:Label>
                </div>
                </div>
                <div class="row">
                 <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Batch Name : </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                <asp:Label ID="lblBatch" runat="server" ></asp:Label>
                </div>
                </div>
                <div class="row">
                 <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Student Name : </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                <asp:Label ID="lblStudent" runat="server" ></asp:Label>
                </div>
                </div>
                <div class="row">
                 <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Email : </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                <asp:Label ID="lblemail" runat="server" ></asp:Label>
                </div>
                </div>
                </div>
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="true" ToolTip="Batch Code" CssClass="form-control"></asp:DropDownList>
                </div>
                </div>
                
                
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                              
                      

                </div>
                </div>
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                            
                                                    <asp:button ID="btnSave" Text="Move in New Batch" CssClass="btn btn-success btn-large "  runat="server"/>
                                                    
                                                <asp:Button ID="btncancel" Text="Cancel" CssClass="btn btn-warning btn-large " runat="server" />
                                            </div>
                                            </div>
                                            <div class="row">&nbsp;</div>


</section>
                                  </ContentTemplate>
                                </asp:UpdatePanel>
      
                    </div>
               
    
    </form>


</asp:Content>
