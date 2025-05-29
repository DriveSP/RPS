using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
    public Sprite sprite;
    public string cardName;
    public string description;
    public List<Card> strongs;
    public List<Card> weaks;
}
