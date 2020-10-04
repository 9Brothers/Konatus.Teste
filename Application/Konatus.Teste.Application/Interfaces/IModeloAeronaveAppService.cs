using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;

namespace Konatus.Teste.Application.Interfaces
{
    public interface IModeloAeronaveAppService : IAppService<ModeloAeronave>
    {
        Task<IEnumerable<ModeloAeronave>> GetAll();
    }
}