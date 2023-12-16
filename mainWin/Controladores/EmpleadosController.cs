using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class EmpleadosController {
        private readonly bdContext _context;

        public EmpleadosController() {
            _context = bdContextSingleton.Instance;
        }


        public List<Empleado> getEmpleados() {
        
        return _context.empleados.ToList();
        
        }
    }
}
