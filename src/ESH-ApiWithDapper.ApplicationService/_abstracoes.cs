using ESH_ApiWithDapper.ApplicationService.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService
{
    public interface IFacadeBase<T> where T : ViewBase
    {
        void Salvar(T view);
        void Excluir(int id);
        List<T> ObterTodos();
        T ObterPor(int id); 
    }

    public interface IFacade
    {
        IAlunoFacade Alunos { get; }
        ITurmaFacade Turmas { get; }
    }
}
