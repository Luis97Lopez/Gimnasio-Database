CREATE DATABASE Gimnasio;

USE Gimnasio;

CREATE SCHEMA gimnasio;

CREATE TABLE gimnasio.Articulo(

	IdArticulo BIGINT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(40) NOT NULL,
	Precio FLOAT NOT NULL,
	Existencia INT NOT NULL,

	CONSTRAINT PK_Articulo PRIMARY KEY (IdArticulo)

);

CREATE TABLE gimnasio.DetalleVenta(

	IdDetalleVenta BIGINT IDENTITY(1,1) NOT NULL,
	IdArticulo BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Total FLOAT NOT NULL,

	CONSTRAINT PK_DetalleVenta PRIMARY KEY (IdDetalleVenta),
	CONSTRAINT FK_Articulo1 FOREIGN KEY (IdArticulo)
	REFERENCES gimnasio.Articulo(IdArticulo)

);

CREATE TABLE gimnasio.DetalleCompra(

	IdDetalleCompra BIGINT IDENTITY(1,1) NOT NULL,
	IdArticulo BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Total FLOAT NOT NULL,

	CONSTRAINT PK_DetalleCompra PRIMARY KEY (IdDetalleCompra),
	CONSTRAINT FK_Articulo2 FOREIGN KEY (IdArticulo)
	REFERENCES gimnasio.Articulo(IdArticulo)

);

CREATE TABLE gimnasio.Horario(

	IdHorario BIGINT IDENTITY(1,1) NOT NULL,
	HoraInicio TIME NOT NULL,
	HoraFin TIME NOT NULL,

	CONSTRAINT PK_Horario PRIMARY KEY (IdHorario)

);

----------------------------------------------

CREATE TABLE gimnasio.Empleado(

	IdEmpleado BIGINT IDENTITY(1,1) NOT NULL,
	IdHorario BIGINT NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Celular VARCHAR(15) NOT NULL,
	Sueldo FLOAT NOT NULL,
	Dias VARCHAR(7) NOT NULL,

	CONSTRAINT PK_Empleado PRIMARY KEY (IdEmpleado),
	CONSTRAINT FK_Horario1 FOREIGN KEY (IdHorario)
	REFERENCES gimnasio.Horario(IdHorario)

);

CREATE TABLE gimnasio.Venta(

	IdVenta BIGINT IDENTITY(1,1) NOT NULL,
	IdEmpleado BIGINT NOT NULL,
	IdDetalleVenta BIGINT NOT NULL,
	Fecha DATE NOT NULL,

	CONSTRAINT PK_Venta PRIMARY KEY (IdVenta),
	CONSTRAINT FK_Empleado1 FOREIGN KEY (IdEmpleado)
	REFERENCES gimnasio.Empleado(IdEmpleado),
	CONSTRAINT FK_DetalleVenta FOREIGN KEY (IdDetalleVenta)
	REFERENCES gimnasio.DetalleVenta(IdDetalleVenta)

);

CREATE TABLE gimnasio.Compra(

	IdVenta BIGINT IDENTITY(1,1) NOT NULL,
	IdEmpleado BIGINT NOT NULL,
	IdDetalleVenta BIGINT NOT NULL,
	Fecha DATE NOT NULL,

	CONSTRAINT PK_Venta PRIMARY KEY (IdVenta),
	CONSTRAINT FK_Empleado1 FOREIGN KEY (IdEmpleado)
	REFERENCES gimnasio.Empleado(IdEmpleado),
	CONSTRAINT FK_DetalleVenta FOREIGN KEY (IdDetalleVenta)
	REFERENCES gimnasio.DetalleVenta(IdDetalleVenta)

);