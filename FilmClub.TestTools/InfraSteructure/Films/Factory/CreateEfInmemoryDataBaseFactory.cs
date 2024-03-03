using FilmClub.TestTools.InfraSteructure.DataBaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.Films.Factory
{
    public class CreateEfInmemoryDataBaseFactory
    {
        public static EFInMemoryDatabase Create()
        {
            return new EFInMemoryDatabase();
        }
    }
}
