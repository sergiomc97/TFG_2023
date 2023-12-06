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

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para OrdenesWindow.xaml
    /// </summary>
    public partial class OrdenesWindow : Page {
        ObservableCollection<Ordene> ordenes;
        UserControlOrdenes uc;
        UserControlMenu uz;

        public OrdenesWindow(ObservableCollection<Ordene> ordenes, UserControlMenu uz) {


            InitializeComponent();
            this.uz = uz;
            Loaded += MainWindow_Loaded;
            this.ordenes = ordenes;
            
        }


        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {

            uc = new UserControlOrdenes(ordenes, uz);
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
            DetallesWindow d = new DetallesWindow(uz);
            NavigationService.Navigate(d);

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
