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
    public partial class Details : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public Details()
        {
            InitializeComponent();
        }

        private void dgrvViewDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Load_Data() {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string query = "select ID.IDID, IR.IDName, ID.PID, IR.EmpID, ID.PPriceImport as Price, ID.PQuantity as Quantity, ID.Total, IR.DateImport from  ImportDetails ID full outer join ImportRecived IR on IR.IRID = ID.IDID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dgrvViewDetails.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
