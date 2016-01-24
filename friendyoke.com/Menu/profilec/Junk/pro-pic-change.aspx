<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pro-pic-change.aspx.cs" Inherits="Profile_profilec_pro_pic_change" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../profile.css"/>
    <link rel="stylesheet" type="text/css" href="../../lib/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    

<div>
 
 
 
  <h2 class="mainheader">Change Profile Picture
     </h2>
                <br />
  

    
     
     
    <div>
        
        
             <div id="something" runat="server">
      
       
           
            <telerik:RadBinaryImage runat="server" Width="180px" Height="350px" ResizeMode="Crop"
            ID="Thumbnail" AlternateText="Thumbnail" CssClass="mimagecss" 
                  />
               
               
               
               
               
               
            
               <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
               
               
               
               
               
               
            
               
              
              </div> 
         <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MaxFileInputsCount="1"
            AllowedFileExtensions="jpeg,jpg,gif,png,bmp" 
            onfileuploaded="AsyncUpload1_FileUploaded" Height="25px" Width="170px">
            
        </telerik:RadAsyncUpload>
        
        
        
        
        
<div style="float:right;">
    <asp:Button ID="Button1" runat="server" 
                Text="Change Profile Picture" CssClass="Submit" 
                onclick="Button1_Click"/> </div>
    </div>
    </div>
    </form>
</body>
</html>
