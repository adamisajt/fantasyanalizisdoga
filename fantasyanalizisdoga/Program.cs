using System;

namespace fantasyanalizisdoga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SzornyAdatbazis szornyAdatbazis = new SzornyAdatbazis();
            var szornyLista = szornyAdatbazis.Feltolt();

            Szornyelemzo szornyElemzo = new Szornyelemzo(szornyLista);

            Console.WriteLine($"osszes szorny szama: {szornyElemzo.OsszesSzornySzama()}");

            Console.WriteLine("veszelyes szornyek neve:");
            foreach (string nev in szornyElemzo.VeszelyesSzornyekNevei())
            {
                Console.WriteLine($"- {nev}");
            }

            Console.WriteLine("egyedi elohelyek:");
            foreach (string elohely in szornyElemzo.EgyediElohelyek())
            {
                Console.WriteLine($"- {elohely}");
            }

            Console.WriteLine($"atlagos veszelyessegi szint: {szornyElemzo.AtlagosVeszelyessegiSzint()}");

            Console.WriteLine("harom legveszelyesebb szorny:");
            foreach (Szorny szorny in szornyElemzo.LegveszelyesebbSzornyek(3))
            {
                Console.WriteLine($"- {szorny.Nev} ({szorny.VeszelyessegiSzint})");
            }

            Console.WriteLine("Fekete mocsarban elo legalabb otos veszelyessegi szintu szornyek");
            foreach (Szorny szorny in szornyElemzo.FeketeMocsarbanEloLegalabbOtosVeszelyessegiSzintuSzornyek())
            {
                Console.WriteLine($"- {szorny.Nev} ({szorny.VeszelyessegiSzint})");
            }

            Console.WriteLine($"Van extremtuzgyenge szorny: {szornyElemzo.VanExtremTuzGyengeSzorny()}");

            Console.WriteLine("szornyek szama elohelyenkent:");
            foreach (string elohelyAdat in szornyElemzo.SzornyekSzamaElohelyenkent())
            {
                Console.WriteLine($"- {elohelyAdat}");
            }
        }
    }
}
