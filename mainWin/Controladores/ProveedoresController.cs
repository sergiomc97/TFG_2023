using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class ProveedoresController {
        private readonly bdContext _context;


        public ProveedoresController() {
            _context = bdContextSingleton.Instance;
        }

        public List<Proveedore> getProve() { 
        
            return _context.proveedores.ToList();
        }
     
    }
}
