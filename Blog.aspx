<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Blog.aspx.vb" Inherits="Blog.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Jason Butler’s G2C Creation Blog!</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK REL="stylesheet" TYPE="text/css" HREF="styles.css">
		<LINK REL="Shortcut Icon" href="jason.ico">
	</HEAD>
	<BODY>
		<!--#include file="heading.txt"-->
		<form id="Form1" method="post" runat="server">
			<asp:datalist id="dlstBlog" runat="server" BorderStyle="None" ShowHeader="False" ShowFooter="False"
				Height="1px" Width="530px" RepeatColumns="1" CellPadding="4" DESIGNTIMEDRAGDROP="444">
				<AlternatingItemStyle BackColor="#E0E0E0"></AlternatingItemStyle>
				<ItemTemplate>
					<FONT CLASS="blogtitle">
						<%# Container.DataItem("TITLE")%>
					</FONT>
					<BR>
					<FONT CLASS="blogdate">
						<%# Container.DataItem("DATE")%>
					</FONT>
					<BR>
					<BR>
					<FONT CLASS="blogmessage">
					    <%# Replace(Replace(Container.DataItem("MESSAGE"), "{", "<"),"}",">")%>
					</FONT>
					<BR>
					<BR>
				</ItemTemplate>
			</asp:datalist>
			<P>&nbsp;
				<asp:Label id="lblCurrpage" runat="server" CssClass="normal" Height="8px" Width="56px">lblCurrpage</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:HyperLink id="lnkPrev" runat="server" CssClass="normal"><</asp:HyperLink>&nbsp;
				<asp:HyperLink id="lnkNext" runat="server" CssClass="normal">></asp:HyperLink></P>
		</form>
		<!--#include file="footer.txt"-->
	</BODY>
</HTML>
