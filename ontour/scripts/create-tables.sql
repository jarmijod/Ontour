USE OnTour
GO

-- Tabla base, nunca debe ser utilizada por sí misma
CREATE TABLE PERSONA(
	rut NVARCHAR(10) PRIMARY KEY,
	nombre_completo NVARCHAR(50) NOT NULL,
	telefono NVARCHAR(8),
	email NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE REPRESENTANTE(
	-- Esta tabla utiliza una PFK para representar herencia
	rut NVARCHAR(10) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES PERSONA(rut)
)
GO

CREATE TABLE APODERADO(
	-- Esta tabla utiliza una PFK para representar herencia
	rut NVARCHAR(10) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES PERSONA(rut),
	-- Por seguridad, la empresa solo conserva el RUT del alumno
	rut_alumno NVARCHAR(10) NOT NULL UNIQUE,
	monto_aportado INT NOT NULL
)
GO

CREATE TABLE CURSO(
	codigo INT PRIMARY KEY,
	alias NVARCHAR(3) NOT NULL,
	establecimiento NVARCHAR(30) NOT NULL,
	cantidad_alumnos INT NOT NULL CHECK(cantidad_alumnos BETWEEN 0 AND 60),
	rut_representante NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES REPRESENTANTE(rut)
)
GO

CREATE TABLE PAQUETE_TURISTICO(
	codigo NVARCHAR(5) PRIMARY KEY,
	origen NVARCHAR(20) NOT NULL,
	destino NVARCHAR(20) NOT NULL,
	dias_minimo INT NOT NULL CHECK(dias_minimo BETWEEN 0 AND 30),
	dias_maximo INT NOT NULL,
	valor_base INT NOT NULL,
	valor_pasajero INT NOT NULL,
	CHECK(dias_maximo >= dias_minimo)
)
GO

CREATE TABLE CONTRATO(
	codigo INT PRIMARY KEY,
	cantidad_dias INT NOT NULL,
	rut_ejecutivo NVARCHAR(10) NOT NULL,
	codigo_curso INT FOREIGN KEY REFERENCES CURSO(codigo),
	codigo_paquete_turistico NVARCHAR(5) FOREIGN KEY REFERENCES PAQUETE_TURISTICO(codigo),
	CHECK(dbo.IsCantidadDiasInRange(codigo_paquete_turistico, cantidad_dias) = 1)
)
GO

CREATE TABLE PAGO_EFECTUADO(
	codigo INT PRIMARY KEY,
	monto INT NOT NULL CHECK(monto > 0),
	rut_apoderado NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES APODERADO(rut),
	codigo_contrato INT NOT NULL FOREIGN KEY REFERENCES CONTRATO(codigo)
)
GO

CREATE TABLE PAGO_DEPOSITO(
	codigo INT PRIMARY KEY FOREIGN KEY REFERENCES PAGO_EFECTUADO(codigo),
	entidad_bancaria NVARCHAR(20) NOT NULL,
	comprobante_pago NVARCHAR(40) NOT NULL
)
GO