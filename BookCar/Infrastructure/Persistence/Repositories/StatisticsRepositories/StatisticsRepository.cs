using Application.Interfaces.StatisticsInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string BrandNameByMaxCar()
        {
            //select top(1) BrandID, count(*) as NumberOfBrand from cars group by BrandID order by NumberOfBrand desc
            var result = _context.cars
                .GroupBy(x => x.BrandID)
                .Select(y => new
            {
                  BrandID =  y.Key,
                  NumberOfBrand = y.Count()
            })
            .OrderByDescending(x => x.NumberOfBrand).FirstOrDefault();

            int brandID = result.BrandID;

            string brandName = _context.brands.Where(x => x.BrandID == brandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //Select Avg(Amount) from CarPricings where PricingID = (Select PricingID From Pricings Where Name = 'Günlük')
            int id = _context.pricings.Where(x => x.Name.Equals("Günlük")).Select(y => y.PricingID).FirstOrDefault();
            var value = _context.carPricings.Where(x => x.PricingID == id).Average(y => y.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.pricings.Where(x => x.Name.Equals("Aylık")).Select(y => y.PricingID).FirstOrDefault();
            var value = _context.carPricings.Where(x => x.PricingID == id).Average(y => y.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.pricings.Where(x => x.Name.Equals("Haftalık")).Select(y => y.PricingID).FirstOrDefault();
            var value = _context.carPricings.Where(x => x.PricingID == id).Average(y => y.Amount);
            return value;
        }

        public int GetBrandCount()
        {
            return _context.brands.Count();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            // select * from CarPricings where PricingID = (select PricingID from Pricings where Name = 'Günlük')
            // and Amount = (select Max(Amount) from CarPricings where PricingID = (select PricingID from Pricings where Name = 'Günlük'))

            int pricingID = _context.pricings.Where(x => x.Name.Equals("Günlük")).Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.carPricings.Where(x => x.PricingID == pricingID).Select(x => x.Amount).Max();
            int carID = _context.carPricings.Where(x => x.PricingID == pricingID && x.Amount == amount).Select(y => y.CarID).FirstOrDefault();

            string brandModel = _context.cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();

            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin() 
        {
            int pricingID = _context.pricings.Where(x => x.Name.Equals("Günlük")).Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.carPricings.Where(x => x.PricingID == pricingID).Select(x => x.Amount).Min();
            int carID = _context.carPricings.Where(x => x.PricingID == pricingID && x.Amount == amount).Select(y => y.CarID).FirstOrDefault();

            string brandModel = _context.cars.Where(x => x.CarID == carID).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();

            return brandModel;
        }

        public int GetCarCount()
        {
            return _context.cars.Count();
        }

        public int GetCarCountByFuelDiesel()
        {
            return _context.cars.Where(x => x.Fuel.Equals("Dizel")).Count();
        }

        public int GetCarCountByFuelElectric()
        {
            return _context.cars.Where(x => x.Fuel.Equals("Elektrik")).Count();
        }

        public int GetCarCountByFuelGasoline()
        {
            return _context.cars.Where(x => x.Fuel.Equals("Benzin")).Count();
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            return _context.cars.Where(x => x.Km <= 1000).Count();
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.cars.Where(x => x.Transmission.Equals("Otomatik")).Count();
            return value;
        }

        public int GetLocationCount()
        {
            return _context.locations.Count();
        }
    }
}
