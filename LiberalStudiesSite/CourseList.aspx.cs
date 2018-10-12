using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace LiberalStudies
{
	public partial class CourseList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (cblCategories.Items.Count == 0)
			{
				foreach (ListItem item in util.course.getCourseCategoriesListForCheckBoxList())
				{
					cblCategories.Items.Add(item);
				}
			}
			LoadDataTable();
		}
		protected void txtSearch_TextChanged(object sender, EventArgs e)
		{
			LoadDataTable();
		}




	private void LoadDataTable()
	{
			TableRow tblheader = Table1.Rows[0];
			Table1.Rows.Clear();
			Table1.Rows.Add(tblheader);
			string queryStr = "SELECT * FROM Courses WHERE Tags LIKE '%" + txtSearch.Text + "%'";
			foreach(ListItem item in cblCategories.Items)
			{
				if (item.Selected)
				{
					queryStr += "AND CourseCategories LIKE '%" + item.Text + "%'";
				}				
			}
	
		System.Diagnostics.Debug.WriteLine(queryStr);

		LoadDataTableHelper(util.db.runQuery(queryStr));
	}
			
		
		private void LoadDataTableHelper(MySqlDataReader results)
		{
			if (results.HasRows)
			{
				do
				{
					Table1.Rows.Add(new util.course(results).toTableRow());
				} while (results.Read());
			}
		}

		
	}
	}