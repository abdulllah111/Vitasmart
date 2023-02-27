using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasmart.Persistence.Npgsql
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext applicationDbContext)
        {
            applicationDbContext.Database.EnsureCreated();
        }
    }
}
