<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Inbox.ascx.cs" Inherits="Messages_Inbox" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div style="height: 593px;">
    <telerik:RadSplitter ID="RadSplitter1" runat="server" Orientation="Horizontal" 
        Width="736px" Height="563px" BorderColor="White" Skin="Sunset">
 <telerik:RadPane ID="LeftPane" runat="server" Width="710px" Height="270px" >

<telerik:RadGrid GridLines="None" ID="RadGrid1" AllowMultiRowSelection="True" style="border:0"
                runat="server" Width="680px" Height="180px" 
    AllowAutomaticDeletes="True" EnableLinqExpressions="False" CellSpacing="0" 
    DataSourceID="Message"   
         AutoGenerateColumns="False" 
       
         onitemcommand="RadGrid1_ItemCommand" Skin="Vista" >
              <ClientSettings EnablePostBackOnRowClick="true"></ClientSettings>
                <ClientSettings Selecting-AllowRowSelect="true" EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="True" />
                
                
                </ClientSettings>

<MasterTableView AutoGenerateColumns="False" DataKeyNames="ID,MID" DataSourceID="Message">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
</ExpandCollapseColumn>

    <Columns>
        
        
        
        
         <telerik:GridBoundColumn HeaderText="MID" DataField="MID" Visible="false" UniqueName="MID">
                            </telerik:GridBoundColumn>
        
        


        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
            UniqueName="TemplateColumn" HeaderText="From" >
            <ItemTemplate>
            <telerik:RadBinaryImage ID="Image1" runat="server" Width="15px" Height="20px" ResizeMode="Crop"    DataValue='<%# Eval("Image") %>' />
					
           
         &nbsp;&nbsp;   <%# DataBinder.Eval(Container.DataItem, "Name") %>
          
         
            
            </ItemTemplate>

        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" 
            UniqueName="TemplateColumn1" HeaderText="Subject"> 
            <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem, "Subject") %>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn2 column" 
            UniqueName="TemplateColumn2" HeaderText="Send-Time"><ItemTemplate>
            
            
            </ItemTemplate>
        </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                
                


            </telerik:RadGrid>
           
       
            </telerik:RadPane>
        <telerik:RadSplitBar ID="RadSplitBar1" runat="server" CollapseMode="None" />
        <telerik:RadPane ID="MiddlePane1" runat="server" Width="710px" 
        ><div style="padding-left:15px; padding-top:15px;">
           <div class="divContainerBottom">
           <div class="xmlPanelCustomerInfo">           <asp:Repeater ID="RepeaterCustomerInfo" runat="server">
				<ItemTemplate>
                
                 <telerik:RadBinaryImage ID="Image1" runat="server" Width="180px" Height="220px" ResizeMode="Crop"   CssClass="classImg" DataValue='<%# Eval("Image") %>' />
					
					<div style="float: left;">
						<br />
						<br />
						<asp:Label CssClass="info" ID="Name" runat="server" Font-Size="X-Large" ForeColor="#5281ce"><%# DataBinder.Eval(Container.DataItem, "Name") %></asp:Label><br />
						<asp:Label CssClass="info" ID="Label1" runat="server" ForeColor="#5281ce"><%# Eval("Subject")%></asp:Label><br />
						<br />
						
						<div style="float: left; margin-left: 5px;">
							<asp:Label CssClass="info" ID="cName" runat="server"><%# Eval("Message")%></asp:Label>
							
							
							
							
						</div>
					</div>
				</ItemTemplate>
			</asp:Repeater></div>
</div>
           
			
		
           </div>
            </telerik:RadPane>
      
       
    </telerik:RadSplitter>
    
    
    
   
    
    
    
    
   
<asp:SqlDataSource ID="Message" runat="server" 
    ConnectionString="<%$ ConnectionStrings:maindb1ConnectionString %>" ></asp:SqlDataSource></div>









