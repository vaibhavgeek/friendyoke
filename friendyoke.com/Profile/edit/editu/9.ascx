<%@ Control Language="C#" AutoEventWireup="true" CodeFile="9.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<div style="padding-left:15px;padding-right:15px;">
 
 
 
  <h2 class="mainheader">Change Profile Picture
     </h2>
                <br />
  

    
     
     
    <div>
        
        
             <div id="something" runat="server" style="width:525px;">
       <center>
       
           
            <telerik:RadBinaryImage runat="server" Width="525px" ResizeMode="Fit"
            ID="Thumbnail" AlternateText="Thumbnail" CssClass="mimagecss" 
                  />
               
               
               
               
               
               
            
               </center>
              
              </div> 
        <center>   <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MaxFileInputsCount="1"
            AllowedFileExtensions="jpeg,jpg,gif,png,bmp" 
            onfileuploaded="AsyncUpload1_FileUploaded" Height="25px" Width="522px">
            
        </telerik:RadAsyncUpload></center>
        
        
        
        
        
<div style="float:right;">
    <asp:Button ID="Button1" runat="server" 
                Text="Change Mimage" CssClass="Submit" 
                onclick="Button1_Click"/> </div>
    </div>
    </div>