using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Data.SQLite;
using System.Text;
using VastGIS.RealEstate.Data.Entity;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class TmpCaddDaoImpl : SQLiteDao, TmpCaddDao
    {
        private const string TmpCaddsTable = "TmpCadd";
        private const string IdCol = "Id";
        private const string entitytypeCol = "EntityType";
        private const string handleCol = "Handle";
        private const string geometryCol = "Geometry";

        public void Save(TmpCadd cadd)
        {
            if (cadd.Id <= 0)
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                StringBuilder fieldParameters = new StringBuilder();
                StringBuilder valuesParameters = new StringBuilder();
                fieldParameters.Append("Handle");
                valuesParameters.Append("'" + cadd.Handle + "'");

                fieldParameters.Append(",EntityType");
                valuesParameters.Append(",'" + cadd.EntityType + "'");

                fieldParameters.Append(",FileName");
                valuesParameters.Append(",'" + cadd.FileName + "'");

                fieldParameters.Append(",Geometry");
                valuesParameters.Append(",GeomFromText('" + cadd.Geometry.AsText() + "'," + _srid.ToString() + ")");
                string query = String.Format("Insert Into TmpCadd ({0}) Values ({1})", fieldParameters.ToString(),
                    valuesParameters.ToString());
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            else
            {
                Update(cadd);
            }
        }

        private void Update(TmpCadd cadd)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            StringBuilder fieldParameters = new StringBuilder();
           
            fieldParameters.Append("Handle='" + cadd.Handle + "'");
            fieldParameters.Append(",EntityType='" + cadd.EntityType + "'");
            fieldParameters.Append(",FileName='" + cadd.FileName + "'");
            fieldParameters.Append(",Geometry=GeomFromText('" + cadd.Geometry.AsText() + "',"+_srid.ToString()+")");
            string query = String.Format("Update TmpCadd Set {0} Where Id={1}", fieldParameters.ToString(),
                cadd.Id);
            command.CommandText = query;
            //ExecuteSql(command);
            command.ExecuteNonQuery();
        }

        public List<TmpCadd> Find(string query)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText=String.Format("Select Id,Handle,FileName,EntityType,AsText(Geometry) from TmpCadd where EntityType like '{0}'", query);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt);
        }

        public TmpCadd Find(int id)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Id,Handle,FileName,EntityType,AsText(Geometry) from TmpCadd where Id={0}", id);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        public TmpCadd FindByHandle(string handle)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("Select Id,Handle,EntityType,FileName,AsText(Geometry) from TmpCadd where Handle='{0}'", handle);
            DataTable dt = ExecuteSql(command);
            return ProcessResult(dt)[0];
        }

        private List<TmpCadd> ProcessResult(DataTable dt)
        {
            List<TmpCadd> cadds = new List<TmpCadd>();
            foreach (DataRow row in dt.Rows)
            {
                TmpCadd cadd = new TmpCadd();
                cadd.Id = int.Parse(row[IdCol].ToString());
                cadd.Handle = (string)row[handleCol];
                cadd.EntityType = (string)row[entitytypeCol];
                cadd.FileName = (string)row[3];
                cadd.Geometry=DbGeometry.FromText(row[4].ToString());
                cadds.Add(cadd);
            }
            return cadds;
        }
    }
}