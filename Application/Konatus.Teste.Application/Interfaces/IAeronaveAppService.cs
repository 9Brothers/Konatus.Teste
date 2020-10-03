using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;

namespace Konatus.Teste.Application.Interfaces
{
    public interface IAeronaveAppService : IAppService<Aeronave>
    {
         Task<IEnumerable<Aeronave>> GetActives();
    }
}