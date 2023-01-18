using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService.Views
{
    public class AlunoView : ViewBase
    {       
        public string Nome { get; set; }
        public string RA { get; set; }
        public int TurmaId { get; set; }
        public string TurmaNome { get; set; }
    }

    public interface IAlunoFacade : IFacadeBase<AlunoView> {

        List<AlunoView> ObterPaginado(int pageIndex, int pageSize);
    }
}
