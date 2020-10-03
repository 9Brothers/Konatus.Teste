using System.Collections.Generic;
using System.IO;

namespace Konatus.Teste.Domain.Interfaces.Repositories.Excel
{
    public interface IExcelRepository<T> where T : class
    {
        MemoryStream Export(IEnumerable<T> entities);
    }
}