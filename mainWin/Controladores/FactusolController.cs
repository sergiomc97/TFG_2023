using mainWin.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Windows;
using Path = System.IO.Path;

namespace mainWin.Controladores {

    public class FactusolController {
        private string connectionString;
        string conn;
        private static string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "logs");
        private static string logFilePath = Path.Combine(logDirectory, "appLog.txt");


        public string er { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase FactusolController con una conexion específica a la base de datos.
        /// </summary>
        /// <param name="db">Ruta o nombre de la base de datos.</param>
        /// <param name="conn">Cadena de conexión para la base de datos.</param>


        public FactusolController(string db, string conn) {
            //connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};" + $"Dbq = {db};" ;
            connectionString = $"Provider = Microsoft.ACE.OLEDB.12.0; Data Source={db};";
            //connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={db}";
            this.conn = conn;
        }


        private void LogException(string ex) {
            try {
                if (!Directory.Exists(logDirectory)) {
                    Directory.CreateDirectory(logDirectory);
                }

                string message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Error: {ex}\n";
                File.AppendAllText(logFilePath, message);
            }
            catch (Exception e) {
                
            }
        }


        /// <summary>
        /// Comprueba la existencia de entidades en la base de datos y las agrega o actualiza segun sea necesario.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad a verificar.</typeparam>
        /// <param name="entities">Lista de entidades a verificar.</param>
        /// <exception cref="InvalidOperationException">Se lanza si la entidad no tiene una propiedad 'id' de tipo entero.</exception>

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
                        LogException("################### se ha añadido una entidad:" + idPropertyName + "###################");
                    }
                }

                context.Set<T>().AddRange(entitiesToAddOrUpdate);

                context.SaveChanges();
            }
        }


        /// <summary>
        /// Comprueba y actualiza la existencia de productos en la base de datos, asignando proveedores y categorias por defecto si es necesario.
        /// </summary>
        /// <param name="entities">Lista de productos a verificar.</param>
        /// <exception cref="DbUpdateException">Se lanza si hay un error al actualizar la base de datos.</exception>

        public void CompExiste_long(List<Producto> entities) {

            using (var context = new bdContext(conn)) {
                var proveedorPorDefecto = context.Set<Proveedore>().Find(1);
                var categoriaPorDefecto = context.Set<Categoria>().Find(9);
                try {
                    foreach (var en in entities) {

                        var existingProveedor = context.Set<Proveedore>().Any(p => p.IdProveedor == en.Proveedor_id) ? en.Proveedor_id : proveedorPorDefecto.IdProveedor;
                        var existingCate = context.Set<Categoria>().Any(c => c.IdCategoria == en.Categoria_id) ? en.Categoria_id : categoriaPorDefecto.IdCategoria;

                        var existingEntity = context.Set<Producto>().Find(en.IdProducto);

                        if (existingEntity == null) {
                            en.Proveedor_id = existingProveedor;
                            en.Categoria_id = existingCate;
                            context.Set<Producto>().Add(en);

                        }

                    }

                    context.SaveChanges();

                }
                catch (DbUpdateException ex) {
                    LogException(ex.ToString());
                    LogException("################### DbUpdateException ###################");

                    LogException("StackTrace: " + ex.StackTrace);

                    LogException("InnerException: " + ex.InnerException.Message);

                    foreach (var entry in ex.Entries) {
                        LogException($"Entity of type {entry.Entity.GetType().FullName} in state {entry.State} could not be updated");
                    }
                }
            }
        }
        /// <summary>
        /// Comprueba y actualiza la existencia de ordenes en la base de datos. Si una orden no existe, la añade a la base de datos. 
        /// Si la orden ya existe, actualiza sus datos si la version de la RowVersion de la orden entrante es mas reciente.
        /// </summary>
        /// <param name="entities">Lista de ordenes a verificar y actualizar.</param>
        /// <exception cref="DbUpdateException">Se lanza si hay un error al intentar actualizar la base de datos, 
        /// proporcionando detalles sobre la entidad y el estado en el que se encontro el error.</exception>

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
                    LogException(ex.ToString());
                    LogException("################### DbUpdateException ###################");

                    LogException("StackTrace: " + ex.StackTrace);

                    LogException("InnerException: " + ex.InnerException.Message);

                    foreach (var entry in ex.Entries) {
                        LogException($"Entity of type {entry.Entity.GetType().FullName} in state {entry.State} could not be updated");
                    }
                }
            }
        }
        /// <summary>
        /// Carga datos de diferentes entidades y verifica su existencia en la base de datos, actualizándolos si ha habido cambios.
        /// </summary>
        /// <exception cref="DbUpdateException">Se lanza si hay un error al actualizar la base de datos.</exception>


        public void CargarDatosSiModificado() {

            List<Cliente> clientes = CargarClientes();
            List<Producto> articulos = CargarArticulos();
            List<Empleado> empleados = CargarEmpleados();
            List<Ordene> ordenes = CargarOrdenes();
            List<Categoria> categorias = CargarCategorias();
            List<Proveedore> proveedores = CargarProveedores();
            List<Marca> marcas = CargarMarcas();


            try {
                if (proveedores != null) {
                    CompExiste<Proveedore>(proveedores);
                    LogException("################### CompExiste proveedores ###################");
                }
                if (categorias != null) {
                    CompExiste<Categoria>(categorias);
                    LogException("################### CompExiste categorias ###################");
                }
                if (articulos != null) {
                    CompExiste_long(articulos);
                    LogException("################### CompExiste articulos ###################");
                }
                if (empleados != null) {
                    CompExiste<Empleado>(empleados);
                    LogException("################### CompExiste empleados ###################");
                }
                if (ordenes != null) {
                    CompExiste_Ordenes(ordenes);
                    LogException("################### CompExiste ordenes ###################");
                }
                if (marcas != null) {
                    CompExiste<Marca>(marcas);
                    LogException("################### CompExiste marcas ###################");
                }
                if (clientes != null) {
                    CompExiste<Cliente>(clientes);
                    LogException("################### CompExiste clientes ###################");
                }

            }
            catch (DbUpdateException ex) {
                LogException("CargarDatosSiModificado DbUpdateException " + ex.ToString());
                LogException("################### DbUpdateException ###################");

                LogException("StackTrace: " + ex.StackTrace);

                LogException("InnerException: " + ex.InnerException.Message);

                foreach (var entry in ex.Entries) {
                    LogException($"Entity of type {entry.Entity.GetType().FullName} in state {entry.State} could not be updated");
                }
            }
            catch (Exception e) {
                LogException("CargarDatosSiModificado " + e.ToString());

            }


        }


        public List<Cliente> CargarClientes() {
            try {
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
                    LogException("################### CargarClientes() ###################");
                    return clientes;
                }
            }
            catch (Exception e) {

                LogException(e.ToString());
                return null;

            }
        }

        public List<Producto> CargarArticulos() {
            try {
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
                                Marca_id = 1,
                                Categoria_id = Categoria_id,
                                Existencias = Existencias,
                                Proveedor_id = Proveedor_id,
                                Costo = 0
                            };

                            articulos.Add(articulo);
                        }
                    }
                    LogException("################### CargarArticulos() ###################");
                    return articulos;
                }
            }
            catch (Exception e) {
                LogException(e.ToString());
                return null;

            }
        }
        public List<Ordene> CargarOrdenes() {
            try {
                using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                    connection.Open();
                    string cli;
                    int cli2;

                    List<Ordene> ordenes = new List<Ordene>();
                    using (OleDbCommand command = new OleDbCommand("SELECT CODPAR,TRAPAR, CLIPAR, CNOPAR, CNIPAR, CDOPAR, FENPAR, " +
                        "TELPAR, AVEPAR, FSAPAR, OBSPAR, MODPAR FROM R_PAR", connection))
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
                                Fecha_ent = fecha_ent,
                                Fecha_comp = fecha.AddDays(5),
                                //Asignado_id = 1,
                                Modelo = reader["MODPAR"].ToString(),
                                Cliente = new Cliente {
                                    Nombre = cli,
                                    Telefono = reader["TELPAR"].ToString(),
                                    Dni = reader["CNIPAR"].ToString(),
                                    Direccion = reader["CDOPAR"].ToString()
                                },

                                Averia = reader["AVEPAR"].ToString(),
                                Solucion = reader["TRAPAR"].ToString(),
                                Telefono = reader["TELPAR"].ToString(),
                                Estado_id = 1,
                                Prioridad = "Alta",
                                Cliente_id = cli2,
                                Producto_id = 1,
                                Servicio_id = 1,
                                Observaciones = reader["OBSPAR"].ToString()

                            };
                            ordenes.Add(orden);
                        }
                    }
                    LogException("################### CargarOrdenes() ###################");
                    return ordenes;
                }
            }
            catch (Exception e) {
                LogException(e.ToString());
                return null;

            }
        }

        public List<Empleado> CargarEmpleados() {
            try {
                using (OleDbConnection connection = new OleDbConnection(connectionString)) {
                    connection.Open();
                    List<Empleado> Empleados = new List<Empleado>();
                    using (OleDbCommand command = new OleDbCommand("SELECT CODAGE, NOMAGE, EMAAGE, TEPAGE FROM F_AGE", connection))
                    using (OleDbDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Empleado Empleado = new Empleado {
                                //IdEmpleado = (int)reader["CODAGE"],
                                Nombre = reader["NOMAGE"].ToString(),
                                Email = reader["EMAAGE"].ToString(),
                                Telefono = reader["TEPAGE"].ToString()
                            };
                            Empleados.Add(Empleado);
                        }
                    }
                    LogException("################### CargarEmpleados() ###################");
                    return Empleados;
                }
            }
            catch (Exception e) {

                LogException(e.ToString());
                return null;
            }
        }

        public List<Categoria> CargarCategorias() {
            try {
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
                    LogException("################### CargarCategorias() ###################");
                    return Categorias;
                }
            }
            catch (Exception e) {
                LogException(e.ToString());
                return null;

            }
        }

        public List<Proveedore> CargarProveedores() {
            try {
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
                    LogException("################### CargarProveedores() ###################");
                    return Proveedores;
                }
            }
            catch (Exception e) {
                LogException(e.ToString());
                return null;

            }
        }

        public List<Marca> CargarMarcas() {
            try {
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
                    LogException("################### CargarMarcas() ###################");
                    return Marcas;
                }
            }
            catch (Exception e) {
                LogException(e.ToString());
                return null;

            }
        }

    }
}
