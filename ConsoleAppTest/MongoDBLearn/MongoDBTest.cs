using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.MongoDBLearn
{
    class MongoDBTest
    {
        public void TestData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("dbfirst");
            var collection = database.GetCollection<BsonDocument>("cfirst");
            BsonDocument document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                    {
                        { "x", 203 },
                        { "y", 102 }
                    }
                }
            };

            collection.InsertOne(document);

            A a = new A { B = 1, C = "nohao" };
            List<int> d = new List<int> { 1, 2 };

        }

        public void TestJson()
        {

        }

    }

    class A
    {
        public int B{get;set ;}

        public string  C{ get; set; }

        public A()
        {

        }

        public A(int b)
        {
            this.B = b;

        }

    }

}
