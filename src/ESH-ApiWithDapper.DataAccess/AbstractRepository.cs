using Dommel;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ESH_ApiWithDapper.DataAccess
{
    public abstract class AbstractRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly string ConnectionString;
        protected AbstractRepository(string conn)
        {
            ConnectionString = conn;
        }

        public void Excluir(T entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Delete(entity);
            }
        }

        public T ObterPor(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Get<T>(id);
            }
        }
       
        public List<T> ObterTodos()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<T>().ToList();
            }
        }

        public void Salvar(T entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                if (entity.Id == 0)
                {
                    db.Insert(entity);
                }
                else
                {
                    db.Update(entity);
                }
            }
        }        
    }
}
