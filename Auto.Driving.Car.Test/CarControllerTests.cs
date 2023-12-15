using Auto.Driving.Car.Api.Controllers;
using Auto.Driving.Car.Api.Interface;
using Auto.Driving.Car.Api.Models;
using Auto.Driving.Car.Domain.DomainModel.CarAggregate;
using Auto.Driving.Car.Services;
using Moq;

namespace Auto.Driving.Car.Test
{
    public class CarControllerTests
    {
        [Fact]
        public void MoveCar_ReturnFinalPosition()
        {
            // Arrange
            ICarService carService = new CarService(); 

            var request = new CarMoveRequestDto
            {
                FieldSize = "10 10",
                InitialPosition = "1 2 N",
                Commands = "FFRFFFRRLF"
            };


            var expectedFinalPosition = "4 3 S";

            // Act
            var result = carService.MoveCar(request);

            // Assert
            Assert.Equal(expectedFinalPosition, result);
        }
    }
}