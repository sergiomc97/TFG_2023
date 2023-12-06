using mainWin.Controladores;
using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para ServiciosWindow.xaml
    /// </summary>
    public partial class ConfiguWindow : Page {
        public Usuario UsuarioAutenticado { get; set; }
        string rutaConexion { get; set; }
        bdContext _context;
        UserControlMenu uc;

        public ConfiguWindow(Usuario usuarioAutenticado, UserControlMenu uc) {
            InitializeComponent();
            _context = bdContextSingleton.Instance; ;
            this.uc = uc;
            UsuarioAutenticado = usuarioAutenticado;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            Configuracion? configuracionUsuario = UsuarioAutenticado?.Configuracions.FirstOrDefault();
            if (configuracionUsuario != null) {
                txtRutaArchivo.Text = configuracionUsuario.RutaFs;
            }
            
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
                Configuracion config = new Configuracion {
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
    }
}
