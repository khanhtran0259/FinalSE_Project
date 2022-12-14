using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration; 

namespace FinalProject
{
    public partial class FormExport : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public FormExport()
        {
            InitializeComponent();
        }
        private void Load_Data()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select P.PID, P.PName, P.PPrice*1.05 as Price , P.PQuantity, P.PPrice*P.PQuantity as Total from Product P";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            drgExport.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            { printDocument1.Print(); }
        }

        private void FormExport_Load(object sender, EventArgs e)
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
            if (txtExCode.Text == "" || txtExName.Text == "")
            {
                MessageBox.Show("Missing Information. Please check again!");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    string query = "insert into ExportRecived values('" + txtExCode.Text + "', N'" + txtExName.Text + "',N'" + txtEmpCode.Text + "',N'"  + txtAgentID.Text + "', N'" + dateExport.Value.Date + "'  )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Create New Export Successful!");
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

        private void rbtnExport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnExport.Checked)
            {

                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string query = "select * from ExportRecived ";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                drgExport.DataSource = ds.Tables[0];
                conn.Close();
            }
        }

        private void drgExport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rbtnExport.Checked)
            {
                if (drgExport.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
                {
                    drgExport.CurrentRow.Selected = true;
                    txtExCode.Text = drgExport.Rows[e.RowIndex].Cells["ERID"].FormattedValue.ToString();
                    txtAgentID.Text = drgExport.Rows[e.RowIndex].Cells["AgentID"].FormattedValue.ToString();
                    txtEmpCode.Text = drgExport.Rows[e.RowIndex].Cells["EmpID"].FormattedValue.ToString();


                }
            }

            else
            {
                if (drgExport.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
                {
                    drgExport.CurrentRow.Selected = true;

                    txtBarCode.Text = drgExport.Rows[e.RowIndex].Cells["PID"].FormattedValue.ToString();
                    txtProductName.Text = drgExport.Rows[e.RowIndex].Cells["PName"].FormattedValue.ToString();
                    txtProductPrice.Text = drgExport.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
                    

                }
            }
            
            

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtExCode.Text == "")
            {
                MessageBox.Show("Missing Information. Please check again!");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    string query = "insert into ExportDetails values('" + txtExCode.Text + "',N'" + txtBarCode.Text + "','" + txtProductPrice.Text + "', N'" + txtQuantity.Text + "'  )";
                    string query1 = "Update Product Set PQuantity = PQuantity - "+txtQuantity.Text+"where PID ="+txtBarCode.Text;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select ED.EDID, ED.PID, P.PName, ED.PPriceExport as Price, ED.PQuantity as Quantity, ED.PPriceExport*ED.PQuantity as Total from ExportDetails ED full outer join Product P on ED.PID = P.PID  where ED.EDID = '" + txtExCode.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            drgExport.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtExCode.Text == "")
            {
                MessageBox.Show("Missing Information. Please check again!");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();
                    string query = "delete from ExportDetails where PID='"+txtBarCode.Text+"'";
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("  =====Export Bill=====", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180));
            e.Graphics.DrawString("SSN: " + txtAgentID.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkGreen, new Point(60, 120));
            e.Graphics.DrawString("Full Name: " + txtEmpCode.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkGreen, new Point(60, 160));
            e.Graphics.DrawString("BirthDay: " + dateExport.Value.ToShortDateString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkGreen, new Point(60, 200));
            e.Graphics.DrawString("Address: " + txtProductName.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkGreen, new Point(60, 240));
            e.Graphics.DrawString("Salary: " + txtProductPrice.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkGreen, new Point(60, 280));
            e.Graphics.DrawString("SuperSSN: " + txtQuantity.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.DarkGreen, new Point(60, 320));
        }

        

        
    }
}
