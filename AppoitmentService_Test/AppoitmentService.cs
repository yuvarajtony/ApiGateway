using AppointmentsApi.Controllers;
using AutoFixture;
using Appointment_BusinessLogic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
//using FluentApi.Entities;
using Appointment_Models;
using Moq;

namespace AppoitmentService_Test
{
    public class AppoitmentService
    {
        private readonly IFixture _fixture;
        private readonly Mock<ILogic> _logic;
        private readonly AppointmentController _controller;

        public AppoitmentService() 
        {
            _fixture = new Fixture();
            _logic = _fixture.Freeze<Mock<ILogic>>();
            _controller = new AppointmentController(_logic.Object);
        }



        [Fact]
        public void GetAllAppointment()
        {
            //arrange
            var AppontmentMock = _fixture.Create<IEnumerable<Appointment>>();
            _logic.Setup(x => x.GetAppointment()).Returns(AppontmentMock);
            //act
            var result = _controller.Get();
            //asert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _logic.Verify(x => x.GetAppointment(), Times.AtLeastOnce());
        }
        [Fact]
        public void GetAllAppointment_NotFound()
        {
            var physicianMock = _fixture.Create<IEnumerable<Appointment>>();
            _logic.Setup(x => x.GetAppointment()).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = _controller.Get();
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.GetAppointment(), Times.AtLeastOnce());
        }
        [Fact]

        public void updatebyAppointMentNo()
        {
            var request = _fixture.Create<Appointment>();
            var AcceptanceNo = _fixture.Create<int>();
            var id = _fixture.Create<int>();
            _logic.Setup(x => x.UpdateAppointmentbyAppoinmentID(id,AcceptanceNo));

            var result = _controller.UpdateAcceptanceByAppointMentID(id, AcceptanceNo);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _logic.Verify(x => x.UpdateAppointmentbyAppoinmentID(id,AcceptanceNo), Times.AtLeastOnce());
        }
        [Fact]
        public void updatebyAppointMentNo_Notfound()
        {
            var res = _fixture.Create<Appointment>();
            var AcceptanceNo = _fixture.Create<int>();
            var id = _fixture.Create<int>();
            _logic.Setup(x => x.UpdateAppointmentbyAppoinmentID(AcceptanceNo, id)).Throws(new Exception("Not Found"));
            var req = _controller.UpdateAcceptanceByAppointMentID(AcceptanceNo, id);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.UpdateAppointmentbyAppoinmentID(AcceptanceNo, id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetbyAcceptance()
        {
            var AppontmentMock = _fixture.Create<IEnumerable<Appointment>>();
            var Acceptoance = _fixture.Create<int>();
            _logic.Setup(x => x.GetAppointmentByAcceptance(Acceptoance)).Returns(AppontmentMock);
            var result = _controller.Get(Acceptoance);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _logic.Verify(x => x.GetAppointmentByAcceptance(Acceptoance), Times.AtLeastOnce());

        }
        [Fact]
        public void GetByAcceptance_NotFound()
        {
            var res = _fixture.Create<Appointment>();
            var AcceptanceNo = _fixture.Create<int>();
            
            _logic.Setup(x => x.GetAppointmentByAcceptance(AcceptanceNo)).Throws(new Exception("Not Found"));
            var req = _controller.Get(AcceptanceNo);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.GetAppointmentByAcceptance(AcceptanceNo), Times.AtLeastOnce());
        }
        [Fact]

        public void GetbyPatientID()
        {
            var AppontmentMock = _fixture.Create<IEnumerable<Appointment>>();
            var patientid = _fixture.Create<int>();
            _logic.Setup(x => x.GetMedicalHistory(patientid)).Returns(AppontmentMock);
            var result = _controller.GetMedical(patientid);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _logic.Verify(x => x.GetMedicalHistory(patientid), Times.AtLeastOnce());
        }
        [Fact]
        public void GetbyPatientID_NotFound()
        {
            var res = _fixture.Create<Appointment>();
            var patientid = _fixture.Create<int>();

            _logic.Setup(x => x.GetMedicalHistory(patientid)).Throws(new Exception("Not Found"));
            var req = _controller.GetMedical(patientid);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.GetMedicalHistory(patientid), Times.AtLeastOnce());
        }
        [Fact]

        public void updateby_patID()
        {
            var request = _fixture.Create<Appointment>();
            var PatientId = _fixture.Create<int>();
            var id = _fixture.Create<int>();
            _logic.Setup(x => x.UpdateAppointment(id, request));

            var result = _controller.Update(id, request);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _logic.Verify(x => x.UpdateAppointment(id, request), Times.AtLeastOnce());
        }
        [Fact]
        public void updateby_patID_NotFound()
        {
            var res = _fixture.Create<Appointment>();
            var PatientId = _fixture.Create<Appointment>();
            var id = _fixture.Create<int>();
            _logic.Setup(x => x.UpdateAppointment( id, PatientId)).Throws(new Exception("Not Found"));
            var req = _controller.Update( id, PatientId);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.UpdateAppointment(id, PatientId), Times.AtLeastOnce());
        }
        [Fact]
        public void GetAcceptanceAndEmail()
        {
            var AppontmentMock = _fixture.Create<IEnumerable<Appointment>>();
            var AcceptanceNo = _fixture.Create<int>();
            var Email = _fixture.Create<string>();
            _logic.Setup(x => x.GetAppointmentsbyEmailandAcceptance(AcceptanceNo,Email)).Returns(AppontmentMock);
            var result = _controller.GetByemailAccept(AcceptanceNo, Email);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _logic.Verify(x => x.GetAppointmentsbyEmailandAcceptance(AcceptanceNo, Email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetAcceptanceAndEmail_NotFound()
        {
            var res = _fixture.Create<Appointment>();
            var AcceptanceNo = _fixture.Create<int>();
            var Email = _fixture.Create<string>();
            _logic.Setup(x => x.GetAppointmentsbyEmailandAcceptance(AcceptanceNo, Email)).Throws(new Exception("Not Found"));
            var req = _controller.GetByemailAccept(AcceptanceNo, Email);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.GetAppointmentsbyEmailandAcceptance(AcceptanceNo, Email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetByDateAcceptanceNoDoctorEmail()
        {

            var AppontmentMock = _fixture.Create<IEnumerable<Appointment>>();
            var AcceptanceId = _fixture.Create<int>();
            var Date = _fixture.Create<string>();
            var DoctorEmail = _fixture.Create<string>();
            _logic.Setup(x => x.GetAppointmentsbyDateDocEmailAndAcceptance(AcceptanceId, Date,DoctorEmail)).Returns(AppontmentMock);
            var result = _controller.GetByDateandDocEmail(AcceptanceId, Date, DoctorEmail);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _logic.Verify(x => x.GetAppointmentsbyDateDocEmailAndAcceptance(AcceptanceId, Date, DoctorEmail), Times.AtLeastOnce());
        
        }
        [Fact]
        public void GetByDateAcceptanceNoDoctorEmail_NotFound()
        {
            var res = _fixture.Create<Appointment>();
            var AcceptanceId = _fixture.Create<int>();
            var Date = _fixture.Create<string>();
            var DoctorEmail = _fixture.Create<string>();
            _logic.Setup(x => x.GetAppointmentsbyDateDocEmailAndAcceptance(AcceptanceId, Date, DoctorEmail)).Throws(new Exception("Not Found"));
            var req = _controller.GetByDateandDocEmail(AcceptanceId, Date, DoctorEmail);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.GetAppointmentsbyDateDocEmailAndAcceptance(AcceptanceId, Date, DoctorEmail), Times.AtLeastOnce());
        }
    }
}