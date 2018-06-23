using ChoiceYourBill.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceYourBill.Tests.Models.DataAccessLayer
{
    static class DbbInit
    {
        static public void initDbb()
        {
            SqlConnection.ClearAllPools();
            IDatabaseInitializer<DbbContext> init = new DropCreateDatabaseAlways<DbbContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new DbbContext());
            using (var ctx = new DbbContext())
            {
                ctx.Database.Initialize(force: true);
            }
        }
    }
}
