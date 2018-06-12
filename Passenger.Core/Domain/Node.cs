using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public string Address { get; protected set; }
        public double Latitude { get; protected set; }
        public double Longitude { get; protected set; }
        public DateTime UpdateAt { get; protected set; }

        protected Node()
        {
        }

        protected Node(string address, double latitude, double longitude)
        {
            SetAddress(address);
            SetLatitude(latitude);
            SetLongitude(longitude);
        }

        private void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new Exception("Addres is empty.");

            Address = address;
            UpdateAt = DateTime.UtcNow;
        }

        private void SetLatitude(double latitude)
        {
            if (double.IsNaN(latitude))
                throw new Exception("Latitude must be a number");
            if (Latitude == latitude)
                return;

            Latitude = latitude;
            UpdateAt = DateTime.UtcNow;
        }

        private void SetLongitude(double longitude)
        {
            if (double.IsNaN(longitude))
                throw new Exception("Longitude must be a number");
            if (Longitude == Longitude)
                return;

            Longitude = longitude;
            UpdateAt = DateTime.UtcNow;
        }

        public static Node Create(string address, double latitude, double longitude)
            => new Node(address, latitude, longitude);

    }
}
