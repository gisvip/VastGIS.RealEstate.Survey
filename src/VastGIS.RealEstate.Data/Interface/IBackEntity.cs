namespace VastGIS.RealEstate.Data.Interface
{
    public interface IBackEntity: IEntity
    {
        string WxDcy { get; set; }
        System.DateTime? WxDcsj { get; set; }
        string WxCly { get; set; }
        System.DateTime? WxClsj { get; set; }
        string WxZty { get; set; }
        System.DateTime? WxZtsj { get; set; }
        string WxZjy { get; set; }
        System.DateTime? WxZjsj { get; set; }
        System.Guid? WxWydm { get; set; }
    }
}