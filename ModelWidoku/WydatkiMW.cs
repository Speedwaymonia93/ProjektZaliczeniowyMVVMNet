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
    public class WydatkiMW
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
                     },
                     o =>
                     {
                         return (o as WydatekMW) != null;
                     });
                return dodajWydatek;
            }
        }


    }
}
