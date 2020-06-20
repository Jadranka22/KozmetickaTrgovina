using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KozmetickaTrgovina
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBoxMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void dodajKozmetikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEmployee ne = new NewEmployee();
            ne.Show();
        }

        private void noviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dealer dd = new Dealer();
            dd.Show();
        }

        private void dodajKozmetikuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cosmetics cs = new Cosmetics();
            cs.Show();
        }

        private void hermetickaKozmetikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CosmeticSale css = new CosmeticSale();
            css.Show();
        }

        private void potraziKozmetikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchCosmetics sc = new SearchCosmetics();
            sc.Show();
        }

        private void kozmetikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCosmetics vc = new ViewCosmetics();
            vc.Show();
        }

        private void zaposleniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewEmployee ve = new ViewEmployee();
            ve.Show();
        }

        private void prodajaKozmetikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSoldCosmetics vsc = new ViewSoldCosmetics();
            vsc.Show();
        }

        private void kupljenaKozmetikaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewPurchaseCosmetics vpc = new ViewPurchaseCosmetics();
            vpc.Show();
        }

        private void kupljenaKozmetikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CosmeticPurchaseData cpd = new CosmeticPurchaseData();
            cpd.Show();
        }
    }
}
