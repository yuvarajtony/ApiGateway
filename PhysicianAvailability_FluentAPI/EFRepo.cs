
using FluentAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace FluentAPI
{
    public class EFRepo : IModel<Entities.PhysicianAvailablity>
    {
        private readonly PhysicianAvailabilityDbContext _con;
        public EFRepo(PhysicianAvailabilityDbContext con)
        {
            _con = con;
        }

        public PhysicianAvailablity AddPhysician(PhysicianAvailablity phy)
        {
            _con.Add(phy);
            _con.SaveChanges();
            return phy;
        }

        public IEnumerable<PhysicianAvailablity> GetAll()
        {
            //throw new NotImplementedException();
            var r = _con.PhysicianAvailablities;
            var getallphysician = (from t in r
                                   select new PhysicianAvailablity()
                                   {
                                       PhysicianEmail = t.PhysicianEmail,
                                       AvailableFrom = t.AvailableFrom,
                                       AvailableTo = t.AvailableTo,
                                   });
            return getallphysician.ToList();
        }


        public IEnumerable<Entities.PhysicianAvailablity> FindDoctorByEmailID()
        {
            return _con.PhysicianAvailablities.ToList();
        }

        public Entities.PhysicianAvailablity Deletetr(string EmailID)
        {
            var t = _con.PhysicianAvailablities.Where(i => i.PhysicianEmail == EmailID).FirstOrDefault(); ;
            if (t != null)
            {
                _con.PhysicianAvailablities.Remove(t);
                _con.SaveChanges();
            }
            return t;
        }

        public Entities.PhysicianAvailablity UpdatePhysician(Entities.PhysicianAvailablity t)
        {
            _con.PhysicianAvailablities.Update(t);
            _con.SaveChanges();
            return t;
        }
    }
}

