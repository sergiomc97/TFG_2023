using mainWin.Controladores;
using mainWin.Modelos;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using WpfApp1;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : NavigationWindow {
        public static Usuario UsuarioAutenticado { get; set; }
        public static Configuracion ConfiguracionUsuario { get; set; }

        private CitasWindow c;
        private ClinetesWindow cl;
        private ConfiguWindow conf;
        private EstadisticasWindow est;
        private InventarioWindow i;
        private OrdenesWindow ord;
        private Principal p;
        private ProveedoresWindow prov;
        private ServiciosWindow s;
        UserControlMenu userControlMenu;
        string connString;


        public Window1(string connString) {
            this.FontFamily = new FontFamily("Roboto");
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            userControlMenu = new UserControlMenu();
            userControlMenu.miEvento += MiEventoEventHandler;
            this.connString = connString;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {

            OrdenesController co = new OrdenesController();
            CitasController ci = new CitasController();

            c = new CitasWindow(ci.GetCitas(), userControlMenu);
            cl = new ClinetesWindow(userControlMenu);
            conf = new ConfiguWindow(UsuarioAutenticado, userControlMenu);
            est = new EstadisticasWindow(userControlMenu);
            i = new InventarioWindow(userControlMenu);
            ord = new OrdenesWindow(co.AñadirTarjetas(), userControlMenu);
            p = new Principal(userControlMenu, co, ci);
            prov = new ProveedoresWindow(userControlMenu);
            s = new ServiciosWindow(userControlMenu);

            this.Navigate(p);
            if (ConfiguracionUsuario != null) {
                DatabaseMonitor monitor = new DatabaseMonitor(ConfiguracionUsuario.RutaFs, connString);
                monitor.StartMonitoring();

            }
            else {
                MessageBox.Show("El usuario no posee configuracion");
            }
        }
        public void MiEventoEventHandler(Type tipoPagina) {


            if (tipoPagina == typeof(ClinetesWindow)) {
                Navigate(cl);

            }
            else if (tipoPagina == typeof(ConfiguWindow)) {
                Navigate(conf);

            }
            else if (tipoPagina == typeof(EstadisticasWindow)) {
                Navigate(est);

            }
            else if (tipoPagina == typeof(InventarioWindow)) {
                Navigate(i);

            }
            else if (tipoPagina == typeof(Principal)) {
                Navigate(p);

            }
            else if (tipoPagina == typeof(ProveedoresWindow)) {
                Navigate(prov);
            }
            else if (tipoPagina == typeof(ServiciosWindow)) {
                Navigate(s);
            }
            else if (tipoPagina == typeof(OrdenesWindow)) {
                Navigate(ord);
            }
            else if (tipoPagina == typeof(CitasWindow)) {
                Navigate(c);
            }

        }



        private void NavigationWindow_SizeChanged(object sender, SizeChangedEventArgs e) {
            double baseFontSize = e.NewSize.Width / 90; // Ajusta según tus necesidades
            Application.Current.Resources["BaseFontSize"] = baseFontSize;
            double dobleFontSize = e.NewSize.Width / 60; // Ajusta según tus necesidades
            Application.Current.Resources["DobleFontSize"] = dobleFontSize;
            double Bordersize = e.NewSize.Width / 30; // Ajusta según tus necesidades
            Application.Current.Resources["Bordersize"] = Bordersize;
            double dobledoblesize = e.NewSize.Width / 30; // Ajusta según tus necesidades
            Application.Current.Resources["DobleDobleFontSize"] = dobledoblesize;
            double midfontsize = e.NewSize.Width / 90; // Ajusta según tus necesidades
            Application.Current.Resources["MidFontSize"] = midfontsize;
        }

    }
}
