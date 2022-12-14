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
    public partial class FormImport : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public FormImport()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRecCode.Text == "" || txtRecName.Text == "")
            {
                MessageBox.Show("Missing Information. Please check again!");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    string query = "insert into Product(PID, PName, PPrice, PQuantity) values('" + txtBarCode.Text + "',N'" + txtProductName.Text + "','" + txtProductPrice.Text + "', N'" + txtQuantity.Text + "'  )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Data Successful!");
                    conn.Close();
                    Load_Data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Load_Data()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select ID.IDID, ID.PID, P.PName, ID.PPriceImport as Price, ID.PQuantity as Quantity, ID.PPriceImport*ID.PQuantity as Total  from ImportDetails ID full outer join Product P on ID.PID = P.PID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            drgImport.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void FormImport_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtRecCode.Text == "" || txtRecName.Text == "")
            {
                MessageBox.Show("Missing Information. Please check again!");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    string query = "insert into ImportRecived values('" + txtRecCode.Text + "',N'" + txtRecName.Text + "',N'" + txtEmpCode.Text + "', N'" + dateImport.Value.Date + "'  )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Create New Recived Successful!");
                    conn.Close();
                    Load_Data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void rbtnProduct_CheckedChanged(object sender, EventArgs e)
        {
             
            Load_Data();
        }

        private void rbtnRec_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnRec.Checked)
            {
          
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string query = "select * from ImportRecived ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                drgImport.DataSource = ds.Tables[0];
                conn.Close();
            }

        }

        private void drgImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (drgImport.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                drgImport.CurrentRow.Selected = true;
                txtRecCode.Text = drgImport.Rows[e.RowIndex].Cells["IRID"].FormattedValue.ToString();
                txtRecName.Text = drgImport.Rows[e.RowIndex].Cells["IDName"].FormattedValue.ToString();
                txtEmpCode.Text = drgImport.Rows[e.RowIndex].Cells["EmpID"].FormattedValue.ToString();
            }
            btnDetails_Click(sender, e);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select ID.IDID, ID.PID, P.PName, ID.PPriceImport as Price, ID.PQuantity as Quantity, ID.PPriceImport*ID.PQuantity as Total  from ImportDetails ID full outer join Product P on ID.PID = P.PID  where ID.IDID = '" + txtRecCode.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            drgImport.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRecCode.Text == "" || txtRecName.Text == "")
            {
                MessageBox.Show("Missing Information. Please check again!");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    string query = "insert into ImportDetails(IDID, PID, PPriceImport, PQuantity) values('" + txtRecCode.Text + "', '" + txtBarCode.Text +  "','" + txtProductPrice.Text + "', N'" + txtQuantity.Text + "'  )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Save Data Successful!");
                    conn.Close();
                    Load_Data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRecCode.Text == "")
            {
                MessageBox.Show("Missing Information. Please check again!");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    string query = "delete from ImportDetails where PID='" + txtBarCode.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successful!");
                    conn.Close();
                    Load_Data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
