using System.Collections.Generic;
using System.Threading.Tasks;

namespace Konatus.Teste.Application.Interfaces
{
    public interface IAppService<T> where T : class
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> Get(T entity, int page = 0);
    }
}