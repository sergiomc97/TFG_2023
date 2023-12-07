using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
            var ordenesSemanaActual = _context.Ordenes
                .Where(o => o.FechaComp >= startOfWeek && o.FechaComp <= endOfWeek)
                .ToList();
            return ordenesSemanaActual;

        }

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
                    // La entidad ha sido modificada en la base de datos
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
                    // La entidad ha sido modificada en la base de datos
                    var databaseValues = (Ordene)databaseEntry.ToObject();
                    entry.OriginalValues.SetValues(databaseValues);
                    return false;
                }
            }



        }

    }
}
