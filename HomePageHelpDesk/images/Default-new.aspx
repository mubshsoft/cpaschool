<%@ Page Title="" Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="Default-new.aspx.vb" Inherits="Default_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick-theme.min.css">
<%--<link rel="stylesheet" type="text/css" href="public/assets/themes/theme-1/fullcalendar/dist/fullcalendar.min.css" />
<link rel="stylesheet" type="text/css" href="public/assets/themes/theme-1/fullcalendar/dist/fullcalendar.print.min.css" />--%>

<%--Start Added by wahid on 19 de 20 for calendar--%>
    <link href="Calendar/fullcalendar.min.css" rel="stylesheet" />
    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.css" rel="stylesheet" />--%>
<link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.print.css" rel="stylesheet" media="print" />
<link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

   <style type="text/css">

        .fc-content{
            text-align: center;
            color: wheat;
            font-weight: bold;
        }

        #calendarNew {
            width: 150px;
            max-width: 200px;
            margin: 20px auto;
            
         }
       .fc td, .fc th {
           border-width:0;
       }
   </style>
<%--END Added by wahid on 19 de 20 for calendar--%>
<style>
.homeservices {
    background: #fff;
    position: relative;
    padding: 30px 0 45px;
    clear: left;
}
.title h2 {
    font-size: 35px;
    color: #0e245d;
    letter-spacing: 1px;
    text-align:center;
}
.course-name {
font-size: 20px;
margin:20px 0;
font-weight: bold;
color: #0e245d;
}
.course-detail 
{
    color:#fff;
    font-size: 14px;
    text-align:justify;
    line-height:22px;
}
.panel-body 
{
    text-align:center;
}
.common-block-three {
    padding: 25px 30px;
    position: relative;
}
.ngo-title {
    
    margin: 0 auto;
    border-radius: 3px;
    background: #fe912c;
    color: #272c3f;
    font-size: 20px;
    font-weight: 600;
    height: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
    text-align: center;
    padding: 15px 35px;
}
.ngo-list {
    margin: -20px;
    border: solid 1px #fe912c;
    padding: 40px 0px 20px 0px;
    border-radius: 5px;
    width: 107%; }
    
.ngo .ngo-list ul li {
    width: 100%;
    padding: 5px 15px;
    position: relative;
    font-family: 'Poppins';
}

</style>

<style>

.testimonial-bg 
{
    background: #fff;
    position: relative;
    padding: 30px 0 45px;
    clear: left;
}
.image {box-shadow:none;}
.testimonial-reel {
  margin-bottom: 4rem !important;
  margin-top: 4rem;
}
  .box-white {
    position: relative;
    margin-bottom: 30px;
}
    .box-white .image {
      margin: 0 auto -30px;
      text-align: center;
      width: 200px;
    }
     .box-white .img {
        height: 130px;
        margin: 0 auto;
      }
    

    .test-component {
      background-color: #fff;
      padding: 1rem 2.5rem;
      box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
      min-height: 200px;
    }

    .test-title {
      font-family: $open-sans;
      color: $brand-orange;
      text-align: center;
      margin-top: 3.3rem;
      margin-bottom: 15px;
    }

    .test-content {
      text-align: center;
    }
  

  .slick-slide {
    opacity: 0.3;
    transition: opacity 0.3s;
    padding-left: 1rem;
    padding-right: 1rem;
  }
    .slick-cloned {
      opacity: 0.3;
      transition: opacity 0.3s;
    }

    .slick-current.slick-active {
      opacity: 1;
      transition: opacity 0.3s;
    }
  
</style>

<style>
@import url(//cdn.rawgit.com/rtaibah/dubai-font-cdn/master/dubai-font.css);


.testim {
		width: 100%;
		top: 50%;
		-webkit-transform: translatey(-50%);
		-moz-transform: translatey(-50%);
		-ms-transform: translatey(-50%);
		-o-transform: translatey(-50%);
		transform: translatey(-50%);
}

.testim .wrap {
    position: relative;
    width: 100%;
    max-width: 1020px;
    padding: 20px 20px;
    margin: auto;
}

.testim .arrow {
    display: block;
    position: absolute;
    color: #0e245d;
    cursor: pointer;
    font-size: 2em;
    top: 50%;
    -webkit-transform: translateY(-50%);
		-ms-transform: translateY(-50%);
		-moz-transform: translateY(-50%);
		-o-transform: translateY(-50%);
		transform: translateY(-50%);
    -webkit-transition: all .3s ease-in-out;    
    -ms-transition: all .3s ease-in-out;    
    -moz-transition: all .3s ease-in-out;    
    -o-transition: all .3s ease-in-out;    
    transition: all .3s ease-in-out;
    padding: 5px;
    z-index: 22222222;
}

.testim .arrow:before {
		cursor: pointer;
}

.testim .arrow:hover {
    color: #ea830e;
}
    

.testim .arrow.left {
    left: 10px;
}

.testim .arrow.right {
    right: 10px;
}

.testim .dots {
    text-align: center;
    position: absolute;
    width: 100%;
    bottom: 60px;
    left: 0;
    display: block;
    z-index: 3333;
		height: 12px;
}

.testim .dots .dot {
    list-style-type: none;
    display: inline-block;
    width: 12px;
    height: 12px;
    border-radius: 50%;
    border: 1px solid #0e245d;
    margin: 0 10px;
    cursor: pointer;
    -webkit-transition: all .5s ease-in-out;    
    -ms-transition: all .5s ease-in-out;    
    -moz-transition: all .5s ease-in-out;    
    -o-transition: all .5s ease-in-out;    
    transition: all .5s ease-in-out;
		position: relative;
}

.testim .dots .dot.active,
.testim .dots .dot:hover {
    background: #ea830e;
    border-color: #ea830e;
}

.testim .dots .dot.active {
    -webkit-animation: testim-scale .5s ease-in-out forwards;   
    -moz-animation: testim-scale .5s ease-in-out forwards;   
    -ms-animation: testim-scale .5s ease-in-out forwards;   
    -o-animation: testim-scale .5s ease-in-out forwards;   
    animation: testim-scale .5s ease-in-out forwards;   
}
    
.testim .cont {
    position: relative;
		overflow: hidden;
}

.testim .cont > div {
    text-align: center;
    position: absolute;
    top: 0;
    left: 0;
    padding: 0 0 70px 0;
    opacity: 0;
}

.testim .cont > div.inactive {
    opacity: 1;
}
    

.testim .cont > div.active {
    position: relative;
    opacity: 1;
}
    

.testim .cont div .img img {
    display: block;
    width: 100px;
    height: 100px;
    margin: auto;
    border-radius: 10%;
}

.testim .cont div h2 {
    color: #ea830e;
    font-size: 1em;
    margin: 15px 0;
}

.testim .cont div p {
    font-size: 1.15em;
    color: #4c4c4c;
    width: 80%;
    margin: auto;
}

.testim .cont div.active .img img {
    -webkit-animation: testim-show .5s ease-in-out forwards;            
    -moz-animation: testim-show .5s ease-in-out forwards;            
    -ms-animation: testim-show .5s ease-in-out forwards;            
    -o-animation: testim-show .5s ease-in-out forwards;            
    animation: testim-show .5s ease-in-out forwards;            
}

.testim .cont div.active h2 {
    -webkit-animation: testim-content-in .4s ease-in-out forwards;    
    -moz-animation: testim-content-in .4s ease-in-out forwards;    
    -ms-animation: testim-content-in .4s ease-in-out forwards;    
    -o-animation: testim-content-in .4s ease-in-out forwards;    
    animation: testim-content-in .4s ease-in-out forwards;    
}

.testim .cont div.active p {
    -webkit-animation: testim-content-in .5s ease-in-out forwards;    
    -moz-animation: testim-content-in .5s ease-in-out forwards;    
    -ms-animation: testim-content-in .5s ease-in-out forwards;    
    -o-animation: testim-content-in .5s ease-in-out forwards;    
    animation: testim-content-in .5s ease-in-out forwards;    
}

.testim .cont div.inactive .img img {
    -webkit-animation: testim-hide .5s ease-in-out forwards;            
    -moz-animation: testim-hide .5s ease-in-out forwards;            
    -ms-animation: testim-hide .5s ease-in-out forwards;            
    -o-animation: testim-hide .5s ease-in-out forwards;            
    animation: testim-hide .5s ease-in-out forwards;            
}

.testim .cont div.inactive h2 {
    -webkit-animation: testim-content-out .4s ease-in-out forwards;        
    -moz-animation: testim-content-out .4s ease-in-out forwards;        
    -ms-animation: testim-content-out .4s ease-in-out forwards;        
    -o-animation: testim-content-out .4s ease-in-out forwards;        
    animation: testim-content-out .4s ease-in-out forwards;        
}

.testim .cont div.inactive p {
    -webkit-animation: testim-content-out .5s ease-in-out forwards;    
    -moz-animation: testim-content-out .5s ease-in-out forwards;    
    -ms-animation: testim-content-out .5s ease-in-out forwards;    
    -o-animation: testim-content-out .5s ease-in-out forwards;    
    animation: testim-content-out .5s ease-in-out forwards;    
}

@-webkit-keyframes testim-scale {
    0% {
        -webkit-box-shadow: 0px 0px 0px 0px #eee;
        box-shadow: 0px 0px 0px 0px #eee;
    }

    35% {
        -webkit-box-shadow: 0px 0px 10px 5px #eee;        
        box-shadow: 0px 0px 10px 5px #eee;        
    }

    70% {
        -webkit-box-shadow: 0px 0px 10px 5px #ea830e;        
        box-shadow: 0px 0px 10px 5px #ea830e;        
    }

    100% {
        -webkit-box-shadow: 0px 0px 0px 0px #ea830e;        
        box-shadow: 0px 0px 0px 0px #ea830e;        
    }
}

@-moz-keyframes testim-scale {
    0% {
        -moz-box-shadow: 0px 0px 0px 0px #eee;
        box-shadow: 0px 0px 0px 0px #eee;
    }

    35% {
        -moz-box-shadow: 0px 0px 10px 5px #eee;        
        box-shadow: 0px 0px 10px 5px #eee;        
    }

    70% {
        -moz-box-shadow: 0px 0px 10px 5px #ea830e;        
        box-shadow: 0px 0px 10px 5px #ea830e;        
    }

    100% {
        -moz-box-shadow: 0px 0px 0px 0px #ea830e;        
        box-shadow: 0px 0px 0px 0px #ea830e;        
    }
}

@-ms-keyframes testim-scale {
    0% {
        -ms-box-shadow: 0px 0px 0px 0px #eee;
        box-shadow: 0px 0px 0px 0px #eee;
    }

    35% {
        -ms-box-shadow: 0px 0px 10px 5px #eee;        
        box-shadow: 0px 0px 10px 5px #eee;        
    }

    70% {
        -ms-box-shadow: 0px 0px 10px 5px #ea830e;        
        box-shadow: 0px 0px 10px 5px #ea830e;        
    }

    100% {
        -ms-box-shadow: 0px 0px 0px 0px #ea830e;        
        box-shadow: 0px 0px 0px 0px #ea830e;        
    }
}

@-o-keyframes testim-scale {
    0% {
        -o-box-shadow: 0px 0px 0px 0px #eee;
        box-shadow: 0px 0px 0px 0px #eee;
    }

    35% {
        -o-box-shadow: 0px 0px 10px 5px #eee;        
        box-shadow: 0px 0px 10px 5px #eee;        
    }

    70% {
        -o-box-shadow: 0px 0px 10px 5px #ea830e;        
        box-shadow: 0px 0px 10px 5px #ea830e;        
    }

    100% {
        -o-box-shadow: 0px 0px 0px 0px #ea830e;        
        box-shadow: 0px 0px 0px 0px #ea830e;        
    }
}

@keyframes testim-scale {
    0% {
        box-shadow: 0px 0px 0px 0px #eee;
    }

    35% {
        box-shadow: 0px 0px 10px 5px #eee;        
    }

    70% {
        box-shadow: 0px 0px 10px 5px #ea830e;        
    }

    100% {
        box-shadow: 0px 0px 0px 0px #ea830e;        
    }
}

@-webkit-keyframes testim-content-in {
    from {
        opacity: 0;
        -webkit-transform: translateY(100%);
        transform: translateY(100%);
    }
    
    to {
        opacity: 1;
        -webkit-transform: translateY(0);        
        transform: translateY(0);        
    }
}

@-moz-keyframes testim-content-in {
    from {
        opacity: 0;
        -moz-transform: translateY(100%);
        transform: translateY(100%);
    }
    
    to {
        opacity: 1;
        -moz-transform: translateY(0);        
        transform: translateY(0);        
    }
}

@-ms-keyframes testim-content-in {
    from {
        opacity: 0;
        -ms-transform: translateY(100%);
        transform: translateY(100%);
    }
    
    to {
        opacity: 1;
        -ms-transform: translateY(0);        
        transform: translateY(0);        
    }
}

@-o-keyframes testim-content-in {
    from {
        opacity: 0;
        -o-transform: translateY(100%);
        transform: translateY(100%);
    }
    
    to {
        opacity: 1;
        -o-transform: translateY(0);        
        transform: translateY(0);        
    }
}

@keyframes testim-content-in {
    from {
        opacity: 0;
        transform: translateY(100%);
    }
    
    to {
        opacity: 1;
        transform: translateY(0);        
    }
}

@-webkit-keyframes testim-content-out {
    from {
        opacity: 1;
        -webkit-transform: translateY(0);
        transform: translateY(0);
    }
    
    to {
        opacity: 0;
        -webkit-transform: translateY(-100%);        
        transform: translateY(-100%);        
    }
}

@-moz-keyframes testim-content-out {
    from {
        opacity: 1;
        -moz-transform: translateY(0);
        transform: translateY(0);
    }
    
    to {
        opacity: 0;
        -moz-transform: translateY(-100%);        
        transform: translateY(-100%);        
    }
}

@-ms-keyframes testim-content-out {
    from {
        opacity: 1;
        -ms-transform: translateY(0);
        transform: translateY(0);
    }
    
    to {
        opacity: 0;
        -ms-transform: translateY(-100%);        
        transform: translateY(-100%);        
    }
}

@-o-keyframes testim-content-out {
    from {
        opacity: 1;
        -o-transform: translateY(0);
        transform: translateY(0);
    }
    
    to {
        opacity: 0;
        transform: translateY(-100%);        
        transform: translateY(-100%);        
    }
}

@keyframes testim-content-out {
    from {
        opacity: 1;
        transform: translateY(0);
    }
    
    to {
        opacity: 0;
        transform: translateY(-100%);        
    }
}

@-webkit-keyframes testim-show {
    from {
        opacity: 0;
        -webkit-transform: scale(0);
        transform: scale(0);
    }
    
    to {
        opacity: 1;
        -webkit-transform: scale(1);       
        transform: scale(1);       
    }
}

@-moz-keyframes testim-show {
    from {
        opacity: 0;
        -moz-transform: scale(0);
        transform: scale(0);
    }
    
    to {
        opacity: 1;
        -moz-transform: scale(1);       
        transform: scale(1);       
    }
}

@-ms-keyframes testim-show {
    from {
        opacity: 0;
        -ms-transform: scale(0);
        transform: scale(0);
    }
    
    to {
        opacity: 1;
        -ms-transform: scale(1);       
        transform: scale(1);       
    }
}

@-o-keyframes testim-show {
    from {
        opacity: 0;
        -o-transform: scale(0);
        transform: scale(0);
    }
    
    to {
        opacity: 1;
        -o-transform: scale(1);       
        transform: scale(1);       
    }
}

@keyframes testim-show {
    from {
        opacity: 0;
        transform: scale(0);
    }
    
    to {
        opacity: 1;
        transform: scale(1);       
    }
}

@-webkit-keyframes testim-hide {
    from {
        opacity: 1;
        -webkit-transform: scale(1);       
        transform: scale(1);       
    }
    
    to {
        opacity: 0;
        -webkit-transform: scale(0);
        transform: scale(0);
    }
}

@-moz-keyframes testim-hide {
    from {
        opacity: 1;
        -moz-transform: scale(1);       
        transform: scale(1);       
    }
    
    to {
        opacity: 0;
        -moz-transform: scale(0);
        transform: scale(0);
    }
}

@-ms-keyframes testim-hide {
    from {
        opacity: 1;
        -ms-transform: scale(1);       
        transform: scale(1);       
    }
    
    to {
        opacity: 0;
        -ms-transform: scale(0);
        transform: scale(0);
    }
}

@-o-keyframes testim-hide {
    from {
        opacity: 1;
        -o-transform: scale(1);       
        transform: scale(1);       
    }
    
    to {
        opacity: 0;
        -o-transform: scale(0);
        transform: scale(0);
    }
}

@keyframes testim-hide {
    from {
        opacity: 1;
        transform: scale(1);       
    }
    
    to {
        opacity: 0;
        transform: scale(0);
    }
}

@media all and (max-width: 300px) {
	body {
		font-size: 14px;
	}
}

@media all and (max-width: 500px) {
	.testim .arrow {
		font-size: 1.5em;
	}
	
	.testim .cont div p {
		line-height: 25px;
	}

}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section id="slider" class="fullwidth">
      <div class="slider owl-carousel owl-theme">
                    <a href="#" target="_blank">
              <div class="item">
                <img src="images/banner1.jpg" alt="" class="img-responsive" />
                <div class="cover">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="slider-content">
                                    <div class="slider-title"></div>
                                    <div class="slider-sub-title"></div>
                                    <p class="slider-para"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
            </a>

                            <a href="#" target="_blank">
              <div class="item">
                <img src="images/banner2.jpg" alt="" class="img-responsive" />
                <div class="cover">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="slider-content">
                                    <div class="slider-title"></div>
                                    <div class="slider-sub-title"></div>
                                    <p class="slider-para"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
            </a>

                            <a href="#" target="_blank">
              <div class="item">
                <img src="images/banner3.jpg" alt="" class="img-responsive" />
                <div class="cover">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="slider-content">
                                    <div class="slider-title"></div>
                                    <div class="slider-sub-title"></div>
                                    <p class="slider-para"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
            </a>

                            <a href="#" target="_blank">
              <div class="item">
                <img src="images/banner1.jpg" alt="" class="img-responsive" />
                <div class="cover">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="slider-content">
                                    <div class="slider-title"></div>
                                    <div class="slider-sub-title"></div>
                                    <p class="slider-para"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
            </a>

                            <a href="#" target="_blank">
              <div class="item">
                <img src="images/banner2.jpg" alt="" class="img-responsive" />
                <div class="cover">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="slider-content">
                                    <div class="slider-title"></div>
                                    <div class="slider-sub-title"></div>
                                    <p class="slider-para"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
            </a>

                            <a href="#" target="_blank">
              <div class="item">
                <img src="images/banner3.jpg" alt="" class="img-responsive" />
                <div class="cover">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm-6 col-12">
                                <div class="slider-content">
                                    <div class="slider-title"></div>
                                    <div class="slider-sub-title"></div>
                                    <p class="slider-para"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>
              </div>
            </a>

                    </div>
    </section>
    <section id="habout" class="fullwidth">
  <div class="container">
    <div class="row">
      <div class="col-lg-6 col-sm-6 col-xs-12">
        <div class="title">
          <h2 style="text-align: left;">About CPA Services</h2>
        </div>
        <div class="para" style="text-align: justify;">
          <p>CPA Services was established in 2007 and is part of the “Financial Management Service Foundation” (FMSF) family. It carries forward the mandate of FMSF to promote accountability and build capacity in the non-profit sector & the CSR sector by infusing best practices and professionalism through its activities. It firmly believes in the values of accountability, transparency and good governance.CPA Services entails these values in its services to help organizations achieve development effectiveness.</p>
          <a href="AboutUs.aspx">Learn more <span><i class="icon arrow-left"></i></span></a>
        </div>
      </div>
      <div class="col-lg-6 col-sm-6 col-xs-12">
        <div class="static-data">
            <div class="col-lg-4 col-sm-4 col-xs-4">
              <div class="static">
                <div class="panel">
                  <div class="panel-body">
                    <div class="simg"><img src="images/alumni.png" /></div>
                    <div class="cot-text">
                      <div class="counter" data-count="<%=stdAdmissionCount %>"><%=stdAdmissionCount %></div>
                      <div class="ctext">Enrolment this Year</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="col-lg-4 col-sm-4 col-xs-4">
              <div class="static">
                <div class="panel">
                  <div class="panel-body">
                    <div class="simg"><img src="images/student.png" /></div>
                    <div class="cot-text">
                      <div class="counter" data-count="<%=stdPassedCount %>">
                          <%=stdPassedCount %></div>
                      <div class="ctext">Students Passed</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="col-lg-4 col-sm-4 col-xs-4">
              <div class="static">
                <div class="panel">
                  <div class="panel-body">
                    <div class="simg"><i class="icon ws"></i></div>
                    <div class="cot-text">
                      <div class="counter" data-count="<%=stdCourseCount %> "><%=stdCourseCount %> </div>
                      <div class="ctext">Courses Offered</div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div style="padding:35px">
            <div class="ngo-title">Knowledge Center</div>
      <div class="ngo-list">
        <div class="row"><div class="col-lg-4 col-sm-4 col-xs-4" style="text-align:center"><div class="simg"><a href="KnowledgeCenterDetails.aspx?SubjectType=Video Pods"><img src="images/KnowledgeCenter-video.png" /><br /><b>Video</b></a></div></div>
     <div class="col-lg-4 col-sm-4 col-xs-4" style="text-align:center"><div class="simg"><a href="KnowledgeCenterDetails.aspx?SubjectType=Audio Pods"><img src="images/KnowledgeCenter-audio.png" /><br /><b>Audio</b></a></div></div>
<div class="col-lg-4 col-sm-4 col-xs-4" style="text-align:center"><div class="simg"><a href="KnowledgeCenterDetails.aspx?SubjectType=Magazine and Article"><img src="images/KnowledgeCenter-articles.png" /><br /><b>Articles</b></a></div></div>
    </div></div>
          </div>
          </div>
      
      </div>
    </div>
  </div>
</section>
    <section class="homeservices">
  <div class="container">
    <div class="col-lg-12 col-sm-12 col-xs-12">
        <div class="title">
          <h2>Courses Offered</h2>
        </div>
      </div>

<%--    
              <div class="common-block-three">
                <div class="flipbox1">
              <div class="flipbox-inner1">
                  <div class="flipbox-front1">
                                        <div class="hs-img">
                      <img src="images/graduation-cap.png" />
                    </div>
                                        <div class="hs-title">
                      <p class="course-name">21 Days crash course on FCRA</p>
                    </div>
                  </div>
                  <div class="flipbox-back1">
                                        <div class="course-detail">
                    <a href="#" style="color:#fff">DFMA is a 1 year online diploma program, especially designed to suit the needs of individuals who are already working in the voluntary sector as well as those who are seeking to join the sector. The program is in joint partnership..</a>
                  </div>
                                      </div>
                </div>
              </div>
            </div>

            
              <div class="common-block-three">
                <div class="flipbox1">
              <div class="flipbox-inner1">
                  <div class="flipbox-front1">
                                        <div class="hs-img">
                      <img src="images/graduation-cap.png" />
                    </div>
                                        <div class="hs-title">
                      <p class="course-name">Diploma in Financial Management and Accountability</p>
                    </div>
                  </div>
                  <div class="flipbox-back1">
                                        <div class="course-detail">
                   <a href="#" style="color:#fff">NPO Governance Program is a 4 month online certificate course. NPO Governance Program provides clarity on conceptual knowledge and processes on organizational governance for effectively running a not-for-profit organization (NPO)..</a>
                  </div>
                                      </div>
                </div>
              </div>
            </div>

            
              <div class="common-block-three">
                <div class="flipbox1">
              <div class="flipbox-inner1">
                  <div class="flipbox-front1">
                                        <div class="hs-img">
                      <img src="images/graduation-cap.png" />
                    </div>
                                        <div class="hs-title">
                      <p class="course-name">NPO Governance Program</p>
                    </div>
                  </div>
                  <div class="flipbox-back1">
                                        <div class="course-detail">
                    <a href="#" style="color:#fff">PME is a 6 months web based online program. Monitoring and Evaluation (M&E) are important for development organizations in order to assess the results achieved with respect to the set targets. Firstly, by monitoring the developme..</a>
                  </div>
                                      </div>
                </div>
              </div>
            </div>--%>

              <%--<div class="common-block-three">
                <div class="flipbox1">
              <div class="flipbox-inner1">
                  <div class="flipbox-front1">
                                        <div class="hs-img">
                      <img src="images/graduation-cap.png" />
                    </div>
                                        <div class="hs-title">
                      <p class="course-name">Planning, Monitoring and Evaluation</p>
                    </div>
                  </div>
                  <div class="flipbox-back1">
                                        <div class="course-detail">
                   <a href="#" style="color:#fff">CPA Services launches 21-dayCrash course on FCRA-Concept and Practice This 21-day course aims at developing concepts and practical application of the FCRA law among the participants. It is also an great opportunity for particip..</a>
                  </div>
                                      </div>
                </div>
              </div>
            </div>--%>

      <asp:Repeater ID="DlsDetails" runat="server">
                                    <ItemTemplate>
                                       <div class="span4">
                                           <div class="common-block-three">
                <div class="flipbox1">
              <div class="flipbox-inner1">
                  <div class="flipbox-front1">
                                        <div class="hs-img">
                      <img src="images/graduation-cap.png" />
                    </div>
                                        <div class="hs-title">
                      <p class="course-name"><%# Eval("CourseName")%></p>
                    </div>
                  </div>
                  <div class="flipbox-back1">
                                        <div class="course-detail">
                   <a href="CourseDetailsInfo.aspx?CID=<%# Eval("courseid").ToString()%>" style="color:#fff"><%# Eval("TextDetails").ToString()%> ...</a>
                  </div>
                                      </div>
                </div>
              </div>
            </div>
                                           <%-- <div class="media" style="height:400px; padding-top: 60px;">
                                               
                                                <div class="media-body" style="padding-bottom: 40px;">
                                                    <h4 class="course-heading" style="border-bottom: solid 1px #ffffff;"><%# Eval("CourseName")%></h4>
                                                    
                                                    <p style="padding-bottom:30px; height: 170px; overflow:auto"><%# Eval("TextDetails").ToString()%> ...</p>
                                                    
                                                                                                    </div>
                                            </div>--%>
                                        </div>         
                                         
                                    </ItemTemplate>
                                    
                                </asp:Repeater>
  </div>
</section>

<!-- News start -->
<section class="sectionpad newsbg fullwidth">
    <div class="container">
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
        <div class="imp-link">
          <div class="title-left"><h2>Events and Updates</h2></div>
          <div class="feature-news">
         <%--<ul> 
		<li>
		<a href="#" class="title">
			<small class="date"><i class="calenders"></i> Aug 19, 2020</small>
			<span>Clarification on Extension of Annual General Meeting (AGM) for the Financial Year ended as on 31.03.2020</span>
		</a>
	</li>
		<li>
		<a href="#" class="title">
			<small class="date"><i class="calenders"></i> Aug 11, 2020</small>
			<span>E-communique released on Board Meetings through Video Conferencing</span>
		</a>
	</li>
		<li>
		<a href="#" class="title">
			<small class="date"><i class="calenders"></i> Aug 11, 2020</small>
			<span>E-communique released on EGM &amp; AGM through video conferencing</span>
		</a>
	</li>
	</ul>--%>
    <asp:Repeater ID="dlnews" runat="server">
                   <ItemTemplate>
                   <%--<div class="item">
                        <div class="row-fluid">--%>
                        <ul>
                        <li>
                            <a href="#" class="title" onclick="openModalNews(<%#Eval("NewsId")%>)">
			<small class="date"><i class="calenders"></i> <%#Format(CDate(DataBinder.Eval(Container.DataItem, "ndate")), "dd-MMM-yyyy")%></small>
			<span><%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%></span>
		</a><hr />
                           <%-- <div class="media-body" style="padding-left: 10px; text-align: justify; font-size:14px;">
                                <span style="font-family: sans-serif;color: #3498db;"><strong><i class="date"></i> <%#Format(CDate(DataBinder.Eval(Container.DataItem, "ndate")), "dd-MMM-yyyy")%> </strong></span>
                                <p style="border-top: solid 1px #cecdcd;padding-top: 6px;"><%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%></p>
                            
                            </div>--%>
                            <div id="myModalNews<%#Eval("NewsId")%>" class="modal fade" tabindex="-1" role="dialog" aria-labeledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" >
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title"><small class="date"><i class="calenders"></i> <%#Format(CDate(DataBinder.Eval(Container.DataItem, "ndate")), "dd-MMM-yyyy")%></small></h4>
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        </div>
                                        <div class="modal-body">
                                             <%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%><br /><br /><br /><br />
                                        <div class="fc-row">

                                         <div class="col-md-6">
                                            <%-- <a class="btn btn-primary" href="https://www.facebook.com/sharer/sharer.php?app_id=3548822928518556&sdk=joey&u=http://cleverjournal.net/Editorial.aspx&display=popup&ref=plugin&src=share_button" onclick="return !window.open(this.href, 'Facebook', 'width=640,height=580')">Facebook share</a>&nbsp;--%>
                                              <a class="btn btn-primary" href="http://www.facebook.com/share.php?u=<url>" onclick="return fbs_click()" target="_blank">Facebook share</a>
                                         </div>
                                         <div class="col-md-6">
                                            <a class="btn btn-primary" href="https://twitter.com/intent/tweet?text=<%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "descr"), "dq$", """"), "com$", ","), "qu$", "'"), "amp$", "&")%>" data-size="large" target="_blank">Tweet</a>&nbsp;
                                         </div>
                                        </div>
                                        <div class="fc-row">
                                        <div class="col-md-6">
                                            <%--<a class="btn btn-primary" href="https://www.linkedin.com/shareArticle?mini=true&url=http://fmsflearningsystems.org&title=FMSF - News&source=MyTestLink" onclick="window.open(this.href, 'mywin',
                                                        'left=20,top=20,width=500,height=500,toolbar=1,resizable=0'); return false;">
                                                 Linkedin
                                                 <img src="https://chillyfacts.com/wp-content/uploads/2017/06/LinkedIN.gif" alt="" width="54" height="20" />
                                             </a>&nbsp;--%>
                                         <a class="btn btn-primary" onclick="return Linkedins_click()" target="_blank">
                                                 Linkedin
                                             </a>
                                         </div>
                                        <div class="col-md-6">
                                                
                                            <%--<a class="btn btn-primary" href="https://plus.google.com/share?url=http%3A%2F%2Fhttp://www.c-sharpcorner.com%3Fa%3Db%26c%3Dd">Share Google +</a>&nbsp;--%>
                                            <a class="btn btn-primary" href="https://plus.google.com/share?url=http://http://fmsflearningsystems.org/" target="_blank">Share on Google+</a>
                                        </div>
                                         </div>
                                         </div>
                                            
                                            
                                        <div class="modal-footer" >
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </li>
                        </ul>
                       <%-- </div>
                    </div>--%>
                        </ItemTemplate>
                        </asp:Repeater>
           <a class="readmore" href="#">View All</a>
          </div>
          <a class="readmore" href="#">View All</a>
        </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
        <div class="imp-link">
          <div class="title-left"><h2>Video Zone</h2></div>
          <div class="vt-sec">
             
<div class="video-img-thum">
    <video width="380" height="365" controls id="IframeVideo">
     <source src="<%=VideoDemo %>" type="video/mp4"></source>
     
     </video>
     <%--<iframe id="ifrm" runat="server"  width="560" height="365" frameborder="0"  allow="accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>--%>


</div>
 <%--<div class="video-title"><span>Webinar on FCRA IMPACT</span></div>--%>
                <!-- </div> -->
                <!-- <div class="video-title">Lorem Ipsum is simply dummy...</div> 
            </a>-->
          </div>
          <a class="readmore" href="#">View All</a>
        </div>
      </div>
      <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
        <div class="imp-link">
          <%--<div class="title-left"><h2>Important Dates</h2></div>--%>
          <div class="calendar-wrapper">
              <div id="calenderNew"></div>

        <div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog" >
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title"><span id="eventTitle"></span></h4>
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
              
                <p id="pDetails"></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
              <%-- <div id="datepicker-22"></div><div id='calendar'></div>--%>

          </div>
        </div>
      </div>
      
    </div>
</section> 
<!-- News end -->

<section class="testimonial-bg">
<div class="container">

<div class="col-lg-12 col-sm-12 col-xs-12">
        <div class="title">
          <h2>Testimonials</h2>
        </div>
      </div>

<!-- Testimonial Carousel -->

    <div class="testimonial-reel">
        <% If (dsTestimonials.Tables IsNot Nothing) Then %>
        <% If (dsTestimonials.Tables(0).Rows IsNot Nothing) Then %>
        <% If (dsTestimonials.Tables(0).Rows.Count > 0) Then%>

         <%For i As Integer = 0 To dsTestimonials.Tables(0).Rows.Count - 1%>
            <div>

            <div class="box-white">

                <!-- Testimonial Image -->
                <figure class="image">
                    <%--<img class="img-fluid rounded-circle" src="https://www.w3schools.com/howto/img_avatar.png">--%>
                    <img class="img-fluid rounded-circle" src='<%= IIf(dsTestimonials.Tables(0).Rows(i)("images").ToString() = "", "Images/noimage.png", dsTestimonials.Tables(0).Rows(i)("images").ToString())%>' />
                </figure>
                <!-- / Testimonial Image -->

                <div class="test-component">
                    <!-- Title -->
                    <article class="test-title">

                        <h4>
                          <%= dsTestimonials.Tables(0).Rows(i)("Name").ToString() %>
                        </h4>

                    </article>
                    <!-- / Title -->

                    <article class="test-content">
                        <p>
                           <%= dsTestimonials.Tables(0).Rows(i)("description").ToString() + " ..."%><% i = i + 1%>
                        </p>
                    </article>

                </div>

            </div>

        </div>
          
         <%Next%>
        <%End If %>
        <%End If %>
        <%End If %>
    </div>

</div>
</section>




<section id="recent-works" class="testim">
<div class="title">
          <h2>Course Faculty</h2>
        </div>
<div class="wrap">

                <span id="right-arrow" class="arrow right fa fa-chevron-right"></span>
                <span id="left-arrow" class="arrow left fa fa-chevron-left "></span>
                <%--<ul id="testim-dots" class="dots">
                    <li class="dot active"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li><!--
                    --><li class="dot"></li>
                </ul>--%>
     <asp:PlaceHolder ID = "PlcDotsCount" runat="server"  />
                <%--<div id="testim-content" class="cont">
                    
                    <div class="active">
                        <div class="img"><img src="https://image.ibb.co/hgy1M7/5a6f718346a28820008b4611_750_562.jpg" alt=""></div>
                        <h2>Lorem P. Ipsum</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>                    
                    </div>
                    <div  id='1'><div class='img'><img src='https://image.ibb.co/hgy1M7/5a6f718346a28820008b4611_750_562.jpg' alt=''></div>
                        <h2>Dr. Vidya Rao</h2>
                        <p>Dr.Vidya Rao, Trustee, is Emeritus Professor of the Department of Social Welfare Administration at the Tata Institute of Social Sciences, (TISS) </p>

                    </div>
<div id='2'><div class='img'><img src='https://image.ibb.co/kL6AES/Top_SA_Nicky_Oppenheimer.jpg' alt=''></div>
    <h2>Dr. Manoj Fogla</h2>
    <p>Dr. Manoj Fogla is a development consultant who has been involved in the Voluntary Sector since many years. A Chartered Accountant by qualification, Dr. Fogla specializes in financial evaluations & reviews of development programs. 
</p>

</div>
                    
                                      <div>
                        <div class="img"><img src="https://image.ibb.co/cNP817/pexels_photo_220453.jpg" alt=""></div>
                        <h2>Mr. Lorem Ipsum</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>                    
                    </div>

                    <div>
                        <div class="img"><img src="https://image.ibb.co/iN3qES/pexels_photo_324658.jpg" alt=""></div>
                        <h2>Lorem Ipsum</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>                    
                    </div>

                    <div>
                        <div class="img"><img src="https://image.ibb.co/kL6AES/Top_SA_Nicky_Oppenheimer.jpg" alt=""></div>
                        <h2>Lorem De Ipsum</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>                    
                    </div>

                    <div>
                        <div class="img"><img src="https://image.ibb.co/gUPag7/image.jpg" alt=""></div>
                        <h2>Ms. Lorem R. Ipsum</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>                    
                    </div>
                    <asp:Repeater ID="rptrFaculties" runat="server">
                    <ItemTemplate>

                       
                    
                    <div >
                        <div class="img"><img src='<%# IIf(Eval("Images").ToString() = "", "Images/noimage.png", Eval("Images"))%>' alt="Faculty" class="image" width="74%"  /></div>
                        <h2><%# Eval("firstName")%> <%# Eval("lastname")%></h2>
                        <p><%# Eval("Profile")%></p>                    
                    </div>

                        
                    </ItemTemplate>
                   </asp:Repeater>

                   
                </div>--%>
    
        <div id="testim-content" class="cont">
                <asp:PlaceHolder ID = "PlaceHolder1" runat="server"  />
            </div>
            </div>

    </section>

<script src="https://use.fontawesome.com/1744f3f671.js"></script>
<script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.min.js"></script>
<script src="js/jquery.slitslider.js"></script>
<!-- /Required javascript files for Slider -->
<script src="public/assets/themes/theme-1/fullcalendar/dist/fullcalendar.min.js"></script>

<script type="text/javascript">

    function fbs_click() {
        u = document.URL;
        //location.href;
        t = document.title;

        window.open('https://www.facebook.com/sharer/sharer.php?app_id=3548822928518556&sdk=joey&?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t) + '&display=popup&ref=plugin&src=share_button', 'facebook', 'width=640,height=580');
        return false;
    }

    function Linkedins_click() {
        u = document.URL;
        //location.href;
        t = document.title;

        window.open('https://www.linkedin.com/shareArticle?mini=true&url=' + u + '&title=FMSF - News&source=MyTestLink', 'mywin', 'left=20,top=20,width=500,height=500,toolbar=1,resizable=0');
        return false;
    }
    </script>
<script type="text/javascript">

$(document).ready(function () {
    var enabledDate_ar = ["2020-01-07","2020-01-15","2020-01-31","2020-02-07","2020-02-15","2020-03-07","2020-03-15","2020-04-15","2020-04-30","2020-05-07","2020-05-15","2020-05-31","2020-06-07","2020-06-15","2020-07-07","2020-07-15","2020-07-31","2020-08-07","2020-08-15","2020-09-07","2020-09-15","2020-09-30","2020-10-07","2020-10-15","2020-10-31","2020-11-07","2020-11-15","2020-12-07","2020-12-15","2020-12-31"];
    var calendar = $('#calendar').fullCalendar({
        //defaultView: 'month',
        default: true,
        editable: true,
        header: {
          left:   'title',
          center: '',
          right:  'prev,next'
        },        
        events: [],
        displayEventTime: false,
        eventRender: function (event, element, view) {
            if (event.allDay === 'true') {
                event.allDay = true;
            } else {
                event.allDay = false;
            }
        },
        selectable: false,
        selectHelper: true,
        viewRender: function(currentView)
        {
      
          var select_date = $('#calendar').fullCalendar('getDate');
          select_date=new Date(select_date);
          
          var sel_d    = select_date.getDate();  
          var sel_m    = select_date.getMonth();
          var sel_y    = select_date.getFullYear();
         
          var curr_date =new Date(); 
          var curr_d    = curr_date.getDate();
          var curr_m    = curr_date.getMonth();
          var curr_y    = curr_date.getFullYear();
          
                   
          
          var minDate = moment(),
          maxDate = moment().add(2,'weeks');

          // Past
          /*if (minDate >= currentView.start && minDate <= currentView.end) {
            $(".fc-prev-button").prop('disabled', true); 
            $(".fc-prev-button").addClass('fc-state-disabled'); 
          }
          else {
            $(".fc-prev-button").removeClass('fc-state-disabled'); 
            $(".fc-prev-button").prop('disabled', false); 
          }*/
          
        },
        dayRender: function (date, cell) {
          var all_date=date.format('YYYY-MM-DD'); // Y-m-d
          //console.log('Date:'+all_date);

          if($.inArray(all_date,enabledDate_ar)!=-1)
          {          
            cell.css("background-color", "#c0d4e9"); 
          }
      },
        dayClick: function(date) 
        {
         
           var sel_date=date.format('YYYY-MM-DD'); // Y-m-d
           if($.inArray(sel_date,enabledDate_ar)!=-1)
           {

           // alert('Date: '+sel_date);

              //$('#odates').val(sel_date); //set date in datepicker

              //on changes date in datepicker load relative traveller data
              load_taxData(sel_date);

                 //For scroll up
                // $('html, body').animate({
               //   scrollTop: $("#odates").offset().top
              //}, 2000);   
           }
        },
        /*select: function (start, end, allDay) {
            var title = prompt('Event Title:');

            if (title) {
                var start = $.fullCalendar.formatDate(start, "Y-MM-DD HH:mm:ss");
                var end = $.fullCalendar.formatDate(end, "Y-MM-DD HH:mm:ss");
                calendar.fullCalendar('renderEvent',
                        {
                            title: title,
                            start: start,
                            end: end,
                            allDay: allDay
                        },
                true
                        );
            }
            calendar.fullCalendar('unselect');
        },*/
        eventClick: function (event) {
          displayMessage(event);
        }
        
        

    });
});
  

function load_taxData(date='') {
    //console.log(date);

    if(date!='')
    {
      var _token = 'wlPx7BsK7vhTco7N42aaKZZ5iGplKkrCyyArudl9';

      $.ajax( {
        url: "https://www.legalissuesforngos.org/get-tax",
        type: "POST",
        data: {selDate:date},
        dataType: "JSON",
        headers: {
          'X-CSRF-TOKEN': _token
        },
        cache: false,
        success: function ( resp ) {

          if(resp.success == 1)
          {
            //console.log(resp.html);        

            var duDate = formatDate(date);

            $('#taxModalLong #taxModalLongTitle').html(duDate);
            $('#taxModalLong .modal-body').html(resp.html);
            $('#taxModalBtn').trigger('click');

          }


        }
      } );

    }
    return true;
}

function formatDate(date) {
  var start_date = moment(date).format('MMMM DD, YYYY');//date;
  return start_date;
}

function displayMessage(message) {
  
  var start_date = $.fullCalendar.formatDate(message.start, "DD-MM-Y");
    $('#taxModalLong #taxModalLongTitle').html('<strong>Form no: </strong>'+message.form_no);
    $('#taxModalLong .modal-body').html('<p><strong>Statutory dues: </strong>'+message.title+' </p><p> <strong>Due Date : </strong>'+start_date+'</p>');
    $('#taxModalBtn').trigger('click');
      
      //$(".response").html("<div class='success'>"+message+"</div>");
      //setInterval(function() { $(".success").fadeOut(); }, 1000);
}

$(document).ready(function(){
    $('#lightgallery').lightGallery();
});
</script>
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

<script>
    //Slick Carousel Controllers
    $(".testimonial-reel").slick({
        autoplay: true,
        autoplaySpeed: 5000,
        centerMode: true,
        centerPadding: "40px",
        dots: true,
        slidesToShow: 3,
        infinite: true,
        arrows: false,
        lazyLoad: "ondemand",
        responsive: [
    {
        breakpoint: 1024,
        settings: {
            slidesToShow: 2,
            centerMode: false
        }
    },
    {
        breakpoint: 767,
        settings: {
            slidesToShow: 1
        }
    }
  ]
    });
</script>

<script>
    // vars
    'use strict'
    var testim = document.getElementById("testim"),
		testimDots = Array.prototype.slice.call(document.getElementById("testim-dots").children),
    testimContent = Array.prototype.slice.call(document.getElementById("testim-content").children),
    testimLeftArrow = document.getElementById("left-arrow"),
    testimRightArrow = document.getElementById("right-arrow"),
    testimSpeed = 4500,
    currentSlide = 0,
    currentActive = 0,
    testimTimer,
		touchStartPos,
		touchEndPos,
		touchPosDiff,
		ignoreTouch = 30;
    ;

    window.onload = function () {

        // Testim Script
        function playSlide(slide) {
            for (var k = 0; k < testimDots.length; k++) {
                testimContent[k].classList.remove("active");
                testimContent[k].classList.remove("inactive");
                testimDots[k].classList.remove("active");
            }

            if (slide < 0) {
                slide = currentSlide = testimContent.length - 1;
            }

            if (slide > testimContent.length - 1) {
                slide = currentSlide = 0;
            }

            if (currentActive != currentSlide) {
                testimContent[currentActive].classList.add("inactive");
            }
            testimContent[slide].classList.add("active");
            testimDots[slide].classList.add("active");

            currentActive = currentSlide;

            clearTimeout(testimTimer);
            testimTimer = setTimeout(function () {
                playSlide(currentSlide += 1);
            }, testimSpeed)
        }

        testimLeftArrow.addEventListener("click", function () {
            playSlide(currentSlide -= 1);
        })

        testimRightArrow.addEventListener("click", function () {
            playSlide(currentSlide += 1);
        })

        for (var l = 0; l < testimDots.length; l++) {
            testimDots[l].addEventListener("click", function () {
                playSlide(currentSlide = testimDots.indexOf(this));
            })
        }

        playSlide(currentSlide);

        // keyboard shortcuts
        document.addEventListener("keyup", function (e) {
            switch (e.keyCode) {
                case 37:
                    testimLeftArrow.click();
                    break;

                case 39:
                    testimRightArrow.click();
                    break;

                case 39:
                    testimRightArrow.click();
                    break;

                default:
                    break;
            }
        })

        testim.addEventListener("touchstart", function (e) {
            touchStartPos = e.changedTouches[0].clientX;
        })

        testim.addEventListener("touchend", function (e) {
            touchEndPos = e.changedTouches[0].clientX;

            touchPosDiff = touchStartPos - touchEndPos;

            console.log(touchPosDiff);
            console.log(touchStartPos);
            console.log(touchEndPos);


            if (touchPosDiff > 0 + ignoreTouch) {
                testimLeftArrow.click();
            } else if (touchPosDiff < 0 - ignoreTouch) {
                testimRightArrow.click();
            } else {
                return;
            }

        })
    }
</script>

<%--<script src="js/vendor/jquery-1.9.1.min.js" type="text/javascript"></script>--%>
    <script src="Calendar/jquery-1.10.2.min.js"  ></script>
       <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>
      <%--<script src="bootstrap/bootstrap.min.js"></script>--%>
    <script src="js/vendor/bootstrap.min.js"></script>
    <script type="text/javascript">
        var gbldata = '';
        $(document).ready(function () {
            // $('.spinner-wrapper').hide();
            var Courseid = "ALL";
            var events = [];
            var selectedEvent = null;
            FetchEventAndRenderCalendar();
            function FetchEventAndRenderCalendar() {
                events = [];
                $.ajax({
                    type: "POST",
                    url: "Calendar.aspx/GetAutherbyID_j",
                    data: "{Courseid:'" + Courseid + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        data = JSON.parse(data.d);
                        $.each(data, function (i, v) {
                           
                            events.push({
                                eventID: v.ID,
                                title: v.title,
                                description: v.ParticipantsComposition,
                                start: moment(v.start_date),
                                end: v.end_date != null ? moment(v.end_date) : null,
                                color: v.ThemeColor,
                                allDay: v.IsFullDay

                            });
                        })
                        gbldata = events;
                        
                        GenerateCalender(gbldata);
                    },
                    failure: function (response) {
                        alert("Error");
                    }
                });
            }

            function GenerateCalender(gbldata) {
               
                
                $('#calenderNew').fullCalendar('destroy');
                $('#calenderNew').fullCalendar({
                    contentHeight: 350,
                    defaultDate: new Date(),
                    timeFormat: 'h(:mm)a',
                    //header: {
                    //    left: 'prev,next today',
                    //    center: 'title',
                    //    right: 'month,basicWeek,basicDay'
                    //},
                    eventLimit: true,
                    eventColor: '#378006',
                    events: gbldata,
                    eventClick: function (calEvent, jsEvent, view) {                       
                        selectedEvent = calEvent;                       
                    $('#myModal #eventTitle').text(calEvent.title);
                    var $description = $('<div/>');
                    $description.append($('<p/>').html('<b>Start: </b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));
                    if (calEvent.end != null) {
                        $description.append($('<p/>').html('<b>End: </b>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
                    }
                    $description.append($('<p/>').html('<b>Description: </b>' + calEvent.description));
                    $('#myModal #pDetails').empty().html($description);

                    //$('#myModal').css({
                    //    'position': 'absolute',
                    //    'width': '500px',
                    //    'heigth' : '400px',
                    //    'left': '10%',
                    //    'top':'30%',
                    //    'transform': 'translate(-30%, -30%)'
                    //})

                    $('#myModal').modal();
                   },
                    selectable: true,
                    select: function (start, end) {
                        selectedEvent = {
                            eventID: 0,
                            title: '',
                            description: '',
                            start: start,
                            end: end,
                            allDay: false,
                            color: ''
                           
                        };
                        //openAddEditForm();
                        $('#calendar').fullCalendar('unselect');
                    },
                    editable: true,
                    eventDrop: function (event) {
                        var data = {
                            EventID: event.ID,
                            Subject: event.title,
                            Start: event.start.format('DD/MM/YYYY HH:mm A'),
                            End: event.end != null ? event.end.format('DD/MM/YYYY HH:mm A') : null,
                            Description: event.description,
                            ThemeColor: event.color,
                            IsFullDay: event.allDay

                        };
                        
                    }
                })

                //alert("hi");
            }

            $('#btnEdit').click(function () {
                //Open modal dialog for edit event
                openAddEditForm();
            })
            $('#btnDelete').click(function () {
                if (selectedEvent != null && confirm('Are you sure?')) {
                    $.ajax({
                        type: "POST",
                        url: '/home/DeleteEvent',
                        data: { 'eventID': selectedEvent.eventID },
                        success: function (data) {
                            if (data.status) {
                                //Refresh the calender
                                FetchEventAndRenderCalendar();
                                $('#myModal').modal('hide');
                            }
                        },
                        error: function () {
                            alert('Failed');
                        }
                    })
                }
            })

            $('#dtp1,#dtp2').datetimepicker({
                format: 'DD/MM/YYYY HH:mm A'
            });

            $('#chkIsFullDay').change(function () {
                if ($(this).is(':checked')) {
                    $('#divEndDate').hide();
                }
                else {
                    $('#divEndDate').show();
                }
            });

            function openAddEditForm() {
                if (selectedEvent != null) {
                    $('#hdEventID').val(selectedEvent.eventID);
                    $('#txtSubject').val(selectedEvent.title);
                    $('#txtStart').val(selectedEvent.start.format('DD/MM/YYYY HH:mm A'));
                    $('#chkIsFullDay').prop("checked", selectedEvent.allDay || false);
                    $('#chkIsFullDay').change();
                    $('#txtEnd').val(selectedEvent.end != null ? selectedEvent.end.format('DD/MM/YYYY HH:mm A') : '');
                    $('#txtDescription').val(selectedEvent.description);
                    $('#ddThemeColor').val(selectedEvent.color);
                }
                $('#myModal').modal('hide');
                $('#myModalSave').modal();
            }

            $('#btnSave').click(function () {
                //Validation/
                if ($('#txtSubject').val().trim() == "") {
                    alert('Subject required');
                    return;
                }
                if ($('#txtStart').val().trim() == "") {
                    alert('Start date required');
                    return;
                }
                if ($('#chkIsFullDay').is(':checked') == false && $('#txtEnd').val().trim() == "") {
                    alert('End date required');
                    return;
                }
                else {
                    var startDate = moment($('#txtStart').val(), "DD/MM/YYYY HH:mm A").toDate();
                    var endDate = moment($('#txtEnd').val(), "DD/MM/YYYY HH:mm A").toDate();
                    if (startDate > endDate) {
                        alert('Invalid end date');
                        return;
                    }
                }

                var data = {
                    EventID: $('#hdEventID').val(),
                    Subject: $('#txtSubject').val().trim(),
                    Start: $('#txtStart').val().trim(),
                    End: $('#chkIsFullDay').is(':checked') ? null : $('#txtEnd').val().trim(),
                    Description: $('#txtDescription').val(),
                    ThemeColor: $('#ddThemeColor').val(),
                    IsFullDay: $('#chkIsFullDay').is(':checked')
                }
                SaveEvent(data);
                // call function for submit data to the server
            })

            function SaveEvent(data) {
                $.ajax({
                    type: "POST",
                    url: '/Calendar/SaveEvent',
                    data: data,
                    success: function (data) {
                        if (data.status) {
                            //Refresh the calender
                            FetchEventAndRenderCalendar();
                            $('#myModalSave').modal('hide');
                        }
                    },
                    error: function () {
                        alert('Failed');
                    }
                })
            }
        });
   
</script>

    <script type="text/javascript">
     function openModalNews(id)
    {    
         $("#myModalNews"+id).modal();
    //$.ajax({
    //            type: "POST",
    //            url: "Default.aspx/NumberOfHit",
    //            data: "{topicid:'" + topicid + "'}",
    //            contentType: "application/json;charset=utf-8 ",
    //            dataType: "json",
    //            success: function (response) {
    //               // alert(response.d);
    //            },
    //            failure: function (response) {
    //                alert(response.d);
    //            },
    //            error: function (response) {
    //                alert(response.d);
    //            }

    //        });

    }
    
   </script>
</asp:Content>

