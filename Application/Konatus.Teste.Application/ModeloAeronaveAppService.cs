using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Application.Interfaces;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Services;

namespace Konatus.Teste.Application
{
    public class ModeloAeronaveAppService : IModeloAeronaveAppService
    {
        private readonly IModeloAeronaveService _modeloAeronaveService;

        public ModeloAeronaveAppService(IModeloAeronaveService modeloAeronaveService)
        {
            _modeloAeronaveService = modeloAeronaveService;
        }

        public async Task<ModeloAeronave> Add(ModeloAeronave entity)
        {
            if (string.IsNullOrEmpty(entity?.Code?.Trim()) || entity.Code.Length == 0) throw new Exception("Informe o CODE.");
            else if (entity.Code.Length > 4) throw new Exception("Informe um CODE com no máximo 4 caracteres.");
            else if (string.IsNullOrEmpty(entity?.AlternativeCode?.Trim()) || entity.AlternativeCode.Length == 0) throw new Exception("Informe o ALTERNATIVE_CODE.");
            else if (entity.AlternativeCode.Length > 4) throw new Exception("Informe um ALTERNATIVE_CODE com no máximo 4 caracteres.");
            else if (entity.MaxDepartureWeight < 0) throw new Exception("Informe um MAX_DEPARTURE_WEIGHT maior que zero.");
            else if (entity.MaxLandingWeight < 0) throw new Exception("Informe um MAX_LANDING_WEIGHT maior que zero.");

            return await _modeloAeronaveService.Add(entity);
        }

        public async Task Delete(ModeloAeronave entity)
        {
            if (string.IsNullOrEmpty(entity?.Code?.Trim()) && string.IsNullOrEmpty(entity?.AlternativeCode?.Trim())) throw new Exception("Informe o CODE ou o ALTERNATIVE_CODE.");
            else if (entity?.Code?.Length > 4) throw new Exception("Informe um CODE com no máximo 4 caracteres.");            
            else if (entity?.AlternativeCode?.Length > 4) throw new Exception("Informe um ALTERNATIVE_CODE com no máximo 4 caracteres.");

            await _modeloAeronaveService.Delete(entity);
        }

        public async Task<IEnumerable<ModeloAeronave>> Get(ModeloAeronave entity, int page = 0)
        {
            if (string.IsNullOrEmpty(entity?.Code?.Trim()) && string.IsNullOrEmpty(entity?.AlternativeCode?.Trim())) throw new Exception("Informe o CODE ou o ALTERNATIVE_CODE.");
            else if (entity?.Code?.Length > 4) throw new Exception("Informe um CODE com no máximo 4 caracteres.");            
            else if (entity?.AlternativeCode?.Length > 4) throw new Exception("Informe um ALTERNATIVE_CODE com no máximo 4 caracteres.");

            return await _modeloAeronaveService.Get(entity, page);
        }

        public async Task<IEnumerable<ModeloAeronave>> GetAll()
        {
            return await _modeloAeronaveService.GetAll();
        }

        public async Task Update(ModeloAeronave entity)
        {
            if (string.IsNullOrEmpty(entity?.Code?.Trim()) || entity.Code.Length == 0) throw new Exception("Informe o CODE.");
            else if (entity.Code.Length > 4) throw new Exception("Informe um CODE com no máximo 4 caracteres.");
            else if (string.IsNullOrEmpty(entity?.AlternativeCode?.Trim()) || entity.AlternativeCode.Length == 0) throw new Exception("Informe o ALTERNATIVE_CODE.");
            else if (!string.IsNullOrEmpty(entity?.AlternativeCode?.Trim()) && entity.AlternativeCode.Length > 4) throw new Exception("Informe um ALTERNATIVE_CODE com no máximo 4 caracteres.");
            else if (entity.MaxDepartureWeight < 0) throw new Exception("Informe um MAX_DEPARTURE_WEIGHT maior que zero.");
            else if (entity.MaxLandingWeight < 0) throw new Exception("Informe um MAX_LANDING_WEIGHT maior que zero.");
            
            await _modeloAeronaveService.Update(entity);
        }
    }
}