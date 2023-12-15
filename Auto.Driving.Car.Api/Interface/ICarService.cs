using Auto.Driving.Car.Api.Models; 
using Azure;

namespace Auto.Driving.Car.Api.Interface
{
    public interface ICarService
    {
        public string MoveCar(CarMoveRequestDto requestDto); 
    }
}
