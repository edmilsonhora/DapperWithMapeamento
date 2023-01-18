using Dommel;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DataAccess.Repositories
{
    internal class AlunoRepository : AbstractRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(string conn) : base(conn)
        {
        }

        public List<Aluno> ObterAlunosComTurma()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<Aluno, Turma, Aluno>((aluno, turma) =>
                {
                    aluno.Turma = turma;
                    return aluno;
                }).OrderByDescending(p => p.Id).ToList();
            }
        }

        public List<Aluno> ObterPaginado(int pageIndex, int pageSize)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetPaged<Aluno>(pageIndex, pageSize).OrderByDescending(p => p.Id).ToList();                
            }
        }
    }
}
