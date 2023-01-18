using ESH_ApiWithDapper.ApplicationService.Facades;
using ESH_ApiWithDapper.ApplicationService.Views;
using ESH_ApiWithDapper.DataAccess;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService
{
    public class Facade : IFacade
    {
        private readonly IRepository _repository;
        public Facade()
        {
            _repository = new Repository();
        }

        private IAlunoFacade _alunos;
        private ITurmaFacade _turmas;

        public IAlunoFacade Alunos => _alunos ?? (_alunos = new AlunoFacade(_repository));

        public ITurmaFacade Turmas => _turmas ?? (_turmas = new TurmaFacade(_repository));
    }
}
