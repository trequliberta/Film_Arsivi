using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Film_Arsivi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MMAHMVJ;Initial Catalog=FilmArsivi;Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLFILMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (ad, KATEGORI, LINK ) values (@P1, @P2, @P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtfilmad.Text);
            komut.Parameters.AddWithValue("@P2", txtkategori.Text);
            komut.Parameters.AddWithValue("@P3", txtlink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film listenize eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void btnhak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Muhammed Kadir YILMAZ tarafından 17 Kasım 2022 tarihinde kodlanmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnrenk_Click(object sender, EventArgs e)
        {
            Random rdm = new Random();

            int x, y, z;

            x = rdm.Next(255);

            y = rdm.Next(255);

            z = rdm.Next(255);

            this.BackColor = Color.FromArgb(x, y, z);
        }
    }
}
