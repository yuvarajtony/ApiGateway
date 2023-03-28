using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityApi.Entities;
using System.Threading.Tasks;
using da = EntityApi;

namespace Allergy_Business_Logic
{
    public class Logic:ILogic
    {
        Mapper map = new Mapper();

        da.IRepo<da.Entities.Allergy> repo;
        public Logic(da.IRepo<da.Entities.Allergy> _repo) 
        {
            repo = _repo;
        }
        public Models.Allergy AddDetails(Models.Allergy allergy)
        {
            return map.Map(repo.Add(map.Map(allergy)));
        }
        public IEnumerable<Models.Allergy> Get(int t) 
        {
            
            return map.Map(repo.Get(t));
        }
        }
    }

