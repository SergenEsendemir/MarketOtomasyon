using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon_v1._0
{
    public class KasaGorevlisi : Kisi
    {
        public int sifre { get; set; }
        public int KasaNo { get; set; }
        public virtual decimal hesapTutar { get; set; }
    }
}
