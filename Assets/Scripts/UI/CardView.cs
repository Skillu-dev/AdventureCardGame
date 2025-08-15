using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

namespace ACG
{
    public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Header("Refs")]
        public CardDefinition Definition;
        public Image ArtworkImage;
        public Image FrameImage;
        public Image RarityStripe;
        public TextMeshProUGUI PowerText;
        public GameObject ArmorGroup;
        public TextMeshProUGUI ArmorText;

        RectTransform _rt;
        Vector3 _baseScale;
        Vector2 _basePos;
        Coroutine _hoverCo;

        const float HoverScale = 1.08f;
        const float HoverMoveY = 20f;
        const float HoverTime = 0.15f;

        void Awake()
        {
            _rt = (RectTransform)transform;
            _baseScale = _rt.localScale;
            _basePos = _rt.anchoredPosition;
        }

        void Start() => ApplyDefinition();

        public void ApplyDefinition()
        {
            if (!Definition) return;

            if (ArtworkImage) ArtworkImage.sprite = Definition.Artwork;
            if (FrameImage)
            {
                FrameImage.color = Definition.FrameColor == Color.white
                    ? Palette.RarityColor(Definition.Rarity)
                    : Definition.FrameColor;

                if (Definition.FrameSprite) FrameImage.sprite = Definition.FrameSprite;
            }
            if (RarityStripe) RarityStripe.color = Palette.RarityColor(Definition.Rarity);

            if (PowerText) PowerText.text = Definition.BasePower.ToString();

            if (ArmorGroup) ArmorGroup.SetActive(Definition.BaseArmor > 0);
            if (ArmorText) ArmorText.text = Definition.BaseArmor.ToString();
        }

        public void OnPointerEnter(PointerEventData e)
        {
            if (_hoverCo != null) StopCoroutine(_hoverCo);
            _hoverCo = StartCoroutine(HoverAnim(true));
            TooltipService.Instance?.ShowSmall(Definition, e);
        }

        public void OnPointerExit(PointerEventData e)
        {
            if (_hoverCo != null) StopCoroutine(_hoverCo);
            _hoverCo = StartCoroutine(HoverAnim(false));
            TooltipService.Instance?.HideSmall();
        }

        public void OnPointerClick(PointerEventData e)
        {
            if (e.button == PointerEventData.InputButton.Right)
            {
                TooltipService.Instance?.ShowBig(Definition);
            }
            // LPM (wybór/zagranie) dodamy w etapie tur.
        }

        IEnumerator HoverAnim(bool up)
        {
            float t = 0f;
            var startS = _rt.localScale;
            var targetS = up ? _baseScale * HoverScale : _baseScale;
            var startP = _rt.anchoredPosition;
            var targetP = up ? _basePos + new Vector2(0, HoverMoveY) : _basePos;

            while (t < HoverTime)
            {
                t += Time.unscaledDeltaTime;
                float a = Mathf.SmoothStep(0, 1, t / HoverTime);
                _rt.localScale = Vector3.Lerp(startS, targetS, a);
                _rt.anchoredPosition = Vector2.Lerp(startP, targetP, a);
                yield return null;
            }
            _rt.localScale = targetS;
            _rt.anchoredPosition = targetP;
        }
    }
}