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
//using System.Data;

namespace kadircelikproje
{
    public partial class Form2 : Form
    {
        //static string conString = "Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True";
        
        SqlConnection con=new SqlConnection("Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True");
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
        public Form2()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Yönetici")
            {
                try
                {
                    if (con.State==ConnectionState.Closed)
                    {
                        con.Open();
                        string kayit = "insert into yonetici(yonetici_adi,yonetici_soyadi,mail,sifre) values (@yonetici_adi,@yonetici_soyadi,@mail,@sifre)";
                        SqlCommand komut = new SqlCommand(kayit, con);
                        //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                        komut.Parameters.AddWithValue("@yonetici_adi", textBox1.Text);
                        komut.Parameters.AddWithValue("@yonetici_soyadi", textBox2.Text);
                        komut.Parameters.AddWithValue("@mail", textBox3.Text);
                        komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                        //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                        komut.ExecuteNonQuery();
                        //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                        con.Close();
                        yonetici();
                        MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
                        
                    }
                    //con = new SqlConnection("Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True");
                    else
                    {
                        MessageBox.Show("internete bağlı değilsiniz!");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("kayıt başarısız!");
                }
                
            }
            else if (comboBox1.SelectedItem.ToString() == "Personel")
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        string kayit = "insert into personel(personel_adi,personel_soyadi,mail,sifre) values (@personel_adi,@personel_soyadi,@mail,@sifre)";
                        SqlCommand komut = new SqlCommand(kayit, con);
                        //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                        komut.Parameters.AddWithValue("@personel_adi", textBox1.Text);
                        komut.Parameters.AddWithValue("@personel_soyadi", textBox2.Text);
                        komut.Parameters.AddWithValue("@mail", textBox3.Text);
                        komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                        //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                        komut.ExecuteNonQuery();
                        //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                        con.Close();
                        personel();
                        MessageBox.Show("Kayıt İşlemi Gerçekleşti.");

                    }
                    //con = new SqlConnection("Data Source=.;Initial Catalog=kadircelikotomasyon;Integrated Security=True");
                    else
                    {
                        MessageBox.Show("internete bağlı değilsiniz!");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("kayıt başarısız!");
                }

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Yönetici");
            comboBox1.Items.Add("Personel");
            yonetici();
            personel();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
