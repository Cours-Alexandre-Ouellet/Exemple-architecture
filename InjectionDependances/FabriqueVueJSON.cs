using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionDependances
{
    internal class FabriqueVueJSON : FabriqueVue
    {
        public override IVue Fabriquer(string nomVue)
        {
            return FabriquerInterne(nomVue, "JSON");
        }
    }
}
