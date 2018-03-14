using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon_v1._0
{
    public class Satis
    {
        public DateTime Tarih { get; set; }
        private List<Urun> UrunListesi { get; set; }
        protected KasaGorevlisi kasa { get; set; }
        public decimal Tutar { get; set; }
        public int girilenMiktar { get; set; }

        public Satis()
        {
            this.Tutar = 0;
            this.UrunListesi = new List<Urun>();
        }

        public Satis(KasaGorevlisi _kg)
        {
            this.Tutar = 0;
            this.kasa = _kg;
            this.UrunListesi = new List<Urun>();
        }       

        public decimal TutarHesapla(decimal fiyat)
        {
            Tutar += this.girilenMiktar * fiyat;
            return Tutar;
        }
        public void UrunEkle(Urun u)
        {
            UrunListesi.Add(u);
        }

        public string UrunListele ()
        {
            string temp = "";
            foreach (Urun u in UrunListesi)
            {
                temp ="Kasa No : "+ this.kasa.KasaNo.ToString() +"  Ürün Adı : " + u.tanim.UrunAdi + "  Ürün Miktarı : " +this.girilenMiktar.ToString() + "  Ürün Fiyatı : " + u.tanim.fiyat.ToString() +Environment.NewLine;
            }
            return temp;
        }

    }
}
