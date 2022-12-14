using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class FormUser : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public FormUser()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void rbtnAgent_CheckedChanged(object sender, EventArgs e)
        {
            Load_Data();
            
        }

        private void Load_Data()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select * from Agent";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dgrvUser.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void rbtnClient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnClient.Checked)
            {

                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string query = "select * from Users ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                dgrvUser.DataSource = ds.Tables[0];
                conn.Close();
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void dgrvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgrvUser_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (rbtnClient.Checked)
            {
                if (dgrvUser.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
                {
                    dgrvUser.CurrentRow.Selected = true;
                    txtID.Text = dgrvUser.Rows[e.RowIndex].Cells["UserID"].FormattedValue.ToString();
                    txtFullName.Text = dgrvUser.Rows[e.RowIndex].Cells["UserFullName"].FormattedValue.ToString();
                    txtUserName.Text = dgrvUser.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
                    txtPassword.Text = dgrvUser.Rows[e.RowIndex].Cells["UserPass"].FormattedValue.ToString();
                    txtAddress.Text = dgrvUser.Rows[e.RowIndex].Cells["UserAddress"].FormattedValue.ToString();
                    txtPhone.Text = dgrvUser.Rows[e.RowIndex].Cells["UserPhone"].FormattedValue.ToString();
                }

            }
            else
            {
                if (dgrvUser.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
                {
                    dgrvUser.CurrentRow.Selected = true;
                    txtID.Text = dgrvUser.Rows[e.RowIndex].Cells["AgentID"].FormattedValue.ToString();
                    txtFullName.Text = dgrvUser.Rows[e.RowIndex].Cells["AgentFullName"].FormattedValue.ToString();
                    txtUserName.Text = dgrvUser.Rows[e.RowIndex].Cells["AgentName"].FormattedValue.ToString();
                    txtPassword.Text = dgrvUser.Rows[e.RowIndex].Cells["AgentPass"].FormattedValue.ToString();
                    txtAddress.Text = dgrvUser.Rows[e.RowIndex].Cells["AgentAddress"].FormattedValue.ToString();
                    txtPhone.Text = dgrvUser.Rows[e.RowIndex].Cells["AgentPhone"].FormattedValue.ToString();
                }
            }
        }
    }
}
