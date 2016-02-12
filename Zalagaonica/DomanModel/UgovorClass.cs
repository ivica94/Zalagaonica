using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
namespace Zalagaonica.DomanModel
{   
    public  class UgovorClass
    {
        public ObjectId Id;
        public String datumPotpisivanja { get; set; }
        public String datumIsteka { get; set; }
        public int datNovac { get; set; } 
        public byte[] slika;
    }
}
