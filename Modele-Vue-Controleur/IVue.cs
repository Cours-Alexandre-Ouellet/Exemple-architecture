using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele_Vue_Controleur
{
    internal interface IVue
    {
        public string Rendre(object contexte);

    }
}
