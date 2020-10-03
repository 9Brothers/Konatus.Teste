USE AircraftControl

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'piAeronave'
)
DROP PROCEDURE dbo.piAeronave
GO
CREATE PROCEDURE dbo.piAeronave
    @Prefix VARCHAR(6),
    @MaxDepartureWeight DECIMAL(10,3),
    @MaxLandingWeight DECIMAL(10,3),
    @AircraftModel VARCHAR(4)
AS
    
    INSERT INTO Aeronaves
    (
        PREFIX, MAX_DEPARTURE_WEIGHT, MAX_LANDING_WEIGHT, ACTIVE, AIRCRAFT_MODEL
    )
    VALUES
    (
        @Prefix, @MaxDepartureWeight, @MaxLandingWeight, 0, @AircraftModel
    )
    GO

    SELECT SCOPE_IDENTITY()
GO