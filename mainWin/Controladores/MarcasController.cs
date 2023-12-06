using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class MarcasController {
        private readonly bdContext _context;
        private bdContext context;

        public MarcasController() {
            _context = bdContextSingleton.Instance;
        }

        public MarcasController(bdContext context) {
            this.context = context;
        }
    }
}
