IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'puModeloAeronave'
)
DROP PROCEDURE dbo.puModeloAeronave
GO
CREATE PROCEDURE dbo.puModeloAeronave
    @Code VARCHAR(4),
    @AlternativeCode VARCHAR(4),
    @MaxDepartureWeight DECIMAL(7,3),
    @MaxLandingWeight DECIMAL(7,3)
AS    
    UPDATE ModelosAeronaves
    SET        
        ALTERNATIVE_CODE = @AlternativeCode,
        MAX_DEPARTURE_WEIGHT = @MaxDepartureWeight,
        MAX_LANDING_WEIGHT = @MaxLandingWeight        
    WHERE CODE = @Code
    GO
GO