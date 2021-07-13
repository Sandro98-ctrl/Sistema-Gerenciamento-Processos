using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;
using System.Text;

namespace Gerenciador.Processos.Data.Extensions
{
    public static class PopulateDatabaseExtensions
    {
        public static void CreateAndPopulate(this DatabaseFacade database)
        {
            if (database.EnsureCreated())
            {
                var directory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
                var sqlFiles = directory.GetFiles("*.sql");

                foreach (var file in sqlFiles)
                {
                    string sql = File.ReadAllText(file.FullName, Encoding.UTF8);
                    database.ExecuteSqlRaw(sql);
                }
            }
        }
    }
}
