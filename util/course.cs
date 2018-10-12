using MongoDB.Bson;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace util
{
	public class course
	{
		private List<string> categories = new List<string>();
		private List<string> tags = new List<string>();

		private string courseName;
		private string courseCode;
		private string courseDescription;

		//Everything is private so they can't be changed without validation and sent to the database. 
		public course()
		{
			courseName = "";
			courseCode = "";
		} //Blank course. 
		public course(MySqlDataReader data)
		{
			courseName = data["CourseName"].ToString();
			courseCode = data["CourseCode"].ToString();
			courseDescription = data["CourseDescription"].ToString();
			string catHold = data["CourseCategories"].ToString();
			string tagHold = data["Tags"].ToString();


			categories = catHold.Split('~').ToList<string>();
			tags = tagHold.Split('~').ToList<string>();

		} //Generate course object from Bsondocument returned by query to Courses Collection
		public TableRow toTableRow() //Builds a ASP Web Table Row for Data Table.
		{
			string courseCategories = "";

			TableRow row = new TableRow();
			TableCell categoriesCell = new TableCell();
			TableCell codeCell = new TableCell();
			TableCell nameCell = new TableCell();
			TableCell descriptionCell = new TableCell();
			// Made 4 table cells because I didn't know a better way to do it. 


			nameCell.Text = this.courseName;
			descriptionCell.Text = this.courseDescription;
			//codeCell.Text = "<a href='#' onClick='openWindow(event, \"/UpdateCourse.aspx?CourseCode=" + this.courseCode + "\")'>" + this.courseCode + "</a>";
			codeCell.Text = "<a href='#' onClick='openWindow(\"/UpdateCourse.aspx?CourseCode=" + this.courseCode + "\", \"Update Course \", 400, 600)'>" + this.courseCode + "</a>";

			foreach (string category in categories)
			{
				if (courseCategories != "")
				{
					courseCategories += " ◆ ";
				}
				courseCategories += category;
			}
			courseCategories = courseCategories.Substring(0, courseCategories.Length - 2);
			categoriesCell.Text = courseCategories;


			//Add Cell Values to Cell
			row.Cells.Add(nameCell);
			row.Cells.Add(codeCell);
			row.Cells.Add(categoriesCell);
			row.Cells.Add(descriptionCell);

			return row;
		}

		//Adding to list nonsense. Setting nonsense. 
		public void addCategory(string category)
		{
			if (!categories.Contains(category))
			{
				categories.Add(category);
			}
		} //Add Category to Category List if not in list. 
		public void addTag(string tag)
		{
			if (!tags.Contains(tag) && tag != "")
			{
				tags.Add(tag);
			}
		} // Add tag to taglist if not in taglist
		public void setCourseName(string coursename)
		{
			courseName = coursename;
		}
		public void setCourseCode(string coursecode)
		{
			courseCode = coursecode;
		}
		public void setCourseDescription(string description)
		{
			courseDescription = description;
		}
		public string getCourseName()
		{
			return courseName;
		}
		public string getCourseCode()
		{
			return courseCode;
		}
		public string getCourseDescription()
		{
			return courseDescription;
		}
		public List<string> getCourseCategories()
		{
			return categories;
		}
		public List<string> getTags() { return tags; }
		//Validation Code
		public static bool courseNameExists(string name)
		{
			return db.runQuery("SELECT CourseName FROM Courses WHERE CourseName = '" + name + "'").HasRows;
		} //Checks course collection to ensure no course has the same name. Returns true if course already has that name.
		public static bool courseCodeExists(string code)
		{
			return db.runQuery("SELECT CourseCode FROM Courses WHERE CourseCode = '" + code + "'").HasRows;
		} //Checks course collection to ensure no course has the same code. Returns true if course already has that code.


		public static course getCourseByName(string name)
		{
			if (courseNameExists(name))
			{
				return new course(db.runQuery("SELECT * FROM Courses WHERE CourseName = '" + name + "'"));
			}
			else
				return new course();
		}
		public static course getCourseByCode(string code)
		{
			if (courseCodeExists(code))
			{
				return new course(db.runQuery("SELECT * FROM Courses WHERE CourseCode = '" + code + "'"));
			}
			else
				System.Console.WriteLine("Course code already exists!");
			return new course();
		}

	
		public static void createCourse(course c)
		{
			if (!courseNameExists(c.getCourseName()) && !courseCodeExists(c.getCourseCode()))
			{
				db.runQuery("INSERT INTO courses (CourseName, CourseCode, CourseDescription, Tags, CourseCategories) VALUES ('"
				+ c.getCourseName() + "', '"
				+ c.getCourseCode() + "', '" 
				+ c.getCourseDescription() + "', '" 
				+ c.listToSeparatedString(c.getTags()) + "', '"
				+ c.listToSeparatedString(c.getCourseCategories()) + "')");
			}

		}
		public static void updateCourse(course c)
		{
			db.runQuery("UPDATE courses SET "
			+ "CourseName='" + c.getCourseName() + "', "
			+ "CourseCode='" + c.getCourseCode() + "', "
			+ "CourseDescription='" + c.getCourseDescription() + "', "
			+ "Tags='" + c.listToSeparatedString(c.getTags()) + "', "
			+ "CourseCategories='" + c.listToSeparatedString(c.getCourseCategories()) + "'"
			+ "WHERE CourseName='" + c.getCourseName() + "' AND CourseCode='" + c.getCourseCode() + "'"); 
		}
		public static void deleteCourse(course c)
		{
			db.runQuery("DELETE FROM courses WHERE CourseName='" + c.getCourseName() + "' AND CourseCode='" + c.getCourseCode() + "'");
		}

		public static List<ListItem> getCourseCategoriesListForCheckBoxList() // for loading check box list of course categories on various pages
		{
			List<ListItem> list = new List<ListItem>();
			MySqlDataReader masterlist = db.runQuery("SELECT * FROM coursecategories");
			if (masterlist.HasRows)
			{
				do
				{
					list.Add(new ListItem(masterlist["coursecategories"].ToString()));

				} while (masterlist.Read());
			}
			return list;
		}

		private string listToSeparatedString(List<string> list)
		{
			string st = "";
			if (list.Count > 1)
			{
				foreach (string a in list)
				{
					st += a + "~";
				}
			}
			else
			{
				st = list[0];
			}

			return st;
		}
	}
}

