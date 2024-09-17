using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGA.Common.Exceptions
{
    public class EmptyBoxException: Exception
    {
        public EmptyBoxException(): base("Shuffle machine has no cards in the box") { }
    }
}
