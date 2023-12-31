﻿using mainWin.Controladores;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using mainWin.Modelos;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para UserControlOrdenes.xaml
    /// </summary>
    public partial class UserControlOrdenes : UserControl {

        public bdContext context = bdContextSingleton.Instance;
        public ObservableCollection<Ordene> Tarjetas { get; set; } = new ObservableCollection<Ordene>();
        UserControlMenu uc;
        public UserControlOrdenes(ObservableCollection<Ordene> t, UserControlMenu uc) {
            InitializeComponent();
            Tarjetas = t;
            DataContext = Tarjetas;
            this.uc = uc;

        }


        private void OnDataGridDoubleClick(object sender, MouseButtonEventArgs e) {
            if (sender is DataGrid grid && grid.SelectedItem is Ordene ord) {

                NavigationService navigationService = NavigationService.GetNavigationService(this);

                navigationService?.Navigate(new DetallesWindow(ord ,uc));
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            Button button = (Button)sender;

            if (button.DataContext is Ordene orden) {


                string numeroTelefono = orden.Telefono;

                string urlWhatsApp = $"https://api.whatsapp.com/send?phone=34{numeroTelefono}";


                try {
                    Process.Start(urlWhatsApp);

                }
                catch {

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {

                        urlWhatsApp = urlWhatsApp.Replace("&", "^&");

                        Process.Start(new ProcessStartInfo(urlWhatsApp) { UseShellExecute = true });


                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {

                        Process.Start("xdg-open", urlWhatsApp);


                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {

                        Process.Start("open", urlWhatsApp);


                    }
                    else {
                        throw;
                    }
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;

            if (button.DataContext is Ordene orden) {
                    try {

                        Ordene ordenAEliminar = context.ordenes.Find(orden.IdOrden);

                        if (ordenAEliminar != null) {

                            context.ordenes.Remove(ordenAEliminar);
                            context.SaveChanges();

                        Tarjetas.Remove(orden);
                        MessageBox.Show("Orden eliminada con éxito");
                        }
                        else {
                            MessageBox.Show("No se encontró la orden");
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Error al intentar eliminar la orden: " + ex.Message);
                    }

            }
        }
    }
}
