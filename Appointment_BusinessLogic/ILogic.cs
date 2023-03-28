using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fe = FluentApi.Entities;

namespace Appointment_BusinessLogic
{
    public interface ILogic
    {
        public fe.Appointment AddAppointment(Appointment_Models.Appointment ap);
        IEnumerable<Appointment_Models.Appointment> GetAppointment();

        IEnumerable<Appointment_Models.Appointment> GetMedicalHistory(int patientid);
        IEnumerable<Appointment_Models.Appointment> GetAppointmentByAcceptance(int acceptVal);

        public fe.Appointment UpdateAppointment(int PatientId, Appointment_Models.Appointment ap);
        IEnumerable<Appointment_Models.Appointment> GetAppointmentsbyEmailandAcceptance(int i, string email);
        public fe.Appointment UpdateAppointmentbyAppoinmentID(int AppointMentId, int AppointmentID);
        public IEnumerable<Appointment_Models.Appointment> GetAppointmentsbyDateDocEmailAndAcceptance(int acceptanceNo, string date, string docEmail);



    }
}
