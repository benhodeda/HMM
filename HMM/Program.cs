using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMM
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> cubesResults = File.ReadAllText(args[0]).Select(c => int.Parse(c.ToString()));
        }
    }
}
