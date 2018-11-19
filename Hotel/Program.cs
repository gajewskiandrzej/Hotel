using System;
using System.Collections.Generic;

namespace Hotel
{
    public enum StanPokoju { wolny, zajety, zarezerwowany, wycofany }

    public abstract class Rezerwacja
    {
        public void WyszukajWolnyPokoj()
        {
            foreach (Pokoj pokoj in Hotel.pokoje)
            {
                if (pokoj.StanPokoju == StanPokoju.wolny)
                {
                    Console.WriteLine("Wolny pokoj: " + pokoj.NrPokoju);
                }
            }
        }
        public void ZarezerwujPokoj(byte nrPokoju, Gosc gosc)
        {
            foreach (Pokoj pokoj in Hotel.pokoje)
            {
                if(pokoj.NrPokoju == nrPokoju)
                {
                    pokoj.StanPokoju = StanPokoju.zarezerwowany;
                    pokoj.NazwiskoGoscia = gosc.Nazwisko;
                }
            }
        }
    }

    public class Pokoj
    {
        public byte NrPokoju { get; set; }
        public string NazwiskoGoscia { get; set; }
        public StanPokoju StanPokoju { get; set; }

        public Pokoj(byte nrPokoju, string nazwiskoGoscia, StanPokoju stanPokoju)
        {
            NrPokoju = nrPokoju;
            NazwiskoGoscia = nazwiskoGoscia;
            StanPokoju = stanPokoju;
        }

        public Pokoj()
        {
            NrPokoju = 0;
            NazwiskoGoscia = string.Empty;
            StanPokoju = StanPokoju.wolny;
        }

        public void Zarezerwuj(byte nrPokoju, string nazwiskoGoscia)
        {
            NrPokoju = nrPokoju;
            StanPokoju = StanPokoju.zarezerwowany;
            NazwiskoGoscia = nazwiskoGoscia;
        }

        public void Wydaj(byte nrPokoju, string nazwiskoGoscia)
        {
            NrPokoju = nrPokoju;
            StanPokoju = StanPokoju.zajety;
            NazwiskoGoscia = nazwiskoGoscia;
        }

        public void Przyjmij(byte nrPokoju)
        {
            NrPokoju = nrPokoju;
            StanPokoju = StanPokoju.wolny;
            NazwiskoGoscia = string.Empty;
        }

        public void Wycofaj(byte nrPokoju)
        {
            NrPokoju = nrPokoju;
            StanPokoju = StanPokoju.wycofany;
            NazwiskoGoscia = string.Empty;
        }

        public override string ToString()
        {
            return String.Format("Numer pokoju: {0} Stan pokoju: {1} Nazwisko gościa: {2}", NrPokoju, StanPokoju, NazwiskoGoscia);
        }
    }

    public class Hotel
    {
        public static Queue<Pokoj> pokoje = new Queue<Pokoj>();

        public void PokazPokoje()
        {
            foreach (Pokoj pokoj in pokoje)
            {
                Console.WriteLine(pokoj);
            }
        }
    }


    public class Gosc : Rezerwacja
    {
        public string Nazwisko { get; set; }
    
        public Gosc(string nazwisko)
        {
            Nazwisko = nazwisko;
        }

        public Gosc()
        {
            Nazwisko = string.Empty;
        }
    }


    public class DyrektorHotelu
    {
        public void DodajPokoj(Pokoj pokoj)
        {
            Hotel.pokoje.Enqueue(pokoj);
        }

        public void WycofajPokoj(byte nrPokoju)
        {
            foreach (Pokoj pokoj in Hotel.pokoje)
            {
                if(pokoj.NrPokoju == nrPokoju)
                {
                    pokoj.StanPokoju = StanPokoju.wycofany;
                }
            }
        }
    }

    class Recepcjonista : Rezerwacja
    {
        public void WyszukajZarezerwowany()
        {
            foreach (Pokoj pokoj in Hotel.pokoje)
            {
                if (pokoj.StanPokoju == StanPokoju.zarezerwowany)
                {
                    Console.WriteLine("Zarezerwowany pokoj: " + pokoj.NrPokoju + " Nazwisko gościa: " + pokoj.NazwiskoGoscia);
                }
            }
        }

        public void ZwolnijPokoj(byte nrPokoju)
        {
            foreach (Pokoj pokoj in Hotel.pokoje)
            {
                if (pokoj.NrPokoju == nrPokoju)
                {
                    pokoj.NrPokoju = nrPokoju;
                    pokoj.StanPokoju = StanPokoju.wolny;
                    pokoj.NazwiskoGoscia = string.Empty;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Hotel hotel = new Hotel();
            Pokoj pokoj1 = new Pokoj(1, "", StanPokoju.wolny);
            Pokoj pokoj2 = new Pokoj(2, "", StanPokoju.wolny);
            Pokoj pokoj3 = new Pokoj(3, "", StanPokoju.wolny);
            Pokoj pokoj4 = new Pokoj(4, "", StanPokoju.wolny);
            Pokoj pokoj5 = new Pokoj(5, "", StanPokoju.wolny);

            DyrektorHotelu dyrektorHotelu = new DyrektorHotelu();

            dyrektorHotelu.DodajPokoj(pokoj1);
            dyrektorHotelu.DodajPokoj(pokoj2);
            dyrektorHotelu.DodajPokoj(pokoj3);
            dyrektorHotelu.DodajPokoj(pokoj4);
            dyrektorHotelu.DodajPokoj(pokoj5);

            Recepcjonista recepcjonistkaGosia = new Recepcjonista();

            Console.WriteLine("Otwarcie hotelu");
            Console.WriteLine("=================================");
            hotel.PokazPokoje();

            Gosc gosc1 = new Gosc("Gajewski");
            Gosc gosc2 = new Gosc("Wiśniewski");
            Gosc gosc3 = new Gosc("Nowak");
            Gosc gosc4 = new Gosc("Kowalski");

            Console.WriteLine("Lista wolnych pokoi:");
            Console.WriteLine("=================================");
            gosc1.WyszukajWolnyPokoj();
            gosc1.ZarezerwujPokoj(1, gosc1);
            gosc3.ZarezerwujPokoj(2, gosc3);

            Console.WriteLine("Lista zarezerwowanych pokoi:");
            Console.WriteLine("=================================");
            recepcjonistkaGosia.WyszukajZarezerwowany();

            Console.WriteLine("Lista wolnych pokoi po rezerwacji:");
            Console.WriteLine("=================================");
            gosc1.WyszukajWolnyPokoj();

            Console.WriteLine("Lista pokoi po rezerwacji:");
            Console.WriteLine("=================================");
            hotel.PokazPokoje();

            dyrektorHotelu.WycofajPokoj(5);
            Console.WriteLine("Lista pokoi po operacji dyrektora:");
            Console.WriteLine("=================================");
            hotel.PokazPokoje();

            recepcjonistkaGosia.ZarezerwujPokoj(4, gosc2);
            recepcjonistkaGosia.ZwolnijPokoj(2);
            Console.WriteLine("Lista pokoi po operacji sekretarki:");
            Console.WriteLine("=================================");
            hotel.PokazPokoje();


            Console.ReadKey();
        }
    }
}
