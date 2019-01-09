﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlantApp.Domain
{
    class Plant
    {
        public string Name { get; set; }
        public int PlantId { get; set; }
        public string LatinName { get; set; }
        public int LocationId { get; set; }
        public int WaterFrekuenseInDays { get; set; }
        public int PlantTypeId { get; set; }
        public int ScentId { get; set; }
        public int SoilId { get; set; }
        public int NutritionId { get; set; }
        public int OriginId { get; set; }
        public int PoisonId { get; set; }
        public int GeneralInfo { get; set; }

    }
}