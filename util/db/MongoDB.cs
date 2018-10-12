using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
namespace util
{
	public sealed class MongoDB
	{
		private static MongoClient getDBConn()
		{
			return new MongoClient("mongodb://localhost:27017");
		}

		public static void insertQuery(BsonDocument doc, string coll, string db)
		{
			var database = getDBConn().GetDatabase(db);
			var collection = database.GetCollection<BsonDocument>(coll);
			collection.InsertOne(doc);
		}
		public static void replaceQuery(BsonDocument doc, string filter, string coll, string db)
		{
			var database = getDBConn().GetDatabase(db);
			var collection = database.GetCollection<BsonDocument>(coll);
			collection.ReplaceOne(filter, doc);
		}
		public static List<BsonDocument> find(string filter, string coll, string database)
		{
			var db = getDBConn().GetDatabase(database);
			var collection = db.GetCollection<BsonDocument>(coll);
			return collection.Find(filter).ToList();
		}

		public static void deleteQuery(string filter, string coll, string database)
		{
			var db = getDBConn().GetDatabase(database);
			var collection = db.GetCollection<BsonDocument>(coll);
			collection.DeleteMany(filter);
		}

	}
}
