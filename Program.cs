using System;
using System.Dynamic;
using System.Text.RegularExpressions;
using HelloWorld;


namespace HelloWorld
{
    /*
In this example, we use the property 'Speed' instead of directly setting 'this.speed' in the constructor.
By using the property, we ensure that any logic in the property's setter, such as validation or logging,
is applied not only when the property is set externally but also during object initialization.
For instance, in the 'Speed' setter, we check if the value is negative and correct it to zero if necessary,
providing robustness against invalid values. Using 'this.speed = speed' directly would bypass this logic,
potentially allowing invalid data to be assigned to 'speed'. This approach makes the code more maintainable
and secure against improper usage.
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            // Erstelle ein Car-Objekt
            Car car = new Car(500);
            car.Speed = 1000;
            // Ausgabe der Geschwindigkeit
            Console.WriteLine("Car speed: " + car.Speed);


            ////// Other Way 
            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };
            myComputer.HasWifi = false;
            Console.WriteLine(myComputer.HasWifi);
            Console.WriteLine(myComputer.ReleaseDate);
            Console.WriteLine(myComputer.VideoCard);

        }
    }

    class Car
    {
        private int speed;

        public Car(int speed)
        {
            Speed = speed;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }

    public class Computer
    {
        public string Motherboard { get; set; } = "";
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";

        // // Die String Properties dürfen nicht NUll sein bei der erstellung, warum - Keine Ahung, alternativer
        // // weg wäre das:
        
        // public Computer()
        // {
        //     if (VideoCard == null)
        //     {
        //         VideoCard = "";
        //     }
        //     if (Motherboard == null)
        //     {
        //         Motherboard = "";
        //     }
        // }

    }
}



