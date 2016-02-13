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
        public Form1()
        {
            InitializeComponent();
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
    }
}
