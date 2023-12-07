using mainWin.Controladores;
using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
        OrdenesController co;
        CitasController ci;
        DatabaseMonitor monitor;

        public Window1(string connString) {
            this.FontFamily = new FontFamily("Roboto");
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            this.connString = connString;
            pruebaConc();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            userControlMenu = new UserControlMenu();
            userControlMenu.miEvento += MiEventoEventHandler;
            co = new OrdenesController();
            ci = new CitasController();

            p = new Principal(userControlMenu, co, ci);
            this.Navigate(p);


            if (ConfiguracionUsuario != null) {
                monitor = new DatabaseMonitor(ConfiguracionUsuario.RutaFs, connString);
                monitor.StartMonitoring();

            }
        }
        public void MiEventoEventHandler(Type tipoPagina) {

            c = new CitasWindow(ci.GetCitas(), userControlMenu);
            cl = new ClinetesWindow(userControlMenu);
            conf = new ConfiguWindow(UsuarioAutenticado, userControlMenu, connString);
            est = new EstadisticasWindow(userControlMenu);
            i = new InventarioWindow(userControlMenu);
            ord = new OrdenesWindow(co.AñadirTarjetas(), userControlMenu);
            prov = new ProveedoresWindow(userControlMenu);
            s = new ServiciosWindow(userControlMenu);

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
        public void pruebaConc() {

            //using (var contexto = new bdContext(connString)) {

            //    var producto = contexto.Ordenes.FirstOrDefault(p => p.IdOrden == 1);

            //    using (var otroContexto = new bdContext(connString)) {
            //        var otroProducto = otroContexto.Ordenes.FirstOrDefault(p => p.IdOrden == 1);
            //        otroProducto.Observaciones = "OtroNombre";
            //        otroContexto.SaveChanges();
            //    }


            //    producto.Observaciones = "NuevoNombre";

            //    try {

            //        contexto.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException ex) {
            //        Debug.WriteLine($"################# Excepción de concurrencia: {ex.Message} ##############################");

            //    }
            //}



        }

        private void NavigationWindow_Closed(object sender, EventArgs e) {
            monitor.detener();
        }
    }
}
