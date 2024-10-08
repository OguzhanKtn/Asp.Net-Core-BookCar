﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeaturesByCarID(int id);
        void ChangeCarFeatureAvailableToFalse(int id);
        void ChangeCarFeatureAvailableToTrue(int id);
        void CreateCarFeatureByCar(List<CarFeature> carFeatures);
    }
}
