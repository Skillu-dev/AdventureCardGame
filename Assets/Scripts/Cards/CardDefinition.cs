using UnityEngine;

namespace ACG
{
    [CreateAssetMenu(menuName = "ACG/Card Definition", fileName = "Card_")]
    public class CardDefinition : ScriptableObject
    {
        [Header("Identyfikacja")]
        [SerializeField] string id;
        [SerializeField] string displayName;

        [Header("Klasyfikacja")]
        [SerializeField] Faction faction = Faction.Neutral;
        [SerializeField] Rarity rarity = Rarity.Common;
        [SerializeField] CardType type = CardType.Unit;
        [SerializeField] Row preferredRow = Row.Front;
        [SerializeField] Keyword keywords = Keyword.None;

        [Header("Parametry")]
        [SerializeField] int basePower = 1;     // wyœwietlane na froncie (lewy-górny róg)
        [SerializeField] int baseArmor = 0;     // wyœwietlane jako tarcza (PPM i ikona na froncie)
        [SerializeField] int recruitCost = 5;   // pokazywane tylko w PPM

        [Header("Opis i grafika")]
        [TextArea(2, 5)][SerializeField] string rulesText;
        [SerializeField] Sprite artwork;
        [SerializeField] Sprite frameSprite;
        [SerializeField] Color frameColor = Color.white;

        public string Id => id;
        public string DisplayName => displayName;
        public Faction Faction => faction;
        public Rarity Rarity => rarity;
        public CardType Type => type;
        public Row PreferredRow => preferredRow;
        public Keyword Keywords => keywords;
        public int BasePower => basePower;
        public int BaseArmor => baseArmor;
        public int RecruitCost => recruitCost;
        public string RulesText => rulesText;
        public Sprite Artwork => artwork;
        public Sprite FrameSprite => frameSprite;
        public Color FrameColor => frameColor;
    }
}