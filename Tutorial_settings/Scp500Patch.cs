using Exiled.API.Features;
using HarmonyLib;
using InventorySystem.Items.Usables;

namespace Tutorial_settings
{
    [HarmonyPatch(typeof(Scp500), nameof(Scp500.OnEffectsActivated))]
    public static class Scp500Patch
    {
        public static bool Prefix(Scp500 __instance)
        {
            Player ply = Player.Get(__instance.Owner);
            ply.Health += Plugin.Singleton.Config.HealthGain;

            return false;
        }
    }
}
