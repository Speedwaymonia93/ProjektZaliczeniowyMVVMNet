using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace ProjektZaliczeniowyMVVMNet.Model
{
   public static class PlikXml
    {
        private static readonly IFormatProvider formatProvider = CultureInfo.InvariantCulture;

        public static void Zapisz(this WydatkiM wydatki, string ścieżkadoPliku)
        {
            try
            {
                XDocument xml = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Data_zapisania" + DateTime.Now.ToString(formatProvider)),
                    new XElement("Wydatki",
                    from WydatekM wydatek in wydatki
                    select new XElement("Wydatek",
                    new XElement("Na_co_wydano", wydatek.NaCoWdano),
                    new XElement("Ile_wydano", wydatek.IleWydano),
                    new XElement("Kategoria_wydatku", ((byte)wydatek.KategoriaWydatku)))));
                    xml.Save(ścieżkadoPliku);
                    
                
            }
            catch(Exception exc)
            {
                throw new Exception("Błąd przy sapisie danych do pliku XML", exc);
            }
        }

        public static WydatkiM Czytaj(string ścieżkadoPliku)
        {
            try
            {
                XDocument xml = XDocument.Load(ścieżkadoPliku);
                IEnumerable<WydatekM> daneWydatki =
                    from wydatek in xml.Root.Descendants("Wydatek")
                    select new WydatekM(
                        wydatek.Element("Na_co_wydano").Value,
                        wydatek.Element("Ile_wydano").Value,
                        (KategoriaWydatku)byte.Parse(wydatek.Element("Kategoria_wydatku").Value, formatProvider));
                WydatkiM wydatki = new WydatkiM();
                foreach (WydatekM wydatek in daneWydatki) wydatki.DodajWydatek(wydatek);
                return wydatki;
            }
            catch(Exception exc)
            {
                throw new Exception("Błąd przt odczycie danych z pliku XML", exc);
            }
        }
    }
}
