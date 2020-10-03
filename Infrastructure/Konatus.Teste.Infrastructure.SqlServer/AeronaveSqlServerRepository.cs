using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Repositories.SqlServer;
using Microsoft.Extensions.Configuration;

namespace Konatus.Teste.Infrastructure.SqlServer
{
    public class AeronaveSqlServerRepository : SqlServerRepository<Aeronave>, IAeronaveSqlServerRepository
    {
        public AeronaveSqlServerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<string> Add(Aeronave entity)
        {
            Params = entity;
            ProcedureName = "piAeronave";

            return await base.Add(entity);
        }

        public override async Task<int> Delete(Aeronave entity)
        {
            Params = entity;
            ProcedureName = "pdAeronave";

            return await base.Delete(entity);
        }

        public override async Task<IEnumerable<Aeronave>> Get(Aeronave entity, int page = 0)
        {
            Params = new {
                entity.Prefix,
                Page = page
            };
            ProcedureName = "psAeronaves";

            return await base.Get(entity, page);
        }

        public async Task<IEnumerable<Aeronave>> GetActives()
        {
            Params = null;
            ProcedureName = "psAeronavesAtivas";

            return await base.Get(null, 0);
        }

        public override async Task<int> Update(Aeronave entity)
        {
            Params = entity;
            ProcedureName = "puAeronave";

            return await base.Update(entity);
        }
    }
}