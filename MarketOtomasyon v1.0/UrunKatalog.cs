using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon_v1._0
{
    public class UrunKatalog
    {
        public List<Urun> UrunKatalogu { get; set; }
        public UrunKatalog()
        {
            this.UrunKatalogu = new List<Urun>();
        }
    }
}
