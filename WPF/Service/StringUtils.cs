using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Interface;

namespace WPF.Service
{
    internal class StringUtils : IStringUtils
    {
        public int? ConvertToInteger(string str)
        {
            if (!int.TryParse(str, out int val))
            {
                return null;
            }
            return val;
        }
    }
}
