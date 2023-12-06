using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace mainWin.Controladores {

    public class FactusolController {
        private string connectionString;
        string conn;

        public string er { get; set; }

        public FactusolController(string db, string conn) {

            connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={db}";
            this.conn = conn;
        }

        public void CompExiste<T>(List<T> entities) where T : class {

            List<T> entitiesToAddOrUpdate = new List<T>();

            using (var context = new bdContext(conn)) {
                PropertyInfo? idProperty = typeof(T).GetProperties()
            .FirstOrDefault(p => p.Name.ToLower().StartsWith("id"));

                if (idProperty == null) {
                    throw new InvalidOperationException("La entidad no tiene una propiedad 'id' de tipo entero.");
                }

                string idPropertyName = idProperty.Name;

                HashSet<int> existingIds = new HashSet<int>(context.Set<T>().Select(e => (int)idProperty.GetValue(e)));

                foreach (var en in entities) {

                    int idValue = (int)idProperty.GetValue(en);

                    if (!existingIds.Contains(idValue)) {

                        entitiesToAddOrUpdate.Add(en);
                        Debug.WriteLine("################### se ha añadido una entidad:" + idPropertyName + "###################");
                    }
                }

                context.Set<T>().AddRange(entitiesToAddOrUpdate);

                context.SaveChanges();
            }
        }



        public void CompExiste_long(List<Producto> entities) {

            using (var context = new bdContext(conn)) {
                var proveedorPorDefecto = context.Set<Proveedore>().Find(1);
                var categoriaPorDefecto = context.Set<Categoria>().Find(9);
                try {
                    foreach (var en in entities) {

                        var existingProveedor = context.Set<Proveedore>().Any(p => p.IdProveedor == en.ProveedorId) ? en.ProveedorId : proveedorPorDefecto.IdProveedor;
                        var existingCate = context.Set<Categoria>().Any(c => c.IdCategoria == en.CategoriaId) ? en.CategoriaId : categoriaPorDefecto.IdCategoria;

                        var existingEntity = context.Set<Producto>().Find(en.IdProducto);

                        if (existingEntity == null) {
                            en.ProveedorId = existingProveedor;
                            en.CategoriaId = existingCate;
                            context.Set<Producto>().Add(en);

                        }

                    }

                    context.SaveChanges();

                }
                catch (DbUpdateException ex) {
                    Debug.WriteLine("################### DbUpdateException ###################");

                    Debug.WriteLine("StackTrace: " + ex.StackTrace);

                    Debug.WriteLine("InnerException: " + ex.InnerException.Message);

                    foreach (var entry in ex.Entries) {
                        Debug.WriteLine($"Entity of type {entry.Entity.GetType().FullName} in state {entry.State} could not be updated");
                    }
                }
            }
        }
        public void CompExiste_Ordenes(List<Ordene> entities) {
            using (var context = new bdContext(conn)) {
                try {
                    foreach (var en in entities) {
                        var existingEntity = context.Set<Ordene>().Find(en.IdOrden);

                        if (existingEntity == null) {
                            context.Set<Ordene>().Add(en);
                        }
                        else {
                            if (existingEntity.RowVersion < en.RowVersion) {
                                context.Entry(existingEntity).CurrentValues.SetValues(en);
                            }
                        }
                    }

                    context.SaveChanges();
                }
                catch (DbUpdateException ex) {
                    Debug.WriteLine("################### DbUpdateException ###################");

                    Debug.WriteLine("StackTrace: " + ex.StackTrace);

                    Debug.WriteLine("InnerException: " + ex.InnerException.Message);

                    foreach (var entry in ex.Entries) {
                        Debug.WriteLine($"Entity of type {entry.Entity.GetType().FullName} in state {entry.State} could not be updated");
                    }
                }
            }
        }


        public void CargarDatosSiModificado() {

            List<Cliente> clientes = CargarClientes();
            List<Producto> articulos = CargarArticulos();
            List<Empleado> empleados = CargarEmpleados();
            List<Ordene> ordenes = CargarOrdenes();
            List<Categoria> categorias = CargarCategorias();
            List<Proveedore> proveedores = CargarProveedores();
            List<Marca> marcas = CargarMarcas();


            try {
                //CompExiste<Proveedore>(proveedores);
                //Debug.WriteLine("################### CompExiste proveedores ###################");
                //CompExiste<Cliente>(clientes);
                //Debug.WriteLine("################### CompExiste clientes ###################");
                //CompExiste<Categoria>(categorias);
                //Debug.WriteLine("################### CompExiste categorias ###################");
                //CompExiste_long(articulos);
                //Debug.WriteLine("################### CompExiste articulos ###################");
                //CompExiste<Empleado>(empleados);
                //Debug.WriteLine("################### CompExiste empleados ###################");
                //CompExiste_Ordenes(ordenes);
                //Debug.WriteLine("################### CompExiste ordenes ###################");
                //CompExiste<Marca>(marcas);
                //Debug.WriteLine("################### CompExiste marcas ###################");
                Task.Run(() => CompExiste<Proveedore>(proveedores)); //--> ok
                Task.Run(() => CompExiste<Cliente>(clientes));  //--> ok
                Task.Run(() => CompExiste<Categoria>(categorias));// --> ok
                Task.Run(() => CompExiste_long(articulos));
                Task.Run(() => CompExiste<Empleado>(empleados));// --> ok
                Task.Run(() => CompExiste_Ordenes(ordenes));
                Task.Run(() => CompExiste<Marca>(marcas));
                //Debug.WriteLine("################### PARECE QUE VA BIEN ###################");



            }
            catch (DbUpdateException ex) {
                Debug.WriteLine("################### DbUpdateException ###################");

                Debug.WriteLine("StackTrace: " + ex.StackTrace);

                Debug.WriteLine("InnerException: " + ex.InnerException.Message);

                foreach (var entry in ex.Entries) {
                    Debug.WriteLine($"Entity of type {entry.Entity.GetType().FullName} in state {entry.State} could not be updated");
                }
            }


        }


        public List<Cliente> CargarClientes() {

            List<Cliente> clientes = new List<Cliente>();

            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand("SELECT CODCLI, NOFCLI, DOMCLI, TELCLI FROM F_cli", connection))
                using (OleDbDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Cliente cliente = new Cliente {
                            IdCliente = (int)reader["CODCLI"],
                            Nombre = reader["NOFCLI"].ToString(),
                            Email = reader["DOMCLI"].ToString(),
                            Telefono = reader["TELCLI"].ToString()
                        };
                        clientes.Add(cliente);
                    }
                }
                Debug.WriteLine("################### CargarClientes() ###################");
                return clientes;
            }
        }

        public List<Producto> CargarArticulos() {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                List<Producto> articulos = new List<Producto>();
                using (OleDbCommand command = new OleDbCommand("SELECT CCOART, DESART, PCOART, FAMART, STOART, PHAART FROM F_art", connection))
                using (OleDbDataReader reader = command.ExecuteReader()) {

                    while (reader.Read()) {
                        long idproducto = Convert.ToInt64(reader["CCOART"]);
                        string producto = reader["DESART"].ToString();
                        decimal Precio = (decimal)reader["PCOART"];
                        Int16 Existencias = (Int16)reader["STOART"];
                        int.TryParse(reader["FAMART"].ToString(), out int Categoria_id);
                        int.TryParse(reader["PHAART"].ToString(), out int Proveedor_id);

                        if (Proveedor_id == 0) {
                            Proveedor_id++;
                        }
                        Producto articulo = new Producto {
                            IdProducto = idproducto,
                            Producto1 = producto,
                            Precio = Precio,
                            MarcaId = 1,
                            CategoriaId = Categoria_id,
                            Existencias = Existencias,
                            ProveedorId = Proveedor_id,
                            Costo = 0
                        };

                        articulos.Add(articulo);
                    }
                }
                Debug.WriteLine("################### CargarArticulos() ###################");
                return articulos;
            }
        }
        public List<Ordene> CargarOrdenes() {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                string cli;
                int cli2;

                List<Ordene> ordenes = new List<Ordene>();
                using (OleDbCommand command = new OleDbCommand("SELECT CODPAR,TRAPAR, CLIPAR, CNOPAR, CNIPAR, CDOPAR, FENPAR, " +
                    "TELPAR, AVEPAR, FSAPAR, TECPAR, OBSPAR, MODPAR FROM R_PAR", connection))
                using (OleDbDataReader reader = command.ExecuteReader()) {

                    while (reader.Read()) {
                        cli = reader["CNOPAR"].ToString();
                        cli2 = (int)reader["CLIPAR"];
                        DateTime fecha_ent = (DateTime)reader["FSAPAR"];
                        DateTime fecha = (DateTime)reader["FENPAR"];
                        if (cli2 == 0) cli2 = 12;
                        Ordene orden = new Ordene {
                            IdOrden = (int)reader["CODPAR"],
                            Fecha = (DateTime)reader["FENPAR"],
                            FechaEnt = fecha_ent,
                            FechaComp = fecha.AddDays(5),
                            AsignadoId = 2,
                            Modelo = reader["MODPAR"].ToString(),
                            CliDni = reader["CNIPAR"].ToString(),
                            CliDirec = reader["CDOPAR"].ToString(),
                            Averia = reader["AVEPAR"].ToString(),
                            Solucion = reader["TRAPAR"].ToString(),
                            Telefono = reader["TELPAR"].ToString(),
                            EstadoId = 1,
                            Prioridad = "Alta",
                            ClienteId = cli2,
                            ClienteStr = cli,
                            ProductoId = 47134,
                            ServicioId = 1,
                            Observaciones = reader["OBSPAR"].ToString()

                        };
                        ordenes.Add(orden);
                    }
                }
                Debug.WriteLine("################### CargarOrdenes() ###################");
                return ordenes;
            }
        }

        public List<Empleado> CargarEmpleados() {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                List<Empleado> Empleados = new List<Empleado>();
                using (OleDbCommand command = new OleDbCommand("SELECT CODAGE, NOMAGE FROM F_AGE", connection))
                using (OleDbDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Empleado Empleado = new Empleado {
                            IdEmpleado = (int)reader["CODAGE"],
                            Nombre = reader["NOMAGE"].ToString(),
                            Email = "",
                            RolId = 1
                        };
                        Empleados.Add(Empleado);
                    }
                }
                Debug.WriteLine("################### CargarEmpleados() ###################");
                return Empleados;
            }
        }

        public List<Categoria> CargarCategorias() {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                List<Categoria> Categorias = new List<Categoria>();
                using (OleDbCommand command = new OleDbCommand("SELECT CODFAM, DESFAM FROM F_FAM", connection))
                using (OleDbDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        int.TryParse(reader["CODFAM"].ToString(), out int x);
                        if (x == 0) x = 1;
                        Categoria Categoria = new Categoria {
                            IdCategoria = x,
                            Categoria1 = reader["DESFAM"].ToString()
                        };

                        Categorias.Add(Categoria);
                    }
                }
                Debug.WriteLine("################### CargarCategorias() ###################");
                return Categorias;
            }
        }

        public List<Proveedore> CargarProveedores() {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                List<Proveedore> Proveedores = new List<Proveedore>();
                using (OleDbCommand command = new OleDbCommand("SELECT CODPRO, NOFPRO, OBSPRO, EMAPRO, PCOPRO, CCOPRO, TELPRO, FCBPRO  FROM F_PRO", connection))
                using (OleDbDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Proveedore Proveedor = new Proveedore {
                            IdProveedor = (int)reader["CODPRO"],
                            Empresa = reader["NOFPRO"].ToString(),
                            Desc = reader["OBSPRO"].ToString(),
                            Email = reader["EMAPRO"].ToString(),
                            PersonaCont = reader["PCOPRO"].ToString(),
                            Telefono = reader["TELPRO"].ToString(),
                            SitioWeb = reader["FCBPRO"].ToString()
                        };
                        Proveedores.Add(Proveedor);
                    }
                }
                Debug.WriteLine("################### CargarProveedores() ###################");
                return Proveedores;
            }
        }

        public List<Marca> CargarMarcas() {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                connection.Open();
                List<Marca> Marcas = new List<Marca>();
                using (OleDbCommand command = new OleDbCommand("SELECT CODMAR, DESMAR FROM R_MAR", connection))
                using (OleDbDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        int.TryParse(reader["CODMAR"].ToString(), out int x);
                        Marca Marca = new Marca {
                            IdMarca = x,
                            Nombre = reader["DESMAR"].ToString()
                        };
                        Marcas.Add(Marca);
                    }
                }
                Debug.WriteLine("################### CargarMarcas() ###################");
                return Marcas;
            }
        }
    }
}
