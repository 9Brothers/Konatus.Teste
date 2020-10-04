USE AircraftControl

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'psAeronaves'
)
DROP PROCEDURE dbo.psAeronaves
GO
CREATE PROCEDURE dbo.psAeronaves
    @Prefix VARCHAR(6),
    @Page INT = 0
AS    
    SELECT 
        PREFIX AS Prefix,
        MAX_DEPARTURE_WEIGHT AS MaxDepartureWeight,
        MAX_LANDING_WEIGHT AS MaxLandingWeight,
        ACTIVE AS Active,
        AIRCRAFT_MODEL AS AircraftModel
    FROM dbo.Aeronaves (NOLOCK)
    WHERE PREFIX LIKE @Prefix + '%'
    ORDER BY PREFIX
    OFFSET 50 * @Page ROWS
    FETCH NEXT 50 ROWS ONLY
GO