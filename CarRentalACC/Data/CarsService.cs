using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarRentalACC.Data
{
	public class CarsService : ICarsService
	{

		private DataContext _dataContext;

		public CarsService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddCar(string model, string description, float price)
		{
			var car = new Car {Model = model, Description = description, Price = price};
			_dataContext.Cars.Add(car);
			await _dataContext.SaveChangesAsync();
		}

        public async Task RemoveCar(int id)
		{
			Car car = new Car() { Id = id };
			_dataContext.Cars.Remove(car);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Car>> GetCars()
        {
            return await _dataContext.Cars.ToListAsync();
        }

    }
}

