using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Konatus.Teste.Infrastructure.SqlServer
{
    public class ModeloAeronaveSqlServerRepository : SqlServerRepository<ModeloAeronave>
    {
        public ModeloAeronaveSqlServerRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<string> Add(ModeloAeronave entity)
        {
            Params = entity;
            ProcedureName = "piModeloAeronave";
            
            return await base.Add(entity);
        }

        public override async Task<int> Delete(ModeloAeronave entity)
        {
            Params = entity;
            ProcedureName = "pdModeloAeronave";

            return await base.Delete(entity);
        }

        public override async Task<IEnumerable<ModeloAeronave>> Get(ModeloAeronave entity, int page = 0)
        {
            Params = new {
                entity.Code,
                entity.AlternativeCode,
                Page = page
            };
            ProcedureName = "psModelosAeronaves";

            return await base.Get(entity, page);
        }
        
        public override async Task<int> Update(ModeloAeronave entity)
        {
            Params = entity;
            ProcedureName = "puModeloAeronave";

            return await base.Update(entity);
        }
    }
}