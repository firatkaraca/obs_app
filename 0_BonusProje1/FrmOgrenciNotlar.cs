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

namespace _0_BonusProje1
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-8NNOKBJ\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmOgrenciNot_Load(object sender, EventArgs e)
        {
            //AdıSoyadı Çekme
            baglanti.Open();
            SqlCommand adgetir = new SqlCommand("SELECT OGRAD+' '+OGRSOYAD FROM TBLOGRENCILER WHERE OGRID=@K1 ", baglanti);
            adgetir.Parameters.AddWithValue("@K1", numara);
            SqlDataReader dr = adgetir.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0].ToString();
            }      
            baglanti.Close();


            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID = @p1", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
