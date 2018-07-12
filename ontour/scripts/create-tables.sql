USE OnTour
GO

-- Tabla base, nunca debe ser utilizada por sí misma
CREATE TABLE Persona(
	Rut NVARCHAR(10) PRIMARY KEY,
	NombreCompleto NVARCHAR(50) NOT NULL,
	Telefono NVARCHAR(8),
	Email NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE Representante(
	-- Esta tabla utiliza una PFK para representar herencia
	Rut NVARCHAR(10) NOT NULL PRIMARY KEY REFERENCES Persona(Rut)
)
GO

CREATE TABLE Curso(
	Codigo INT PRIMARY KEY,
	Alias NVARCHAR(3) NOT NULL,
	Establecimiento NVARCHAR(30) NOT NULL,
	CantidadAlumnos INT NOT NULL CHECK(CantidadAlumnos BETWEEN 0 AND 60),
	RutRepresentante NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Representante(Rut)
)
GO

CREATE TABLE Apoderado(
	-- Esta tabla utiliza una PFK para representar herencia
	Rut NVARCHAR(10) NOT NULL PRIMARY KEY REFERENCES Persona(Rut),
	-- Por seguridad, la empresa solo conserva el RUT del alumno
	RutAlumno NVARCHAR(10) NOT NULL UNIQUE,
	MontoAportado INT NOT NULL,
	CodigoCurso INT NOT NULL FOREIGN KEY REFERENCES Curso(Codigo)
)
GO

CREATE TABLE PaqueteTuristico(
	Codigo NVARCHAR(5) PRIMARY KEY,
	Origen NVARCHAR(20) NOT NULL,
	Destino NVARCHAR(20) NOT NULL,
	DiasMinimos INT NOT NULL CHECK(DiasMinimos BETWEEN 0 AND 30),
	DiasMaximos INT NOT NULL,
	ValorBase INT NOT NULL,
	ValorPasajero INT NOT NULL,
	CHECK(DiasMaximos >= DiasMinimos)
)
GO

CREATE TABLE Contrato(
	Codigo INT PRIMARY KEY,
	CantidadDias INT NOT NULL,
	RutEjecutivo NVARCHAR(10) NOT NULL,
	CodigoCurso INT FOREIGN KEY REFERENCES CURSO(Codigo),
	CodigoPaqueteTuristico NVARCHAR(5) FOREIGN KEY REFERENCES PaqueteTuristico(Codigo),
	CHECK(dbo.IsCantidadDiasInRange(CodigoPaqueteTuristico, CantidadDias) = 1)
)
GO

CREATE TABLE DetallePago(
	Codigo INT PRIMARY KEY,
	Monto INT NOT NULL CHECK(monto > 0),
	RutApoderado NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Apoderado(Rut),
	CodigoContrato INT NOT NULL FOREIGN KEY REFERENCES Contrato(Codigo)
)
GO

CREATE TABLE PagoDeposito(
	Codigo INT PRIMARY KEY REFERENCES DetallePago(Codigo),
	EntidadBancaria NVARCHAR(20) NOT NULL,
	ComprobantePago NVARCHAR(40) NOT NULL
)
GO