using ProjektZaliczeniowyMVVMNet.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjektZaliczeniowyMVVMNet
{
    /*
    public class KategroriaToHeightConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {// Żywnośc, Prąd, Woda, Sport, Rozrywka, Ubranie, DomoweZwierzaki, Multimedia, ŚrodkiHigieniczne,
         //   Kosmetyki, NieprzewidzianeWydatki, Kredyty, Wakacje,Paliwo, Oszczędności, Inne
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
  }
    */
    public class Wydatekconverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string nacoWydano = (string)values[0];
            string ileWydano = (string)values[1];
            Model.KategoriaWydatku kategoria = (Model.KategoriaWydatku)(int)values[2];
            if (!string.IsNullOrWhiteSpace(nacoWydano) && !string.IsNullOrWhiteSpace(ileWydano))
                return new ModelWidoku.WydatekMW(nacoWydano, ileWydano, kategoria);
            else return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
