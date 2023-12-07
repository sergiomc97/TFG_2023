using mainWin.Controladores;
using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para OrdenesWindow.xaml
    /// </summary>
    public partial class DetallesWindow : Page {

        public Ordene or;
        private Boolean esnuevo;
        private OrdenesController ordenesController = new OrdenesController();
        public List<Empleado> ListaDeEmpleados { get; set; }
        private EmpleadosController emp = new EmpleadosController();
        public string estado;
        UserControlMenu uc;


        public DetallesWindow(Ordene o, UserControlMenu uc) {

            InitializeComponent();
            or = o;
            DataContext = or;
            esnuevo = false;
            ListaDeEmpleados = emp.getEmpleados();
            comboAsig.ItemsSource = ListaDeEmpleados;
            this.uc=uc;

        }
       
        public DetallesWindow(UserControlMenu uc) {
            InitializeComponent();
            esnuevo = true;
            ListaDeEmpleados = emp.getEmpleados();
            comboAsig.ItemsSource = ListaDeEmpleados;
            comboAsig.SelectedIndex = 0;
            this.uc = uc;
        }



        private void backBtn_Click(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e) {

        }

        private void OnBorderClick(object sender, MouseButtonEventArgs e) {

            borderPorPresupuestar.BorderBrush = new SolidColorBrush(Colors.Transparent);
            borderEnProceso.BorderBrush = new SolidColorBrush(Colors.Transparent);
            borderPorEntregar.BorderBrush = new SolidColorBrush(Colors.Transparent);

            Border clickedBorder = (Border)sender;
            clickedBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fb7e1f"));


            estado = clickedBorder.Name;

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

            int idEstado = 1;
            switch (estado) {
                case "borderPorPresupuestar":
                    idEstado = 1;
                    break;
                case "borderEnProceso":
                    idEstado = 2;
                    break;
                case "borderPorEntregar":
                    idEstado = 3;
                    break;
            }

            Empleado emp = (Empleado)comboAsig.SelectedItem;
            int idEmpleado = emp.IdEmpleado;

            string prioridad = comboprio.SelectedIndex.ToString();
            if (esnuevo && CamposValidos()) {
                int.TryParse(textId.Text, out int idOrden);
                Ordene orden = new Ordene {
                    IdOrden = idOrden,
                    Fecha = DateTime.Now,
                    FechaComp = DateTime.Now.AddDays(5),
                    EstadoId= idEstado,
                    AsignadoId = idEmpleado,
                    Modelo = textModelo.Text,
                    CliDni = textdni.Text,
                    CliDirec = textDirec.Text,
                    Averia = textAveria.Text,
                    Solucion = textSolucion.Text,
                    Telefono = textTelefono.Text,
                    Prioridad = "Alta",
                    ClienteId = 1,
                    ClienteStr = textCliente.Text,
                    ProductoId = 47134,
                    ServicioId = 1,
                    Observaciones = textobs.Text

                };

                ordenesController.NewOrden(orden);
            }
            else if(CamposValidos()) {
                or.EstadoId = idEstado;
                or.AsignadoId = idEmpleado;
                or.Prioridad = prioridad;
                ordenesController.UpdateOrden(or);
            }
            MessageBox.Show("Se han guardado los cambios");
            NavigationService.GoBack();

        }
        private bool CamposValidos() {
            // Verifica que todos los campos tengan contenido
            if (string.IsNullOrWhiteSpace(textModelo.Text) ||
                string.IsNullOrWhiteSpace(textdni.Text) ||
                string.IsNullOrWhiteSpace(textDirec.Text) ||
                string.IsNullOrWhiteSpace(textAveria.Text) ||
               string.IsNullOrWhiteSpace(textTelefono.Text) ||
                string.IsNullOrWhiteSpace(textCliente.Text)) {
                MessageBox.Show("Has dejado algun campo vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true; 
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
            if (esnuevo) {
                Ordene? ultimaOrden = ordenesController.AñadirTarjetas().OrderByDescending(o => o.IdOrden).FirstOrDefault();
                if (ultimaOrden != null) {
                    int nuevaIdOrden = ultimaOrden.IdOrden + 1;
                    textId.Text = nuevaIdOrden.ToString();
                }
                
               
                textfecha.Text = DateTime.UtcNow.ToString("dd/MM/yyyy");
            }
            else {

                if (or.EstadoId != null) {
                    int estado = (int)or.EstadoId;
                    SetBorder(estado);
                }
                
                comboAsig.SelectedItem = or.Asignado ?? ListaDeEmpleados.FirstOrDefault();
                comboprio.SelectedItem = or.Prioridad ?? comboprio.Items[0];

            }


        }

        private void SetBorder(int estado) {
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fb7e1f"));

            switch (estado) {
                case 1:
                    borderPorPresupuestar.BorderBrush = brush;
                    break;
                case 2:
                    borderEnProceso.BorderBrush = brush;
                    break;
                case 3:
                    borderPorEntregar.BorderBrush = brush;
                    break;
            }
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