﻿using VastGIS.Api.Enums;
using VastGIS.Helpers;
using VastGIS.Menu;
using VastGIS.Plugins.Concrete;
using VastGIS.Plugins.Interfaces;

namespace VastGIS.Commands.View
{
    public class CmdShowCoordinates : BaseCommand
    {
        private IAppContext _context;
        public CmdShowCoordinates(IAppContext context)
        {
            base._text = "显示坐标";
            base._key = MenuKeys.ShowCoordinates;
            base._icon = null;
            _context = context;
        }

        public override void OnClick()
        {
            var config = AppConfig.Instance;
            AppConfig.Instance.ShowCoordinates = !AppConfig.Instance.ShowCoordinates;
            _context.Map.ApplyConfig(config);
            _context.Map.Redraw(RedrawType.SkipAllLayers);
        }
    }
}