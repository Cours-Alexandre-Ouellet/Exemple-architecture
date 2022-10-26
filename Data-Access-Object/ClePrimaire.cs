using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Object
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class ClePrimaire : Attribute
    {
        
    }
}
