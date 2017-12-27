using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfMvvmSample.converters
{
    public class BooleanToSolidColorBrushConverter : IValueConverter
    {
        /// <summary>
        /// Petit converter pour convertir un booléan nullable (à 3 états possibles) en une couleur (SolidColorBrush)
        /// Rose pour les filles, bleu pour les garçons et blanc quand pas renseigné...
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);

            if (value != null && value is bool?)
            {
                bool? boolean = value as bool?;
                if (boolean.HasValue && boolean.Value == true)
                {
                    brush = new SolidColorBrush(Colors.LightBlue);
                }
                else
                {
                    brush = new SolidColorBrush(Colors.LightPink);
                }
            }

            return brush;
        }

        /// <summary>
        /// Méthode inverse du converter pour convertir une couleur (SolidColorBrush) en booléen nullable (à 3 états)
        /// Inutile dans notre exemple donc pas implémentée
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("Méthode non implémentée !");
        }
    }
}
