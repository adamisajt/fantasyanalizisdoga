using System;
using System.Collections.Generic;
using System.Text;

namespace fantasyanalizisdoga
{
    internal class Szornyelemzo
    {
        private string szornyek;
        List<Szorny> szornyLista = new List<Szorny>();
        public Szornyelemzo(string szornyek)
        {
            this.szornyek = szornyek;
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

    }
}
