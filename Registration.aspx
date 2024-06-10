<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="Registration.aspx.vb" Inherits="Admin_Registration" Title="Registration" %>

<%--<%@ Register Src="MainHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
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
                     
                       function HideMessage2()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage2.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage2.ClientID%>').textContent ='';
                        }
                     }
                     
                       function HideMessage3()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage3.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage3.ClientID%>').textContent ='';
                        }
                     }
                      
                         function HideMessage4()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage4.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage4.ClientID%>').textContent ='';
                        }
                     }
                         
                         function HideMessage5()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage5.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage5.ClientID%>').textContent ='';
                        }
                     }
                     
                     function openPopup(strOpen)
                         {
                          var options = 'scrollbars=yes,resizable=yes,status=no,toolbar=no,menubar=no,location=no';    options += ',width=' + screen.availWidth + ',height=' + screen.availHeight;    options += ',screenX=0,screenY=0,top=0,left=0';    
                          var win = window.open(strOpen, '', options);    
                          win.focus();    
                          win.moveTo(0, 0); 
                         
                         
                          //open(strOpen, "Info", "status=1, width=900, height=800, top=20, left=300,scrollbars=yes");
                         }
    </script>
    <style>body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color">Register</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Register</li>
		</ul>
	</div>
</section>
<!-- / .title -->
    <form id="form1" runat="server">
    <%--<div onkeypress="HideMessage(),HideMessage2(),HideMessage3(),HideMessage4(),HideMessage5()" ALIGN="center"></div>--%>
      
    

    <section class="container main">
    <div class="row">&nbsp;</div>
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

    <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
    <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
                 <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Course Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Select Course :<asp:Label ID="lblred1" Text="*" ForeColor="Red" runat="server" ></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
                                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="input-block-level" required="required" placeholder="Course" title="Course"/>
                              </div>
                </div>
                   <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="dllCountry" runat="server" CssClass="input-block-level">
                                                                <asp:ListItem Value="0">- Select -</asp:ListItem>
                                                                <asp:ListItem>Afghanistan</asp:ListItem>
                                                                <asp:ListItem>Albania</asp:ListItem>
                                                                <asp:ListItem>Algeria</asp:ListItem>
                                                                <asp:ListItem>Andorra</asp:ListItem>
                                                                <asp:ListItem>Angola</asp:ListItem>
                                                                <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                                                                <asp:ListItem>Argentina</asp:ListItem>
                                                                <asp:ListItem>Armenia</asp:ListItem>
                                                                <asp:ListItem>Australia</asp:ListItem>
                                                                <asp:ListItem>Austria</asp:ListItem>
                                                                <asp:ListItem>Azerbaijan</asp:ListItem>
                                                                <asp:ListItem>Bahamas</asp:ListItem>
                                                                <asp:ListItem>Bahrain</asp:ListItem>
                                                                <asp:ListItem>Bangladesh</asp:ListItem>
                                                                <asp:ListItem>Barbados</asp:ListItem>
                                                                <asp:ListItem>Belarus</asp:ListItem>
                                                                <asp:ListItem>Belgium</asp:ListItem>
                                                                <asp:ListItem>Belize</asp:ListItem>
                                                                <asp:ListItem>Benin</asp:ListItem>
                                                                <asp:ListItem>Bhutan</asp:ListItem>
                                                                <asp:ListItem>Bolivia</asp:ListItem>
                                                                <asp:ListItem>Bosnia and Herzegovina</asp:ListItem>
                                                                <asp:ListItem>Botswana</asp:ListItem>
                                                                <asp:ListItem>Brazil</asp:ListItem>
                                                                <asp:ListItem>Brunei</asp:ListItem>
                                                                <asp:ListItem>Bulgaria</asp:ListItem>
                                                                <asp:ListItem>Burkina Faso</asp:ListItem>
                                                                <asp:ListItem>Burma</asp:ListItem>
                                                                <asp:ListItem>Burundi</asp:ListItem>
                                                                <asp:ListItem>Cambodia</asp:ListItem>
                                                                <asp:ListItem>Cameroon</asp:ListItem>
                                                                <asp:ListItem>Canada</asp:ListItem>
                                                                <asp:ListItem>Cape Verde</asp:ListItem>
                                                                <asp:ListItem>Central African Republic</asp:ListItem>
                                                                <asp:ListItem>Chad</asp:ListItem>
                                                                <asp:ListItem>Chile</asp:ListItem>
                                                                <asp:ListItem>China</asp:ListItem>
                                                                <asp:ListItem>Colombia</asp:ListItem>
                                                                <asp:ListItem>Comoros</asp:ListItem>
                                                                <asp:ListItem>Congo</asp:ListItem>
                                                                <asp:ListItem>Costa Rica</asp:ListItem>
                                                                <asp:ListItem>Cote d Ivoire</asp:ListItem>
                                                                <asp:ListItem>Croatia</asp:ListItem>
                                                                <asp:ListItem>Cuba</asp:ListItem>
                                                                <asp:ListItem>Cyprus</asp:ListItem>
                                                                <asp:ListItem>Czech Republic</asp:ListItem>
                                                                <asp:ListItem>Denmark</asp:ListItem>
                                                                <asp:ListItem>Djibouti</asp:ListItem>
                                                                <asp:ListItem>Dominica</asp:ListItem>
                                                                <asp:ListItem>Dominican Republic</asp:ListItem>
                                                                <asp:ListItem>East Timor</asp:ListItem>
                                                                <asp:ListItem>Ecuador</asp:ListItem>
                                                                <asp:ListItem>Egypt</asp:ListItem>
                                                                <asp:ListItem>El Salvador</asp:ListItem>
                                                                <asp:ListItem>Equatorial Guinea</asp:ListItem>
                                                                <asp:ListItem>Eritrea</asp:ListItem>
                                                                <asp:ListItem>Estonia</asp:ListItem>
                                                                <asp:ListItem>Ethiopia</asp:ListItem>
                                                                <asp:ListItem>Fiji</asp:ListItem>
                                                                <asp:ListItem>Finland</asp:ListItem>
                                                                <asp:ListItem>France</asp:ListItem>
                                                                <asp:ListItem>Fabon</asp:ListItem>
                                                                <asp:ListItem>Fambia</asp:ListItem>
                                                                <asp:ListItem>Feorgia</asp:ListItem>
                                                                <asp:ListItem>Fermany</asp:ListItem>
                                                                <asp:ListItem>Fhana</asp:ListItem>
                                                                <asp:ListItem>Freece</asp:ListItem>
                                                                <asp:ListItem>Frenada</asp:ListItem>
                                                                <asp:ListItem>Fuatemala</asp:ListItem>
                                                                <asp:ListItem>Fuinea</asp:ListItem>
                                                                <asp:ListItem>Fuinea-Bissau</asp:ListItem>
                                                                <asp:ListItem>Fuyana</asp:ListItem>
                                                                  <asp:ListItem>Germany</asp:ListItem>
                                                                <asp:ListItem>Haiti</asp:ListItem>
                                                                <asp:ListItem>Holy See</asp:ListItem>
                                                                <asp:ListItem>Honduras</asp:ListItem>
                                                                <asp:ListItem>Hong Kong</asp:ListItem>
                                                                <asp:ListItem>Hungary</asp:ListItem>
                                                                <asp:ListItem>Iceland</asp:ListItem>
                                                                <asp:ListItem>India</asp:ListItem>
                                                                <asp:ListItem>Indonesia</asp:ListItem>
                                                                <asp:ListItem>Iran</asp:ListItem>
                                                                <asp:ListItem>Iraq</asp:ListItem>
                                                                <asp:ListItem>Ireland</asp:ListItem>
                                                                <asp:ListItem>Israel</asp:ListItem>
                                                                <asp:ListItem>Italy</asp:ListItem>
                                                                <asp:ListItem>Jamaica</asp:ListItem>
                                                                <asp:ListItem>Japan</asp:ListItem>
                                                                <asp:ListItem>Jordan</asp:ListItem>
                                                                <asp:ListItem>Kazakhstan</asp:ListItem>
                                                                <asp:ListItem>Kenya</asp:ListItem>
                                                                <asp:ListItem>Kiribati</asp:ListItem>
                                                                <asp:ListItem>Korea</asp:ListItem>
                                                                <asp:ListItem>Kosovo</asp:ListItem>
                                                                <asp:ListItem>Kuwait</asp:ListItem>
                                                                <asp:ListItem>Kyrgyzstan</asp:ListItem>
                                                                <asp:ListItem>Laos</asp:ListItem>
                                                                <asp:ListItem>Latvia</asp:ListItem>
                                                                <asp:ListItem>Lebanon</asp:ListItem>
                                                                <asp:ListItem>Lesotho</asp:ListItem>
                                                                <asp:ListItem>Liberia</asp:ListItem>
                                                                <asp:ListItem>Libya</asp:ListItem>
                                                                <asp:ListItem>Liechtenstein</asp:ListItem>
                                                                <asp:ListItem>Lithuania</asp:ListItem>
                                                                <asp:ListItem>Luxembourg</asp:ListItem>
                                                                <asp:ListItem>Macau</asp:ListItem>
                                                                <asp:ListItem>Macedonia</asp:ListItem>
                                                                <asp:ListItem>Madagascar</asp:ListItem>
                                                                <asp:ListItem>Malawi</asp:ListItem>
                                                                <asp:ListItem>Malaysia</asp:ListItem>
                                                                <asp:ListItem>Maldives</asp:ListItem>
                                                                <asp:ListItem>Mali</asp:ListItem>
                                                                <asp:ListItem>Malta</asp:ListItem>
                                                                <asp:ListItem>Marshall Islands</asp:ListItem>
                                                                <asp:ListItem>Mauritania</asp:ListItem>
                                                                <asp:ListItem>Mauritius</asp:ListItem>
                                                                <asp:ListItem>Mexico</asp:ListItem>
                                                                <asp:ListItem>Micronesia</asp:ListItem>
                                                                <asp:ListItem>Moldova</asp:ListItem>
                                                                <asp:ListItem>Monaco</asp:ListItem>
                                                                <asp:ListItem>Mongolia</asp:ListItem>
                                                                <asp:ListItem>Montenegro</asp:ListItem>
                                                                <asp:ListItem>Morocco</asp:ListItem>
                                                                <asp:ListItem>Mozambique</asp:ListItem>
                                                                <asp:ListItem>Namibia</asp:ListItem>
                                                                <asp:ListItem>Nauru</asp:ListItem>
                                                                <asp:ListItem>Nepal</asp:ListItem>
                                                                <asp:ListItem>Netherlands</asp:ListItem>
                                                                <asp:ListItem>New Zealand</asp:ListItem>
                                                                <asp:ListItem>Nicaragua</asp:ListItem>
                                                                <asp:ListItem>Niger</asp:ListItem>
                                                                <asp:ListItem>Nigeria</asp:ListItem>
                                                                <asp:ListItem>North Korea</asp:ListItem>
                                                                <asp:ListItem>Norway</asp:ListItem>
                                                                <asp:ListItem>Oman</asp:ListItem>
                                                                <asp:ListItem>Pakistan</asp:ListItem>
                                                                <asp:ListItem>Palau</asp:ListItem>
                                                                <asp:ListItem>Palestinian Territories</asp:ListItem>
                                                                <asp:ListItem>Panama</asp:ListItem>
                                                                <asp:ListItem>Papua New Guinea</asp:ListItem>
                                                                <asp:ListItem>Paraguay</asp:ListItem>
                                                                <asp:ListItem>Peru</asp:ListItem>
                                                                <asp:ListItem>Philippines</asp:ListItem>
                                                                <asp:ListItem>Poland</asp:ListItem>
                                                                <asp:ListItem>Portugal</asp:ListItem>
                                                                <asp:ListItem>Qatar</asp:ListItem>
                                                                <asp:ListItem>Romania</asp:ListItem>
                                                                <asp:ListItem>Russia</asp:ListItem>
                                                                <asp:ListItem>Rwanda</asp:ListItem>
                                                                <asp:ListItem>Saint Kitts and Nevis</asp:ListItem>
                                                                <asp:ListItem>Saint Lucia</asp:ListItem>
                                                                <asp:ListItem>Saint Vincent and the Grenadines</asp:ListItem>
                                                                <asp:ListItem>Samoa</asp:ListItem>
                                                                <asp:ListItem>San Marino</asp:ListItem>
                                                                <asp:ListItem>Sao Tome and Principe</asp:ListItem>
                                                                <asp:ListItem>Saudi Arabia</asp:ListItem>
                                                                <asp:ListItem>Senegal</asp:ListItem>
                                                                <asp:ListItem>Serbia</asp:ListItem>
                                                                <asp:ListItem>Seychelles</asp:ListItem>
                                                                <asp:ListItem>Sierra Leone</asp:ListItem>
                                                                <asp:ListItem>Singapore</asp:ListItem>
                                                                <asp:ListItem>Slovakia</asp:ListItem>
                                                                <asp:ListItem>Slovenia</asp:ListItem>
                                                                <asp:ListItem>Solomon Islands</asp:ListItem>
                                                                <asp:ListItem>Somalia</asp:ListItem>
                                                                <asp:ListItem>South Africa</asp:ListItem>
                                                                <asp:ListItem>South Korea</asp:ListItem>
                                                                <asp:ListItem>Spain</asp:ListItem>
                                                                <asp:ListItem>Sri Lanka</asp:ListItem>
                                                                <asp:ListItem>Sudan</asp:ListItem>
                                                                <asp:ListItem>Suriname</asp:ListItem>
                                                                <asp:ListItem>Swaziland</asp:ListItem>
                                                                <asp:ListItem>Sweden</asp:ListItem>
                                                                <asp:ListItem>Switzerland</asp:ListItem>
                                                                <asp:ListItem>Syria</asp:ListItem>
                                                                <asp:ListItem>Taiwan</asp:ListItem>
                                                                <asp:ListItem>Tajikistan</asp:ListItem>
                                                                <asp:ListItem>Tanzania</asp:ListItem>
                                                                <asp:ListItem>Thailand</asp:ListItem>
                                                                <asp:ListItem>Timor-Leste</asp:ListItem>
                                                                <asp:ListItem>Togo</asp:ListItem>
                                                                <asp:ListItem>Tonga</asp:ListItem>
                                                                <asp:ListItem>Trinidad and Tobago</asp:ListItem>
                                                                <asp:ListItem>Tunisia</asp:ListItem>
                                                                <asp:ListItem>Turkey</asp:ListItem>
                                                                <asp:ListItem>Turkmenistan</asp:ListItem>
                                                                <asp:ListItem>Tuvalu</asp:ListItem>
                                                                <asp:ListItem>Uganda</asp:ListItem>
                                                                <asp:ListItem>Ukraine</asp:ListItem>
                                                                <asp:ListItem>United Arab Emirates</asp:ListItem>
                                                                <asp:ListItem>United Kingdom</asp:ListItem>
                                                                <asp:ListItem>United States</asp:ListItem>
                                                                <asp:ListItem>Uruguay</asp:ListItem>
                                                                <asp:ListItem>Uzbekistan</asp:ListItem>
                                                                <asp:ListItem>Vanuatu</asp:ListItem>
                                                                <asp:ListItem>Venezuela</asp:ListItem>
                                                                <asp:ListItem>Vietnam</asp:ListItem>
                                                                <asp:ListItem>Yemen</asp:ListItem>
                                                                <asp:ListItem>Zambia</asp:ListItem>
                                                                <asp:ListItem>Zimbabwe</asp:ListItem>
                                                            </asp:DropDownList></div>
                </div>
    </div>

    <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Account Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Email Address (will be the user id) :<asp:Label ID="Label1" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="input-block-level" required="required" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" CssClass="form-control arial" Display="Dynamic" ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                             </div>
                 </div>            
                 <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Password :<asp:Label ID="Label2" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" >
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="input-block-level" TextMode="Password" required="required" ></asp:TextBox>
                             </div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Confirm Password :<asp:Label ID="Label3" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input-block-level" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password entries does not match"
                                                                ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator></div>
                </div>

                 </div>

    <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Contact Details</div>
                </div>
                <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">First Name<asp:Label ID="Label4" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="input-block-level" required="required" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" CssClass="arial" Display="Dynamic"
                                                                ErrorMessage="First name cannot be left blank"></asp:RequiredFieldValidator>   
                             </div>
                 </div>
                 <div class="row">            
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Middle Name</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="input-block-level"></asp:TextBox>
                             </div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Last Name<asp:Label ID="Label5" Text="*" ForeColor="Red" runat="server" ></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtLastName" runat="server" CssClass="input-block-level" required="required"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" Display="Dynamic"
                                                                ErrorMessage="Last name cannot be left blank."></asp:RequiredFieldValidator>
                            </div>
                 </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Date of Birth :<asp:Label ID="Label6" Text="*" ForeColor="Red" runat="server" ></asp:Label>
                                                             <asp:Label ID="Label12" Text="(MM/dd/yyyy)"  runat="server" CssClass="arial"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtDOB" runat="server" CssClass="input-block-level" required="required"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdob" Display="Dynamic"
                                                                ErrorMessage="Date of birth cannot be left blank." CssClass="arial"></asp:RequiredFieldValidator></div>
                </div>
                 <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Permanent Address :<asp:Label ID="Label7" Text="*" ForeColor="Red" runat="server" ></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="input-block-level"
                                                                TextMode="MultiLine" required="required" Rows="4"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPermanentAddress" CssClass="arial" Display="Dynamic"
                                                                ErrorMessage="Permanent Address cannot be left blank."></asp:RequiredFieldValidator></div>
                </div>
                 <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Correspondence Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="input-block-level"
                                                                TextMode="MultiLine" Rows="4"></asp:TextBox></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Contact Number :<asp:Label ID="Label8" Text="*" ForeColor="Red" runat="server" ></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="input-block-level"></asp:TextBox>
                                                                <asp:Label ID="lblMessage4" EnableViewState="false" runat="server" Text="" ForeColor="Red" CssClass="arial"></asp:Label></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Mobile Number :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="input-block-level"></asp:TextBox>
                                                            <asp:Label ID="lblMessage5" EnableViewState="false" runat="server" Text="" ForeColor="Red" CssClass="arial"></asp:Label></div>
                </div>
     </div>

    <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Personal Details</div>
                </div>
                <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Gender :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="dllGender" runat="server" CssClass="input-block-level">
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList></div>
                </div>
                <div class="row">
                              <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Applicant Category :<asp:Label ID="Label13" Text="*" ForeColor="Red" runat="server" ></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlapplicantCategory" runat="server" CssClass="input-block-level">
                                                                   <asp:ListItem>- Select -</asp:ListItem>
                                                                              <asp:ListItem>Institutional Sponsored</asp:ListItem>
                                                                              <asp:ListItem>Individual Candidate</asp:ListItem>
                                                                              <asp:ListItem>Student</asp:ListItem>
                                                                              <asp:ListItem>Applicant from developed countries</asp:ListItem>
                                                                              <asp:ListItem>Applicant from SAARC and other developing countries</asp:ListItem>
                                                              
                                                            </asp:DropDownList></div>
                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Current Profession :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="dllProfession" runat="server" CssClass="input-block-level">
                                                                <asp:ListItem>Student</asp:ListItem>
                                                                <asp:ListItem>Working</asp:ListItem>
                                                                <asp:ListItem>Others</asp:ListItem>
                                                            </asp:DropDownList></div>
                </div>
             
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Category : <asp:Label ID="Label10" Text="(Only for Indian Applicants)"  runat="server" ></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="dllCategory" runat="server" CssClass="input-block-level">
                                                                   <asp:ListItem>- Select -</asp:ListItem>
                                                                <asp:ListItem>General</asp:ListItem>
                                                                <asp:ListItem>SC/ST</asp:ListItem>
                                                                <asp:ListItem>OBC</asp:ListItem>
                                                                
                                                            </asp:DropDownList>
                             </div>
                </div>


     </div>

    <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Educational Details <asp:Label ID="lblMessage2" EnableViewState="false" runat="server" Text="" ForeColor="Red" CssClass="arial"></asp:Label></div>
                </div>
    <div class="row" style="margin-top: 20px;">
    <%--<div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">&nbsp;</div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text">10<sup>th</sup> <asp:Label ID="Label11" Text="*" ForeColor="Red" runat="server" CssClass="arial"></asp:Label></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text">12<sup>th</sup></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text">Graduation</div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text">Any Other</div>
    </div>
    <br />
    <br />
    <br />
    
    </div>--%>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of the Univ./Board</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level"></asp:TextBox></div>
    </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Stream</b></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" ></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" ></asp:TextBox></div>
    </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Marks Obtained (%)</b></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level" MaxLength="5"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" MaxLength="5"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" MaxLength="5"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" MaxLength="5" ></asp:TextBox></div>
    </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Year of Completion</b></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level" MaxLength="40"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" MaxLength="40"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" MaxLength="40"></asp:TextBox></div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" MaxLength="40"></asp:TextBox></div>
    </div>
    </div>
    </div>
   

    </div>

    <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Work Experience (Atleast One Mandatory if Current Profession is chosen as 
                                                working) <asp:Label ID="lblMessage3" EnableViewState="false" runat="server" Text="" ForeColor="Red" CssClass="arial"></asp:Label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ErrorMessage="Total Experience should be numeric" CssClass="arial" ControlToValidate="txtTotExp" ValidationExpression="^\d*\.?\d*$" ValidationGroup="d"></asp:RegularExpressionValidator></div>
    </div>
    <div class="row" style="margin-top: 20px; border-bottom:solid 1px #c0c0c0; margin-bottom:10px">
            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form_text field-label">
                Total Years of Experience
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                <asp:TextBox ID="txtTotExp" runat="server" placeholder="Total Years of Experience" CssClass="input-block-level" MaxLength="4" ></asp:TextBox>
            </div>
    </div>
    <div class="row">
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of Organisation</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg1" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg2" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg3" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Phone Number</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh1" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level"  MaxLength="50" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh2" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" MaxLength="50" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh3" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" MaxLength="50" Width="100%"></asp:TextBox></div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Designation</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation1" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation2" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation3" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
    </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Years of Service</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear1" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear2" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear3" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" MaxLength="100" Width="100%"></asp:TextBox></div>
    </div>
    </div>
    </div>
   
    </div>

    <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Declaration</div>
    </div>
     <div class="row" style="margin-top:20px">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    
                    <h6>    I hereby declare that the information furnished in the application form is complete and accurate. I also agree that the FMSF has the right to cancel my candidature, in case it is found that any information provided therein is incorrect, incomplete or misleading, or ineligibility being detected before or after the selection/admission.</h6>
                    
                </div>
      </div>
     <div class="row">&nbsp;</div>
     <div class="row">
                             <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 form_text field-label"><span class="pull-right">Supporting Document :</span></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" align="left"><asp:FileUpload ID="Fupd" runat="server" CssClass="btn btn-primary"  /></div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                             <asp:TextBox ID="txtPlace" runat="server" placeholder="Place" CssClass="input-block-level" MaxLength="40" Width="100%"></asp:TextBox>
                             </div>
      </div>
      <div class="row">&nbsp;</div>
      <div class="row center">
      <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success" />
      <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-large btn-warning" />
      <asp:Button ID="btnPrint" runat="server" OnClientClick="return openPopup('student/PrintRegistration.aspx');" Enabled="false"  Text="Print" CssClass="btn btn-large btn-primary" /> 
      <asp:Button ID="btnPrint1" runat="server" Text="Print" Visible="false" CssClass="btn btn-primary btn-large" />
      </div>
      </div>

      </div>
      </div>
      <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text" style="margin-top:20px">
     <blockquote>
      <p>Note</p>
      <small> Above mentioned Email ID is also used for any correspondence.You can change this from Edit Profile option in student login.</small>                                 
      <small> Please remember your password as well as your login ID as you will need to log in using these details for your screening Exam.</small>
      <small><span style="color:Red"> If you have any problem in registering online then please click <a href="DownloadRegistration.aspx?id=dr">here</a> to download the registration form and mail it on coordinator@fmsflearningsystems.org.</small>
               
                                        
                                        <%--        
                                                  <div style="width:210px; overflow-x:auto">
                                                      <asp:ListBox ID="lst" runat="server" CssClass="NormalText"  
                                                          SelectionMode="Multiple"  Height="100px" width="310px"></asp:ListBox>
                                                   </div>
                                                    --%>
                    </blockquote>                   
      </div>
      </div>
      </section> 
                                  
    </form>
<script type="text/javascript">
    document.getElementById('registrationpage').setAttribute("class", "active");
</script>        
</asp:Content>
