using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierplanung
{
    class main
    {
        static void Main(string[] args)
        {
            Controller verwalter = new Controller();

            verwalter.UnitTestHierachie();
        }
    }
}
