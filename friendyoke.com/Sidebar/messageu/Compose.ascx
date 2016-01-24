<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Compose.ascx.cs" Inherits="Messages_Compose" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

		<asp:Panel ID="somesendemail" runat="server">	
        
        
        <div class="example-panelabc">
		<div class="to-subject-panel">
				<ul>
					<li>
						<label>
							To:</label>
						<telerik:RadComboBox runat="server" 
							    ID="Search_People2" 
							    DataTextField="Name" 
							    DataValueField="ID" 
							    HighlightTemplatedItems="True"
							    
							    Width="640px"
							   DataSourceID="SqlDataSource2" Skin="Office2007"
								 EnableAutomaticLoadOnDemand="true" EnableVirtualScrolling="true" ItemsPerRequest = "4"
								 ShowMoreResultsBox="true" MaxHeight="240px"  AutoCompleteSeparator=","
           
            MarkFirstMatch="true" AllowCustomText="false">
								<HeaderTemplate>
						            <ul>
						                <li class="col1">Image</li>
						                <li class="col2">Name</li>
						                
						            </ul>
					            </HeaderTemplate>
					            <ItemTemplate>
						            <ul>
						                <li class="col1"><telerik:RadBinaryImage ResizeMode="Crop" DataValue='<%#Eval("Image") is DBNull ? null : Eval("Image")%>' ID="Image1" runat="server" Height="50px" 
                                         Width="50px" /></li>
						                <li class="col2"><%# DataBinder.Eval(Container.DataItem, "Name") %></li>
						                <li style="visibility:hidden;">
                                        <asp:Label runat="server" ID="lb"
                                         Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                                         </asp:Label></li>
						            </ul>
					            </ItemTemplate>
							</telerik:RadComboBox>
					</li>
					<li>
						<label>
							Subject:</label>
						<telerik:RadTextBox ID="SubjectTextBox" runat="server" Width="640px" Skin="Office2007"
							EnableViewState="false" />
					</li>
				</ul>
			</div>
			
			<div class="editor-panel">
				<telerik:RadEditor ID="MailBodyEditor" runat="server" Width="735px" Height="258px"
					EnableResize="false" EditModes="Design" Skin="Office2007" >
					<Tools>
						<telerik:EditorToolGroup Tag="MainToolbar">
							<telerik:EditorTool Name="AjaxSpellCheck" />
							<telerik:EditorSeparator Visible="true" />
							<telerik:EditorTool Name="Undo" />
							<telerik:EditorTool Name="Redo" />
							<telerik:EditorSeparator Visible="true" />
							<telerik:EditorTool Name="Cut" />
							<telerik:EditorTool Name="Copy" />
							<telerik:EditorTool Name="Paste" ShortCut="CTRL+!" />
						</telerik:EditorToolGroup>
						<telerik:EditorToolGroup Tag="Formatting">
							<telerik:EditorTool Name="Bold" />
							<telerik:EditorTool Name="Italic" />
							<telerik:EditorTool Name="Underline" />
							<telerik:EditorSeparator Visible="true" />
							<telerik:EditorTool Name="ForeColor" />
							<telerik:EditorTool Name="BackColor" />
							<telerik:EditorSeparator Visible="true" />
							<telerik:EditorTool Name="FontName" />
							
						</telerik:EditorToolGroup>
					</Tools>
				</telerik:RadEditor>
				<asp:LinkButton ID="SaveButton" Text="SEND" runat="server" 
                    CssClass="save-button" onclick="SaveButton_Click"
					 />
			</div><asp:panel CssClass="ui-state-highlight ui-corner-all" 
                        style="margin-top: 20px; padding: 0 .7em;" runat="server" ID="error0" 
                         Height="23px">
    <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
    If you enter the name twice two messages will be sent to that person . Do it if the message is important
                        
      </asp:panel>
		</div><asp:panel CssClass="ui-state-error ui-corner-all" style="padding: 0 .7em;" runat="server" 
                        ID="error" Width="625px" Height="19px" Visible="false">
    <span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span> 
     Following Field Cannot be blank
                        
      </asp:panel></asp:Panel>
      <asp:panel CssClass="ui-state-highlight ui-corner-all" 
                        style="margin-top: 20px; padding: 0 .7em;" runat="server" ID="Panel1" 
                         Height="23px" Visible="false">
    <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
    Message Successfully Sent To That Person 
                        
      </asp:panel>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:maindb1ConnectionString %>" 
    ></asp:SqlDataSource>