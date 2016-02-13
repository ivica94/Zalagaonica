using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Zalagaonica.DomanModel
{
    public class RadnjaClass
    {
        public ObjectId Id { get; set; }
        public int broj { get; set; }
        public String adresa { get; set; }
        public List<MongoDBRef> radnici { get; set; }

        public RadnjaClass()
        {
            radnici = new List<MongoDBRef>();
        }
    }
}
