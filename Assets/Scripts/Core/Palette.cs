using UnityEngine;

namespace ACG
{
    public static class Palette
    {
        public static Color FactionColor(Faction f) => f switch
        {
            Faction.Sweets => new Color(1f, 0.70f, 0.73f), // #FFB3BA
            Faction.Ice => new Color(0.73f, 0.88f, 1f), // #BAE1FF
            Faction.Neutral => new Color(0.90f, 0.90f, 0.90f),
            _ => Color.white
        };
        public static Color FactionColorLight(Faction f)
        {
            var c = FactionColor(f);
            return Color.Lerp(c, Color.white, 0.35f);
        }
        public static Color RarityColor(Rarity r) => r switch
        {
            Rarity.Common => new Color(0.78f, 0.78f, 0.78f),
            Rarity.Epic => new Color(0.84f, 0.71f, 0.96f),
            Rarity.Legendary => new Color(0.95f, 0.83f, 0.37f),
            _ => Color.white
        };
    }
}