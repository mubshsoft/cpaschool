<%@ Page Title="" Language="VB" MasterPageFile="~/HomeMaster.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>
blockquote small:before
{
    content:''
}
</style>

<!--Slider-->
    <section id="slide-show">
     <div id="slider" class="sl-slider-wrapper">
     <!--Slider Items-->    
       <div class="sl-slider">

            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                    <div class="sl-slide item2" data-orientation="<%# Eval("dataorientation")%>" data-slice1-rotation="<%# Eval("dataslice1rotation")%>" data-slice2-rotation="<%# Eval("dataslice2rotation")%>" data-slice1-scale="<%# Eval("dataslice1scale")%>" data-slice2-scale="<%# Eval("dataslice2scale")%>">
                <div class="sl-slide-inner">
                    <div class="container">
                         <img class="pull-right" style="padding-top: 85px;position: absolute;right: 30px;" src="Images/slider/<%# Eval("images")%>" alt="" />
                         
                        
                        <div class="media-body" style="overflow:visible">
                           <h2 class="hidden-phone"><%# Eval("BannerHeading")%></h2>
                        <h3 class="hidden-desktop" style="font-size:30px"><%# Eval("CourseName")%></h3>
                        <h3 class="gap hidden-phone"><%# Eval("BannerDesc")%></h3>
                       
                       <a class="btn btn-large btn-transparent" href="CourseDetailsInfo.aspx?cid=<%# Eval("Courseid")%>">Learn More</a><br />
                           </div>
                        </div>
                </div>
            </div>       
        </ItemTemplate>
        </asp:Repeater>
           <!--Slider Item1-->
           <%--<div class="sl-slide item1" data-orientation="horizontal" data-slice1-rotation="-25" data-slice2-rotation="-25" data-slice1-scale="2" data-slice2-scale="2">
               <div class="sl-slide-inner">
                   <div class="container">
                       <img class="pull-right" style="padding-top: 85px;position: absolute;right: 30px;" src="Images/slider/img1.png" alt="" />
                       <h2 class="hidden-phone">FMSF Learning Systems</h2>
                       <h3 class="hidden-desktop" style="font-size:30px">FMSF Learning Systems</h3>
                       <h3 class="gap hidden-phone">An online learning interface for professionals working in the voluntary sector</h3>
                       <a class="btn btn-large btn-transparent hidden-phone" href="aboutus.aspx">Learn More</a>
                       <a class="hidden-desktop" href="aboutus.aspx"><img src="images/learn-more-button.png" style="width: 200px;margin-left: -40px;"></a>
                   </div>
               </div>
           </div>--%>
           <!--/Slider Item1-->

           <!--Slider Item2-->
           <%--<div class="sl-slide item2" data-orientation="vertical" data-slice1-rotation="10" data-slice2-rotation="-15" data-slice1-scale="1.5" data-slice2-scale="1.5">
               <div class="sl-slide-inner">
                   <div class="container">
                       <img class="pull-right" style="padding-top:85px" src="Images/slider/img2.png" alt="" />
                       <h2>DFMA</h2>
                       <h3 class="gap">(Diploma in Financial Management and Accountability)</h3>
                       <a class="btn btn-large btn-transparent" href="CourseDetailsInfo.aspx?cid=2">Learn More</a>
                   </div>
               </div>
           </div>--%>
           <!--Slider Item2-->

           <!--Slider Item3-->
           <%--<div class="sl-slide item3" data-orientation="horizontal" data-slice1-rotation="3" data-slice2-rotation="3" data-slice1-scale="2" data-slice2-scale="1">
               <div class="sl-slide-inner">
                  <div class="container">
                   <img class="pull-right" style="padding-top:120px" src="Images/slider/img3.png" alt="" />
                   <h2>NPO</h2>
                   <h3 class="gap">(NPO Governance Program)</h3>
                   <a class="btn btn-large btn-transparent" href="CourseDetailsInfo.aspx?cid=3">Learn More</a>
               </div>
           </div>
       </div>--%>
       <!--Slider Item3-->

       <!--Slider Item4-->

    <!--Slider Next Prev button-->
    <nav id="nav-arrows" class="nav-arrows">
        <span class="nav-arrow-prev"><i class="icon-angle-left"></i></span>
        <span class="nav-arrow-next"><i class="icon-angle-right"></i></span> 
    </nav>
    <!--/Slider Next Prev button-->

</div>
<!-- /slider-wrapper -->           
</section>
<!--/Slider-->
                
 <section class="main-info">
    <div class="container">
        <div class="row-fluid">
            <div class="span8">
                <h3>Welcome to Fmsf Learning Systems !</h3>
                <p class="no-margin"><strong>FMSF Learning Systems</strong> is an interactive online learning platform for individuals working in the not-for-profit sector as well as those interested to join the sector. This online platform aims to break the barriers of distance & provide training to all those who do not have access to structured training programs in the areas of financial management; legal compliances; governance; and planning, monitoring & evaluation.</p>
            </div>
            <div class="span4">
           <div class="clearfix">
                    <h3 class="pull-left">News & Events</h3>
                    <div class="pull-right">
                        <a class="prev" href="#myCarousel" data-slide="prev">
                        <i class="icon-angle-left icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell; font-size:12px"></i>
                        </a> 
                        <a class="next" href="#myCarousel" data-slide="next">
                        <i class="icon-angle-right icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell; font-size:12px"></i>
                        </a>
                    </div>
                </div>
                <div class="user-info media box" style="background:#ececec">
                <div id="myCarousel" class="carousel slide clients" style="margin:0;">
                  <!-- Carousel items -->
                  <div class="carousel-inner">
                <asp:Repeater ID="dlnews" runat="server" >
                   <ItemTemplate>
                   <div class="item">
                        <div class="row-fluid">
                        <ul style="margin-left:0">
                        <li>
                            <div class="pull-left">
                                <img src="Images/newsandevents.png" alt="news events" style="border: solid 1px #ababab;" />
                            </div>
                            <div class="media-body" style="padding-left: 10px; text-align: justify; font-size:14px;">
                                <span style="font-family: sans-serif;color: #3498db;"><strong><i class="icon-calendar"></i> <%#Format(CDate(DataBinder.Eval(Container.DataItem, "ndate")), "dd-MMM-yyyy")%> </strong></span>
                                <p style="border-top: solid 1px #cecdcd;padding-top: 6px;"><%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%></p>
                            
                            </div>
                         </li>
                        </ul>
                        </div>
                    </div>
                        </ItemTemplate>
                        </asp:Repeater>
                 </div>
                 </div>
                 </div>
<div class="row-fluid">
<div class="span12" style="padding:10px 0 0 0"><a class="btn btn-blue pull-right" href="DetailsNewsEvents.aspx">View More</a></div>

</div>
            </div>
        </div>
    </div>
</section>

<!--Services-->
<section id="services">
    <div class="center">
        <img src="images/courses.png" class="centerImg" style="background: #3b5a6c;"/>
    </div>
    <div class="container">
        <div class="center">
            <h3 style="padding-top:0;margin-top:0">COURSES OFFERED</h3>
        </div>

        <div id="courses" class="row-fluid">
                                <asp:Repeater ID="DlsDetails" runat="server">
                                    <ItemTemplate>
                                       <div class="span4">
                                            <div class="media" style="height:400px; padding-top: 60px;">
                                                <div class="pull-left">
                                                    <i class="icon-globe icon-medium"></i>
                                                </div>
                                                <div class="media-body" style="padding-bottom: 40px;">
                                                    <h4 class="course-heading" style="border-bottom: solid 1px #ffffff;"><%# Eval("CourseName")%></h4>
                                                    <%--<p style="padding-bottom:30px"><%# Eval("TextDetails").ToString().Substring(0, 230)%> ...</p>--%>
                                                    <p style="padding-bottom:30px; height: 170px; overflow:auto"><%# Eval("TextDetails").ToString()%> ...</p>
                                                    <div class="well">
                                                    <div class="span4">
                                                    <i class="icon-download-alt"></i> <a href="DownloadPDF.aspx?HelpDesk=2&amp;cid=<%#Container.DataItem("CourseId")%>">Brochure</a>
                                                    </div>
                                                    <div class="span4">
                                                    <i class="icon-download-alt"></i> <a href="DownloadPDF.aspx?HelpDesk=1&amp;cid=<%#Container.DataItem("CourseId")%>">FAQ's</a>
                                                    </div>
                                                    <div class="span4">
                                                    <i class="icon-download-alt"></i> <a href="DownloadPDF.aspx?HelpDesk=3&amp;cid=<%#Container.DataItem("CourseId")%>">Calendar</a>
                                                    </div>
                                                    </div>
                                                    <a class="btn btn-large btn-transparent" href="CourseDetailsInfo.aspx?cid=<%#Container.DataItem("CourseId")%>">Learn More</a>
                                                    
                                                    <asp:PlaceHolder runat="server" Visible='<%# Container.DataItem("courseid") = "2" %>'>
                                                        <a class="btn btn-large btn-transparent" href="ScreeningLogin.aspx">Screening Test</a>
                                                    </asp:PlaceHolder>
                                                </div>
                                            </div>
                                        </div>         
                                          
                                        
                                                       
                                                    
                                              
                                               
                                            <%--<tr>
                                                <td style="width: 32px; height: 37px;">
                                                    <img src="Images/bottom_left_white_corner.png" alt="" />
                                                </td>
                                                <td style="background-image: url(Images/bottom_mid_white_corner.png)" align="right">
                                                    <a href="registration.aspx">
                                                        <img src="Images/register.png" alt="Learning systems" border="0" /></a>&nbsp;
                                                    <a href="CourseDetailsInfo.aspx?CID=<%#Container.DataItem("CourseId")%>#COURSE_FEE">
                                                        <img src="Images/course_fees.png" alt="Learning systems" border="0" /></a>&nbsp
                                                    <a href="login.aspx">
                                                        <img src="Images/login_blue.png" alt="Learning systems" border="0" />
                                                </td>
                                                <td style="width: 32px; height: 37px;">
                                                    <img src="Images/bottom_right_white_corner.png" alt="" />
                                                </td>
                                            </tr>--%>
                                       
                                    </ItemTemplate>
                                     <%--<FooterTemplate>  
                                     <span id="totCorses" style="display:none">
                                     <%# DlsDetails.Items.Count%>
                                     </span>
                                     </FooterTemplate>--%>
                                </asp:Repeater>
                </div>
        </div>
</section>



<section id="testimonial">
<div class="center">
        <img src="images/users.png" class="centerImg" style="border:solid 8px #f5f5f5; margin-top:-87px; background: #f5f5f5;"/>
    </div>
<div class="container">
        <div class="row-fluid">
            <div class="span12">
            <div class="clearfix" style="padding-top:20px;">
                    <h3 class="pull-left">Testimonials of our Alumni</h3>
                    <div class="pull-right" style="padding-top:15px">
                        <a class="prev" href="#myCarousel2" data-slide="prev">
                        <i class="icon-angle-left icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell;"></i>
                        </a> 
                        <a class="next" href="#myCarousel2" data-slide="next">
                        <i class="icon-angle-right icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell;"></i>
                        </a>
                    </div>
                </div>
            </div>
            <div class="span12" style="margin-left:0">
            <!-- Start Testimonials Carousel -->
            <div id="myCarousel2" class="carousel slide clients">
            <div class="carousel-inner">
            <%For i As Integer = 0 To dsAllumni.Tables(0).Rows.Count - 1%>
            <%If i = 0 Then%>
                <div class="active item">
            <%Else%>
                <div class="item">
            <%End If%>
            <div class="row-fluid">
            <ul style="margin: 0 20px 10px 0; padding: 0 0px 0 0;">
            <li class="span4">
            <!-- Testimonial 1 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <div class="span5"><img src='<%= dsAllumni.Tables(0).Rows(i)(6).ToString()%>' class="image" alt="testimonials" />
              </div>
              <div class="span7">
                <div class="testimonial-author"><span><%= dsAllumni.Tables(0).Rows(i)(2).ToString() + " " + dsAllumni.Tables(0).Rows(i)(3).ToString()%></span><br /><span class="text-info"><i class="icon icon-group" style="background: #3498db;padding: 4px;color: #fff;border-radius: 100%;"></i> <%= dsAllumni.Tables(0).Rows(i)(4).ToString()%></span></div><hr style="margin:2px 0 10px 0" />
                <div class="testimonial-content">
                  <p><%= dsAllumni.Tables(0).Rows(i)(5).ToString().Substring(0, 90) + " ..."%><% i = i + 1%></p>
                </div>
                
                </div>
                </div>
              </div>
              </li>

               <li class="span4">
            <!-- Testimonial 1 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <div class="span5"><img src='<%= dsAllumni.Tables(0).Rows(i)(6).ToString()%>' class="image" alt="testimonials" />
              </div>
              <div class="span7">
              <div class="testimonial-author"><span><%= dsAllumni.Tables(0).Rows(i)(2).ToString() + " " + dsAllumni.Tables(0).Rows(i)(3).ToString()%></span><br /><span class="text-info"><i class="icon icon-group" style="background: #3498db;padding: 4px;color: #fff;border-radius: 100%;"></i> <%= dsAllumni.Tables(0).Rows(i)(4).ToString()%></span></div><hr style="margin:2px 0 10px 0" />
                <div class="testimonial-content">
                  <p><%= dsAllumni.Tables(0).Rows(i)(5).ToString().Substring(0, 90) + " ..."%><% i = i + 1%></p>
                </div>
                
                </div>
                </div>
              </div>
              </li>

               <li class="span4">
            <!-- Testimonial 1 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <div class="span5"><img src='<%= dsAllumni.Tables(0).Rows(i)(6).ToString()%>' class="image" alt="testimonials" />
              </div>
              <div class="span7">
                <div class="testimonial-author"><span><%= dsAllumni.Tables(0).Rows(i)(2).ToString() + " " + dsAllumni.Tables(0).Rows(i)(3).ToString()%></span><br /><span class="text-info"><i class="icon icon-group" style="background: #3498db;padding: 4px;color: #fff;border-radius: 100%;"></i> <%= dsAllumni.Tables(0).Rows(i)(4).ToString()%></span></div><hr style="margin:2px 0 10px 0" />
                <div class="testimonial-content">
                  <p><%= dsAllumni.Tables(0).Rows(i)(5).ToString().Substring(0, 90) + " ..."%><% i = i + 1%></p>
                </div>
                
                </div>
                </div>
              </div>
              </li>
              
            </ul>
              </div>
              </div>
            <%--  <div class="item">
                        <div class="row-fluid">
                        <ul>
            <li class="span4">
            <!-- Testimonial 1 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <div class="span5"><img src="Images/testi4.png" class="image" />
              <div class="testimonial-author"><span>Sunil Mahajan</span><br />Batch 3</div></div>
              <div class="span7">
                <div class="testimonial-content">
                
                  <p>DFMA not only helped me in updating my knowledge about the new currents in this sector but also enabled and empowered me to familiarize myself to the institutional..</p>
                </div>
                
                </div>
                </div>
              </div>
              </li>
              <li class="span4">
              <!-- Testimonial 2 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <div class="span5"><img src="Images/testi5.png" class="image" />
              <div class="testimonial-author"><span>V P Manoj</span><br />Batch 3</div></div>
              <div class="span7">
                <div class="testimonial-content">
                
                  <p>The course helped me improve and gain confidence in my work. Most of the complicated tasks became easier for me, as I started understanding the complexity of the work easily..</p>
                </div>
                
                </div>
                </div>
              </div>
              </li>
              <li class="span4">
              <!-- Testimonial 3 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <div class="span5"><img src="Images/testi6.png" class="image" />
              <div class="testimonial-author"><span>Indrajit Das</span><br />Batch 6</div></div>
              <div class="span7">
                <div class="testimonial-content">
                
                  <p>Before I enrolled for the DFMA Course I already had been working for an NGO in the accounts and finance department, but after reviewing the books and..</p>
                </div>
                
                </div>
                </div>
              </div>
            </li>
            </ul>
            </div>
            </div>

              <div class="item">
                        <div class="row-fluid">
                        <ul>
            <li class="span4">
            <!-- Testimonial 1 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <div class="span5"><img src="Images/testi7.png" class="image" />
              <div class="testimonial-author"><span>Hemalatha Krishnamurti</span><br />Batch 7</div></div>
              <div class="span7">
                <div class="testimonial-content">
                
                  <p>This course has not only fulfilled my expectations, it has given me a better understanding of the working of accounts and administrative procedure that was..</p>
                </div>
                
                </div>
                </div>
              </div>
              </li>
              <li class="span4">
              &nbsp;
              </li>
              <li class="span4">
              &nbsp;
            </li>
            </ul>
            </div>
            </div>--%>
            <%Next%>
            </div>

            </div>
            <!-- End Testimonials Carousel -->
            </div>
            <div class="row-fluid">
<div class="span12" style="padding-bottom:20px"><a class="btn btn-blue pull-right" href="AlumniSpeaks.aspx">View More</a></div>

</div>
         </div>
</div>



</section>

<section id="testimonialstudent">
    <div class="container">
        <div class="row-fluid">
            <div class="span12">
            <div class="clearfix" style="padding-top:20px;">
                    <h3 class="pull-left">Testimonials of our Student</h3>
                    <div class="pull-right" style="padding-top:15px">
                        <a class="prev" href="#myCarousel2" data-slide="prev">
                        <i class="icon-angle-left icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell;"></i>
                        </a> 
                        <a class="next" href="#myCarousel2" data-slide="next">
                        <i class="icon-angle-right icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell;"></i>
                        </a>
                    </div>
                </div>
            </div>
            <div class="span12" style="margin-left:0">
            <!-- Start Testimonials Carousel -->
            <div id="myCarousel2" class="carousel slide clients">
            <div class="carousel-inner">
            <%For i As Integer = 0 To dsTestimonials.Tables(0).Rows.Count - 1%>
            <%If i = 0 Then%>
                <div class="active item">
            <%Else%>
                <div class="item">
            <%End If%>
            <div class="row-fluid">
            <ul style="margin: 0 20px 10px 0; padding: 0 0px 0 0;">
            <li class="span4">
            <!-- Testimonial 1 -->
              <div class="classic-testimonials item">
              <div class="row-fluid testi-class">
              <%--<div class="span5"><img src='<%= dsTestimonials.Tables(0).Rows(i)(6).ToString()%>' class="image" alt="testimonials" />
              </div>--%>
              <div class="span7">
                <div class="testimonial-author"><span><%= dsTestimonials.Tables(0).Rows(i)("Name").ToString() %></span><br /><span class="text-info"><i class="icon icon-group" style="background: #3498db;padding: 4px;color: #fff;border-radius: 100%;"></i> <%= dsTestimonials.Tables(0).Rows(i)("batchcode").ToString()%></span></div><hr style="margin:2px 0 10px 0" />
                <div class="testimonial-content">
                  <p><%= dsTestimonials.Tables(0).Rows(i)("description").ToString().Substring(0, 10) + " ..."%><% i = i + 1%></p>
                </div>
                
                </div>
                </div>
              </div>
              </li>

            
            </ul>
              </div>
              </div>
           
            <%Next%>
            </div>

            </div>
            <!-- End Testimonials Carousel -->
            </div>
            <div class="row-fluid">
<div class="span12" style="padding-bottom:20px"><a class="btn btn-blue pull-right" href="TestimonialStudents.aspx" id="sttestimonial" runat="server" visible="false" >View More</a></div>

</div>
         </div>
</div>
    </div>
</section>
<section id="recent-works">
<div class="center">
        <img src="images/contact-icon.png" class="centerImg" style="border:solid 8px #edebec; margin-top:-74px; background: #edebec;"/>
    </div>

    <div class="container">
        <div class="row-fluid">
            <div class="span4">
            <h3>Enquiry Form</h3>
            <div class="status alert alert-success" style="display: none"></div>

                <form id="main-contact-form" class="contact-form" name="contact-form" method="post" action="sendemail.php">
                  <div class="row-fluid">
                    <div class="span12">
                        <input type="text" class="input-block-level" required="required" placeholder="Name">
                        <input type="text" class="input-block-level" required="required" placeholder="Email ID">
                        <textarea name="message" id="message" required="required" class="input-block-level" rows="4"></textarea>
                    </div>
                   
                </div>
                <button type="submit" class="btn btn-blue pull-right" style="font-family:Calibri">Send</button>
                <p> </p>

            </form>
        </div>
        
        <div class="span8">
        <div class="row-fluid">
                <div class="span12">
            <div class="clearfix">
                    <h3 class="pull-left">Course Faculty</h3>
                    <div class="pull-right" style="padding-top:15px">
                        <a class="prev" href="#myCarousel3" data-slide="prev">
                        <i class="icon-angle-left icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell;"></i>
                        </a> 
                        <a class="next" href="#myCarousel3" data-slide="next">
                        <i class="icon-angle-right icon-large" style="border: solid 1px #ccc; padding: 5px; display: table-cell;"></i>
                        </a>
                    </div>
                </div>
            </div>
            <div class="span12">
             
            <!-- Start Testimonials Carousel -->
            <div id="myCarousel3" class="carousel slide clients">
                <div class="carousel-inner">
                   <asp:Repeater ID="rptrFaculties" runat="server">
                    <ItemTemplate>
                        <div class="classic-testimonials item">
                            <div class="row-fluid testi-class">
                                <div class="span3">
                                <img src='<%# IIf(Eval("Images").ToString() = "", "Images/noimage.png", Eval("Images"))%>' alt="Faculty" class="image" width="74%"  />

                                    <blockquote>
                                        <p style="text-transform:uppercase; font-size:15px"><%# Eval("firstName")%> <%# Eval("lastname")%></p>
                                        <small> <cite title="Source Title"><%# Eval("email")%></cite></small>
                                    </blockquote>
                                </div>
                                <div class="span9">
                                <div>
                                    <p class="faculty" style="margin-right:10px"><%# Eval("Profile")%></p>
                                </div>
                
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                   </asp:Repeater>
                </div>

            </div>
            <!-- End Testimonials Carousel -->
            </div>
            <div class="row-fluid">
<div class="span12" style="padding-bottom:20px"><a class="btn btn-blue pull-right" href="FacultiesDetail.aspx">View More</a></div>

</div>
            </div>
        </div>  
        
        </div>
        </div>
        </section>

<script src="js/jquery.slitslider.js"></script>
<!-- /Required javascript files for Slider -->

<!-- SL Slider -->
<script type="text/javascript">
    
        
    
    $(function () {
        document.getElementsByClassName('carousel-inner')[0].childNodes[1].setAttribute("class", "item active");
        document.getElementById('myCarousel3').childNodes[1].childNodes[1].setAttribute("class", "classic-testimonials item active");
        var Page = (function () {

            var $navArrows = $('#nav-arrows'),
        slitslider = $('#slider').slitslider({
            autoplay: true,
            speed: 1800
        }),

        init = function () {
            initEvents();
        },
        initEvents = function () {
            $navArrows.children(':last').on('click', function () {
                slitslider.next();
                return false;
            });

            $navArrows.children(':first').on('click', function () {
                slitslider.previous();
                return false;
            });
        };

            return { init: init };

        })();

        Page.init();
    });
    document.getElementById('homepage').setAttribute("class", "active");
    var num = document.getElementsByClassName("autoSpan").length;
    spans = "span" + Math.floor((12 / num));
    for (i = 0; i < num; i++) {
        document.getElementsByClassName("autoSpan")[0].setAttribute("class", spans);
    }
</script>


</asp:Content>

