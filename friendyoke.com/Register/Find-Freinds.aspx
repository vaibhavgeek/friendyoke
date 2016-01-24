<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Find-Freinds.aspx.cs" Debug="true" Inherits="Register_Find_Freinds" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<%@ Register src="../user-controls/footer.ascx" tagname="footer" tagprefix="uc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
          
	
        
        <link rel="stylesheet" type="text/css" href="../lib/style.css"/>
</head>
<body class="body">
   <div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>

    <form id="form1" runat="server"  >


   <telerik:RadFormDecorator runat="server" ID="decorate" 
    DecoratedControls="Buttons" Skin="Default" Width="194px" />
    <table style="margin: auto;">
    <tr>
    <td colspan="2">
      <div style="height:70px;">  
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
                 Enabled="false" >
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server"  Text="Step 2 &gt; Complete Your Profile" 
                Value="3"  Enabled="false">
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server"  Text="Step 3 &gt; Find Friends" Value="4" Selected="true"  >
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server" Text="Stpe 4 &gt; Start yoking " Enabled="false" >
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
    &nbsp;<div>
           
    
       
       <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
       </telerik:RadScriptManager>
         
                   
    <asp:Panel  CssClass="somesignup" ID="some" runat="server" 
                BackColor="White" Width="980px" >
                <div style="padding-left:25px; padding-right:35px;"><center>        
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Windows7" 
                        MultiPageID="RadMultiPage1" SelectedIndex="1">
                        <Tabs>
                            <telerik:RadTab runat="server" Text="gmail" Width="400px">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="facebook" Width="400px" Selected="True" >
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    </center>
                    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" 
                        SelectedIndex="1">
            <telerik:RadPageView ID="RadPageView1" runat="server">
                <table>
                
                <tr>
                <td>
                 <b>Email Address : </b>
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                
                </td>
                <td>
                <b>Password : </b>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TabIndex="1" TextMode="Password"></asp:TextBox>
                
                </td>

                
               
                </tr>
                
                </table>
    <asp:Button ID="btnContacts" runat="server" onclick="btnContacts_Click" 
            TabIndex="2" Text="Find Friends" Width="125px" />
       
       
        
       
        <br />
        <b>Contacts:<br />
        </b>
         <telerik:RadListBox
        runat="server" ID="RadListBoxSource"
        Height="300px" Width="300px"
        AllowTransfer="true" TransferToID="RadListBoxDestination" Skin="Office2007">
        
    </telerik:RadListBox>
    
        
    
    <telerik:RadListBox
        runat="server" ID="RadListBoxDestination"
        Height="300px" Width="300px" Skin="Office2007" />
        <br />
        Add contacts to the left pane if u want to send them invite to join on friendyoke.com
      <div style=" float:right;">  <asp:Button ID="Button1" runat="server" 
              CssClass="Submit" Text="Send Invites" onclick="Button1_Click" /></div>

   
            </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" Height="400px" runat="server">
                       

    <div class="fb-send" data-href="http://www.vaibhavgeek.blogspot.com/" data-font="arial"></div>
                        </telerik:RadPageView>
                        
        </telerik:RadMultiPage><br />
        <div style=" float:right; padding-right:15px;">
        <telerik:RadButton ID="Button2" NavigateUrl="~/Register/Yoking.aspx"  ButtonType="LinkButton" runat="server" Text="Skip this Step" 
                 ></telerik:RadButton></div>
</div>
                </asp:Panel>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="some">
                                </asp:RoundedCornersExtender>
         
                   
</div>       
    </td>
    </tr>
    <tr>
    <td valign="top" class="style1" colspan="2">
        
        </td>
    </tr>
    <tr>
    <td colspan="2">
        <uc1:footer ID="footer1" runat="server" />
        </td>
    </tr>
    </table> </form>
    </body>
   
    
    
</html>
