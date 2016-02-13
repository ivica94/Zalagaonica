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
    public partial class DodavanjeRadnje : Form
    {
        public DodavanjeRadnje()
        {
            InitializeComponent();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            var collection = database.GetCollection<RadnjaClass>("radnja");
            RadnjaClass radnja1=new RadnjaClass {
                broj=Int32.Parse(textBoxBrojIspostave.Text), 
                adresa=textBoxAdresa.Text, 
                radnici = new List<MongoDBRef>() 
            };
            collection.Insert(radnja1);
            foreach (RadnjaClass rad in collection.FindAll())
            {
                MessageBox.Show(rad.broj.ToString());
            }
            textBoxAdresa.Text = "";
            textBoxBrojIspostave.Text = "";
        }
    }
}
