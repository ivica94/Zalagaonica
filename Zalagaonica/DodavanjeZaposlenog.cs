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
    public partial class DodavanjeZaposlenog : Form
    {
        public DodavanjeZaposlenog()
        {
            InitializeComponent();
            Ubaci();
        }
        private void Ubaci()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
            foreach (RadnjaClass r in collectionIspostave.FindAll())
            {
                comboBoxIspostave.Items.Add(r.broj);
            }
        }
        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            var collectionZaposleni = database.GetCollection<ZaposleniClass>("zaposleni");
            ZaposleniClass zaposleni = new ZaposleniClass
            {
                ime = textBoxIme.Text,
                prezime = textBoxPrezime.Text,
                JMBG = textBoxJMBG.Text,
                brojTelefona = textBoxBrojtelefona.Text,
                adresa = textBoxAdresa.Text,
                plata = float.Parse(textBoxPlata.Text),
                user= textBoxUser.Text,
                pass=textBoxPass.Text
            };
            var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
            var query = Query.EQ("broj", Int32.Parse(comboBoxIspostave.SelectedItem.ToString()));
            RadnjaClass rad = collectionIspostave.FindOne(query);           
            zaposleni.ispostava = new MongoDBRef("radnja", rad.Id);
            collectionZaposleni.Insert(zaposleni);
            var query2 = Query.EQ("JMBG", textBoxJMBG.Text);
            ZaposleniClass zap = collectionZaposleni.FindOne(query2);
            rad.radnici.Add(new MongoDBRef("zaposleni", zap.Id));
            collectionIspostave.Save(rad);
        }

    }
}
