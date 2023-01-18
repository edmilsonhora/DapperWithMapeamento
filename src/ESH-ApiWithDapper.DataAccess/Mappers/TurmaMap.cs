using Dapper.FluentMap.Dommel.Mapping;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DataAccess.Mappers
{
   public class TurmaMap : DommelEntityMap<Turma>
    {
        public TurmaMap()
        {
            ToTable("Turmas");
            Map(p => p.Id).ToColumn("Id").IsKey();
            Map(p => p.Nome).ToColumn("Nome");            
            Map(p => p.LimiteAlunos).ToColumn("LimiteAlunos");
            Map(p => p.AlunosNaTurma).ToColumn("AlunosNaTurma");
        }
    }
}
