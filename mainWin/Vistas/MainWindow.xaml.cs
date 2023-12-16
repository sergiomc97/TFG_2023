using mainWin.Controladores;
using mainWin.Modelos;
using mainWin.Vistas;
using System.Collections.Generic;
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
        public string connString { get; set; }


        public MainWindow() {
            InitializeComponent();
            connString = $"server=localhost;" +
                  $" user id=root;" +
                  $" password=060989;" +
                  $" port=3306;" +
                  "database = app1;" +
                  "Allow Zero Datetime=True;CHARSET=latin1";
            Loaded += MainWindow_Loaded;
          
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            t = new bdContextSingleton(connString);
            _context = bdContextSingleton.Instance;
            usuariosController = new UsuariosController();
            empleadosController = new EmpleadosController();
            listaDeUsers = await usuariosController.LoadUsers();


        }

            private void btnInicioSesion_Click(object sender, RoutedEventArgs e) {


            string usernameText = textuserIni.Text;
            string passwordText = textpassIni.Password;

            if (usernameText != string.Empty && passwordText != string.Empty) {
                Usuario? user = listaDeUsers.SingleOrDefault(u => u.Nick == usernameText);
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

        private void registrar_Click(object sender, RoutedEventArgs e) {
            Usuario? user = usuariosController.getusers().SingleOrDefault(u => u.Nick == regUser.Text);

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
