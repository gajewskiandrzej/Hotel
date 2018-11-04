using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Pokoj
    {
        public int NrPokoju { get; set; }
        public string NazwiskoGoscia { get; set; }
        private StanPokoju StanPokoju;

        public Pokoj (int nrPokoju)
        {
            NrPokoju = nrPokoju;
        }

        public void Zarezerwuj(string nazwisko)
        {
            nazwisko = string.Empty;
            StanPokoju stan = StanPokoju.zarezerwowany;
        }
    }
}
