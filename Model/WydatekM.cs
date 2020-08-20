using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektZaliczeniowyMVVMNet.Model
{
    public enum KategoriaWydatku:byte
    {
        Żywnośc, Prąd, Woda, Sport, Rozrywka, Ubranie, DomoweZwierzaki, Multimedia, ŚrodkiHigieniczne,
        Kosmetyki, NieprzewidzianeWydatki, Kredyty, Wakacje,Paliwo, Oszczędności, Inne
    }
    public class WydatekM
    {

        // definicja pól
        public string NaCoWdano { get; private set; }
        public string IleWydano { get; private set; }
        public KategoriaWydatku KategoriaWydatku { get; private set; }
        // konstruktor
        public WydatekM(string naCoWydano, string ileWydano, KategoriaWydatku kategoriaWydatku)
        {
            this.NaCoWdano = naCoWydano;
            this.IleWydano = ileWydano;
            this.KategoriaWydatku = kategoriaWydatku;

        }

        public override string ToString()
        {
            return NaCoWdano + " wydano " + IleWydano.ToString() + "." + "Wydatek należy do kategorii " + KategoriaWydatku;
        }

       
        }
}
