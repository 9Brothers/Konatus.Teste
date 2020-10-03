USE AircraftControl

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'psAeronavesAtivas'
)
DROP PROCEDURE dbo.psAeronavesAtivas
GO
CREATE PROCEDURE dbo.psAeronavesAtivas    
AS
    SELECT 
        PREFIX AS Prefix,
        MAX_DEPARTURE_WEIGHT AS MaxDepartureWeight,
        MAX_LANDING_WEIGHT AS MaxLandingWeight,
        ACTIVE AS Active,
        AIRCRAFT_MODEL AS AircraftModel
    FROM dbo.Aeronaves (NOLOCK)
    WHERE ACTIVE = 1        
GO