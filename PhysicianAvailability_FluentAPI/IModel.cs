using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public interface IModel<T>
    {
        T AddPhysician(T phy);
        IEnumerable<T> GetAll();

        T Deletetr(string EmailID);

        T UpdatePhysician(T phy);
    }
}
