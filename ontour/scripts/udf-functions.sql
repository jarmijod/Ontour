USE OnTour
GO

DROP FUNCTION dbo.IsCantidadDiasInRange
GO

CREATE FUNCTION dbo.IsCantidadDiasInRange (@codigo_paquete NVARCHAR(5), @value INT) RETURNS BIT AS
BEGIN
	DECLARE @min INT
	DECLARE @max INT
	SET @min = (SELECT dias_minimo FROM PAQUETE_TURISTICO WHERE codigo = @codigo_paquete)
	SET @max = (SELECT dias_maximo FROM PAQUETE_TURISTICO WHERE codigo = @codigo_paquete)

	IF (@value BETWEEN @min AND @max) RETURN 1
	RETURN 0
END
GO