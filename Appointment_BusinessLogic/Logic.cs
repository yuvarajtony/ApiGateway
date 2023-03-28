using FluentApi;
using FluentApi.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using fe = FluentApi.Entities;

namespace Appointment_BusinessLogic
{
    public class Logic : ILogic
    {
        IRepo<fe.Appointment> aprepo;
        public Logic(fe.AppointmentDbContext context)
        {
            aprepo = new AppointmentRepo(context);

        }
        public fe.Appointment AddAppointment(Appointment_Models.Appointment ap)
        {
            return aprepo.Add(Mapper.Map(ap));
        }
        public IEnumerable<Appointment_Models.Appointment> GetAppointment()
        {
            return Mapper.Map(aprepo.GetAll());
        }
        public IEnumerable<Appointment_Models.Appointment> GetAppointmentByAcceptance(int acceptVal)
        {

            return Mapper.Map(aprepo.GetByAcceptance(acceptVal));
        }

        public IEnumerable<Appointment_Models.Appointment> GetMedicalHistory(int patientid)
        {
            // throw new NotImplementedException();
            return Mapper.Map(aprepo.GetByPatientId(patientid));
        }

        public fe.Appointment UpdateAppointment(int PatientId, Appointment_Models.Appointment ap)
        {

            var apmt = (from apt in aprepo.GetAll()
                        where apt.PatientId == PatientId
                        select apt).FirstOrDefault();

            if (apmt != null)
            {

                apmt.Acceptance = ap.Acceptance;
                apmt.PatientId = ap.PatientId;
                apmt.Date = ap.Date;
                apmt.SubmissionDate = ap.SubmissionDate;
                apmt.Reason = ap.Reason;
                apmt.PhysicianEmail = ap.PhysicianEmail;
                apmt = aprepo.Update(apmt);


            }

            return apmt;
        }
        public IEnumerable<Appointment_Models.Appointment> GetAppointmentsbyEmailandAcceptance(int i, string email)
        {
            return Mapper.Map(aprepo.GetByDoctorMailAcceptance(i, email));
        }

        public fe.Appointment UpdateAppointmentbyAppoinmentID(int AppointMentId, int AcceptanceNo)
        {

            var apmt = (from apt in aprepo.GetAll()
                        where apt.Id == AppointMentId
                        select apt).FirstOrDefault();

            if (apmt != null)
            {
                //apmt.Id = AppointMentId;
                apmt.Acceptance = AcceptanceNo;

                apmt = aprepo.UpdateById(apmt);


            }

            return apmt;
        }

        public IEnumerable<Appointment_Models.Appointment> GetAppointmentsbyDateDocEmailAndAcceptance(int acceptanceNo, string date, string docEmail)
        {
            return Mapper.Map(aprepo.GetByDateAcceptanceDoctor(acceptanceNo, date, docEmail));
        }
    }
}
