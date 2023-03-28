using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityApi.Entities;

namespace EntityApi
{
    public class Repo:IRepo<Allergy>
    {
        public Repo() { }
        Entities.AllergyDbContext context = new Entities.AllergyDbContext();
        public Entities.Allergy Add(Entities.Allergy t)
        {
            context.Add(t);
            context.SaveChanges();
            return t;
        }
        public IEnumerable<Entities.Allergy> Get(int  t) 
        { 
            var a = context.Allergies.Where(m => m.VisitId == t);
            return a;
        }

    }
}
