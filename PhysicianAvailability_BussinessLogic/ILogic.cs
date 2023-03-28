using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAPI.Entities;
using Models;

namespace Physician_BussinessLogic
{
    public interface ILogic
    {
        IEnumerable<Physicianavailability> GetAll();
        Physicianavailability AddPhysician(Physicianavailability phy);

        IEnumerable<Physicianavailability> FindDoctorByEmailID(string EmailID);

        Physicianavailability DeletePhy(string EmailID);

        Physicianavailability UpdatePhysician(string EmailID, Physicianavailability s);
    }
}
