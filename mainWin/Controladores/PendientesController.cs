using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace mainWin.Controladores
{
    public class PendientesController : Utilidades<Pendiente> {
        private readonly bdContext _context;
        /// <summary>
        /// Inicializa una nueva instancia de PendientesController utilizando una instancia singleton de bdContext.
        /// </summary>
        public PendientesController() {
            _context = bdContextSingleton.Instance;
        }

        /// <summary>
        /// Añade las tarjetas de pendientes existentes en el contexto a una coleccion observable.
        /// </summary>
        /// <returns>Una ObservableCollection de objetos Pendiente.</returns>

        public ObservableCollection<Pendiente> AñadirTarjetas() {

            ObservableCollection<Pendiente> tarjetas = new ObservableCollection<Pendiente>();

            try {
                foreach (Pendiente item in _context.pendientes) {
                    tarjetas.Add(item);
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);

            }

            return tarjetas;
        }
        /// <summary>
        /// Actualiza asincronicamente un pendiente especifico en la base de datos.
        /// </summary>
        /// <param name="pendiente">El pendiente a actualizar.</param>
        /// <exception cref="DbUpdateConcurrencyException">Lanzada si hay un conflicto de concurrencia durante la actualizacion.</exception>

        public async Task ActualizarPendienteAsync(Pendiente pendiente) {
            try {
                var pendienteExistente = await _context.pendientes.FindAsync(pendiente.IdPendientes);

                if (pendienteExistente != null) {
                    pendienteExistente.Completado = pendiente.Completado;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException ex) {

               MessageBox.Show($"Error de concurrencia: {ex.Message}");

            }
        }

        public void OrdenarPorFechaAsc() {

        }

        public void actualizarestado(Pendiente p) {

            _context.SaveChanges();
        }

        public int ContarPendientesIncompletos() {
            return _context.pendientes.Count(p => (bool)!p.Completado);

        }
        /// <summary>
        /// Agrega un nuevo pendiente al contexto y lo guarda en la base de datos.
        /// </summary>
        /// <param name="p">El pendiente a agregar.</param>
        /// <exception cref="DbUpdateConcurrencyException">Lanzada si hay un conflicto de concurrencia durante la adicion.</exception>

        public void NewPendiente(Pendiente p) {
            try {
                _context.Attach(p);
                _context.Entry(p).State = EntityState.Added;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) {

                Console.WriteLine($"Error de concurrencia: {ex.Message}");

            }
        }
    }
}
