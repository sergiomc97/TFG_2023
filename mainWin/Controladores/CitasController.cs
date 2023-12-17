using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class CitasController {
        private readonly bdContext _context;
        private bdContext context;

        public CitasController() {
            _context = bdContextSingleton.Instance;
        }


        public ObservableCollection<Cita> GetCitas() {
            ObservableCollection<Cita> listaDeOrdenes = new ObservableCollection<Cita>(_context.citas.ToList<Cita>());
            return listaDeOrdenes;
        }
        public void NewCita(Cita p) {

            _context.Attach(p);
            _context.Entry(p).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Added;
            _context.SaveChanges();


        }
    }
}
