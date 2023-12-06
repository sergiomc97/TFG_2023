using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class CategoriasController {
        private readonly bdContext _context;

        public CategoriasController() {
            _context = bdContextSingleton.Instance;
        }

        public void Create(Categoria categoria) {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public List<Categoria> GetAll() {
            return _context.Categorias.ToList();
        }
        

    }
}
