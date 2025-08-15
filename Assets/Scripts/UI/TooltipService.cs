using UnityEngine;
using UnityEngine.EventSystems;

namespace ACG
{
    public class TooltipService : MonoBehaviour
    {
        public static TooltipService Instance { get; private set; }

        public TooltipSmall SmallPrefab;
        public CardDetailPanel BigPrefab;

        TooltipSmall _small;
        CardDetailPanel _big;
        Canvas _canvas;

        void Awake()
        {
            if (Instance && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            _canvas = GetComponentInParent<Canvas>();
        }

        public void ShowSmall(CardDefinition def, PointerEventData ev)
        {
            if (!def) return;
            if (!_small) _small = Instantiate(SmallPrefab, _canvas.transform);
            _small.Set(def);
            _small.gameObject.SetActive(true);
            _small.Follow(ev);
        }

        public void HideSmall()
        {
            if (_small) _small.gameObject.SetActive(false);
        }

        public void ShowBig(CardDefinition def)
        {
            if (!def) return;
            if (!_big) _big = Instantiate(BigPrefab, _canvas.transform);
            _big.Set(def);
            _big.gameObject.SetActive(true);
            HideSmall();
        }
    }
}