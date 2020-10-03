USE AircraftControl

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'pdAeronave'
)
DROP PROCEDURE dbo.pdAeronave
GO
CREATE PROCEDURE dbo.pdAeronave
    @Prefix VARCHAR(6)
AS    
    DELETE FROM Aeronaves
    WHERE PREFIX = @Prefix
GO