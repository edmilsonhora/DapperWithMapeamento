using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.DomainModel
{
   public abstract class EntityBase
    {
        protected StringBuilder regraQuebras = new StringBuilder();

        public int Id { get; set; }

        public virtual void Validar()
        {
            if (regraQuebras.Length > 0)
                throw new ApplicationException(regraQuebras.ToString());

        }

        protected void CampoTextoObrigatorio(string nomeCampo, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                regraQuebras.Append($"O campo {nomeCampo} é obrigatório.{Environment.NewLine}");
        }

        protected void CampoIdObrigatorio(string nomeCampo, int id)
        {
            if (id < 1)
                regraQuebras.Append($"O campo {nomeCampo} é obrigatório.{Environment.NewLine}");
        }

        protected void CampoNumericoMaiorQueZero(string nomeCampo, int valor)
        {
            if (valor < 1)
                regraQuebras.Append($"O campo {nomeCampo} deve ser maior que zero.{Environment.NewLine}");
        }
    }

    public interface IRepositoryBase<T> where T : EntityBase
    {
        void Salvar(T entity);
        void Excluir(T entity);
        List<T> ObterTodos();
        T ObterPor(int id);       
    }

    public interface IRepository
    {
        IAlunoRepository Alunos { get; }
        ITurmaRepository Turmas { get; }
       
    }
}
