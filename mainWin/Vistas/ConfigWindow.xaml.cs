﻿using mainWin;
using mainWin.Controladores;
using mainWin.Modelos;
using mainWin.Vistas;
using MySql.Data.MySqlClient;
using System;
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
    public partial class ConfigWindow : Window {
        MySqlConnection conn;
        public string server { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string connString { get; set; }
        private static string logFilePath = "C:\\Users\\carra\\Documents\\logs\\appLog.txt";

        public ConfigWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;



        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {



        }


        private void LogException(Exception ex) {
            try {
                string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Error: {ex}\n";
                File.AppendAllText(logFilePath, message);
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }
        public void saveParametros() {
            server = string.IsNullOrEmpty(ServidorTextBox.Text) ? "localhost" : ServidorTextBox.Text;
            username = string.IsNullOrEmpty(UsuarioTextBox.Text) ? "root" : UsuarioTextBox.Text;
            pass = string.IsNullOrEmpty(PassTextBox.Text) ? "060989" : PassTextBox.Text;
            connString = $"server={server};" +
                   $" user id={username};" +
                   $" password={pass};" +
                   $" port=3306;" +
                   "database = app1;" +
                   "Allow Zero Datetime=True;CHARSET=latin1";

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            saveParametros();
            this.Close();
        }
        private void ClosePopup_Click(object sender, RoutedEventArgs e) {
            saveParametros();
            this.Close();
        }
        private void Cancelbutton_Click(object sender, RoutedEventArgs e) {
            saveParametros();
            this.Close();
        }
        private bool conectar() {
            saveParametros();
            try {

                conn = new MySqlConnection(connString);

                conn.Open();
                borderGen.IsEnabled = true;
                return true;

            }
            catch (Exception ex) {
                LogException(ex);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally {

                conn.Close();
            }

        }
        private void generarbbdd() {
            try {
                string script = LeerScriptDesdeArchivo(".\\GenerarBBDD.sql");
                connString = $"server=localhost;" +
                  $" user id=root;" +
                  $" password=060989;" +
                  $" port=3306;" +
                  "Allow Zero Datetime=True;CHARSET=latin1";
                conn = new MySqlConnection(connString);

                conn.Open();

                MySqlCommand command = new MySqlCommand(script, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("Script SQL ejecutado exitosamente.");
            }
            catch (Exception ex) {
                MessageBox.Show($"Error al ejecutar el script SQL: {ex.Message}");
            }


        }
        public string LeerScriptDesdeArchivo(string fileName) {
            string script;
            using (StreamReader reader = new StreamReader(fileName)) {
                script = reader.ReadToEnd();
            }
            return script;
        }

        private void borderProb_Click(object sender, RoutedEventArgs e) {
            if (conectar()) {
                MessageBox.Show("La conexión a MySQL es exitosa.");

            }
            else {
                MessageBox.Show("No se pudo establecer la conexión a MySQL.");
            }
        }

        private void borderGen_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult resultado = MessageBox.Show("Los datos ya existentes van a eliminarse, ¿Estas segur@?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes) {

                MessageBoxResult resultado2 = MessageBox.Show("¿Seguro?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resultado2 == MessageBoxResult.Yes) {
                    generarbbdd();
                }
            }


        }

        private void borderInstall_Click(object sender, RoutedEventArgs e) {
            string help = "https://dev.mysql.com/downloads/installer/";
            try {
                Process.Start(help);

            }
            catch {

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {

                    help = help.Replace("&", "^&");

                    Process.Start(new ProcessStartInfo(help) { UseShellExecute = true });


                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {

                    Process.Start("xdg-open", help);


                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {

                    Process.Start("open", help);


                }
                else {
                    throw;
                }
            }
        }
    }
}
