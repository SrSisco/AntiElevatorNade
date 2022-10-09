
namespace AntiElevatorNade
{
    using Exiled.API.Enums;
    using Exiled.Events.EventArgs;
    using System.Linq;
    using Player = Exiled.API.Features.Player;
    using Elev = Exiled.API.Features.Lift;
    using Exiled.API.Structs;
    

    public class EventHandlers
    {
        public bool EnemyAffected;
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        internal void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {

            if (ev.GrenadeType != GrenadeType.FragGrenade) return;

            foreach (Elev lift in Elev.List)
            {


                foreach (Elevator elevator in lift.Elevators)
                {

                    foreach (Player player in ev.TargetsToAffect)
                    {

                        if (player.LeadingTeam != ev.Thrower.LeadingTeam)
                        {
                            
                            ev.IsAllowed = true;
                            EnemyAffected = true;

                        }
                        else
                        {
                            if (EnemyAffected == true) return;
                            if ((ev.TargetsToAffect.First().Position - elevator.Position).sqrMagnitude < 13) continue;
                            ev.IsAllowed = false;
                            ev.Grenade.CancelInvoke();
                            
                            if (plugin.Config.BroadcastThrower)
                            {
                                ev.Thrower.ShowHint(plugin.Config.BcThrower, plugin.Config.BcThrowerDuration);
                            }
                            if (plugin.Config.KillThrower)
                            {
                                ev.Thrower.Kill(DamageType.Explosion);
                            }
                        }

                    }
                }
            }
        }
    }
}
