using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon_v1._0
{
    public abstract class Odeme
    {
        protected Satis satis { get; set; }
        protected decimal odemeMiktari { get; set; }
        public abstract string OdemeYap();

    }
}
