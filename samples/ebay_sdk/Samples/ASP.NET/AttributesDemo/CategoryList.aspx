<%@ Page language="c#" Inherits="Attributes.CategoryList" CodeFile="CategoryList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CategoryList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		<!--
		function onChange(select)
		{
			//alert(select.selectedIndex);

			select.options[select.selectedIndex].selected = true;

			var cnt = 1;
			for(index=0; index<select.options.length; index++)
			{
				if (select.selectedIndex != index) {
					if(select.options[index].selected)
					{
						if (cnt >= 2)
						select.options[index].selected = false;
						cnt++;
					}
				}
			}
		}
		-->
		</script>
	</HEAD>
	<body>
		<form method="post" runat="server">
			<table border="0" align="center">
				<tr>
					<td><img src="images/ebay.gif"></td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td><b>First Category:</b></td>
					<td>&nbsp;</td>
					<td><b>Second Category:</b></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>
						<SELECT id="catId" name="catId" size="20" onChange="javascript:onChange(this)">
							<% addCategories(); %>
						</SELECT>
					</td>
					<td style="TABLE-LAYOUT:fixed" width="100">
					<td>
						<SELECT id="catId2" name="catId2" size="20" onChange="javascript:onChange(this)">
							<% addCategories(); %>
						</SELECT>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center" colspan="3">
						<asp:Button id="btSubmit" runat="server" Text="&nbsp;Next&nbsp;" onclick="btSubmit_Click"></asp:Button></td>
				</tr>
				<tr>
					<td colspan="3"><font color="red">
							<asp:Label ID="pageError" Runat="server"></asp:Label>
						</font>
					</td>
				</tr>
			</table>
			<br>
			<!--
			<input name="first" type="hidden" value="" /> <input name="second" type="hidden" value="" />
			-->
		</form>
	</body>
</HTML>
