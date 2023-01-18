using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using ESH_ApiWithDapper.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_ApiWithDapper.ApplicationService.RegisterMap
{
   public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(c =>
            {
                c.AddMap(new AlunoMap());
                c.AddMap(new TurmaMap());
                c.ForDommel();

            });
        }
    }
}
