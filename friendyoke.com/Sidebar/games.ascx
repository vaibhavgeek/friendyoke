<%@ Control Language="C#" AutoEventWireup="true" CodeFile="games.ascx.cs" Inherits="Ement_games" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
		
		
			    <telerik:RadTabStrip ID="R1" 
                    
				    runat="server" Skin="Sitefinity" 
                    OnTabClick="RadTabStrip1_TabClick">
			    </telerik:RadTabStrip>			
			
               
		    
       <center><h1>
            Coming Soon
            </h1>
        <telerik:RadMultiPage ID="RadMultiPage5" runat="server" SelectedIndex="0" OnPageViewCreated="RadMultiPage2_PageViewCreated">
			   
                </telerik:RadMultiPage>             
               </center>      