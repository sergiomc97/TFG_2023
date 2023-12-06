using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace mainWin.Controladores {
    public class OrdenesController {

        private readonly bdContext _context;

        public OrdenesController() {
            _context = bdContextSingleton.Instance;
        }


        public int ContarOrdenesPorEstado(int estadoId) {

            return _context.Ordenes.Count(o => o.EstadoId == estadoId);

        }
        public ObservableCollection<Ordene> ObtenerOrdenesPorEstado(int estadoId) {
            ObservableCollection<Ordene> ordenesPorEstado = 
                new ObservableCollection<Ordene>(_context.Ordenes.Where(o => o.EstadoId == estadoId).ToList());
            return ordenesPorEstado;
        }


        public ObservableCollection<Ordene> AñadirTarjetas() {
            List<Ordene> listaDeOrdenes = _context.Ordenes.ToList();
            ObservableCollection<Ordene> OrdenesFiltradas = new ObservableCollection<Ordene>(listaDeOrdenes.OrderByDescending(o => o.Fecha).Take(150).ToList());
            return OrdenesFiltradas;
        }
        public ObservableCollection<Ordene> GetOrdenes() {
            ObservableCollection<Ordene> listaDeOrdenes = new ObservableCollection<Ordene>(_context.Ordenes.ToList<Ordene>());
            return listaDeOrdenes;
        }


        public List<Ordene> getOrdenesFechaComp() {

            DateTime now = DateTime.Now.Date;
            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
            int diff = (5 + (now.DayOfWeek - firstDayOfWeek)) % 5;
            DateTime startOfWeek = now.AddDays(-1 * diff);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Realiza la consulta LINQ
            var ordenesSemanaActual = _context.Ordenes
                .Where(o => o.FechaComp >= startOfWeek && o.FechaComp <= endOfWeek)
                .ToList();
            return ordenesSemanaActual;

        }

        public bool NewOrden(Ordene entidad) {
            try {
                // Marcar la entidad como modificada para que Entity Framework Core realice un seguimiento de los cambios
                _context.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                // Guardar cambios en la base de datos
                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException ex) {
                // Manejar la excepción de concurrencia optimista
                var entry = ex.Entries.Single();
                var clientValues = (Ordene)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();

                if (databaseEntry == null) {
                    // La entidad ha sido eliminada en la base de datos
                    // Puedes manejar esto de acuerdo a tus requerimientos
                    return false;
                }
                else {
                    // La entidad ha sido modificada en la base de datos
                    // Actualiza la entidad local con los valores de la base de datos
                    var databaseValues = (Ordene)databaseEntry.ToObject();
                    entry.OriginalValues.SetValues(databaseValues);
                    return false;

                    // Puedes lanzar una excepción personalizada aquí si lo deseas
                    // o realizar alguna otra acción apropiada
                }
            }



        }


        public bool UpdateOrden(Ordene entidad) {
            try {
                // Marcar la entidad como modificada para que Entity Framework Core realice un seguimiento de los cambios
                _context.Entry(entidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                // Guardar cambios en la base de datos
                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException ex) {
                // Manejar la excepción de concurrencia optimista
                var entry = ex.Entries.Single();
                var clientValues = (Ordene)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();

                if (databaseEntry == null) {
                    // La entidad ha sido eliminada en la base de datos
                    // Puedes manejar esto de acuerdo a tus requerimientos
                    return false;
                }
                else {
                    // La entidad ha sido modificada en la base de datos
                    // Actualiza la entidad local con los valores de la base de datos
                    var databaseValues = (Ordene)databaseEntry.ToObject();
                    entry.OriginalValues.SetValues(databaseValues);
                    return false;

                    // Puedes lanzar una excepción personalizada aquí si lo deseas
                    // o realizar alguna otra acción apropiada
                }
            }



        }

    }
}
