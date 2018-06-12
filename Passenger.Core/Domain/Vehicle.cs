﻿using System;

namespace Passenger.Core.Domain
{
    public class Vehicle //valueObject -> Inmutable
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public int Seats { get; protected set; }

        public Vehicle(string brand, string name, int seats)
        {
            SetBrand(brand);
            SetName(name);
            SetSeats(seats);
        }

        private void SetBrand(string brand)
        {
            if(string.IsNullOrWhiteSpace(brand))
               throw new Exception("Please provide valid brand.");
            if (Brand == brand)
                return;
            Brand = brand;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Please provide valid name.");
            if (Name == name)
                return;
            Name = name;
        }

        private void SetSeats(int seats)
        {
            if (seats < 0)
                throw new Exception("Please provide valid seats");
            if (seats > 9)
                throw new Exception("Please provide valid seats");
            Seats = seats;
        }
    }
}