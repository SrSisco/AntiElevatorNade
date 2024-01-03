using Exiled.Events.EventArgs.Map;


namespace AntiElevatorNade
{
    using Exiled.API.Enums;

    using System.Linq;
    using Player = Exiled.API.Features.Player;
    using Elev = Exiled.API.Features.Lift;

    

    public class EventHandlers
    {
        public bool EnemyAffected;
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        internal void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {

            if (ev.Projectile.ProjectileType != ProjectileType.FragGrenade) return;

            foreach (Elev lift in Elev.List)
            {

                    foreach (Player player in ev.TargetsToAffect)
                    {

                        if (player.LeadingTeam != ev.Player.LeadingTeam)
                        {
                            
                            ev.IsAllowed = true;
                            EnemyAffected = true;

                        }
                        else
                        {
                            if (EnemyAffected == true) return;
                            if ((ev.TargetsToAffect.First().Position - lift.Position).sqrMagnitude < 13) continue;
                            ev.IsAllowed = false;
                            ev.Projectile.Base.CancelInvoke();
                            
                            if (plugin.Config.BroadcastThrower)
                            {
                                ev.Player.ShowHint(plugin.Config.BcThrower, plugin.Config.BcThrowerDuration);
                            }
                            if (plugin.Config.KillThrower)
                            {
                                ev.Player.Kill(DamageType.Explosion);
                            }
                        }

                    }
                
            }
        }
    }
}