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

namespace Red_Rose
{
    public partial class Stoklar1 : Form
    {
        public Stoklar1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=RedRosePansiyon;Integrated Security=True");
        
        private void veriler()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Stoklar1",baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Gida"].ToString();
                ekle.SubItems.Add(oku["icecekler"].ToString());
                ekle.SubItems.Add(oku["Atistirmaliklar"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void veriler2()
        {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Faturalar1", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku2["Elektrik"].ToString();
                ekle.SubItems.Add(oku2["Su"].ToString());
                ekle.SubItems.Add(oku2["internet"].ToString());
                listView2.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void Btn_Kaydet_1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Stoklar1(Gida,icecekler,Atistirmaliklar) values('" + TxtGidalar1.Text + "','" + Txtİcecekler1.Text + "','" + TxtAtistirmaliklar1.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close() ;
            veriler();
        }

        private void Stoklar1_Load(object sender, EventArgs e)
        {
            veriler();
            veriler2();
        }

        private void BtnKaydet2_2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Faturalar1(Elektrik,Su,internet) values('" + TxtElektrik1.Text + "','" +TxtSu1.Text + "','" + Txtinternet1.Text + "')", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            veriler2();
        }
    }
}

/*baglanti.Open();
SqlCommand komut = new SqlCommand("insert into Stoklar(Gida,İcecek,Cerezler)values ('" + TxtGidalar.Text + "','" + Txtİcecekler.Text + "','" + TxtAtistirmaliklar.Text + "')", baglanti);
komut.ExecuteNonQuery();
baglanti.Close();
veriler();



 */