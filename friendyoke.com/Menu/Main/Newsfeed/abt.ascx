<%@ Control Language="C#" AutoEventWireup="true" CodeFile="abt.ascx.cs" Inherits="fy.about" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
  

  <link rel="stylesheet" type="text/css" href="lib/Style.css"/>

<div style="overflow:auto; height:550px;" id="tobescrolled">


                   <telerik:RadTextBox ID="ptb" runat="server"  TextMode="MultiLine"
        EmptyMessage="Click to comment on the post.." Height="25px" Width="350px" 
       >
                    </telerik:RadTextBox>
                    <asp:Button ID="Post" runat="server" Text="Post"  
        CssClass="commentpost" onclick="Post_Click">
                        </asp:Button>
                    <asp:PlaceHolder runat="server" ID="emptypanel" >

</asp:PlaceHolder>
                  
</div> 