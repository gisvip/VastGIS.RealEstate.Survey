﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using VastGIS.RealEstate.Data.Entity;
using VastGIS.RealEstate.Data.Enums;
using VastGIS.RealEstate.Data.Interface;

namespace VastGIS.RealEstate.Data.Service.Impl
{

    public partial class SystemServiceImpl
    {
        public void CreateEmptyDatabase(string dbName)
        {
            _systemDao.CreateEmptyDatabase(dbName);
        }

        public void InternalInitTables()
        {
            _systemDao.InternalInitTables();
        }

        public bool InitTables()
        {
            return _systemDao.InitTables();
        }

        public void Close()
        {
            _systemDao.Close();
        }

        public int GetGeometryColumnSRID(string tableName, string columnName)
        {
            return _systemDao.GetGeometryColumnSRID(tableName, columnName);
        }

        public int GetSystemSRID()
        {
            return _systemDao.GetSystemSRID();
        }

        public void AssignTextToPolygon(
            AssignTextType assignType,
            string polyTable,
            string polyFieldName,
            string textTable,
            string textFieldName,
            string whereClause,
            object values)
        {
            _systemDao.AssignTextToPolygon(assignType, polyTable, polyFieldName, textTable, textFieldName, whereClause, values);
        }


        public IFeature FindFirstRecord(string[] getSearchLayers, double dx, double dy)
        {
            return _systemDao.FindFirstRecord(getSearchLayers, dx, dy);
        }

        public bool CopyFeature(
            string sourceTable,
            int id,
            string targetTable,
            bool isDelete = false,
            bool isAttributeAutoTransform = true)
        {
            return _systemDao.CopyFeature(sourceTable, id, targetTable, isDelete, isAttributeAutoTransform);
        }

        public List<VgObjectclasses> GetObjectclasseses(bool isDeep = true)
        {
            return _systemDao.GetObjectclasseses(isDeep);
        }

        public bool SaveVgSettings2(VgSettings setting)
        {
            return _systemDao.SaveVgSettings2(setting);
        }

        public bool SaveVgSettings2(string csmc, string csz)
        {
            return _systemDao.SaveVgSettings2(csmc,csz);
        }

        public VgSettings GetVgSettings(string csmc)
        {
            return _systemDao.GetVgSettings(csmc);
        }

        public void InitSettings()
        {
            _systemDao.InitSettings();
        }

        public IEnumerable<VgAreacodes> GetAreaCodesByJB(string parentCode, int jb = 1)
        {
            return _systemDao.GetAreaCodesByJB(parentCode, jb);
        }
    }
}



