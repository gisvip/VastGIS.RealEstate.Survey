CREATE TABLE [C] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [CH] CHAR(20), [ZRZH] CHAR(24), [YSDM] CHAR(10), [SJC] INTEGER, [MYC] CHAR(50), [CJZMJ] FLOAT, [CTNJZMJ] FLOAT, [CYTMJ] FLOAT, [CGYJZMJ] FLOAT, [CFTJZMJ] FLOAT, [CBQMJ] FLOAT, [CG] FLOAT, [SPTYMJ] FLOAT, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [CFDJ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [YWH] CHAR(20), [CFJG] CHAR(200), [CFLX] CHAR(2), [CFWJ] BLOB, [CFWH] CHAR(50), [CFQSSJ] DATETIME, [CFJSSJ] DATETIME, [CFFW] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [JFYWH] CHAR(20), [JFJG] CHAR(200), [JFWJ] BLOB, [JFWH] CHAR(200), [JFDBR] CHAR(50), [JFDJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2));


CREATE TABLE [DJQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [DJQDM] CHAR(9), [DJQMC] CHAR(100), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL, [SHAPE_Length] FLOAT, [SHAPE_Area] FLOAT);


CREATE TABLE [DJZQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [DJZQDM] CHAR(12), [DJZQMC] CHAR(100), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL, [SHAPE_Length] FLOAT, [SHAPE_Area] FLOAT);


CREATE TABLE [DXTJMDD] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [CASSDM] CHAR(10), [CASSSX1] CHAR(255), [CASSSX2] CHAR(255), [CASSSX3] CHAR(255), [CASSSX4] CHAR(255), [CASSSX5] CHAR(255), [CASSSX6] CHAR(255), [CASSSX7] CHAR(255), [CASSSX8] CHAR(255), [CASSSX9] CHAR(255), [CASSSX10] CHAR(255), [XZJD] FLOAT, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [DXTJMDM] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [CASSDM] CHAR(10), [CASSSX1] CHAR(255), [CASSSX2] CHAR(255), [CASSSX3] CHAR(255), [CASSSX4] CHAR(255), [CASSSX5] CHAR(255), [CASSSX6] CHAR(255), [CASSSX7] CHAR(255), [CASSSX8] CHAR(255), [CASSSX9] CHAR(255), [CASSSX10] CHAR(255), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL, [SHAPE_Length] FLOAT, [SHAPE_Area] FLOAT);


CREATE TABLE [DXTJMDX] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [CASSDM] CHAR(10), [CASSSX1] CHAR(255), [CASSSX2] CHAR(255), [CASSSX3] CHAR(255), [CASSSX4] CHAR(255), [CASSSX5] CHAR(255), [CASSSX6] CHAR(255), [CASSSX7] CHAR(255), [CASSSX8] CHAR(255), [CASSSX9] CHAR(255), [CASSSX10] CHAR(255), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL, [SHAPE_Length] FLOAT);


CREATE TABLE [DXTJMDZJ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [ZJNR] CHAR(200), [ZT] CHAR(50), [YS] CHAR(20), [BS] INTEGER, [XZ] CHAR(1), [XHX] CHAR(1), [KD] FLOAT, [GD] FLOAT, [ZJDZXJXZB] FLOAT, [ZJDZXJYZB] FLOAT, [ZJFX] FLOAT, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [DYAQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [YWH] CHAR(20), [DYBDCLX] CHAR(2), [DYR] CHAR, [DYFS] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [ZJJZWZL] CHAR(200), [ZJJZWDYFW] CHAR, [BDBZZQSE] FLOAT, [ZWLXQSSJ] DATETIME, [ZWLXJSSJ] DATETIME, [ZGZQQDSS] CHAR, [ZGZQSE] FLOAT, [ZXDYYWH] CHAR(20), [ZXDYYY] CHAR, [ZXSJ] DATETIME, [BDCDJZMH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2));


CREATE TABLE [DYIQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [YWH] CHAR(20), [GYDBDCDYH] CHAR(28), [GYDQLR] CHAR(50), [GYDQLRZJZL] CHAR(2), [GYDQLRZJH] CHAR(50), [XYDBDCDYH] CHAR(28), [XYDZL] CHAR(200), [XYDQLR] CHAR(50), [XYDQLRZJZL] CHAR(2), [XYDQLRZJH] CHAR(50), [DJLX] CHAR(6), [DJYY] CHAR, [DYQNR] CHAR, [BDCDJZMH] CHAR, [QLQSSJ] DATETIME, [QLJSSJ] DATETIME, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2));


CREATE TABLE [DZDZW] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [ZDZHDM] CHAR(19), [DZDZWLX] CHAR(100), [DZWMC] CHAR(100), [MJDW] CHAR(2), [MJ] FLOAT, [DAH] CHAR, [ZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [FDCQ1] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [FDZL] CHAR(200), [TDSYQR] CHAR, [DYTDMJ] FLOAT, [FTTDMJ] FLOAT, [TDSYQSSJ] DATETIME, [TDSYJSSJ] DATETIME, [FDCJYJG] FLOAT, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [FCFHT] BLOB, [QSZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [FDCQ2] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [FDZL] CHAR(200), [TDSYQR] CHAR, [DYTDMJ] FLOAT, [FTTDMJ] FLOAT, [TDSYQSSJ] DATETIME, [TDSYJSSJ] DATETIME, [FDCJYJG] FLOAT, [GHYT] CHAR(2), [FWXZ] CHAR(2), [FWJG] CHAR(2), [SZC] INTEGER, [ZCS] INTEGER, [JZMJ] FLOAT, [ZYJZMJ] FLOAT, [FTJZMJ] FLOAT, [JGSJ] DATETIME, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [FDCQ3] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [JGZWBH] CHAR(10), [JGZWMC] CHAR(100), [JGZWSL] INTEGER, [JGZWMJ] FLOAT, [FTTDMJ] FLOAT, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2));


CREATE TABLE [FDCQXM] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [BDCDYH] CHAR(28), [XMMC] CHAR(200), [ZH] CHAR(200), [ZCS] INTEGER, [GHYT] CHAR(2), [FWJG] CHAR(2), [JZMJ] FLOAT, [JGSJ] DATETIME, [ZTS] INTEGER, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [FZ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YWH] CHAR(20), [YSDM] CHAR(10), [FZRY] CHAR(50), [FZSJ] DATETIME, [FZMC] CHAR(50), [FZSL] INTEGER, [HFZSH] CHAR, [LZRXM] CHAR(50), [LZRZJLB] CHAR(2), [LZRZJH] CHAR(50), [LZRDH] CHAR(50), [LZRDZ] CHAR(200), [LZRYB] CHAR(10), [BZ] CHAR); 

CREATE TABLE [GD] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YWH] CHAR(20), [YSDM] CHAR(10), [DJDL] CHAR(6), [DJXL] INTEGER, [ZL] CHAR(200), [QZHM] CHAR, [WJJS] INTEGER, [ZYS] INTEGER, [GDRY] CHAR(50), [GDSJ] DATETIME, [BZ] CHAR);


CREATE TABLE [GJZWSYQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [ZL] CHAR(200), [TDHYSYQR] CHAR(100), [TDHYSYMJ] FLOAT, [TDHYSYQSSJ] DATETIME, [TDHYSYJSSJ] DATETIME, [GJZWLX] CHAR(2), [GJZWGHYT] CHAR(200), [GJZWMJ] FLOAT, [JGSJ] DATETIME, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [GJZWPMT] BLOB, [QSZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [GZW] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [ZDZHDM] CHAR(19), [GZWMC] CHAR(100), [ZL] CHAR(200), [MJDW] CHAR(2), [MJ] FLOAT, [DAH] CHAR, [ZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL, [SHAPE_Length] FLOAT, [SHAPE_Area] FLOAT);


CREATE TABLE [H] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [BDCDYH] CHAR(28), [FWBM] CHAR(26), [YSDM] CHAR(10), [ZRZH] CHAR(24), [LJZH] CHAR(20), [CH] CHAR(20), [ZL] CHAR(100), [MJDW] CHAR(2), [SJCS] FLOAT, [HH] INTEGER, [SHBW] CHAR(20), [HX] CHAR(2), [HXJG] CHAR(2), [FWYT1] CHAR(2), [FWYT2] CHAR(2), [FWYT3] CHAR(2), [YCJZMJ] FLOAT, [YCTNJZMJ] FLOAT, [YCFTJZMJ] FLOAT, [YCDXBFJZMJ] FLOAT, [YCQTJZMJ] FLOAT, [YCFTXS] FLOAT, [SCJZMJ] FLOAT, [SCTNJZMJ] FLOAT, [SCFTJZMJ] FLOAT, [SCDXBFJZMJ] FLOAT, [SCQTJZMJ] FLOAT, [SCFTXS] FLOAT, [GYTDMJ] FLOAT, [FTTDMJ] FLOAT, [DYTDMJ] FLOAT, [FWLX] CHAR(2), [FWXZ] CHAR(2), [FCFHT] BLOB, [ZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [HYSYQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [ZHHDDM] CHAR(19), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [SYQMJ] FLOAT, [SYQQSSJ] DATETIME, [SYQJSSJ] DATETIME, [SYJZE] FLOAT, [SYJBZYJ] CHAR, [SYJJNQK] CHAR, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2));


CREATE TABLE [JSYDSYQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [ZDDM] CHAR(19), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [SYQMJ] FLOAT, [SYQQSSJ] DATETIME, [SYQJSSJ] DATETIME, [QDJG] FLOAT, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [JZD] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [ZDZHDM] CHAR, [YSDM] CHAR(10), [JZDH] CHAR(10), [SXH] INTEGER, [JBLX] CHAR(2), [JZDLX] CHAR(2), [XZBZ] FLOAT, [YZBZ] FLOAT, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [JZX] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [ZDZHDM] CHAR, [YSDM] CHAR(10), [JZXCD] FLOAT, [JZXLB] CHAR(2), [JZXWZ] CHAR(1), [JXXZ] CHAR(1), [QSJXXYSBH] CHAR(30), [QSJXXYS] BLOB, [QSZYYYSBH] CHAR(30), [QSZYYYS] BLOB, [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL, [SHAPE_Length] FLOAT);


CREATE TABLE [LJZ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[LJZH] CHAR(20),
[ZRZH] CHAR(24),
[YSDM] CHAR(10),
[MPH] CHAR(50),
[YCJZMJ] FLOAT,
[YCDXMJ] FLOAT,
[YCQTMJ] FLOAT,
[SCJZMJ] FLOAT,
[SCDXMJ] FLOAT,
[SCQTMJ] FLOAT,
[JGRQ] DATETIME,
[FWJG1] CHAR(4),
[FWJG2] CHAR(4),
[FWJG3] CHAR(4),
[JZWZT] CHAR(4),
[FWYT1] CHAR(4),
[FWYT2] CHAR(4),
[FWYT3] CHAR(4),
[ZCS] INTEGER,
[DSCS] INTEGER,
[DXCS] INTEGER,
[BZ] CHAR);


CREATE TABLE [LQ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[YWH] CHAR(20),
[QLLX] CHAR(2),
[DJLX] CHAR(6),
[DJYY] CHAR,
[FBF] CHAR(100),
[SYQMJ] FLOAT,
[LDSYQSSJ] DATETIME,
[LDSYJSSJ] DATETIME,
[LDSYQXZ] CHAR(2),
[SLLMSYQR1] CHAR(100),
[SLLMSYQR2] CHAR(100),
[ZYSZ] CHAR(200),
[ZS] INTEGER,
[LZ] CHAR(4),
[QY] CHAR(2),
[ZLND] INTEGER,
[LB] CHAR(50),
[XB] CHAR(50),
[XDM] CHAR(200),
[BDCQZH] CHAR,
[QXDM] CHAR(6),
[DJJG] CHAR(200),
[DBR] CHAR(50),
[DJSJ] DATETIME,
[FJ] CHAR,
[QSZT] CHAR(2));


CREATE TABLE [MZDZW] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[SHAPE] BLOB,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[ZDZHDM] CHAR(19),
[MZDZWLX] CHAR(100),
[DZWMC] CHAR(100),
[MJDW] CHAR(2),
[MJ] FLOAT,
[DAH] CHAR,
[ZT] CHAR(2),
[WX_DCY] CHAR(30),
[WX_DCSJ] DATETIME,
[WX_CLY] CHAR(30),
[WX_CLSJ] DATETIME,
[WX_ZTY] CHAR(30),
[WX_ZTSJ] DATETIME,
[WX_ZJY] CHAR(30),
[WX_ZJSJ] DATETIME,
[WX_WYDM] GUID NOT NULL,
[SHAPE_Length] FLOAT,
[SHAPE_Area] FLOAT);


CREATE TABLE [NYDSYQ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[YWH] CHAR(20),
[QLLX] CHAR(2),
[DJLX] CHAR(6),
[DJYY] CHAR,
[ZL] CHAR(200),
[FBFDM] CHAR(100),
[FBFMC] CHAR(100),
[CBMJ] FLOAT,
[CBQSSJ] DATETIME,
[CBJSSJ] DATETIME,
[TDSYQXZ] CHAR(2),
[SYTTLX] CHAR(2),
[YZYFS] CHAR(2),
[CYZL] CHAR,
[SYZCL] INTEGER,
[BDCQZH] CHAR,
[QXDM] CHAR(6),
[DJJG] CHAR(200),
[DBR] CHAR(50),
[DJSJ] DATETIME,
[FJ] CHAR,
[QSZT] CHAR(2),
[WX_DCY] CHAR(30),
[WX_DCSJ] DATETIME,
[WX_CLY] CHAR(30),
[WX_CLSJ] DATETIME,
[WX_ZTY] CHAR(30),
[WX_ZTSJ] DATETIME,
[WX_ZJY] CHAR(30),
[WX_ZJSJ] DATETIME,
[WX_WYDM] GUID NOT NULL);


CREATE TABLE [QLR] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [BDCDYH] CHAR(28), [SXH] INTEGER, [QLRMC] CHAR, [BDCQZH] CHAR(50), [QZYSXLH] CHAR(100), [SFCZR] CHAR(2), [ZJZL] CHAR(2), [ZJH] CHAR(50), [FZJG] CHAR(200), [SSHY] CHAR(6), [GJ] CHAR(6), [HJSZSS] CHAR(6), [XB] CHAR(2), [DH] CHAR(50), [DZ] CHAR(200), [YB] CHAR(10), [GZDW] CHAR(100), [DZYJ] CHAR(50), [QLRLX] CHAR(2), [QLBL] CHAR(100), [GYFS] CHAR(2), [GYQK] CHAR, [BZ] CHAR);


CREATE TABLE [QTXGQL] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[YWH] CHAR(20),
[QLLX] CHAR(2),
[DJLX] CHAR(6),
[DJYY] CHAR,
[QLQSSJ] DATETIME,
[QLJSSJ] DATETIME,
[QSFS] CHAR(100),
[SYLX] CHAR(100),
[QSL] FLOAT,
[QSYT] CHAR(200),
[KCMJ] FLOAT,
[KCFS] CHAR,
[KCKZ] CHAR,
[SCGM] CHAR,
[BDCQZH] CHAR,
[QXDM] CHAR(6),
[DJJG] CHAR(200),
[DBR] CHAR(50),
[DJSJ] DATETIME,
[FJ] CHAR,
[FT] BLOB,
[QSZT] CHAR(2));


CREATE TABLE [QXZD] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[XZQHDM] CHAR(6),
[XZQHMC] CHAR(60));


CREATE TABLE [SF] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YWH] CHAR(20),
[YSDM] CHAR(10),
[JFRY] CHAR(50),
[JFRQ] DATETIME,
[SFKMMC] CHAR(50),
[SFEWSF] CHAR(2),
[SFJS] FLOAT,
[SFLX] CHAR(2),
[YSJE] FLOAT,
[ZKHYSJE] FLOAT,
[SFRY] CHAR(50),
[SFRQ] DATETIME,
[FFF] CHAR(255),
[SJFFR] CHAR(50),
[SSJE] FLOAT,
[SFDW] CHAR(50));


CREATE TABLE [SGSJ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YSDM] CHAR(10),
[SJWJM] BLOB,
[TWJM] BLOB,
[YSJWJM] BLOB);


CREATE TABLE [SH] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YWH] CHAR(20),
[YSDM] CHAR(10),
[JDMC] CHAR(50),
[SXH] INTEGER,
[SHRYXM] CHAR(50),
[SHKSSJ] DATETIME,
[SHJSSJ] DATETIME,
[SHYJ] CHAR,
[CZJG] CHAR(2));


CREATE TABLE [SJ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YWH] CHAR(20),
[YSDM] CHAR(10),
[SJSJ] DATETIME,
[SJLX] CHAR(4),
[SJMC] CHAR(100),
[SJSL] INTEGER,
[SFSJSY] CHAR(2),
[SFEWSJ] CHAR(2),
[SFBCSJ] CHAR(2),
[YS] INTEGER,
[BZ] CHAR);


CREATE TABLE [SLSQ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YSDM] CHAR(10),
[YWH] CHAR(20),
[DJDL] CHAR(4),
[DJXL] CHAR(4),
[SQZSBS] INTEGER,
[SQFBCZ] INTEGER,
[QXDM] CHAR(6),
[SLRY] CHAR(50),
[SLSJ] DATETIME,
[ZL] CHAR(200),
[TZRXM] CHAR(50),
[TZFS] CHAR(2),
[TZRDH] CHAR(50),
[TZRYDDH] CHAR(50),
[TZRDZYJ] CHAR(50),
[SFWTAJ] CHAR(2),
[JSSJ] DATETIME,
[AJZT] CHAR(2),
[BZ] CHAR);


CREATE TABLE [SQR] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YWH] CHAR(20),
[YSDM] CHAR(10),
[QLRMC] CHAR,
[QLRZJZL] CHAR(2),
[QLRZJH] CHAR(50),
[QLRTXDZ] CHAR(100),
[QLRYB] CHAR(10),
[QLRFRMC] CHAR(100),
[QLRFRDH] CHAR(50),
[QLRDLRMC] CHAR(100),
[QLRDLRDH] CHAR(50),
[QLRDLJG] CHAR(100),
[YWRMC] CHAR,
[YWRZJZL] CHAR(2),
[YWRZJH] CHAR(50),
[YWRTXDZ] CHAR(100),
[YWRYB] CHAR(10),
[YWRFRMC] CHAR(100),
[YWRFRDH] CHAR(50),
[YWRDLRMC] CHAR(100),
[YWRDLRDH] CHAR(50),
[YWRDLJG] CHAR(100),
[BZ] CHAR);


CREATE TABLE [SZ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YWH] CHAR(20),
[YSDM] CHAR(10),
[SZMC] CHAR(50),
[SZZH] CHAR,
[YSXLH] CHAR,
[SZRY] CHAR(50),
[SZSJ] DATETIME,
[BZ] CHAR);


CREATE TABLE [TDSYQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [YSDM] CHAR(10), [ZDDM] CHAR(19), [BDCDYH] CHAR(28), [YWH] CHAR(20), [QLLX] CHAR(2), [DJLX] CHAR(6), [DJYY] CHAR, [MJDW] CHAR(2), [NYDMJ] FLOAT, [GDMJ] FLOAT, [LDMJ] FLOAT, [CDMJ] FLOAT, [QTNYDMJ] FLOAT, [JSYDMJ] FLOAT, [WLYDMJ] FLOAT, [BDCQZH] CHAR, [QXDM] CHAR(6), [DJJG] CHAR(200), [DBR] CHAR(50), [DJSJ] DATETIME, [FJ] CHAR, [QSZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL);


CREATE TABLE [XZDZW] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[SHAPE] BLOB,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[ZDZHDM] CHAR(19),
[XZDZWLX] CHAR(100),
[DZWMC] CHAR(100),
[MJDW] CHAR(2),
[MJ] FLOAT,
[DAH] CHAR,
[ZT] CHAR(2),
[WX_DCY] CHAR(30),
[WX_DCSJ] DATETIME,
[WX_CLY] CHAR(30),
[WX_CLSJ] DATETIME,
[WX_ZTY] CHAR(30),
[WX_ZTSJ] DATETIME,
[WX_ZJY] CHAR(30),
[WX_ZJSJ] DATETIME,
[WX_WYDM] GUID NOT NULL,
[SHAPE_Length] FLOAT);


CREATE TABLE [XZQ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [XZQDM] CHAR(12), [XZQMC] CHAR(100), [XZQMJ] FLOAT);


CREATE TABLE [XZQJX] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [JXLX] CHAR(6), [JXXZ] CHAR(6), [JXSM] CHAR);


CREATE TABLE [XZQZJ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[SHAPE] BLOB,
[YSDM] CHAR(10),
[ZJNR] CHAR(200),
[ZT] CHAR(50),
[YS] CHAR(20),
[BS] INTEGER,
[XZ] CHAR(1),
[XHX] CHAR(1),
[KD] FLOAT,
[GD] FLOAT,
[ZJDZXJXZB] FLOAT,
[ZJDZXJYZB] FLOAT,
[ZJFX] FLOAT);


CREATE TABLE [YGDJ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[YWH] CHAR(20),
[BDCZL] CHAR(200),
[YWR] CHAR(50),
[YWRZJZL] CHAR(2),
[YWRZJH] CHAR(50),
[YGDJZL] CHAR(2),
[DJLX] CHAR(6),
[DJYY] CHAR,
[TDSYQR] CHAR(50),
[GHYT] CHAR(2),
[FWXZ] CHAR(2),
[FWJG] CHAR(2),
[SZC] INTEGER,
[ZCS] INTEGER,
[JZMJ] FLOAT,
[QDJG] FLOAT,
[BDCDJZMH] CHAR,
[QXDM] CHAR(6),
[DJJG] CHAR(200),
[DBR] CHAR(50),
[DJSJ] DATETIME,
[FJ] CHAR,
[QSZT] CHAR(2));


CREATE TABLE [YHYDZB] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[ZHHDDM] CHAR(19),
[XH] INTEGER,
[BW] FLOAT,
[DJ] FLOAT);


CREATE TABLE [YHZK] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[ZHDM] CHAR(19),
[YHFS] CHAR(2),
[YHMJ] FLOAT,
[JTYT] CHAR,
[SYJSE] FLOAT);


CREATE TABLE [YYDJ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[YWH] CHAR(20),
[YYSX] CHAR,
[BDCDJZMH] CHAR,
[QXDM] CHAR(6),
[DJJG] CHAR(200),
[DBR] CHAR(50),
[DJSJ] DATETIME,
[ZXYYYWH] CHAR(20),
[ZXYYYY] CHAR,
[ZXYYDBR] CHAR(50),
[ZXYYDJSJ] DATETIME,
[FJ] CHAR,
[QSZT] CHAR(2));


CREATE TABLE [ZDBHQK] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[ZDDM] CHAR(19),
[BHYY] CHAR,
[BHNR] CHAR,
[DJSJ] DATETIME,
[DBR] CHAR(50),
[FJ] CHAR);


CREATE TABLE [ZDJBXX] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [ZDDM] CHAR(19), [BDCDYH] CHAR(28), [ZDTZM] CHAR(2), [ZL] CHAR(200), [ZDMJ] FLOAT, [MJDW] CHAR(2), [YT] CHAR(4), [DJ] CHAR(2), [JG] FLOAT, [QLLX] CHAR(2), [QLXZ] CHAR(4), [QLSDFS] CHAR(2), [RJL] FLOAT, [JZMD] FLOAT, [JZXG] FLOAT, [ZDSZD] CHAR(200), [ZDSZN] CHAR(200), [ZDSZX] CHAR(200), [ZDSZB] CHAR(200), [ZDT] BLOB, [TFH] CHAR(50), [DJH] CHAR(20), [DAH] CHAR, [BZ] CHAR, [ZT] CHAR(2), [WX_DCY] CHAR(30), [WX_DCSJ] DATETIME, [WX_CLY] CHAR(30), [WX_CLSJ] DATETIME, [WX_ZTY] CHAR(30), [WX_ZTSJ] DATETIME, [WX_ZJY] CHAR(30), [WX_ZJSJ] DATETIME, [WX_WYDM] GUID NOT NULL, [SHAPE_Length] FLOAT, [SHAPE_Area] FLOAT);


CREATE TABLE [ZHBHQK] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[ZHDM] CHAR(19),
[BHYY] CHAR,
[BHNR] CHAR,
[DJSJ] DATETIME,
[DBR] CHAR(50));


CREATE TABLE [ZHJBXX] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[SHAPE] BLOB,
[YSDM] CHAR(10),
[ZHDM] CHAR(19),
[BDCDYH] CHAR(28),
[ZHTZM] CHAR(2),
[XMMC] CHAR(100),
[XMXZ] CHAR(2),
[YHZMJ] FLOAT,
[ZHMJ] FLOAT,
[DB] CHAR(2),
[ZHAX] FLOAT,
[YHLXA] CHAR(2),
[YHLXB] CHAR(2),
[YHWZSM] CHAR,
[HDMC] CHAR(100),
[HDDM] CHAR(19),
[YDFW] CHAR,
[YDMJ] FLOAT,
[HDWZ] CHAR,
[HDYT] CHAR(2),
[ZHT] BLOB,
[DAH] CHAR,
[ZT] CHAR(2),
[SHAPE_Length] FLOAT,
[SHAPE_Area] FLOAT);


CREATE TABLE [ZJ] ( [Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT, [SHAPE] BLOB, [YSDM] CHAR(10), [ZJNR] CHAR(200), [ZT] CHAR(50), [YS] CHAR(20), [BS] INTEGER, [XZ] CHAR(1), [XHX] CHAR(1), [KD] FLOAT, [GD] FLOAT, [ZJDZXJXZB] FLOAT, [ZJDZXJYZB] FLOAT, [ZJFX] FLOAT);


CREATE TABLE [ZRZ] (
[Id] INTEGER NOT NULL RIMARY KEY AUTOINCREMENT,
[SHAPE] BLOB,
[YSDM] CHAR(10),
[BDCDYH] CHAR(28),
[ZDDM] CHAR(19),
[ZRZH] CHAR(24),
[XMMC] CHAR(100),
[JZWMC] CHAR(100),
[JGRQ] DATETIME,
[JZWGD] FLOAT,
[ZZDMJ] FLOAT,
[ZYDMJ] FLOAT,
[YCJZMJ] FLOAT,
[SCJZMJ] FLOAT,
[ZCS] INTEGER,
[DSCS] INTEGER,
[DXCS] INTEGER,
[DXSD] FLOAT,
[GHYT] CHAR(2),
[FWJG] CHAR(2),
[ZTS] INTEGER,
[JZWJBYT] CHAR(200),
[DAH] CHAR,
[BZ] CHAR,
[ZT] CHAR(2),
[WX_DCY] CHAR(30),
[WX_DCSJ] DATETIME,
[WX_CLY] CHAR(30),
[WX_CLSJ] DATETIME,
[WX_ZTY] CHAR(30),
[WX_ZTSJ] DATETIME,
[WX_ZJY] CHAR(30),
[WX_ZJSJ] DATETIME,
[WX_WYDM] GUID NOT NULL,
[SHAPE_Length] FLOAT,
[SHAPE_Area] FLOAT);


CREATE TABLE [vg_objectclasses] (   [MC] CHAR(30),   [DXLX] INT DEFAULT 0,   [ZWMC] CHAR(30),   [FBMC] CHAR(30),   [XHZDMC] CHAR(30),   [TXZDMC] CHAR(30),   [TXLX] INT DEFAULT 0);
