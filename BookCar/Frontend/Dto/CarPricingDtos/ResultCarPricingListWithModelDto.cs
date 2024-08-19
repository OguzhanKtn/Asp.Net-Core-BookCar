using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.CarPricingDtos
{
	public class ResultCarPricingListWithModelDto
	{
        public int carID { get; set; }
        public string model { get; set; }
        public string brand { get; set; }
        public string coverImageUrl { get; set; }
        public decimal dailyAmount { get; set; }
        public decimal weeklyAmount { get; set; }
        public decimal monthlyAmount { get; set; }
    }
}
