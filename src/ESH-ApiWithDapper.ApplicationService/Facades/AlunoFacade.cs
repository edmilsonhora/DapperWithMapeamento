using ESH_ApiWithDapper.ApplicationService.Conversores;
using ESH_ApiWithDapper.ApplicationService.Views;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService.Facades
{
    internal class AlunoFacade : IAlunoFacade
    {
        private readonly IRepository _repository;
        public AlunoFacade(IRepository repository)
        {
            this._repository = repository;
        }

        public void Excluir(int id)
        {
            var obj = _repository.Alunos.ObterPor(id);
            if (obj != null)
            {
                obj.Turma = _repository.Turmas.ObterPor(obj.TurmaId);
                obj.TurmaRemoveAluno();
                _repository.Alunos.Excluir(obj);
                _repository.Turmas.Salvar(obj.Turma);
            }
        }

        public List<AlunoView> ObterPaginado(int pageIndex, int pageSize)
        {
            return _repository.Alunos.ObterPaginado(pageIndex, pageSize).ConvertToView();
        }

        public AlunoView ObterPor(int id)
        {
            return _repository.Alunos.ObterPor(id).ConvertToView();
        }

        public List<AlunoView> ObterTodos()
        {
            return _repository.Alunos.ObterAlunosComTurma().ConvertToView();
        }

        public void Salvar(AlunoView view)
        {
            var obj = view.Id == 0 ? new Aluno() : _repository.Alunos.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.RA = view.RA;
            obj.TurmaId = view.TurmaId;
            obj.Turma = _repository.Turmas.ObterPor(view.TurmaId);
            obj.TurmaAddAluno();
            obj.Validar();

            _repository.Alunos.Salvar(obj);
            _repository.Turmas.Salvar(obj.Turma);
        }

    }
}
