using System;
namespace CarRentalACC.Data
{
	public class Reservation
	{

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AuthorId { get; set; }
        public Car Car { get; set; } = null!;

    }
}

