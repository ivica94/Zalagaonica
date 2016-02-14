using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Zalagaonica.DomanModel
{
   public class ZalogClass
    {
       public ObjectId id { get; set; }
       public String naziv { get; set; }
       public String vrsta { get; set; }
       public int kolicina { get; set; }
       public byte[] slikaZaloga { get; set; } 
       public MongoDBRef Ispostva { get; set; }
       public MongoDBRef Zalagac { get; set; }
       public MongoDBRef Ugovor { get; set; }
       public List<String> dodatniPodaci { get; set; }

    }
}
