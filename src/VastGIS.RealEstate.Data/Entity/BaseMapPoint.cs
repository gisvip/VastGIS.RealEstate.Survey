﻿using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public abstract class BaseMapPoint : Feature, IEntity
    {
        public int Id { get; set; }
        public string Tc { get; set; }
        public string Cassdm { get; set; }
        public string Fh { get; set; }
        public double? Fhdx { get; set; }
        public double? Xzjd { get; set; }
        public string Fsxx1 { get; set; }
        public string Fsxx2 { get; set; }
        public string Ysdm { get; set; }
      
    }
}