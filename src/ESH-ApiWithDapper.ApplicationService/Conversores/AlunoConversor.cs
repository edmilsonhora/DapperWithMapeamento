using ESH_ApiWithDapper.ApplicationService.Views;
using ESH_ApiWithDapper.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService.Conversores
{
    public static class AlunoConversor
    {
        public static List<AlunoView> ConvertToView(this List<Aluno> list)
        {
            var novaLista = new List<AlunoView>();

            foreach (var item in list)
            {
                novaLista.Add(item.ConvertToView());
            }


            return novaLista;

        }

        public static AlunoView ConvertToView(this Aluno item)
        {
            if (item == null) return new AlunoView();

            return new AlunoView
            {
                Id = item.Id,
                Nome = item.Nome,
                RA = item.RA,
                TurmaId = item.TurmaId,
                TurmaNome = item.Turma?.Nome
            };
        }
    }
}
