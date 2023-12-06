using System;
using System.Windows;
using System.Windows.Controls;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para UserControl.xaml
    /// </summary>
    public partial class UserControlMenu : UserControl {
        public delegate void MiEvento(Type tipoPagina);
        public event MiEvento? miEvento;

        public UserControlMenu() {

            InitializeComponent();
           

        }


        private void Button_Click_1(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(Principal));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(OrdenesWindow));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(InventarioWindow));
        }
        private void Button_Click_4(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(ClinetesWindow));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(ProveedoresWindow));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(ServiciosWindow));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(EstadisticasWindow));
        }

        private void Button_Click_8(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(CitasWindow));
        }
        private void Button_Click_9(object sender, RoutedEventArgs e) {

            miEvento?.Invoke(typeof(ConfiguWindow));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            if (Window1.UsuarioAutenticado.RolId == 2) {
                btn9.Visibility = Visibility.Visible;

            }
        }
    }

}
