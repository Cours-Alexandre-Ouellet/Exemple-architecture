using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Object
{
    internal struct StatutBD
    {
        public readonly string Code { get; }
        public readonly string Message { get; }

        public StatutBD(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
