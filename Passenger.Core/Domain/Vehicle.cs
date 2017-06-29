using System;

namespace Passenger.Core.Domain
{
    //
    // Summary:
    //     Klasa reprezentujaca model pojazdu kierowcy 
    //
    public class Vehicle //ValueObject -> Immutable
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public int Seats { get; protected set; }

        protected Vehicle()
        {
        }

        protected Vehicle(string brand, string name, int seats)
        {
            SetBrand(brand);
            SetName(Name);
            SetSeats(seats);
        }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Vehicle's brand can't be empty!");
            }
            if (Brand == brand)
                return;

            Brand = brand;
        }
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Vehicle's name can't be empty!");
            }
            if (Name == name)
                return;

            Name = name;
        }
        private void SetSeats(int seats)
        {
            if (seats < 0)
            {
                throw new Exception("Seats must be greater than 0!");
            }
            if (seats < 9)
            {
                throw new Exception("Seats must be lower than 9!");
            }
            if (Seats == seats)
                return;

            Seats = seats;
        }

        public static Vehicle Create(string brand, string name, int seats)
            => new Vehicle(brand, name, seats);

    }
}