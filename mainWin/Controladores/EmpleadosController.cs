using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class EmpleadosController {
        private readonly bdContext _context;
        private bdContext context;

        public EmpleadosController() {
            _context = bdContextSingleton.Instance;
        }

        public EmpleadosController(bdContext context) {
            this.context = context;
        }

        public List<Empleado> getEmpleados() {
        
        return _context.Empleados.ToList();
        
        }
    }
}
