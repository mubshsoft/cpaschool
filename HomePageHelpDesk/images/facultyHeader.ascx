<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FacultyHeader.ascx.vb" Inherits="FacultyHeader" %>

  <style type="text/css">
        .menuItem
        {
            font-family: Tahoma, Verdana, Arial, Helvetica, sans-serif;
            color: #ffffff;
            border: 1px solid gray;
            background-color: #13a1d3;
            padding: 1px 1px 1px 1px;
            height: 15px;
            font-weight:normal;
            border-spacing: 2px;
            width:116px;
            text-align:center;
            font-size:11px;
        }
        .menuHover
        {
            color: #000000;
            border: 1px Solid gray;
          background-color:#13a1d3;
            padding: 1px 1px 1px 1px;
            text-decoration: none;
            height: 15px;
            border-spacing: 2px;
            font-family: Tahoma, Verdana, Arial, Helvetica, sans-serif;
             width:116px;
                 text-align:center;
                 font-size:11px;
         
        }
        
        
        .dynamicItem
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            
           
            color: #806000;
            background-color: #13a1d3;
            padding: 4px 5px 4px 5px;
            height: 25px;
            border-spacing: 2px;
              font-weight: bold;
        }
        
        .dynamicItemNew
        {
            font-family: Tahoma, Verdana, Arial, Helvetica, sans-serif;            
            color:#ffffff;            
            background-color: #13a1d3;
          
            padding: 1px 1px 1px 1px;
            height: 15px;
            font-weight:bold;
            border-spacing: 2px;
            width:116px;
            text-align:left;
            font-size:11px;
        }
        
        
        .hoverdynamicItemNew
        {
            font-family: Tahoma, Verdana, Arial, Helvetica, sans-serif;
            color: #000000;            
            background-color: #13a1d3;
          
            padding: 1px 1px 1px 1px;
            height: 15px;
            font-weight:bold;
            border-spacing: 2px;
            width:116px;
            text-align:left;
            font-size:11px;
        }

    </style>
      <style type="text/css"> 
           .IE8Fix  
           {   z-index: 100; }    </style>
<table>
   <tr>
                            <td height="91" align="left" valign="bottom" >&nbsp;
                           <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="../../download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0"
                                    width="703" height="91">
                                    <param name="movie" value="../images/menu_top.swf">
                                    <param name="quality" value="high">
                                    <param name="menu" value="false">
                                    <!--[if !IE]> <-->
                                    <object data="../images/menu_top.swf" width="703" height="91" type="application/x-shockwave-flash">
                                        <param name="quality" value="high">
                                        <param name="menu" value="false">
                                        <param name="pluginurl" value="../../www.macromedia.com/go/getflashplayer">
                                        FAIL (the browser should render some flash content, not this).
                                    </object>
                                    <!--> <![endif]-->
                                </object>


                            </td>
                        </tr>
                       
                        <tr>
                            <td height="27" align="left" valign="bottom" >
                               <asp:Menu ID="Menu1" runat="server" 
                             Orientation="Horizontal"  StaticEnableDefaultPopOutImage="false"                                                        
                                                         DynamicEnableDefaultPopOutImage="false" 
                                                            DynamicMenuItemStyle-CssClass="dynamicItemNew"
                                                            DynamicMenuStyle-CssClass="IE8Fix"
                                                         DynamicHoverStyle-CssClass="hoverdynamicItemNew"
                                                              StaticHoverStyle-CssClass="menuHover"  
                                                             StaticMenuItemStyle-CssClass="menuItem" DynamicHorizontalOffset="2" DynamicVerticalOffset="1" BackColor="#13a1d3"   DynamicMenuStyle-BackColor="#13a1d3"  DynamicMenuStyle-bordercolor="#000000" DynamicMenuStyle-borderwidth="1px" DynamicMenuStyle-borderstyle="Groove"   Width="701px"  >
                                                            <StaticItemTemplate>
                                                               
                                                                <b>
                                    <%# Eval("Text") %></b>
                                                            </StaticItemTemplate>
                                                            <DynamicItemTemplate>
                                                                
                                <%# Eval("Text") %>
                                                            </DynamicItemTemplate>
                                                        </asp:Menu>








                            </td>
                        </tr>                        
</table>