using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionDependances
{
    internal class Injecter : Attribute
    {
        public string NomParametre { get; }
        public Type Type { get; }

        public Injecter(string nomParametre, Type type)
        {
            NomParametre = nomParametre;   
            Type = type;
        }
    }
}
