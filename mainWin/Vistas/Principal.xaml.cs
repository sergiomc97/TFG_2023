using mainWin.Controladores;
using mainWin.Vistas;
using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using MySqlX.XDevAPI;
using System.IO;
using K4os.Compression.LZ4.Streams;
using System.Windows.Media.Animation;
using System.ComponentModel;
using WpfApp1;

namespace mainWin {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Principal : Page
    {
        public ObservableCollection<Pendiente> Tarjetas { get; set; } = new ObservableCollection<Pendiente>();
        public ObservableCollection<Pendiente> TarjetasOr { get; set; }
        public static DebugInfo DebugInfoModel { get; set; }
        CitasController c;
        Usuario user;
        OrdenesController? ordenesController;
        PendientesController? pendientesController;
        UserControlMenu uc;
        UserControlOrdenes uco;
        UserControlCitas ucCitas;


        public Principal(UserControlMenu uc, OrdenesController ordenesController, CitasController c) {
           
            InitializeComponent();
            this.uc = uc;
            Loaded += MainWindow_Loaded;
            user = Window1.UsuarioAutenticado;
            this.ordenesController = ordenesController;
            pendientesController = new PendientesController();
            DebugInfoModel = new DebugInfo();
            DebugInfoModel.PropertyChanged += DebugInfoModel_PropertyChanged;
            DataContext = this;
            this.c = c;
        }


        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {


            numEntregar.Text = ordenesController.ContarOrdenesPorEstado(3).ToString();
            numPresupu.Text = ordenesController.ContarOrdenesPorEstado(1).ToString();
            numProceso.Text = ordenesController.ContarOrdenesPorEstado(2).ToString();
            NumPend.Text = pendientesController.ContarPendientesIncompletos().ToString();
            uco = new UserControlOrdenes(new ObservableCollection<Ordene>(ordenesController.getOrdenesFechaComp()), uc);
            ucCitas = new UserControlCitas(new ObservableCollection<Cita>(c.GetCitas()));
            contenedor.Children.Add(uco);
            contenedorCitas.Children.Add(ucCitas);


            if (user != null) {
                username.Text = user.Nick;
            }
          

        }
        private void DebugInfoModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "cont") {
                MessageBox.Show("Se han añadido nuevos registros");
            }
        }



        //Metodos para efecto hover
        private void Button_MouseEnter(object sender, MouseEventArgs e) {
            ico0.Foreground = new BrushConverter().ConvertFrom("#ff6a00") as Brush;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e) {
            ico0.Foreground = new BrushConverter().ConvertFrom("#ff2f4f4f") as Brush;
        }

        private void Button_MouseEnter1(object sender, MouseEventArgs e) {
            ico1.Foreground = new BrushConverter().ConvertFrom("#ff6a00") as Brush;
        }

        private void Button_MouseLeave1(object sender, MouseEventArgs e) {
            ico1.Foreground = new BrushConverter().ConvertFrom("#ff2f4f4f") as Brush;
        }

        private void Button_MouseEnter2(object sender, MouseEventArgs e) {
            ico2.Foreground = new BrushConverter().ConvertFrom("#ff6a00") as Brush;
        }

        private void Button_MouseLeave2(object sender, MouseEventArgs e) {
            ico2.Foreground = new BrushConverter().ConvertFrom("#ff2f4f4f") as Brush;
        }



        private void Button_Click_1(object sender, RoutedEventArgs e) {
            PendientesWindow p = new PendientesWindow(uc, pendientesController);
            NavigationService.Navigate(p);


        }

        private void Button_Click(object sender, RoutedEventArgs e) {


        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            OrdenesWindow o= new OrdenesWindow(ordenesController.ObtenerOrdenesPorEstado(1),uc);
            NavigationService.Navigate(o);
        }

        private void enproceso_Click(object sender, RoutedEventArgs e) {
            OrdenesWindow o = new OrdenesWindow(ordenesController.ObtenerOrdenesPorEstado(2), uc);
            NavigationService.Navigate(o);

        }

        private void porentregar_Click(object sender, RoutedEventArgs e) {
            OrdenesWindow o = new OrdenesWindow(ordenesController.ObtenerOrdenesPorEstado(3), uc);
            NavigationService.Navigate(o);

        }
        private void menuList_MouseDoubleClick(object sender, MouseButtonEventArgs e) {


        }

        private void menuList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
           
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e) {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {

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

        private void ImageAwesome_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            MessageBoxResult resultado = MessageBox.Show("Se va a cerrar la sesión", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.None);

            if (resultado == MessageBoxResult.Yes) {
                MainWindow main = new MainWindow();
                main.Show();
                Window.GetWindow(this)?.Close();

            }
                
        }

        private void newCita_MouseEnter(object sender, MouseEventArgs e) {
            newCita.Foreground = new BrushConverter().ConvertFrom("#ff6a00") as Brush;
        }

        private void newCita_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            MessageBox.Show("añadiendo cita....");
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e) {
            newCita.Foreground = new BrushConverter().ConvertFrom("#ff2f4f4f") as Brush;
        }
    }
}
