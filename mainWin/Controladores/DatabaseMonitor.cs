using System;
using System.Threading;

using System.IO;
using System.Diagnostics;

namespace mainWin.Controladores {
    public class DatabaseMonitor {

        private string dbFilePath;
        private DateTime lastModified;
        private Thread monitoringThread;
        private FactusolController dataLoader;
        string conn;

        public DatabaseMonitor(string dbFilePath, string conn) {
            this.dbFilePath = dbFilePath;
            dataLoader = new FactusolController(dbFilePath, conn);
            lastModified = File.GetLastWriteTime(dbFilePath);
            this.conn = conn;
        }

        public void StartMonitoring() {
            monitoringThread = new Thread(MonitoringThreadMethod);
            monitoringThread.Start();
        }

        private void MonitoringThreadMethod() {
            while (true) {
                DateTime currentModified = File.GetLastWriteTime(dbFilePath);
                if (currentModified > lastModified) {
                    Debug.WriteLine("################### El archivo de la base de datos ha sido modificado. Actualizando los datos... ###################");
                    lastModified = currentModified;
                    try {
                        dataLoader.CargarDatosSiModificado();
                    }
                    catch (Exception ex) {
                        Debug.WriteLine("################### DbUpdateException ###################");

                        Debug.WriteLine("StackTrace: " + ex.StackTrace);

                    }

                    Debug.WriteLine("################### Datos actualizados. ###################");
                    Principal.DebugInfoModel.Msg = "Nuevos registros";
                    Principal.DebugInfoModel.cont += 1;
                }
                else {
                    Debug.WriteLine("################### No existen modificaciones. ###################");


                    Principal.DebugInfoModel.Msg = "Sin registros nuevos";


                }
                Thread.Sleep(10000);
            }
        }
    }
}
