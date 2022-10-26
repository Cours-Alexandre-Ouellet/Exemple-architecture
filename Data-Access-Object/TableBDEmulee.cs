using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace Data_Access_Object
{
    internal class TableBDEmulee<T> where T : class
    {
        private List<T> table;
        private int dernierId;

        public TableBDEmulee(List<T> donneesInitiales)
        {
            if(donneesInitiales is not null)
            {
                table = donneesInitiales;
            }
            else
            {
                table = new List<T>();
            }

            dernierId = 1;
        }

        public StatutBD InsertInto(T objet)
        {
            try
            {
                SetIdentifiant(objet, dernierId);
                table.Add(Cloner(objet));
                dernierId++;

                return new StatutBD("200", "Objet correctement insere");
            }
            catch(TableException ex)
            {
                return new StatutBD(ex.Code, ex.Message);
            }
        }

        public StatutBD Update(T objet)
        {
            try
            {
                if(SelectById(GetIdentifiant(objet), false) is not T reference)
                {
                    throw new TableException("500", "Impossible de trouver l'objet dans la BD.");
                }

                CopierDans(objet, reference);

                return new StatutBD("200", "Objet correctement modifie");
            }
            catch(TableException ex)
            {
                return new StatutBD(ex.Code, ex.Message);
            }
        }

        public StatutBD Delete(T objet)
        {
            try
            {
                if(SelectById(GetIdentifiant(objet), false) is not T reference)
                {
                    throw new TableException("500", "Impossible de trouver l'objet dans la BD.");
                }

                table.Remove(reference);

                return new StatutBD("200", "Objet correctement supprime");
            }
            catch(TableException ex)
            {
                return new StatutBD(ex.Code, ex.Message);
            }
        }

        public T[] SelectAll()
        {
            T[] donnees = new T[table.Count];

            for(int i = 0; i < table.Count; i++)
            {
                donnees[i] = Cloner(table[i]);
            }

            return donnees;
        }

        public T? SelectById(int identifiant, bool cloner = true)
        {
            foreach(T objet in table)
            {
                int id = GetIdentifiant(objet);
                
                if(id == identifiant)
                {
                    return cloner ? Cloner(objet) : objet;
                }
            }

            return null;
        }

        private static int GetIdentifiant(T objet)
        {
            try
            {
                if(objet.GetType().GetProperties().Where(
                    p => p.GetCustomAttribute<ClePrimaire>() is not null).First() is not PropertyInfo proprieteClePrimaire)
                {
                    throw new Exception("Pas de propriété avec un clé primaire.");
                }

                if(proprieteClePrimaire?.GetValue(objet) is not object clePrimaire)
                {
                    throw new Exception("Pas de propriété avec un clé primaire.");
                }

                return Convert.ToInt32(clePrimaire);
            }
            catch(Exception ex)
            {

                throw new TableException("500", $"Impossible de récupérer la clé primaire du type {objet.GetType()}.", ex);
            }
        }

        private static void SetIdentifiant(T objet, int id)
        {
            try
            {
                if(objet.GetType().GetProperties().Where(
                    p => p.GetCustomAttribute<ClePrimaire>() is not null).First() is not PropertyInfo proprieteClePrimaire)
                {
                    throw new Exception("Pas de propriété avec un clé primaire.");
                }

                proprieteClePrimaire?.SetValue(objet, id);
            }
            catch(Exception ex)
            {
                throw new TableException("500", $"Impossible de modifier la clé primaire du type {objet.GetType()}.", ex);
            }
        }

        private static void CopierDans(T original, T copie)
        {
            try
            {
                PropertyInfo[] proprietes = original.GetType().GetProperties();

                foreach(PropertyInfo propriete in proprietes)
                {
                    propriete.SetValue(copie, propriete.GetValue(original));
                }

            }
            catch(Exception ex)
            {
                throw new TableException("500", $"Impossible de copier des objets du type {copie.GetType()}.", ex);
            }
        }

        private static T Cloner(T objet)
        {
            try
            {
                if(Activator.CreateInstance(objet.GetType()) is not T clone)
                {
                    throw new Exception("Erreur de clone d'objet.");
                }

                CopierDans(objet, clone);

                return clone;
            }
            catch(Exception ex)
            {
                throw new TableException("500", $"Impossible de copier l'objet du type {objet.GetType()}.", ex);
            }
        }
    }
}
