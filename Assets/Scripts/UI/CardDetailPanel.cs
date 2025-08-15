using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ACG
{
    public class CardDetailPanel : MonoBehaviour
    {
        [Header("Lewa kolumna")]
        public Image ArtworkLarge;
        public TextMeshProUGUI PowerText;
        public GameObject ArmorGroup;
        public TextMeshProUGUI ArmorText;
        public TextMeshProUGUI RecruitCostText;

        [Header("Prawa kolumna")]
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI TypesText;
        public TextMeshProUGUI RulesText;

        [Header("Kontrola")]
        public Button CloseButton;

        void Awake()
        {
            if (CloseButton) CloseButton.onClick.AddListener(() => gameObject.SetActive(false));
        }

        public void Set(CardDefinition def)
        {
            if (ArtworkLarge) ArtworkLarge.sprite = def.Artwork;
            if (PowerText) PowerText.text = def.BasePower.ToString();
            if (ArmorGroup) ArmorGroup.SetActive(def.BaseArmor > 0);
            if (ArmorText) ArmorText.text = def.BaseArmor.ToString();
            if (RecruitCostText) RecruitCostText.text = def.RecruitCost.ToString();

            if (NameText) NameText.text = def.DisplayName;
            if (TypesText) TypesText.text = $"{def.Type} • {def.Faction}";
            if (RulesText) RulesText.text = def.RulesText;
        }
    }
}