using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiElevatorNade
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public class Config : IConfig
    {
        [Description("Enable or disable the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should the thrower die?")]
        public bool KillThrower { get; set; } = true;

        [Description("Should the thrower get a broadcast?")]
        public bool BroadcastThrower { get; set; } = true;

        [Description("Thrower broadcast")]
        public string BcThrower { get; set; } = "You threw a grenade at your teammates.";

        [Description("Broadcast duration")]
        public ushort BcThrowerDuration { get; set; } = 5;
    }
}
