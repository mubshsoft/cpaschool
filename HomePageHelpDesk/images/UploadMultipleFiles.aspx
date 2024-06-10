<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UploadMultipleFiles.aspx.vb" Inherits="UploadMultipleFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="css/font-awesome.min.css"/>
    <link rel="stylesheet" href="css/sl-slide.css"/>
    <link rel="stylesheet" href="css/main.css"/>

</head>
<body>
    <form id="form1" runat="server">
    <section class="container main">
        
          <div class="row-fluid" >
            <div class="span12">
               <fieldset> 
                   <legend style="font-family: Verdana; font-size: 11px; font-weight: bold;border:solid;text-align:center;">
                       <span style="text-align:center;font-weight:bold;"> Upload Files for Topic</span></legend><br />
                       
                            1. You are able to upload multiple fils<br />
                            2. Upload file of following types<br />
                               Text file, DOC, PDF, Images, EXCEL and Videos (MP3 & MP4)
                            3. File size must be less than 5 MB  
                   <hr style="border-bottom:double;color:black" />
                                        
                </fieldset> 

            </div>
        </div>
        <div class="row-fluid" >
            <div class="span12" style="text-align:center">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" ></asp:Label>
            </div>
        </div>
        <div class="row-fluid" >
            <div class="span6">
                <asp:FileUpload ID="FileUpload1" Multiple="Multiple" runat="server" /> &nbsp;<asp:Button ID="btnUpload" runat="server" Text="upload" CssClass="btn btn-success btn"  />
            </div>
            <div class="span6">
                 
            </div>
           
        </div>
       
        <div class="row-fluid" >
            <div class="span12">
                <asp:Repeater ID="dlstFileUpload" runat="server" >
                                                    <HeaderTemplate>  <table class="table table-striped table-bordered table-advance table-hover">
                                        <thead>
                                        <tr>
                                        <th><i class="icon-leaf"></i> <span class="hidden-phone">Sno.</span></th>
                                            <th><i class="icon-leaf"></i> <span class="hidden-phone">File Name</span></th>
                                            <th><i class="icon-remove"> </i><span class="hidden-phone">Delete</span></th>
                                            
                                        </tr>
                                        </thead>
                                        <tbody></HeaderTemplate>
                                                    <ItemTemplate>
     
            <tr>
            <td><%# Container.ItemIndex + 1 %></td>
                <td align = "center">
                    <%# Eval("Filename")%>
                </td>
                
                <td> <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Filepath") %>' runat = "server" OnClick = "DeleteFile" CssClass="btn btn-danger"  OnClientClick="javascript:return confirm('Are you sure you want to delete the file ?')"/>
                 <asp:HiddenField ID="hdnfilename" runat="server" Value='<%# Eval("Filename") %>' />
                <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%# Eval("Filepath") %>' />
                 <asp:HiddenField ID="hdnFilesize" runat="server" Value='<%# Eval("Filesize") %>' />
                </td>
            </tr>
       
    </ItemTemplate>
    <FooterTemplate> </tbody>
                                    </table></FooterTemplate></asp:Repeater>
            </div>
        </div> 
         <div class="row-fluid" >
            <div class="span12">
                <asp:Button ID="btnclose" runat="server" Text="Close" CssClass="btn btn-primary" />
            </div>
        </div> 
    </section>
    <div>
    
    </div>
    </form>
</body>
</html>
