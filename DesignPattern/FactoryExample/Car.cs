namespace DesignPattern.FactoryExample
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }

        public Car CreateCar()
        {
            return new Car
            {
                Model = "Sedan",
                Color = "Blue",
                Speed = 110
            };
        }
    }
}