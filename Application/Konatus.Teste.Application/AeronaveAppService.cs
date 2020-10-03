using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Application.Interfaces;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Services;

namespace Konatus.Teste.Application
{
    public class AeronaveAppService : IAeronaveAppService
    {
        private readonly IAeronaveService _aeronaveService;

        public AeronaveAppService(IAeronaveService aeronaveService)
        {
            _aeronaveService = aeronaveService;
        }

        public async Task<Aeronave> Add(Aeronave entity)
        {
            if (string.IsNullOrEmpty(entity?.Prefix?.Trim()) || entity.Prefix.Length == 0) throw new Exception("Informe o PREFIX.");
            else if (entity.Prefix.Length > 6) throw new Exception("Informe um PREFIX com no máximo 6 caracteres");
            else if (string.IsNullOrEmpty(entity?.AircraftModel?.Trim()) || entity.AircraftModel.Length == 0) throw new Exception("Informe o AIRCRAFT_MODEL.");
            else if (entity.AircraftModel.Length > 4) throw new Exception("Informe um AIRCRAFT_MODEL com no máximo 4 caracteres");
            else if (entity.MaxDepartureWeight < 0) throw new Exception("Informe um MAX_DEPARTURE_WEIGHT maior que zero.");
            else if (entity.MaxLandingWeight < 0) throw new Exception("Informe um MAX_LANDING_WEIGHT maior que zero.");

            return await _aeronaveService.Add(entity);
        }

        public async Task Delete(Aeronave entity)
        {
            if (string.IsNullOrEmpty(entity?.Prefix?.Trim()) || entity.Prefix.Length == 0) throw new Exception("Informe o PREFIX.");
            else if (entity.Prefix.Length > 6) throw new Exception("Informe um PREFIX com no máximo 6 caracteres");

            await _aeronaveService.Delete(entity);
        }

        public async Task<IEnumerable<Aeronave>> Get(Aeronave entity, int page = 0)
        {
            if (string.IsNullOrEmpty(entity?.Prefix?.Trim()) || entity.Prefix.Length == 0) throw new Exception("Informe o PREFIX.");
            else if (entity.Prefix.Length > 6) throw new Exception("Informe um PREFIX com no máximo 6 caracteres");

            return await _aeronaveService.Get(entity, page);
        }

        public async Task<IEnumerable<Aeronave>> GetActives()
        {
            return await _aeronaveService.GetActives();
        }

        public async Task Update(Aeronave entity)
        {
            if (string.IsNullOrEmpty(entity?.AircraftModel?.Trim()) || entity.AircraftModel.Length == 0) throw new Exception("Informe o AIRCRAFT_MODEL.");
            else if (entity.AircraftModel.Length > 4) throw new Exception("Informe um AIRCRAFT_MODEL com no máximo 4 caracteres");
            else if (entity.MaxDepartureWeight < 0) throw new Exception("Informe um MAX_DEPARTURE_WEIGHT maior que zero.");
            else if (entity.MaxLandingWeight < 0) throw new Exception("Informe um MAX_LANDING_WEIGHT maior que zero.");

            await _aeronaveService.Update(entity);
        }
    }
}