using System;

namespace EFCoreSample.Core.Main
{
    using Config.Properties;
    using System.Data.SqlClient;
    using Persistence.DAO;
    using Persistence.Context;

    class ProgramEntry
    {

        private static readonly string ConnectionString = new SqlConnectionStringBuilder
        {
            DataSource = Resources.DataSource,
            UserID = Resources.UserID,
            Password = Resources.Password,
            InitialCatalog = Resources.InitialCatalog
        }.ConnectionString;

        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Code, if you want to Test NativeSQLSample (1) or EFSample (2): ");
            var response = Console.ReadKey().KeyChar;
            if (response == '1')
            {

                var dao = new NativeSampleDBDAO(ConnectionString);
                Console.WriteLine("TestConnection!");
                dao.TestConnect();
                Console.WriteLine("Delete DataBase and Reset Table!");
                dao.ResetDB();
                Console.WriteLine("Select whole Table!");
                dao.TestSQLQuery();
                Console.WriteLine("Select Table by name, Input Name");
                dao.SelectByName(Console.ReadLine());

            }
            else if (response == '2')
            {

                var dao = new EFSampleDBDAO(ConnectionString);
                Console.WriteLine("TestConnection!");
                dao.TestConnect();
                Console.WriteLine("Delete DataBase and Reset Table!");
                dao.ResetDB();
                Console.WriteLine("Select whole Table!");
                dao.TestSQLQuery();
                Console.WriteLine("Select Table by name, Input Name");
                dao.SelectByName(Console.ReadLine());
            }


            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);


        }
    }
}
