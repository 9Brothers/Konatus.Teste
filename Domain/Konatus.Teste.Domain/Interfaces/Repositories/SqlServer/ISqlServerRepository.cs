using System.Collections.Generic;
using System.Threading.Tasks;

namespace Konatus.Teste.Domain.Interfaces.Repositories.SqlServer
{
    public interface ISqlServerRepository<T> where T : class
    {
        Task<string> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<IEnumerable<T>> Get(T entity, int page = 0);
    }
}