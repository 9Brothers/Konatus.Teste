IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'psModelosAeronaves'
)
DROP PROCEDURE dbo.psModelosAeronaves
GO
CREATE PROCEDURE dbo.psModelosAeronaves
    @Code VARCHAR(4),
    @AlternativeCode VARCHAR(4),
    @Page INT = 0
AS
    
    SELECT
        CODE, 
        ALTERNATIVE_CODE,
        MAX_DEPARTURE_WEIGHT,
        MAX_LANDING_WEIGHT
    FROM dbo.ModelosAeronaves
    WHERE CODE LIKE @Code + '%' OR ALTERNATIVE_CODE = @AlternativeCode + '%'
    ORDER BY CODE
    OFFSET 50 * @Page ROWS
    FETCH NEXT 50 ROWS ONLY
GO