﻿using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarInterfaces
{
    public interface ICarPricingRepository
    {
        IQueryable<CarPricing> GetCarPricingWithCars();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();
    }
}
