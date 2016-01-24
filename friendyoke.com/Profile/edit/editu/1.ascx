<%@ Control Language="C#" AutoEventWireup="true" Debug="true" CodeFile="1.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>




 <div style="padding-left:15px;padding-right:15px;">
 
 
 
  <h2 class="mainheader">Change Mimage
     </h2>
                <br />
    Mimage is a photo which best defines you.Choose wisely :)

    
     
     
    <div>
        
        
             <div id="something" runat="server" style="width:525px;">
       <center>
       
           
            <telerik:RadBinaryImage runat="server" Width="525px" ResizeMode="Fit"
            ID="Thumbnail" AlternateText="Thumbnail" CssClass="mimagecss" 
                  />
               
               
               
               
               
               
               
               </center>
              
            <asp:Image runat="server" ID="p1" CssClass="profileimager" ImageUrl="~/Images/pro-pic-try.jpg" Width="80px" style="left:20px;"/>
              <asp:Image runat="server" ID="p2" CssClass="profileimager" ImageUrl="~/Profile/images/sample.jpg" Width="80px" style="left:35px;"/>
              <asp:Image runat="server" ID="p3" CssClass="profileimager" ImageUrl="~/Profile/images/3.jpg" Width="80px" style="left:50px;"/>
              <asp:Image runat="server" ID="p4" CssClass="profileimager" ImageUrl="~/Profile/images/2.jpg" Width="80px" style="left:65px;"/>
              <asp:Image runat="server" ID="p5" CssClass="profileimager" ImageUrl="~/Profile/images/sample.jpg" Width="80px" style="left:80px;"/>
              </div> 
        
        <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MaxFileInputsCount="1"
            AllowedFileExtensions="jpeg,jpg,gif,png,bmp" 
            onfileuploaded="AsyncUpload1_FileUploaded" Height="25px" Width="522px">
            
        </telerik:RadAsyncUpload>
        
        
        
        
<div style="float:right;">
    <asp:Button ID="Button1" runat="server" 
                Text="Change Mimage" CssClass="Submit" 
                onclick="Button1_Click"/> </div>
    </div>
    </div>