using System;

namespace EFCoreSample.Core.Main
{
    using Persistence.NativeSQLSample;

    class ProgramEntry
    {
        static void Main(string[] args)
        {
            var dao = new NativeSampleDBDAO();
            Console.WriteLine("TestConnection!");
            dao.TestConnect();
            Console.WriteLine("Delete DataBase and Reset Table!");
            dao.ResetDB();
            Console.WriteLine("Select whole Table!");
            dao.TestSQLQuery();

            Console.WriteLine("Select Table by name, Input Name");
            dao.SelectByName(Console.ReadLine());

            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);


        }
    }
}
