using mainWin;
using mainWin.Controladores;
using mainWin.Modelos;
using mainWin.Vistas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewCitaWindow : Window {

        public CitasController CitasController;
        public NewCitaWindow(CitasController c) {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            CitasController = c;
            LlenarComboBox();

        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {



        }

        private Cita? CrearCitaSiEsValida() {
            // Validar Fecha
            if (!fechaTextBox.SelectedDate.HasValue) {
                MessageBox.Show("Por favor, selecciona una fecha.");
                return null;
            }
            var fecha = DateOnly.FromDateTime(fechaTextBox.SelectedDate.Value);

            // Validar Hora
            if (!TimeOnly.TryParse(HoraTextBox.Text, out TimeOnly hora)) {
                MessageBox.Show("Por favor, introduce una hora válida.");
                return null;
            }

            // Validar Cliente
            if (comboCli.SelectedItem == null) {
                MessageBox.Show("Por favor, selecciona un cliente.");
                return null;
            }
            // Suponiendo que el ComboBox contiene objetos Cliente y quieres el Id del cliente seleccionado
            var cliente = comboCli.SelectedItem as Cliente;

            // Validar Descripción
            if (string.IsNullOrWhiteSpace(descTextBox.Text)) {
                MessageBox.Show("Por favor, introduce una descripción.");
                return null;
            }
            var descripcion = descTextBox.Text;

            // Crear y retornar el objeto Cita
            return new Cita {
                Fecha = fecha,
                Hora = hora,
                Cliente = cliente,
                Desc = descripcion
            };
        }

        private void LlenarComboBox() {
            var cli = new ClientesController();
            List<Cliente> clientes = cli.GetClientes().ToList();
            comboCli.ItemsSource = clientes;
            comboCli.DisplayMemberPath = "Nombre";
            comboCli.SelectedValuePath = "IdCliente";

        }


        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            CitasController.NewPendiente(CrearCitaSiEsValida());
            this.Close();
        }
        private void ClosePopup_Click(object sender, RoutedEventArgs e) {

            this.Close();
        }
        private void Cancelbutton_Click(object sender, RoutedEventArgs e) {

            this.Close();
        }





    }
}
