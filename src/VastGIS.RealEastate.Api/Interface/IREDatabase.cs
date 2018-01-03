﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.RealEstate.Api.Enums;
using VastGIS.RealEstate.Data;
using VastGIS.RealEstate.Data.Entity;
using VastGIS.RealEstate.Data.Enums;
using VastGIS.Services.Views;

namespace VastGIS.RealEstate.Api.Interface
{
    public interface IREDatabase
    {
        string DatabaseName { get; set; }
        int EpsgCode { get; set; }
        List<IObjectClass> GetObjectClasses();
        List<IObjectClass> GetClasses(bool IsRecursion = true);
        bool InitREDatabase(int epsgCode,ProjectLoadingView loadingForm,out string errorMsg);
        ICodeDomain GetDomain(string domainName);
        bool CheckDatabase();

        #region CAD数据处理
        void SplitTmpCadIntoLayers(string cadLayerName, string tableName, string fileName = "", bool isClear = true);

        void ImportDxfDrawing(string dxfName, ProjectLoadingView loadingForm,string codePage="CP936", CADInsertMethod insertMthod=CADInsertMethod.DeleteByFileName);
        bool HasCADData(string fileName);

        void AssignTextToPolygon(
            AssignTextType assignType,
            string polyTable,
            string polyFieldName,
            string textTable,
            string textFieldName,
            string whereClause,
            object values);
        #endregion

        IFeature FindFirstRecord(string[] getSearchLayers, double dx, double dy);
    }

    public interface IRealEstateContext
    {
       IREDatabase RealEstateDatabase { get; set; }

        bool CheckDatabase();
    }
}
