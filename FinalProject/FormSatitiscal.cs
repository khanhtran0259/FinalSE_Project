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
    public partial class FormSatitiscal : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public FormSatitiscal()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void Load_Data()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select P.PName from Product P order by P.PQuantity desc";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dgrvBest.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void btnStatis_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select SUM (ID.PPriceImport*ID.PQuantity) as Total_ImPort from ImportDetails ID";
            string query1 = "select SUM (ED.PPriceExport*ED.PQuantity) as Total_Export from ExportDetails ED";
            string query2 = "select SUM (ED.PPriceExport*ED.PQuantity) - SUM (ID.PPriceImport*ID.PQuantity) as Profit from ImportDetails ID, ExportDetails ED";
            SqlCommand cmd1 = new SqlCommand(query, conn);
            SqlCommand cmd2 = new SqlCommand(query1, conn);
            SqlCommand cmd3 = new SqlCommand(query2, conn);
            SqlDataReader sqlDataReader = cmd1.ExecuteReader();
            SqlDataReader sqlDataReader1 = cmd2.ExecuteReader();
            SqlDataReader sqlDataReader2 = cmd3.ExecuteReader();
            if (sqlDataReader.Read() && sqlDataReader1.Read() && sqlDataReader2.Read())
            {
                lblImport.Text = sqlDataReader["Total_ImPort"].ToString();
                lblExport.Text = sqlDataReader1["Total_Export"].ToString();
                lblProfit.Text = sqlDataReader2["Profit"].ToString();

            }
            conn.Close();
        }

        private void rbtnImport_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnImport.Checked)
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string query = "select ID.IDID, ID.PID, P.PName, ID.PPriceImport as Price, ID.PQuantity as Quantity, ID.PPriceImport*ID.PQuantity as Total  from ImportDetails ID full outer join Product P on ID.PID = P.PID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                dgrvStatis.DataSource = ds.Tables[0];
                conn.Close();
            }
        }

        private void rbtnExport_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnExport.Checked)
            {
                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                string query = "select ED.EDID, ED.PID, P.PName, ED.PPriceExport as Price, ED.PQuantity as Quantity, ED.PPriceExport*ED.PQuantity as Total  from ExportDetails ED full outer join Product P on ED.PID = P.PID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                dgrvStatis.DataSource = ds.Tables[0];
                conn.Close();
            }
        }

        private void FormSatitiscal_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
    }
}
