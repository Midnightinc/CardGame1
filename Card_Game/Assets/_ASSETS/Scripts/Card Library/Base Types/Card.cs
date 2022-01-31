using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardData.BaseTypes
{
    [Serializable]
    public class Card : ScriptableObject, IEquatable<Card>
    {
        public int id;
        public string cardName;
        public Texture2D cardImage;

        public int cost;
        public string cardDescription;

        public Card() { }

        public Card(int id, string cardName, Texture2D cardImage, int cost, string cardDescription)
        {
            this.id = id;
            this.cardName = cardName;
            this.cardImage = cardImage;
            this.cost = cost;
            this.cardDescription = cardDescription;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public bool Equals(Card other)
        {
            return other != null &&
                   id == other.id &&
                   cardName == other.cardName &&
                   EqualityComparer<Texture2D>.Default.Equals(cardImage, other.cardImage) &&
                   cost == other.cost &&
                   cardDescription == other.cardDescription;
        }

        public override int GetHashCode()
        {
            int hashCode = 2038986315;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cardName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Texture2D>.Default.GetHashCode(cardImage);
            hashCode = hashCode * -1521134295 + cost.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cardDescription);
            return hashCode;
        }

        public static bool operator ==(Card left, Card right)
        {
            return EqualityComparer<Card>.Default.Equals(left, right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }
    }
}