using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Zalagaonica.DomanModel
{
    public class ZalagacClass
    {
        public ObjectId id{get; set;}
        public String ime { get; set; }
        public String prezime{get; set;}
        public String JMBG{get; set;}
        public String brojTelefona { get; set; }
        public String email { get; set; }
        public String adresa{get; set;}
        public List<MongoDBRef> ugovori;
        public List<MongoDBRef> zalozi;
        public ZalagacClass()
        {
            ugovori = new List<MongoDBRef>();
            zalozi = new List<MongoDBRef>();
        }
    }
}
