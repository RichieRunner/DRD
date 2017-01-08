using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Richie.DRD.Models;
using Richie.DRD.Repository;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            TestOutput();


        }

        static void TestOutput()
        {
            int myRosterSize;

            DRDRepository repo = new DRDRepository();
            var items = repo.ListPlayers(out myRosterSize, 3);

            Console.WriteLine(myRosterSize.ToString());
        }

    }
}
