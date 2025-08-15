namespace ACG
{
    public enum Faction { Sweets, Ice, Neutral }
    public enum Rarity { Common, Epic, Legendary }
    public enum CardType { Unit, Spell, Artifact, Location }
    public enum Row { Front, Ranged, Magic }
    [System.Flags]
    public enum Keyword { None = 0, Armor = 1 << 0, Poison = 1 << 1, Draw = 1 << 2, Nuke = 1 << 3, Spy = 1 << 4 }
}