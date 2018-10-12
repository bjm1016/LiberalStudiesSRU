using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using util;
namespace LiberalStudies
{
	public partial class UpdateCourse : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, EventArgs e)
		{
			
			string CourseCode = Request.QueryString["CourseCode"];

			if (CourseCode != null)
			{
				course a = course.getCourseByCode(CourseCode);
				txtCourseName.Text = a.getCourseName();
				txtCourseCode.Text = a.getCourseCode();
				txtCourseDescription.Text = a.getCourseDescription();
				foreach(ListItem item in  cblCourseCategories.Items)
				{
					if(a.getCourseCategories().Contains(item.Text))
					{
						item.Selected = true;
					}
				}
				
				foreach(string s in a.getTags())
				{
					ListItem item = new ListItem(s, s, true);
					item.Selected = true;
					cblTags.Items.Add(item);
				}

			}
		}

		protected void Submit_Click(object sender, EventArgs e)
		{
			submitCourse();
		}
		private void submitCourse()
		{
			course c = new course();
			c.setCourseName(txtCourseName.Text);
			c.setCourseCode(txtCourseCode.Text);
			c.addTag(txtCourseCode.Text);
			c.addTag(txtCourseName.Text);
			c.setCourseDescription(txtCourseDescription.Text);
			foreach (ListItem listItem in cblCourseCategories.Items)
			{
				if (listItem.Selected)
				{
					c.addCategory(listItem.Value);
				}
			}
			foreach (ListItem listItem in cblTags.Items)
			{
				if (listItem.Selected)
				{
					c.addTag(listItem.Value);
				}
			}
			if (course.courseNameExists(c.getCourseName()) || course.courseCodeExists(c.getCourseCode()))
			{
				course.updateCourse(c);
			}
			else
			{
				course.createCourse(c);
			}
			ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "window.close()", true);

		}
		protected void btnAddTag_Click(object sender, EventArgs e)
		{
			ListItem a = new ListItem(txtTagAdd.Text, txtTagAdd.Text, true);
			a.Selected = true;
			cblTags.Items.Add(a);
			txtTagAdd.Text = "";
			txtTagAdd.Focus();
		}
	}
}