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
        public ObjectId Id;
        public string JMBG;
        public string ime;
        public string prezime;
        public string adresa;
        public string telefon;
        public float plata;
        public MongoDBRef ispostava;
    }
}
