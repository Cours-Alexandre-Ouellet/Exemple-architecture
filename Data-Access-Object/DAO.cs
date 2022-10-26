using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Object
{
    internal abstract class DAO<T>
    {

        public abstract T? Selectionner(int identifiant);

        public abstract T[] SelectionnerTout();

        public abstract void Sauvegarder(T element);

        public abstract void Supprimer(T element);

    }
}
