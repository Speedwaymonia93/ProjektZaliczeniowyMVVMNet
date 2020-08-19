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

        // policzenie kategoruu
        public void policzKategorie(WydatekM wydatek)
        {//  Żywnośc, Prąd, Woda, Sport, Rozrywka, Ubranie, DomoweZwierzaki, Multimedia, ŚrodkiHigieniczne,
         //   Kosmetyki, NieprzewidzianeWydatki, Kredyty, Wakacje,Paliwo, Oszczędności, Inne
            var kategoria = (int)wydatek.KategoriaWydatku;
            int żywnośćiCount = 0;
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
            switch(kategoria)
            {
                case 0:
                    żywnośćiCount += 1;
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

            double zywnośćProcenty = (żywnośćiCount / 16) * 100;
            double prądProcenty = (prądCount / 16) * 100;
            double wodaProcenty = (wodaCount / 16) * 100;
            double sportProcenty = (sportCount / 16) * 100;

            double rozrywkaProcenty = (rozrywkaCount / 16) * 100;
            double ubranieProcenty = (ubranieCount / 16) * 100;
            double domoweZwProcenty = (domoweZwierzakicount / 16) * 100;
            double multimediaProcenty = (multimediaCount / 16) * 100;

            double środkihigProcenty = (środkihigieniczneCount / 16) * 100;
            double kosmetykiProcenty = (kosmetykucount / 16) * 100;
            double nieprzewidizaneProcenty = (nieprzewiduzaneWydatkiCount / 16) * 100;
            double kredytyProcenty = (kredytycount / 16) * 100;

            double wakacjePocenty = (wakacjeCount / 16) * 100;
            double pliwoProcenty = (paliwoCount / 16) * 100;
            double oszczednościProcenty = (oszczednosciCount / 16) * 100;
            double inneProcenty = (inneCount / 16) * 100;


            // lista wartośic procentowych która bezie wykorzystana do pzypisania poszeczególnych
            // elementów tej listy do wysokości słupka

            /*
        List<float?> listaProcentów = new List<float?>();
        var pogrupowaneKategorie =
        from kategoria in listaWydatków
        group kategoria by kategoria.KategoriaWydatku into kategoriaGropu
            select new
        {
            Kateoria = kategoriaGropu.Key,
            Count = kategoriaGropu.Count(),
        };
            var k = pogrupowaneKategorie.ToArray();
           //for(int i = 0; i < k.Length; i++)
           // {
           //     listaProcentów.Add(k[i]/16);
           // }
           */
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
