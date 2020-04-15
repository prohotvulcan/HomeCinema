using System;
using System.Collections.Generic;

namespace homeCinema.Data.Entities
{
    public class Customer : IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityCard { get; set; }
        public Guid UniqueKey { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<Rental> Rentals { get; set; }

        public Customer()
        {
            Rentals = new List<Rental>();
        }
    }
}
