using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulApp.BLL;

namespace OkulAppSube1BIL
{
    public partial class frmOgrKayit : Form
    {

        public int Ogrenciid { get; set; }
        public frmOgrKayit()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı!" : "Ekleme Başarısız!!");

                // Ekleme işlemi başarılıysa textbox'ları temizle
                if (sonuc)
                    Temizle();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Number == 2627 ? "Bu numaralı öğrenci daha önce kayıtlı" : "Veritabanı hatası");
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }

        // ...

        private void Temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtNumara.Text = "";
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            frmOgrBul frm = new frmOgrBul(this);
            frm.ShowDialog(); // ShowDialog kullanarak bul formunu modal olarak aç

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), Ogrenciid = Ogrenciid });
                MessageBox.Show("Güncelleme Başarılı!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Number == 2627 ? "Bu numaralı öğrenci daha önce kayıtlı" : "Veritabanı hatası");
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                obl.OgrenciSil(Ogrenciid);
                MessageBox.Show("Silme Başarılı!");
                this.Close(); // Silme işlemi başarılıysa formu kapat
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Number == 2627 ? "Bu numaralı öğrenci daha önce kayıtlı" : "Veritabanı hatası");
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }
    }

    //Güncelleme Başarılı mesajı
    //Güncelleme butonu aktifliği?
    //Silme butonu aktifliği
    //Silme işlemi mesajı
    //Tüm işlemlerde try-catch
    //Helperda bulunan connection ve commandlerin dispose edilmesi (IDisposable Pattern)
    //Singleton Pattern (Sürkeli nesne oluşmadan tek nesne üstünden işlemlerin yapılması)
    //Öğretmen entity'si için kalan CRUD işlemleri



    interface ITransfer
    {
        int Eft(string gondericiiban, string aliciiban, double tutar);
        int Havale(string gondericiiban, string aliciiban, double tutar);

    }

    class Transfer : ITransfer
    {
        public int Eft(string gondericiiban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }

        public int Havale(string gondericiiban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }

        //
    }
}

//Garbage Collector
