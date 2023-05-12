using System;
namespace CarRentalACC.Data
{
    public class Car
    {

        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}

