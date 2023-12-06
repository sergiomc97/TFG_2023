using mainWin.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para ServiciosWindow.xaml
    /// </summary>
    public partial class ServiciosWindow : Page {

        public ServiciosController ServiciosController;
        UserControlMenu uc;
        public ServiciosWindow(UserControlMenu uc) {
            this.uc = uc;
            InitializeComponent();
            ServiciosController = new ServiciosController();
            this.DataContext = ServiciosController.GetServicios();
        }
        private void backBtn_Click(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
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
