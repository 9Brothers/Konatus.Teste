using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Interfaces.Repositories.SqlServer;
using Konatus.Teste.Domain.Interfaces.Services;

namespace Konatus.Teste.Domain.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly ISqlServerRepository<T> _sqlServerRepository;

        public Service(ISqlServerRepository<T> sqlServerRepository)
        {
            _sqlServerRepository = sqlServerRepository;
        }

        public async Task<string> Add(T entity)
        {
            return await _sqlServerRepository.Add(entity);
        }

        public async Task<int> Delete(T entity)
        {
            return await _sqlServerRepository.Delete(entity);
        }

        public async Task<IEnumerable<T>> Get(T entity, int page = 0)
        {
            return await _sqlServerRepository.Get(entity, page);
        }

        public async Task<int> Update(T entity)
        {
            return await _sqlServerRepository.Update(entity);
        }
    }
}