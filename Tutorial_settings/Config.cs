using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tutorial_settings
{
    public class Config : IConfig
    {
        [Description("Determines, if the plugin should be enabled or not")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Spawn info shown on spawn")]
        public string BroadcastMessage { get; set; } = "당신은 뱀의 손 입니다. 당신은 누구의 편도 아닌 공존을 추구하는 존재들입니다. <color=#EC320C>SCP</color>, <color=#7EED28>혼돈의 반란</color>, 그리고 <color=#1875E5>구미호 부대</color>를 무찌르십쇼";

        [Description("Duration of the spawn info message")]
        public ushort BroadcastTime { get; set; } = 6;

        [Description("List of item that tutorial should spawn with")]
        public List<ItemType> items { get; set; } = new List<ItemType>
        {
            ItemType.KeycardFacilityManager,
            ItemType.GrenadeHE,
            ItemType.SCP244a,
            ItemType.SCP1576,
            ItemType.SCP2176,
            ItemType.ArmorHeavy,
            ItemType.GunE11SR,
            ItemType.SCP500,
        };

        [Description("Types of ammo and amount to give")]
        public Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>
        {
            { AmmoType.Nato556, 180 },
        };

        [Description("Amount of HP gain on SCP500 usage")]
        public float HealthGain { get; set; } = 140f;
    }
}
