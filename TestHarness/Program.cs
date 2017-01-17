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
            TestDate();


        }

        static void TestOutput()
        {
            int myRosterSize;

            DRDRepository repo = new DRDRepository();
            var items = repo.ListPlayers(out myRosterSize, 3);

            Console.WriteLine(myRosterSize.ToString());
        }

        static void TestOutput1()
        {
            DRDRepository repo = new DRDRepository();
            var items = repo.ListMajors(1);

            foreach (var item in items)
            {
                Console.WriteLine(item.Player);
            }


        }

        static void GetPlayer()
        {
            DRDRepository repo = new DRDRepository();
            var items = repo.GetPlayer(1);

            Console.WriteLine(items.HasLostRookieStatus);
        }

        static void TestDate()
        {
            DRDRepository repo = new DRDRepository();
            DateTime lastDate;
            var items = repo.GetLastUpdatedDate(out lastDate);

            Console.WriteLine(items.ToString());


        }
    }
}
