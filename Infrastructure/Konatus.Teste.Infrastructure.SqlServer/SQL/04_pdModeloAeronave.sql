USE AircraftControl

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'pdModeloAeronave'
)
DROP PROCEDURE dbo.pdModeloAeronave
GO
CREATE PROCEDURE dbo.pdModeloAeronave
    @Code VARCHAR(4),
    @AlternativeCode VARCHAR(4)
AS    
    DELETE FROM ModelosAeronaves
    WHERE @Code IS NOT NULL AND CODE = @Code OR 
    @AlternativeCode IS NOT NULL AND ALTERNATIVE_CODE = @AlternativeCode
GO