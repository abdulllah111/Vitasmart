using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitasmart.EntityFramework
{
    public class DbInitializer
    {
        public static void Initialize(PatientsDbContext patientsDbContext, VisitingsDbContext visitingsDbContext)
        {
            patientsDbContext.Database.EnsureCreated();
            visitingsDbContext.Database.EnsureCreated();
        }
    }
}
