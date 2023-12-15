using Auto.Driving.Car.Api.Interface;
using Auto.Driving.Car.Api.Models;

namespace Auto.Driving.Car.Services
{
    public class CarService : ICarService
    {
        public string MoveCar(CarMoveRequestDto requestDto)
        {
            string[] fieldSize = requestDto.FieldSize.Split();
            int width = int.Parse(fieldSize[0]);
            int height = int.Parse(fieldSize[1]);

            string[] initialPosition = requestDto.InitialPosition.Split();
            int x = int.Parse(initialPosition[0]);
            int y = int.Parse(initialPosition[1]);
            char direction = char.Parse(initialPosition[2]);

            foreach (char command in requestDto.Commands)
            {
                ProcessCommand(ref x, ref y, ref direction, width, height, command);
            }

            return $"{x} {y} {direction}";
        }

        private static void ProcessCommand(ref int x, ref int y, ref char direction,
            int width, int height, char command)
        {
            // Update position and direction based on the command
            switch (command)
            {
                case 'L':
                case 'R':
                    direction = Rotate(direction, command);
                    break;
                case 'F':
                    // Update position based on direction
                    switch (direction)
                    {
                        case 'N':
                            if (y < height - 1) y++;
                            break;
                        case 'E':
                            if (x < width - 1) x++;
                            break;
                        case 'S':
                            if (y > 0) y--;
                            break;
                        case 'W':
                            if (x > 0) x--;
                            break;
                        default:
                            throw new ArgumentException("Invalid direction");
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid command");
            }
        }

        private static char Rotate(char currentDirection, char rotation)
        {
            if (rotation == 'L')
            {
                return currentDirection switch
                {
                    'N' => 'W',
                    'W' => 'S',
                    'S' => 'E',
                    'E' => 'N',
                    _ => throw new ArgumentException("Invalid direction"),
                };
            }
            else if (rotation == 'R')
            {
                return currentDirection switch
                {
                    'N' => 'E',
                    'E' => 'S',
                    'S' => 'W',
                    'W' => 'N',
                    _ => throw new ArgumentException("Invalid direction"),
                };
            }
            else
            {
                throw new ArgumentException("Invalid rotation");
            }
        }
    }
}
