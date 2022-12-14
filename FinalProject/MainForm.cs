using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FormImport formImport = new FormImport();
            formImport.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormUser formUser = new FormUser();
            formUser.Show();
            this.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FormExport formExport = new FormExport();
            formExport.Show();
            this.Hide();
        }

        private void btnSattis_Click(object sender, EventArgs e)
        {
            FormSatitiscal formSatitiscal = new FormSatitiscal();   
            formSatitiscal.Show();
            this.Hide();
        }
    }
}
