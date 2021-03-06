﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SQLite;
using VastGIS.RealEstate.Data.Dao;
using VastGIS.RealEstate.Data.Entity;
using VastGIS.RealEstate.Data.Enums;
using VastGIS.RealEstate.Data.Events;


namespace VastGIS.RealEstate.Data.Dao.Impl
{

    public partial class SystemDaoImpl:SQLiteDao,SystemDao
    {
        public Dictionary<string, string> _entityNames;
        //private SystemDao _systemDao;
        private string SELECT_VG_OBJECTCLASSES = "select Id,MC,DXLX,ZWMC,FBMC,XHZDMC,TXZDMC,TXLX,IDENTIFY,EDITABLE,QUERYABLE,SNAPABLE,VISIBLE,XSSX,FILTER,QSDM,BJCT from vg_objectclasses";
        
        private string SELECT_VG_SETTINGS = "select Id,CSMC,CSZ from vg_settings";
        
        private string SELECT_VG_CADCODES = "select Id,XH,SFCY,TC,CASSDM,TXLX,XTC,YSDM,YSLX,YSZL from vg_cadcodes";
        
        private string SELECT_VG_AREACODES = "select Id,XZQHMC,XZQHDM,XZQHJB from vg_areacodes";
        
        private string SELECT_VG_OBJECTYSDM = "select Id,YSDM,YSMC,XSSX,QSBG,QSFH,SFKJ from vg_objectysdm";
        
        private string SELECT_VG_LAYERGROUP = "select Id,ZM from vg_layergroup";
        
        private string SELECT_VG_LAYERGROUPDETAIL = "select Id,ZM,Mc,IDENTIFY,EDITABLE,QUERYABLE,SNAPABLE,VISIBLE from vg_layergroupdetail";
        
        private string SELECT_VG_CLASSGROUP = "select Id,GroupName,CreateImpl from vg_classgroup";
        
        private string SELECT_VG_CLASSDETAIL = "select Id,GroupName,TableName,CreateImpl,InterfaceName from vg_classdetail";
        
        private string SELECT_VG_FIELDINFO = "select Id,BM,BNSX,ZDZWMC,ZDMC,ZDLX,ZDCD,ZDXSWS,SYZD,YS,SYZDYW from vg_fieldinfo";
        
        
        public SystemDaoImpl(): base()
        {
            _entityNames=new Dictionary<string, string>();
            _entityNames.Add("VG_OBJECTCLASSES","");
            _entityNames.Add("VG_SETTINGS","");
            _entityNames.Add("VG_CADCODES","");
            _entityNames.Add("VG_AREACODES","");
            _entityNames.Add("VG_OBJECTYSDM","");
            _entityNames.Add("VG_LAYERGROUP","");
            _entityNames.Add("VG_LAYERGROUPDETAIL","");
            _entityNames.Add("VG_CLASSGROUP","");
            _entityNames.Add("VG_CLASSDETAIL","");
            _entityNames.Add("VG_FIELDINFO","");
        }
        
        private event EntityChangedEventHandler entityChanged;

        public event EntityChangedEventHandler EntityChanged
        {
            add { this.entityChanged += value; }
            remove { this.entityChanged -= value; }
        }

        public  void OnEntityChanged(string tableName, string layerName, EntityOperationType operationType, List<long> ids)
        {
            if (this.entityChanged != null)
            {
                this.entityChanged(this, new EntityChanedEventArgs(tableName, layerName, operationType, ids));
            }
        }
        
        public string GetLayerName(string tableName)
        {
            tableName=tableName.ToUpper();
            if(_entityNames.ContainsKey(tableName))
                return _entityNames[tableName];
            else
                return "";
        }
        
        ///VgObjectclasses函数
        public VgObjectclasses GetVgObjectclasses(long id)
        {
            string sql="select Id,MC,DXLX,ZWMC,FBMC,XHZDMC,TXZDMC,TXLX,IDENTIFY,EDITABLE,QUERYABLE,SNAPABLE,VISIBLE,XSSX,FILTER,QSDM,BJCT from vg_objectclasses" + " where id="+id.ToString();
            IEnumerable<VgObjectclasses> vgObjectclasss=connection.Query<VgObjectclasses>(sql);
            if(vgObjectclasss != null && vgObjectclasss.Count()>0)
            {
                return vgObjectclasss.First();
            }
            return null;
        }
        
        public IEnumerable<VgObjectclasses> GetVgObjectclassess(string filter)
        {
            string sql="select Id,MC,DXLX,ZWMC,FBMC,XHZDMC,TXZDMC,TXLX,IDENTIFY,EDITABLE,QUERYABLE,SNAPABLE,VISIBLE,XSSX,FILTER,QSDM,BJCT from vg_objectclasses" + " where "+filter;
            var vgObjectclasss=connection.Query<VgObjectclasses>(sql);
            
            return vgObjectclasss;
        }
        
        public bool SaveVgObjectclasses(VgObjectclasses vgObjectclass)
        {
            bool retVal= vgObjectclass.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_objectclasses",GetLayerName("vg_objectclasses"),EntityOperationType.Save,new List<long>{vgObjectclass.ID});
            }
            return retVal;
        }
        
        public void SaveVgObjectclassess(List<VgObjectclasses> vgObjectclasss)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgObjectclasss)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgObjectclasss.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_objectclasses",GetLayerName("vg_objectclasses"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgObjectclasses(VgObjectclasses record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_objectclasses",GetLayerName("vg_objectclasses"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgObjectclasses(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_objectclasses where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_objectclasses",GetLayerName("vg_objectclasses"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgObjectclasses(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_objectclasses";
                else
                    command.CommandText="delete from vg_objectclasses where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_objectclasses",GetLayerName("vg_objectclasses"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgSettings函数
        public VgSettings GetVgSettings(long id)
        {
            string sql="select Id,CSMC,CSZ from vg_settings" + " where id="+id.ToString();
            IEnumerable<VgSettings> vgSettings=connection.Query<VgSettings>(sql);
            if(vgSettings != null && vgSettings.Count()>0)
            {
                return vgSettings.First();
            }
            return null;
        }
        
        public IEnumerable<VgSettings> GetVgSettingss(string filter)
        {
            string sql="select Id,CSMC,CSZ from vg_settings" + " where "+filter;
            var vgSettings=connection.Query<VgSettings>(sql);
            
            return vgSettings;
        }
        
        public bool SaveVgSettings(VgSettings vgSetting)
        {
            bool retVal= vgSetting.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_settings",GetLayerName("vg_settings"),EntityOperationType.Save,new List<long>{vgSetting.ID});
            }
            return retVal;
        }
        
        public void SaveVgSettingss(List<VgSettings> vgSettings)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgSettings)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgSettings.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_settings",GetLayerName("vg_settings"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgSettings(VgSettings record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_settings",GetLayerName("vg_settings"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgSettings(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_settings where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_settings",GetLayerName("vg_settings"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgSettings(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_settings";
                else
                    command.CommandText="delete from vg_settings where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_settings",GetLayerName("vg_settings"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgCadcodes函数
        public VgCadcodes GetVgCadcodes(long id)
        {
            string sql="select Id,XH,SFCY,TC,CASSDM,TXLX,XTC,YSDM,YSLX,YSZL from vg_cadcodes" + " where id="+id.ToString();
            IEnumerable<VgCadcodes> vgCadcodes=connection.Query<VgCadcodes>(sql);
            if(vgCadcodes != null && vgCadcodes.Count()>0)
            {
                return vgCadcodes.First();
            }
            return null;
        }
        
        public IEnumerable<VgCadcodes> GetVgCadcodess(string filter)
        {
            string sql="select Id,XH,SFCY,TC,CASSDM,TXLX,XTC,YSDM,YSLX,YSZL from vg_cadcodes" + " where "+filter;
            var vgCadcodes=connection.Query<VgCadcodes>(sql);
            
            return vgCadcodes;
        }
        
        public bool SaveVgCadcodes(VgCadcodes vgCadcode)
        {
            bool retVal= vgCadcode.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_cadcodes",GetLayerName("vg_cadcodes"),EntityOperationType.Save,new List<long>{vgCadcode.ID});
            }
            return retVal;
        }
        
        public void SaveVgCadcodess(List<VgCadcodes> vgCadcodes)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgCadcodes)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgCadcodes.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_cadcodes",GetLayerName("vg_cadcodes"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgCadcodes(VgCadcodes record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_cadcodes",GetLayerName("vg_cadcodes"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgCadcodes(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_cadcodes where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_cadcodes",GetLayerName("vg_cadcodes"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgCadcodes(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_cadcodes";
                else
                    command.CommandText="delete from vg_cadcodes where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_cadcodes",GetLayerName("vg_cadcodes"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgAreacodes函数
        public VgAreacodes GetVgAreacodes(long id)
        {
            string sql="select Id,XZQHMC,XZQHDM,XZQHJB from vg_areacodes" + " where id="+id.ToString();
            IEnumerable<VgAreacodes> vgAreacodes=connection.Query<VgAreacodes>(sql);
            if(vgAreacodes != null && vgAreacodes.Count()>0)
            {
                return vgAreacodes.First();
            }
            return null;
        }
        
        public IEnumerable<VgAreacodes> GetVgAreacodess(string filter)
        {
            string sql="select Id,XZQHMC,XZQHDM,XZQHJB from vg_areacodes" + " where "+filter;
            var vgAreacodes=connection.Query<VgAreacodes>(sql);
            
            return vgAreacodes;
        }
        
        public bool SaveVgAreacodes(VgAreacodes vgAreacode)
        {
            bool retVal= vgAreacode.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_areacodes",GetLayerName("vg_areacodes"),EntityOperationType.Save,new List<long>{vgAreacode.ID});
            }
            return retVal;
        }
        
        public void SaveVgAreacodess(List<VgAreacodes> vgAreacodes)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgAreacodes)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgAreacodes.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_areacodes",GetLayerName("vg_areacodes"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgAreacodes(VgAreacodes record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_areacodes",GetLayerName("vg_areacodes"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgAreacodes(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_areacodes where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_areacodes",GetLayerName("vg_areacodes"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgAreacodes(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_areacodes";
                else
                    command.CommandText="delete from vg_areacodes where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_areacodes",GetLayerName("vg_areacodes"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgObjectysdm函数
        public VgObjectysdm GetVgObjectysdm(long id)
        {
            string sql="select Id,YSDM,YSMC,XSSX,QSBG,QSFH,SFKJ from vg_objectysdm" + " where id="+id.ToString();
            IEnumerable<VgObjectysdm> vgObjectysdms=connection.Query<VgObjectysdm>(sql);
            if(vgObjectysdms != null && vgObjectysdms.Count()>0)
            {
                return vgObjectysdms.First();
            }
            return null;
        }
        
        public IEnumerable<VgObjectysdm> GetVgObjectysdms(string filter)
        {
            string sql="select Id,YSDM,YSMC,XSSX,QSBG,QSFH,SFKJ from vg_objectysdm" + " where "+filter;
            var vgObjectysdms=connection.Query<VgObjectysdm>(sql);
            
            return vgObjectysdms;
        }
        
        public bool SaveVgObjectysdm(VgObjectysdm vgObjectysdm)
        {
            bool retVal= vgObjectysdm.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_objectysdm",GetLayerName("vg_objectysdm"),EntityOperationType.Save,new List<long>{vgObjectysdm.ID});
            }
            return retVal;
        }
        
        public void SaveVgObjectysdms(List<VgObjectysdm> vgObjectysdms)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgObjectysdms)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgObjectysdms.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_objectysdm",GetLayerName("vg_objectysdm"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgObjectysdm(VgObjectysdm record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_objectysdm",GetLayerName("vg_objectysdm"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgObjectysdm(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_objectysdm where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_objectysdm",GetLayerName("vg_objectysdm"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgObjectysdm(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_objectysdm";
                else
                    command.CommandText="delete from vg_objectysdm where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_objectysdm",GetLayerName("vg_objectysdm"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgLayergroup函数
        public VgLayergroup GetVgLayergroup(long id)
        {
            string sql="select Id,ZM from vg_layergroup" + " where id="+id.ToString();
            IEnumerable<VgLayergroup> vgLayergroups=connection.Query<VgLayergroup>(sql);
            if(vgLayergroups != null && vgLayergroups.Count()>0)
            {
                return vgLayergroups.First();
            }
            return null;
        }
        
        public IEnumerable<VgLayergroup> GetVgLayergroups(string filter)
        {
            string sql="select Id,ZM from vg_layergroup" + " where "+filter;
            var vgLayergroups=connection.Query<VgLayergroup>(sql);
            
            return vgLayergroups;
        }
        
        public bool SaveVgLayergroup(VgLayergroup vgLayergroup)
        {
            bool retVal= vgLayergroup.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_layergroup",GetLayerName("vg_layergroup"),EntityOperationType.Save,new List<long>{vgLayergroup.ID});
            }
            return retVal;
        }
        
        public void SaveVgLayergroups(List<VgLayergroup> vgLayergroups)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgLayergroups)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgLayergroups.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_layergroup",GetLayerName("vg_layergroup"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgLayergroup(VgLayergroup record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_layergroup",GetLayerName("vg_layergroup"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgLayergroup(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_layergroup where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_layergroup",GetLayerName("vg_layergroup"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgLayergroup(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_layergroup";
                else
                    command.CommandText="delete from vg_layergroup where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_layergroup",GetLayerName("vg_layergroup"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgLayergroupdetail函数
        public VgLayergroupdetail GetVgLayergroupdetail(long id)
        {
            string sql="select Id,ZM,Mc,IDENTIFY,EDITABLE,QUERYABLE,SNAPABLE,VISIBLE from vg_layergroupdetail" + " where id="+id.ToString();
            IEnumerable<VgLayergroupdetail> vgLayergroupdetails=connection.Query<VgLayergroupdetail>(sql);
            if(vgLayergroupdetails != null && vgLayergroupdetails.Count()>0)
            {
                return vgLayergroupdetails.First();
            }
            return null;
        }
        
        public IEnumerable<VgLayergroupdetail> GetVgLayergroupdetails(string filter)
        {
            string sql="select Id,ZM,Mc,IDENTIFY,EDITABLE,QUERYABLE,SNAPABLE,VISIBLE from vg_layergroupdetail" + " where "+filter;
            var vgLayergroupdetails=connection.Query<VgLayergroupdetail>(sql);
            
            return vgLayergroupdetails;
        }
        
        public bool SaveVgLayergroupdetail(VgLayergroupdetail vgLayergroupdetail)
        {
            bool retVal= vgLayergroupdetail.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_layergroupdetail",GetLayerName("vg_layergroupdetail"),EntityOperationType.Save,new List<long>{vgLayergroupdetail.ID});
            }
            return retVal;
        }
        
        public void SaveVgLayergroupdetails(List<VgLayergroupdetail> vgLayergroupdetails)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgLayergroupdetails)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgLayergroupdetails.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_layergroupdetail",GetLayerName("vg_layergroupdetail"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgLayergroupdetail(VgLayergroupdetail record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_layergroupdetail",GetLayerName("vg_layergroupdetail"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgLayergroupdetail(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_layergroupdetail where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_layergroupdetail",GetLayerName("vg_layergroupdetail"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgLayergroupdetail(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_layergroupdetail";
                else
                    command.CommandText="delete from vg_layergroupdetail where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_layergroupdetail",GetLayerName("vg_layergroupdetail"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgClassgroup函数
        public VgClassgroup GetVgClassgroup(long id)
        {
            string sql="select Id,GroupName,CreateImpl from vg_classgroup" + " where id="+id.ToString();
            IEnumerable<VgClassgroup> vgClassgroups=connection.Query<VgClassgroup>(sql);
            if(vgClassgroups != null && vgClassgroups.Count()>0)
            {
                return vgClassgroups.First();
            }
            return null;
        }
        
        public IEnumerable<VgClassgroup> GetVgClassgroups(string filter)
        {
            string sql="select Id,GroupName,CreateImpl from vg_classgroup" + " where "+filter;
            var vgClassgroups=connection.Query<VgClassgroup>(sql);
            
            return vgClassgroups;
        }
        
        public bool SaveVgClassgroup(VgClassgroup vgClassgroup)
        {
            bool retVal= vgClassgroup.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_classgroup",GetLayerName("vg_classgroup"),EntityOperationType.Save,new List<long>{vgClassgroup.ID});
            }
            return retVal;
        }
        
        public void SaveVgClassgroups(List<VgClassgroup> vgClassgroups)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgClassgroups)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgClassgroups.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_classgroup",GetLayerName("vg_classgroup"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgClassgroup(VgClassgroup record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_classgroup",GetLayerName("vg_classgroup"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgClassgroup(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_classgroup where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_classgroup",GetLayerName("vg_classgroup"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgClassgroup(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_classgroup";
                else
                    command.CommandText="delete from vg_classgroup where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_classgroup",GetLayerName("vg_classgroup"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgClassdetail函数
        public VgClassdetail GetVgClassdetail(long id)
        {
            string sql="select Id,GroupName,TableName,CreateImpl,InterfaceName from vg_classdetail" + " where id="+id.ToString();
            IEnumerable<VgClassdetail> vgClassdetails=connection.Query<VgClassdetail>(sql);
            if(vgClassdetails != null && vgClassdetails.Count()>0)
            {
                return vgClassdetails.First();
            }
            return null;
        }
        
        public IEnumerable<VgClassdetail> GetVgClassdetails(string filter)
        {
            string sql="select Id,GroupName,TableName,CreateImpl,InterfaceName from vg_classdetail" + " where "+filter;
            var vgClassdetails=connection.Query<VgClassdetail>(sql);
            
            return vgClassdetails;
        }
        
        public bool SaveVgClassdetail(VgClassdetail vgClassdetail)
        {
            bool retVal= vgClassdetail.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_classdetail",GetLayerName("vg_classdetail"),EntityOperationType.Save,new List<long>{vgClassdetail.ID});
            }
            return retVal;
        }
        
        public void SaveVgClassdetails(List<VgClassdetail> vgClassdetails)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgClassdetails)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgClassdetails.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_classdetail",GetLayerName("vg_classdetail"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgClassdetail(VgClassdetail record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_classdetail",GetLayerName("vg_classdetail"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgClassdetail(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_classdetail where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_classdetail",GetLayerName("vg_classdetail"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgClassdetail(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_classdetail";
                else
                    command.CommandText="delete from vg_classdetail where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_classdetail",GetLayerName("vg_classdetail"),EntityOperationType.Delete,null);
            }
        }
        
        
        ///VgFieldinfo函数
        public VgFieldinfo GetVgFieldinfo(long id)
        {
            string sql="select Id,BM,BNSX,ZDZWMC,ZDMC,ZDLX,ZDCD,ZDXSWS,SYZD,YS,SYZDYW from vg_fieldinfo" + " where id="+id.ToString();
            IEnumerable<VgFieldinfo> vgFieldinfos=connection.Query<VgFieldinfo>(sql);
            if(vgFieldinfos != null && vgFieldinfos.Count()>0)
            {
                return vgFieldinfos.First();
            }
            return null;
        }
        
        public IEnumerable<VgFieldinfo> GetVgFieldinfos(string filter)
        {
            string sql="select Id,BM,BNSX,ZDZWMC,ZDMC,ZDLX,ZDCD,ZDXSWS,SYZD,YS,SYZDYW from vg_fieldinfo" + " where "+filter;
            var vgFieldinfos=connection.Query<VgFieldinfo>(sql);
            
            return vgFieldinfos;
        }
        
        public bool SaveVgFieldinfo(VgFieldinfo vgFieldinfo)
        {
            bool retVal= vgFieldinfo.Save(connection);
            if(retVal)
            {
                OnEntityChanged("vg_fieldinfo",GetLayerName("vg_fieldinfo"),EntityOperationType.Save,new List<long>{vgFieldinfo.ID});
            }
            return retVal;
        }
        
        public void SaveVgFieldinfos(List<VgFieldinfo> vgFieldinfos)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in vgFieldinfos)
            {
                rec.Save(connection);
            }
            tran.Commit();
            tran.Dispose();
            List<long> ids=vgFieldinfos.Select(a => a.ID).ToList(); 
            OnEntityChanged("vg_fieldinfo",GetLayerName("vg_fieldinfo"),EntityOperationType.Save,ids);
        }
        
        public void DeleteVgFieldinfo(VgFieldinfo record)
        {
            record.Delete(connection);
            OnEntityChanged("vg_fieldinfo",GetLayerName("vg_fieldinfo"),EntityOperationType.Delete,new List<long>{record.ID});
        }
        
        public void DeleteVgFieldinfo(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from vg_fieldinfo where Id=" + id.ToString();
                command.ExecuteNonQuery();
                OnEntityChanged("vg_fieldinfo",GetLayerName("vg_fieldinfo"),EntityOperationType.Delete,new List<long>{id});
            }
        }
        
        public void DeleteVgFieldinfo(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from vg_fieldinfo";
                else
                    command.CommandText="delete from vg_fieldinfo where " + filter;
                command.ExecuteNonQuery();
                OnEntityChanged("vg_fieldinfo",GetLayerName("vg_fieldinfo"),EntityOperationType.Delete,null);
            }
        }
        
        
        
        
    }
}



