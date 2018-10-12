<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="CourseList.aspx.cs" Inherits="LiberalStudies.CourseList" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
			<br />
        	Search:
			<asp:TextBox ID="txtSearch" runat="server" Height="16px" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged" Font-Names="Arial" Width="103px" EnableTheming="False"></asp:TextBox><span style="listbox">
			<asp:CheckBoxList ID="cblCategories" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="txtSearch_TextChanged" CssClass="listbox" style="margin-top: 0px; margin-bottom: 0px;" BorderStyle="None" Height="12px">
			</asp:CheckBoxList>
			<asp:Table ID="Table1" runat="server"  BorderStyle="None" ForeColor="Black" GridLines="Both" ValidateRequestMode="Disabled" style="margin-top: 0px">
			<asp:TableRow BackColor="#007055">
			<asp:TableCell Font-Bold="True" Font-Names="Arial" ForeColor="White" HorizontalAlign="Center">Course Name</asp:TableCell>
			<asp:TableCell Font-Bold="True" Font-Italic="False" Font-Names="Arial" ForeColor="White" HorizontalAlign="Center">Course Number</asp:TableCell>
			<asp:TableCell Font-Bold="True" Font-Names="Arial" ForeColor="White" HorizontalAlign="Center">Categories</asp:TableCell>
			<asp:TableCell Font-Bold="True" Font-Names="Arial" ForeColor="White" HorizontalAlign="Center">Course Description</asp:TableCell>
			</asp:TableRow> 
				<asp:TableRow runat="server" BackColor="#DAE9DC" EnableTheming="True" Font-Names="Arial">
				</asp:TableRow>
			</asp:Table></br>
	 <input type="button" name="addCourse" value="Add Course" onclick="openWindow(event, './UpdateCourse.aspx')"/></span><br />
&nbsp;&nbsp;
	 &nbsp;</asp:Content>

