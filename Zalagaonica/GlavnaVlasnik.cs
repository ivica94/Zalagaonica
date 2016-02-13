using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Zalagaonica.DomanModel;
namespace Zalagaonica
{
    public partial class GlavnaVlasnik : Form
    {
        public GlavnaVlasnik()
        {
            InitializeComponent();
            Popuni();
        }
        private void Popuni()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
            foreach (RadnjaClass item in collectionIspostave.FindAll())
            {
                
            }
        }

    }
}
