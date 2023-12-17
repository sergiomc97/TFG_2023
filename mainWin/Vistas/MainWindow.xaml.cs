using mainWin.Controladores;
using mainWin.Modelos;
using mainWin.Vistas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        bdContextSingleton t;
        bdContext _context;
        EmpleadosController empleadosController;
        UsuariosController usuariosController;
        List<Usuario> listaDeUsers;
        bool existeConexion = false;
        public string connString { get; set; }
        private static string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "logs");
        private static string logFilePath = Path.Combine(logDirectory, "appLog.txt");


        public MainWindow() {
            InitializeComponent();
            connString = $"Server=localhost; User ID=root; Password=060989; Database=app1";
            initCosas();


        }
        private void initCosas() {

            try {
                t = new bdContextSingleton(connString);
                _context = bdContextSingleton.Instance;

                if (_context.Database.CanConnect()) {
                    existeConexion = true;
                }

                usuariosController = new UsuariosController();
                empleadosController = new EmpleadosController();

            }
            catch (Exception ex) {
                LogException("Base de datos no encontrada, vaya a configuración.\nDetalle del error: " + ex.Message);
            }

        }
        private void LogException(string ex) {
            try {
                if (!Directory.Exists(logDirectory)) {
                    Directory.CreateDirectory(logDirectory);
                }

                string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Error: {ex}\n";
                File.AppendAllText(logFilePath, message);
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
        private async void cargarUsers() {


            listaDeUsers = usuariosController.getusers();

        }

        private void btnInicioSesion_Click(object sender, RoutedEventArgs e) {
            initCosas();
            if (existeConexion) {
                cargarUsers();
                string usernameText = textuserIni.Text;
                string passwordText = textpassIni.Password;

                if (usernameText != string.Empty && passwordText != string.Empty) {
                    Usuario? user = usuariosController.getusers().SingleOrDefault(u => u.Nick == usernameText);
                    if (user != null && usuariosController.VerifyPassword(user, passwordText, user.PasswordHash, user.Salt)) {

                        Configuracion? configuracionUsuario = _context.usuarios
                                        .Where(u => u.Iduser == user.Iduser)
                                        .Select(u => u.Configuracions.SingleOrDefault())
                                        .FirstOrDefault();


                        Window1 window1 = new Window1(connString);
                        Window1.UsuarioAutenticado = user;

                        if (configuracionUsuario != null) {


                            Window1.ConfiguracionUsuario = configuracionUsuario;
                            window1.Show();
                            this.Close();
                        }
                        else {
                            MessageBox.Show("Configuración no encontrada para el usuario. Establece un archivo valido y reinicia la aplicacion");
                            window1.Show();
                            this.Close();
                        }
                    }
                    else {
                        SolidColorBrush redTransparentBrush = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));
                        textuserIni.Background = redTransparentBrush;
                        textpassIni.Background = redTransparentBrush;
                        textuserIni.Text = "Introduce usuario y contraseña";
                    }
                }
            }
            else {

                MessageBox.Show("No se ha podido conectar con la base de datos, puedes generarla en la configuracion");
            }

        }

        private void registrar_Click(object sender, RoutedEventArgs e) {
            initCosas();
            if (existeConexion) {
                cargarUsers();
                Usuario? user = _context.usuarios.SingleOrDefault(u => u.Nick == regUser.Text);

                if (user == null) {

                    Empleado? emp = empleadosController.getEmpleados().SingleOrDefault(u => u.Email == regmail.Text);

                    if (emp != null) {

                        usuariosController.RegisterUser(regUser.Text, regPass.Password, regmail.Text, emp);
                        _ = new MainWindow();

                    }
                    else {
                        usuariosController.RegisterUserBasic(regUser.Text, regPass.Password, regmail.Text);
                        _ = new MainWindow();
                    }

                }
            }
            else {

                MessageBox.Show("No se ha podido conectar con la base de datos, puedes generarla en la configuracion");
            }


        }



        private void iniciarsesion_Click(object sender, RoutedEventArgs e) {

            inciosesion.Visibility = Visibility.Collapsed;
            registro.Visibility = Visibility.Visible;

            gridCentroRegistro.Visibility = Visibility.Collapsed;
            gridCentroInicio.Visibility = Visibility.Visible;

        }

        private void registrarse_Click(object sender, RoutedEventArgs e) {

            inciosesion.Visibility = Visibility.Visible;

            registro.Visibility = Visibility.Collapsed;

            gridCentroRegistro.Visibility = Visibility.Visible;
            gridCentroInicio.Visibility = Visibility.Collapsed;


        }



        private void textuserIni_GotFocus(object sender, RoutedEventArgs e) {
            textuserIni.Text = string.Empty;
        }


        private void regUser_GotFocus(object sender, RoutedEventArgs e) {
            regUser.Text = string.Empty;
        }

        private void regnom_GotFocus(object sender, RoutedEventArgs e) {
            regnom.Text = string.Empty;
        }

        private void regmail_GotFocus(object sender, RoutedEventArgs e) {
            regmail.Text = string.Empty;
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e) {

        }

        private void StackPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            ConfigWindow c = new ConfigWindow();
            c.ShowDialog();
            connString = c.connString;
        }
    }
}
