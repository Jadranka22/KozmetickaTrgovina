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

namespace KozmetickaTrgovina
{
    public partial class CosmeticSale : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public CosmeticSale()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("INSERT INTO Prodaja(k_ime,kos_ime,marka,opis,cijena,kolicina,t_cijena)VALUES(@k_ime,@kos_ime,@marka,@opis,@cijena,@kolicina,@t_cijena)", cn);
            cm.Parameters.AddWithValue("@k_ime", txtNameK.Text);
            cm.Parameters.AddWithValue("@kos_ime", txtNameC.Text);
            cm.Parameters.AddWithValue("@marka", txtBrand.Text);
            cm.Parameters.AddWithValue("@opis", txtDescription.Text);
            cm.Parameters.AddWithValue("@cijena", txtPrice.Text);
            cm.Parameters.AddWithValue("@kolicina", txtQty.Text);
            cm.Parameters.AddWithValue("@t_cijena", txtTotalPrice.Text);
            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Kozmetika je uspesno prodana.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
            txtNameK.Text = "";
            txtNameC.Text = "";
            txtBrand.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtDescription.Text = "";
            txtTotalPrice.Text = "";
        }
    }
}
