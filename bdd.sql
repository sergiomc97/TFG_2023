
INSERT INTO `categorias` VALUES (1,'Electrónica'),(2,'Ropa'),(3,'Hogar'),(4,'Alimentos'),(5,'Pantallas'),(6,'Altavoces'),(7,'Herramientas'),(8,'Sensores');

INSERT INTO `citas` VALUES (1,'2023-08-10','10:00:00',1,'Cita para revisión'),(2,'2023-08-11','15:30:00',2,'Cita para consulta'),(3,'2023-08-12','14:00:00',3,'Cita para instalación');

INSERT INTO `empleados` VALUES (1,'Ana Rodríguez','ana@example.com','111-222-3333',1),(2,'Luis García','luis@example.com','444-555-6666',2),(3,'Laura Gómez','laura@example.com','777-888-9999',3),(4,'Ana Rodríguez','ana@example.com','111-222-3333',1),(5,'Luis García','luis@example.com','444-555-6666',2),(6,'Laura Gómez','laura@example.com','777-888-9999',3);

INSERT INTO `estados` VALUES (1,'Pendiente'),(2,'En proceso'),(3,'Completado'),(4,'Cancelado'),(5,'Por asignar'),(6,'En proceso'),(7,'Por entregar'),(8,'Rechazado'),(9,'Sin solucion'),(10,'Garantia');

INSERT INTO `marcas` VALUES (1,'Sony'),(2,'Samsung'),(3,'Nike'),(4,'Adidas'),(5,'Sony'),(6,'Samsung'),(7,'Apple'),(8,'Xiaomi');

INSERT INTO `ordenes` VALUES (1,'2023-08-01',1,2,'Modelo A',1,1,'2023-08-15','2023-08-20','Alta'),(2,'2023-08-02',2,3,'Modelo B',2,2,'2023-08-18','2023-08-25','Media'),(3,'2023-08-03',3,1,'Modelo C',3,3,'2023-08-20','2023-08-27','Baja');

INSERT INTO `pendientes` VALUES (1,'2023-08-05','Cliente Pendiente 1','111-222-3333',50.00,100.00,1),(2,'2023-08-06','Cliente Pendiente 2','444-555-6666',0.00,80.00,2),(3,'2023-08-07','Cliente Pendiente 3','777-888-9999',20.00,50.00,3);

INSERT INTO `productos` VALUES (1,'TV LED 55\"',500.00,799.00,1,50,1),(2,'Zapatillas deportivas',50.00,100.00,3,100,2),(3,'Laptop i7',800.00,1200.00,2,30,1),(4,'TV LED 55\"',500.00,799.00,1,50,1),(5,'Zapatillas deportivas',50.00,100.00,3,100,2),(6,'Laptop i7',800.00,1200.00,2,30,1);

INSERT INTO `proveedores` VALUES (1,'ElectroMart','David García','david@electromart.com','555-999-8888','www.electromart.com','Proveedor de productos electrónicos',1),(2,'ShoeZone','Laura Pérez','laura@shoezone.com','444-222-1111','www.shoezone.com','Proveedor de calzado deportivo',2);

INSERT INTO `roles` VALUES (1,'Administrador'),(2,'Usuario'),(3,'Soporte'),(4,'Administrador'),(5,'Usuario'),(6,'Soporte');

INSERT INTO `servicios` VALUES (1,'Mantenimiento'),(2,'Reparación'),(3,'Instalación'),(4,'Consultoría'),(5,'Mantenimiento'),(6,'Reparación'),(7,'Instalación'),(8,'Consultoría');
