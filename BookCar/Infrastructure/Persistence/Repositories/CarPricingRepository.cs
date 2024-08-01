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
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public IQueryable<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.carPricings.Include(p => p.Car).ThenInclude(x => x.Brand).Include(y => y.Pricing).Where(z => z.PricingID == 2);
            return values;
        }
    }
}
