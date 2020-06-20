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
    public partial class NewEmployee : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public NewEmployee()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("INSERT INTO Zaposlenik(ime,mobilni,godina_rodjenja,kvalifikacije,radno_vrijeme,datum_pocetka,adresa)VALUES(@ime,@mobilni,@godina_rodjenja,@kvalifikacije,@radno_vrijeme,@datum_pocetka,@adresa)", cn);
            cm.Parameters.AddWithValue("@ime", txtName.Text);
            cm.Parameters.AddWithValue("@mobilni", txtPhoneNo.Text);
            cm.Parameters.AddWithValue("@godina_rodjenja", DateTime.Parse(dateTimePicker1.Text));
            cm.Parameters.AddWithValue("@kvalifikacije", txtQual.Text);
            cm.Parameters.AddWithValue("@radno_vrijeme", txtDutyTime.Text);
            cm.Parameters.AddWithValue("@datum_pocetka", DateTime.Parse(dateTimePicker2.Text));
            cm.Parameters.AddWithValue("@adresa", txtAddress.Text);
            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Zaposlenik je uspesno dodan.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhoneNo.Text = "";
            dateTimePicker1.Text = "";
            txtQual.Text = "";
            txtDutyTime.Text = "";
            dateTimePicker2.Text = "";
            txtAddress.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
