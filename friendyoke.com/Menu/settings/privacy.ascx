<%@ Control Language="C#" AutoEventWireup="true" CodeFile="privacy.ascx.cs" Debug="true" Inherits="Menu_settings_privacy2" %>
<asp:Panel  CssClass="sidemeyaaarright" runat="server" ID="settings">

<style type="text/css">
#settings .td
{
    border-bottom-style: dotted; border-width:thin; border-color: #800000;
}
</style>


<table style="width:100%;">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            public&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; connects</td>
    </tr>

    
    <tr>
        <td class="td">
            posts&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            :</td>
        <td  class="td">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="18px" 
                RepeatDirection="Horizontal" Width="229px">
                <asp:ListItem Text="" Value="0"></asp:ListItem>
                <asp:ListItem Text="" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td  class="td">
            albums/photos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
        <td  class="td">
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" Height="18px" 
                RepeatDirection="Horizontal" Width="229px">
               <asp:ListItem Text="" Value="0"></asp:ListItem>
                <asp:ListItem Text="" Value="1"></asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td  class="td">
            inside-box&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; :</td>
        <td  class="td">
           <asp:RadioButtonList ID="RadioButtonList2" runat="server" Height="18px" 
                RepeatDirection="Horizontal" Width="229px">
                <asp:ListItem Text="" Value="0"></asp:ListItem>
                <asp:ListItem Text="" Value="1"></asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td  class="td">
            info&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
        <td  class="td">
           <asp:RadioButtonList ID="RadioButtonList4" runat="server" Height="18px" 
                RepeatDirection="Horizontal" Width="229px">
               <asp:ListItem Text="" Value="0"></asp:ListItem>
                <asp:ListItem Text="" Value="1"></asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td  class="td">
            connections &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
        </td>
        <td  class="td">
           <asp:RadioButtonList ID="RadioButtonList5" runat="server" Height="18px" 
                RepeatDirection="Horizontal" Width="229px">
               <asp:ListItem Text="" Value="0"></asp:ListItem>
                <asp:ListItem Text="" Value="1"></asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td class="td">
            allow messages&nbsp;&nbsp;&nbsp;&nbsp; :</td>
        <td  class="td">
            <asp:RadioButtonList ID="RadioButtonList6" runat="server" Height="18px" 
                RepeatDirection="Horizontal" Width="229px">
                <asp:ListItem Text="" Value="0"></asp:ListItem>
                <asp:ListItem Text="" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="td">
            ask to connect&nbsp;&nbsp;&nbsp; &nbsp; :</td>
        <td  class="td">
            <asp:RadioButtonList ID="RadioButtonList7" runat="server" Height="18px" 
                RepeatDirection="Horizontal" Width="229px">
                <asp:ListItem Text="" Value="0"></asp:ListItem>
                <asp:ListItem Text="" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>

</asp:Panel>
<div style="float:right; padding-right:25px;">
<asp:Button ID="Button1" CssClass="twittertypebut" runat="server" Text="save" 
        onclick="Button1_Click" />
<asp:Button ID="Button2" CssClass="twittertypebutp2" runat="server" 
        Text="load saved settings" onclick="Button2_Click" />
</div>
