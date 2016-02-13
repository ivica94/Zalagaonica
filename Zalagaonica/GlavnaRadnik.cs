using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zalagaonica
{
    public partial class GlavnaRadnik : Form
    {
        public GlavnaRadnik()
        {
            InitializeComponent();
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
    }
}
