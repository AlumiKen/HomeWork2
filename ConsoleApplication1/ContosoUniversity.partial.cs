using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public partial class ContosoUniversityEntities : DbContext
    {
        public override int SaveChanges()
        {
            var entities = this.ChangeTracker.Entries();

            foreach (var entry in entities)
            {
                Console.WriteLine("Entity Name : {0}", entry.Entity.GetType().FullName);
                Console.WriteLine("State_Original : {0}", entry.State);

                if (entry.State == EntityState.Modified)
                {
                    //Console.WriteLine("Value_Original : {0}", entry.OriginalValues.GetValue<int>("Credits"));
                    if (entry.Entity is Course)
                    {
                        //var a = entry.Entity as Course;
                        entry.CurrentValues.SetValues(new { Credits = 110 });
                    }
                    //Console.WriteLine("Value_After : {0}", entry.CurrentValues.GetValue<int>("Credits"));
                }
                Console.WriteLine("State_After : {0}", entry.State);
            }

            return base.SaveChanges();
        }
    }
}
