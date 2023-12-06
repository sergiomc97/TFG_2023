using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace mainWin.Controladores
{
    public class PendientesController: Utilidades<Pendiente>  {
        private readonly bdContext _context;
        private bdContext context;

        public PendientesController() {
            _context = bdContextSingleton.Instance;
        }

        public PendientesController(bdContext context) {
            this.context = context;
        }

        public ObservableCollection<Pendiente> AñadirTarjetas() {

            ObservableCollection<Pendiente> tarjetas = new ObservableCollection<Pendiente>();

            try {
                foreach (Pendiente item in _context.Pendientes) {
                    tarjetas.Add(item);
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);

            }

            return tarjetas;
        }
        public async Task ActualizarPendienteAsync(Pendiente pendiente) {
            try {
                var pendienteExistente = await _context.Pendientes.FindAsync(pendiente.IdPendientes);

                if (pendienteExistente != null) {
                    pendienteExistente.Completado = pendiente.Completado;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex) {
                // Manejo de excepciones si es necesario
                MessageBox.Show(ex.Message);
            }
        }

        public void OrdenarPorFechaAsc() {

        }

        public void actualizarestado(Pendiente p) {
            
            _context.SaveChanges();
        }

        public int ContarPendientesIncompletos() {
            return _context.Pendientes.Count(p => (bool)!p.Completado);
            
        }
        public void NewPendiente(Pendiente p) {

            _context.Attach(p);
            _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();


        }
    }
}
