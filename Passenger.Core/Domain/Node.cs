using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class Node
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-[_.-])$");

        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Node()
        {
        }

        protected Node(string address, double longitude, double latitude)
        {
            SetAdress(address);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public void SetAdress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Address can't be empty!");
            }
            if (Address == address)
                return;

            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLongitude(double longitude)
        {
            if (Double.IsNaN(longitude))
            {
                throw new Exception("Value must be a number!");
            }
            if (Longitude == longitude)
                return;

            Longitude = longitude;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLatitude(double latitude)
        {
            if (Double.IsNaN(latitude))
            {
                throw new Exception("Value must be a number!");
            }
            if (Latitude == latitude)
                return;

            Latitude = latitude;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Node Create(string address, double longitude, double latitude)
            => new Node(address,longitude,latitude);
    }
}