using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Zalagaonica.DomanModel
{
    public class ZaposleniClass
    {
        public ObjectId Id { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String adresa { get; set; }
        public String JMBG { get; set; }
        public String brojTelefona { get; set; }
        public float plata { get; set; }
        public MongoDBRef ispostava { get; set; }
        public List<MongoDBRef> ugovori { get; set; }
        public ZaposleniClass()
        {
            ugovori = new List<MongoDBRef>();
        }

     }
}
