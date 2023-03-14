using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public static class IntExtension
    {
        public static int Add(this int a, int b) {  // lezem awel parametre bnafs type lclasse
            return a + b; 
        }
    }
}
