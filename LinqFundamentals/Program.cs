using System;
using System.Linq;

namespace LinqFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LINQ!");
            //ExampleData.Cars.Print();

            //Find all by specific year and make
            //ExampleData.Cars.Where(c => c.Make.Equals("Mercedes") && c.Year > 2010).Print();

            //Find first with petrol engine
            // ExampleData.Cars.Where(car => car.TechData.FuelType == FuelType.Gasoline).First().Print();
            ExampleData.Cars.First(c => c.TechData.FuelType == FuelType.Diesel).Print();

            //Total price of all rwd cars

        }
    }
}
