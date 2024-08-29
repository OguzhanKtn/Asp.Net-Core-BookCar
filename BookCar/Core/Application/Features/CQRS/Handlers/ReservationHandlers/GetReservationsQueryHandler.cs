using Application.Features.CQRS.Queries.ReservationQueries;
using Application.Features.CQRS.Results.ReservationResults;
using Application.Interfaces.ReservationInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ReservationHandlers
{
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, IEnumerable<GetReservationsQueryResult>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<GetReservationsQueryResult>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = _reservationRepository.GetReservations();
          return  reservations.Select(x => new GetReservationsQueryResult
            {
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Age = x.Age,
                DriverLicenseYear = x.DriverLicenseYear,
                CarID = x.CarID,
                PickUpLocation = x.PickUpLocation,
                DropOffLocation = x.DropOffLocation,
                ReservationDate = x.ReservationDate,
            }).ToList();
        }
    }
}
