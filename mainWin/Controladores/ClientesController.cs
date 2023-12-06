using mainWin.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin.Controladores {
    public class ClientesController {
        private readonly bdContext _context;

        public ClientesController() {
            _context = bdContextSingleton.Instance;
        }


        public ObservableCollection<Cliente> GetClientes() {

            List<Cliente> listaDeClientes = _context.Clientes.ToList();
            ObservableCollection<Cliente> ClientesFiltrados = new ObservableCollection<Cliente>(listaDeClientes.Take(150).ToList());

            return ClientesFiltrados;
        }

       
    }
}
