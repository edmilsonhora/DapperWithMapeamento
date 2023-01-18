using ESH_ApiWithDapper.ApplicationService.Views;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService.Conversores
{
   public static class TurmaConversor
    {
        public static List<TurmaView> ConvertToView(this List<Turma> list)
        {
            var novaLista = new List<TurmaView>();

            foreach (var item in list)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;

        }

        public static TurmaView ConvertToView(this Turma item)
        {
            if (item == null) return new TurmaView();

            return new TurmaView
            {
                Id = item.Id,
                Nome = item.Nome,
                LimiteAlunos = item.LimiteAlunos,
                AlunosNaTurma = item.AlunosNaTurma
                
            };
        }
    }
}
