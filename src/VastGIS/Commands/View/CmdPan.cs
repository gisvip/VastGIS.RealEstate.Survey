using VastGIS.Api.Enums;
using VastGIS.Menu;
using VastGIS.Plugins.Concrete;
using VastGIS.Plugins.Interfaces;
using VastGIS.Properties;

namespace VastGIS.Commands.View
{
    public class CmdPan : BaseCommand
    {
        private IAppContext _context;
        public CmdPan(IAppContext context)
        {
            base._text = "ƽ��";
            base._key = MenuKeys.Pan;
            base._icon = Resources.icon_pan;
            _context = context;
        }

        public override void OnClick()
        {
            _context.Map.MapCursor = MapCursor.Pan;
        }
    }
}