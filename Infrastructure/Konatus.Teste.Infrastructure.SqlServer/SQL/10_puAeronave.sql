USE AircraftControl

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'puAeronave'
)
DROP PROCEDURE dbo.puAeronave
GO
CREATE PROCEDURE dbo.puAeronave
    @Prefix VARCHAR(6),
    @MaxDepartureWeight DECIMAL(10, 3),
    @MaxLandingWeight  DECIMAL(10, 3),
    @Active BIT,
    @AircraftModel VARCHAR(4)
AS        
    UPDATE Aeronaves
    SET
        MAX_DEPARTURE_WEIGHT = @MaxDepartureWeight,
        MAX_LANDING_WEIGHT = @MaxLandingWeight,
        ACTIVE = @Active,
        AIRCRAFT_MODEL = @AircraftModel
    WHERE PREFIX = @Prefix
    GO
GO