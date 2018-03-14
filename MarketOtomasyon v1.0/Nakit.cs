using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon_v1._0
{
    public class Nakit : Odeme
    {
        public Nakit(Satis s)
        {
            this.satis = s;
            this.odemeMiktari = satis.Tutar;
        }
        public override string OdemeYap()
        {
            return this.odemeMiktari.ToString() + "TL Nakit Ödenmiştir...";
        }
    }
}
