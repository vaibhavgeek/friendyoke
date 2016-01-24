<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cpp.aspx.cs" Inherits="Profile_profilec_pro_pic_change" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .twittertypebutp2
{background-color: #FD9A0F;
background-repeat: repeat-x;
    display: inline-block;
    overflow: visible;
    padding: 5px 10px;
    font-size: 13px;
    font-weight: bold;
    line-height: 18px;
    color: #333;
    text-shadow: 0 1px 0 rgba(255, 255, 255, .5);
    background-color: #CCC;
    background-repeat: no-repeat;
    border: 1px solid #CCC;
    cursor: pointer;
    -webkit-border-radius: 4px;
    -moz-border-radius: 4px;
    -webkit-box-shadow: 0 1px 0 rgba(255, 255, 255, .5);
    -moz-box-shadow: 0 1px 0 rgba(255, 255, 255, .5);
    box-shadow: 0 1px 0 rgba(255, 255, 255, .5);
    background-image: linear-gradient(top,#FEE94F 0,#FD9A0F 100%);
}
    
.twittertypebutp2:hover  {  
    background-color: #FD9512;
background-repeat: repeat-x;
    border-color: #EC8B11;
    background-image: linear-gradient(top,#FEDC4D 0,#FD9512 100%);
}
    .twittertypebut
    {
        padding-top: 5px; 
        padding-right: 10px; 
        padding-bottom: 5px; 
        padding-left: 10px; 
        margin-top: 0px;
         margin-right: 0px;
          margin-bottom: 0px; 
          margin-left: 0px;
           border-top-width: 1px; 
           border-right-width: 1px;
            border-bottom-width: 1px;
             border-left-width: 1px;
              border-style: initial; 
              border-color: initial; 
              border-image: initial;
               font-size: 13px !important; 
               font: inherit; 
               vertical-align: baseline; 
               font-family: HelveticaNeue, 'Helvetica Neue', Helvetica, Arial, sans-serif; 
               font-style: normal; 
               font-variant: normal; 
               font-weight: bold; 
               line-height: 18px;
                position: relative;
                 display: inline-block;
                  overflow-x: visible; 
                  overflow-y: visible; 
                  color: rgb(255, 255, 255);
                   text-shadow: rgba(0, 0, 0, 0.246094) 0px -1px 0px; 
                   background-color: rgb(1, 154, 210); 
                   border-top-style: solid; 
                   border-right-style: solid; 
                   border-bottom-style: solid;
                    border-left-style: solid;
                     border-top-color: rgb(5, 126, 208); 
                     border-right-color: rgb(5, 126, 208); 
                     border-bottom-color: rgb(5, 126, 208); 
                     border-left-color: rgb(5, 126, 208); 
                     cursor: pointer;
                      border-top-left-radius: 4px;
                       border-top-right-radius: 4px; 
                       border-bottom-right-radius: 4px; 
                       border-bottom-left-radius: 4px; 
                       -webkit-box-shadow: rgba(255, 255, 255, 0.0976563) 0px 1px 0px inset; 
                       box-shadow: rgba(255, 255, 255, 0.0976563) 0px 1px 0px inset; 
                       background-image: -webkit-linear-gradient(top, rgb(51, 188, 239), rgb(1, 154, 210));
                        background-repeat: repeat no-repeat;
        
        }
.twittertypebut:hover
{
   background-color: #0271BF;
background-repeat: repeat-x;

background-image: -webkit-linear-gradient(#2DADDC,#0271BF);



border-color: #096EB3;
 }
    
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <script type="text/javascript">

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog      
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow; //IE (and Moz as well)      
            return oWindow;
        }

        function Close() {
            GetRadWindow().Close();
        }  
      
    </script>

        
        
             <div id="something" runat="server">
      
       <div style="float:right;">  <asp:Button ID="Button2" CssClass="twittertypebutp2" runat="server" Text="Close" OnClientClick="Close();return false;" />
                 </div>
           <center>
            <telerik:RadBinaryImage runat="server" Width="150px" Height="150px" ResizeMode="Crop"
            ID="Thumbnail"  
                  /></center>
               
               
               
               
               
               
            
               <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
               
               
               
               
               
               
            
               
              
              </div> 
         <telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MaxFileInputsCount="1"
            AllowedFileExtensions="jpeg,jpg,gif,png,bmp" 
            onfileuploaded="AsyncUpload1_FileUploaded" Height="25px" Width="170px">
            
        </telerik:RadAsyncUpload>
        
        
        
        
        
<div style="float:right;">
    <asp:Button ID="Button1" runat="server" 
                Text="Change Profile Picture" CssClass="twittertypebut" 
                onclick="Button1_Click"/> </div>
    
    </form>
</body>
</html>
