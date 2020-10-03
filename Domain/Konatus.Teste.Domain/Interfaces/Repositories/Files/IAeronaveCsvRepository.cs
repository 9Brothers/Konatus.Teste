using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;

namespace Konatus.Teste.Domain.Interfaces.Repositories.Files
{
    public interface IAeronaveCsvRepository
    {
        Task<(List<Aeronave> aircrafts, List<ModeloAeronave> aircraftsModels)> Convert(Stream stream);
    }
}