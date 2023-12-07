using mainWin.Controladores;
using mainWin.Modelos;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp1;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para ServiciosWindow.xaml
    /// </summary>
    public partial class ConfiguWindow : Page {
        public Usuario UsuarioAutenticado { get; set; }
        string rutaConexion { get; set; }
        Configuracion config;
        bdContext _context;
        UserControlMenu uc;
        string connString;

        public ConfiguWindow(Usuario usuarioAutenticado, UserControlMenu uc, string connString) {
            InitializeComponent();
            _context = bdContextSingleton.Instance; ;
            this.uc = uc;
            UsuarioAutenticado = usuarioAutenticado;
            Loaded += MainWindow_Loaded;
            this.connString = connString;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            Configuracion? configuracionUsuario = UsuarioAutenticado?.Configuracions.FirstOrDefault();
            if (configuracionUsuario != null) {
                txtRutaArchivo.Text = configuracionUsuario.RutaFs;
            }
            LlenarComboBoxUsuarios();
            LlenarComboBoxEmpleados();

        }


        private void ClosePopup_Click(object sender, RoutedEventArgs e) {

        }
        private void Cancelbutton_Click(object sender, RoutedEventArgs e) {

        }
        private void SeleccionarArchivo_Click(object sender, RoutedEventArgs e) {
            // Crear el cuadro de diálogo para seleccionar archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            // Mostrar el cuadro de diálogo y obtener el resultado
            bool? resultado = openFileDialog.ShowDialog();

            // Procesar el resultado del cuadro de diálogo
            if (resultado == true) {
                // Obtener la ruta del archivo seleccionado
                rutaConexion = openFileDialog.FileName;

                // Mostrar la ruta en el TextBox
                txtRutaArchivo.Text = rutaConexion;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            Configuracion? existingConfig = _context.Configuracions.FirstOrDefault(c => c.UsuarioId == UsuarioAutenticado.Iduser);

            if (existingConfig == null) {
                config = new Configuracion {
                    RutaFs = rutaConexion,
                    UsuarioId = UsuarioAutenticado.Iduser
                };

                _context.Add(config);
            }
            else {
                existingConfig.RutaFs = rutaConexion;
                _context.Entry(existingConfig).State = EntityState.Modified;
            }

            _context.SaveChanges();
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
        private void LlenarComboBoxUsuarios() {

            List<Usuario> usuarios = _context.Usuarios.ToList();
            combo.ItemsSource = usuarios;
            combo.DisplayMemberPath = "Nick";
            combo.SelectedValuePath = "Iduser";
        }

        private void LlenarComboBoxEmpleados() {

            List<Empleado> empleados = _context.Empleados.ToList();
            combo2.ItemsSource = empleados;
            combo2.DisplayMemberPath = "Nombre";
            combo2.SelectedValuePath = "IdEmpleado";
        }
        private void asign_Click(object sender, RoutedEventArgs e) {
            var usuarioSeleccionado = combo.SelectedItem as Usuario;
            if (usuarioSeleccionado == null) {
                MessageBox.Show("Por favor, selecciona un usuario.");
                return;
            }

            var empleadoSeleccionado = combo2.SelectedItem as Empleado;
            if (empleadoSeleccionado == null) {
                MessageBox.Show("Por favor, selecciona un empleado.");
                return;
            }

            if (usuarioSeleccionado != null && empleadoSeleccionado != null) {
                usuarioSeleccionado.Empleado = empleadoSeleccionado;
                _context.SaveChanges();
            }

            MessageBox.Show("Asignación realizada correctamente.");

        }

        private void cargar_Click(object sender, RoutedEventArgs e) {
            FactusolController f = new FactusolController(txtRutaArchivo.Text, connString);
            f.CargarDatosSiModificado();
            MessageBox.Show("Se procede a cerrar la sesion para establecer los cambios");
            
            MainWindow main = new MainWindow();
            main.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}
