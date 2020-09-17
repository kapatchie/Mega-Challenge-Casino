<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mega_Challenge_Casino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="leftImageReel" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="middleImageReel" runat="server" Height="150px" Width="150px" />
            <asp:Image ID="rightImageReel" runat="server" Height="150px" Width="150px" />
            <br />
            <br />
            Your Bet: <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull The  Lever" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            Player&#39;s Money <asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - 2X Your Bet<br />
            2 Cherries - 3X Your Bet<br />
            3 Cherries - 4X Your Bet<br />
            <br />
            3 7&#39;s - JackPot - 100X Your Bet<br />
            <br />
            Any Bar and you Loose</div>
    </form>
</body>
</html>
