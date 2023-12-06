using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainWin
{
    public class MenuItem
    {
        public string Icon { get; set; }
        public string Description { get; set; }

        public string MenuKey { get; set; }

        public MenuItem(string icon, string description, string menuKey)
        {
            Icon = icon;
            Description = description;
            MenuKey = menuKey;
        }
    }
}
