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
using System.IO;
namespace Zalagaonica
{
    public partial class Form1 : Form
    {
        private MongoCollection<ZalagacClass> collectionZalagac;
        private MongoCollection<RadnjaClass> collectionIspostava;
        private MongoCollection<UgovorClass> collectionUgovor;
        private MongoDBRef novi_ugovor;
        private List<MongoDBRef> ispostave;
        private List<MongoDBRef> Zalagaci;
        private byte[] slikaArtikla;
        public Form1()
        {
            InitializeComponent();
           
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            collectionUgovor = database.GetCollection<UgovorClass>("ugovor");
            collectionIspostava = database.GetCollection<RadnjaClass>("radnja");
            collectionZalagac = database.GetCollection<ZalagacClass>("zalagac");
            ispostave = new List<MongoDBRef>();
            Zalagaci = new List<MongoDBRef>();
            foreach (var item in collectionIspostava.FindAll())
            {
                ispostave.Add(new MongoDBRef("radnja", item.Id));
                comboBox1.Items.Add("ispodtava broj: " + item.broj + " - " + item.adresa);
            }

            foreach (var item in collectionZalagac.FindAll())
            {
                Zalagaci.Add(new MongoDBRef("zalagac", item.id));
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
            foreach (var item in flowLayoutPanel1.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    dodatno.Add(((TextBox)item).Text);
                }
	        }
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                ZalogClass noviZalog = new ZalogClass
                {
                    naziv = textBox1.Text,
                    vrsta = textBox2.Text,
                    kolicina = Int32.Parse(textBox3.Text),
                    dodatniPodaci = dodatno,
                    Ugovor = novi_ugovor,
                    Ispostva= ispostave.ElementAt(comboBox1.SelectedIndex),
                    Zalagac = Zalagaci.ElementAt(comboBox1.SelectedIndex),
                    slikaZaloga=slikaArtikla
                };
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                var database = server.GetDatabase("Zalagaonica");
                var collection = database.GetCollection<ZalogClass>("zalog");
                collection.Insert(noviZalog);
            }
            else
            {
                MessageBox.Show("Izaberite zalagaca i ispostavu");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");

            Ugovor noviUgovorForm = new Ugovor();
            noviUgovorForm.ShowDialog();
            novi_ugovor = noviUgovorForm.vratiUgovor();
            textBox4.Text = novi_ugovor.Id.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox5.Text = openFileDialog1.FileName;
            byte[] slikaArtikla = File.ReadAllBytes(textBox5.Text);
        }
    }
}
