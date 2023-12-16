using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

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
        private void cambiarAtransparente() {

            borderHome.Foreground = Brushes.Gray;
            borderClientes.Foreground = Brushes.Gray;
            borderCitas.Foreground = Brushes.Gray;
            borderConfig.Foreground = Brushes.Gray;
            borderEst.Foreground = Brushes.Gray;
            borderInventario.Foreground = Brushes.Gray;
            borderOrdenes.Foreground = Brushes.Gray;
            borderprove.Foreground = Brushes.Gray;
            borderServ.Foreground = Brushes.Gray;

        }
        private void cambiarAcolor(FontAwesome.WPF.ImageAwesome b) {
            b.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff6a00"));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderHome);
            miEvento?.Invoke(typeof(Principal));
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderOrdenes);
            miEvento?.Invoke(typeof(OrdenesWindow));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderInventario);
            miEvento?.Invoke(typeof(InventarioWindow));
        }
        private void Button_Click_4(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderClientes);
            miEvento?.Invoke(typeof(ClinetesWindow));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderprove);
            miEvento?.Invoke(typeof(ProveedoresWindow));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderServ);
            miEvento?.Invoke(typeof(ServiciosWindow));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderEst);
            miEvento?.Invoke(typeof(EstadisticasWindow));
        }

        private void Button_Click_8(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderCitas);
            miEvento?.Invoke(typeof(CitasWindow));
        }
        private void Button_Click_9(object sender, RoutedEventArgs e) {
            cambiarAtransparente();
            cambiarAcolor(borderConfig);
            miEvento?.Invoke(typeof(ConfiguWindow));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            if (Window1.UsuarioAutenticado.Rol_id == 2) {
                btn9.Visibility = Visibility.Visible;

            }
        }
    }

}
