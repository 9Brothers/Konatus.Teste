using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;

namespace Konatus.Teste.Domain.Interfaces.Services
{
    public interface IModeloAeronaveService : IService<ModeloAeronave>
    {
        Task<IEnumerable<ModeloAeronave>> GetAll();
    }
}