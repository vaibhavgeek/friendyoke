<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Yoking.aspx.cs" Inherits="Register_oking" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../user-controls/footer.ascx" tagname="footer" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <link rel="stylesheet" type="text/css" href="register.css"/>
  <link rel="stylesheet" type="text/css" href="../lib/style.css"/>
  
</head>
<body class="body">
    <form id="form1" runat="server"  >
    
   <telerik:RadFormDecorator runat="server" ID="decorate" 
    DecoratedControls="Buttons" Skin="Default" Width="194px" />
    <table style="margin: auto;">
    <tr>
    <td colspan="2">
      <div style="height:49px;">  
<asp:Panel  ID="somw" runat="server" style='position:absolute;left:13px;
top:-21px;width:984px;height:83px' Height="83px" Width="984px" BackImageUrl="~/Images/header.png">
<br />
    <div >
    <table>
    <tr>
    <td>
    <div style="position:relative; top: -10px; left: 11px;"><h3 style="font-family:Vivaldi; font-size:22px;"><b>Friendyoke</b></h3> </div>
    </td>
    
    <td style="text-align:right; width:790px;">
      
   
<telerik:RadMenu ID="RadMenu1" Runat="server" Skin="Forest" 
                  style="top: 5px; left: 106px">
        <Items>
            <telerik:RadMenuItem runat="server" Text="Step1 &gt; Enter Basic Information" 
                Enabled="false" Value="1" >
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server"  Text="Step 2 &gt; Complete Your Profile" 
                Value="3" Enabled="false">
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server"  Text="Step 3 &gt; Find Friends" Value="4" Enabled="false">
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server" Text="Stpe 4 &gt; Start yoking "  Selected="true">
            </telerik:RadMenuItem>
        </Items>
    </telerik:RadMenu>
       </td>
    </tr>
    
    </table>
        
    </div>
        
          </asp:Panel>
        </div>
    
        
          
</td>
    </tr>
    <tr>
    <td valign="top" class="style1">
    
   
    <br />   
        <br />
       
        
        <br />
        </td>
    <td valign="top">
   <br />
        <div>
           
    
       
       <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
       </telerik:RadScriptManager>
         
                   
    <asp:Panel  CssClass="somesignup" ID="some" runat="server" 
                BackColor="White" Width="980px"  >
                
  <div style="padding-left:25px; padding-right:15px;">
    
                <h2>You Need Step 4 Also??!!</h2>
                <p style="color: rgb(51, 51, 51); font-family: Arial, serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 22px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none; ">
                   Browse-ahead friendyoke.com .If you need any assistant in browsing our website go straight to <a href="help.friendyoke.com">help at Friendyoke.com</a>
                   A click to take you to your own website!!
                   Here are the list of things which we differ from social networking websites such as facebook and google plus , hope u have a good time aboard with us ..:)
                    </p><br />
                    <p style="float:right;">
                    <asp:Button ID="Button1" NavigateUrl="~/Default.aspx" runat="server" 
                            Text="Start Yoking" CssClass="twittertypebutp2" onclick="Button1_Click" />
                </p></div>
        
                
                </asp:Panel>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="some">
                                </asp:RoundedCornersExtender>
         
                   
</div>       
    </td>
    </tr>
    <tr>
    <td valign="top" class="style1" colspan="2"></td>
    </tr>
    <tr>
    <td colspan="2">
        <uc1:footer ID="footer1" runat="server" />
        </td>
    </tr>
    </table> </form>
    </body>
</html>
