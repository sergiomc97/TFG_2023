using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class ProductosController {
        private readonly bdContext _context;
        private bdContext context;

        public ProductosController() {
            _context = bdContextSingleton.Instance;
        }

        public ProductosController(bdContext context) {
            this.context = context;
        }

        public List<Producto> GetAll() {

            return _context.productos.Take(150).ToList();

        }

       
    }
}
