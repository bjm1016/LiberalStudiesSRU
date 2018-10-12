using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using MongoDB.Bson;
namespace util
{
	public static class db
	{
	static public MySqlConnection getDbConn()
		{
			return new MySqlConnection("server=localhost;user=root;database=srulibstud;port=3306;password=password;");
		}
		public static void insertQuery(BsonDocument doc, string coll, string db)
		{

		}

		public static void replaceQuery(BsonDocument doc, string filter, string coll, string db)
		{

		}

		public static List<BsonDocument> find(string filter, string coll, string database)
		{
			return new List<BsonDocument>();
		}

		public static void deleteQuery(string filter, string coll, string database)
		{

		}

		public static MySqlDataReader runQuery(string query)
		{
			MySqlConnection conn = getDbConn();
			conn.Open();
			MySqlDataReader result = new MySqlCommand(query, conn).ExecuteReader();
			result.Read();
			return result;
		}
	}
}
