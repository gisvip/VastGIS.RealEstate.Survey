﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SQLite;
using VastGIS.RealEstate.Data.Entity;
using VastGIS.RealEstate.Data.Enums;


namespace VastGIS.RealEstate.Data.Dao.Impl
{

    public partial class ZdDaoImpl:SQLiteDao,ZdDao
    {
        //private ZdDao _zdDao;
        string SELECT_DJQ = "select Id,YSDM,DJQDM,DJQMC,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,geometry from DJQ Where [FLAGS] < 3";
        
        string SELECT_DJZQ = "select Id,YSDM,DJZQDM,DJZQMC,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,geometry from DJZQ Where [FLAGS] < 3";
        
        string SELECT_JZD = "select Id,ZDZHDM,YSDM,JZDH,JZDGZBH,SXH,JBLX,JZDLX,XZBZ,YZBZ,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,geometry from JZD Where [FLAGS] < 3";
        
        string SELECT_JZDZJ = "select Id,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,geometry from JZDZJ Where [FLAGS] < 3";
        
        string SELECT_JZX = "select Id,ZDZHDM,YSDM,JZXGZBH,JZXCD,JZXLB,JZXWZ,JXXZ,QSJXXYSBH,QSJXXYS,QSZYYYSBH,QSZYYYS,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,QSJZDBH,JZJZDBH,DatabaseId,FLAGS,geometry from JZX Where [FLAGS] < 3";
        
        string SELECT_JZXZJ = "select Id,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,geometry from JZXZJ Where [FLAGS] < 3";
        
        string SELECT_XZQ = "select Id,YSDM,XZQDM,XZQMC,XZQMJ,DatabaseId,FLAGS,geometry from XZQ Where [FLAGS] < 3";
        
        string SELECT_XZQJX = "select Id,YSDM,JXLX,JXXZ,JXSM,DatabaseId,FLAGS,geometry from XZQJX Where [FLAGS] < 3";
        
        string SELECT_ZDBHQK = "select Id,ZDDM,BHYY,BHNR,DJSJ,DBR,FJ,DatabaseId,FLAGS from ZDBHQK Where [FLAGS] < 3";
        
        string SELECT_ZDJBXX = "select Id,YSDM,ZDDM,BDCDYH,ZDTZM,ZL,ZDMJ,MJDW,YT,DJ,JG,QLLX,QLXZ,QLSDFS,RJL,JZMD,JZXG,ZDSZD,ZDSZN,ZDSZX,ZDSZB,ZDT,TFH,DJH,DAH,BZ,ZT,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,geometry from ZDJBXX Where [FLAGS] < 3";
        
        string SELECT_ZDJBXXZJ = "select Id,GLYSDM,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,geometry from ZDJBXXZJ Where [FLAGS] < 3";
        
        string SELECT_ZDTOJZD = "select Id,ZD_WYDM,JZD_WYDM,SXH from ZDTOJZD";
        
        string SELECT_ZDTOJZX = "select Id,ZD_WYDM,JZX_WYDM,SXH from ZDTOJZX";
        
        
        ///Djq函数
        public Djq GetDjq(long id)
        {
            string sql="select Id,YSDM,DJQDM,DJQMC,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from DJQ" + " where id="+id.ToString();
            IEnumerable<Djq> djqs=connection.Query<Djq>(sql);
            if(djqs != null && djqs.Count()>0)
            {
                return djqs.First();
            }
            return null;
        }
        
        public IEnumerable<Djq> GetDjqs(string filter)
        {
            string sql="select Id,YSDM,DJQDM,DJQMC,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from DJQ" + " where "+filter;
            var djqs=connection.Query<Djq>(sql);
            
            return djqs;
        }
        
        public bool SaveDjq(Djq djq)
        {
            return djq.Save(connection,GetSRID());
        }
        
        public void SaveDjqs(List<Djq> djqs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in djqs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteDjq(Djq record)
        {
            record.Delete(connection);
        }
        
        public void DeleteDjq(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Djq row=this.GetDjq(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from DJQ where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update DJQ set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteDjq(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Djq> rows=GetDjqs(filter);
                foreach(Djq row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Djzq函数
        public Djzq GetDjzq(long id)
        {
            string sql="select Id,YSDM,DJZQDM,DJZQMC,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from DJZQ" + " where id="+id.ToString();
            IEnumerable<Djzq> djzqs=connection.Query<Djzq>(sql);
            if(djzqs != null && djzqs.Count()>0)
            {
                return djzqs.First();
            }
            return null;
        }
        
        public IEnumerable<Djzq> GetDjzqs(string filter)
        {
            string sql="select Id,YSDM,DJZQDM,DJZQMC,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from DJZQ" + " where "+filter;
            var djzqs=connection.Query<Djzq>(sql);
            
            return djzqs;
        }
        
        public bool SaveDjzq(Djzq djzq)
        {
            return djzq.Save(connection,GetSRID());
        }
        
        public void SaveDjzqs(List<Djzq> djzqs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in djzqs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteDjzq(Djzq record)
        {
            record.Delete(connection);
        }
        
        public void DeleteDjzq(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Djzq row=this.GetDjzq(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from DJZQ where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update DJZQ set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteDjzq(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Djzq> rows=GetDjzqs(filter);
                foreach(Djzq row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Jzd函数
        public Jzd GetJzd(long id)
        {
            string sql="select Id,ZDZHDM,YSDM,JZDH,JZDGZBH,SXH,JBLX,JZDLX,XZBZ,YZBZ,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZD" + " where id="+id.ToString();
            IEnumerable<Jzd> jzds=connection.Query<Jzd>(sql);
            if(jzds != null && jzds.Count()>0)
            {
                return jzds.First();
            }
            return null;
        }
        
        public IEnumerable<Jzd> GetJzds(string filter)
        {
            string sql="select Id,ZDZHDM,YSDM,JZDH,JZDGZBH,SXH,JBLX,JZDLX,XZBZ,YZBZ,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZD" + " where "+filter;
            var jzds=connection.Query<Jzd>(sql);
            
            return jzds;
        }
        
        public bool SaveJzd(Jzd jzd)
        {
            return jzd.Save(connection,GetSRID());
        }
        
        public void SaveJzds(List<Jzd> jzds)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in jzds)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteJzd(Jzd record)
        {
            record.Delete(connection);
        }
        
        public void DeleteJzd(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Jzd row=this.GetJzd(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from JZD where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update JZD set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteJzd(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Jzd> rows=GetJzds(filter);
                foreach(Jzd row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Jzdzj函数
        public Jzdzj GetJzdzj(long id)
        {
            string sql="select Id,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZDZJ" + " where id="+id.ToString();
            IEnumerable<Jzdzj> jzdzjs=connection.Query<Jzdzj>(sql);
            if(jzdzjs != null && jzdzjs.Count()>0)
            {
                return jzdzjs.First();
            }
            return null;
        }
        
        public IEnumerable<Jzdzj> GetJzdzjs(string filter)
        {
            string sql="select Id,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZDZJ" + " where "+filter;
            var jzdzjs=connection.Query<Jzdzj>(sql);
            
            return jzdzjs;
        }
        
        public bool SaveJzdzj(Jzdzj jzdzj)
        {
            return jzdzj.Save(connection,GetSRID());
        }
        
        public void SaveJzdzjs(List<Jzdzj> jzdzjs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in jzdzjs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteJzdzj(Jzdzj record)
        {
            record.Delete(connection);
        }
        
        public void DeleteJzdzj(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Jzdzj row=this.GetJzdzj(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from JZDZJ where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update JZDZJ set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteJzdzj(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Jzdzj> rows=GetJzdzjs(filter);
                foreach(Jzdzj row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Jzx函数
        public Jzx GetJzx(long id)
        {
            string sql="select Id,ZDZHDM,YSDM,JZXGZBH,JZXCD,JZXLB,JZXWZ,JXXZ,QSJXXYSBH,QSJXXYS,QSZYYYSBH,QSZYYYS,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,QSJZDBH,JZJZDBH,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZX" + " where id="+id.ToString();
            IEnumerable<Jzx> jzxs=connection.Query<Jzx>(sql);
            if(jzxs != null && jzxs.Count()>0)
            {
                return jzxs.First();
            }
            return null;
        }
        
        public IEnumerable<Jzx> GetJzxs(string filter)
        {
            string sql="select Id,ZDZHDM,YSDM,JZXGZBH,JZXCD,JZXLB,JZXWZ,JXXZ,QSJXXYSBH,QSJXXYS,QSZYYYSBH,QSZYYYS,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,QSJZDBH,JZJZDBH,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZX" + " where "+filter;
            var jzxs=connection.Query<Jzx>(sql);
            
            return jzxs;
        }
        
        public bool SaveJzx(Jzx jzx)
        {
            return jzx.Save(connection,GetSRID());
        }
        
        public void SaveJzxs(List<Jzx> jzxs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in jzxs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteJzx(Jzx record)
        {
            record.Delete(connection);
        }
        
        public void DeleteJzx(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Jzx row=this.GetJzx(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from JZX where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update JZX set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteJzx(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Jzx> rows=GetJzxs(filter);
                foreach(Jzx row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Jzxzj函数
        public Jzxzj GetJzxzj(long id)
        {
            string sql="select Id,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZXZJ" + " where id="+id.ToString();
            IEnumerable<Jzxzj> jzxzjs=connection.Query<Jzxzj>(sql);
            if(jzxzjs != null && jzxzjs.Count()>0)
            {
                return jzxzjs.First();
            }
            return null;
        }
        
        public IEnumerable<Jzxzj> GetJzxzjs(string filter)
        {
            string sql="select Id,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,AsText(geometry) as Wkt from JZXZJ" + " where "+filter;
            var jzxzjs=connection.Query<Jzxzj>(sql);
            
            return jzxzjs;
        }
        
        public bool SaveJzxzj(Jzxzj jzxzj)
        {
            return jzxzj.Save(connection,GetSRID());
        }
        
        public void SaveJzxzjs(List<Jzxzj> jzxzjs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in jzxzjs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteJzxzj(Jzxzj record)
        {
            record.Delete(connection);
        }
        
        public void DeleteJzxzj(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Jzxzj row=this.GetJzxzj(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from JZXZJ where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update JZXZJ set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteJzxzj(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Jzxzj> rows=GetJzxzjs(filter);
                foreach(Jzxzj row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Xzq函数
        public Xzq GetXzq(long id)
        {
            string sql="select Id,YSDM,XZQDM,XZQMC,XZQMJ,DatabaseId,FLAGS,AsText(geometry) as Wkt from XZQ" + " where id="+id.ToString();
            IEnumerable<Xzq> xzqs=connection.Query<Xzq>(sql);
            if(xzqs != null && xzqs.Count()>0)
            {
                return xzqs.First();
            }
            return null;
        }
        
        public IEnumerable<Xzq> GetXzqs(string filter)
        {
            string sql="select Id,YSDM,XZQDM,XZQMC,XZQMJ,DatabaseId,FLAGS,AsText(geometry) as Wkt from XZQ" + " where "+filter;
            var xzqs=connection.Query<Xzq>(sql);
            
            return xzqs;
        }
        
        public bool SaveXzq(Xzq xzq)
        {
            return xzq.Save(connection,GetSRID());
        }
        
        public void SaveXzqs(List<Xzq> xzqs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in xzqs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteXzq(Xzq record)
        {
            record.Delete(connection);
        }
        
        public void DeleteXzq(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Xzq row=this.GetXzq(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from XZQ where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update XZQ set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteXzq(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Xzq> rows=GetXzqs(filter);
                foreach(Xzq row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Xzqjx函数
        public Xzqjx GetXzqjx(long id)
        {
            string sql="select Id,YSDM,JXLX,JXXZ,JXSM,DatabaseId,FLAGS,AsText(geometry) as Wkt from XZQJX" + " where id="+id.ToString();
            IEnumerable<Xzqjx> xzqjxs=connection.Query<Xzqjx>(sql);
            if(xzqjxs != null && xzqjxs.Count()>0)
            {
                return xzqjxs.First();
            }
            return null;
        }
        
        public IEnumerable<Xzqjx> GetXzqjxs(string filter)
        {
            string sql="select Id,YSDM,JXLX,JXXZ,JXSM,DatabaseId,FLAGS,AsText(geometry) as Wkt from XZQJX" + " where "+filter;
            var xzqjxs=connection.Query<Xzqjx>(sql);
            
            return xzqjxs;
        }
        
        public bool SaveXzqjx(Xzqjx xzqjx)
        {
            return xzqjx.Save(connection,GetSRID());
        }
        
        public void SaveXzqjxs(List<Xzqjx> xzqjxs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in xzqjxs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteXzqjx(Xzqjx record)
        {
            record.Delete(connection);
        }
        
        public void DeleteXzqjx(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Xzqjx row=this.GetXzqjx(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from XZQJX where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update XZQJX set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteXzqjx(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Xzqjx> rows=GetXzqjxs(filter);
                foreach(Xzqjx row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Zdbhqk函数
        public Zdbhqk GetZdbhqk(long id)
        {
            string sql="select Id,ZDDM,BHYY,BHNR,DJSJ,DBR,FJ,DatabaseId,FLAGS from ZDBHQK" + " where id="+id.ToString();
            IEnumerable<Zdbhqk> zdbhqks=connection.Query<Zdbhqk>(sql);
            if(zdbhqks != null && zdbhqks.Count()>0)
            {
                return zdbhqks.First();
            }
            return null;
        }
        
        public IEnumerable<Zdbhqk> GetZdbhqks(string filter)
        {
            string sql="select Id,ZDDM,BHYY,BHNR,DJSJ,DBR,FJ,DatabaseId,FLAGS from ZDBHQK" + " where "+filter;
            var zdbhqks=connection.Query<Zdbhqk>(sql);
            
            return zdbhqks;
        }
        
        public bool SaveZdbhqk(Zdbhqk zdbhqk)
        {
            return zdbhqk.Save(connection,GetSRID());
        }
        
        public void SaveZdbhqks(List<Zdbhqk> zdbhqks)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in zdbhqks)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteZdbhqk(Zdbhqk record)
        {
            record.Delete(connection);
        }
        
        public void DeleteZdbhqk(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Zdbhqk row=this.GetZdbhqk(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from ZDBHQK where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update ZDBHQK set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteZdbhqk(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Zdbhqk> rows=GetZdbhqks(filter);
                foreach(Zdbhqk row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Zdjbxx函数
        public Zdjbxx GetZdjbxx(long id)
        {
            string sql="select Id,YSDM,ZDDM,BDCDYH,ZDTZM,ZL,ZDMJ,MJDW,YT,DJ,JG,QLLX,QLXZ,QLSDFS,RJL,JZMD,JZXG,ZDSZD,ZDSZN,ZDSZX,ZDSZB,ZDT,TFH,DJH,DAH,BZ,ZT,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from ZDJBXX" + " where id="+id.ToString();
            IEnumerable<Zdjbxx> zdjbxxs=connection.Query<Zdjbxx>(sql);
            if(zdjbxxs != null && zdjbxxs.Count()>0)
            {
                return zdjbxxs.First();
            }
            return null;
        }
        
        public IEnumerable<Zdjbxx> GetZdjbxxs(string filter)
        {
            string sql="select Id,YSDM,ZDDM,BDCDYH,ZDTZM,ZL,ZDMJ,MJDW,YT,DJ,JG,QLLX,QLXZ,QLSDFS,RJL,JZMD,JZXG,ZDSZD,ZDSZN,ZDSZX,ZDSZB,ZDT,TFH,DJH,DAH,BZ,ZT,WX_DCY,WX_DCSJ,WX_CLY,WX_CLSJ,WX_ZTY,WX_ZTSJ,WX_ZJY,WX_ZJSJ,WX_WYDM,DatabaseId,FLAGS,AsText(geometry) as Wkt from ZDJBXX" + " where "+filter;
            var zdjbxxs=connection.Query<Zdjbxx>(sql);
            
            return zdjbxxs;
        }
        
        public bool SaveZdjbxx(Zdjbxx zdjbxx)
        {
            return zdjbxx.Save(connection,GetSRID());
        }
        
        public void SaveZdjbxxs(List<Zdjbxx> zdjbxxs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in zdjbxxs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteZdjbxx(Zdjbxx record)
        {
            record.Delete(connection);
        }
        
        public void DeleteZdjbxx(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Zdjbxx row=this.GetZdjbxx(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from ZDJBXX where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update ZDJBXX set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteZdjbxx(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Zdjbxx> rows=GetZdjbxxs(filter);
                foreach(Zdjbxx row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Zdjbxxzj函数
        public Zdjbxxzj GetZdjbxxzj(long id)
        {
            string sql="select Id,GLYSDM,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,AsText(geometry) as Wkt from ZDJBXXZJ" + " where id="+id.ToString();
            IEnumerable<Zdjbxxzj> zdjbxxzjs=connection.Query<Zdjbxxzj>(sql);
            if(zdjbxxzjs != null && zdjbxxzjs.Count()>0)
            {
                return zdjbxxzjs.First();
            }
            return null;
        }
        
        public IEnumerable<Zdjbxxzj> GetZdjbxxzjs(string filter)
        {
            string sql="select Id,GLYSDM,YSDM,ZJNR,ZT,YS,BS,XZ,XHX,KD,GD,ZJDZXJXZB,ZJDZXJYZB,ZJFX,DatabaseId,FLAGS,AsText(geometry) as Wkt from ZDJBXXZJ" + " where "+filter;
            var zdjbxxzjs=connection.Query<Zdjbxxzj>(sql);
            
            return zdjbxxzjs;
        }
        
        public bool SaveZdjbxxzj(Zdjbxxzj zdjbxxzj)
        {
            return zdjbxxzj.Save(connection,GetSRID());
        }
        
        public void SaveZdjbxxzjs(List<Zdjbxxzj> zdjbxxzjs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in zdjbxxzjs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteZdjbxxzj(Zdjbxxzj record)
        {
            record.Delete(connection);
        }
        
        public void DeleteZdjbxxzj(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                Zdjbxxzj row=this.GetZdjbxxzj(id);
                if(row.DatabaseID ==0)
                {
                    command.CommandText="delete from ZDJBXXZJ where Id=" + id.ToString();
                }
                else
                {
                    command.CommandText="update ZDJBXXZJ set Flags=3 where Id=" + id.ToString();
                }
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteZdjbxxzj(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                IEnumerable<Zdjbxxzj> rows=GetZdjbxxzjs(filter);
                foreach(Zdjbxxzj row in rows)
                {
                    row.Delete(connection);
                }
            }
        }
        
        
        ///Zdtojzd函数
        public Zdtojzd GetZdtojzd(long id)
        {
            string sql="select Id,ZD_WYDM,JZD_WYDM,SXH from ZDTOJZD" + " where id="+id.ToString();
            IEnumerable<Zdtojzd> zdtojzds=connection.Query<Zdtojzd>(sql);
            if(zdtojzds != null && zdtojzds.Count()>0)
            {
                return zdtojzds.First();
            }
            return null;
        }
        
        public IEnumerable<Zdtojzd> GetZdtojzds(string filter)
        {
            string sql="select Id,ZD_WYDM,JZD_WYDM,SXH from ZDTOJZD" + " where "+filter;
            var zdtojzds=connection.Query<Zdtojzd>(sql);
            
            return zdtojzds;
        }
        
        public bool SaveZdtojzd(Zdtojzd zdtojzd)
        {
            return zdtojzd.Save(connection,GetSRID());
        }
        
        public void SaveZdtojzds(List<Zdtojzd> zdtojzds)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in zdtojzds)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteZdtojzd(Zdtojzd record)
        {
            record.Delete(connection);
        }
        
        public void DeleteZdtojzd(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from ZDTOJZD where Id=" + id.ToString();
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteZdtojzd(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from ZDTOJZD";
                else
                    command.CommandText="delete from ZDTOJZD where " + filter;
                command.ExecuteNonQuery();
            }
        }
        
        
        ///Zdtojzx函数
        public Zdtojzx GetZdtojzx(long id)
        {
            string sql="select Id,ZD_WYDM,JZX_WYDM,SXH from ZDTOJZX" + " where id="+id.ToString();
            IEnumerable<Zdtojzx> zdtojzxs=connection.Query<Zdtojzx>(sql);
            if(zdtojzxs != null && zdtojzxs.Count()>0)
            {
                return zdtojzxs.First();
            }
            return null;
        }
        
        public IEnumerable<Zdtojzx> GetZdtojzxs(string filter)
        {
            string sql="select Id,ZD_WYDM,JZX_WYDM,SXH from ZDTOJZX" + " where "+filter;
            var zdtojzxs=connection.Query<Zdtojzx>(sql);
            
            return zdtojzxs;
        }
        
        public bool SaveZdtojzx(Zdtojzx zdtojzx)
        {
            return zdtojzx.Save(connection,GetSRID());
        }
        
        public void SaveZdtojzxs(List<Zdtojzx> zdtojzxs)
        {
            SQLiteTransaction tran = connection.BeginTransaction();
            foreach(var rec in zdtojzxs)
            {
                rec.Save(connection,GetSRID());
            }
            tran.Commit();
            tran.Dispose();
        }
        
        public void DeleteZdtojzx(Zdtojzx record)
        {
            record.Delete(connection);
        }
        
        public void DeleteZdtojzx(long id)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                command.CommandText="delete from ZDTOJZX where Id=" + id.ToString();
                command.ExecuteNonQuery();
            }
        }
        
        public void DeleteZdtojzx(string filter)
        {
            using(SQLiteCommand command=new SQLiteCommand(connection))
            {
                if(string.IsNullOrEmpty(filter))
                    command.CommandText="delete from ZDTOJZX";
                else
                    command.CommandText="delete from ZDTOJZX where " + filter;
                command.ExecuteNonQuery();
            }
        }
        
        
        
        
    }
}



