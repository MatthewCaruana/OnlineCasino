using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCasino.Shared.Services
{
    public static class EnumUtils
    {
        public static T ParseToEnum<T>(int value)
        {
            return (T)(object)value;
        }
    }
}
