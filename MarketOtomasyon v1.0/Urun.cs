using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon_v1._0
{
    public class Urun
    {
        public SatisKalemi kalem { get; set; }
        public UrunTanimi tanim { get; set; }

        public Urun()
        {
            this.tanim = new UrunTanimi();
            this.kalem = new SatisKalemi();
        }
    }
}
