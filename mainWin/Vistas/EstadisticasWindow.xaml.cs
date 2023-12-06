using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para EstadisticasWindow.xaml
    /// </summary>
    public partial class EstadisticasWindow : Page {
        List<MenuItem> m;
        UserControlMenu uc;
        public EstadisticasWindow(UserControlMenu uc) {
            this.uc = uc;
            InitializeComponent();

        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e) {
            if (uc.Parent != null) {
                ((Grid)uc.Parent).Children.Remove(uc);
                control.Children.Add(uc);
            }
            else {
                control.Children.Add(uc);
            }
        }


    }
}
