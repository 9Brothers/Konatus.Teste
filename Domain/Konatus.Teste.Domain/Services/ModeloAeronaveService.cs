using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Repositories.SqlServer;
using Konatus.Teste.Domain.Interfaces.Services;

namespace Konatus.Teste.Domain.Services
{
    public class ModeloAeronaveService : IModeloAeronaveService
    {
        private readonly IModeloAeronaveSqlServerRepository _modeloAeronaveSqlServerRepository;

        public ModeloAeronaveService(IModeloAeronaveSqlServerRepository modeloAeronaveSqlServerRepository)
        {
            _modeloAeronaveSqlServerRepository = modeloAeronaveSqlServerRepository;
        }

        public async Task<ModeloAeronave> Add(ModeloAeronave entity)
        {
            await _modeloAeronaveSqlServerRepository.Add(entity);
            
            return entity;
        }

        public async Task Delete(ModeloAeronave entity)
        {
            await _modeloAeronaveSqlServerRepository.Delete(entity);            
        }

        public async Task<IEnumerable<ModeloAeronave>> Get(ModeloAeronave entity, int page = 0)
        {
            return await _modeloAeronaveSqlServerRepository.Get(entity, page);
        }

        public async Task<IEnumerable<ModeloAeronave>> GetAll()
        {
            return await _modeloAeronaveSqlServerRepository.GetAll();
        }

        public async Task Update(ModeloAeronave entity)
        {
            await _modeloAeronaveSqlServerRepository.Update(entity);
        }
    }
}