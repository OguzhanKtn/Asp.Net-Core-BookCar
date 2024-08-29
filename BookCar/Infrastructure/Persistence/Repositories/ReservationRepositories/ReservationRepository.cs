using Application.Interfaces.ReservationInterfaces;
using Application.ViewModels;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarBookContext _context;

        public ReservationRepository(CarBookContext context)
        {
            _context = context;
        }

        public IEnumerable<ReservationViewModel> GetReservations()
        {
            var reservations = from res in _context.reservations
                               join lo in _context.locations on res.PickUpLocationID equals lo.LocationID
                               join lo2 in _context.locations on res.DropOffLocationID equals lo2.LocationID
                               select new ReservationViewModel
                               {
                                   Name = res.Name,
                                   Surname = res.Surname,
                                   Email = res.Email,
                                   Phone = res.Phone,
                                   Age = res.Age,
                                   DriverLicenseYear = res.DriverLicenseYear,
                                   CarID = res.CarID,
                                   PickUpLocation = lo.Name,
                                   DropOffLocation = lo2.Name,
                                   ReservationDate = res.ReservationDate.ToString("dd-MM-yyyy")
                               };
            return reservations;
        }
    }
}
