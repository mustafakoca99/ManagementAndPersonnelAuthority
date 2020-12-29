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

namespace kadircelikproje
{
    public partial class Form5 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        void personel()
        {
            //con = new SqlConnection("Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True");
            da = new SqlDataAdapter("Select *From personel", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "personel");
            dataGridView1.DataSource = ds.Tables["personel"];
            con.Close();
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            personel();
            //datagridview genişliği eşitlendi
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
