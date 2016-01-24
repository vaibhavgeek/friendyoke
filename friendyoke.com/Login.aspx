<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<%@ Register src="user-controls/footer.ascx" tagname="footer" tagprefix="uc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
          <link type="text/css" href="lib/jquery/jquery-ui-1.8.5.custom.css" rel="stylesheet" />	
		
	
        
        <link rel="stylesheet" type="text/css" href="lib/style.css"/>
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
    
    
    <td style="text-align:right; width:790px;">
      
   
       <asp:Login  ID="ctlLogin" runat="server" style="position:relative;top: 5px; float:right;" 
            onauthenticate="OnAuthenticate" onloginerror="Error">
                            <LayoutTemplate>
                                <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                    <tr>
                                        <td>
                                            <table cellpadding="0">
                                                <tr>
                                                    <td valign="middle" align="center">
                                                       <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">email or username:</asp:Label>
                                                    </td>
                                                    <td valign="middle" align="center">
                                                        <asp:TextBox ID="UserName" runat="server" Width="">
                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                            ForeColor="Red" ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td valign="middle" align="center">
                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">password:</asp:Label>
                                                    </td>
                                                    <td valign="middle" align="center">
                                                       <asp:TextBox ID="Password" runat="server" TextMode="Password">
                                        </asp:TextBox><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                                            ForeColor="Red" ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator></td>
                                                    <td valign="middle" align="center">
                                                        
                                                    </td>
                                                    <td valign="bottom" align="center">
                                                       
                                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                                            ValidationGroup="Login1" CssClass="twittertypebut"  />
                                                       
                                                    </td>
                                                    <td valign="middle" align="center" style="color: Red;">
                                                   <asp:Panel ID="invi" runat="server" Visible="false"> 
                                                   <div style="position:absolute;top:72px;left:120px" class="ui-state-error ui-corner-all" > 
         <span class="ui-icon ui-icon-alert" 
             style="float: left; margin-right: .3em;">
            </span><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div> </asp:Panel>   
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:Login></td>
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
    &nbsp;<div>
           
    
       
       <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
       </telerik:RadScriptManager>
         
                   
    <asp:Panel  CssClass="somesignup" ID="some" runat="server" 
                BackColor="White" Width="980px" >
                
                <center>
                <asp:Button ID="joinn" 
                runat="server" CssClass="twittertypebutp2" Text="Sign Up Now !!!" 
                onclick="joinn_Click"  />
                 <br />
                 <div class="sidemeyaaarright">
                <h1>"let's fall in love , again"</h1>
           </div>

            
            
        </center>
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
    
    </table> </form>
    </body>
   
    
    
</html>
