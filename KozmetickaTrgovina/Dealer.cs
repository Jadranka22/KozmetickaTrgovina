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
    public partial class Dealer : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Dealer()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("INSERT INTO Dobavljac(ime,mobilni,email,adresa)VALUES(@ime,@mobilni,@email,@adresa)", cn);
            cm.Parameters.AddWithValue("@ime", txtName.Text);
            cm.Parameters.AddWithValue("@mobilni", txtPhoneNo.Text);
            cm.Parameters.AddWithValue("@email", txtEmail.Text);
            cm.Parameters.AddWithValue("@adresa", txtAddress.Text);
            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Dobavljac je uspesno dodan.");
        }
    }
}
