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

    }
}
