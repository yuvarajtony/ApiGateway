using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityApi
{
    public interface IRepo<T>
    {
        T Add(T t);
       IEnumerable<T> Get(int t);
    }
}
