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

CREATE TABLE gimnasio.Horario(

	IdHorario BIGINT IDENTITY(1,1) NOT NULL,
	HoraInicio TIME NOT NULL,
	HoraFin TIME NOT NULL,

	CONSTRAINT PK_Horario PRIMARY KEY (IdHorario)

);

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
	Fecha DATE NOT NULL,
	Total FLOAT,

	CONSTRAINT PK_Venta PRIMARY KEY (IdVenta),
	CONSTRAINT FK_Empleado1 FOREIGN KEY (IdEmpleado)
	REFERENCES gimnasio.Empleado(IdEmpleado),
);

CREATE TABLE gimnasio.Compra(

	IdCompra BIGINT IDENTITY(1,1) NOT NULL,
	IdEmpleado BIGINT NOT NULL,
	Fecha DATE NOT NULL,
	Total FLOAT,

	CONSTRAINT PK_Compra PRIMARY KEY (IdCompra),
	CONSTRAINT FK_Empleado2 FOREIGN KEY (IdEmpleado)
	REFERENCES gimnasio.Empleado(IdEmpleado),
);

CREATE TABLE gimnasio.DetalleVenta(
	IdVenta BIGINT NOT NULL,
	IdArticulo BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Subtotal FLOAT,

	CONSTRAINT FK_Articulo1 FOREIGN KEY (IdArticulo)
	REFERENCES gimnasio.Articulo(IdArticulo)
);

CREATE TABLE gimnasio.DetalleCompra(
	IdCompra BIGINT NOT NULL,
	IdArticulo BIGINT NOT NULL,
	Cantidad INT NOT NULL,
	Subtotal FLOAT,

	CONSTRAINT FK_Articulo2 FOREIGN KEY (IdArticulo)
	REFERENCES gimnasio.Articulo(IdArticulo)
);


CREATE TABLE gimnasio.Cliente(

	IdCliente BIGINT IDENTITY(1,1) NOT NULL,
	IdEmpleado BIGINT,
	Nombre VARCHAR(50) NOT NULL,
	Direccion VARCHAR(70) NOT NULL,

	CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente),
	CONSTRAINT FK_Empleado3 FOREIGN KEY (IdEmpleado)
	REFERENCES gimnasio.Empleado(IdEmpleado),

);

CREATE TABLE gimnasio.Suscripcion(

	IdSuscripcion BIGINT IDENTITY(1,1) NOT NULL,
	IdEmpleado BIGINT NOT NULL,
	IdCliente BIGINT NOT NULL,
	Precio FLOAT NOT NULL,
	Duracion VARCHAR(10) NOT NULL,
	Tipo VARCHAR(20) NOT NULL,
	Fecha DATE NOT NULL,
	Estado VARCHAR(20) NOT NULL,

	CONSTRAINT PK_Suscripcion PRIMARY KEY (IdSuscripcion),
	CONSTRAINT FK_Empleado4 FOREIGN KEY (IdEmpleado)
	REFERENCES gimnasio.Empleado(IdEmpleado),
	CONSTRAINT FK_Cliente1 FOREIGN KEY (IdCliente)
	REFERENCES gimnasio.Cliente(IdCliente)

);

CREATE TABLE gimnasio.Pago(

	IdPago BIGINT IDENTITY(1,1) NOT NULL,
	IdSuscripcion BIGINT NOT NULL,
	IdCliente BIGINT NOT NULL,
	Total FLOAT NOT NULL,
	Fecha DATE NOT NULL,

	CONSTRAINT PK_Pago PRIMARY KEY (IdPago),
	CONSTRAINT FK_Suscripcion FOREIGN KEY (IdSuscripcion)
	REFERENCES gimnasio.Suscripcion(IdSuscripcion),
	CONSTRAINT FK_Cliente2 FOREIGN KEY (IdCliente)
	REFERENCES gimnasio.Cliente(IdCliente)

);

CREATE TABLE gimnasio.Clase(

	IdClase BIGINT IDENTITY(1,1) NOT NULL,
	IdEmpleado BIGINT NOT NULL,
	IdHorario BIGINT NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Cupo INT NOT NULL,

	CONSTRAINT PK_Clase PRIMARY KEY (IdClase),
	CONSTRAINT FK_Empleado5 FOREIGN KEY (IdEmpleado)
	REFERENCES gimnasio.Empleado(IdEmpleado),
	CONSTRAINT FK_Horario2 FOREIGN KEY (IdHorario)
	REFERENCES gimnasio.Horario(IdHorario)

);

CREATE TABLE gimnasio.Inscripcion(

	IdInscripcion BIGINT IDENTITY(1,1) NOT NULL,
	IdClase BIGINT NOT NULL,
	IdCliente BIGINT NOT NULL,

	CONSTRAINT PK_Inscripcion PRIMARY KEY (IdInscripcion),
	CONSTRAINT FK_Clase FOREIGN KEY (IdClase)
	REFERENCES gimnasio.Clase(IdClase),
	CONSTRAINT FK_Cliente3 FOREIGN KEY (IdCliente)
	REFERENCES gimnasio.Cliente(IdCliente)

);

CREATE RULE RL_EstadoSuscripcion AS @Estado IN (
	'Activa','Inactiva'
)

CREATE RULE RL_TipoSuscripcion AS @Suscripcion IN (
	'Mensual', 'Semestral', 'Anual'
)

EXEC sp_bindrule 'RL_EstadoSuscripcion','gimnasio.Suscripcion.Estado'

EXEC sp_bindrule 'RL_TipoSuscripcion','gimnasio.Suscripcion.Tipo'



CREATE TRIGGER gimnasio.trigger_compraArticulo
ON gimnasio.DetalleCompra
AFTER INSERT
AS
BEGIN
	DECLARE @IdArticulo BIGINT;
	DECLARE @Cantidad FLOAT;
	SELECT @IdArticulo=inserted.IdArticulo FROM inserted;
	SELECT @Cantidad=inserted.Cantidad FROM inserted;

	UPDATE gimnasio.Articulo
	SET Existencia = ((SELECT Existencia FROM gimnasio.Articulo 
						WHERE IdArticulo = @IdArticulo) + @Cantidad)
	WHERE IdArticulo = @IdArticulo
END


CREATE TRIGGER gimnasio.trigger_ventaArticulo
ON gimnasio.DetalleVenta
AFTER INSERT
AS
BEGIN
	DECLARE @IdArticulo BIGINT;
	DECLARE @Cantidad FLOAT;
	SELECT @IdArticulo=inserted.IdArticulo FROM inserted;
	SELECT @Cantidad=inserted.Cantidad FROM inserted;

	UPDATE gimnasio.Articulo
	SET Existencia = ((SELECT Existencia FROM gimnasio.Articulo 
						WHERE IdArticulo = @IdArticulo) - @Cantidad)
	WHERE IdArticulo = @IdArticulo
END

CREATE TRIGGER gimnasio.trigger_addInscripcion
ON gimnasio.Inscripcion
AFTER INSERT
AS
BEGIN
	DECLARE @IdClase BIGINT;

	SELECT @IdClase=inserted.IdClase FROM inserted;

	UPDATE gimnasio.Clase
	SET Cupo = (SELECT Cupo FROM gimnasio.Clase WHERE IdClase=@IdClase) - 1
	WHERE IdClase = @IdClase
END

CREATE TRIGGER gimnasio.trigger_deleteInscripcion
ON gimnasio.Inscripcion
AFTER DELETE
AS
BEGIN
	DECLARE @IdClase BIGINT;

	SELECT @IdClase=inserted.IdClase FROM inserted;

	UPDATE gimnasio.Clase
	SET Cupo = (SELECT Cupo FROM gimnasio.Clase WHERE IdClase=@IdClase) + 1
	WHERE IdClase = @IdClase
END


CREATE TRIGGER gimnasio.totalDetalleCompra
ON gimnasio.DetalleCompra
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @IdArticulo BIGINT;
	DECLARE @Cantidad INT;
	DECLARE @IdDetalleCompra BIGINT;

	SELECT	@IdDetalleCompra=IdDetalleCompra, 
			@Cantidad=Cantidad, 
			@IdArticulo=IdArticulo 
	FROM inserted;


	UPDATE gimnasio.DetalleCompra
	SET Total = (@Cantidad) * (SELECT Precio FROM gimnasio.Articulo WHERE IdArticulo=@IdArticulo)
	WHERE IdDetalleCompra = (@IdDetalleCompra)

END


CREATE TRIGGER gimnasio.totalDetalleVenta
ON gimnasio.DetalleVenta
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @IdArticulo BIGINT;
	DECLARE @Cantidad INT;
	DECLARE @IdDetalleVenta BIGINT;

	SELECT	@IdDetalleVenta=IdDetalleVenta, 
			@Cantidad=Cantidad, 
			@IdArticulo=IdArticulo 
	FROM inserted;


	UPDATE gimnasio.DetalleVenta
	SET Total = (@Cantidad) * (SELECT Precio FROM gimnasio.Articulo WHERE IdArticulo=@IdArticulo)
	WHERE IdDetalleVenta = (@IdDetalleVenta)

END


CREATE TRIGGER gimnasio.trigger_addEmpleado
ON gimnasio.Cliente
AFTER INSERT
AS BEGIN

	DECLARE @IdEmpleado BIGINT;
	DECLARE @IdCliente BIGINT;

	SELECT @IdEmpleado=IdEmpleado FROM
		(SELECT TOP 1 e.IdEmpleado, COUNT(c.IdEmpleado) AS number 
		FROM gimnasio.Empleado e LEFT JOIN gimnasio.Cliente c ON e.IdEmpleado = c.IdEmpleado
		GROUP BY e.IdEmpleado
		ORDER BY number ASC)
	AS foo

	SELECT @IdCliente=IdCliente FROM inserted;

	UPDATE gimnasio.Cliente
	SET IdEmpleado=@IdEmpleado
	WHERE IdCliente=@IdCliente
END

