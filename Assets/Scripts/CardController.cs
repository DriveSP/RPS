using System;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public bool CardFlipped { get; set; }
    public string CardName { get; set; }
    public string Description { get; set; }
    public List<Card> Strongs { get; set; }
    public List<Card> Weaks { get; set; }
}
