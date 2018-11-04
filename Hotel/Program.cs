using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokoj pokoj = new Pokoj(2);
            Gosc gosc = new Gosc("Gajewski");
            pokoj.Zarezerwuj(gosc);
            Console.WriteLine(pokoj);

            Console.ReadKey();
        }
    }
}
