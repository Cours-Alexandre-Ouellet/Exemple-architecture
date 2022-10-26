using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalisateurService
{
    internal class ServiceCalculAge : IService
    {
        public int CalculerAge(string ddn)
        {
            DateTime dtNaissance = DateTime.Parse(ddn);
            DateTime dtMaintenant = DateTime.Now;

            TimeSpan age = dtMaintenant - dtNaissance;
            return (int) Math.Floor(age.TotalDays / 365.25);
        }

    }
}
