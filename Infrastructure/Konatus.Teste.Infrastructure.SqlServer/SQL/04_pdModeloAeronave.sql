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
    WHERE CODE = @Code OR ALTERNATIVE_CODE = @AlternativeCode    
GO