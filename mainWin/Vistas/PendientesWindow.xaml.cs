using mainWin.Controladores;
using mainWin.Modelos;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Brushes = System.Windows.Media.Brushes;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para OrdenesWindow.xaml
    /// </summary>
    public partial class PendientesWindow : Page {
        public ObservableCollection<Pendiente> Tarjetas { get; set; } = new ObservableCollection<Pendiente>();
        public ObservableCollection<Pendiente> TarjetasOrd { get; set; }
        UserControlMenu uc;
        PendientesController pendientesController;


        public PendientesWindow(UserControlMenu uc, PendientesController pendientesController) {

            InitializeComponent();
            this.uc = uc;
            Loaded += MainWindow_Loaded;
            this.pendientesController = pendientesController;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {


            await LoadPendientesAsync();

        }


        public async Task LoadPendientesAsync() {

            var taskTarjetas = Task.Run(() => Tarjetas = pendientesController.AñadirTarjetas());

            await Task.WhenAll(taskTarjetas);

            Tarjetas = taskTarjetas.Result;


            DataContext = Tarjetas;

        }

        private void backBtn_Click(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }


        public void reinicializar() {


            TarjetasOrd = new ObservableCollection<Pendiente>(pendientesController.TarjetasOr);
            DataContext = TarjetasOrd;


        }

        private void busq_TextChanged(object sender, TextChangedEventArgs e) {

            string searchTerm = busq.Text;

            if (string.IsNullOrWhiteSpace(searchTerm)) {

                DataContext = Tarjetas;
            }
            else {
                pendientesController.BuscarPorTodosLosAtributos(searchTerm, Tarjetas);
                reinicializar();
            }
        }


        private void fch_Click(object sender, RoutedEventArgs e) {
            pendientesController.OrdenAscendente = !pendientesController.OrdenAscendente;

            pendientesController.ActualizarTarjetas(t => t.Fecha, Tarjetas);

            reinicializar();

        }

        private void nom_Click(object sender, RoutedEventArgs e) {
            pendientesController.OrdenAscendente = !pendientesController.OrdenAscendente;
            pendientesController.ActualizarTarjetas(t => t.Nombre, Tarjetas);

            reinicializar();
        }

        private void Ped_Click(object sender, RoutedEventArgs e) {
            pendientesController.OrdenAscendente = !pendientesController.OrdenAscendente;
            pendientesController.ActualizarTarjetas(t => t.Pedido, Tarjetas);
            reinicializar();
        }

        private void tlf_Click(object sender, RoutedEventArgs e) {
            pendientesController.OrdenAscendente = !pendientesController.OrdenAscendente;
            pendientesController.ActualizarTarjetas(t => t.Telefono, Tarjetas);

            reinicializar();
        }

        private void Ant_Click(object sender, RoutedEventArgs e) {
            pendientesController.OrdenAscendente = !pendientesController.OrdenAscendente;
            pendientesController.ActualizarTarjetas(t => t.Anticipo, Tarjetas);
            reinicializar();
        }

        private void pre_Click(object sender, RoutedEventArgs e) {
            pendientesController.OrdenAscendente = !pendientesController.OrdenAscendente;
            pendientesController.ActualizarTarjetas(t => t.Precio, Tarjetas);
            reinicializar();
        }



        private void BorderPend_click(object sender, MouseButtonEventArgs e) {
            if (sender is Border clickedBorder && clickedBorder.DataContext is Pendiente pendiente) {
                // Cambiar el estado del pendiente (suponiendo que "Completado" es una propiedad booleana)
                pendiente.Completado = !pendiente.Completado;

                pendientesController.actualizarestado(pendiente);
                BindingExpression bindingExpression = clickedBorder.GetBindingExpression(BackgroundProperty);
                bindingExpression.UpdateTarget();

            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            if (ValidarCampos()) {

                Pendiente nuevoPendiente = new Pendiente {
                    Nombre = NombreTextBox.Text,
                    Telefono = TelefonoTextBox.Text,
                    Anticipo = decimal.Parse(AnticipoTextBox.Text),
                    Precio = decimal.Parse(PrecioTextBox.Text),
                    Pedido = PedidoTextBox.Text,
                    Completado = false,
                    Fecha = DateTime.Now
                };

                pendientesController.NewPendiente(nuevoPendiente);


                cerrarPop();
                LoadPendientesAsync();
            }

        }
        private bool ValidarCampos() {
            // Validar que los TextBox no estén vacíos
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(TelefonoTextBox.Text) ||
                string.IsNullOrWhiteSpace(AnticipoTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrecioTextBox.Text) ||
                string.IsNullOrWhiteSpace(PedidoTextBox.Text)) {
                MessageBox.Show("Todos los campos deben ser completados.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Validar que los valores numéricos sean válidos (por ejemplo, Anticipo y Precio)
            if (!decimal.TryParse(AnticipoTextBox.Text, out _) || !decimal.TryParse(PrecioTextBox.Text, out _)) {
                MessageBox.Show("Anticipo y Precio deben ser valores numéricos válidos.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void BtnNuevo_Click(object sender, RoutedEventArgs e) {
            BlurEffect blurEffect = new BlurEffect {
                Radius = 10
            };

            // Aplicar el efecto de desenfoque al elemento deseado
            principal.Effect = blurEffect;
            MyPopup.IsOpen = true;

        }

        private void cerrarPop() {
            principal.Effect = null;
            MyPopup.IsOpen = false;
            NombreTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            AnticipoTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            PedidoTextBox.Text = string.Empty;


        }


        private void MyPopup_Closed(object sender, EventArgs e) {
            cerrarPop();
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e) {
            cerrarPop();
        }
        private void Cancelbutton_Click(object sender, RoutedEventArgs e) {
            cerrarPop();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

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

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e) {
            LoadPendientesAsync();
        }

        private void BtnNuevo_Click(object sender, MouseButtonEventArgs e) {

        }
    }
    public class BooleanToColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool isCompleted) {
                return isCompleted ? "#19b5d0" : "#fe6701";
            }

            return Brushes.Red; // Valor por defecto si no es booleano
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
       
    }
}