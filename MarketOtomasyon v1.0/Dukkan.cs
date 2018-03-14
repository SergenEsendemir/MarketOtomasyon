using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon_v1._0
{
    public class Dukkan 
    {
        public UrunKatalog urunKat { get; set; }
        public Dukkan()
        {
            this.urunKat = new UrunKatalog();
        }
        public void UrunEkle(Urun urun)
        {
            urunKat.UrunKatalogu.Add(urun);
        }
    }
}
