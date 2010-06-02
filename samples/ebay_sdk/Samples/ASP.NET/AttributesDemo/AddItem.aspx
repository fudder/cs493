<%@ Page language="c#" Inherits="Attributes.AddItem" CodeFile="AddItem.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddItem</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<table cellSpacing="2" cellPadding="2" width="700" align="center" border="0">
				<tr style="FONT-WEIGHT: bold; FONT-SIZE: large; COLOR: #000099">
					Specify information&nbsp;for your item
				</tr>
				<tr>
					&nbsp;
				</tr>
				<tr>
					<asp:label id="Label1" runat="server">Currency: </asp:label><asp:label id="Currency" runat="server"></asp:label></tr>
				<tr>
					<td width="10%">Title:</td>
					<td><asp:textbox id="ItemTitle" runat="server">SDK Item</asp:textbox></td>
					<td>Location:</td>
					<td><asp:textbox id="ItemLocation" runat="server" Width="259px">San Jose, CA</asp:textbox></td>
				</tr>
				<TR>
					<td>Description:</td>
					<td colSpan="3"><asp:textbox id="Description" runat="server" Height="88px" Width="564">Description of item.</asp:textbox></td>
				<tr>
				</tr>
			</table>
			<table cellSpacing="2" cellPadding="2" width="700" align="center" border="0">
				<tr>
					<td width="50%">
						<table>
							<tr>
								<td style="WIDTH: 72px">StartPrice:</td>
								<td><asp:textbox id="StartPrice" runat="server" Width="99px">2.0</asp:textbox></td>
							</tr>
						</table>
					</td>
					<td>
						<table>
							<tr>
								<td>BuyItNow Price:</td>
								<td><asp:textbox id="BuyItNowPrice" runat="server" Width="99px">10.0</asp:textbox>(optional)</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table>
							<tr>
								<td style="WIDTH: 72px">listing type:</td>
								<td><asp:dropdownlist id="ddlListingType" runat="server" AutoPostBack="True" onselectedindexchanged="ddlListingType_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
					<td>
						<table>
							<tr>
								<td style="WIDTH: 104px">Duration:</td>
								<td><asp:dropdownlist id="ItemDuration" runat="server" Width="107px"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table>
							<tr>
								<td style="WIDTH: 72px">Quantity</td>
								<td><asp:textbox id="Quantity" runat="server" Width="97px">1</asp:textbox></td>
							</tr>
						</table>
					</td>
					<td>
						<table>
							<tr>
								<td style="WIDTH: 98px"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<table style="BACKGROUND-COLOR: #ccffff" width="100%">
							<tr>
								<td><b>Motor Specifics</b>
								</td>
							</tr>
							<tr>
								<td width="50%"><asp:label id="Label2" runat="server">Subtitle:</asp:label>&nbsp;
									<asp:textbox id="MotorSubtitle" runat="server"></asp:textbox></td>
								<td><asp:label id="Label3" runat="server">Deposit Amount:</asp:label>&nbsp; &nbsp;
									<asp:textbox id="MotorDepositAmount" runat="server"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table cellSpacing="2" cellPadding="2" width="700" align="center" border="0">
				<tr>
					<td colSpan="2">
						<h2>Shipping Service</h2>
					</td>
				</tr>
				<tr>
					<td colSpan="2"><asp:dropdownlist id="ddlShippingServiceDetails" AutoPostBack="False" Runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td colSpan="2">
						<h2>Ship to Locations:</h2>
					</td>
				</tr>
				<tr>
					<td colSpan="2"><asp:checkboxlist id="cblLocation" runat="server" RepeatColumns="1"></asp:checkboxlist></td>
				</tr>
			</table>
			<table cellSpacing="2" cellPadding="2" width="700" align="center" border="0">
				<tr>
					<td colSpan="2">
						<h2>Payment Method</h2>
					</td>
				</tr>
				<tr>
					<td colSpan="2"><asp:checkboxlist id="cblPaymentMethod" runat="server" RepeatColumns="5"></asp:checkboxlist></td>
				</tr>
				<tr>
					<td colSpan="2">Please specify the Paypal Email:<asp:TextBox ID="txtPaypalAccount" Runat="server"></asp:TextBox>
					</td>
				</tr>
			</table>
			<asp:panel id="pnlReturnPolicy" runat="server">
				<TABLE cellSpacing="2" cellPadding="2" width="700" align="center" border="0">
					<TR>
						<TD colSpan="2">
							<H2>Return Policy</H2>
						</TD>
					</TR>
					<TR>
						<TD><asp:Literal id="ltlReturnAccepted" runat="server" Text="Return accepted:"></asp:Literal>
							<asp:DropDownList id="ddlReturnAccepted" AutoPostBack="False" Runat="server"></asp:DropDownList></TD>
					</tr>
					<TR>
						<TD><asp:Literal id="ltlRefund" runat="server" Text="Refund type:"></asp:Literal>
							<asp:dropdownlist id="ddlRefund" AutoPostBack="False" Runat="server"></asp:dropdownlist>
							</TD>
					</tr>
					<tr>
						<TD><asp:Literal id="ltlReturnWithin" runat="server" Text="Return within:"></asp:Literal>
							<asp:DropDownList id="ddlReturnWithin" AutoPostBack="False" Runat="server"></asp:DropDownList></TD>
					</TR>
					<tr>
						<TD><asp:Literal id="ltlShippingPaidBy" runat="server" Text="Shipping cost paid By:"></asp:Literal>
							<asp:DropDownList id="ddlShippingCostPaidBy" AutoPostBack="False" Runat="server"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>Description:</TD>
						<TD colSpan="3"></TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:TextBox id="txtReturnPolicyDescription" Width="688px" Height="96px" Runat="server"></asp:TextBox></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<table cellSpacing="2" cellPadding="2" width="700" align="center" border="0">
				<tr>
					<td><asp:button id="BtnAddItem" runat="server" Text="List Item to eBay" onclick="BtnAddItem_Click"></asp:button></td>
					<td></td>
				</tr>
				<tr>
					<td><asp:label id="StatusText" runat="server" Width="357px" ForeColor="Red"></asp:label><asp:Literal ID="ltlReturnPolicyEnalbed" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
