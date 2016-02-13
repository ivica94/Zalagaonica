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
        public string brojTelefona{get; set;}
        public string email{get; set;}
        public String adresa{get; set;}
    }
}
