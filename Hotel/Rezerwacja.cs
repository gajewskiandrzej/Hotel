using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public abstract class Rezerwacja
    {
        public int NrPokoju { get; set; }

        public abstract StanPokoju WyszukajWolnyPokoj(StanPokoju stanPokoju);
        public abstract void ZarezerwujPokoj(StanPokoju stanPokoju);
    }
}
