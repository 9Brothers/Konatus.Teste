using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Entities;
using Konatus.Teste.Domain.Interfaces.Repositories.SqlServer;
using Microsoft.Extensions.Configuration;

namespace Konatus.Teste.Infrastructure.SqlServer
{
    public class ModeloAeronaveSqlServerRepository : SqlServerRepository<ModeloAeronave>, IModeloAeronaveSqlServerRepository
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
            Params = new {
                entity.Code,
                entity.AlternativeCode
            };
            ProcedureName = "pdModeloAeronave";

            var affectedRows = await base.Update(entity);

            if (affectedRows <= 0) throw new Exception("Registro não removido");

            return affectedRows;
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

        public async Task<IEnumerable<ModeloAeronave>> GetAll()
        {
            ProcedureName = "psTodosModelosAeronaves";

            return await base.Get(null, 0);
        }

        public override async Task<int> Update(ModeloAeronave entity)
        {
            Params = entity;
            ProcedureName = "puModeloAeronave";

            var affectedRows = await base.Update(entity);

            if (affectedRows <= 0) throw new Exception("Registro não atualizado");

            return affectedRows;
        }
    }
}