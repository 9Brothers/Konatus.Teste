IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'psTodosModelosAeronaves'
)
DROP PROCEDURE dbo.psTodosModelosAeronaves
GO
CREATE PROCEDURE dbo.psTodosModelosAeronaves    
AS
    SELECT
        CODE AS Code, 
        ALTERNATIVE_CODE AS AlternativeCode,
        MAX_DEPARTURE_WEIGHT AS MaxDepartureWeight,
        MAX_LANDING_WEIGHT AS MaxLandingWeight
    FROM dbo.ModelosAeronaves (NOLOCK)
GO