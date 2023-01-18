using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService.Views
{
   public class TurmaView : ViewBase
    {
        public string Nome { get; set; }
        public byte LimiteAlunos { get; set; }
        public byte AlunosNaTurma { get; set; }
    }

    public interface ITurmaFacade : IFacadeBase<TurmaView> { }
}
