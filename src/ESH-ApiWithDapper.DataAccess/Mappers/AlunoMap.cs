using Dapper.FluentMap.Dommel.Mapping;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DataAccess.Mappers
{
   public class AlunoMap : DommelEntityMap<Aluno>
    {
        public AlunoMap()
        {
            ToTable("Alunos");
            Map(p => p.Id).ToColumn("Id").IsKey();
            Map(p => p.Nome).ToColumn("Nome");
            Map(p => p.RA).ToColumn("Ra");
            Map(p => p.TurmaId).ToColumn("TurmaId");            
        }
    }
}
