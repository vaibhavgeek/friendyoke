<%@ Control Language="C#" AutoEventWireup="true" CodeFile="account-settings.ascx.cs" Inherits="Menu_settings_account_settings" %>
<asp:Panel  CssClass="sidemeyaaarright" runat="server" ID="settings">

<style type="text/css">
#settings .td
{
    border-bottom-style: dotted; border-width:thin; border-color: #800000;
}
</style>


<table style="width:100%;">
    <tr>
        <td class="td">
            <h3>change password</h3>    
            current password&nbsp;&nbsp;&nbsp;&nbsp; : <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" Width="">
                                        </asp:TextBox> <br />
                                          enter new  password : <asp:TextBox ID="TextBox1" TextMode="Password" runat="server" Width="">
                                        </asp:TextBox>
                                         confirm new password : <asp:TextBox ID="TextBox3" TextMode="Password" runat="server" Width="">
                                        </asp:TextBox>
                                        <div style="float:right; padding-right:25px;">
                                         <asp:Button ID="Button1" CssClass="twittertypebut" runat="server" Text="save password" 
        /></div>
                                          </td>
    </tr>
    <tr>
        <td>
         <h3>primary account information</h3> 
            username :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server" Width="">
                                        </asp:TextBox>  <br />

                                       email address:  <asp:TextBox ID="TextBox5" runat="server" Width="">
                                        </asp:TextBox>  <br />
         </td>
       
    </tr>

    
   
    <tr>
       <td>
         <h3>social mdia authentication</h3> 
        <asp:Button ID="Button2" CssClass="facebook" runat="server" 
        Text="remove facebook authentication" />
         </td>
    </tr>
    <tr>
        <td  class="td">
            &nbsp;</td>
        <td  class="td">
            &nbsp;</td>
    </tr>
    <tr>
        <td  class="td">
            &nbsp;</td>
        <td  class="td">
            &nbsp;</td>
    </tr>
    <tr>
        <td  class="td">
            &nbsp;</td>
        <td  class="td">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="td">
            &nbsp;</td>
        <td  class="td">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="td">
            &nbsp;</td>
        <td  class="td">
            &nbsp;</td>
    </tr>
</table>

</asp:Panel>