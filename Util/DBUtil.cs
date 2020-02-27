using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

namespace ShookREST.Util
{
    public class DBUtil
    {
        public DBUtil()
        {
            var client = new MongoClient(
                "");
            var database = client.GetDatabase("test");

            Console.WriteLine(database);
        }
    }
}
