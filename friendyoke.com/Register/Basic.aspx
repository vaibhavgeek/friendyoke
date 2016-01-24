<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Basic.aspx.cs" Inherits="Register_Basic" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../user-controls/footer.ascx" tagname="footer" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <link rel="stylesheet" type="text/css" href="register.css"/>
  <link rel="stylesheet" type="text/css" href="../lib/style.css"/>
  
</head>
<body class="body">
    <form id="form1" runat="server"  >
    
   <telerik:RadFormDecorator runat="server" ID="decorate" 
    DecoratedControls="Buttons" Skin="Default" Width="194px" />
    <table style="margin: auto;">
    
    <tr>
    <td valign="top" class="style1">
    
   
    <br />   
        <br />
       
        
        <br />
        </td>
    <td valign="top">
    &nbsp;<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="nextButton">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadPanelBar1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div>
           
    
       
       <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
       </telerik:RadScriptManager>
         
                   
    <asp:Panel  CssClass="somesignup" ID="some" runat="server" 
                BackColor="White" Width="980px"  >
                <div runat="server" id="coder">

<script type="text/javascript">

      function checkPasswordMatch() {
          var text1 = $find("<%=RadPanelBar1.FindItemByValue("Step1").FindControl("password").ClientID%>").get_textBoxValue();
          var text2 = $find("<%=RadPanelBar1.FindItemByValue("Step1").FindControl("cpassword").ClientID%>").get_textBoxValue();

          if (text2 == "") {
              $get("PasswordRepeatedIndicator").innerHTML = "";
              $get("PasswordRepeatedIndicator").className = "Base L0";
          }
          else if (text1 == text2) {
              $get("PasswordRepeatedIndicator").innerHTML = "Match";
              $get("PasswordRepeatedIndicator").className = "Base L5";
          }
          else {
              $get("PasswordRepeatedIndicator").innerHTML = "No match";
              $get("PasswordRepeatedIndicator").className = "Base L1";
          }
      }
  
  </script>
  </div>
  <div style="padding-left:25px;">
    
                <h2>signup on friendyoke.com</h2>
                <table>
                <tr align="center">
                <td align="center">
                <center><asp:Button runat="server" ID="but" CssClass="facebook" Text="facebook signup magic" PostBackUrl="https://www.facebook.com/dialog/oauth/?
    client_id=389477487741720
    &redirect_uri=http://friendyoke.com/open.php&scope=user_activities,user_about_me,user_birthday,user_education_history,user_hometown,user_interests,user_location,user_relationships,user_religion_politics,user_website,user_work_history
">

</asp:Button></center>
                </td>
                </tr>
                <tr>
                <td>
                
                

                

             
         

  


     <br />


                <telerik:RadPanelBar  style="margin-left:8px;" ID="RadPanelBar1" Runat="server" Skin="Office2007" Width="910px">
    <Items>

    

        <telerik:RadPanelItem Expanded="true" Selected="true" runat="server" Text="Enter Account Information :  Step 1 Of Registration" >
        <Items>
                 <telerik:RadPanelItem Value="Step1" runat="server">
                             <ItemTemplate>
									<div class="text" style="background-color: #edf9fe">
										<ul class="formList" id="accountInfo">
											
                                            
                                            <li>
												<asp:Label runat="server" ID="nameLabel" AssociatedControlID="fName">First Name: </asp:Label>

												<telerik:RadTextBox EmptyMessage="ex. Vaibhav" EnableTheming="false" Height="20px" Font-Size="15px" ID="fName" CssClass="textInput" runat="server" ValidationGroup="accountValidation"
													Width="200px"></telerik:RadTextBox>
												<asp:RequiredFieldValidator runat="server" ID="accountValidator" ValidationGroup="accountValidation"
													ControlToValidate="fName" ErrorMessage="First name is required" Text="*"></asp:RequiredFieldValidator>
											</li>

                                            <li>
												<asp:Label runat="server" ID="Label8" AssociatedControlID="lName">Last Name: </asp:Label>
												<telerik:RadTextBox EmptyMessage="ex. Maheshwari" EnableTheming="false" Height="20px" Font-Size="15px" ID="lname" CssClass="textInput" runat="server" ValidationGroup="accountValidation"
													Width="200px"></telerik:RadTextBox>
												<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ValidationGroup="accountValidation"
													ControlToValidate="lName" ErrorMessage="Last name is required" Text="*"></asp:RequiredFieldValidator>
											</li>
                                            
                                            
                                            <li>
												<asp:Label runat="server" ID="uname" AssociatedControlID="unamet">User Name: </asp:Label>
												<telerik:RadTextBox EmptyMessage="profile-friendyoke.com/username" EnableTheming="false" Height="20px" Font-Size="15px" ID="unamet" CssClass="textInput" runat="server" ValidationGroup="accountValidation"
													Width="200px"></telerik:RadTextBox>
												<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ValidationGroup="accountValidation"
													ControlToValidate="unamet" ErrorMessage="User name is required" Text="*"></asp:RequiredFieldValidator>
											</li>
                                            
                                            
                                            
                                            <li>
												<asp:Label runat="server" ID="Label3" AssociatedControlID="email">Email:</asp:Label>
												<telerik:RadTextBox EmptyMessage="ex. emailid@gmail.com" EnableTheming="false" Height="20px" Font-Size="15px" ID="email" ValidationGroup="accountValidation" CssClass="textInput" runat="server" Width="200px"></telerik:RadTextBox>
												<asp:RegularExpressionValidator ID="emailValidator" runat="server" Display="Dynamic"
													ErrorMessage="Please enter a valid e-mail address." ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
													ControlToValidate="Email" ValidationGroup="accountValidation">
												</asp:RegularExpressionValidator>
												<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" Display="Dynamic"
													ControlToValidate="Email" ErrorMessage="E-mail is required" Text="*" ValidationGroup="accountValidation" />
											</li>
											
                                            
                                            
                                            <li>
												<asp:Label runat="server" ID="Label1" AssociatedControlID="Password">Password:</asp:Label>
												<telerik:RadTextBox  EnableTheming="false" Height="20px" Font-Size="15px" ID="password" CssClass="textInput" TextMode="Password" ValidationGroup="accountValidation"
													runat="server" Width="200px" PasswordStrengthSettings-ShowIndicator="true"></telerik:RadTextBox>
												<asp:RequiredFieldValidator runat="server" ValidationGroup="accountValidation" ID="passwordValidator"
													ControlToValidate="password" ErrorMessage="Password is required" Text="*"></asp:RequiredFieldValidator>
											</li>
											
                                            
                                            
                                            <li class="lastListItem">
												<asp:Label runat="server" ID="Label2" AssociatedControlID="cPassword">Confirm Password:</asp:Label>
												<telerik:RadTextBox EnableTheming="false" Height="20px" Font-Size="15px" TextMode="Password" CssClass="textInput" ValidationGroup="accountValidation" ID="cPassword"
													runat="server" Width="200px" onkeyup="checkPasswordMatch()"></telerik:RadTextBox>
													
											<span id="PasswordRepeatedIndicator" class="Base L0">
                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="accountValidation" ID="RequiredFieldValidator2"
													ControlToValidate="cPassword" ErrorMessage="Password is required" Text="*"></asp:RequiredFieldValidator>
        &nbsp;</span>
        
        </li>
											
										
                                        
                                        
                                        </ul>
										<br />
										<asp:ValidationSummary runat="server" ID="validationSummary" CssClass="validationSummary" />
										
                                        <asp:Button runat="server" ID="nextButton"  Text="Next Step"
											 style="width: 93px; height: 25px; margin-left:613px; font: normal 12px Arial, sans-serif;" ValidationGroup="accountValidation" OnClick="nextButton_Click" /><br />
									
                                    
                                    <asp:Label style="width: 93px; height: 25px; margin-left:503px; font: normal 12px Arial, sans-serif;" runat="server" ID="e2" Visible="false" ForeColor="Red" ></asp:Label>	<br />
									
                                    
                                    </div>

								</ItemTemplate>
                                
                                </telerik:RadPanelItem>
                                
                                </Items>
                                
                                </telerik:RadPanelItem >
        <telerik:RadPanelItem runat="server" Text="Enter Basic Details :  Step 2 Of Registration" Expanded="false" Enabled="false" >
        <Items>
        <telerik:RadPanelItem Value="Step2">     
        <ItemTemplate>
      <div class="text" style="background-color: #edf9fe" Text="">
										<ul class="formList" id="accountInfo" Text="">
											<li>
												<asp:Label runat="server" ID="Label5" AssociatedControlID="bday" Text="Birthdate :"></asp:Label>
                                                
                                                
												<telerik:RadComboBox MarkFirstMatch="true" Filter="StartsWith" Skin="Office2007" Width="50px" id="bday" Runat="server" Text="">

                                                <Items>
 
 <telerik:RadComboBoxItem Selected="True" Value="1" Text="1" />
 <telerik:RadComboBoxItem Value="2" Text="2" />
 <telerik:RadComboBoxItem Value="3" Text="3" />
 <telerik:RadComboBoxItem Value="4" Text="4" />
 <telerik:RadComboBoxItem Value="5" Text="5" />
 <telerik:RadComboBoxItem Value="6" Text="6" />
 <telerik:RadComboBoxItem Value="7" Text="7" />
 <telerik:RadComboBoxItem Value="8" Text="8" />
 <telerik:RadComboBoxItem Value="9" Text="9" />
 <telerik:RadComboBoxItem Value="10" Text="10" />
 <telerik:RadComboBoxItem Value="11" Text="11" />
 <telerik:RadComboBoxItem Value="12" Text="12" />
 <telerik:RadComboBoxItem Value="13" Text="13" />
 <telerik:RadComboBoxItem Value="14" Text="14" />
 <telerik:RadComboBoxItem Value="15" Text="15" />
 <telerik:RadComboBoxItem Value="16" Text="16" />
 <telerik:RadComboBoxItem Value="17" Text="17" />
 <telerik:RadComboBoxItem Value="18" Text="18" />
 <telerik:RadComboBoxItem Value="19" Text="19" />
 <telerik:RadComboBoxItem Value="20" Text="20" />
 <telerik:RadComboBoxItem Value="21" Text="21" />
 <telerik:RadComboBoxItem Value="22" Text="22" />
 <telerik:RadComboBoxItem Value="23" Text="23" />
 <telerik:RadComboBoxItem Value="24" Text="24" />
 <telerik:RadComboBoxItem Value="25" Text="25" />
 <telerik:RadComboBoxItem Value="26" Text="26" />
 <telerik:RadComboBoxItem Value="27" Text="27" />
 <telerik:RadComboBoxItem Value="28" Text="28" />
 <telerik:RadComboBoxItem Value="29" Text="29" />
 <telerik:RadComboBoxItem Value="30" Text="30" />
 <telerik:RadComboBoxItem Value="31" Text="31" /></Items>
</telerik:RadComboBox>-<telerik:RadComboBox MarkFirstMatch="true" Filter="StartsWith" Skin="Office2007" Width="70px" id="drpBirthMonth" Runat="server" Text=""><Items>
 <telerik:RadComboBoxItem Selected="True" Value="1" Text="Jan" />
 <telerik:RadComboBoxItem Value="2" Text="Feb" />
 <telerik:RadComboBoxItem Value="3" Text="Mar" />
 <telerik:RadComboBoxItem Value="4" Text="Apr" />
 <telerik:RadComboBoxItem Value="5" Text="May" />
 <telerik:RadComboBoxItem Value="6" Text="Jun" />
 <telerik:RadComboBoxItem Value="7" Text="Jul" />
 <telerik:RadComboBoxItem Value="8" Text="Aug" />
 <telerik:RadComboBoxItem Value="9" Text="Sep" />
 <telerik:RadComboBoxItem Value="10" Text="Oct" />
 <telerik:RadComboBoxItem Value="11" Text="Nov" />
 <telerik:RadComboBoxItem Value="12" Text="Dec" /></Items>
</telerik:RadComboBox>-<telerik:RadComboBox MarkFirstMatch="true" Width="80px" Filter="StartsWith" Skin="Office2007" id="drpBirthYear" runat="server" Text=""><Items>
 <telerik:RadComboBoxItem Value="1950" Text="1950" />
 <telerik:RadComboBoxItem Value="1951" Text="1951" />
 <telerik:RadComboBoxItem Value="1952" Text="1952" />
 <telerik:RadComboBoxItem Value="1953" Text="1953" />
 <telerik:RadComboBoxItem Value="1954" Text="1954" />
 <telerik:RadComboBoxItem Value="1955" Text="1955" />
 <telerik:RadComboBoxItem Value="1956" Text="1956" />
 <telerik:RadComboBoxItem Value="1957" Text="1957" />
 <telerik:RadComboBoxItem Value="1958" Text="1958" />
 <telerik:RadComboBoxItem Value="1959" Text="1959" />
 <telerik:RadComboBoxItem Value="1960" Text="1960" />
 <telerik:RadComboBoxItem Value="1961" Text="1961" />
 <telerik:RadComboBoxItem Value="1962" Text="1962" />
 <telerik:RadComboBoxItem Value="1963" Text="1963" />
 <telerik:RadComboBoxItem Value="1964" Text="1964" />
 <telerik:RadComboBoxItem Value="1965" Text="1965" />
 <telerik:RadComboBoxItem Value="1966" Text="1966" />
 <telerik:RadComboBoxItem Value="1967" Text="1967" />
 <telerik:RadComboBoxItem Value="1968" Text="1968" />
 <telerik:RadComboBoxItem Value="1969" Text="1969" />
 <telerik:RadComboBoxItem Value="1970" Text="1970" />
 <telerik:RadComboBoxItem Value="1971" Text="1971" />
 <telerik:RadComboBoxItem Value="1972" Text="1972" />
 <telerik:RadComboBoxItem Value="1973" Text="1973" />
 <telerik:RadComboBoxItem Value="1974" Text="1974" />
 <telerik:RadComboBoxItem Value="1975" Text="1975" />
 <telerik:RadComboBoxItem Value="1976" Text="1976" />
 <telerik:RadComboBoxItem Value="1977" Text="1977" />
 <telerik:RadComboBoxItem Value="1978" Text="1978" />
 <telerik:RadComboBoxItem Value="1979" Text="1979" />
 <telerik:RadComboBoxItem Value="1980" Text="1980" />
 <telerik:RadComboBoxItem Value="1981" Text="1981" />
 <telerik:RadComboBoxItem Value="1982" Text="1982" />
 <telerik:RadComboBoxItem Value="1983" Text="1983" />
 <telerik:RadComboBoxItem Value="1984" Text="1984" />
 <telerik:RadComboBoxItem Value="1985" Text="1985" />
 <telerik:RadComboBoxItem Value="1986" Text="1986" />
 <telerik:RadComboBoxItem Value="1987" Text="1987" />
 <telerik:RadComboBoxItem Value="1988" Text="1988" />
 <telerik:RadComboBoxItem Value="1989" Text="1989" />
 <telerik:RadComboBoxItem Value="1990" Selected="True" Text="1990" />
 <telerik:RadComboBoxItem Value="1991" Text="1991" />
 <telerik:RadComboBoxItem Value="1992" Text="1992" />
 <telerik:RadComboBoxItem Value="1993" Text="1993" />
 <telerik:RadComboBoxItem Value="1994" Text="1994" />
 <telerik:RadComboBoxItem Value="1995" Text="1995" />
 <telerik:RadComboBoxItem Value="1996" Text="1996" />
 <telerik:RadComboBoxItem Value="1997" Text="1997" />
 <telerik:RadComboBoxItem Value="1998" Text="1998" />
 <telerik:RadComboBoxItem Value="1999"  Text="1999" />
 <telerik:RadComboBoxItem Value="2000" Text="2000" />
 <telerik:RadComboBoxItem Value="2001"  Text="2001" />
 <telerik:RadComboBoxItem Value="2002"  Text="2002" />
  <telerik:RadComboBoxItem Value="2003"  Text="2003" />
   <telerik:RadComboBoxItem Value="2004"  Text="2004" />
    <telerik:RadComboBoxItem Value="2005"  Text="2005" />
 <telerik:RadComboBoxItem Value="2006"  Text="2006" />
 <telerik:RadComboBoxItem Value="2007"  Text="2007" />
  <telerik:RadComboBoxItem Value="2008"  Text="2008" />
   <telerik:RadComboBoxItem Value="2009"  Text="2009" />
    <telerik:RadComboBoxItem Value="2010"  Text="2010" />
  
 </Items>
</telerik:RadComboBox> *
             
												
											   
             
												
											</li>
                                            <li>
                                            <asp:Label runat="server" ID="gender" AssociatedControlID="gen" Text="Gender"> </asp:Label>
                                            <telerik:RadComboBox MarkFirstMatch="true" Width="200px" id="gen" runat="server" Text="" Filter="StartsWith" Skin="Office2007">
                                            <Items>
<telerik:RadComboBoxItem Value=""  Selected="true" Text="Select Gender" /> 
<telerik:RadComboBoxItem Value="M" Text="Male" /> 
<telerik:RadComboBoxItem Value="Fe" Text="Female" /> 
 </Items>
</telerik:RadComboBox> *
                                            
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                    ControlToValidate="gen" ErrorMessage="Gender Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                            
                                            </li><li>
												<asp:Label runat="server" ID="Label4" AssociatedControlID="country" Text="Country :"> </asp:Label>
												<telerik:RadComboBox MarkFirstMatch="true" Width="200px" id="Country" runat="server" Filter="StartsWith" Skin="Office2007">
                                            <Items>
<telerik:RadComboBoxItem Value=""  Selected=true Text="Select Country" /> 
<telerik:RadComboBoxItem Value="AF" Text="Afghanistan" /> 
<telerik:RadComboBoxItem Value="AL" Text="Albania" /> 
<telerik:RadComboBoxItem Value="DZ" Text="Algeria" /> 
<telerik:RadComboBoxItem Value="AS" Text="American Samoa" /> 
<telerik:RadComboBoxItem Value="AD" Text="Andorra" /> 
<telerik:RadComboBoxItem Value="AO" Text="Angola" /> 
<telerik:RadComboBoxItem Value="AI" Text="Anguilla" /> 
<telerik:RadComboBoxItem Value="AQ" Text="Antarctica" /> 
<telerik:RadComboBoxItem Value="AG" Text="Antigua And Barbuda" /> 
<telerik:RadComboBoxItem Value="AR" Text="Argentina" /> 
<telerik:RadComboBoxItem Value="AM" Text="Armenia" /> 
<telerik:RadComboBoxItem Value="AW" Text="Aruba" /> 
<telerik:RadComboBoxItem Value="AU" Text="Australia" /> 
<telerik:RadComboBoxItem Value="AT" Text="Austria" /> 
<telerik:RadComboBoxItem Value="AZ" Text="Azerbaijan" /> 
<telerik:RadComboBoxItem Value="BS" Text="Bahamas" /> 
<telerik:RadComboBoxItem Value="BH" Text="Bahrain" /> 
<telerik:RadComboBoxItem Value="BD" Text="Bangladesh" /> 
<telerik:RadComboBoxItem Value="BB" Text="Barbados" /> 
<telerik:RadComboBoxItem Value="BY" Text="Belarus" /> 
<telerik:RadComboBoxItem Value="BE" Text="Belgium" /> 
<telerik:RadComboBoxItem Value="BZ" Text="Belize" /> 
<telerik:RadComboBoxItem Value="BJ" Text="Benin" /> 
<telerik:RadComboBoxItem Value="BM" Text="Bermuda" /> 
<telerik:RadComboBoxItem Value="BT" Text="Bhutan" /> 
<telerik:RadComboBoxItem Value="BO" Text="Bolivia" /> 
<telerik:RadComboBoxItem Value="BA" Text="Bosnia And Herzegowina" /> 
<telerik:RadComboBoxItem Value="BW" Text="Botswana" /> 
<telerik:RadComboBoxItem Value="BV" Text="Bouvet Island" /> 
<telerik:RadComboBoxItem Value="BR" Text="Brazil" /> 
<telerik:RadComboBoxItem Value="IO" Text="British Indian Ocean Territory" /> 
<telerik:RadComboBoxItem Value="BN" Text="Brunei Darussalam" /> 
<telerik:RadComboBoxItem Value="BG" Text="Bulgaria" /> 
<telerik:RadComboBoxItem Value="BF" Text="Burkina Faso" /> 
<telerik:RadComboBoxItem Value="BI" Text="Burundi" /> 
<telerik:RadComboBoxItem Value="KH" Text="Cambodia" /> 
<telerik:RadComboBoxItem Value="CM" Text="Cameroon" /> 
<telerik:RadComboBoxItem Value="CA" Text="Canada" /> 
<telerik:RadComboBoxItem Value="CV" Text="Cape Verde" /> 
<telerik:RadComboBoxItem Value="KY" Text="Cayman Islands" /> 
<telerik:RadComboBoxItem Value="CF" Text="Central African Republic" /> 
<telerik:RadComboBoxItem Value="TD" Text="Chad" /> 
<telerik:RadComboBoxItem Value="CL" Text="Chile" /> 
<telerik:RadComboBoxItem Value="CN" Text="China" /> 
<telerik:RadComboBoxItem Value="CX" Text="Christmas Island" /> 
<telerik:RadComboBoxItem Value="CC" Text="Cocos (Keeling) Islands" /> 
<telerik:RadComboBoxItem Value="CO" Text="Colombia" /> 
<telerik:RadComboBoxItem Value="KM" Text="Comoros" /> 
<telerik:RadComboBoxItem Value="CG" Text="Congo" /> 
<telerik:RadComboBoxItem Value="CK" Text="Cook Islands" /> 
<telerik:RadComboBoxItem Value="CR" Text="Costa Rica" /> 
<telerik:RadComboBoxItem Value="CI" Text="Cote D'Ivoire" /> 
<telerik:RadComboBoxItem Value="HR" Text="Croatia (Local Name: Hrvatska)" /> 
<telerik:RadComboBoxItem Value="CU" Text="Cuba" /> 
<telerik:RadComboBoxItem Value="CY" Text="Cyprus" /> 
<telerik:RadComboBoxItem Value="CZ" Text="Czech Republic" /> 
<telerik:RadComboBoxItem Value="DK" Text="Denmark" /> 
<telerik:RadComboBoxItem Value="DJ" Text="Djibouti" /> 
<telerik:RadComboBoxItem Value="DM" Text="Dominica" /> 
<telerik:RadComboBoxItem Value="DO" Text="Dominican Republic" /> 
<telerik:RadComboBoxItem Value="TP" Text="East Timor" /> 
<telerik:RadComboBoxItem Value="EC" Text="Ecuador" /> 
<telerik:RadComboBoxItem Value="EG" Text="Egypt" /> 
<telerik:RadComboBoxItem Value="SV" Text="El Salvador" /> 
<telerik:RadComboBoxItem Value="GQ" Text="Equatorial Guinea" /> 
<telerik:RadComboBoxItem Value="ER" Text="Eritrea" /> 
<telerik:RadComboBoxItem Value="EE" Text="Estonia" /> 
<telerik:RadComboBoxItem Value="ET" Text="Ethiopia" /> 
<telerik:RadComboBoxItem Value="FK" Text="Falkland Islands (Malvinas)" /> 
<telerik:RadComboBoxItem Value="FO" Text="Faroe Islands" /> 
<telerik:RadComboBoxItem Value="FJ" Text="Fiji" /> 
<telerik:RadComboBoxItem Value="FI" Text="Finland" /> 
<telerik:RadComboBoxItem Value="FR" Text="France" /> 
<telerik:RadComboBoxItem Value="GF" Text="French Guiana" /> 
<telerik:RadComboBoxItem Value="PF" Text="French Polynesia" /> 
<telerik:RadComboBoxItem Value="TF" Text="French Southern Territories" /> 
<telerik:RadComboBoxItem Value="GA" Text="Gabon" /> 
<telerik:RadComboBoxItem Value="GM" Text="Gambia" /> 
<telerik:RadComboBoxItem Value="GE" Text="Georgia" /> 
<telerik:RadComboBoxItem Value="DE" Text="Germany" /> 
<telerik:RadComboBoxItem Value="GH" Text="Ghana" /> 
<telerik:RadComboBoxItem Value="GI" Text="Gibraltar" /> 
<telerik:RadComboBoxItem Value="GR" Text="Greece" /> 
<telerik:RadComboBoxItem Value="GL" Text="Greenland" /> 
<telerik:RadComboBoxItem Value="GD" Text="Grenada" /> 
<telerik:RadComboBoxItem Value="GP" Text="Guadeloupe" /> 
<telerik:RadComboBoxItem Value="GU" Text="Guam" /> 
<telerik:RadComboBoxItem Value="GT" Text="Guatemala" /> 
<telerik:RadComboBoxItem Value="GN" Text="Guinea" /> 
<telerik:RadComboBoxItem Value="GW" Text="Guinea-Bissau" /> 
<telerik:RadComboBoxItem Value="GY" Text="Guyana" /> 
<telerik:RadComboBoxItem Value="HT" Text="Haiti" /> 
<telerik:RadComboBoxItem Value="HM" Text="Heard And Mc Donald Islands" /> 
<telerik:RadComboBoxItem Value="VA" Text="Holy See (Vatican City State)" /> 
<telerik:RadComboBoxItem Value="HN" Text="Honduras" /> 
<telerik:RadComboBoxItem Value="HK" Text="Hong Kong" /> 
<telerik:RadComboBoxItem Value="HU" Text="Hungary" /> 
<telerik:RadComboBoxItem Value="IS" Text="Icel And" /> 
<telerik:RadComboBoxItem Value="IN" Text="India" /> 
<telerik:RadComboBoxItem Value="ID" Text="Indonesia" /> 
<telerik:RadComboBoxItem Value="IR" Text="Iran (Islamic Republic Of)" /> 
<telerik:RadComboBoxItem Value="IQ" Text="Iraq" /> 
<telerik:RadComboBoxItem Value="IE" Text="Ireland" /> 
<telerik:RadComboBoxItem Value="IL" Text="Israel" /> 
<telerik:RadComboBoxItem Value="IT" Text="Italy" /> 
<telerik:RadComboBoxItem Value="JM" Text="Jamaica" /> 
<telerik:RadComboBoxItem Value="JP" Text="Japan" /> 
<telerik:RadComboBoxItem Value="JO" Text="Jordan" /> 
<telerik:RadComboBoxItem Value="KZ" Text="Kazakhstan" /> 
<telerik:RadComboBoxItem Value="KE" Text="Kenya" /> 
<telerik:RadComboBoxItem Value="KI" Text="Kiribati" /> 
<telerik:RadComboBoxItem Value="KP" Text="Korea, Dem People'S Republic" /> 
<telerik:RadComboBoxItem Value="KR" Text="Korea, Republic Of" /> 
<telerik:RadComboBoxItem Value="KW" Text="Kuwait" /> 
<telerik:RadComboBoxItem Value="KG" Text="Kyrgyzstan" /> 
<telerik:RadComboBoxItem Value="LA" Text="Lao People'S Dem Republic" /> 
<telerik:RadComboBoxItem Value="LV" Text="Latvia" /> 
<telerik:RadComboBoxItem Value="LB" Text="Lebanon" /> 
<telerik:RadComboBoxItem Value="LS" Text="Lesotho" /> 
<telerik:RadComboBoxItem Value="LR" Text="Liberia" /> 
<telerik:RadComboBoxItem Value="LY" Text="Libyan Arab Jamahiriya" /> 
<telerik:RadComboBoxItem Value="LI" Text="Liechtenstein" /> 
<telerik:RadComboBoxItem Value="LT" Text="Lithuania" /> 
<telerik:RadComboBoxItem Value="LU" Text="Luxembourg" /> 
<telerik:RadComboBoxItem Value="MO" Text="Macau" /> 
<telerik:RadComboBoxItem Value="MK" Text="Macedonia" /> 
<telerik:RadComboBoxItem Value="MG" Text="Madagascar" /> 
<telerik:RadComboBoxItem Value="MW" Text="Malawi" /> 
<telerik:RadComboBoxItem Value="MY" Text="Malaysia" /> 
<telerik:RadComboBoxItem Value="MV" Text="Maldives" /> 
<telerik:RadComboBoxItem Value="ML" Text="Mali" /> 
<telerik:RadComboBoxItem Value="MT" Text="Malta" /> 
<telerik:RadComboBoxItem Value="MH" Text="Marshall Islands" /> 
<telerik:RadComboBoxItem Value="MQ" Text="Martinique" /> 
<telerik:RadComboBoxItem Value="MR" Text="Mauritania" /> 
<telerik:RadComboBoxItem Value="MU" Text="Mauritius" /> 
<telerik:RadComboBoxItem Value="YT" Text="Mayotte" /> 
<telerik:RadComboBoxItem Value="MX" Text="Mexico" /> 
<telerik:RadComboBoxItem Value="FM" Text="Micronesia, Federated States" /> 
<telerik:RadComboBoxItem Value="MD" Text="Moldova, Republic Of" /> 
<telerik:RadComboBoxItem Value="MC" Text="Monaco" /> 
<telerik:RadComboBoxItem Value="MN" Text="Mongolia" /> 
<telerik:RadComboBoxItem Value="MS" Text="Montserrat" /> 
<telerik:RadComboBoxItem Value="MA" Text="Morocco" /> 
<telerik:RadComboBoxItem Value="MZ" Text="Mozambique" /> 
<telerik:RadComboBoxItem Value="MM" Text="Myanmar" /> 
<telerik:RadComboBoxItem Value="NA" Text="Namibia" /> 
<telerik:RadComboBoxItem Value="NR" Text="Nauru" /> 
<telerik:RadComboBoxItem Value="NP" Text="Nepal" /> 
<telerik:RadComboBoxItem Value="NL" Text="Netherlands" /> 
<telerik:RadComboBoxItem Value="AN" Text="Netherlands Ant Illes" /> 
<telerik:RadComboBoxItem Value="NC" Text="New Caledonia" /> 
<telerik:RadComboBoxItem Value="NZ" Text="New Zealand" /> 
<telerik:RadComboBoxItem Value="NI" Text="Nicaragua" /> 
<telerik:RadComboBoxItem Value="NE" Text="Niger" /> 
<telerik:RadComboBoxItem Value="NG" Text="Nigeria" /> 
<telerik:RadComboBoxItem Value="NU" Text="Niue" /> 
<telerik:RadComboBoxItem Value="NF" Text="Norfolk Island" /> 
<telerik:RadComboBoxItem Value="MP" Text="Northern Mariana Islands" /> 
<telerik:RadComboBoxItem Value="NO" Text="Norway" /> 
<telerik:RadComboBoxItem Value="OM" Text="Oman" /> 
<telerik:RadComboBoxItem Value="PK" Text="Pakistan" /> 
<telerik:RadComboBoxItem Value="PW" Text="Palau" /> 
<telerik:RadComboBoxItem Value="PA" Text="Panama" /> 
<telerik:RadComboBoxItem Value="PG" Text="Papua New Guinea" /> 
<telerik:RadComboBoxItem Value="PY" Text="Paraguay" /> 
<telerik:RadComboBoxItem Value="PE" Text="Peru" /> 
<telerik:RadComboBoxItem Value="PH" Text="Philippines" /> 
<telerik:RadComboBoxItem Value="PN" Text="Pitcairn" /> 
<telerik:RadComboBoxItem Value="PL" Text="Poland" /> 
<telerik:RadComboBoxItem Value="PT" Text="Portugal" /> 
<telerik:RadComboBoxItem Value="PR" Text="Puerto Rico" /> 
<telerik:RadComboBoxItem Value="QA" Text="Qatar" /> 
<telerik:RadComboBoxItem Value="RE" Text="Reunion" /> 
<telerik:RadComboBoxItem Value="RO" Text="Romania" /> 
<telerik:RadComboBoxItem Value="RU" Text="Russian Federation" /> 
<telerik:RadComboBoxItem Value="RW" Text="Rwanda" /> 
<telerik:RadComboBoxItem Value="KN" Text="Saint K Itts And Nevis" /> 
<telerik:RadComboBoxItem Value="LC" Text="Saint Lucia" /> 
<telerik:RadComboBoxItem Value="VC" Text="Saint Vincent, The Grenadines" /> 
<telerik:RadComboBoxItem Value="WS" Text="Samoa" /> 
<telerik:RadComboBoxItem Value="SM" Text="San Marino" /> 
<telerik:RadComboBoxItem Value="ST" Text="Sao Tome And Principe" /> 
<telerik:RadComboBoxItem Value="SA" Text="Saudi Arabia" /> 
<telerik:RadComboBoxItem Value="SN" Text="Senegal" /> 
<telerik:RadComboBoxItem Value="SC" Text="Seychelles" /> 
<telerik:RadComboBoxItem Value="SL" Text="Sierra Leone" /> 
<telerik:RadComboBoxItem Value="SG" Text="Singapore" /> 
<telerik:RadComboBoxItem Value="SK" Text="Slovakia (Slovak Republic)" /> 
<telerik:RadComboBoxItem Value="SI" Text="Slovenia" /> 
<telerik:RadComboBoxItem Value="SB" Text="Solomon Islands" /> 
<telerik:RadComboBoxItem Value="SO" Text="Somalia" /> 
<telerik:RadComboBoxItem Value="ZA" Text="South Africa" /> 
<telerik:RadComboBoxItem Value="GS" Text="South Georgia , S Sandwich Is." /> 
<telerik:RadComboBoxItem Value="ES" Text="Spain" /> 
<telerik:RadComboBoxItem Value="LK" Text="Sri Lanka" /> 
<telerik:RadComboBoxItem Value="SH" Text="St. Helena" /> 
<telerik:RadComboBoxItem Value="PM" Text="St. Pierre And Miquelon" /> 
<telerik:RadComboBoxItem Value="SD" Text="Sudan" /> 
<telerik:RadComboBoxItem Value="SR" Text="Suriname" /> 
<telerik:RadComboBoxItem Value="SJ" Text="Svalbard, Jan Mayen Islands" /> 
<telerik:RadComboBoxItem Value="SZ" Text="Sw Aziland" /> 
<telerik:RadComboBoxItem Value="SE" Text="Sweden" /> 
<telerik:RadComboBoxItem Value="CH" Text="Switzerland" /> 
<telerik:RadComboBoxItem Value="SY" Text="Syrian Arab Republic" /> 
<telerik:RadComboBoxItem Value="TW" Text="Taiwan" /> 
<telerik:RadComboBoxItem Value="TJ" Text="Tajikistan" /> 
<telerik:RadComboBoxItem Value="TZ" Text="Tanzania, United Republic Of" /> 
<telerik:RadComboBoxItem Value="TH" Text="Thailand" /> 
<telerik:RadComboBoxItem Value="TG" Text="Togo" /> 
<telerik:RadComboBoxItem Value="TK" Text="Tokelau" /> 
<telerik:RadComboBoxItem Value="TO" Text="Tonga" /> 
<telerik:RadComboBoxItem Value="TT" Text="Trinidad And Tobago" /> 
<telerik:RadComboBoxItem Value="TN" Text="Tunisia" /> 
<telerik:RadComboBoxItem Value="TR" Text="Turkey" /> 
<telerik:RadComboBoxItem Value="TM" Text="Turkmenistan" /> 
<telerik:RadComboBoxItem Value="TC" Text="Turks And Caicos Islands" /> 
<telerik:RadComboBoxItem Value="TV" Text="Tuvalu" /> 
<telerik:RadComboBoxItem Value="UG" Text="Uganda" /> 
<telerik:RadComboBoxItem Value="UA" Text="Ukraine" /> 
<telerik:RadComboBoxItem Value="AE" Text="United Arab Emirates" /> 
<telerik:RadComboBoxItem Value="GB" Text="United Kingdom" /> 
<telerik:RadComboBoxItem Value="US" Text="United States" /> 
<telerik:RadComboBoxItem Value="UM" Text="United States Minor Is." /> 
<telerik:RadComboBoxItem Value="UY" Text="Uruguay" /> 
<telerik:RadComboBoxItem Value="UZ" Text="Uzbekistan" /> 
<telerik:RadComboBoxItem Value="VU" Text="Vanuatu" /> 
<telerik:RadComboBoxItem Value="VE" Text="Venezuela" /> 
<telerik:RadComboBoxItem Value="VN" Text="Viet Nam" /> 
<telerik:RadComboBoxItem Value="VG" Text="Virgin Islands (British)" /> 
<telerik:RadComboBoxItem Value="VI" Text="Virgin Islands (U.S.)" /> 
<telerik:RadComboBoxItem Value="WF" Text="Wallis And Futuna Islands" /> 
<telerik:RadComboBoxItem Value="EH" Text="Western Sahara" /> 
<telerik:RadComboBoxItem Value="YE" Text="Yemen" /> 
<telerik:RadComboBoxItem Value="YU" Text="Yugoslavia" /> 
<telerik:RadComboBoxItem Value="ZR" Text="Zaire" /> 
<telerik:RadComboBoxItem Value="ZM" Text="Zambia" /> 
<telerik:RadComboBoxItem Value="ZW" Text="Zimbabwe" /> </Items>
</telerik:RadComboBox> *
												
												
											    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                    ControlToValidate="Country" ErrorMessage="Country Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
												
												
											</li>
                                            
											<li>
                        <table>
                        <tr>
                        <td valign="top">
                        <asp:Label runat="server" ID="Label7">Are You A Bot ?</asp:Label>
                        
                        </td>
                        <td>
                        <telerik:RadCaptcha ID="RadCaptcha1" ErrorMessage="Invalid Captcha , Please Enter the Captcha Again" ForeColor="Red" Runat="server" CaptchaImage-TextLength="2" ValidationGroup="urvashi">
    </telerik:RadCaptcha>
    
                        </td></tr>
                        
                        </table>
                        
                        
                        
                        



						
    
    
    </li>
											

											
										</ul>
										<br />
										<asp:Button runat="server" ID="nextButton" CssClass="twittertypebutp2"  Text="Register On Friendyoke.com"
											 style="margin-left:613px;"  OnClick="nextButton2_Click" />
                                             <asp:Label style="width: 93px; height: 25px; margin-left:503px; font: normal 12px Arial, sans-serif;" runat="server" ID="errorr" Visible="false" ForeColor="Red" ></asp:Label><br />
										<br />
									</div>
   
        </ItemTemplate>
        </telerik:RadPanelItem>
        </Items>
        </telerik:RadPanelItem>
        

        

    </Items>
</telerik:RadPanelBar><asp:Label runat="server" ID="chita" Visible="false"></asp:Label>
               </td>
                </tr>
                </table>  </div>
                
                </asp:Panel>
        <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="some">
                                </asp:RoundedCornersExtender>
         
                   
</div>       
    </td>
    </tr>
    <tr>
    <td valign="top" class="style1" colspan="2"></td>
    </tr>
    
    </table> </form>
    </body>
</html>
