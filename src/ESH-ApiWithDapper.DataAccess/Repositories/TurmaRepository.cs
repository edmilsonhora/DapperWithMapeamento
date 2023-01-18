using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DataAccess.Repositories
{
    internal class TurmaRepository : AbstractRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(string conn) : base(conn)
        {
        }
    }
}
