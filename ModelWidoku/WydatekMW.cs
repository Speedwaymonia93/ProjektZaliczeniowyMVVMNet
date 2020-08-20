using ProjektZaliczeniowyMVVMNet.Model;
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
