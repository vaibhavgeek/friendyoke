<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="Default.aspx.cs" Inherits="fy.Default2" %>
<%@ Register src="user-controls/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="user-controls/footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="lib/style.css"/>
      <script type="text/javascript" src="lib/jquery/jquery.js"></script>
</head>

<body class="body" id="home">



    <script type="text/javascript">
       

            if (screen.width <= 1024) 

           

            $('head').append('<link rel="stylesheet" href="lib/style1024.css" type="text/css" />');  
               
            
        else 
           
            $('head').append('<link rel="stylesheet" href="lib/mstyle1024.css" type="text/css" />');
              
               
               
               
            
      

        
    </script>
    
    <form id="form1" runat="server">
   

    <telerik:RadCodeBlock ID="RadCodeBlock" runat="server">
			<script type="text/javascript">

			    function onTabSelecting(sender, args) {
			        if (args.get_tab().get_pageViewID()) {
			            args.get_tab().set_postBack(false);
			            
			        }
			    }
            
        </script>
        
		</telerik:RadCodeBlock>

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        
        </telerik:RadScriptManager>

      <telerik:RadToolTipManager runat="server" ID="RadToolTipManager1" Position="BottomCenter"
        RelativeTo="Element" Width="800px" Height="600px" Animation="Slide" HideEvent="LeaveTargetAndToolTip"
        Skin="Default" OnAjaxUpdate="OnAjaxUpdate"  OffsetY="-50"
        RenderInPageRoot="true" AnimationDuration="200" ShowEvent="OnClick" OffsetX="180">
        <TargetControls>
        <telerik:ToolTipTargetControl  IsClientID="true" TargetControlID="notifi" Value="notifi" /></TargetControls>
    </telerik:RadToolTipManager>
    <table style="margin: auto;">
    <tr>
    <td  style="height: 71px;"  valign="top">
   
  
       <div  id="Navbanner">

  
   
    <ul id="Nav">

	<h4>
    <table>
    <tr>
    <td>
 <telerik:RadTabStrip ID="RadTabStrip2"  runat="server" EnableEmbeddedSkins="False" SelectedIndex="2" 
             >
     <Tabs>
         <telerik:RadTab runat="server" CssClass="menutem" Width="340px">
         <TabTemplate>
         search :<telerik:RadComboBox ID="Search_People" runat="server" AutoPostBack="true" 
                        DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID" 
                        DropDownWidth="290px" EnableAutomaticLoadOnDemand="true" 
                        EnableVirtualScrolling="true" Height="190px" HighlightTemplatedItems="True" 
                        ItemsPerRequest="4" MarkFirstMatch="true" MaxHeight="240px" 
                       
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
         
         
         </TabTemplate>
         </telerik:RadTab>
        <telerik:RadTab runat="server" Text="my profile"  Value="profile"
             >
         </telerik:RadTab>
         <telerik:RadTab runat="server" Text="notifications(55)" ID="notifi" Width="220px" Selected="True" 
             >
         </telerik:RadTab>
        
         
        
     </Tabs>
 
 </telerik:RadTabStrip>   
    </td>
   <td>
   <telerik:RadTabStrip  ID="RadTabStrip1" 
                      EnableEmbeddedSkins="false"
				    runat="server" MultiPageID="RadMultiPage1" 
                    OnTabClick="RadTabStrip1_TabClick" OnClientTabSelecting="onTabSelecting">
			    </telerik:RadTabStrip>

                
   </td>
   
   <td>
                 <telerik:RadTabStrip runat="server" ID="try1" EnableEmbeddedSkins="False" 
                     ontabclick="try_TabClick">
                 <Tabs>
                  <telerik:RadTab runat="server" Text="logout" Selected="false">
         </telerik:RadTab>
        
     </Tabs>
 
 </telerik:RadTabStrip>   
 </td> </tr>
    </table>
        

   

        </h4>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:maindb1ConnectionString %>" 
    SelectCommand="SELECT     [User].Name, [User].ID, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     (Propic.[Current] = 1)
ORDER BY [User].Name"></asp:SqlDataSource>
</ul>
 
           
 </div>

        
        
        
 
 </td></tr>
 <tr>
 <td align="left">

 <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" OnPageViewCreated="RadMultiPage1_PageViewCreated">
			    </telerik:RadMultiPage> 
       
 </td>

 

 
 

 
 
 </tr>
 
 </table>
 
    
 
    </form>
</body>

</html>
