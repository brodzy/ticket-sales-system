<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="summary.aspx.cs" Inherits="ticket_sales_system.summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Summary</title>
    <link href="styles.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="529px" Width="771px">
            <h2><asp:Label ID="Label1" runat="server" Text="Ticket Holders for"></asp:Label>
            <asp:Label ID="eventNamelbl" runat="server" ForeColor="Red"></asp:Label></h2>
            <table>
            <tr>
                <td>
                    <asp:Button ID="purchaseMoreBtn" runat="server" Text="Purchase More Tickets" Width="173px" OnClick="purchaseMoreBtn_Click" />
                </td>
                <td class="auto-style1">
                    <asp:Label ID="sortLbl" Text="Sort:" runat="server" ></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:RadioButtonList repeatdirection="Horizontal" ID="sortRadioList" runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True">Order Purchased</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Seat</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            </table>
            <asp:Label ID="Label2" runat="server" Text="Remove Ticket Holder"></asp:Label>
                <asp:DropDownList ID="ddlTicketHolders" runat="server" Width="187px">
                </asp:DropDownList>
                <asp:Button ID="rmvBtn" runat="server" Text="Remove" OnClick="rmvBtn_Click" />
                <br />
                <br />
                <asp:TextBox ID="displayTxtBox" runat="server" Height="383px" Width="503px" TextMode="MultiLine"></asp:TextBox>
            </asp:Panel>
        </div>

    </form>
</body>
</html>
