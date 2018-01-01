using System;
using System.Collections.Generic;
using System.Data.SQLite;
using VastGIS.RealEstate.Data.Entity;
using VastGIS.RealEstate.Data.Enums;

namespace VastGIS.RealEstate.Data.Dao.Impl
{
    public class MainDaoImpl : MainDao
    {
        public void Close()
        {
            DbConnection.GetConnection().Close();
        }

        public int GetGeometryColumnSRID(string tableName, string columnName)
        {
            using (SQLiteCommand command = new SQLiteCommand(DbConnection.GetConnection()))
            {
                command.CommandText =
                    string.Format(
                        "Select srid from geometry_columns where f_table_name='{0}' and f_geometry_column='{1}'",
                        tableName.ToLower().Trim(), columnName.ToLower().Trim());
                int srid = Convert.ToInt32(command.ExecuteScalar());
                return srid;
            }
        }

        public void ClearCADTemps()
        {
            using (SQLiteCommand command = new SQLiteCommand(DbConnection.GetConnection()))
            {
                command.CommandText = "delete from tmpcadd";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadx";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadm";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadzj";
                command.ExecuteNonQuery();
                command.CommandText = "delete from tmpcadxdata";
                command.ExecuteNonQuery();
            }
        }

        public void ClearCADTemps(CADInsertMethod insertMethod, string dxfName)
        {
            using (SQLiteCommand command = new SQLiteCommand(DbConnection.GetConnection()))
            {
                if (insertMethod == CADInsertMethod.DeleteAll)
                {
                    command.CommandText = "delete from tmpcadd";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadx";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadm";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadzj";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadxdata";
                    command.ExecuteNonQuery();
                }
                else if (insertMethod == CADInsertMethod.DeleteByFileName)
                {
                    command.CommandText = "delete from tmpcadd where FileName='" + dxfName + "'";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadx where FileName='" + dxfName + "'";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadm where FileName='" + dxfName + "'";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadzj where FileName='" + dxfName + "'";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete from tmpcadxdata where FileName='" + dxfName + "'";
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool HasCADData(string fileName)
        {
            using (SQLiteCommand command = new SQLiteCommand(DbConnection.GetConnection()))
            {
                command.CommandText = "select Count(*) from [tmpcadx] where [FileName] = '" + fileName + "'";
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        public void SplitTmpCADToLayer(string cadLayerName, string tableName, string fileName = "", bool isClear=true)
        {
            using (SQLiteCommand command = new SQLiteCommand(DbConnection.GetConnection()))
            {
                string sql = "";
                if (isClear)
                {
                    command.CommandText = string.Format("delete from {0}D", tableName);
                    command.ExecuteNonQuery();
                    command.CommandText = string.Format("delete from {0}X", tableName);
                    command.ExecuteNonQuery();
                    command.CommandText = string.Format("delete from {0}M", tableName);
                    command.ExecuteNonQuery();
                    command.CommandText = string.Format("delete from {0}ZJ", tableName);
                    command.ExecuteNonQuery();


                }
                //��ѯ��
                if (cadLayerName != "")
                    sql = string.Format(
                        @"INSERT INTO {0}D ([geometry],[TC],[CASSDM],[FSXX1],[FSXX2],[XZJD],[Fh],[YSDM])" +
                        " SELECT [a].[geometry] AS [geometry], [a].[Tc] AS [Tc]," +
                        "   [a].[Cassdm] AS [Cassdm], [a].[Fsxx1] AS [Fsxx1]," +
                        "   [a].[Fsxx2] AS [Fsxx2], [a].[Xzjd] AS [Xzjd], [a].[Fh] AS [Fh]," +
                        "   [b].[YSDM] AS [YSDM] " +
                        " FROM [TmpCaddView] AS [a] LEFT JOIN [vg_cadcodes] AS [b] ON ([a].[Cassdm] = [b].[CASSDM])" +
                        " WHERE [a].[Tc]='{1}'", tableName, cadLayerName);
                else
                {
                    sql = string.Format(
                        @"INSERT INTO {0}D ([geometry],[TC],[CASSDM],[FSXX1],[FSXX2],[XZJD],[Fh],[YSDM])" +
                        " SELECT [a].[geometry] AS [geometry], [a].[Tc] AS [Tc]," +
                        "   [a].[Cassdm] AS [Cassdm], [a].[Fsxx1] AS [Fsxx1]," +
                        "   [a].[Fsxx2] AS [Fsxx2], [a].[Xzjd] AS [Xzjd], [a].[Fh] AS [Fh]," +
                        "   [b].[YSDM] AS [YSDM] " +
                        " FROM [TmpCaddView] AS [a] LEFT JOIN [vg_cadcodes] AS [b] ON ([a].[Cassdm] = [b].[CASSDM])" , tableName);
                }
                if (!string.IsNullOrEmpty(fileName))
                {
                    sql += string.Format("  AND [a].[FileName]='{0}'", fileName);
                }
                command.CommandText = sql;
                command.ExecuteNonQuery();
                if (cadLayerName != "")
                    sql = string.Format(
                    "INSERT INTO {0}X ([geometry],[TC],[CASSDM],[FSXX1],[FSXX2],[FH],[FHDX],[YSDM]) " +
                    "SELECT[a].[geometry] AS[geometry], [a].[Tc] AS[Tc]," +
                    "[a].[Cassdm] AS[Cassdm], [a].[Fsxx1] AS[Fsxx1]," +
                    "[a].[Fsxx2] AS[Fsxx2],  [a].[Fh] AS[Fh], [a].[FHDX] AS[FHDX]," + "[b].[YSDM] AS[YSDM]  " +
                    "FROM[TmpCadxView] AS[a] LEFT JOIN [vg_cadcodes] AS[b] ON([a].[Cassdm] = [b].[CASSDM]) " +
                    "WHERE[a].[Tc] = '{1}'", tableName, cadLayerName);
                else
                    sql = string.Format(
                        "INSERT INTO {0}X ([geometry],[TC],[CASSDM],[FSXX1],[FSXX2],[FH],[FHDX],[YSDM]) " +
                        "SELECT[a].[geometry] AS[geometry], [a].[Tc] AS[Tc]," +
                        "[a].[Cassdm] AS[Cassdm], [a].[Fsxx1] AS[Fsxx1]," +
                        "[a].[Fsxx2] AS[Fsxx2],  [a].[Fh] AS[Fh], [a].[FHDX] AS[FHDX]," + "[b].[YSDM] AS[YSDM]  " +
                        "FROM[TmpCadxView] AS[a] LEFT JOIN [vg_cadcodes] AS[b] ON([a].[Cassdm] = [b].[CASSDM]) " , tableName);

                if (!string.IsNullOrEmpty(fileName))
                {
                    sql += string.Format("  AND [a].[FileName]='{0}'", fileName);
                }
                command.CommandText = sql;
                command.ExecuteNonQuery();
                if (cadLayerName != "")
                    sql = string.Format(
                    "INSERT INTO {0}M ([geometry],[TC],[CASSDM],[FSXX1],[FSXX2],[YSDM]) " +
                    "SELECT[a].[geometry] AS[geometry], [a].[Tc] AS[Tc]," +
                    "[a].[Cassdm] AS[Cassdm], [a].[Fsxx1] AS[Fsxx1]," +
                    "[a].[Fsxx2] AS[Fsxx2],  " + "[b].[YSDM] AS[YSDM]  " +
                    "FROM[TmpCadmView] AS[a] LEFT JOIN [vg_cadcodes] AS[b] ON([a].[Cassdm] = [b].[CASSDM]) " +
                    "WHERE[a].[Tc] = '{1}'", tableName, cadLayerName);
                else
                    sql = string.Format(
                        "INSERT INTO {0}M ([geometry],[TC],[CASSDM],[FSXX1],[FSXX2],[YSDM]) " +
                        "SELECT[a].[geometry] AS[geometry], [a].[Tc] AS[Tc]," +
                        "[a].[Cassdm] AS[Cassdm], [a].[Fsxx1] AS[Fsxx1]," +
                        "[a].[Fsxx2] AS[Fsxx2],  " + "[b].[YSDM] AS[YSDM]  " +
                        "FROM[TmpCadmView] AS[a] LEFT JOIN [vg_cadcodes] AS[b] ON([a].[Cassdm] = [b].[CASSDM]) " , tableName);

                if (!string.IsNullOrEmpty(fileName))
                {
                    sql += string.Format("  AND [a].[FileName]='{0}'", fileName);
                }
                command.CommandText = sql;
                command.ExecuteNonQuery();
                if (cadLayerName != "")
                    sql = string.Format(
                    "INSERT INTO {0}ZJ ([geometry],[WBNR],[TC],[CASSDM],[FH],[FHDX],[XZJD],[YSDM]) " +
                    "SELECT[a].[geometry] AS[geometry], [a].[WBNR] AS[WBNR], [a].[Tc] AS[Tc]," +
                    "[a].[Cassdm] AS[Cassdm], " +
                    "[a].[Fh] AS[Fh], [a].[FHDX] AS[FHDX], [a].[Xzjd] AS [Xzjd]," + "[b].[YSDM] AS[YSDM]  " +
                    "FROM[TmpCadzjView] AS[a] LEFT JOIN [vg_cadcodes] AS[b] ON([a].[Cassdm] = [b].[CASSDM]) " +
                    "WHERE[a].[Tc] = '{1}'", tableName, cadLayerName);
                else
                    sql = string.Format(
                        "INSERT INTO {0}ZJ ([geometry],[WBNR],[TC],[CASSDM],[FH],[FHDX],[XZJD],[YSDM]) " +
                        "SELECT[a].[geometry] AS[geometry], [a].[WBNR] AS[WBNR], [a].[Tc] AS[Tc]," +
                        "[a].[Cassdm] AS[Cassdm], " +
                        "[a].[Fh] AS[Fh], [a].[FHDX] AS[FHDX], [a].[Xzjd] AS [Xzjd]," + "[b].[YSDM] AS[YSDM]  " +
                        "FROM[TmpCadzjView] AS[a] LEFT JOIN [vg_cadcodes] AS[b] ON([a].[Cassdm] = [b].[CASSDM]) ", tableName);

                if (!string.IsNullOrEmpty(fileName))
                {
                    sql += string.Format("  AND [a].[FileName]='{0}'", fileName);
                }
                command.CommandText = sql;
                command.ExecuteNonQuery();

                sql = cadLayerName != "" ? string.Format("delete from TmpCadd where Handle in (select Handle from TmpCaddView where Tc = '{0}')",cadLayerName): "delete from TmpCadd";
                command.CommandText = sql;
                command.ExecuteNonQuery();

                sql = cadLayerName != "" ? string.Format("delete from TmpCadx where Handle in (select Handle from TmpCadxView where Tc = '{0}')", cadLayerName): "delete from TmpCadx";
                command.CommandText = sql;
                command.ExecuteNonQuery();

                sql = cadLayerName != "" ? string.Format("delete from TmpCadm where Handle in (select Handle from TmpCadmView where Tc = '{0}')", cadLayerName):"delete from TmpCadm";
                command.CommandText = sql;
                command.ExecuteNonQuery();

                sql = cadLayerName != "" ? string.Format("delete from TmpCadzj where Handle in (select Handle from TmpCadzjView where Tc = '{0}')", cadLayerName): "delete from TmpCadzj";
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}