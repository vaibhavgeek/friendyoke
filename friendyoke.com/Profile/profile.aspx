<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="Profile_images_profile" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register src="../user-controls/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../user-controls/footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile Page - friendyoke.com</title>
    <link rel="stylesheet" type="text/css" href="../lib/style.css"/>
    <link rel="stylesheet" type="text/css" href="profile.css"/>
    <script type="text/javascript" src="../lib/jquery/jquery.js"></script>
    <script type="text/javascript">

        
        function goToByScroll(id) {
            $('html,body').animate({ scrollTop: $("#" + id).offset().top }, 'slow');
        }
       
		</script>
        <style type="text/css">
        .nfeedradgrid
     {
         background-color:White;
         display:none;
         }
        
        </style>
</head>
<body class="body">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    <div>
    <table style="margin: auto;">
    <tr><td style=" height:65px;">
        <uc1:Header ID="Header1" runat="server" />
        
        
        </td></tr>
    <tr>
    <td>
    <table>
        
        
    <tr>
    <td valign="top">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" HorizontalAlign="NotSet" 
            LoadingPanelID="LoadingPanel1">
       
    <asp:Panel ID="Panel4" runat="server" BackColor="White"  Width="232px"> 
           <telerik:RadPanelBar  style="margin-left:8px;" ID="RadPanelBar1" Runat="server" Skin="Office2007" 
    Width="210px"><Items><telerik:RadPanelItem runat="server" Text="Connect" Value="connect" Expanded="true" PostBack="false">
    <Items>
    <telerik:RadPanelItem Value="buttons">
    <ItemTemplate>
    <div class="text" style="background-color: #edf9fe"><ul class="formList" id="accountInfo">
    <li><telerik:RadButton ID="friendreq" runat="server" Text="Ask 2 Connect" Width="171px" onclick="friendreq_Click" CommandName="ask"></telerik:RadButton></li>
    <li><telerik:RadButton runat="server" Width="171px" ID="addbox" Text="Add to Box"  onclick="but2_Click" CommandName="addb" ></telerik:RadButton></li>
    <li><telerik:RadButton runat="server" Width="171px" Visible = "false" ID="message" Text="Message" onclick="but3_Click" CommandName="ms"></telerik:RadButton></li>
    </ul></div></ItemTemplate></telerik:RadPanelItem></Items></telerik:RadPanelItem>
    <telerik:RadPanelItem runat="server" Text="Basic Information" Expanded="true" PostBack="false">
    <Items><telerik:RadPanelItem Value="bi"><ItemTemplate>
    <div class="text" style="background-color: #edf9fe"><ul class="formList" id="accountInfo">
    <telerik:RadBinaryImage runat="server" Width="180px" Height="350px" ID="profilepicture" ResizeMode="Crop" />
    <li>Name &nbsp;&nbsp;: <asp:Label ID="nm" runat="server"></asp:Label> </li>
    <li>DOB &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:  <asp:Label ID="dob" runat="server"></asp:Label> </li>
    <li>Gender :  <asp:Label ID="gen" runat="server"></asp:Label>  </li>
    <li>Born @ :  <asp:Label ID="born" runat="server"></asp:Label></li>
    </ul></div></ItemTemplate></telerik:RadPanelItem></Items></telerik:RadPanelItem>
    <telerik:RadPanelItem runat="server" Text="On Networks" Expanded="true" PostBack="false">
    <Items><telerik:RadPanelItem>
    <ItemTemplate>
    <div class="text" style="background-color: #edf9fe">
    <ul class="formList" id="accountInfo">
    <li><a href="#"><img src="images/networks/facebook.png" /></a>&nbsp; 
    <a href="#"><img src="images/networks/twitter.png" /></a>&nbsp;
     <a href="#"><img src="images/networks/plus.jpg" /></a>&nbsp;
      <a href="#"><img src="images/networks/linked.png" /></a>
      </li>
      </ul>
      </div>
      </ItemTemplate></telerik:RadPanelItem></Items></telerik:RadPanelItem></Items></telerik:RadPanelBar>
           <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel4"></asp:RoundedCornersExtender>
           </asp:Panel> 
     </telerik:RadAjaxPanel>
    </td>
    <td valign="top">
     <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="750px">
      <asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel1">
                                </asp:RoundedCornersExtender>
      <div style="padding-left:15px;">
   
    <table>
    <tr>
    <td valign="top">
    
               
                <asp:Panel runat="server" ID="mimageandpic" Width="527px">
              
                
                <h2 class="mainheader">Mimage</h2>
                <br />
              
                <telerik:RadBinaryImage ID="mmimage" ResizeMode="Crop" Height="412px" runat="server" Width="525px" />
                
                 </asp:Panel>       
                
                
                <asp:Panel runat="server" ID="eduwork" Width="527px">
                <h2 class="mainheader">Education and Work</h2>
                <br />
                <table><tr>
                <td valign="top">
                <ul class="formList">     
                <li style="width:490px;"> 
                <b><asp:Label runat="server" ID="schoolt" Text="School"></asp:Label></b>
                
                <asp:Label runat="server" ID="school" Text=": Rachana School"></asp:Label>
                
                </li>
                  <li style="width:490px;"> 
               <b> <asp:Label runat="server" ID="colleget" Text="College"></asp:Label></b>
                 
                <asp:Label runat="server" ID="collegea" Text=": Rachana School"></asp:Label>
                </li>

                 <li style="width:490px;"> 
                <b><asp:Label runat="server" ID="degreet" Text="Degree"></asp:Label> </b>
                <asp:Label runat="server" ID="degree" Text=": Rachana School"></asp:Label>

                </li>
                 <li style="width:490px;"> 
               <b> <asp:Label runat="server" ID="companyt" Text="Company"></asp:Label> </b>
                <asp:Label runat="server" ID="company" Text=": Rachana School"></asp:Label>

                </li>
                <li style="width:490px;"> 
               <b> <asp:Label runat="server" ID="designationt" Text="Designation"></asp:Label></b>
                
                
               
                      <asp:Label runat="server" ID="college" Text=": Rachana School"></asp:Label></li></ul>
               
                </td>
                </tr></table>
                
                </asp:Panel> <br /><br />    
                <asp:Panel runat="server" ID="photos" Width="527px">
                <h2 class="mainheader">Albums</h2>
                <br />
                  
                        
                            
                               
                            
                      
                        
                    
                </asp:Panel><br /><br />
                <div id="try">    </div>
                <asp:Panel Visible ="false" runat="server" ID="eventlife" Width="527px">
                <h2 class="mainheader">Events in Life</h2>
                <br />

               <asp:Repeater ID="Repeater1" runat="server">
					<ItemTemplate>
               <div class="divXmlPanel">
						<div style="float: left; width: 330px; position: relative;left: 30px; padding-right:20px; top:5px;">
							<br />
							<asp:Label CssClass="info" ID="Name" runat="server" Style="font-size: x-large; line-height: 1.5em;"><%# DataBinder.Eval(Container.DataItem, "EventName") %></asp:Label><br />
							<asp:Label CssClass="info" ID="Label1" runat="server">
                            <%# DataBinder.Eval(Container.DataItem, "Description") %>
                             
                             </asp:Label>
							<br />
						
							
						</div>
                       
						 <telerik:RadBinaryImage  runat="server" ID="eimg" DataValue='<%#photobyte(Container.DataItem)%>' style="position: relative; top: 35px; float: left; border: 1px solid #999999;
							margin-right: 10px; width: 150px; height: 200px; background-position: center;
							background-repeat: no-repeat;"/>
						
					</div></ItemTemplate></asp:Repeater>
                    
                  
                </asp:Panel><br /><br />    
                <asp:Panel runat="server" ID="locations" Visible="false" Width="527px">
                <h2 class="mainheader">Locations</h2>
                <br />
                Google Maps API use, could be added later on 
                
                </asp:Panel><br /><br />    

                <asp:Panel runat="server" ID="philosophy" Width="527px">
                <h2 class="mainheader">Philosophy</h2>
                <br />
               <table><tr>
                <td valign="top"> 
                <ul class="formList">     
                <li style="width:490px;">    <b>    <asp:Label runat="server" ID="relt" Text="Religion"></asp:Label> </b>
                <asp:Label runat="server" ID="rel" Text=": Rachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana Schoo"></asp:Label>
                </li>

                 <br />
                 <li  style="width:490px;"> 
                <b><asp:Label runat="server" ID="lifet" Text="Life"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                 <asp:Label runat="server" ID="life" Text=": Rachana School Rachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRa Rachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRa"></asp:Label>
                 </li>

                 <br /><li style="width:490px;"> 
                <b> <asp:Label runat="server" ID="qt" Text="Quote"></asp:Label></b> &nbsp;
                  <asp:Label runat="server" ID="qute" Text=": Rachana School"></asp:Label>
                  </li>

                 <br /><b><li  style="width:490px;"> <asp:Label runat="server" ID="politicst" Text="Political"></asp:Label></b>
                  <asp:Label runat="server" ID="politics" Text=": Rachana School"></asp:Label>
               </li>  </ul>
  
                
               
              
               
                
                     
                </td>
                
                </tr></table>
                
                </asp:Panel><br /><br />    
                <asp:Panel runat="server" ID="ement" Width="527px">
                <h2 class="mainheader">Entertainment and Intrests</h2>
                <br />
               <table><tr>
                <td valign="top"> 
                <ul class="formList">     
                <li style="width:490px;">    <b>    <asp:Label runat="server" ID="moviest" Text="Movies"></asp:Label> </b>
                <asp:Label runat="server" ID="movies" Text=": Rachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana Schoo"></asp:Label>
                </li>

                 <br />
                 <li  style="width:490px;"> 
                <b><asp:Label runat="server" ID="musict" Text="Music"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                 <asp:Label runat="server" ID="music" Text=": Rachana School Rachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRa Rachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRachana SchoolRa"></asp:Label>
                 </li>

                 <br /><li style="width:490px;"> 
                <b> <asp:Label runat="server" ID="bookst" Text="Books"></asp:Label></b> &nbsp;
                  <asp:Label runat="server" ID="books" Text=": Rachana School"></asp:Label>
                  </li>

                 <br /><b><li  style="width:490px;"> <asp:Label runat="server" ID="telt" Text="Television"></asp:Label></b>
                  <asp:Label runat="server" ID="tel" Text=": Rachana School"></asp:Label>
               </li>
               
               <br /><b><li  style="width:490px;"> <asp:Label runat="server" ID="sportst" Text="Sports"></asp:Label></b>
                  <asp:Label runat="server" ID="sports" Text=": Rachana School"></asp:Label>
               </li> 
                 </ul>
  
                
               
              
               
                
                     
                </td>
                
                </tr></table>
                
                </asp:Panel><br /><br />    
                   <asp:Panel runat="server" ID="achieve" Width="527px">
                <h2 class="mainheader">Achievements</h2>
                <br />
               <asp:Literal runat="server" ID="achievements"></asp:Literal>
                
                </asp:Panel><br /><br />    
                <asp:Panel runat="server" ID="friends" Width="527px">
                <h2 class="mainheader">Friend List</h2>
               
                 <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

		<script type="text/javascript">
		    function rowSelected(sender, args) {
		        var key = args.getDataKeyValue("ID");
		        var panel = $find("<%=RadXmlHttpPanel1.ClientID %>");
		        panel.set_value(key);
		    }
		</script>

	</telerik:RadScriptBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
		<AjaxSettings>
			<telerik:AjaxSetting AjaxControlID="RadGrid1">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="LoadingPanel1" />
				</UpdatedControls>
			</telerik:AjaxSetting>
		    <telerik:AjaxSetting AjaxControlID="Repeater2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Repeater2" LoadingPanelID="LoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="LoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
		</AjaxSettings>
	</telerik:RadAjaxManager>
	
	<br /> <center>
			<telerik:RadGrid ID="RadGrid1" Skin="Vista" OnNeedDataSource="RadGrid1_NeedDataSource"
				Width="500px" AllowSorting="True" AllowPaging="True" runat="server"
				AutoGenerateColumns="False" GridLines="None" AllowFilteringByColumn="True" CellSpacing="0" CssClass="grid">
				<MasterTableView ClientDataKeyNames="ID" Width="100%" Summary="RadGrid table">
					<Columns>
						<telerik:GridBoundColumn DataField="ID" Visible="false">
						</telerik:GridBoundColumn>
						<telerik:GridBoundColumn HeaderText="Name" DataField="Name" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="155px">
						</telerik:GridBoundColumn>
						<telerik:GridBoundColumn HeaderText="City" DataField="City" UniqueName="City" AllowFiltering="false">
						</telerik:GridBoundColumn>
					</Columns>
				</MasterTableView>
				<PagerStyle Mode="Slider" PageButtonCount="5" />
				<ClientSettings EnableRowHoverStyle="true" Selecting-AllowRowSelect="true" ClientEvents-OnRowSelected="rowSelected">
				</ClientSettings>
			</telerik:RadGrid></center>
		
		<br />
			<telerik:RadXmlHttpPanel ID="RadXmlHttpPanel1" runat="server" OnServiceRequest="XmlHttpPanel_ServiceRequest"
				RenderMode="Block">
				<asp:Repeater ID="Repeater2" runat="server" 
                    onitemcommand="Repeater2_ItemCommand">
					<ItemTemplate>
                    
						<a href="profile.aspx?Id=<%# Eval("Id") %>"><telerik:RadBinaryImage ResizeMode="Crop" Width="177px" Height="230px" 
        runat="server" ID="propic" DataValue='<%# Eval("Image") %>' style="float:left;border:1px solid #999999;margin-right: 15px;"/>
						</a>
							
								<asp:Label CssClass="info" ID="Name" runat="server" Style="font-size: x-large;">
									<%# Eval("Name") %></asp:Label><br />
							<a class="someclasslink" href="profile.aspx?Id=<%# Eval("Id") %>">	<asp:Label CssClass="info" ID="Label1" runat="server">@<%# Eval("uname")%></asp:Label>
							</a>
							
							 <ul class="formList">     
                <li style="width:490px;"> 
								<b>Education : </b>
                                <asp:Label CssClass="info" ID="Label2" runat="server"><%# Eval("School")%></asp:Label>
                                </li>
								
								<li style="width:490px;"><b> Gender: </b>
                                <asp:Label CssClass="info" ID="Label3" runat="server"><%# Eval("Gender")%></asp:Label>
                                
                                </li>
								<li style="width:490px;"> <b>Website :</b> 
                                <asp:Label CssClass="info" ID="Label5" runat="server">
                                <a href="<%# Eval("Website")%>" target="_blank">
                                <%# Eval("Website")%>
                                </a>
                                
                                
                                </asp:Label>
                                </li>


								
                                <li style="width:490px;">
                                <telerik:RadButton runat="server" ID="addasfrnd" CommandName="connect" Text="Ask 2 Connect">
                                <Icon PrimaryIconUrl="../Images/REQUEST.jpg" />
                                </telerik:RadButton>
                                &nbsp;&nbsp; <telerik:RadButton runat="server" ID="addbox" CommandName="box" Text="Add to Box">
                                 <Icon PrimaryIconUrl="../Images/add-icon.png" /> 
                                 </telerik:RadButton>
                                </li>

                                <li style="width:490px;"><b>Social Connect :</b>
                               
                                <a href="http://www.facebook.com/<%# Eval("Facebook")%>" target="_blank"><img src="images/networks/facebook.png" /></a>&nbsp; 
                                <a href="http://www.twitter.com/<%# Eval("Twitter")%>" target="_blank"><img src="images/networks/twitter.png" /></a>&nbsp; 
                                <a href="http://www.plus.google.com/<%# Eval("Plus")%>" target="_blank" ><img src="images/networks/plus.jpg" /></a>&nbsp; 
                                <a href="http://www.linkedin.com/<%# Eval("Linkedin")%>" target="_blank"><img src="images/networks/linked.png"  /></a>
                                
                                </li>
								</ul>
							
							
								
								
								
								
								
								
							
						
					</ItemTemplate>
				</asp:Repeater>
			</telerik:RadXmlHttpPanel>
		
                <asp:Label runat="server" ID="lblError" Visible="true"></asp:Label>
                
                    
                
                </asp:Panel>  
                
                
                <asp:Panel runat="server" ID="contactme" Width="527px">
                <h2 class="mainheader">Contact Information</h2>
                <br />
               <table><tr>
                <td valign="top"> 
                <ul class="formList">     
                <li style="width:490px;">    <b>    <asp:Label runat="server" ID="webt" Text="Website"></asp:Label> </b>
                <asp:Label runat="server" ID="web" Text=": http://www.thevaibhavm.blogspot.com"></asp:Label>
                </li>

                 <br />
                 <li  style="width:490px;"> 
                <b><asp:Label runat="server" ID="phonet" Text="Phone"></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                 <asp:Label runat="server" ID="phone" Text=": 9426336657"></asp:Label>
                 </li>

                 <br /><li style="width:490px;"> 
                <b> <asp:Label runat="server" ID="addt" Text="Address"></asp:Label></b> &nbsp;
                  <asp:Label runat="server" ID="add" Text=": 303, Akshar Park - 2 , Shahibagh , Ahmedabad, Gujarat , India"></asp:Label>
                  </li>

                 <br /><b><li  style="width:490px;"> <asp:Label runat="server" ID="emailt" Text="Email"></asp:Label></b>
                  <asp:Label runat="server" ID="email" Text=": vaibhav.dkm@gmail.com"></asp:Label>
               </li>  </ul>
  
                
               
              
               
                
                     
                </td>
                
                </tr></table>
                
                </asp:Panel>   <br /><br />    
                <asp:Panel runat="server" ID="posts" Width="527px">
                <h2 class="mainheader">Recent Posts</h2>
                <br />
               <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CellSpacing="0" GridLines="None" 
                        onneeddatasource="RadGrid2_NeedDataSource">
                        <MasterTableView Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 <table bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                 <tr>
                 <td valign="top" bordercolor="White" style="border-style: none; border-width: 0px; border-top-color: #FFFFFF">
                 
             
                                        <a href='<%#getUserHREF(Container.DataItem)%>'>
                                        <telerik:RadBinaryImage ID="sompropic" style="margin-left:0px;" runat="server" CssClass="ppic" DataValue='<%#propics(Container.DataItem)%>' Height="70px" Width="70px" ResizeMode="Fit" />
                                             </a>
                                 
                 
                 
                 </td>
                <td valign="top" bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                
                
                 <div align="justify">
              <span style="font-size:11px;">  
               Posted  By  <%#sendname(Container.DataItem)%>
               </span>
               <span style="font-size:11px; padding-left:60px;">
               Posted On: 
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    <asp:Panel runat="server" ID="mainc">
                  
                  <a class="nfeed" style="display:<%#displayy(Container.DataItem)%>;"  href="javascript:OpenFileExplorerDialog(<%#itemd(Container.DataItem)%>,<%#pid(Container.DataItem)%>,<%#alid(Container.DataItem)%>)">
                   <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyt(Container.DataItem)%>'
                                AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/>
                   </a>
                    
            <a style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </a>

            </asp:Panel>
  <br /><asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%#itemd(Container.DataItem)%>'></asp:Label>
                          <br /> 
                           <span style="font-size:11px;">
                           &nbsp;&nbsp;
                           </div>
                              
                             
                     
                    
                  
                          
                                  
               
                
                </td> 
                 
                 
                 </tr>
                 
                 </table>
                            
                           
                  </ItemTemplate>
                  
                </telerik:GridTemplateColumn>
                </Columns></MasterTableView>
                <PagerStyle Wrap="True"  PageSizeLabelText="New Feed Count:" />
                    </telerik:RadGrid>
                <asp:Label runat="server" ID="lbl"></asp:Label>
                </asp:Panel>    <br /><br />    
        
    </td>
    <td style="border-left: 1px solid #BB3D00;">
    </td>
    <td valign="top">
    <div style="width:185px">
      <telerik:RadTabStrip  ID="RadTabStrip1" 
                     CssClass="tabStrip"
				    runat="server" MultiPageID="Mpage" 
                    Orientation="VerticalRight" SelectedIndex="0" 
            Skin="Office2007" style="position:fixed !important;">
			    <Tabs>
                <telerik:RadTab runat="server" Text="Take me to Top" Selected="true" onclick="goToByScroll(&#39;form1&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Mimage" onclick="goToByScroll(&#39;mimageandpic&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Education and Work" onclick="goToByScroll(&#39;eduwork&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Albums" onclick="goToByScroll(&#39;photos&#39;)">
                    </telerik:RadTab>
                    
                    
                    <telerik:RadTab runat="server" Text="Philosophy" onclick="goToByScroll(&#39;philosophy&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Entertainment and Intrests" onclick="goToByScroll(&#39;ement&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Achievements" onclick="goToByScroll(&#39;achieve&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Friends" onclick="goToByScroll(&#39;friends&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Contact Information" onclick="goToByScroll(&#39;contactme&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Recent Posts" onclick="goToByScroll(&#39;posts&#39;)">
                    </telerik:RadTab>
                </Tabs>
			    </telerik:RadTabStrip>		
    </div>
    </td>
    </tr>
    </table>
   
		     
                
    </div>
    </asp:Panel>
    </td>
    </tr>
    </table>
     <telerik:RadAjaxLoadingPanel ID="LoadingPanel1" runat="server" 
        Skin="Sitefinity" Direction="LeftToRight" BackgroundPosition="Center" >
        
    </telerik:RadAjaxLoadingPanel>
    </td>
    </tr>
    <tr><td>
        <uc2:footer ID="footer1" runat="server" />
        </td></tr>
    </table>
    </div>
    </form>
</body>
</html>
