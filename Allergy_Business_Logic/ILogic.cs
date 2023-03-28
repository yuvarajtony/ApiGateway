using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allergy_Business_Logic
{
    public interface ILogic
    {
        Models.Allergy AddDetails(Models.Allergy details);
        IEnumerable<Models.Allergy> Get(int t);
    }
}
