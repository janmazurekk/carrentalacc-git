using System;
namespace CarRentalACC.Data
{
	public interface ICarsService
	{

		public Task AddCar(string model, string description, float price);
		public Task RemoveCar(int id);
        public Task<List<Car>> GetCars();

    }
}

