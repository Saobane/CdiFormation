using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfMvvmSample.converters
{
    /// <summary>
    /// Petit converter pour convertir un booléan nullable (à 3 états possibles) en une chaine "Homme" ou "Femme"
    /// </summary>
    public class BooleanToSexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string sexe = null;
            
            if (value != null && value is bool?)
            {
                bool? boolean = value as bool?;
                if (boolean.HasValue && boolean.Value == true)
                {
                    sexe = "Homme";
                }
                else
                {
                    sexe = "Femme";
                }
            }

            return sexe;
        }

        /// <summary>
        /// Méthode inverse du converter pour convertir une chaine "Homme" ou "Femme" en booléen nullable (à 3 états)
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
