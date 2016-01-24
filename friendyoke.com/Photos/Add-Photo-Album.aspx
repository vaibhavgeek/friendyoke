<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add-Photo-Album.aspx.cs" Inherits="Photos_Add_Photo_Album" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Photos to your Album</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" Width="193px" DataTextField="Name" DataValueField="ID">
        </asp:DropDownList><br />
    <telerik:RadProgressManager runat="server" ID="RadProgressManager1" />
 <telerik:RadProgressArea runat="server" ID="RadProgressArea1" Skin="Office2007">
        </telerik:RadProgressArea>
   Select Photos: <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" 
    onfileuploaded="justadd_FileUploaded" InputSize="27" MultipleFileSelection="Automatic" AllowedFileExtensions="jpeg,jpg,gif,png,bmp" 
                             >
     
</telerik:RadAsyncUpload>
<telerik:RadButton ID="postfeed" runat="server" Text="Post" Skin="Default" Width="80px" 
                         onclick="postfeed_Click">
       </telerik:RadButton>
    </div>
    
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    
    </form>
</body>
</html>
