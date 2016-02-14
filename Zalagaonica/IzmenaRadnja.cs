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
    public partial class IzmenaRadnja : Form
    {   
        public IzmenaRadnja()
        {
            InitializeComponent();
        }
        public IzmenaRadnja(String brojRadnje)
        {
            InitializeComponent();
            popuniPolja(brojRadnje);
        }
        private void popuniPolja(String brojRadnje)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");
            var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
            var query = Query.EQ("broj", Int32.Parse(brojRadnje));
            RadnjaClass rad = collectionIspostave.FindOne(query);
            textBoxAdresa.Text = rad.adresa;
            textBoxBroj.Text = brojRadnje;
            textBoxBroj.Enabled = true;
        }
        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("Zalagaonica");            
            var collectionIspostave = database.GetCollection<RadnjaClass>("radnja");
            var query = Query.EQ("broj", Int32.Parse(textBoxBroj.Text));
            var update = MongoDB.Driver.Builders.Update.Set("adresa", textBoxAdresa.Text); //BsonValue.Create(new List<string>{"test"}));
            collectionIspostave.Update(query, update);
            MessageBox.Show("Uspesno ste azurirali radnju");
            this.Close();
        }
    }
}
