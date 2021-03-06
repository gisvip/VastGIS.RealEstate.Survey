﻿namespace VastGIS.RealEstate.Data.Interface
{
    public interface IDatabaseEntity
    {
        long ID { get; set; }
        long? DatabaseID { get; set; }
        short? Flags { get; set; }
    }
}