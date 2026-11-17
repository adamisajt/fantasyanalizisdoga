using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fantasyanalizisdoga
{
    internal class Szornyelemzo
    {
        private readonly List<Szorny> szornyLista;
        public Szornyelemzo(List<Szorny> szornyek)
        {
            szornyLista = szornyek;
        }
        public int OsszesSzornySzama()
        {
            return szornyLista.Count;
        }
        public IEnumerable<string> VeszelyesSzornyekNevei()
        {
            return szornyLista.Where(szorny => szorny.VeszelyesE).Select(szorny => szorny.Nev);
        }
        public IEnumerable<string> EgyediElohelyek()
        {
            return szornyLista.Select(szorny => szorny.Elohely).Distinct();
        }
        public double AtlagosVeszelyessegiSzint()
        {
            return szornyLista.Average(szorny => szorny.VeszelyessegiSzint);
        }
        public IEnumerable<Szorny> LegveszelyesebbSzornyek(int topN)
        {
            return szornyLista.OrderByDescending(szorny => szorny.VeszelyessegiSzint).Take(topN);
        }

        public IEnumerable<Szorny> FeketeMocsarbanEloLegalabbOtosVeszelyessegiSzintuSzornyek()
        {
            return szornyLista.Where(szorny => szorny.Elohely == "FeketeMocsár" && szorny.VeszelyessegiSzint >= 5);
        }
        public bool VanExtremTuzGyengeSzorny()
        {
            return szornyLista.Any(szorny => szorny.FoGyengeseg == "Tűz" && szorny.VeszelyessegiSzint >= 8);
        }
        public IEnumerable<string> SzornyekSzamaElohelyenkent()
        {
            return szornyLista.GroupBy(szorny => szorny.Elohely)
                             .Select(group => $"{group.Key}: {group.Count()}");
        }

    }
}
