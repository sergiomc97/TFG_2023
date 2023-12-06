using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace mainWin.Controladores {
    public class Utilidades<T>
    {

        public ObservableCollection<T> TarjetasOr { get; set; } = new ObservableCollection<T>();
        public bool OrdenAscendente { get; set; }



        // Método genérico para ordenar las tarjetas por una propiedad
        public void ActualizarTarjetas(Func<T, IComparable> att, ObservableCollection<T> tarjetas)
        {
            IEnumerable<T> orderedTarjetas = OrdenarTarjetas(att, tarjetas);

            if (orderedTarjetas != null)
            {
                ActualizarTarjetasCollection(orderedTarjetas);
            }
        }

        public IEnumerable<T>? OrdenarTarjetas(Func<T, IComparable> att, ObservableCollection<T> tarjetas)
        {
            if (tarjetas != null)
            {
                return OrdenAscendente ? tarjetas.OrderBy(att) : tarjetas.OrderByDescending(att);
            }
            return null;
        }

        public void ActualizarTarjetasCollection(IEnumerable<T> tarjetas)
        {
            TarjetasOr.Clear();
            foreach (var ta in tarjetas)
            {
                TarjetasOr.Add(ta);
            }

        }

        public void BuscarPorTodosLosAtributos(string searchTerm, ObservableCollection<T> tarjetas)
        {
            IEnumerable<T> matchingTarjetas = BuscarTarjetasPorAtributos(searchTerm, tarjetas);

            if (matchingTarjetas != null)
            {
                ActualizarTarjetasCollection(matchingTarjetas);
            }
        }

        public static IEnumerable<T>? BuscarTarjetasPorAtributos(string searchTerm, ObservableCollection<T> tarjetas)
        {
            if (tarjetas != null && !string.IsNullOrWhiteSpace(searchTerm))
            {
                return tarjetas.Where(ta =>
                    ta.GetType().GetProperties().Any(prop =>
                        prop.GetValue(ta)?.ToString()?.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            return null;
        }
    }


    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                // Si el valor booleano es verdadero, se muestra el elemento (Visible).
                // Si el valor booleano es falso, se oculta el elemento (Collapsed).
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            // Por defecto, se oculta el elemento si el valor no es booleano o es nulo.
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Esta conversión no es necesaria para la conversión de visibilidad a booleano.
            throw new NotImplementedException();
        }
    }
}
