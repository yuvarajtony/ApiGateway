using AutoFixture;
using Allergy_Business_Logic;
using Capstone_Project.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Models;
namespace AllergyServiceTest
{
    public class AllergyControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<ILogic> _logic;
        private readonly AllergyController _controller;


        public AllergyControllerTest()
        {
            _fixture = new Fixture();
            _logic = _fixture.Freeze<Mock<ILogic>>();
            _controller = new AllergyController(_logic.Object);

        }
        [Fact]
        public void Get_ShouldReturnOkResponse_WhenDataFound()
        {
            // Arrange
            var AllergyMock = _fixture.Create<IEnumerable<Allergy>>();
            var VisitId = _fixture.Create<int>();
            _logic.Setup(x => x.Get(VisitId)).Returns(AllergyMock);

            // Act
            var result = _controller.Get(VisitId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AllergyMock.GetType());
            _logic.Verify(x => x.Get(VisitId), Times.AtLeastOnce());

        }
        [Fact]
        public void Get_ShouldReturnOkResponse_WhenDataNotFound()
        {
            // Arrange
            var AllergyMock = _fixture.Create<IEnumerable<Allergy>>();
            var VisitId = _fixture.Create<int>();
            _logic.Setup(x => x.Get(VisitId)).Throws(new Exception("Something Went Wrong"));
            // Act
            var result = _controller.Get(VisitId);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _logic.Verify(x => x.Get(VisitId), Times.AtLeastOnce());


        }
        [Fact]
        public void Post_ShouldReturnOkResponse_WhenDataFound()
        {
            var request = _fixture.Create<Allergy>();
            var response = _fixture.Create<Allergy>();
            _logic.Setup(x => x.AddDetails(request));

            var result = _controller.Add(request);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CreatedResult>();
            _logic.Verify(x => x.AddDetails(request), Times.AtLeastOnce());

        }

    }
}