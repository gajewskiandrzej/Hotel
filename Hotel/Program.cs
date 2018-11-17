using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public enum StanPokoju { wolny, zajety, zarezerwowany, wycofany }

    public abstract class Rezerwacja
    {
        public int pokoj;

        public abstract bool WyszukajWolnyPokoj(StanPokoju stanPokoju);
        public abstract void ZarezerwujPokoj(ref int pokoj);
    }

    public class Pokoj
    {
        int nrPokoju { get; set; }
        string nazwiskoGoscia;
        public string NazwiskoGoscia
        {
            get
            {
                return nazwiskoGoscia;
            }
            set
            {
                nazwiskoGoscia = value;
            }
        }
        StanPokoju stanPokoju = StanPokoju.wolny;

        public Pokoj(int nrPokoju)
        {
            this.nrPokoju = nrPokoju;
        }

        public void Zarezerwuj(string nazwiskoGoscia)
        {
            stanPokoju = StanPokoju.zarezerwowany;
            NazwiskoGoscia = nazwiskoGoscia;
        }

        public void Wydaj()
        {
            stanPokoju = StanPokoju.zajety;
            NazwiskoGoscia = nazwiskoGoscia;
        }

        public void Przyjmij()
        {
            stanPokoju = StanPokoju.wolny;
            NazwiskoGoscia = string.Empty;
        }

        public void Wycofaj()
        {
            stanPokoju = StanPokoju.wycofany;
        }

        public override string ToString()
        {
            return String.Format("Numer pokoju: {0} Nazwisko gościa: {1} Stan pokoju: {2}", nrPokoju, nazwiskoGoscia, stanPokoju);
        }
    }

    class Gosc : Rezerwacja
    {
        string nazwisko;
        public string Nazwisko { get; set; }

        public Gosc(string nazwisko)
        {
            this.nazwisko = nazwisko;
        }

        public override bool WyszukajWolnyPokoj(StanPokoju stanPokoju)
        {
            if (stanPokoju == StanPokoju.wolny)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ZarezerwujPokoj(ref int nrPokoju)
        {
            StanPokoju stanPokoju = StanPokoju.zarezerwowany;
            Nazwisko = nazwisko;
        }
    }

    class Hotel
    {

    }

    class DyrektorHotelu
    {
        public static void DodajPokoj()
        {

        }

        public static void WycofajPokoj()
        {

        }
    }

    class Recepcjonista
    {
        public static void WyszukajWolnyPokoj()
        {

        }

        public static void WyszukajZarezerwowany()
        {

        }

        public static void ZarezerwujPokoj()
        {

        }

        public static void ZwolnijPokoj()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pokoj pokoj1 = new Pokoj(1);
            Pokoj pokoj2 = new Pokoj(2);
            pokoj1.Zarezerwuj("Gajewski");

            Gosc gosc1 = new Gosc("Nowak");
            gosc1.ZarezerwujPokoj(2);

            Console.WriteLine(pokoj1);
            Console.WriteLine(pokoj2);

            Console.ReadKey();
        }
    }
}
