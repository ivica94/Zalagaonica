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
    public partial class DodavanjeZalagaca : Form
    {
        public DodavanjeZalagaca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            var collectionZalagac = database.GetCollection<ZalagacClass>("zalagac");
            ZalagacClass zal = new ZalagacClass
            {
                ime = textBoxIme.Text,
                prezime = textBoxPrezime.Text,
                JMBG = textBoxJMBG.Text,
                adresa = textBoxAdresa.Text,
                brojTelefona = textBoxBrojTelefona.Text,
                email = textBoxEmail.Text,
                ugovori = new List<MongoDBRef>(),
                zalozi = new List<MongoDBRef>()
            };
            collectionZalagac.Insert(zal);
            clearAll();
        }
        private void clearAll()
        {
            textBoxEmail.Clear();
            textBoxIme.Clear();
            textBoxJMBG.Clear();
            textBoxPrezime.Clear();
            textBoxBrojTelefona.Clear();
            textBoxAdresa.Clear();
        }
    }
}
