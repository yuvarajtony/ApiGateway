using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAPI.Entities;

namespace Physician_BussinessLogic
{
    public class Mapper
    {
        public static Models.Physicianavailability PhyMap(FluentAPI.Entities.PhysicianAvailablity s)
        {
            return new Models.Physicianavailability()
            {
                physician_email = s.PhysicianEmail,
                availablefrom = s.AvailableFrom,
                availableTo = s.AvailableTo,
            };
        }

        public static FluentAPI.Entities.PhysicianAvailablity PhyMap(Models.Physicianavailability e)
        {
            return new FluentAPI.Entities.PhysicianAvailablity()
            {
                PhysicianEmail = e.physician_email,
                AvailableFrom = e.availablefrom,
                AvailableTo = e.availableTo,
            };
        }

        public static IEnumerable<Models.Physicianavailability> PhyMap(IEnumerable<FluentAPI.Entities.PhysicianAvailablity> s)
        {
            return s.Select(PhyMap);
        }
    }
}
