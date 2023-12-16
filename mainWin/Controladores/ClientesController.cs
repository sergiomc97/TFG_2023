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
            //.Take(150)
            List<Cliente> listaDeClientes = _context.clientes.ToList();
            ObservableCollection<Cliente> ClientesFiltrados = new ObservableCollection<Cliente>(listaDeClientes.OrderByDescending(c => c.IdCliente).ToList());

            return ClientesFiltrados;
        }

       
    }
}
