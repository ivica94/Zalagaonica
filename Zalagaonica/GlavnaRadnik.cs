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
    public partial class GlavnaRadnik : Form
    {
        private MongoCollection<ZalagacClass> collectionZalagac;
        private MongoCollection<ZalogClass> collectionZalog;
        private MongoCollection<UgovorClass> collectionUgovor;
        public GlavnaRadnik()
        {
            InitializeComponent();
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            collectionUgovor = database.GetCollection<UgovorClass>("ugovori");
            collectionZalog = database.GetCollection<ZalogClass>("zalog");
            collectionZalagac = database.GetCollection<ZalagacClass>("zalagac");
            Refresh();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Ne pipiaj !!!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dodavanjeZalogaForma = new Form1();
            dodavanjeZalogaForma.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DodavanjeZalagaca dodavanjeZalagacaForma = new DodavanjeZalagaca();
            dodavanjeZalagacaForma.ShowDialog();
        }
        private void Refresh()
        {
            foreach (var item in collectionZalog.FindAll())
            {
                dataGridView1.Rows.Add(item.id, item.naziv, item.vrsta);
            }
            foreach (var item in collectionUgovor.FindAll())
            {
                dataGridView2.Rows.Add(item.Id, item.datumPotpisivanja, item.datumIsteka, item.datNovac);
            }
            foreach (var item in collectionZalagac.FindAll())
            {
                dataGridView3.Rows.Add(item.JMBG, item.ime, item.prezime, item.brojTelefona);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedColumns.Count==1)
            {

            }
        }
    }
}
