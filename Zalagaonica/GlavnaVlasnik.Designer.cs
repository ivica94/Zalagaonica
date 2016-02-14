namespace Zalagaonica
{
    partial class GlavnaVlasnik
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDodajIspostave = new System.Windows.Forms.Button();
            this.buttonDodajZaposlenog = new System.Windows.Forms.Button();
            this.buttonObrisiZaposlenog = new System.Windows.Forms.Button();
            this.buttonObrisiIspostave = new System.Windows.Forms.Button();
            this.buttonIzmeniZaposlenog = new System.Windows.Forms.Button();
            this.buttonIzmeniIspostavu = new System.Windows.Forms.Button();
            this.dataGridViewIspostave = new System.Windows.Forms.DataGridView();
            this.listBoxRadnici = new System.Windows.Forms.ListBox();
            this.buttonPrikaz = new System.Windows.Forms.Button();
            this.Ispostave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zarada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artikli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIspostave)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDodajIspostave
            // 
            this.buttonDodajIspostave.Location = new System.Drawing.Point(181, 12);
            this.buttonDodajIspostave.Name = "buttonDodajIspostave";
            this.buttonDodajIspostave.Size = new System.Drawing.Size(132, 42);
            this.buttonDodajIspostave.TabIndex = 0;
            this.buttonDodajIspostave.Text = "Dodaj ispostavu";
            this.buttonDodajIspostave.UseVisualStyleBackColor = true;
            this.buttonDodajIspostave.Click += new System.EventHandler(this.buttonDodajIspostave_Click);
            // 
            // buttonDodajZaposlenog
            // 
            this.buttonDodajZaposlenog.Location = new System.Drawing.Point(31, 12);
            this.buttonDodajZaposlenog.Name = "buttonDodajZaposlenog";
            this.buttonDodajZaposlenog.Size = new System.Drawing.Size(133, 42);
            this.buttonDodajZaposlenog.TabIndex = 1;
            this.buttonDodajZaposlenog.Text = "Dodaj zaposlenog";
            this.buttonDodajZaposlenog.UseVisualStyleBackColor = true;
            this.buttonDodajZaposlenog.Click += new System.EventHandler(this.buttonDodajZaposlenog_Click);
            // 
            // buttonObrisiZaposlenog
            // 
            this.buttonObrisiZaposlenog.Location = new System.Drawing.Point(568, 300);
            this.buttonObrisiZaposlenog.Name = "buttonObrisiZaposlenog";
            this.buttonObrisiZaposlenog.Size = new System.Drawing.Size(101, 43);
            this.buttonObrisiZaposlenog.TabIndex = 2;
            this.buttonObrisiZaposlenog.Text = "Obrisi zaposlenog";
            this.buttonObrisiZaposlenog.UseVisualStyleBackColor = true;
            this.buttonObrisiZaposlenog.Visible = false;
            this.buttonObrisiZaposlenog.Click += new System.EventHandler(this.buttonObrisiZaposlenog_Click);
            // 
            // buttonObrisiIspostave
            // 
            this.buttonObrisiIspostave.Location = new System.Drawing.Point(211, 305);
            this.buttonObrisiIspostave.Name = "buttonObrisiIspostave";
            this.buttonObrisiIspostave.Size = new System.Drawing.Size(102, 39);
            this.buttonObrisiIspostave.TabIndex = 3;
            this.buttonObrisiIspostave.Text = "Obrisi Ispostavu";
            this.buttonObrisiIspostave.UseVisualStyleBackColor = true;
            this.buttonObrisiIspostave.Click += new System.EventHandler(this.buttonObrisiIspostave_Click);
            // 
            // buttonIzmeniZaposlenog
            // 
            this.buttonIzmeniZaposlenog.Location = new System.Drawing.Point(427, 300);
            this.buttonIzmeniZaposlenog.Name = "buttonIzmeniZaposlenog";
            this.buttonIzmeniZaposlenog.Size = new System.Drawing.Size(98, 43);
            this.buttonIzmeniZaposlenog.TabIndex = 4;
            this.buttonIzmeniZaposlenog.Text = "Izmeni  zaposlenog";
            this.buttonIzmeniZaposlenog.UseVisualStyleBackColor = true;
            this.buttonIzmeniZaposlenog.Visible = false;
            this.buttonIzmeniZaposlenog.Click += new System.EventHandler(this.buttonIzmeniZaposlenog_Click);
            // 
            // buttonIzmeniIspostavu
            // 
            this.buttonIzmeniIspostavu.Location = new System.Drawing.Point(31, 300);
            this.buttonIzmeniIspostavu.Name = "buttonIzmeniIspostavu";
            this.buttonIzmeniIspostavu.Size = new System.Drawing.Size(109, 44);
            this.buttonIzmeniIspostavu.TabIndex = 5;
            this.buttonIzmeniIspostavu.Text = "Izmeni ispostavu";
            this.buttonIzmeniIspostavu.UseVisualStyleBackColor = true;
            this.buttonIzmeniIspostavu.Click += new System.EventHandler(this.buttonIzmeniIspostavu_Click);
            // 
            // dataGridViewIspostave
            // 
            this.dataGridViewIspostave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIspostave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ispostave,
            this.Zarada,
            this.Artikli});
            this.dataGridViewIspostave.Location = new System.Drawing.Point(31, 97);
            this.dataGridViewIspostave.Name = "dataGridViewIspostave";
            this.dataGridViewIspostave.Size = new System.Drawing.Size(347, 171);
            this.dataGridViewIspostave.TabIndex = 6;
            // 
            // listBoxRadnici
            // 
            this.listBoxRadnici.FormattingEnabled = true;
            this.listBoxRadnici.Location = new System.Drawing.Point(508, 95);
            this.listBoxRadnici.Name = "listBoxRadnici";
            this.listBoxRadnici.Size = new System.Drawing.Size(242, 173);
            this.listBoxRadnici.TabIndex = 7;
            this.listBoxRadnici.Visible = false;
            // 
            // buttonPrikaz
            // 
            this.buttonPrikaz.Location = new System.Drawing.Point(414, 97);
            this.buttonPrikaz.Name = "buttonPrikaz";
            this.buttonPrikaz.Size = new System.Drawing.Size(88, 53);
            this.buttonPrikaz.TabIndex = 8;
            this.buttonPrikaz.Text = "Prikaz";
            this.buttonPrikaz.UseVisualStyleBackColor = true;
            this.buttonPrikaz.Click += new System.EventHandler(this.buttonPrikaz_Click);
            // 
            // Ispostave
            // 
            this.Ispostave.HeaderText = "Ispostave";
            this.Ispostave.Name = "Ispostave";
            // 
            // Zarada
            // 
            this.Zarada.HeaderText = "Zarada";
            this.Zarada.Name = "Zarada";
            // 
            // Artikli
            // 
            this.Artikli.HeaderText = "Broj artikala";
            this.Artikli.Name = "Artikli";
            // 
            // GlavnaVlasnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.buttonPrikaz);
            this.Controls.Add(this.listBoxRadnici);
            this.Controls.Add(this.dataGridViewIspostave);
            this.Controls.Add(this.buttonIzmeniIspostavu);
            this.Controls.Add(this.buttonIzmeniZaposlenog);
            this.Controls.Add(this.buttonObrisiIspostave);
            this.Controls.Add(this.buttonObrisiZaposlenog);
            this.Controls.Add(this.buttonDodajZaposlenog);
            this.Controls.Add(this.buttonDodajIspostave);
            this.Name = "GlavnaVlasnik";
            this.Text = "GlavnaVlasnik";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIspostave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDodajIspostave;
        private System.Windows.Forms.Button buttonDodajZaposlenog;
        private System.Windows.Forms.Button buttonObrisiZaposlenog;
        private System.Windows.Forms.Button buttonObrisiIspostave;
        private System.Windows.Forms.Button buttonIzmeniZaposlenog;
        private System.Windows.Forms.Button buttonIzmeniIspostavu;
        private System.Windows.Forms.DataGridView dataGridViewIspostave;
        private System.Windows.Forms.ListBox listBoxRadnici;
        private System.Windows.Forms.Button buttonPrikaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ispostave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zarada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artikli;
    }
}