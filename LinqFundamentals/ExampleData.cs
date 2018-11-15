using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LinqFundamentals
{
    internal static class ExampleData
    {
        internal static List<string> ListString => new List<string>
        {
            "a 1 record 1",
                "a 12 record 2",
                "a 45 string 3",
                "a 115 string 30",
                "a 2 string 100",
                "a 8 string 200"
        };

        internal static List<Car> Cars => new List<Car>
        {
            new Car{ Make = "Subaru", Model = "Impresa", Price = 50000, Year = 2007,
                TechData = new Specs{DriveType = DriveType.AWD, EngineVolume = 2.5,
                    FuelType = FuelType.Gasoline, TurboCharged = true, Transmission = TransmissionType.Automatic}},

            new Car{ Make = "Subaru", Model = "Forester", Price = 25000, Year = 2008,
                TechData = new Specs{DriveType = DriveType.AWD, EngineVolume = 2.5,
                    FuelType = FuelType.Gasoline, TurboCharged = true, Transmission = TransmissionType.Manual}},

            new Car{ Make = "Volvo", Model = "XC70", Price = 45000, Year = 2007,
                TechData = new Specs{DriveType = DriveType.AWD, EngineVolume = 3.0,
                    FuelType = FuelType.Diesel, TurboCharged = false, Transmission = TransmissionType.Manual}},

            new Car{ Make = "Audi", Model = "A8", Price = 20000, Year = 2007,
                TechData = new Specs{DriveType = DriveType.AWD, EngineVolume = 2.5,
                    FuelType = FuelType.Diesel, TurboCharged = true, Transmission = TransmissionType.Automatic}},

            new Car{ Make = "Toyota", Model = "Hilux", Price = 30000, Year = 2017,
                TechData = new Specs{DriveType = DriveType.AWD, EngineVolume = 5.0,
                    FuelType = FuelType.Diesel, TurboCharged = true, Transmission = TransmissionType.Manual}},

            new Car{ Make = "Mercedes", Model = "Benz", Price = 230000, Year = 2018,
                TechData = new Specs{DriveType = DriveType.RWD, EngineVolume = 3.0,
                    FuelType = FuelType.LPG, TurboCharged = true, Transmission = TransmissionType.Automatic}},
        };
    }

    internal class Car : IEquatable<Car>
    {
        [JsonProperty("Model")]
        internal string Model;

        [JsonProperty("Make")]
        internal string Make;

        [JsonProperty("Year")]
        internal int Year;

        [JsonProperty("TechData")]
        internal Specs TechData;

        [JsonProperty("Price")]
        internal BigInteger Price;


        public bool Equals(Car other)
        {
            return this.Model.Equals(other.Model) && this.Make.Equals(other.Make) && this.Year.Equals(other.Year);
        }

        public override int GetHashCode()
        {
            int hashMake = Make == null ? 0 : Make.GetHashCode();
            int hashModel = Model == null ? 0 : Model.GetHashCode();
            return hashMake ^ hashModel;
        }

    }

    internal class Specs
    {
        [JsonProperty("FuelType")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal FuelType FuelType;

        [JsonProperty("EngineVolume")]
        internal double EngineVolume;

        [JsonProperty("Turbocharged")]
        internal bool TurboCharged;

        [JsonProperty("Transmission")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal TransmissionType Transmission;

        [JsonProperty("DriveType")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal DriveType DriveType;
    }

    internal enum FuelType
    {
        Diesel,
        Gasoline,
        LPG
    }

    internal enum TransmissionType
    {
        Automatic,
        Manual
    }

    internal enum DriveType
    {
        FWD,
        RWD,
        AWD
    }
}
