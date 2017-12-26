﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VastGIS.RealEstate.Api.Helpers
{
    public class SQLiteHelpers
    {
        public const string VG_DICTIONARYNAME =
            "CREATE TABLE [vg_dictoryname] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,  [ZDMC] CHAR(30),   [ZDSM] CHAR(200));";

        public const string VG_DICTIONARY =
            "CREATE TABLE [vg_dictionary] ([BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,   [ZDMC] CHAR(30),   [ZDZ] CHAR(30),   [ZDSM] CHAR(200),   [SFQS] BOOLEAN DEFAULT 0,   [PX] INT DEFAULT 0);";
        public const string VG_OBJECTCLASSES =
                "CREATE TABLE [vg_objectclasses] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [MC] CHAR(30), [DXLX] INT DEFAULT 0,   [ZWMC] CHAR(30),   [FBMC] CHAR(30),   [XHZDMC] CHAR(30),   [TXZDMC] CHAR(30),   [TXLX] INT DEFAULT 0);"
            ;

        public const string XZQ =
                "CREATE TABLE [XZQ] ([BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [XZQDM] CHAR(12), [XZQMC] CHAR(100), [XZQMJ] FLOAT);"
            ;

        public const string XZQJX =
                "CREATE TABLE [XZQJX] ([BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [JXLX] CHAR(6), [JXXZ] CHAR(6), [JXSM] CHAR);"
            ;
        public const string C =
                "CREATE TABLE [C] (   [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,   [CH] CHAR(20),   [ZRZH] CHAR(24),   [YSDM] CHAR(10),   [SJC] INTEGER,   [MYC] CHAR(50),   [CJZMJ] FLOAT,   [CTNJZMJ] FLOAT,   [CYTMJ] FLOAT,   [CGYJZMJ] FLOAT,   [CFTJZMJ] FLOAT,   [CBQMJ] FLOAT,   [CG] FLOAT,   [SPTYMJ] FLOAT,   [WX_DCY] CHAR(30),   [WX_DCSJ] DATETIME,   [WX_CLY] CHAR(30),   [WX_CLSJ] DATETIME,   [WX_ZTY] CHAR(30),   [WX_ZTSJ] DATETIME,   [WX_ZJY] CHAR(30),   [WX_ZJSJ] DATETIME,   [WX_WYDM] GUID NOT NULL);"
            ;

        public const string H =
                "CREATE TABLE [H] (   [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,   [BDCDYH] CHAR(28),   [FWBM] CHAR(26),   [YSDM] CHAR(10),   [ZRZH] CHAR(24),   [LJZH] CHAR(20),   [CH] CHAR(20),   [ZL] CHAR(100),   [MJDW] CHAR(2),   [SJCS] FLOAT,   [HH] INTEGER,   [SHBW] CHAR(20),   [HX] CHAR(2),   [HXJG] CHAR(2),   [FWYT1] CHAR(2),   [FWYT2] CHAR(2),   [FWYT3] CHAR(2),   [YCJZMJ] FLOAT,   [YCTNJZMJ] FLOAT,   [YCFTJZMJ] FLOAT,   [YCDXBFJZMJ] FLOAT,   [YCQTJZMJ] FLOAT,   [YCFTXS] FLOAT,   [SCJZMJ] FLOAT,   [SCTNJZMJ] FLOAT,   [SCFTJZMJ] FLOAT,   [SCDXBFJZMJ] FLOAT,   [SCQTJZMJ] FLOAT,   [SCFTXS] FLOAT,   [GYTDMJ] FLOAT,   [FTTDMJ] FLOAT,   [DYTDMJ] FLOAT,   [FWLX] CHAR(2),   [FWXZ] CHAR(2),   [FCFHT] BLOB,   [ZT] CHAR(2),   [WX_DCY] CHAR(30),   [WX_DCSJ] DATETIME,   [WX_CLY] CHAR(30),   [WX_CLSJ] DATETIME,   [WX_ZTY] CHAR(30),   [WX_ZTSJ] DATETIME,   [WX_ZJY] CHAR(30),   [WX_ZJSJ] DATETIME,   [WX_WYDM] GUID NOT NULL); "
            ;

        public const string QLR =
                "CREATE TABLE [QLR] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [SXH] INTEGER, [QLRMC] CHAR, [BDCQZH] CHAR(50), [QZYSXLH] CHAR(100), [SFCZR] CHAR(2), [ZJZL] CHAR(2), [ZJH] CHAR(50), [FZJG] CHAR(200), [SSHY] CHAR(6), [GJ] CHAR(6), [HJSZSS] CHAR(6), [XB] CHAR(2), [DH] CHAR(50), [DZ] CHAR(200), [YB] CHAR(10), [GZDW] CHAR(100), [DZYJ] CHAR(50), [QLRLX] CHAR(2), [QLBL] CHAR(100), [GYFS] CHAR(2), [GYQK] CHAR, [BZ] CHAR);"
            ;

        public const string TDSYQ =
                "CREATE TABLE [TDSYQ] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [ZDDM] CHAR(19), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [MJDW] CHAR(2), [NYDMJ] FLOAT, [GDMJ] FLOAT, [LDMJ] FLOAT, [CDMJ] FLOAT, [QTNYDMJ] FLOAT, [JSYDMJ] FLOAT, [WLYDMJ] FLOAT, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);"
            ;

        public const string JSYDSYQ =
                "CREATE TABLE [JSYDSYQ] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [ZDDM] CHAR(19), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [SYQMJ] FLOAT, [SYQQSSJ] DATETIME, [SYQJSSJ] DATETIME, [QDJG] FLOAT, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);"
            ;

        public const string FDCQXM =
                "CREATE TABLE [FDCQXM] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [BDCDYH] CHAR(28), [XMMC] CHAR(200), [ZH] CHAR(200), [ZCS] INTEGER, [GHYT] CHAR(2), [FWJG] CHAR(2), [JZMJ] FLOAT, [JGSJ] DATETIME, [ZTS] INTEGER, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);"
            ;

        public const string DJQ =
                "CREATE TABLE [DJQ] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[YSDM] CHAR(10), [DJQDM] CHAR(9), [DJQMC] CHAR(100), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);"
            ;

        public const string DJZQ =
                "CREATE TABLE [DJZQ] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[YSDM] CHAR(10), [DJZQDM] CHAR(12), [DJZQMC] CHAR(100), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);"
            ;

        public const string ZDJBXX =
                "CREATE TABLE [ZDJBXX] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[YSDM] CHAR(10), [ZDDM] CHAR(19), [BDCDYH] CHAR(28), [ZDTZM] CHAR(2), [ZL] CHAR(200), [ZDMJ] FLOAT, [MJDW] CHAR(2), [YT] CHAR(4), [DJ] CHAR(2), [JG] FLOAT, [QLLX] CHAR(2), [QLXZ] CHAR(4), [QLSDFS] CHAR(2), [RJL] FLOAT, [JZMD] FLOAT, [JZXG] FLOAT, [ZDSZD] CHAR(200), [ZDSZN] CHAR(200), [ZDSZX] CHAR(200), [ZDSZB] CHAR(200), [ZDT] BLOB, [TFH] CHAR(50), [DJH] CHAR(20), [DAH] CHAR, [BZ] CHAR, [ZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);"
            ;

        public const string JZD = "CREATE TABLE [JZD] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,[ZDZHDM] CHAR, [YSDM] CHAR(10), [JZDH] CHAR(10), [SXH] INTEGER, [JBLX] CHAR(2), [JZDLX] CHAR(2), [XZBZ] FLOAT, [YZBZ] FLOAT, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);";

        public const string JZX =
                "CREATE TABLE [JZX] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [ZDZHDM] CHAR, [YSDM] CHAR(10), [JZXCD] FLOAT, [JZXLB] CHAR(2), [JZXWZ] CHAR(1), [JXXZ] CHAR(1), [QSJXXYSBH] CHAR(30), [QSJXXYS] BLOB, [QSZYYYSBH] CHAR(30), [QSZYYYS] BLOB, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);"
            ;

        public const string ZDTZJ = "CREATE TABLE [ZDTZJ] ( [BSM] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [BDCDYH] CHAR(28), [YSDM] CHAR(10), [ZJNR] CHAR(200), [ZT] CHAR(50), [YS] CHAR(20), [BS] INTEGER, [XZ] CHAR(1), [XHX] CHAR(1), [KD] FLOAT, [GD] FLOAT, [ZJDZXJXZB] FLOAT, [ZJDZXJYZB] FLOAT, [ZJFX] FLOAT);";
        public static string ConnectionStringBuilder(string dbName)
        {
            return string.Format("Data Source={0};", dbName);
        }

        public static  FileInfo GetTemplateDBInfo()
        {
            FileInfo fileInfo=new FileInfo(Path.Combine(Application.StartupPath, "Templates\\vastgis.sqlite"));
            if (fileInfo.Exists) return fileInfo;
            return null;
        }
    }
}
