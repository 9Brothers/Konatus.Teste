using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;

namespace Konatus.Teste.Domain.Interfaces.Services
{
    public interface IAeronaveService : IService<Aeronave>
    {
        Task<IEnumerable<Aeronave>> GetActives();
    }
}