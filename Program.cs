﻿using System;

namespace OOP
{
    class OOPBasics
    {
        // Interfaces
        public interface IVehicle
        {
            public void Start();
            public void Stop();
        }
        public class Car: IVehicle
        {
            // Private fields to store property values internally.
            private string _make=string.Empty;// Initialized to avoid null
            private string _model=string.Empty;// Initialized to avoid null
            private int _year;

            public void Start()
            {
                Console.WriteLine($"This {_make} {_model} has started.");
            }
            public void Stop()
            {
                Console.WriteLine($"This {_make} {_model} has stopped.");
            }

            // Public properties with encapsulation for controlled access to fields.
            public string Make
            {
                get => _make; // Getter returns the value of _make.
                set
                {
                    // Validate input to ensure it's not empty or null.
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Make cannot be empty.");
                    _make = value;
                }
            }

            public string Model
            {
                get => _model; // Getter returns the value of _model.
                set
                {
                    // Validate input to ensure it's not empty or null.
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Model cannot be empty.");
                    _model = value;
                }
            }

            public int Year
            {
                get => _year; // Getter returns the value of _year.
                set
                {
                    // Validate the year to ensure it's realistic.
                    if (value < 1886 || value > DateTime.Now.Year)
                        throw new ArgumentOutOfRangeException(nameof(Year), "Year must be realistic.");
                    _year = value;
                }
            }

            // Constructor to initialize the Car object with values for make, model, and year.
            public Car(string make, string model, int year)
            {
                Make = make;  // Assign value using the property to apply validation.
                Model = model; // Assign value using the property to apply validation.
                Year = year;   // Assign value using the property to apply validation.
            }

            // Method to display car details in the console.
            public virtual void DisplayDetails()
            {
                Console.WriteLine($"Make: {Make}");
                Console.WriteLine($"Model: {Model}");
                Console.WriteLine($"Year: {Year}");
            }

            // Override the ToString method to provide a string representation of the car.
            public override string ToString()
            {
                return $"{Make} {Model} ({Year})"; // Concatenates the make, model, and year.
            }
        }
        public class ElectricCar: Car
        {
            private int _batteryCapacity;
            public int BatteryCapacity
            {
                get => _batteryCapacity;
                set
                {
                    if (value < 40 || value > 1000)
                        throw new ArgumentOutOfRangeException(nameof(BatteryCapacity), "Battery capacity must be between 40 and 1000 kWh.");
                    _batteryCapacity = value;
                }
            }

            public ElectricCar(string make, string model, int year, int batteryCapacity): base(make, model, year)
            {
                BatteryCapacity = batteryCapacity;
            }
            public override void DisplayDetails()
            {
                base.DisplayDetails();
                Console.WriteLine($"Battery Capacity: {BatteryCapacity} kWh");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // Create a new Car object using the constructor.
                Car myCar = new Car("Toyota", "Fielder", 2021);
                myCar.DisplayDetails(); // Call the method to display details.

                ElectricCar electricCar = new ElectricCar("Tesla", "Cyber Truck", 2024, 150 );
                electricCar.DisplayDetails();
                electricCar.Start();
                electricCar.Stop();


                
                // Demonstrate the overridden ToString method.
                Console.WriteLine(myCar.ToString());

                // Uncomment to test validation (will throw an exception).
                Car invalidCar = new Car("", "Fielder", 1800);

            }
            catch (Exception ex)
            {
                // Catch and display any exceptions that occur during execution.
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}