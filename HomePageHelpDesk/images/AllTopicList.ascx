<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AllTopicList.ascx.vb" Inherits="AllTopicList" %>
<div class="span12">
    <div class="pull-right">
    <asp:Button ID="imgBack" runat="server" Text="Back to Topic" class="btn btn-success btn-large"/>&nbsp;&nbsp;
    <asp:Button ID="ImgbtnPostReply" runat="server" Text="Post Reply"  class="btn btn-primary btn-large"/>
    </div>
</div>
            <%--<asp:ImageButton ID="ImgbtnPostReply" runat="server" ImageUrl="~/Images/post_reply.png" />--%>
<h3> <asp:Label ID="lblmainTopic" runat="server" Text=""></asp:Label></h3>
<asp:LinkButton ID="lnkFile" runat="server" Text="Attachment" OnClick="lnkFile_Click" Visible="false" ></asp:LinkButton><br />
<asp:Label ID="Label1" runat="server"></asp:Label><br />
<asp:Label ID="lblNoTopic" runat="server" Text="NO REPLY FOUND.CLICK POST REPLY TO ADD."></asp:Label>

            <asp:Repeater ID="dlstFileUpload" runat="server" >
                                                    <HeaderTemplate>  <table class="table table-striped table-bordered table-advance table-hover">
                                        <thead>
                                        <tr>
                                        <th><i class="fa fa-leaf"></i> <span class="hidden-phone">Sno.</span></th>
                                        <th><i class="fa fa-leaf"></i> <span class="hidden-phone">File Name</span></th>
                                        <th><i class='fa fa-download'></i> <span class="hidden-phone">Download</span></th>
                                        </tr>
                                        </thead>
                                        <tbody></HeaderTemplate>
                                                    <ItemTemplate>
     
            <tr>
            <td><%# Container.ItemIndex + 1 %></td>
                <td align = "center">
                    <%# Eval("Filename")%>
                </td>
                
                <td> 
                     <asp:LinkButton ID = "lnkDownload" Text = "DownLoad" CommandArgument = '<%# Eval("Filepath") %>' runat = "server" OnClick = "DownloadFile" CssClass="btn btn-success"  />
                 <asp:HiddenField ID="hdnfilename" runat="server" Value='<%# Eval("Filename") %>' />
                <asp:HiddenField ID="hdnfilepath" runat="server" Value='<%# Eval("Filepath") %>' />
                 <asp:HiddenField ID="hdnFilesize" runat="server" Value='<%# Eval("Filesize") %>' />
                </td>
            </tr>
       
    </ItemTemplate>
    <FooterTemplate> </tbody>
                                    </table></FooterTemplate></asp:Repeater>
         <asp:Repeater ID="grdTopic" runat="server" onitemdatabound="grdTopic_ItemDataBound">
                <ItemTemplate>
                    
                    <div class="blog">
                        <div class="blog-item well" style="background-color: #ffffff;">
                            <div class="blog-meta clearfix">
                                <p class="pull-left">
                                    <h5><i class="icon-user"></i> Posted by <a href="#"><asp:Label ID="lblUserName" runat="server" Text='<%# Bind("email") %>'></asp:Label></b></a> <span class="pull-right"> <i class="icon-calendar" style="color:#d4d2d2"></i> <asp:Label ID="lblDateOfPosting" runat="server" Text='<%# Bind("dateofposting","{0:dd-MM-yyyy}") %>' style="color:#d4d2d2"></asp:Label></span></h5>
                                </p>
                                <%--<p class="pull-right"><i class="icon-comment pull"></i> <a href="blog-item.html#comments">3 Comments</a></p>--%>
                            </div>
                            <hr />
                            <div style="padding-left:20px">
                            <p id="a123">
                            
                                <%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "subjecttext"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%>
                            
                            </p></div>
                            <%--<a class="btn btn-link" href="#">Read More <i class="icon-angle-right"></i></a>--%>
                            <asp:HiddenField ID="hdnSubSubjectid" runat="server" value='<%# Bind("SubSubjectid") %>' />
                            <asp:HiddenField ID="hdnSubjectid" runat="server" value='<%# Bind("Subjectid") %>' />
                            <asp:HiddenField ID="hdnEmail" runat="server" value='<%# Bind("Email") %>' />
                            <span class="pull-right" style="vertical-align:top"> 
                            <asp:LinkButton ID="lnkbtnreplies" runat="server" Visible="false"> <i class="icon-edit" style="color:#d4d2d2"></i>&nbsp;Edit Replies</asp:LinkButton>
                                </span>
                         </div>
                    </div>


                </ItemTemplate>
            </asp:Repeater>   
            