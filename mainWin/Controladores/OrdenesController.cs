using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace mainWin.Controladores {
    public class OrdenesController {

        private readonly bdContext _context;

        public OrdenesController() {
            _context = bdContextSingleton.Instance;
        }


        public int ContarOrdenesPorEstado(int estadoId) {

            return _context.ordenes.Count(o => o.Estado_id == estadoId);

        }
        public ObservableCollection<Ordene> ObtenerOrdenesPorEstado(int estadoId) {
            ObservableCollection<Ordene> ordenesPorEstado = 
                new ObservableCollection<Ordene>(_context.ordenes.Where(o => o.Estado_id == estadoId).ToList());
            return ordenesPorEstado;
        }


        public ObservableCollection<Ordene> AñadirTarjetas() {
            List<Ordene> listaDeOrdenes = _context.ordenes.ToList();
            ObservableCollection<Ordene> OrdenesFiltradas = new ObservableCollection<Ordene>(listaDeOrdenes.OrderByDescending(o => o.Fecha).Take(150).ToList());
            return OrdenesFiltradas;
        }
        public ObservableCollection<Ordene> GetOrdenes() {
            ObservableCollection<Ordene> listaDeOrdenes = new ObservableCollection<Ordene>(_context.ordenes.ToList<Ordene>());
            return listaDeOrdenes;
        }
        /// <summary>
        /// Obtiene una lista de ordenes cuya fecha de completado esta dentro de la semana actual.
        /// </summary>
        /// <returns>Una lista de objetos Ordenes que tienen fecha de completado en la semana actual.</returns>
        /// <remarks>
        /// La semana se considera empezando el lunes y terminando el domingo. Se utiliza la fecha actual para determinar la semana.
        /// </remarks>

        public List<Ordene> getOrdenesFechaComp() {

            DateTime now = DateTime.Now.Date;
            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
            int diff = (5 + (now.DayOfWeek - firstDayOfWeek)) % 5;
            DateTime startOfWeek = now.AddDays(-1 * diff);
            DateTime endOfWeek = startOfWeek.AddDays(6);
            var ordenesSemanaActual = _context.ordenes
                .Where(o => o.Fecha_comp >= startOfWeek && o.Fecha_comp <= endOfWeek)
                .ToList();
            return ordenesSemanaActual;

        }
        /// <summary>
        /// Agrega una nueva orden a la base de datos.
        /// </summary>
        /// <param name="entidad">El objeto Ordenes a agregar.</param>
        /// <returns>Verdadero si la orden se agrego con exito, falso si ocurrio un conflicto de concurrencia o un error.</returns>
        /// <exception cref="DbUpdateConcurrencyException">Lanzada si hay un conflicto de concurrencia durante la adicion de la orden.</exception>
        /// <remarks>
        /// Si ocurre un conflicto de concurrencia, se muestra un mensaje indicando si la orden ya no existe o ha sido modificada.
        /// </remarks>
        public bool NewOrden(Ordene entidad) {
            try {
                _context.Entry(entidad).State = EntityState.Added;
                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException ex) {

                var entry = ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();

                if (databaseEntry == null) {
                    MessageBox.Show("La orden no existe");
                    return false;
                }
                else {
                    var databaseValues = (Ordene)databaseEntry.ToObject();
                    entry.OriginalValues.SetValues(databaseValues);
                    return false;
                }
            }



        }


        public bool UpdateOrden(Ordene entidad) {
            try {

                _context.Entry(entidad).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException ex) {
                var entry = ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();

                if (databaseEntry == null) {
                    MessageBox.Show("La entidad ha sido eliminada en la base de datos");
                    return false;
                }
                else {
                    var databaseValues = (Ordene)databaseEntry.ToObject();
                    entry.OriginalValues.SetValues(databaseValues);
                    return false;
                }
            }



        }

    }
}
