using mainWin.Controladores;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using mainWin.Modelos;
using System.Collections.ObjectModel;

namespace mainWin.Vistas {
    /// <summary>
    /// Lógica de interacción para UserControlOrdenes.xaml
    /// </summary>
    public partial class UserControlCitas: UserControl {

        public bdContext context = bdContextSingleton.Instance;
        public ObservableCollection<Cita> Tarjetas { get; set; } = new ObservableCollection<Cita>();

        public UserControlCitas(ObservableCollection<Cita> t) {
            InitializeComponent();
            Tarjetas = t;
            DataContext = Tarjetas;
            

        }


        private void OnDataGridDoubleClick(object sender, MouseButtonEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {

        }

        private void delete_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;

            if (button.DataContext is Cita cita) {
                    try {

                        Cita citaAEliminar = context.citas.Find(cita.IdCita);

                        if (citaAEliminar != null) {

                            context.citas.Remove(citaAEliminar);
                            context.SaveChanges();

                        Tarjetas.Remove(cita);
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
