namespace Auto.Driving.Car.Api.Models
{
    public class CarMoveRequestDto
    {
        public string FieldSize { get; set; } = string.Empty;
        public string InitialPosition { get; set; } = string.Empty;
        public string Commands { get; set; } = string.Empty;
    }
}
