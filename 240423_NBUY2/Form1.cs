using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _240423_NBUY2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            //server=localhost veya . konulursa pcdeki servera baglanır.
            baglanti.ConnectionString = "Server=localhost;Database=Northwind;User=sa;Pwd=123";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Urunler";
            cmd.Connection=baglanti;
            baglanti.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                string adi = reader["UrunAdi"].ToString();
                string fiyat = reader["BirimFiyati"].ToString();
                string stok = reader["HedefStokDuzeyi"].ToString();
                LstUrunler.Items.Add(string.Format("{0}-{1}-{2}", adi, fiyat, stok));

            }
        }
    }
}
