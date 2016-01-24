<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photo.ascx.cs" Inherits="Newsfeed_Photo" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <style type="text/css">
 
   .RadUpload input.ruFakeInput
        {
            display: none;
        }
        .RadUpload input.ruBrowse
        {
            width: 115px;
        } 
        .RadUpload span.ruFileWrap input.ruButtonHover
        {
            background-position: 100% -46px;
        }
        .RadUpload input.ruButton
        {
            background-position: 0 -46px;
        }
        .relative1
        {
            top:-27px;
            left:125px;
            }
            .relative2
         {top:-27px;
             left:125px;
             }
 </style>
 
 <asp:Panel ID="llooader" runat="server">
 </asp:Panel>
 <telerik:RadAsyncUpload ID="justadd" runat="server" 
    onfileuploaded="justadd_FileUploaded"  MaxFileInputsCount="1"  AllowedFileExtensions="jpeg,jpg,gif,png,bmp" >
<Localization Select="Just Add Photo"/>
     
</telerik:RadAsyncUpload>
 
<telerik:RadButton ID="createalbum" runat="server" Text="Create new Album" 
    Icon-PrimaryIconUrl="~/Images/website/add2al.png" CssClass="relative1" 
    onclick="createalbum_Click">
</telerik:RadButton>
<telerik:RadButton ID="addtoalbum" runat="server" 
    Text="Add to already added Album" 
    Icon-PrimaryIconUrl="~/Images/website/album.png" CssClass="relative2" 
    onclick="addtoalbum_Click">
</telerik:RadButton>














 <br />
<asp:Button ID="post" runat="server" Text="Post" CssClass="Submit" 
    onclick="post_Click" />















 