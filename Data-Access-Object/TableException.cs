using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Object
{
    internal class TableException : Exception
    {
        public string Code { get; }

        public TableException(string code, string message, Exception? exceptionInterne = null) : base(message, exceptionInterne)
        {
            Code = code;
        }
    }
}
