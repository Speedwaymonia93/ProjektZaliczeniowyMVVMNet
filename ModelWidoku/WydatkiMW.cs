using ProjektZaliczeniowyMVVMNet.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

// klasa reprezentujaca całą kolekcje wydatków
namespace ProjektZaliczeniowyMVVMNet.ModelWidoku
{
    using static Model.PlikXml;
    public class WydatkiMW : ObservedObject
    {
        // przechowanie prywatnej instancji modelu
        private Model.WydatkiM model;

        // przechowywanie kolekcji wydatków
        public ObservableCollection<WydatekMW> ListaWydatków { get; } = new ObservableCollection<WydatekMW>();

        // kopiowanie wtdatkó z modelu
        private void kopiujWydatkiZModelu()
        {
            ListaWydatków.CollectionChanged -= synchronizacjaModelu;
            ListaWydatków.Clear();
            foreach (Model.WydatekM wydatek in model)
            {
                // dodajemy wydatek
                ListaWydatków.Add(new WydatekMW(wydatek));
               
            }
            ListaWydatków.CollectionChanged += synchronizacjaModelu;
        }

        // zdefiniowanie pliku do zapisu danych
        private string ścieżkadoPliku = "wydatki.xml";
        // kontruktor domyślny
        public WydatkiMW()
        {
            if (System.IO.File.Exists(ścieżkadoPliku)) model = Czytaj(ścieżkadoPliku);
            else model = new Model.WydatkiM();
            kopiujWydatkiZModelu();
        }

        // synchronizacja widoku do modelu
        public void synchronizacjaModelu(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                // dodawanie wydatku
                case NotifyCollectionChangedAction.Add:
                    WydatekMW nowyWydatek = (WydatekMW)e.NewItems[0];
                    if (nowyWydatek != null) model.DodajWydatek(nowyWydatek.GetModel());
                    break;

                // usuwanie wydatku
                case NotifyCollectionChangedAction.Remove:
                    WydatekMW usuwanyWydatek = (WydatekMW)e.OldItems[0];
                    if (usuwanyWydatek != null) model.UsuńWydatek(usuwanyWydatek.GetModel());
                    break;


              }
        }

        // zapisywanie 
        public ICommand Zapisz
        {
            get
            {
                return new RelayCommand(
                    argument =>
                    {
                        Model.PlikXml.Zapisz(model, ścieżkadoPliku);
                    });
            }
        }

        // usuwanie wydatku
        private ICommand usuńWydatek;
        public ICommand UsuńWydatek
        {
            get
            {
                if (usuńWydatek == null) usuńWydatek = new RelayCommand(
                      o =>
                      {
                          int indeksWydatku = (int)o;
                          WydatekMW wydatek = ListaWydatków[indeksWydatku];
                          ListaWydatków.Remove(wydatek);
                      },
                      o =>
                      {
                          if (o == null) return false;
                          int indeksWydatku = (int)o;
                          return indeksWydatku >= 0;
                      });
                return usuńWydatek;
            }
        }

        // dodawanie wydatku
        private ICommand dodajWydatek;
        public ICommand DodajWydatek
        {
            get
            {
                if (dodajWydatek == null) dodajWydatek = new RelayCommand(
                     o =>
                     {
                         WydatekMW wydatek = o as WydatekMW;
                         if (wydatek != null) ListaWydatków.Add(wydatek);
                         // po przecinku wszystkie własności
                         onPropertyChanged(nameof(żywnośćProcent));
                     },
                     o =>
                     {
                         return (o as WydatekMW) != null;
                     });
                return dodajWydatek;
            }
        }

        public double żywnośćProcent
        {
            get
            {
                return model.dane.zywnośćProcenty;

            }
        }
        public double prądProcent => model.dane.prądProcenty;
        public double wodaProcent => model.dane.wodaProcenty;
        public double sportProcent => model.dane.sportProcenty;
        public double rozrywkaProcent => model.dane.rozrywkaProcenty;
        public double ubranieProcent => model.dane.ubranieProcenty;
        public double domoweZwierzakiProcent => model.dane.domoweZwProcenty;
        public double multimediaProcent => model.dane.multimediaProcenty;
        public double środkihigieniczneProcent => model.dane.środkihigProcenty;
        public double kosmetykiProcent => model.dane.kosmetykiProcenty;
        public double nieprzewidzianeWydatkiProcent => model.dane.nieprzewidizaneProcenty;
        public double kredytyProcent =>  model.dane.kredytyProcenty;
        public double wakacjeProcent => model.dane.wakacjePocenty;
        public double paliwoProcent => model.dane.pliwoProcenty;
        public double oszczędnościProcent => model.dane.oszczednościProcenty;
        public double inneProcent => model.dane.inneProcenty;

    }
}
