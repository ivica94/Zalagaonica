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
using System.IO;
using Zalagaonica.DomanModel;
namespace Zalagaonica
{
    public partial class Ugovor : Form
    {
        private MongoDBRef ovajUgovor;
        public Ugovor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

              openFileDialog1.ShowDialog();
              textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("Zalagaonica");
            byte[] slika_ugovora = File.ReadAllBytes(textBox1.Text);
            UgovorClass ugovor = new UgovorClass
            {
                datumPotpisivanja = dateTimePicker1.Value.ToString(),
                datumIsteka = dateTimePicker2.Value.ToString(),
                datNovac = Int32.Parse(textBox3.Text),
                slikaUgovora = slika_ugovora
            };
            var collection = db.GetCollection<UgovorClass>("ugovori");
            collection.Insert(ugovor);
            ovajUgovor = new MongoDBRef("ugovori",ugovor.Id);

            //var nc = db.GetCollection<UgovorClass>("ugovori");
            //foreach (UgovorClass item in nc.FindAll())
            //{
            //     MessageBox.Show(item.datumIsteka);
            //}
        }
        public MongoDBRef vratiUgovor()
        {
            return ovajUgovor;
        }
    }
}
