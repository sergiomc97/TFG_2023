using mainWin.Controladores;
using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Effects;
using WpfApp1;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para OrdenesWindow.xaml
    /// </summary>
    public partial class CitasWindow : Page {

        ObservableCollection<Cita> citas;
        UserControlCitas uc;
        UserControlMenu uz;

        public CitasWindow(ObservableCollection<Cita> citas, UserControlMenu uz) {


            InitializeComponent();

            Loaded += MainWindow_Loaded;
            this.citas = citas;
            this.uz=uz;
            
        }


        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {

            uc = new UserControlCitas(citas);
            contenedor.Children.Add(uc);

        }



        private void busq_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e) {
            BlurEffect blurEffect = new BlurEffect {
                Radius = 10
            };


        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {

        }

        private void backBtn_Click(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }

        private void BtnNuevo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            CitasController controller = new CitasController();
            NewCitaWindow n = new NewCitaWindow(controller);
            n.ShowDialog();
            uc = new UserControlCitas(new ObservableCollection<Cita>(controller.GetCitas()));
            contenedor.Children.Add(uc);
        }
        private async void Grid_Loaded(object sender, RoutedEventArgs e) {
            if (uz.Parent != null) {
                ((Grid)uz.Parent).Children.Remove(uz);
                control.Children.Add(uz);
            }
            else {
                control.Children.Add(uz);
            }
        }
    }

}
