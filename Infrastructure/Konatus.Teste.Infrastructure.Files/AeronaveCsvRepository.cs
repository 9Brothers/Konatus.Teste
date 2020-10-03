using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Repositories.Files;

namespace Konatus.Teste.Infrastructure.Files
{
    public class AeronaveCsvRepository : IAeronaveCsvRepository
    {
        public async Task<(List<Aeronave> aircrafts, List<ModeloAeronave> aircraftsModels)> Convert(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var headers = new Dictionary<string, int>();
                var aeronaves = new List<Aeronave>();
                var modelosAeronaves = new List<ModeloAeronave>();
                var findCode = new Dictionary<string, bool>();

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();

                    if (headers.Count == 0)
                    {
                        var keys = line.Split('\t');

                        for (int i = 0; i < keys.Length; i++)
                        {
                            headers.Add(keys[i], i);
                        }

                        continue;
                    }

                    var aircraftData = line.Split('\t');

                    var aeronave = new Aeronave();
                    int indexOf;

                    if (headers.TryGetValue("PREFIX_AIRCRAFT", out indexOf))
                    {
                        aeronave.Prefix = aircraftData[indexOf];
                    }

                    if (headers.TryGetValue("MAX_DEPARTURE_WEIGHT_AIRCRAFT", out indexOf))
                    {
                        aeronave.MaxDepartureWeight = System.Convert.ToDecimal(aircraftData[indexOf]);
                    }

                    if (headers.TryGetValue("MAX_LANDING_WEIGHT_AIRCRAFT", out indexOf))
                    {
                        aeronave.MaxLandingWeight = System.Convert.ToDecimal(aircraftData[indexOf]);
                    }

                    if (headers.TryGetValue("ACTIVE_AIRCRAFT", out indexOf))
                    {
                        var active = System.Convert.ToInt32(aircraftData[indexOf]);

                        aeronave.Active = System.Convert.ToBoolean(active);
                    }

                    if (headers.TryGetValue("CODE_AIRCRAFT_MODEL", out indexOf))
                    {
                        aeronave.AircraftModel = aircraftData[indexOf];
                    }

                    aeronaves.Add(aeronave);

                    var modeloAeronave = new ModeloAeronave();

                    if (headers.TryGetValue("CODE_AIRCRAFT_MODEL", out indexOf))
                    {
                        modeloAeronave.Code = aircraftData[indexOf];
                        
                        var exists = false;

                        if (findCode.TryGetValue(modeloAeronave.Code, out exists))
                            continue;

                        findCode.Add(modeloAeronave.Code, true);
                    }

                    if (headers.TryGetValue("ALTERNATIVE_AIRCRAFT_MODEL", out indexOf))
                    {
                        modeloAeronave.AlternativeCode = aircraftData[indexOf];
                    }

                    if (headers.TryGetValue("MAX_DEPARTURE_WEIGHT_AIRCRAFT_MODEL", out indexOf))
                    {
                        modeloAeronave.MaxDepartureWeight = System.Convert.ToDecimal(aircraftData[indexOf]);
                    }

                    if (headers.TryGetValue("MAX_LANDING_WEIGHT_AIRCRAFT_MODEL", out indexOf))
                    {
                        modeloAeronave.MaxLandingWeight = System.Convert.ToDecimal(aircraftData[indexOf]);
                    }

                    modelosAeronaves.Add(modeloAeronave);
                }

                return (aircrafts: aeronaves, aircraftsModels: modelosAeronaves);
            }
        }
    }
}