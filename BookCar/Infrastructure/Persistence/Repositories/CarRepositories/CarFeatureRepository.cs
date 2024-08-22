using Application.Interfaces.CarInterfaces;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CarRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarFeature> GetCarFeaturesByCarID(int id)
        {
            var values = _context.carFeatures.Where(x => x.CarID == id).ToList();
            return values;
        }
    }
}
