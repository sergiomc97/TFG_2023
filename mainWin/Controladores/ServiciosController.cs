using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class ServiciosController {
        private readonly bdContext _context;

        public ServiciosController() {
            _context = bdContextSingleton.Instance;
        }

        public List<Servicio> GetServicios() { 
        
            return _context.servicios.ToList();
        }

    }
}
