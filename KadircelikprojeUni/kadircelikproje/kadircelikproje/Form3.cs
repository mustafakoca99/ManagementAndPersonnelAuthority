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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        void yonetici()
        {

            da = new SqlDataAdapter("Select *From yonetici", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "yonetici");
            dataGridView1.DataSource = ds.Tables["yonetici"];
            con.Close();
        }
        void personel()
        {
            //con = new SqlConnection("Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True");
            da = new SqlDataAdapter("Select *From personel", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "personel");
            dataGridView2.DataSource = ds.Tables["personel"];
            con.Close();
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()=="Yönetici")
            {
                try
                {
                    if (con.State==ConnectionState.Closed)
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("select*from yonetici where mail='" + textBox3.Text + "' and sifre='" + textBox4.Text + "'", con);
                        SqlDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {

                            MessageBox.Show("Giriş başarılı :)");
                            Form4 frm4 = new Form4();
                            frm4.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Giriş başarısız...");
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("bağlantı hatası!");
                    }
                }
             
                catch (Exception)
                {
                MessageBox.Show("başarısız...");

                   // throw;
                }
            }


            else if (comboBox1.SelectedItem.ToString() == "Personel")
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("select*from personel where mail='" + textBox3.Text + "' and sifre='" + textBox4.Text + "'", con);
                        SqlDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {

                            MessageBox.Show("Giriş başarılı :)");
                            Form5 frm5 = new Form5();
                            frm5.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Giriş başarısız...");
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("bağlantı hatası!");
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("başarısız...");

                    // throw;
                }
            }

            else
            {
                MessageBox.Show("hatalı seçim!");
            }

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Yönetici");
            comboBox1.Items.Add("Personel");
            personel();
            yonetici();
        }
    }
}
