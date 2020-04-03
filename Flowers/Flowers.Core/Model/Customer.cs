using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowers.Core.Model
{
    public class Customer
    {
        private int _CustomerID {get; set;}
        private string _Username;
        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _FirstName = value;
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _LastName = value;
            }
        }

        public string Username
        {
            get => _Username;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _Username = value;
            }
        }
      public List<Order> Order { get; set; } = new List<Order>();

    }
}