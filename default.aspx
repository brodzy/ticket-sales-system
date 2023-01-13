<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ticket_sales_system._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ticket Sales System</title>
    <link href="styles.css" rel="stylesheet" />
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Ticket Sales System</h1>
            <a href="diagram.html">Class Diagram</a>
        </div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="Create Event" Height="170px" Width="781px">
            <asp:Label ID="Label1" runat="server" Text="Event Name: "></asp:Label>
            <asp:TextBox ID="eventBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Available Seat Numbers: "></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="First   "></asp:Label>
            <asp:TextBox ID="firstBox" runat="server" Width="23px"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Last  "></asp:Label>
            <asp:TextBox ID="lastBox" runat="server" Width="27px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="makeEventBtn" runat="server" Text="Make Event" Width="101px" OnClick="makeEventBtn_Click" />
            <asp:Button ID="startOverBtn" runat="server" Text="Start Over" Width="104px" OnClick="startOverBtn_Click" />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" GroupingText="Purchase Ticket" Height="440px" Width="780px">
            <asp:Label ID="Label5" runat="server" Text="Name "></asp:Label>
            <asp:TextBox ID="nameBox" runat="server" Width="174px"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Age "></asp:Label>
            <asp:TextBox ID="ageBox" runat="server" Width="28px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Pick seat, "></asp:Label>
            <asp:Label ID="seatAmnt" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="available"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="availableListBox" runat="server" Height="277px" Width="96px"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="purchaseBtn" runat="server" Text="Purchase" OnClick="purchaseBtn_Click" />
            <asp:Button ID="eventSummaryBtn" runat="server" Text="Event Summary" OnClick="eventSummaryBtn_Click" />
            <br />
            <br />
        </asp:Panel>
    </form>
</body>
</html>
