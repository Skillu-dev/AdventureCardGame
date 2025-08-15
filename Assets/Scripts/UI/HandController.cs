using UnityEngine;
using System.Collections.Generic;

namespace ACG
{
    public class HandController : MonoBehaviour
    {
        public CardView CardViewPrefab;
        [Tooltip("Do testów: przeci¹gnij do 10 definicji kart")]
        public List<CardDefinition> StartingHand = new();

        void Start()
        {
            int count = Mathf.Min(StartingHand.Count, 10);
            for (int i = 0; i < count; i++)
            {
                var def = StartingHand[i];
                if (!def) continue;
                var view = Instantiate(CardViewPrefab, transform);
                view.Definition = def;
                view.ApplyDefinition();
            }
        }
    }
}