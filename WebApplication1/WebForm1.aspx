<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Title</title>
    <link rel="stylesheet" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" /> 
         <h1><div align="center"> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
            <ContentTemplate > 
                <asp:Timer ID="Timer1" runat="server" Interval="999"> 
                </asp:Timer>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 
            </ContentTemplate> 
            </asp:UpdatePanel>
    </div></h1>

    </form>

</body>
</html>
