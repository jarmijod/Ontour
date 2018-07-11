USE OnTour
GO

DROP FUNCTION dbo.IsCantidadDiasInRange
GO

CREATE FUNCTION dbo.IsCantidadDiasInRange (@codigo_paquete NVARCHAR(5), @value INT) RETURNS BIT AS
BEGIN
	DECLARE @min INT
	DECLARE @max INT
	SET @min = (SELECT DiasMinimos FROM PaqueteTuristico WHERE Codigo = @codigo_paquete)
	SET @max = (SELECT DiasMaximos FROM PaqueteTuristico WHERE Codigo = @codigo_paquete)

	IF (@value BETWEEN @min AND @max) RETURN 1
	RETURN 0
END
GO