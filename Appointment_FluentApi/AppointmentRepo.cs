using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi
{
    public class AppointmentRepo : IRepo<Entities.Appointment>
    {

        Entities.AppointmentDbContext context;
        public AppointmentRepo(Entities.AppointmentDbContext context)
        {
            this.context = context;
        }
        public Entities.Appointment Add(Entities.Appointment ap)
        {
            context.Add(ap);
            context.SaveChanges();
            return ap;
        }
        public List<Entities.Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }
        public List<Entities.Appointment> GetByAcceptance(int val)
        {
            return context.Appointments.Where(x => x.Acceptance == val).ToList();
        }

        public List<Entities.Appointment> GetByPatientId(int val)
        {
            return context.Appointments.Where(x => x.PatientId == val).ToList();
        }
        public Entities.Appointment Update(Entities.Appointment ap)
        {
            context.Appointments.Update(ap);
            context.SaveChanges();
            return ap;
        }
        public List<Entities.Appointment> GetByDoctorMailAcceptance(int i, string email)
        {
            return context.Appointments.Where(x => x.Acceptance == i && x.PhysicianEmail == email).ToList();
        }

        public Entities.Appointment UpdateById(Entities.Appointment ap)
        {
            //db.Users.Attach(user);
            //db.Entry(user).Property(x => x.Password).IsModified = true;
            //db.SaveChanges();

            context.Appointments.Attach(ap);
            //context.Entry(ap).Property(x => x.Id).IsModified = true;
            context.Entry(ap).Property(x => x.Acceptance).IsModified = true;
            context.SaveChanges();
            return ap;
        }

        public List<Entities.Appointment> GetByDateAcceptanceDoctor(int acceptanceNo, string date, string docEmail)
        {
            {
                return context.Appointments.Where(x => x.Acceptance == acceptanceNo &&
                x.Date == date &&
                x.PhysicianEmail == docEmail)
                    .ToList();

            }
        }
    }
}
