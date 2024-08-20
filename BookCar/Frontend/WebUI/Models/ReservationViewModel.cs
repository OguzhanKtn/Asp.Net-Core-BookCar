using Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models
{
    public class ReservationViewModel
    {
        public CreateReservationDto Reservation { get; set; }
        public List<SelectListItem> Pricings { get; set; }
        public List<SelectListItem> Locations { get; set; }
    }
}
