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
        
        private MongoCollection<RadnjaClass> radnjeColl;
        private List<String> jmbgTmp;
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
            dataGridViewIspostave.Rows.Clear();
            foreach (RadnjaClass item in collectionIspostave.FindAll())
            {
                int suma = 0;
                int artikli = 0;
                foreach (MongoDBRef refZaposleni in item.radnici.ToList())
                {
                    ZaposleniClass zaposlen = database.FetchDBRefAs<ZaposleniClass>(refZaposleni);
                    
                    foreach (MongoDBRef refUgovor in zaposlen.ugovori.ToList())
                    { 
                        UgovorClass ugovor = database.FetchDBRefAs<UgovorClass>(refUgovor);
                        suma += ugovor.datNovac;
                        artikli++;
                    }
                }
                dataGridViewIspostave.Rows.Add(item.broj.ToString(), suma.ToString(),artikli.ToString());
            }
        }

        private void buttonPrikaz_Click(object sender, EventArgs e)
        {
             if (dataGridViewIspostave.SelectedRows.Count == 1)
             {
                 buttonIzmeniZaposlenog.Visible = true;
                 buttonObrisiZaposlenog.Visible = true;
                 listBoxRadnici.Visible = true;
                 listBoxRadnici.Items.Clear();
                 var connectionString = "mongodb://localhost/?safe=true";
                 var server = MongoServer.Create(connectionString);
                 var database = server.GetDatabase("Zalagaonica");
                 var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
                 int id = dataGridViewIspostave.SelectedCells[0].RowIndex;
                 DataGridViewRow selectedRow = dataGridViewIspostave.Rows[id];
                 var query = Query.EQ("broj", Int32.Parse(selectedRow.Cells[0].Value.ToString()));
                 RadnjaClass rad = collectionIspostave.FindOne(query);
                 jmbgTmp = new List<string>();
                 foreach (MongoDBRef refZaposleni in rad.radnici.ToList())
                 {
                     ZaposleniClass zaposlen = database.FetchDBRefAs<ZaposleniClass>(refZaposleni);
                     listBoxRadnici.Items.Add("Ime i Prezime: " + zaposlen.ime + " " +
                         zaposlen.prezime + "Plata: " + zaposlen.plata);
                     jmbgTmp.Add(zaposlen.JMBG);
                 }
             }
             else
             {
                 MessageBox.Show("Morate obeleziti radnju za koju zelite prikaz!!!");
             }
        }

        private void buttonIzmeniIspostavu_Click(object sender, EventArgs e)
        {
            if (dataGridViewIspostave.SelectedRows.Count == 1)
            {
                int id = dataGridViewIspostave.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewIspostave.Rows[id];
                IzmenaRadnja izmenaRadnje = new IzmenaRadnja(selectedRow.Cells[0].Value.ToString());
                izmenaRadnje.ShowDialog();
            }
            else
            {
                MessageBox.Show("Obelezite radnju koju zelite da izmenite!!!");
            }
        }

        private void buttonObrisiIspostave_Click(object sender, EventArgs e)
        {
            if (dataGridViewIspostave.SelectedRows.Count == 1)
            {
                int id = dataGridViewIspostave.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewIspostave.Rows[id];
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                var database = server.GetDatabase("Zalagaonica");
                var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
                var query = Query.EQ("broj", Int32.Parse(selectedRow.Cells[0].Value.ToString()));
                collectionIspostave.Remove(query);
                Popuni();
            }
            else
            {
                MessageBox.Show("Obelezite radnju koju zelite da izbrisete!!!");
            }
        }

        private void buttonIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            if(listBoxRadnici.SelectedItems.Count==1)
            {
                IzmenaZaposlenog izmeniZaposlenog = new IzmenaZaposlenog(jmbgTmp.ElementAt(listBoxRadnici.SelectedIndex));
                izmeniZaposlenog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Obelezite radnika kome zelite da izmenite podatke!!!");
            }
        }

        private void buttonObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            if(listBoxRadnici.SelectedItems.Count==1)
            {
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                var database = server.GetDatabase("Zalagaonica");
                var collectionZaposleni = database.GetCollection<ZaposleniClass>("zaposleni");
                var query = Query.EQ("JMBG", jmbgTmp.ElementAt(listBoxRadnici.SelectedIndex));
                collectionZaposleni.Remove(query);
            }
            else
            {
                MessageBox.Show("Obelezite radnika kome zelite da izmenite podatke!!!");
            }
        }

        private void buttonDodajZaposlenog_Click(object sender, EventArgs e)
        {
            DodavanjeZaposlenog dodaZap = new DodavanjeZaposlenog();
            dodaZap.ShowDialog();
            Popuni();
        }

        private void buttonDodajIspostave_Click(object sender, EventArgs e)
        {
            DodavanjeRadnje dodIspostavu = new DodavanjeRadnje();
            dodIspostavu.ShowDialog();
            Popuni();
        }
    }
}
