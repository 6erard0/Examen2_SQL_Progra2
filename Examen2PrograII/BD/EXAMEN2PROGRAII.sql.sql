/*
     //Mantenimiento de las tablas:  Equipos, Usuarios y tecnicos 
     //Estudiante: Gerardo Navarro Ugarte
*/

/*Creacion de la base de datos*/

CREATE DATABASE EXAMEN2PROGRAII
GO

USE EXAMEN2PROGRAII
GO

/*Creación de tabla de equipos*/

CREATE TABLE Equipos
(
    EquipoID int identity(1,1), 
	TipoEquipo varchar(50) NOT NULL,
	CONSTRAINT pk_idequipos PRIMARY KEY(EquipoID)
)
GO

/*Creación tabla de usuarios*/

CREATE TABLE Usuarios
(
    UsuarioID int identity(1000,5),
	Nombre int,
	CorreoElectronico varchar(100) NOT NULL,
	CONSTRAINT pk_idusuarios PRIMARY KEY (UsuarioID),
	CONSTRAINT fk_idequipos FOREIGN KEY (Nombre) REFERENCES equipos (EquipoID)
)
GO

/*Creación tabla de tecnicos*/

CREATE TABLE Tecnicos
(
    TecnicoID int identity(10,15),
	Nombre int,
	Especialidad varchar(105) NOT NULL,
	CONSTRAINT pk_idtecnicos PRIMARY KEY (TecnicoID),
	CONSTRAINT fk_idequipos1 FOREIGN KEY (Nombre) REFERENCES equipos (EquipoID)
)
GO

/*Creación de tabla reparaciones*/

CREATE TABLE Reparaciones
(
    ReparacionID int identity(1001,35),
	EquipoID int,
	FechaSolicitud datetime constraint df_fecha2 DEFAULT GETDATE(),
	Estado varchar(200) NOT NULL,
	CONSTRAINT pk_idrepaciones PRIMARY KEY (ReparacionID),
	CONSTRAINT fk_idequipos2 FOREIGN KEY (EquipoID) REFERENCES equipos (EquipoID)
)
GO

/*Creación de tabla de los detalles de la reparacion*/

CREATE TABLE DetallesDeLaReparacion
(
    DetalleID int identity(1002,143),
	ReparacionID int,
	Descripcion varchar(103) NOT NULL,
	FechaInicio datetime constraint df_fecha3 DEFAULT GETDATE(),
	FechaFin datetime constraint df_fecha5 DEFAULT GETDATE(),
	CONSTRAINT pk_iddetallesreparacion PRIMARY KEY (DetalleID),
	CONSTRAINT fk_idequipos3 FOREIGN KEY (ReparacionID) REFERENCES equipos (EquipoID)
)
GO

/*Creación de la tabla asignaciones*/

CREATE TABLE Asignaciones
(
    AsignacionID int identity(120,35),
	ReparacionID int,
	TecnicosID int,
	FechaAsignacion datetime constraint df_fecha4 DEFAULT GETDATE(),
	CONSTRAINT pk_idasignaciones PRIMARY KEY (AsignacionID),
	CONSTRAINT fk_idequipos4 FOREIGN KEY (TecnicosID) REFERENCES equipos (EquipoID)
)
GO

-- EN ESTA PARTE SE HACEN LOS PROCEDIMIENTOS ALMACENADOS, STORE, PA, SP

/*Aqui es para agregar equipos*/

CREATE PROCEDURE AGREGAREquipos
@TIPOEQUIPO VARCHAR(100)
  AS
    BEGIN
	    INSERT INTO Equipos (TipoEquipo) VALUES (@TIPOEQUIPO)
	END
GO

/*Aqui es para borrar equipos*/

CREATE PROCEDURE BORRAREquipos
@CODIGO INT
   AS    
     BEGIN
	     DELETE Equipos WHERE EquipoID =@CODIGO
	 END
GO

/*Aqui es para consultar los equipos*/

CREATE PROCEDURE CONSULTAEquipos
  AS
    BEGIN
	  SELECT * FROM Equipos
	END
GO

/*En esta siguiente parte es para consultar equipos y que el programa funcione*/

CREATE PROCEDURE CONSULTAEquipos_FILTRO
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Equipos WHERE EquipoID = @CODIGO
	END
GO

/*Aqui es para actualizar o modificar los equipos*/

CREATE PROCEDURE MODIFICARequipos
@CODIGO INT,
@TIPOEQUIPO VARCHAR (107)
    AS    
      BEGIN
	    UPDATE Equipos SET TipoEquipo=@TIPOEQUIPO WHERE EquipoID  =@CODIGO
	  END
GO

/*Aqui funciona para agregar usuarios*/

CREATE PROCEDURE AGREGARUsuarios
@CORREOELECTRONICO VARCHAR(100)
  AS
    BEGIN
	    INSERT INTO Usuarios (CorreoElectronico) VALUES (@CORREOELECTRONICO)
	END
GO

/*Aqui funciona para borrar equipos*/

CREATE PROCEDURE BORRARusuarios
@CODIGO INT
  AS    
    BEGIN
	   DELETE Usuarios WHERE UsuarioID =@CODIGO
	END
GO

/*Aqui funiciona para actualizar los equipos*/

CREATE PROCEDURE MODIFICARusuarios
@CODIGO INT,
@CORREOELECTRONICO VARCHAR (107)
    AS    
      BEGIN
	    UPDATE Usuarios SET CorreoElectronico=@CORREOELECTRONICO WHERE UsuarioID  =@CODIGO
	  END
GO

/*Aqui funciona para consultar equipos*/

CREATE PROCEDURE CONSULTAUsuarios
  AS
    BEGIN
	  SELECT * FROM Usuarios
	END
GO

/*Aqui sirve para consultar usuarios para que el programa funcione */

CREATE PROCEDURE CONSULTAUsuarios_FILTRO
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Usuarios WHERE UsuarioID = @CODIGO
	END
GO

/*Aqui es para agregar tecnicos*/

CREATE PROCEDURE AGREGARTecnicos
@ESPECIALIDAD VARCHAR(150)
  AS
    BEGIN
	    INSERT INTO Tecnicos (Especialidad) VALUES (@ESPECIALIDAD)
	END
GO

/*Aqui es para borrar equipos*/

CREATE PROCEDURE BORRARTecnicos
@CODIGO INT
   AS    
     BEGIN
	     DELETE Tecnicos WHERE TecnicoID =@CODIGO
	 END
GO

/*Aqui es para actualizar los equipos*/

CREATE PROCEDURE MODIFICARTecnicos
@CODIGO INT,
@ESPECIALIDAD VARCHAR (107)
    AS    
      BEGIN
	    UPDATE Tecnicos SET Especialidad=@ESPECIALIDAD WHERE TecnicoID  = @CODIGO
	  END
GO

/*Aqui sirve para consultar equipos*/

CREATE PROCEDURE CONSULTATecnicos
  AS
    BEGIN
	  SELECT * FROM Tecnicos
	END
GO

/*Aqui es donde se consulta los tecnicos para que el programa funcione*/

CREATE PROCEDURE CONSULTATecnicos_FILTRO
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Tecnicos WHERE TecnicoID = @CODIGO
	END
GO

/*Aqui se van a agregar dos equipos nuevos*/

INSERT INTO Equipos VALUES ('EQUIPO DE MANTENIMIENTO'),('EQUIPO DE SISTEMAS')
GO

/*Aqui se agrega el primer usuario nuevo*/

EXEC AGREGARUsuarios 'Cristiano@gmail.com'

/*Aqui se agrega el segundo usuario nuevo*/

EXEC AGREGARUsuarios 'Messi@gmail.com'

/*Aqui se agrega el primer usuario nuevo*/

EXEC AGREGARTecnicos 'TECNICO DE MANTENIMIENTO'

/*Aqui se agrega el segundo usuario nuevo*/

EXEC AGREGARTecnicos 'TECNICO DE SISTEMAS'