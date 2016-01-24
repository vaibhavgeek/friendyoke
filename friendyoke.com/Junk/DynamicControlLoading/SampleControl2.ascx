<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SampleControl2.ascx.cs" Inherits="SampleControl2" %>
<h1>
    Sample Control2
</h1>
<table border="0" cellpadding="3" cellspacing="0">
    <tbody>
        <tr>
            <td style="text-align:left">
                Name:
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:left">
                City:
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:left">
            </td>
            <td style="text-align:left">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            </td>
        </tr>
    </tbody>
</table>
