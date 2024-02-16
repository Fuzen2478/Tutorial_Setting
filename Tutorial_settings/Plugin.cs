using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using HarmonyLib;
using PlayerRoles;
using Event = Exiled.Events.Handlers;
using System;
using UnityEngine;

namespace Tutorial_settings
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "Artyom <3";
        public override string Editor => "Fuzen"
        public override string Name => "Tutorial Settings";

        public override Version Version => new Version(1, 0, 0);
        public static Plugin Singleton;
        public static Harmony _harmony;

        public override void OnEnabled()
        {
            Singleton = this;
            _harmony = new Harmony("com.tutsettings");
            _harmony.PatchAll();

            Event.Player.Hurting += OnHurting;
            Event.Player.UsedItem -= OnItemUsed;
            Event.Player.Spawned += OnSpawn;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Event.Player.Hurting -= OnHurting;
            Event.Player.Spawned -= OnSpawn;
            Event.Player.UsedItem -= OnItemUsed;

            Singleton = null;
            base.OnDisabled();
        }

        public void OnSpawn(SpawnedEventArgs ev)
        {
            if (ev.Player.Role == RoleTypeId.Tutorial)
            {
                ev.Player.Broadcast(Singleton.Config.BroadcastTime, Singleton.Config.BroadcastMessage);
                AddSHInv(ev.Player);
                ev.Player.Position = Room.Get(RoomType.EzGateB).Position + Vector3.up;
            }
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Player is null || ev.Attacker is null)
            {
                return;
            }
            if (ev.Player.Role == RoleTypeId.Tutorial && ev.Attacker.Role == RoleTypeId.Tutorial)
            {
                ev.IsAllowed = false;
            }
        }

        public void OnItemUsed(UsedItemEventArgs ev)
        {
            if (ev.Usable.Type == ItemType.SCP500)
            {
                //ev.Player.Health += Singleton.Config.HealthGain;
            }
        }

        private void AddSHInv(Player ply)
        {
            foreach (ItemType item in Singleton.Config.items)
            {
                ply.AddItem(item);
            }
            
            foreach (var ammo in Singleton.Config.Ammo)
            {
                ply.AddAmmo(ammo.Key, ammo.Value);
            }
        }
    }
}
