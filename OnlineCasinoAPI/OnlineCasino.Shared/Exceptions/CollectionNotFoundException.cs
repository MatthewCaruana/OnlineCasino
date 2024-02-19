using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Shared.Exceptions
{
    public class CollectionNotFoundException : Exception
    {
        public CollectionNotFoundException()
        {
        }

        public CollectionNotFoundException(string message)
            : base(message)
        {
        }

        public CollectionNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
