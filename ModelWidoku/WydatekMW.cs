using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektZaliczeniowyMVVMNet.ModelWidoku
{
   public class WydatekMW : ObservedObject
    {
        // przechowywanie modelu dla tej klasy - > pojedyńczy wydatek 
        private Model.WydatekM model;

        // udostepnianie własności
        #region
        public string NaCoWydano
        {
            get
            {
                return model.NaCoWdano;
            }
        }
        public Model.KategoriaWydatku KategoriaWydatku
        {
            get
            {
                return model.KategoriaWydatku;
            }
        }
        public string IleWydano
        {
            get
            {
                return model.IleWydano;
            }
        }

        // własności doble do przechowywania procenta dla poszczególnych kategorii
        public double żywnośćProcent
        { 
            get 
            {
                return model.zywnośćProcenty;

            }
        } 
        public double prądProcent => model.policzKategorie.prądProcenty;
        public double wodaProcent => model.policzKategorie.wodaProcenty;
        public double sportProcent => model.policzKategorie.sportProcenty;
        public double rozrywkaProcent => model.policzKategorie.rozrywkaProcenty;
        public double ubranieProcent => model.policzKategorie.ubranieProcenty;
        public double domoweZwierzakiProcent => model.policzKategorie.domoweZwProcenty;
        public double multimediaProcent => model.policzKategorie.multimediaProcenty;
        public double środkihigieniczneProcent => model.policzKategorie.środkihigProcenty;
        public double kosmetykiProcent => model.policzKategorie.kosmetykiProcenty;
        public double nieprzewidzianeWydatkiProcent => model.policzKategorie.nieprzewidizaneProcenty;
        public double kredytyProcent => model.policzKategorie.kredytyProcenty;
        public double wakacjeProcent => model.policzKategorie.wakacjePocenty;
        public double paliwoProcent => model.policzKategorie.pliwoProcenty;
        public double oszczędnościProcent => model.policzKategorie.oszczednościProcenty;
        public double inneProcent => model.policzKategorie.inneProcenty;


        #endregion
        // konstruktor wykorzystywany w momencie wczytania danych z pliku i wówczas 
        // chcemy zaktualizować model widoku i będziemy podawać elementy z modelu
        // czyli te wydatki  poszczególne 
        public WydatekMW(Model.WydatekM model)
        {
            this.model = model;
        }

        // konstruktor wykorzystywanr w momencie tworzenia nowego wydatku
        public WydatekMW(string naCoWydano, string ileWydano, Model.KategoriaWydatku kategoriaWydatku)
        {
            model = new Model.WydatekM(naCoWydano, ileWydano, kategoriaWydatku);
        }

        // zwracanie wydatku z modelu
        public Model.WydatekM GetModel()
        {
            // zwraca cały model
            return model;
        }

        public override string ToString()
        {
            return model.ToString();
        }
    }
}
