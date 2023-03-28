using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fe = FluentApi.Entities;

namespace Appointment_BusinessLogic
{
    public class Mapper
    {
        public static Appointment_Models.Appointment Map(fe.Appointment ap)
        {
            return new Appointment_Models.Appointment()
            {
                Id = ap.Id,
                Reason = ap.Reason,
                Date = ap.Date,
                Acceptance = ap.Acceptance,
                PatientId = ap.PatientId,
                PhysicianEmail = ap.PhysicianEmail,
                SubmissionDate = ap.SubmissionDate
            };
        }

        public static fe.Appointment Map(Appointment_Models.Appointment ap)
        {
            return new fe.Appointment()
            {
                     Id = ap.Id,
                     Reason= ap.Reason,
                     Date= ap.Date,
                     Acceptance = ap.Acceptance,
                     PatientId= ap.PatientId,
                     PhysicianEmail  = ap.PhysicianEmail,
                     SubmissionDate   =ap.SubmissionDate
            };
        }
        public static IEnumerable<Appointment_Models.Appointment> Map(IEnumerable<fe.Appointment> ap)
        {
            return ap.Select(Map);
        }
    }
}
