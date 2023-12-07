using mainWin.Controladores;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para ProveedoresWindow.xaml
    /// </summary>
    public partial class ProveedoresWindow : Page {
        ProveedoresController proveedoresController;
        UserControlMenu uc;
        public ProveedoresWindow(UserControlMenu uc) {
            InitializeComponent();
            this.uc = uc;
            proveedoresController = new ProveedoresController();
            this.DataContext = proveedoresController.getProve();

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
