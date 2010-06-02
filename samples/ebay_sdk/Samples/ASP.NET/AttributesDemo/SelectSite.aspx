<%@ Page language="c#" Inherits="Attributes.SelectSite" CodeFile="SelectSite.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SelectSite</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<table cellSpacing="2" cellPadding="0" width="480" align="center" border="0">
				<TR>
					<TD><IMG src="images/ebay.gif"></TD>
					&nbsp;
					<TD></TD>
					<TD><B><FONT size="5">Attributes Sample Application</FONT></B></TD>
				</TR>
				<tr>
					<td></td>
					<td></td>
					<td style="FONT-SIZE: x-small; COLOR: blue; FONT-STYLE: italic; FONT-FAMILY: Tahoma">--- 
						Based on eBay .NET SDK 
						<asp:Label id="VersionLabel" runat="server">Version</asp:Label></td>
				</tr>
			</table>
			<br>
			<table cellSpacing="8" cellPadding="0" width="480" align="center" border="0">
				<TR>
					<TD>Select the site to which you want to list your item then continue.</TD>
				</TR>
				<TR>
					<TD><asp:dropdownlist id="ddlEbaySite" runat="server" Width="196px">
							<asp:ListItem Value="eBayMotors" Selected="True">eBayMotors</asp:ListItem>
							<asp:ListItem Value="US">US</asp:ListItem>
							<asp:ListItem Value="Canada">Canada</asp:ListItem>
							<asp:ListItem Value="UnitedKingdom">UnitedKingdom</asp:ListItem>
							<asp:ListItem Value="Australia">Australia</asp:ListItem>
							<asp:ListItem Value="Austria">Austria</asp:ListItem>
							<asp:ListItem Value="BelgiumFrench">BelgiumFrench</asp:ListItem>
							<asp:ListItem Value="France">France</asp:ListItem>
							<asp:ListItem Value="Germany">Germany</asp:ListItem>
							<asp:ListItem Value="Italy">Italy</asp:ListItem>
							<asp:ListItem Value="BelgiumDutch">BelgiumDutch</asp:ListItem>
							<asp:ListItem Value="Netherlands">Netherlands</asp:ListItem>
							<asp:ListItem Value="Spain">Spain</asp:ListItem>
							<asp:ListItem Value="Switzerland">Switzerland</asp:ListItem>
							<asp:ListItem Value="Taiwan">Taiwan</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						Enter category or leave blank to download categories and pick:</TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD><asp:button id="Continue" runat="server" Width="91px" Text="Continue" onclick="Continue_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
