using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAPI;
using FluentAPI.Entities;
using Models;
using System.Net;
using System.Security.Cryptography;

namespace Physician_BussinessLogic
{
    public class Logic : ILogic
    {
        IModel<FluentAPI.Entities.PhysicianAvailablity> _repo;
        public Logic(IModel<FluentAPI.Entities.PhysicianAvailablity> repo)
        {
            _repo = repo;
        }
        public Physicianavailability AddPhysician(Physicianavailability phy)
        {
            return Mapper.PhyMap(_repo.AddPhysician(Mapper.PhyMap(phy)));
        }

        public IEnumerable<Physicianavailability> GetAll()
        {
            return Mapper.PhyMap(_repo.GetAll());
        }

        public IEnumerable<Physicianavailability> FindDoctorByEmailID(string EmailID)
        {
            var t = _repo.GetAll().Where(i => i.PhysicianEmail == EmailID);
            return Mapper.PhyMap(t);
        }

        public Physicianavailability DeletePhy(string EmailID)
        {
            var t = _repo.Deletetr(EmailID);
            if (t != null)
            {
                return Mapper.PhyMap(t);
            }
            else
            {
                return null;
            }
        }

        public Physicianavailability UpdatePhysician(string EmailID, Physicianavailability s)
        {
            var t = (from r in _repo.GetAll()
                     where r.PhysicianEmail == EmailID
                     && r.PhysicianEmail == s.physician_email
                     select r).FirstOrDefault();
            if (t != null)
            {
                t.PhysicianEmail = s.physician_email;
                t.AvailableFrom = s.availablefrom;
                t.AvailableTo = s.availableTo;

                t = _repo.UpdatePhysician(t);
            }
            if (t == null)
            {
                throw new Exception("Not found");
            }
            return Mapper.PhyMap(t);



        }
    }
}