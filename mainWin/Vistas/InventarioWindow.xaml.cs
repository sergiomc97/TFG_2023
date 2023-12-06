using mainWin.Controladores;
using System.Windows;
using System.Windows.Controls;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para InventarioWindow.xaml
    /// </summary>
    public partial class InventarioWindow : Page {

        public ProductosController pc;
        UserControlMenu uc;
        public InventarioWindow(UserControlMenu uc) {
            InitializeComponent();
            this.uc = uc;
            pc = new ProductosController();
            this.DataContext = pc.GetAll();

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
