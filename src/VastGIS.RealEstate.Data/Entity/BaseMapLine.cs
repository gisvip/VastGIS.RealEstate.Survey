using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public abstract class BaseMapLine : Feature, IEntity
    {
        public int Id { get; set; }
        public string Tc { get; set; }
        public string Cassdm { get; set; }
        public string Xx { get; set; }
        public double? Fhdx { get; set; }
        public string Fsxx1 { get; set; }
        public string Fsxx2 { get; set; }
        public string Ysdm { get; set; }
       
    }
}