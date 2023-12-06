using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class RolesController {
        private readonly bdContext _context;

        public RolesController() {
            _context = bdContextSingleton.Instance;
        }

     
    }
}
