using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;

namespace Konatus.Teste.Domain.Interfaces.Repositories.SqlServer
{
    public interface IModeloAeronaveSqlServerRepository : ISqlServerRepository<ModeloAeronave>
    {
        Task<IEnumerable<ModeloAeronave>> GetAll();
    }
}