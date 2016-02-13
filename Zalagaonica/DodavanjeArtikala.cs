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
    public partial class Form1 : Form
    {
        private MongoCollection<ZalagacClass> collectionZalagac;
        private MongoCollection<RadnjaClass> collectionIspostava;
        private MongoCollection<UgovorClass> collectionUgovor;
        public Form1()
        {
            InitializeComponent();
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            collectionUgovor = database.GetCollection<UgovorClass>("ugovor");
            collectionIspostava = database.GetCollection<RadnjaClass>("radnja");
            collectionZalagac = database.GetCollection<ZalagacClass>("zalagac");
            foreach (var item in collectionIspostava.FindAll())
            {
                comboBox1.Items.Add("ispodtava broj: " + item.broj + " - " + item.adresa);
            }

            foreach (var item in collectionZalagac.FindAll())
            {
                comboBox2.Items.Add(item.ime + item.prezime);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBox dod_inf = new TextBox();
            dod_inf.Width = 200;
            flowLayoutPanel1.Controls.Add(dod_inf);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> dodatno = new List<String>();
            foreach (TextBox item in flowLayoutPanel1.Controls)
            {
		        dodatno.Add(item.Text);
	        }
            ZalogClass noviZalog = new ZalogClass
            {
                naziv = textBox1.Text,
                vrsta = textBox2.Text,
                kolicina = Int32.Parse(textBox3.Text),
                dodatniPodaci=dodatno,

            };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");

            Ugovor noviUgovorForm = new Ugovor();
            noviUgovorForm.ShowDialog();
            MongoDBRef novi_ugovor = noviUgovorForm.vratiUgovor();
            textBox4.Text = novi_ugovor.Id.ToString();
        }
    }
}
