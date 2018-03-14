using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOtomasyon_v1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dukkan d = new Dukkan();
        Urun urun = new Urun();
        KasaGorevlisi kasa1 = new KasaGorevlisi();
        KasaGorevlisi kasa2 = new KasaGorevlisi();
        public void Listele(int a)
        {
            listView1.Items.Add(urun.tanim.UrunAdi);
            listView1.Items[a].SubItems.Add(urun.tanim.UrunKodu.ToString());
            listView1.Items[a].SubItems.Add(urun.tanim.fiyat.ToString());
            listView1.Items[a].SubItems.Add(urun.kalem.miktar.ToString());
        }
        public void HarfGiris(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar)) e.Handled = true;
            else e.Handled = false;
        }
        public void SayiGiris(KeyPressEventArgs e,int sinir)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (txtMusteriTC.TextLength == sinir) e.Handled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440,370);

            urun.tanim.UrunAdi = "kalem";
            urun.tanim.UrunKodu = 12;
            urun.tanim.fiyat = 3.5M;
            urun.kalem.miktar = 10;
            d.UrunEkle(urun);
            Listele(0);

            urun.tanim.UrunAdi = "silgi";
            urun.tanim.UrunKodu = 15;
            urun.tanim.fiyat = 1;
            urun.kalem.miktar = 25;
            d.UrunEkle(urun);
            Listele(1);

            urun.tanim.UrunAdi = "defter";
            urun.tanim.UrunKodu = 23;
            urun.tanim.fiyat = 5;
            urun.kalem.miktar = 15;
            d.UrunEkle(urun);
            Listele(2);
            
            kasa1.Adi = "Ahmet";
            kasa1.Soyad = "Demir";
            kasa1.TCKimlikNo = 12345678910;
            kasa1.sifre = 1234;
                     
            kasa2.Adi = "Ayşe";
            kasa2.Soyad = "Çelik";
            kasa2.TCKimlikNo = 98765432102;
            kasa2.sifre = 5678;
        }
        private void btn_Musteri_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(290, 270);
            Giris.Visible = false;
            gboxMusteriGiris.Visible = true;
        }
        private void btnMusteriGiris_Click(object sender, EventArgs e)
        {
            rdbKasa1.Checked = true;
            rdbKasa1.Visible = true;
            rdbKasa2.Visible = true;
            this.Size = new System.Drawing.Size(700, 480);
            listView1.Size = new System.Drawing.Size(309, 372);
            try
            {
                Musteri m = new Musteri();
                m.Adi = txtMusteriAd.Text;
                m.Soyad = txtMusteriSoyad.Text;
                m.TCKimlikNo = long.Parse(txtMusteriTC.Text);
                gboxMusteriGiris.Visible = false;
                gboxKatalog.Visible = true;
                gboxMusteriSatis.Visible = true;
                tabcKasa.Visible = false;
                txtMusteriAd.Text = "";
                txtMusteriSoyad.Text = "";
                txtMusteriTC.Text = "";
                lblKasa.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Zorunlu Alanları Doldurunuz...\n\n"+"Hata Mesajı : \n"+hata);
            } 
        }
        private void btnKasaGiris_Click(object sender, EventArgs e)
        {
            gboxOdeme.Visible = false;
            gboxMusteriSatis.Visible = false;
            listView1.Size = new System.Drawing.Size(309, 372);
            if (txtKasaTC.Text == (kasa1.TCKimlikNo.ToString()) && txtSifre.Text == (kasa1.sifre.ToString()))
            {
                MessageBox.Show(kasa1.Adi + " adlı kasa görevlisi giriş yapmıştır.(Kasa 1)");
                this.Size = new System.Drawing.Size(700, 480);
                gboxKasaGiris.Visible = false;
                gboxKatalog.Visible = true;
                tabcKasa.Visible = true;
                txtK1.Visible = true;
                txtK2.Visible = false;
                lblKasa.Text = "Kasa1";
            }
            else if (txtKasaTC.Text == (kasa2.TCKimlikNo.ToString()) && txtSifre.Text == (kasa2.sifre.ToString()))
            {
                MessageBox.Show(kasa2.Adi + " adlı kasa görevlisi giriş yapmıştır.(Kasa 2)");
                this.Size = new System.Drawing.Size(700, 480);
                gboxKasaGiris.Visible = false;
                gboxKatalog.Visible = true;
                tabcKasa.Visible = true;
                txtK1.Visible = false;
                txtK2.Visible = true ;
                lblKasa.Text = "Kasa2";
            }
                else
                    MessageBox.Show("Hatalı Giriş Yaptınız.Tekrar Giriniz...");
            txtKasaTC.Text="";
            txtSifre.Text="";
        }
        private void btnAnaekran_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440, 370);
            gboxKatalog.Visible = false;
            Giris.Visible = true;
        }
        Satis s = new Satis();
        private void btnSatis_Click(object sender, EventArgs e)
        {
            gboxOdeme.Visible = true;
            s.Tarih = Convert.ToDateTime(dateTarih.Text);
            urun.kalem.miktar = int.Parse(listView1.SelectedItems[0].SubItems[3].Text);
            urun.tanim.fiyat = decimal.Parse(listView1.SelectedItems[0].SubItems[2].Text);
            urun.tanim.UrunAdi = listView1.SelectedItems[0].SubItems[0].Text;
            s.girilenMiktar = int.Parse(txtMusteriAdet.Text);

            if (urun.kalem.miktar < s.girilenMiktar)
            {
                MessageBox.Show("Ürün Stoklarda bulunmamaktadır.Lütfen başka bir ürün seçin ya da daha az adet giriniz...");
                s.girilenMiktar = 0;
            }
            urun.kalem.miktar -=s.girilenMiktar;        
            lblTutar.Text = s.TutarHesapla(urun.tanim.fiyat).ToString();
            listView1.SelectedItems[0].SubItems[3].Text = urun.kalem.miktar.ToString();
            txtMusteriAdet.Text = "";
            btnSatis.Enabled = false;
            dateTarih.Enabled = false;
            if (rdbKasa1.Checked == true)
            {
                kasa1.KasaNo = 1;
                kasa1.hesapTutar = s.Tutar;
                txtKasa1.Text = kasa1.hesapTutar.ToString();
                Satis s1 = new Satis(kasa1);
                s1.girilenMiktar = s.girilenMiktar;
                s1.Tutar = s.Tutar;
                s1.UrunEkle(urun);               
                txtK1.Text += s1.UrunListele().ToString();
                rdbKasa2.Visible = false;
            }
            else if (rdbKasa2.Checked == true)
            {
                kasa2.KasaNo = 2;
                kasa2.hesapTutar = s.Tutar;
                txtKasa2.Text = kasa2.hesapTutar.ToString();
                Satis s2 = new Satis(kasa2);
                s2.girilenMiktar = s.girilenMiktar;
                s2.Tutar = s.Tutar;
                s2.UrunEkle(urun);
                txtK2.Text += s2.UrunListele().ToString();
                rdbKasa1.Visible = false ;
            }
        }
        int a = 3;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                urun.tanim.UrunAdi = txtUrunAdi.Text;
                urun.tanim.UrunKodu = int.Parse(txtUrunKodu.Text);
                urun.tanim.fiyat = decimal.Parse(txtUrunFiyat.Text);
                urun.kalem.miktar = int.Parse(txtUrunMiktar.Text);
                Listele(a);
                a++;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu ... "+hata);
            }         
        }
        private void btnKasaGorev_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(280,270);
            Giris.Visible = false;
            gboxKasaGiris.Visible = true;
        }
        private void btnAnaEkranEkle_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440, 370);
            gboxKatalog.Visible = false;
            Giris.Visible = true;
        }
        private void btnAnaekranK_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440, 370);
            gboxKatalog.Visible = false;
            Giris.Visible = true;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            urun.kalem.miktar = int.Parse(listView1.SelectedItems[0].SubItems[3].Text);
            int girilenMiktar = int.Parse(txtGuncelAdet.Text);
            urun.kalem.miktar += girilenMiktar;
            listView1.SelectedItems[0].SubItems[3].Text = urun.kalem.miktar.ToString();
            txtGuncelAdet.Text = "";
            btnGuncelle.Enabled = false;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMusteriAdet.Enabled = true;
            txtGuncelAdet.Enabled = true;
        }
        private void txtMusteriAdet_TextChanged(object sender, EventArgs e)
        {
            btnSatis.Enabled = true;
        }
        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Satın Almayı Kabul Ediyor musunuz?", "Satış Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {              
                if (rdbNakit.Checked == true)
                {
                    Nakit n = new Nakit(s);
                    MessageBox.Show(n.OdemeYap());
                }
                else if (rdbKredi.Checked == true)
                {
                    KrediKarti k = new KrediKarti(s);
                    MessageBox.Show(k.OdemeYap());
                }
                gboxOdeme.Visible = false;
                gboxMusteriSatis.Visible = false;
                gboxKatalog.Visible = false;
                Giris.Visible = true;
                lblTutar.Text = "";
                s.Tutar = 0;
                rdbNakit.Checked = true;
                rdbKredi.Checked = false;
                this.Size = new System.Drawing.Size(440, 370);
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Ödeme Yapılmadı.");
            }
        }
        private void txtGuncelAdet_TextChanged(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = true;
        }
        private void txtMusteriTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            SayiGiris(e,11);
        }
        private void txtMusteriAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            HarfGiris(e);
        }
        private void txtMusteriSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            HarfGiris(e);
        }
        private void txtMusteriAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            SayiGiris(e, 4);
        }
        private void txtGuncelAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            SayiGiris(e, 4);
        }       
        private void txtUrunAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            HarfGiris(e);
        }
        private void txtUrunKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            SayiGiris(e, 3);
        }
        private void txtUrunMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            SayiGiris(e, 4);
        }
        private void txtKasaTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            SayiGiris(e, 11);
        }
        private void btnCikis1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak Istediğinize Emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)  Close();
            else if (dialogResult == DialogResult.No) { }
        }

        private void btnCikis2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak Istediğinize Emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) Close();
            else if (dialogResult == DialogResult.No) { }
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak Istediğinize Emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) Close();
            else if (dialogResult == DialogResult.No) { }
        }

        private void btnHesapAna_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440, 370);
            gboxKatalog.Visible = false;
            Giris.Visible = true;
        }

        private void btngeri1_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440, 370);
            gboxKasaGiris.Visible = false;
            Giris.Visible = true;
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(440, 370);
            gboxMusteriGiris.Visible = false;
            Giris.Visible = true;
        }
    }
}
