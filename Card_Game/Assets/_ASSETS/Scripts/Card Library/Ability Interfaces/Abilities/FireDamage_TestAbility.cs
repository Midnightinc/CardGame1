using CardData.AbilityInterfaces;
using CardData.BaseTypes;
using UnityEngine;

namespace CardData.Abilities
{
    [System.Serializable]
    public class FireDamage_TestAbility : CardAbility
    {
        public override void UseOnCard(Card onCard)
        {
            Debug.Log($"{onCard.cardName} has been damaged by FireDamage Test");
        }
    }
}
