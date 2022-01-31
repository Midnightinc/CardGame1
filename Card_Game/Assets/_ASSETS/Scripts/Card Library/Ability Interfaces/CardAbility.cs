using CardData.BaseTypes;
using UnityEngine;

namespace CardData.AbilityInterfaces
{
    public abstract class CardAbility : ScriptableObject
    {
        public abstract void UseOnCard(Card onCard);
    }
}