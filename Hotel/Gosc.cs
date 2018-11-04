using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Gosc : Rezerwacja
    {
        string Nazwisko { get; set; }

        public Gosc (string Nazwisko)
        {
            this.Nazwisko = Nazwisko;
        }

        public override void ZarezerwujPokoj(StanPokoju stanPokoju)
        {
            stanPokoju = StanPokoju.zarezerwowany;
        }

        public override StanPokoju WyszukajWolnyPokoj(StanPokoju stanPokoju)
        {
            if (stanPokoju == StanPokoju.wolny)
                return stanPokoju;
            else
                return 0;
        }
    }
}
