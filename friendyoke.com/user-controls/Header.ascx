<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Design_Header" %>
<link href="Style.css" rel="stylesheet" type="text/css" />
  <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>       
 
      
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
      

<script type="text/javascript">

    function goto(locationa) {
        var root = location.protocol + '//' + location.host;
        window.location = root  + "/friendyoke.com/"+ locationa;
    }


</script>

 
      <telerik:RadFormDecorator runat="server" ID="decorate" 
    DecoratedControls="Buttons" Skin="Default" Width="194px" />  
    
<asp:Panel style='position:absolute;top:-21px;height:83px;' ID="somw" runat="server" Height="83px" Width="984px" BackImageUrl="~/Images/header.png">
<br />
    <div>
    <table>
    <tr>
    <td>
    <div style="position:relative;top: -5px; left:5px;">
    <telerik:RadBinaryImage runat="server" ID="propic" Height="55px" Width="55px" ResizeMode="Crop" />
    
        </div>
    </td>
    <td>
      <div style="position:relative;top: -5px; left:5px;">
        <asp:Image ID="Image2" runat="server" Height="55px"  Width="55px"
            ImageUrl="~/Images/website/1232.png" /></div>

    <div style=" display:none; position:relative;left:5px;">
    


    <span style="font-family:Arial Rounded MT Bold; font-size:23px;">
    <asp:LinkButton
        ID="LinkButton1" runat="server" ForeColor="Black" PostBackUrl="~/Default.aspx" CssClass="someclasslink">Friendyoke</asp:LinkButton>
    
    </span></div>
    
    </td>
        <telerik:RadToolTipManager runat="server" ID="RadToolTipManager1" Position="BottomCenter"
        RelativeTo="Element" Width="400px" Height="200px" Animation="Resize" HideEvent="LeaveTargetAndToolTip"
        Skin="Default" OnAjaxUpdate="OnAjaxUpdate" EnableShadow="true"
        RenderInPageRoot="true" AnimationDuration="200" ShowEvent="OnMouseOver">
        <TargetControls>
        <telerik:ToolTipTargetControl  IsClientID="true" TargetControlID="Button1" Value="Vaibhav" /></TargetControls>
    </telerik:RadToolTipManager>
    <td valign="top" style="text-align:right; vertical-align:middle; height:60px; width:790px;">
     

    <telerik:RadToolBar EnableRoundedCorners="True" EnableShadows="True" 
            ID="RadToolBar1" Runat="server" CssClass="heloo" 
        Skin="Windows7" onbuttonclick="click">
        <Items>
            <telerik:RadToolBarButton runat="server" ID="Button1" Text="0"  PostBack="false" ImageUrl="~/Images/nfeed.png">
               
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server" ImageUrl="~/Images/pricon.png">
           </telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Owner="RadToolBar1">
                <ItemTemplate>
                    Search People:
                </ItemTemplate>
            </telerik:RadToolBarButton>
            
            <telerik:RadToolBarButton CommandName="search" Owner="RadToolBar1">
                <ItemTemplate>
                    <telerik:RadComboBox ID="Search_People" runat="server" AutoPostBack="true" 
                        DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" 
                        DropDownWidth="290px" EnableAutomaticLoadOnDemand="true" 
                        EnableVirtualScrolling="true" Height="190px" HighlightTemplatedItems="True" 
                        ItemsPerRequest="4" MarkFirstMatch="true" MaxHeight="240px" 
                        onselectedindexchanged="RadComboBox2_SelectedIndexChanged" 
                        ShowMoreResultsBox="true" Width="175px" Skin="Office2007">
                        <HeaderTemplate>
                            <ul>
                                <li class="col1">Photo</li>
                                <li class="col2">Name</li>
                            </ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <ul>
                                <li class="col1">
                                    <telerik:RadBinaryImage ResizeMode="Crop" DataValue='<%#Eval("Image") is DBNull ? null : Eval("Image")%>' ID="Image1" runat="server" Height="50px" 
                                         Width="50px" />
                                </li>
                                <li class="col2"><%# DataBinder.Eval(Container.DataItem, "Name") %></li>
                                <li style="visibility:hidden;">
                                    <asp:Label ID="ID" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                                         </asp:Label>
                                </li>
                            </ul>
                        </ItemTemplate>
                    </telerik:RadComboBox>
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton runat="server" 
                NavigateUrl="~/Friends/Default.aspx" ImageUrl="~/Images/stepfinal2.png" Text="Connects" ToolTip="Connects">
            </telerik:RadToolBarButton>
             <telerik:RadToolBarButton runat="server" 
                 ImageUrl="~/Images/Settings.png" Text="Settings" ToolTip="Settings">
            </telerik:RadToolBarButton>

            <telerik:RadToolBarButton runat="server" CommandName="logout" Text="Log Out"  
                ImageUrl="~/Images/logicon.png">
            
            </telerik:RadToolBarButton>
             
            
        </Items>
    </telerik:RadToolBar>
    </td>
    </tr>
    
    </table>
    
    
        
                    
</asp:Panel>



<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:maindb1ConnectionString %>" 
    SelectCommand="SELECT     [User].Name, [User].ID, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     (Propic.[Current] = 1)
ORDER BY [User].Name"></asp:SqlDataSource>
