

namespace AntiElevatorNade
{
    using Exiled.API.Features;
    using System;
    using Map = Exiled.Events.Handlers.Map;
    public class Plugin : Plugin<Config>
    {
        private EventHandlers EventHandler;
        public override string Name => "AntiElevatorNade";
        public override string Author => "SrSisco#2995";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(5, 0, 0);

        public override void OnEnabled()
        {

            EventHandler = new EventHandlers(this);
            Map.ExplodingGrenade += EventHandler.OnExplodingGrenade;
            Log.Info("AntiElevatorNade has been enabled.");
            base.OnEnabled();

        }

        public override void OnDisabled()
        {
            Map.ExplodingGrenade -= EventHandler.OnExplodingGrenade;
            EventHandler = null;
            Log.Info("AntiElevatorNade has been disabled.");
            base.OnDisabled();
        }
    }
}
