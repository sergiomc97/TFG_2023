using mainWin.Modelos;
using System.Windows;

namespace mainWin.Controladores {
    //idea sacada de chatgpt para usar una unica instancia del dbcontext en toda la aplicacion
    public class bdContextSingleton {
        private static bdContext? _context;
        string conn;
        public bdContextSingleton(string conn) {
            _context = new bdContext(conn);
            this.conn = conn;
        }

        public static bdContext Instance {
            get {

                return _context;


            }
        }
    }
}
