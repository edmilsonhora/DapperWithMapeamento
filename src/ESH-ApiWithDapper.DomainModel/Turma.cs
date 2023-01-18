using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DomainModel
{
   public class Turma:EntityBase
    {
        public string Nome { get; set; }
        public byte LimiteAlunos { get; set; }
        public byte AlunosNaTurma { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio("Nome", Nome);
            CampoNumericoMaiorQueZero("Limite Alunos", LimiteAlunos);
            base.Validar();
        }

        public void AddAluno()
        {
            if (AlunosNaTurma < LimiteAlunos)
            {
                AlunosNaTurma++;
            }
            else
            {
                throw new ApplicationException($"A quantidade limite de alunos para a turma foi atingida.{Environment.NewLine}");
            }
        }

        public void RemoveAluno()
        {
            if (AlunosNaTurma > 0)
                AlunosNaTurma--;
        }
    }

    public interface ITurmaRepository : IRepositoryBase<Turma> { }
}
