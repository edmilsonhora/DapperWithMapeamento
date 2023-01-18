using ESH_ApiWithDapper.ApplicationService.Conversores;
using ESH_ApiWithDapper.ApplicationService.Views;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService.Facades
{
    internal class TurmaFacade : ITurmaFacade
    {
        private readonly IRepository _repository;

        public TurmaFacade(IRepository repository)
        {
            this._repository = repository;
        }

        public void Excluir(int id)
        {
            var obj = _repository.Turmas.ObterPor(id);
            if(obj is not null)
            {
                _repository.Turmas.Excluir(obj);
            }
        }

        public TurmaView ObterPor(int id)
        {
            return _repository.Turmas.ObterPor(id).ConvertToView();
        }

        public List<TurmaView> ObterTodos()
        {
            return _repository.Turmas.ObterTodos().ConvertToView();
        }

        public void Salvar(TurmaView view)
        {
            var obj = view.Id == 0 ? new Turma() : _repository.Turmas.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.LimiteAlunos = view.LimiteAlunos;
            obj.Validar();

            _repository.Turmas.Salvar(obj);

        }
    }
}
