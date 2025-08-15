using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

namespace ACG
{
    public class TooltipSmall : MonoBehaviour
    {
        public RectTransform Root;
        public Image HeaderBg;
        public Image BodyBg;
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI TypesText;
        public TextMeshProUGUI RulesText;

        public void Set(CardDefinition def)
        {
            NameText.text = def.DisplayName;
            TypesText.text = $"{def.Type}, {def.Faction}";
            RulesText.text = def.RulesText;

            if (HeaderBg) HeaderBg.color = Palette.FactionColor(def.Faction);
            if (BodyBg) BodyBg.color = Palette.FactionColorLight(def.Faction);
        }

        public void Follow(PointerEventData ev)
        {
            var parent = Root.parent as RectTransform;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parent, ev.position, ev.pressEventCamera, out var p);
            Root.anchoredPosition = p + new Vector2(20f, 20f);
        }
    }
}