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
        private MongoCollection<ZaposleniClass> zaposleniColl;
        private MongoCollection<RadnjaClass> radnjeColl;
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
            radnjeColl = collectionIspostave;
            foreach (RadnjaClass item in collectionIspostave.FindAll())
            {
                int suma = 0;
                foreach (MongoDBRef refZaposleni in item.radnici.ToList())
                {
                    ZaposleniClass zaposlen = database.FetchDBRefAs<ZaposleniClass>(refZaposleni);
                    
                    foreach (MongoDBRef refUgovor in zaposlen.ugovori.ToList())
                    { 
                        UgovorClass ugovor = database.FetchDBRefAs<UgovorClass>(refUgovor);
                        suma += ugovor.datNovac;
                    }
                }
                dataGridViewIspostave.Rows.Add(item.broj.ToString(), suma.ToString());
            }
        }

        private void buttonPrikaz_Click(object sender, EventArgs e)
        {
             if (dataGridViewIspostave.SelectedRows.Count == 1)
             {
                 var connectionString = "mongodb://localhost/?safe=true";
                 var server = MongoServer.Create(connectionString);
                 var database = server.GetDatabase("Zalagaonica");
                 var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
                 int id = dataGridViewIspostave.SelectedCells[0].RowIndex;
                 DataGridViewRow selectedRow = dataGridViewIspostave.Rows[id];
                 var query = Query.EQ("broj", Int32.Parse(selectedRow.Cells[0].Value.ToString()));
                 RadnjaClass rad = collectionIspostave.FindOne(query);
                 foreach (MongoDBRef refZaposleni in rad.radnici)
                 {
                     ZaposleniClass zaposlen = database.FetchDBRefAs<ZaposleniClass>(refZaposleni);
                     listBoxRadnici.Items.Add("Ime i Prezime: " + zaposlen.ime + " " +
                         zaposlen.prezime + "Plata: " + zaposlen.plata);
                 }
             }
        }

    }
}
