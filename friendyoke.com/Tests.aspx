<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Tests.aspx.cs" Debug="true" Inherits="Tests" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



























<%@ Register src="~/Menu/profilec/albums.ascx" tagname="follow" tagprefix="uc1" %>



























<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<link rel="stylesheet" type="text/css" href="lib/Style.css"/>
<body>
    <form id="form1" runat="server" >
    <telerik:RadScriptManager
        ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    
    
    
    
    
    
    
    <br />
      
   
    
    
      
   
    
    
    
    <uc1:follow ID="follow1" runat="server" />
      
   
    
    
      
   
    
    
    
    </form>
</body>
</html>
