using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class EstadosController {
        private readonly bdContext _context;

        public EstadosController() {
            _context = bdContextSingleton.Instance;
        }

    }
}
