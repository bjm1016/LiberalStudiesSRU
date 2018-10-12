<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCourse.aspx.cs" Inherits="LiberalStudies.UpdateCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="lblCourseName" runat="server" Text="Course Name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtCourseName" runat="server" Width="125px"></asp:TextBox>
			<br />
			<br />
			<asp:Label ID="lblCourseCode" runat="server" Text="Course Code:"></asp:Label>
&nbsp;<asp:TextBox ID="txtCourseCode" runat="server" Width="125px"></asp:TextBox>
        	<br />
			<br />
			<br />
			<asp:Label ID="lblCourseCategories" runat="server" Text="Course Categories:" ToolTip="Course Categories:"></asp:Label>
			<asp:CheckBoxList ID="cblCourseCategories" runat="server">
				<asp:ListItem>The Arts</asp:ListItem>
				<asp:ListItem>Cultures, Discourse and Ideas</asp:ListItem>
				<asp:ListItem>Science, Technology, and Math</asp:ListItem>
				<asp:ListItem>Society and Institutions</asp:ListItem>
				<asp:ListItem>Self-Care and Well-Being</asp:ListItem>
				<asp:ListItem>Diversity and Global Understanding</asp:ListItem>
				<asp:ListItem>Civil Knowledge and Engagement</asp:ListItem>
				<asp:ListItem>Ethical Reasoning</asp:ListItem>
			</asp:CheckBoxList>
			<br />
			Tags:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTagAdd" runat="server"></asp:TextBox>
&nbsp;&nbsp;
			<asp:Button ID="btnAddTag" runat="server" Text="Add Tag" OnClick="btnAddTag_Click" />
			<br />
			<asp:CheckBoxList ID="cblTags" runat="server">
			</asp:CheckBoxList>
			<br />
			<br />
			Course Description:<br />
			<asp:TextBox ID="txtCourseDescription" runat="server" Height="215px" Width="625px" TextMode="MultiLine"></asp:TextBox>
			<br />
			<br />
			<br />
			<asp:Button ID="Submit" runat="server" Height="26px" OnClick="Submit_Click" Text="Button" />
        </div>
    	<p>
&nbsp;</p>
		<p>
			&nbsp;</p>
		<p>
			&nbsp;</p>
		<p>
			&nbsp;</p>
		<p>
			&nbsp;</p>
		<p>
			&nbsp;</p>
		<p>
			&nbsp;</p>
		<p>
			&nbsp;</p>
    </form>
</body>
</html>
