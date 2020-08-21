using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace ProjektZaliczeniowyMVVMNet.Model
{
    public class WydatkiM : IEnumerable<WydatekM>
    {
        // prywatna lista wydatków i zainicjowanie jej
        private List<WydatekM> listaWydatków = new List<WydatekM>();

        // operacje CRUD
        // dodawanie wydatek
        public void DodajWydatek(WydatekM wydatek)
        {
            listaWydatków.Add(wydatek);
           policzKategorie(wydatek);
            
        }

        public DaneM dane = new DaneM();
       
        // policzenie kategoruu
        public void policzKategorie(WydatekM wydatek)
        {//  Żywnośc, Prąd, Woda, Sport, Rozrywka, Ubranie, DomoweZwierzaki, Multimedia, ŚrodkiHigieniczne,
         //   Kosmetyki, NieprzewidzianeWydatki, Kredyty, Wakacje,Paliwo, Oszczędności, Inne
            var kategoria = (int)wydatek.KategoriaWydatku;
            int żywnośćCount = 0;
            int prądCount = 0;
            int wodaCount = 0;
            int sportCount = 0;
            int rozrywkaCount = 0;
            int ubranieCount = 0;
            int domoweZwierzakicount = 0;
            int multimediaCount = 0;
            int środkihigieniczneCount = 0;
            int kosmetykucount = 0;
            int nieprzewiduzaneWydatkiCount = 0;
            int kredytycount = 0;
            int wakacjeCount = 0;
            int paliwoCount = 0;
            int oszczednosciCount = 0;
            int inneCount = 0;

            
                switch (kategoria)
                {
                    case 0:
                        żywnośćCount += 1;
                        break;
                    case 1:
                        prądCount += 1;
                        break;
                    case 2:
                        wodaCount += 1;
                        break;
                    case 3:
                        sportCount += 1;
                        break;
                    case 4:
                        rozrywkaCount += 1;
                        break;
                    case 5:
                        ubranieCount += 1;
                        break;
                    case 6:
                        domoweZwierzakicount += 1;
                        break;
                    case 7:
                        multimediaCount += 1;
                        break;
                    case 8:
                        środkihigieniczneCount += 1;
                        break;
                    case 9:
                        kosmetykucount += 1;
                        break;
                    case 10:
                        nieprzewiduzaneWydatkiCount += 1;
                        break;
                    case 11:
                        kredytycount += 1;
                        break;
                    case 12:
                        wakacjeCount += 1;
                        break;
                    case 13:
                        paliwoCount += 1;
                        break;
                    case 14:
                        oszczednosciCount += 1;
                        break;
                    case 15:
                        inneCount += 1;
                        break;
                }
            
           
            //DaneM dane = new DaneM();

            dane.zywnośćProcenty = (żywnośćCount / 16.0) * 100;
           dane.prądProcenty = (prądCount / 16.0) * 100;
            dane.wodaProcenty = (wodaCount / 16.0) * 100;
            dane.sportProcenty = (sportCount / 16.0) * 100;

            dane.rozrywkaProcenty = (rozrywkaCount / 16.0) * 100;
            dane.ubranieProcenty = (ubranieCount / 16.0) * 100;
            dane.domoweZwProcenty = (domoweZwierzakicount / 16.0) * 100;
            dane.multimediaProcenty = (multimediaCount / 16.0) * 100;

            dane.środkihigProcenty = (środkihigieniczneCount / 16.0) * 100;
            dane.kosmetykiProcenty = (kosmetykucount / 16.0) * 100;
            dane.nieprzewidizaneProcenty = (nieprzewiduzaneWydatkiCount / 16.0) * 100;
            dane.kredytyProcenty = (kredytycount / 16.0) * 100;

            dane.wakacjePocenty = (wakacjeCount / 16.0) * 100;
            dane.pliwoProcenty = (paliwoCount / 16.0) * 100;
            dane.oszczednościProcenty = (oszczednosciCount / 16.0) * 100;
            dane.inneProcenty = (inneCount / 16.0) * 100;

            
        }

        // usuń wydatek
        public bool UsuńWydatek(WydatekM wydatek)
        {
            return listaWydatków.Remove(wydatek);
        }

        public int liczbaWydatkw
        {
            get
            {
                return listaWydatków.Count;
            }
        }
        // indekser wydatku
        public WydatekM this[int index]
        {
            get
            {
                return listaWydatków[index];
            }
        }
        public IEnumerator<WydatekM> GetEnumerator()
        {
            return listaWydatków.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }
    }
}
