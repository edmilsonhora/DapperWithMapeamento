using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DomainModel
{
   public class Aluno:EntityBase
    {       
        public string Nome { get; set; }
        public string RA { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio("Nome", Nome);
            CampoTextoObrigatorio("RA", RA);
            CampoIdObrigatorio("TurmaId", TurmaId);
            base.Validar();            
        }

        public void TurmaAddAluno()
        {
            if (Id.Equals(0))
                Turma.AddAluno();
        }

        public void TurmaRemoveAluno()
        {
            Turma.RemoveAluno();
        }

        
    }

    public interface IAlunoRepository: IRepositoryBase<Aluno> 
    {

        List<Aluno> ObterAlunosComTurma();
        List<Aluno> ObterPaginado(int pageIndex, int pageSize);

    }
}
