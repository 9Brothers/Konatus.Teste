using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Repositories.SqlServer;
using Konatus.Teste.Domain.Interfaces.Services;

namespace Konatus.Teste.Domain.Services
{
    public class AeronaveService : IAeronaveService
    {
        private readonly IAeronaveSqlServerRepository _aeronaveSqlServerRepository;

        public AeronaveService(IAeronaveSqlServerRepository aeronaveSqlServerRepository)
        {
            _aeronaveSqlServerRepository = aeronaveSqlServerRepository;
        }

        public async Task<Aeronave> Add(Aeronave entity)
        {
            await _aeronaveSqlServerRepository.Add(entity);

            return entity;
        }

        public async Task Delete(Aeronave entity)
        {
            await _aeronaveSqlServerRepository.Delete(entity);
        }

        public async Task<IEnumerable<Aeronave>> Get(Aeronave aeronave, int page = 0)
        {
            return await _aeronaveSqlServerRepository.Get(aeronave, page);
        }

        public async Task<IEnumerable<Aeronave>> GetActives()
        {
            return await _aeronaveSqlServerRepository.GetActives();
        }

        public async Task Update(Aeronave entity)
        {
            await _aeronaveSqlServerRepository.Update(entity);
        }
    }
}