using System.Data.Entity.Spatial;

namespace VastGIS.RealEstate.Data.Entity
{
    public abstract class BaseMapArea : IEntity, IFeature
    {
        public int Id { get; set; }
        public string Tc { get; set; }
        public string Cassdm { get; set; }
        public string Fsxx1 { get; set; }
        public string Fsxx2 { get; set; }
        public string Ysdm { get; set; }
        public DbGeometry Geometry { get; set; }
    }
}