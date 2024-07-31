using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetCarsWithBrands()
        {
            return _context.cars.Include(x=> x.Brand).ToList();
        }

        public IQueryable<Car> GetLast5CarsWithBrands()
        {
            return _context.cars.Include(_x => _x.Brand).OrderByDescending(x => x.CarID).Take(5);
        }
    }
}
