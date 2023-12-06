using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public CitasController(bdContext context) {
            this.context = context;
        }

        public ObservableCollection<Cita> GetCitas() {
            ObservableCollection<Cita> listaDeOrdenes = new ObservableCollection<Cita>(_context.Citas.ToList<Cita>());
            return listaDeOrdenes;
        }
    }
}
