using CardData.AbilityInterfaces;
using CardData.BaseTypes;
using System;
using UnityEngine;

namespace CardData.CardTypes
{
    [Serializable, CreateAssetMenu(fileName = "New Spell Card", menuName = "Card Data / Spell Card", order = 1)]
    public class SpellCard : Card
    {
        public CardAbility[] abilities;

        public SpellCard()
        {
        }

        public SpellCard(int id, string cardName, Texture2D cardImage, int cost, string cardDescription, params CardAbility[] abilities) : base(id, cardName, cardImage, cost, cardDescription)
        {
            this.abilities = abilities;
        }
    }
}