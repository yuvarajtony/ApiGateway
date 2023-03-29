using AutoFixture;
using Moq;
using Physician_BussinessLogic;
using PhysicianAvailabilityService.Controllers;
using Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;

namespace PhysicianServiceTestApi
{
    public class PhysicianAvaliabilityTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<ILogic> _mock;
        private readonly PhysicianAvailabilityController _controller;
    
        public PhysicianAvaliabilityTest()
        {
            _fixture = new Fixture();
            _mock = _fixture.Freeze<Mock<ILogic>>();
            _controller = new PhysicianAvailabilityController(_mock.Object);
        }
        [Fact]
        public void GetPhysicians_ShouldReturnOkResponse_WhenDataFound()
        {
            var physicianMock = _fixture.Create<IEnumerable<Physicianavailability>>();
            _mock.Setup(x => x.GetAll()).Returns(physicianMock);

            var result = _controller.Get();

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(physicianMock.GetType());
            _mock.Verify(x => x.GetAll(), Times.AtLeastOnce());
        }
        [Fact]
        public void GetPhysicians_ShouldReturnOkResponse_WhenDataNotFound()
        {
            var physicianMock = _fixture.Create<IEnumerable<Physicianavailability>>();
            _mock.Setup(x => x.GetAll()).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = _controller.Get();
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetAll(), Times.AtLeastOnce());
        }
        [Fact]
        public void FindDoctorByEmailID_ShouldReturnOkResponse_WhenDataFound()
        {

            //var EmailId = _fixture.Create<string>();
            var Mock = _fixture.Create<IEnumerable<Physicianavailability>>();
            var EmailId = _fixture.Create<string>();
            _mock.Setup(x => x.FindDoctorByEmailID(EmailId)).Returns(Mock);

            // Act
            var result = _controller.FindDoctorByEmailID(EmailId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(Mock.GetType());
            _mock.Verify(x => x.FindDoctorByEmailID(EmailId), Times.AtLeastOnce());

        }
        [Fact]
        public void FindDoctorByEmailID_ShouldReturnOkResponse_WhenDataNotFound()
        {
            var result = _fixture.Create<Physicianavailability>();
            var EmailId = _fixture.Create<string>();
            _mock.Setup(x => x.FindDoctorByEmailID(EmailId));
            var res = _controller.FindDoctorByEmailID(EmailId);
            res.Should().NotBeNull();
            _mock.Verify(x => x.FindDoctorByEmailID(EmailId), Times.AtLeastOnce());
        }
    
        [Fact]
        public void Post_ShouldReturnOkResponse_WhenDataFound()
        {
            var request = _fixture.Create<Physicianavailability>();
            var response = _fixture.Create<Physicianavailability>();
            _mock.Setup(x => x.AddPhysician(request));

            var result = _controller.AddNewPhysician(request);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedResult>();
            _mock.Verify(x => x.AddPhysician(request), Times.AtLeastOnce());
        }
        [Fact]
        public void Post_ShouldReturnOkResponse_WhenDataNotFound()
        {
            var result = _fixture.Create<Physicianavailability>();
            _mock.Setup(x => x.AddPhysician(result));
            var res = _controller.AddNewPhysician(result);
            res.Should().NotBeNull();
            _mock.Verify(x => x.AddPhysician(result), Times.AtLeastOnce());
        }
        [Fact]
        public void UpdatePhysician()
        {
            var request = _fixture.Create<Physicianavailability>();
            var Email = _fixture.Create<string>();
            _mock.Setup(x => x.UpdatePhysician(Email, request)).Returns(request);

            var result = _controller.Updatephy(Email, request);

            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(request.GetType());
            _mock.Verify(x=> x.UpdatePhysician(Email, request), Times.AtLeastOnce());

        }
        [Fact]
        public void UpdatePhysician_NotFound()
        {
            var res = _fixture.Create<Physicianavailability>();
            var Email = _fixture.Create<string>();
            _mock.Setup(x => x.UpdatePhysician(Email, res)).Throws(new Exception("Something went wrong"));
            var req = _controller.Updatephy(Email, res);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x=> x.UpdatePhysician(Email, res), Times.AtLeastOnce());
        }
        [Fact]
        public void DeletePhysician()
        {
            var request = _fixture.Create<Physicianavailability>();
            var EmailId = _fixture.Create<string>();
            _mock.Setup(x=> x.DeletePhy(EmailId)).Returns(request);

            var result = _controller.Delete(EmailId);

            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(request.GetType());
            _mock.Verify(x=> x.DeletePhy(EmailId), Times.AtLeastOnce());


        }
        [Fact]
        public void DeletePhysician_NotFound()
        {
            var res = _fixture.Create<Physicianavailability>();
            var EmailId = _fixture.Create<string>();
            _mock.Setup(x => x.DeletePhy(EmailId)).Throws(new Exception("Details Not Found"));
            var result = _controller.Delete(EmailId);
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.DeletePhy(EmailId), Times.AtLeastOnce());
        }
    }
}
