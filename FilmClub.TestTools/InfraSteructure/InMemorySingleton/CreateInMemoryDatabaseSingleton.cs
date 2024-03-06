using FilmClub.TestTools.InfraSteructure.DataBaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.InMemorySingleton
{
    public class CreateInMemoryDatabaseSingleton
    {
        public static EFInMemoryDatabase db;
        public static EFInMemoryDatabase Singleton()
        {
            db = new EFInMemoryDatabase();
            return db;
        }
    }
}
