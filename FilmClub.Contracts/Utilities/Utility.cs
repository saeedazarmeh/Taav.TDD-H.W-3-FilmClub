using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Contracts.Utilities
{
    public class Utility
    {
        public static bool IsCheckLength(string str, int length)
        {
            return str.Length <= length;
        }
    }
}
