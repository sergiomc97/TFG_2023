-- Tabla: roles
CREATE TABLE IF NOT EXISTS `roles` (
  `idRol` INT NOT NULL AUTO_INCREMENT,
  `rol` VARCHAR(45) DEFAULT NULL,
  PRIMARY KEY (`idRol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: servicios
CREATE TABLE IF NOT EXISTS `servicios` (
  `idServicio` INT NOT NULL AUTO_INCREMENT,
  `servicio` VARCHAR(45) DEFAULT NULL,
  PRIMARY KEY (`idServicio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: categoria
CREATE TABLE IF NOT EXISTS `categorias` (
  `idCategoria` INT NOT NULL AUTO_INCREMENT,
  `categoria` VARCHAR(45) DEFAULT NULL,
  PRIMARY KEY (`idCategoria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `idCliente` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) DEFAULT NULL,
  `email` VARCHAR(100) DEFAULT NULL,
  `telefono` VARCHAR(45) DEFAULT NULL,
  PRIMARY KEY (`idCliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: estados
CREATE TABLE IF NOT EXISTS `estados` (
  `idEstado` INT NOT NULL AUTO_INCREMENT,
  `estado` VARCHAR(45) DEFAULT NULL,
  PRIMARY KEY (`idEstado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: marcas
CREATE TABLE IF NOT EXISTS `marcas` (
  `idMarca` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) DEFAULT NULL,
  PRIMARY KEY (`idMarca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: citas
CREATE TABLE IF NOT EXISTS `citas` (
  `idCita` INT NOT NULL AUTO_INCREMENT,
  `fecha` DATE DEFAULT NULL,
  `hora` TIME DEFAULT NULL,
  `cliente_id` INT DEFAULT NULL,
  `desc` VARCHAR(100) DEFAULT NULL,
  PRIMARY KEY (`idCita`),
  INDEX `cliente_id` (`cliente_id`),
  FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`idCliente`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: empleados
CREATE TABLE IF NOT EXISTS `empleados` (
  `idEmpleado` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) DEFAULT NULL,
  `email` VARCHAR(100) DEFAULT NULL,
  `telefono` VARCHAR(45) DEFAULT NULL,
  `rol_id` INT DEFAULT NULL,
  PRIMARY KEY (`idEmpleado`),
  INDEX `rol_id` (`rol_id`),
  FOREIGN KEY (`rol_id`) REFERENCES `roles` (`idRol`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: productos
CREATE TABLE IF NOT EXISTS `productos` (
  `idProducto` INT NOT NULL AUTO_INCREMENT,
  `producto` VARCHAR(100) DEFAULT NULL,
  `costo` DECIMAL(10, 2) DEFAULT NULL,
  `precio` DECIMAL(10, 2) DEFAULT NULL,
  `marca_id` INT DEFAULT NULL,
  `existencias` INT DEFAULT NULL,
  `categoria_id` INT DEFAULT NULL,
  PRIMARY KEY (`idProducto`),
  INDEX `marca_id` (`marca_id`),
  INDEX `categoria_id` (`categoria_id`),
  FOREIGN KEY (`marca_id`) REFERENCES `marcas` (`idMarca`)
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`idCategoria`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE IF NOT EXISTS `ordenes` (
  `idOrden` int NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `cliente_id` int DEFAULT NULL,
  `asignado_id` int DEFAULT NULL,
  `producto_id` bigint DEFAULT NULL,
  `estado_id` int DEFAULT NULL,
  `servicio_id` int DEFAULT NULL,
  `fecha_comp` date DEFAULT NULL,
  `fecha_ent` date DEFAULT NULL,
  `prioridad` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `modelo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `averia` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `solucion` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `observaciones` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `telefono` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ClienteStr` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CliDni` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CliDirec` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`idOrden`),
  KEY `cliente_id` (`cliente_id`),
  KEY `servicio_id` (`servicio_id`),
  KEY `asignado_id` (`asignado_id`),
  KEY `estado_id` (`estado_id`),
  KEY `producto_id` (`producto_id`),
  CONSTRAINT `ordenes_ibfk_1` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`idCliente`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `ordenes_ibfk_2` FOREIGN KEY (`servicio_id`) REFERENCES `servicios` (`idServicio`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `ordenes_ibfk_3` FOREIGN KEY (`asignado_id`) REFERENCES `empleados` (`idEmpleado`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `ordenes_ibfk_4` FOREIGN KEY (`producto_id`) REFERENCES `productos` (`idProducto`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `ordenes_ibfk_5` FOREIGN KEY (`estado_id`) REFERENCES `estados` (`idEstado`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2511 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: pendientes
CREATE TABLE IF NOT EXISTS `pendientes` (
  `idPendientes` INT NOT NULL AUTO_INCREMENT,
  `fecha` DATE DEFAULT NULL,
  `nombre` VARCHAR(100) DEFAULT NULL,
  `telefono` VARCHAR(45) DEFAULT NULL,
  `anticipo` DECIMAL(10, 2) DEFAULT NULL,
  `precio` DECIMAL(10, 2) DEFAULT NULL,
  `estado_id` INT DEFAULT NULL,
  PRIMARY KEY (`idPendientes`),
  INDEX `estado_id` (`estado_id`),
  FOREIGN KEY (`estado_id`) REFERENCES `estados` (`idEstado`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: proveedores
CREATE TABLE IF NOT EXISTS `proveedores` (
  `idProveedor` INT NOT NULL AUTO_INCREMENT,
  `empresa` VARCHAR(100) DEFAULT NULL,
  `personaCont` VARCHAR(100) DEFAULT NULL,
  `email` VARCHAR(100) DEFAULT NULL,
  `telefono` VARCHAR(45) DEFAULT NULL,
  `sitioWeb` VARCHAR(100) DEFAULT NULL,
  `desc` VARCHAR(200) DEFAULT NULL,
  `producto_id` INT DEFAULT NULL,
  PRIMARY KEY (`idProveedor`),
  INDEX `producto_id` (`producto_id`),
  FOREIGN KEY (`producto_id`) REFERENCES `productos` (`idProducto`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `iduser` INT NOT NULL AUTO_INCREMENT,
  `nick` VARCHAR(45) DEFAULT NULL,
  `pass` VARCHAR(45) DEFAULT NULL,
  `rol_id` INT DEFAULT NULL,
  `mail` VARCHAR(100) DEFAULT NULL,
  PRIMARY KEY (`iduser`),
  INDEX `rol_id` (`rol_id`),
  FOREIGN KEY (`rol_id`) REFERENCES `roles` (`idRol`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla: config
CREATE TABLE IF NOT EXISTS `config` (
  `idConfig` INT NOT NULL AUTO_INCREMENT,
  `usuario_id` INT DEFAULT NULL,
  `rutaFS` VARCHAR(45) DEFAULT NULL,
  `opcion2` VARCHAR(45) DEFAULT NULL,
  -- Agrega otras columnas según sea necesario para la configuración del usuario
  PRIMARY KEY (`idConfig`),
  INDEX `usuario_id` (`usuario_id`),
  FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`iduser`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


