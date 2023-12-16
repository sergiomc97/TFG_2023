using mainWin.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;

namespace mainWin.Controladores {
    public class UsuariosController {
        private readonly bdContext _context;

        public Usuario UsuarioAutenticado { get; private set; }

        public UsuariosController() {
            _context = bdContextSingleton.Instance;
        }

        public List<Usuario> getusers() {

            return _context.usuarios.ToList();
        }
        public async Task<List<Usuario>> LoadUsers() {
            return await Task.Run(() =>  _context.usuarios.ToList());
        }
        public void AddUsers(Usuario u) {

            _context.Attach(u);
            _context.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
        }
        // Método para generar un hash y una sal para la contraseña
        public (byte[] hash, byte[] salt) GeneratePasswordHash(string password) {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 20, 10000)) {
                return (deriveBytes.GetBytes(20), deriveBytes.Salt);
            }
        }

        public void RegisterUser(string username, string password, string m, Empleado e) {

            var (hash, salt) = GeneratePasswordHash(password);
            Usuario newUser = new Usuario {
                Nick = username,
                PasswordHash = hash,
                Mail = m,
                Salt = salt,
                Rol_id = 2, 
                Empleado = e
            };

            AddUsers(newUser);
            

        }

        public void RegisterUserBasic(string username, string password, string m) {

            var (hash, salt) = GeneratePasswordHash(password);
            Usuario newUser = new Usuario {
                Nick = username,
                PasswordHash = hash,
                Mail = m,
                Salt = salt,
                Rol_id = 2
            };

            AddUsers(newUser);
            MessageBox.Show("Bienvenid@");


        }


        // Método para verificar la contraseña
        public bool VerifyPassword(Usuario u,string password, byte[] storedHash, byte[] salt) {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000)) {
                byte[] newKey = deriveBytes.GetBytes(20);

                for (int i = 0; i < 20; i++) {
                    if (newKey[i] != storedHash[i]) {
                        return false;
                    }
                }
            }
            UsuarioAutenticado = u;
            return true;
        }



    }
}
