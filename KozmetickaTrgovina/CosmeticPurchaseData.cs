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
    public partial class CosmeticPurchaseData : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public CosmeticPurchaseData()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("INSERT INTO Kupiti(p_ime,k_ime,marka,cijena,opis,zaliha,kolicina,t_cijena,datum_p)VALUES(@p_ime,@k_ime,@marka,@cijena,@opis,@zaliha,@kolicina,@t_cijena,@datum_p)", cn);
            cm.Parameters.AddWithValue("@p_ime", txtNameP.Text);
            cm.Parameters.AddWithValue("@k_ime", txtNameK.Text);
            cm.Parameters.AddWithValue("@marka", txtBrand.Text);
            cm.Parameters.AddWithValue("@cijena", txtPrice.Text);
            cm.Parameters.AddWithValue("@opis", txtDescription.Text);
            cm.Parameters.AddWithValue("@zaliha", txtQua.Text);
            cm.Parameters.AddWithValue("@kolicina", txtQty.Text);
            cm.Parameters.AddWithValue("@t_cijena", txtTotalPrice.Text);
            cm.Parameters.AddWithValue("@datum_p", txtDate.Text);
            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Kozmetika je uspesno prodana.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNameP.Text = "";
            txtNameK.Text = "";
            txtBrand.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            txtQua.Text = "";
            txtQty.Text = "";
            txtTotalPrice.Text = "";
            txtDate.Text = "";
        }
    }
}
