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
    public partial class Cosmetics : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public Cosmetics()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadCosmetics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtBrand.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtDescription.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("INSERT INTO Kozmetika(ime,marka,cijena,opis,zaliha)VALUES(@ime,@marka,@cijena,@opis,@zaliha)", cn);
            cm.Parameters.AddWithValue("@ime", txtName.Text);
            cm.Parameters.AddWithValue("@marka", txtBrand.Text);
            cm.Parameters.AddWithValue("@cijena", txtPrice.Text);
            cm.Parameters.AddWithValue("@opis", txtDescription.Text);
            cm.Parameters.AddWithValue("@zaliha", txtQty.Text);
            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Kozmetika je uspesno dodana.");
            LoadCosmetics();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("Select ime,marka,cijena,opis,zaliha from Kozmetika where id='" + txtId.Text + "'", cn);
            dr = cm.ExecuteReader();
            if (dr.Read()) {

                txtName.Text = dr.GetValue(0).ToString();
                txtBrand.Text = dr.GetValue(1).ToString();
                txtPrice.Text = dr.GetValue(2).ToString();
                txtDescription.Text = dr.GetValue(3).ToString();
                txtQty.Text = dr.GetValue(4).ToString();
           }
            cn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite promeniti ovu kozmetiku?", "Kozmetika je promenjen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE Kozmetika SET ime=@ime,marka=@marka,cijena=@cijena,opis=@opis,zaliha=@zaliha WHERE id like @id", cn);
                    cm.Parameters.AddWithValue("@id", txtId.Text);
                    cm.Parameters.AddWithValue("@ime", txtName.Text);
                    cm.Parameters.AddWithValue("@marka", txtBrand.Text);
                    cm.Parameters.AddWithValue("@cijena", txtPrice.Text);
                    cm.Parameters.AddWithValue("@opis", txtDescription.Text);
                    cm.Parameters.AddWithValue("@zaliha", txtQty.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Kozmetika je uspesno promjenjena.");
                    LoadCosmetics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void LoadCosmetics()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM Kozmetika order by Id", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            cn.Close();
        }
    }
}
