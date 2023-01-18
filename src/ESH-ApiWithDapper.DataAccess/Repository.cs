using ESH_ApiWithDapper.DataAccess.Repositories;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DataAccess
{
    public class Repository : IRepository
    {
        private readonly string _conn;
        public Repository()
        {
            _conn = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ApiWithDapperDB;Integrated Security=True";
        }

        private IAlunoRepository _alunos;
        private ITurmaRepository _turmas;

        public IAlunoRepository Alunos => _alunos ?? (_alunos = new AlunoRepository(_conn));

        public ITurmaRepository Turmas => _turmas ?? (_turmas = new TurmaRepository(_conn));
    }
}
