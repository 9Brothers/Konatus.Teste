USE AircraftControl

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'piModeloAeronave'
)
DROP PROCEDURE dbo.piModeloAeronave
GO

CREATE PROCEDURE dbo.piModeloAeronave
    @Code VARCHAR(4),
    @AlternativeCode VARCHAR(4),
    @MaxDepartureWeight DECIMAL(7,3),
    @MaxLandingWeight DECIMAL(7,3)
AS    
    INSERT INTO ModelosAeronaves
    (
        CODE, ALTERNATIVE_CODE, MAX_DEPARTURE_WEIGHT, MAX_LANDING_WEIGHT
    )
    VALUES
    (
        @Code, @AlternativeCode, @MaxDepartureWeight, @MaxLandingWeight
    )    
    GO
GO