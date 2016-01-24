<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="profile.aspx.cs" Inherits="Menu_profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../lib/style.css"/>
    <script type="text/javascript" src="../lib/jquery/jquery.js"></script>
    
</head>
<body class="body">
    <form id="form1" runat="server">
    <script type="text/javascript">


        if (screen.width <= 1024)



            $('head').append('<link rel="stylesheet" href="../lib/style1024.css" type="text/css" />');


        else

            $('head').append('<link rel="stylesheet" href="../lib/mstyle1024.css" type="text/css" />');

       
            
      

        
    </script>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        
        </telerik:RadScriptManager>
    <telerik:RadToolTipManager runat="server" ID="RadToolTipManager1" Position="BottomCenter"
        RelativeTo="Element" Width="800px" Height="600px" Animation="Slide" HideEvent="LeaveTargetAndToolTip"
        Skin="Default" OnAjaxUpdate="OnAjaxUpdate"  
        RenderInPageRoot="true" AnimationDuration="200" ShowEvent="OnClick">
        
        <TargetControls>
        <telerik:ToolTipTargetControl  IsClientID="true" TargetControlID="notifi" Value="notifi" /></TargetControls>
    </telerik:RadToolTipManager>


    <telerik:RadToolTipManager runat="server" ID="RadToolTipManager2" Position="MiddleLeft"
        RelativeTo="Element" Width="800px" Height="160px" Animation="Slide" HideEvent="LeaveTargetAndToolTip"
        Skin="Default" OnAjaxUpdate="OnAjaxUpdate"   OffsetY="50"
        RenderInPageRoot="true" AnimationDuration="200" ShowEvent="OnClick">
        
        
    </telerik:RadToolTipManager>
    <div>
    <table style="margin: auto;">
    <tr>
    <td  style="height: 71px;"  valign="top">
   
  
       <div  id="Navbanner">

  
   
    <ul id="Nav">

	<h4>
    <table>
    <tr>
    <td>
 <telerik:RadTabStrip ID="RadTabStrip2" runat="server" EnableEmbeddedSkins="False" 
            SelectedIndex="0" >
     <Tabs>
         <telerik:RadTab runat="server" CssClass="menutem" Width="340px" Selected="True">
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
         <telerik:RadTab runat="server" Text="notifications(55)" ID="notifi" Width="220px" 
             >
         </telerik:RadTab>
        
     </Tabs>
 
 </telerik:RadTabStrip>   
  

    </td>
   <td>
   <telerik:RadTabStrip  ID="RadTabStrip1" 
                     EnableEmbeddedSkins="False"
				    runat="server" SelectedIndex="2" 
                   >
       <Tabs>
           <telerik:RadTab runat="server" CssClass="menutem" Text="home">
           </telerik:RadTab>
           
           <telerik:RadTab runat="server" CssClass="menutem" Text="connects">
           </telerik:RadTab>
           <telerik:RadTab runat="server" CssClass="menutem" Text="settings" 
               Selected="True">
           </telerik:RadTab>
           
       </Tabs>
                    
			    </telerik:RadTabStrip>

                
   </td>
   
   <td>
                 <telerik:RadTabStrip runat="server" ID="try1" EnableEmbeddedSkins="False" 
                     ontabclick="try_TabClick" >
                 <Tabs>
                  <telerik:RadTab runat="server" Text="logout" Selected="False">
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

        
        
        
 
 </td>
    </tr>
    <tr>
    <td>
    
<asp:Panel runat="server" Width="990px" BackColor="White" ID="Panel1">
 <div style="padding-left:10px;">

  <table>
  <tr>
  
  <td style="width:790px;">
  <telerik:RadBinaryImage runat="server" ID="propic"  Width="150px" Height="150px" CssClass="magea"  AutoAdjustImageControlSize="true" ResizeMode="Crop" />
 

 <div class="som">
 <div style="height:68px;">
  <asp:Label ID="som" runat="server"></asp:Label>
	</div>
	<div  class="connecta">
    <asp:Label ID="web" runat="server"></asp:Label><br />
    <asp:Label ID="fb" runat="server"></asp:Label><br />
   <asp:Label ID="twit" runat="server"></asp:Label>
    </div>

  </div>

 <div  style="width:390px; float:right">
    <span style="font-size:x-large;"><asp:Label ID="name" runat="server"></asp:Label></span><br />
    @<asp:Label ID="un" runat="server"></asp:Label>
    <br /><br />
   <asp:Panel runat="server" ID="sidd" CssClass="abcd">
   
  
   DOB &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:  <asp:Label ID="dob" runat="server"></asp:Label> <br />
     gender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :  <asp:Label ID="gen" runat="server"></asp:Label> <br />
     lookin for : &nbsp;&nbsp; <asp:Label ID="lookin" runat="server"></asp:Label><br />
   relationship: <asp:Label ID="works" runat="server"></asp:Label><br />
   </asp:Panel></div>
  
  </td>
  <td style="border-left: 1px solid #BB3D00;"></td>
  <td>
  <asp:Button ID="but1" runat="server" CssClass="twittertypebut" Width="180px" 
          onclick="but1_Click"  />
  <br /><br />
      <asp:Button ID="but2" runat="server" CssClass="twittertypebutp2" Width="180px" 
          onclick="but2_Click" />
      <br /><br />
      <asp:Button CssClass="twittertypebutp2" ID="but3" runat="server" Width="180px"  
onclick="but3_Click" />
      
      
  </td>
  </tr>
      
  </table>

 </div>

  
            <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="White" Enabled="True" Radius="15" TargetControlID="Panel1"></asp:RoundedCornersExtender>
    

 </asp:Panel><br />
 <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
 <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
     <AjaxSettings>
         <telerik:AjaxSetting AjaxControlID="RadTabStrip3">
             <UpdatedControls>
                 <telerik:AjaxUpdatedControl ControlID="RadMultiPage1"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                 
                 <telerik:AjaxUpdatedControl ControlID="RadTabStrip3" />
                 
             </UpdatedControls>
         </telerik:AjaxSetting>
     </AjaxSettings>
        </telerik:RadAjaxManager>
     
 <asp:Panel runat="server" Width="990px" BackColor="White" ID="Panel2">
 

 <div style="padding-left:10px;">
     
  <table>
  <tr>
  
  <td valign="top" style="width:785px;">

  <telerik:RadMultiPage ID="RadMultiPage1" SelectedIndex="0" runat="server" OnPageViewCreated="RadMultiPage1_PageViewCreated">
              

		
              

		</telerik:RadMultiPage>
  
  

  


      
  
  

  


      



  </td>
   <td style="border-left: 1px solid #BB3D00;"></td>
  <td valign="top" style="height:140px;">
  
  
  <telerik:RadTabStrip ID="RadTabStrip3" runat="server" EnableEmbeddedSkins="False"  
           Width="180px" Orientation="VerticalLeft" style="position:fixed;" SelectedIndex="0"  MultiPageID="RadMultiPage1" OnTabClick="RadTabStrip1_TabClick" >
         
     </telerik:RadTabStrip>
     <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
		<script type="text/javascript">

		    function onTabSelecting(sender, args) {
		        if (args.get_tab().get_pageViewID()) {
		            args.get_tab().set_postBack(false);
		        }
		    }
            
		</script>
        </telerik:RadScriptBlock>
  </td>
  </tr>
  </table>
  </div>
 <asp:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" 
                                    BorderColor="White" Enabled="True" Radius="15" TargetControlID="Panel2"></asp:RoundedCornersExtender>
 </asp:Panel>
 
        
    </td>
        
    </tr>
    
    </table>
        
    </div>
    </form>
</body>
</html>
