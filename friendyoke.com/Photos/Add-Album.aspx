<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="Add-Album.aspx.cs" Inherits="Photos_Add_Album" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Album</title>
    <link rel="stylesheet" type="text/css" href="../lib/style.css"/>
    <style type="text/css" >
     .tbber
     {
         height:55px;
         
         }
         
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
   

        Name Of The Album :<br /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
   <br /><telerik:RadProgressManager runat="server" ID="RadProgressManager1" />
 <telerik:RadProgressArea runat="server" ID="RadProgressArea1" Skin="Office2007">
        </telerik:RadProgressArea>
   Select Photos: <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" 
    onfileuploaded="justadd_FileUploaded" InputSize="27" MultipleFileSelection="Automatic" AllowedFileExtensions="jpeg,jpg,gif,png,bmp" 
                             >
     
</telerik:RadAsyncUpload>

        Describe Album :<br />
           <asp:TextBox runat="server" CssClass="tbber" style="-webkit-border-radius: 6px;" ID="maincontent" 
    TextMode="MultiLine" Width="450px"></asp:TextBox>  <br /> 
       <telerik:RadButton ID="postfeed" runat="server" Text="Post" Skin="Default" Width="80px" 
                         onclick="postfeed_Click">
       </telerik:RadButton>     
    </div>
    
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    
    </form>
</body>
</html>
